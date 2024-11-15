using Ni.Mathematics;
using Ni.Mathematics.Editor;
using Unity.Mathematics;
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
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float t) => ray.Cast(transform.ToNonUniformTransform().Mul(Obb3T), maxDistance, out t);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float t) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out t);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float tIn, out float tOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out tOut);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float t, out float3 normal)
    //{
    //    var trf = transform.ToNonUniformTransform();
    //    trf.Untransform(ray).Cast(Obb3T, maxDistance, out t, out normal);
    //    normal = trf.Rotation3.Transform(normal);
    //}
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float tIn, out float3 normalIn, out float tOut, out float3 normalOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out float3 point) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out point);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out LineSegment3 intersection) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out intersection);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out Ray3 pointNormal) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out pointNormal);
    //public bool Raycast(Transform transform, Ray3 ray, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out pointNormalIn, out pointNormalOut);

    //public bool Raycast(Ray3 ray, float maxDistance, out float t) => ray.Cast(transform.ToNonUniformTransform().Mul(Obb3T), maxDistance, out t);
    public bool Raycast(Ray3 ray, float maxDistance, out float t) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Obb3T, maxDistance, out t);
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float tOut) => transform.GetNonUniformTransform3().Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out tOut);
    public bool Raycast(Ray3 ray, float maxDistance, out float t, out Direction3 normal)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Obb3T, maxDistance, out t, out normal);
        normal = trf.Transform(normal);
        return result;
    }
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut)
    {
        var trf = transform.GetNonUniformTransform3();
        var result = trf.Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
        normalIn = trf.Transform(normalIn);
        normalOut = trf.Transform(normalOut);
        return result;
    }


    //public bool Raycast(Ray3 ray, float maxDistance, out float t) => ray.Cast(transform.ToNonUniformTransform().Mul(Obb3T), maxDistance, out t);
    //public bool Raycast(Ray3 ray, float maxDistance, out float t) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out t);
    //public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float tOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out tOut);
    //public bool Raycast(Ray3 ray, float maxDistance, out float t, out float3 normal) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out t, out normal);
    //public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float3 normalIn, out float tOut, out float3 normalOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out tIn, out normalIn, out tOut, out normalOut);
    //public bool Raycast(Ray3 ray, float maxDistance, out float3 point) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out point);
    //public bool Raycast(Ray3 ray, float maxDistance, out LineSegment3 intersection) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out intersection);
    //public bool Raycast(Ray3 ray, float maxDistance, out Ray3 pointNormal) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out pointNormal);
    //public bool Raycast(Ray3 ray, float maxDistance, out Ray3 pointNormalIn, out Ray3 pointNormalOut) => transform.ToNonUniformTransform().Untransform(ray).Cast(Obb3T, maxDistance, out pointNormalIn, out pointNormalOut);

}
