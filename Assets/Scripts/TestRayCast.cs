using Ni.Mathematics;
using Ni.Mathematics.Editor;
using System.Collections.Generic;
using Unity.Mathematics;
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
            if(primitive.Raycast(Ray, MaxDistance, out float tIn, out Direction3 nIn, out float tOut, out Direction3 nOut))
            {
                ++hits;
                var hitIn = Ray[tIn];
                var hitOut = Ray[tOut];
                Gizmos.color = Color.red;
                var scaleIn = HitCrossScale + HitCrossLogScale * Unity.Mathematics.math.log2(1 + tIn);
                var scaleOut = HitCrossScale + HitCrossLogScale * Unity.Mathematics.math.log2(1 + tOut);

                NiMathGizmos.DrawAaCross3(hitIn, scaleIn);
                NiMathGizmos.DrawAaCross3(hitOut, scaleOut);
                Gizmos.DrawLine(hitIn, hitOut);
                Gizmos.color = new Color(1, 0, 0, 0.3f);
                Gizmos.DrawLine(Ray.origin, hitIn);

                Gizmos.color = new Color(1, 0.5f, 0, 1);
                Gizmos.DrawLine(hitIn, hitIn + nIn.vector * scaleIn);
                //Gizmos.color = new Color(1, 0.5f, 0, 1);
                Gizmos.DrawLine(hitOut, hitOut + nOut.vector * scaleOut);
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
