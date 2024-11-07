using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;

public class Obb3TComponent : MonoBehaviour, INiMathPrimitive3
{
    public Obb3T Obb3T = Obb3T.Identity;
    public bool ShowGizmo;
    void OnDrawGizmos()
    {
        if (ShowGizmo)
            NiMathGizmos.Draw(Obb3T, transform);
    }
    public bool RaycastT(Ray3 ray, float maxDistance, out float t)
    {
        var localRay = transform.ToNonUniformTransform().Untransform(ray);
        return NiMath.Raycast1(localRay, Obb3T, maxDistance, out t);
    }
}
