using Ni.Mathematics;
using UnityEngine;

public class TestTransformUI : MonoBehaviour
{
    public Translation3 MyTranslationTransform3 = Translation3.Identity;
    public Rotation3Q MyRotationQTransform3 = Rotation3Q.Identity;
    public Rotation3Euler MyRotationEulerTransform3 = Rotation3Euler.Identity;
    public Scale1 MyScaleUniformTransform3 = Scale1.Identity;
    public Scale3 MyScaleNonUniformTransform3 = Scale3.Identity;
    public RigidTransform3 MyRigidTransform3 = RigidTransform3.Identity;
    public UniformTransform3 MyUniformTransform3 = UniformTransform3.Identity;
    public NonUniformTransform3 MyNonUniformTransform3 = NonUniformTransform3.Identity;
    public Matrix3x3Transform3 MyMatrix3x3Transform3 = Matrix3x3Transform3.Identity;
    public Matrix4x4Transform3 MyMatrix4x4Transform3 = Matrix4x4Transform3.Identity;
    public Aabb3M MyAabb3M = Aabb3M.Identity;
    public Aabb3S MyAabb3S = Aabb3S.Identity;
    public Aabb3C MyAabb3C = Aabb3C.Identity;
    public Obb3T MyObb3T = Obb3T.Identity;
    public Obb3M MyObb3M = Obb3M.Identity;
}
