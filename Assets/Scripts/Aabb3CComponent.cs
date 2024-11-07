using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;

public class Aabb3CComponent : MonoBehaviour, INiMathPrimitive3
{
    public Aabb3C Aabb3C = Aabb3C.Identity;
    public bool ShowGizmo;
    void OnDrawGizmos()
    {
        if (ShowGizmo)
            NiMathGizmos.Draw(Aabb3C, transform);
    }
    public bool RaycastT(Ray3 ray, float maxDistance, out float t)
    {
        var localRay = transform.ToNonUniformTransform().Untransform(ray);
        return NiMath.Raycast1(localRay, Aabb3C, maxDistance, out t);
    }
}
