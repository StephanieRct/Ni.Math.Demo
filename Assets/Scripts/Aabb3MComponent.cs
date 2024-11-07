using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;

public class Aabb3MComponent : MonoBehaviour, INiMathPrimitive3
{
    public Aabb3M Aabb3M = Aabb3M.Identity;
    public bool ShowGizmo;
    void OnDrawGizmos()
    {
        if (ShowGizmo)
            NiMathGizmos.Draw(Aabb3M, transform);
    }
    public bool RaycastT(Ray3 ray, float maxDistance, out float t)
    {
        var localRay = transform.ToNonUniformTransform().Untransform(ray);
        return NiMath.Raycast1(localRay, Aabb3M, maxDistance, out t);
    }
}
