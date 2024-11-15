using Ni.Mathematics;
using Ni.Mathematics.Editor;
using Unity.Mathematics;
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


    public bool Raycast(Ray3 ray, float maxDistance, out float t) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Aabb3C, maxDistance, out t);
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float tOut) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Aabb3C, maxDistance, out tIn, out tOut);
    public bool Raycast(Ray3 ray, float maxDistance, out float t, out Direction3 normal)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Aabb3C, maxDistance, out t, out normal);
        normal = trf.Transform(normal);
        return result;
    }
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Aabb3C, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
        normalIn = trf.Transform(normalIn);
        normalOut = trf.Transform(normalOut);
        return result;
    }

}
