using Ni.Mathematics;
using Ni.Mathematics.Editor;
using System.Collections.Generic;
using UnityEngine;

public class TestRayCast : MonoBehaviour
{
    public Transform RayObject;
    public float MaxDistance = 100;
    public Ray3 Ray;
    public float HitCrossScale = 0.2f;
    public float HitCrossLogScale = 0.0f;
    void OnValidate()
    {
        Ray = new Ray3(RayObject.position, RayObject.forward * RayObject.lossyScale.z);
    }

    void OnDrawGizmos()
    {
        NiMathGizmos.Draw(Ray);

        Ray = new Ray3(RayObject.position, RayObject.forward * RayObject.lossyScale.z);
        int hits = 0;
        var allPrimitives = GetAllComponentsOfType<INiMathPrimitive3>();
        foreach (var primitive in allPrimitives)
        {
            if (primitive is Component component && !component.gameObject.activeInHierarchy)
                continue;
            if(primitive.RaycastT(Ray, MaxDistance, out var t))
            {
                ++hits;
                var hit = Ray[t];
                Gizmos.color = Color.red;
                NiMathGizmos.DrawAaCross3(hit, HitCrossScale + HitCrossLogScale * Unity.Mathematics.math.log2(1 + t));
                Gizmos.color = new Color(1, 0, 0, 0.3f);
                Gizmos.DrawLine(Ray.origin, hit);
            }

        }
        if(hits == 0)
        {
            Gizmos.color = new Color(1, 0, 0, 0.3f);
            Gizmos.DrawLine(Ray[0], Ray[MaxDistance]);
        }
    }

    IEnumerable<T> GetAllComponentsOfType<T>()
    {
        var roots = gameObject.scene.GetRootGameObjects();
        foreach (var root in roots)
        {
            foreach (var o in root.GetComponentsInChildren<T>())
                yield return o;
        }
    }
}
