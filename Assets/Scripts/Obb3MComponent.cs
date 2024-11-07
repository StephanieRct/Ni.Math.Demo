using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;
public class Obb3MComponent : MonoBehaviour, INiMathPrimitive3
{
    public Obb3M Obb3M = Obb3M.Identity;
    public bool ShowGizmo;
    void OnDrawGizmos()
    {
        if(ShowGizmo)
            NiMathGizmos.Draw(Obb3M, transform);
    }
    public bool RaycastT(Ray3 ray, float maxDistance, out float t)
    {
        var localRay = transform.ToNonUniformTransform().Untransform(ray);
        return NiMath.Raycast1(localRay, Obb3M, maxDistance, out t);
    }
}
