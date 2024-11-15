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
    public bool Raycast(Ray3 ray, float maxDistance, out float t) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Obb3M, maxDistance, out t);
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float tOut) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Obb3M, maxDistance, out tIn, out tOut);
    public bool Raycast(Ray3 ray, float maxDistance, out float t, out Direction3 normal)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Obb3M, maxDistance, out t, out normal);
        normal = trf.Transform(normal);
        return result;
    }
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Obb3M, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
        normalIn = trf.Transform(normalIn);
        normalOut = trf.Transform(normalOut);
        return result;
    }


}
