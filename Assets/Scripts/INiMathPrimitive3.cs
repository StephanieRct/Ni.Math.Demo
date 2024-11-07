using Ni.Mathematics;
using Ni.Mathematics.Editor;
using UnityEngine;

public interface INiMathPrimitive3
{
    public bool RaycastT(Ray3 ray, float maxDistance, out float t);
}