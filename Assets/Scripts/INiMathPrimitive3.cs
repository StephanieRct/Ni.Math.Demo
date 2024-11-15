using Ni.Mathematics;
using Unity.Mathematics;

public interface INiMathPrimitive3
{
    public bool Raycast(Ray3 ray, float maxDistance, out float t);
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out float tOut);
    public bool Raycast(Ray3 ray, float maxDistance, out float t, out Direction3 normal);
    public bool Raycast(Ray3 ray, float maxDistance, out float tIn, out Direction3 normalIn, out float tOut, out Direction3 normalOut);
}