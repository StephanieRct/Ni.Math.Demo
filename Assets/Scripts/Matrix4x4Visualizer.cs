using Ni.Mathematics;
using Ni.Mathematics.Editor;
using System;
using UnityEngine;

public class Matrix4x4Visualizer : MonoBehaviour
{
    [Serializable]
    public class Compose
    {
        public Translation3 Translation = Translation3.Identity;
        public Rotation3Q Rotation3Q = Rotation3Q.Identity;
        public ShearXY3 Shear = ShearXY3.Identity;
        public Scale3 Scale = Scale3.Identity;
        public Matrix4x4Transform3 Matrix = Matrix4x4Transform3.Identity;
        public bool IsOrthogonal;
        public bool IsOrthonormal;
    }
    public Compose Composed;

    [Serializable]
    public class Decompose
    {
        public bool CopyFromComposed = true;
        public Matrix4x4Transform3 Matrix = Matrix4x4Transform3.Identity;
        public Translation3 Translation = Translation3.Identity;
        public Rotation3Q Rotation3Q = Rotation3Q.Identity;
        public Matrix3x3Transform3 Rotation3M = Matrix3x3Transform3.Identity;
        public ShearXY3 Shear = ShearXY3.Identity;
        public Scale3 Scale = Scale3.Identity;
        public bool IsOrthogonal;
        public bool IsOrthonormal;
        public Rotation3Q OrthonormalRotation3Q = Rotation3Q.Identity;
    }
    public Decompose Decomposed;

    public bool ShowGizmo = true;
    public bool ComposedCopyToGizmo = true;
    public bool DecomposedCopyToGizmo = false;
    public Matrix4x4Transform3 GizmoMatrix = Matrix4x4Transform3.Identity;


    void OnDrawGizmos()
    {
        if (ShowGizmo)
            NiMathGizmos.Draw(new Obb3M(GizmoMatrix), transform);
    }

    void OnValidate()
    {


        Composed.Matrix = NiMath.Mul(Composed.Translation, NiMath.Mul(Composed.Rotation3Q, NiMath.Mul(Matrix4x4Transform3.Shearing(Composed.Shear.shear), Composed.Scale)));
        Composed.IsOrthogonal = Composed.Matrix.isOrthogonal;
        Composed.IsOrthonormal = Composed.Matrix.isOrthonormal;
        if (Decomposed.CopyFromComposed)
            Decomposed.Matrix = Composed.Matrix;

        Decomposed.Translation = Decomposed.Matrix.Translation3;
        Decomposed.Rotation3Q = Decomposed.Matrix.Rotation3;
        Decomposed.Rotation3M = Decomposed.Matrix.Rotation3M;
        Decomposed.Shear = Decomposed.Matrix.Shear3;
        Decomposed.Scale = Decomposed.Matrix.Scale3;
        Decomposed.IsOrthogonal = Decomposed.Matrix.isOrthogonal;
        Decomposed.IsOrthonormal = Decomposed.Matrix.isOrthonormal;

        Decomposed.OrthonormalRotation3Q = Decomposed.Matrix.rotation3Orthonormal;

        if (ComposedCopyToGizmo)
            GizmoMatrix = Composed.Matrix;

        if (DecomposedCopyToGizmo)
            GizmoMatrix = Decomposed.Matrix;
        
        //var shear = new float4x4(1, ShearYX, ShearZX,
        //                         ShearXY, 1, ShearZY,
        //                         ShearXZ, ShearYZ, 1);

        //var shear = new float4x4(1, Shear0.y, Shear0.z, 0,
        //                         Shear0.x, 1, Shear1.z, 0,
        //                         Shear1.x, Shear1.y, 1, 0,
        //                         0,0,0,1);
        //Obb3M.Matrix4x4Transform.matrix = math.mul(shear, Base.matrix);

        //var m = Obb3M.Matrix4x4Transform.matrix;
        //Shear0 = new float3(m.c1.x, m.c2.x, m.c2.y) / new float3(m.c1.y, m.c2.z, m.c2.z);
        //Shear0 = new float3(m.c0.y, m.c0.z, m.c1.z) / new float3(m.c0.x, m.c0.x, m.c1.y);
    }

}
