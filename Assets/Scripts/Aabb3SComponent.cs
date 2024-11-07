using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;

public class Aabb3SComponent : MonoBehaviour, INiMathPrimitive3
{
    public Aabb3S Aabb3S = Aabb3S.Identity;
    public bool ShowGizmo;
    void OnDrawGizmos()
    {
        if (ShowGizmo)
            NiMathGizmos.Draw(Aabb3S, transform);
    }
    public bool RaycastT(Ray3 ray, float maxDistance, out float t)
    {
        var localRay = transform.ToNonUniformTransform().Untransform(ray);
        return NiMath.Raycast1(localRay, Aabb3S, maxDistance, out t);
    }
}
