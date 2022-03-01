using System;
using UnityEngine;

namespace Utils
{
	// Token: 0x02000163 RID: 355
	public static class TransformUtil
	{
		// Token: 0x06000A35 RID: 2613 RVA: 0x00035947 File Offset: 0x00033D47
		public static Matrix4x4 GetMatrix(this Transform trans)
		{
			return trans.localToWorldMatrix;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00035950 File Offset: 0x00033D50
		public static Matrix4x4 GetRelativeMatrix(this Transform trans, Transform relativeTo)
		{
			Matrix4x4 localToWorldMatrix = trans.localToWorldMatrix;
			return relativeTo.worldToLocalMatrix * localToWorldMatrix;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00035970 File Offset: 0x00033D70
		public static Matrix4x4 GetLocalMatrix(this Transform trans)
		{
			return Matrix4x4.TRS(trans.localPosition, trans.localRotation, trans.localScale);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00035989 File Offset: 0x00033D89
		public static void GetTransformFromMatrix(this Transform trans, Matrix4x4 m)
		{
			trans.localPosition = m.GetTranslation();
			trans.localRotation = m.GetRotation();
			trans.localScale = m.GetScale();
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x000359B0 File Offset: 0x00033DB0
		public static Vector3 GetTranslation(this Matrix4x4 m)
		{
			Vector4 column = m.GetColumn(3);
			return new Vector3(column.x, column.y, column.z);
		}

		// Token: 0x06000A3A RID: 2618 RVA: 0x000359E0 File Offset: 0x00033DE0
		public static Quaternion GetRotation(this Matrix4x4 matrix)
		{
			Vector3 vector;
			vector.x = matrix.m02;
			vector.y = matrix.m12;
			vector.z = matrix.m22;
			Vector3 vector2;
			vector2.x = matrix.m01;
			vector2.y = matrix.m11;
			vector2.z = matrix.m21;
			return Quaternion.LookRotation(vector, vector2);
		}

		// Token: 0x06000A3B RID: 2619 RVA: 0x00035A48 File Offset: 0x00033E48
		public static Vector3 GetScale(this Matrix4x4 matrix)
		{
			Vector3 result;
			result..ctor(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);
			if (Vector3.Cross(matrix.GetColumn(0), matrix.GetColumn(1)).normalized != matrix.GetColumn(2).normalized)
			{
				result.x *= -1f;
			}
			return result;
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x00035AE8 File Offset: 0x00033EE8
		public static Vector3 ParentTransformPoint(this Transform t, Vector3 pnt)
		{
			if (t.parent == null)
			{
				return pnt;
			}
			return t.parent.TransformPoint(pnt);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x00035B09 File Offset: 0x00033F09
		public static Vector3 ParentInverseTransformPoint(this Transform t, Vector3 pnt)
		{
			if (t.parent == null)
			{
				return pnt;
			}
			return t.parent.InverseTransformPoint(pnt);
		}

		// Token: 0x06000A3E RID: 2622 RVA: 0x00035B2A File Offset: 0x00033F2A
		public static Vector3 GetRelativePosition(this Transform trans, Transform relativeTo)
		{
			return relativeTo.InverseTransformPoint(trans.position);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00035B38 File Offset: 0x00033F38
		public static Quaternion GetRelativeRotation(this Transform trans, Transform relativeTo)
		{
			return Quaternion.Inverse(relativeTo.rotation) * trans.rotation;
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00035B50 File Offset: 0x00033F50
		public static Vector3 ScaleVector(this Matrix4x4 m, Vector3 v)
		{
			Vector3 scale = m.GetScale();
			return Matrix4x4.Scale(scale).MultiplyPoint(v);
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x00035B74 File Offset: 0x00033F74
		public static Vector3 ScaleVector(this Transform t, Vector3 v)
		{
			Vector3 scale = t.localToWorldMatrix.GetScale();
			return Matrix4x4.Scale(scale).MultiplyPoint(v);
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00035B9C File Offset: 0x00033F9C
		public static Vector3 InverseScaleVector(this Matrix4x4 m, Vector3 v)
		{
			Vector3 scale = m.inverse.GetScale();
			return Matrix4x4.Scale(scale).MultiplyPoint(v);
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00035BC8 File Offset: 0x00033FC8
		public static Vector3 InverseScaleVector(this Transform t, Vector3 v)
		{
			Vector3 scale = t.worldToLocalMatrix.GetScale();
			return Matrix4x4.Scale(scale).MultiplyPoint(v);
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x00035BF0 File Offset: 0x00033FF0
		public static Quaternion TranformRotation(this Matrix4x4 m, Quaternion rot)
		{
			return rot * m.GetRotation();
		}

		// Token: 0x06000A45 RID: 2629 RVA: 0x00035BFE File Offset: 0x00033FFE
		public static Quaternion TransformRotation(this Transform t, Quaternion rot)
		{
			return rot * t.rotation;
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x00035C0C File Offset: 0x0003400C
		public static Quaternion InverseTranformRotation(this Matrix4x4 m, Quaternion rot)
		{
			return Quaternion.Inverse(m.GetRotation()) * rot;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00035C1F File Offset: 0x0003401F
		public static Quaternion InverseTransformRotation(this Transform t, Quaternion rot)
		{
			return Quaternion.Inverse(t.rotation) * rot;
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x00035C32 File Offset: 0x00034032
		public static Ray TransformRay(this Matrix4x4 m, Ray r)
		{
			return new Ray(m.MultiplyPoint(r.origin), m.MultiplyVector(r.direction));
		}

		// Token: 0x06000A49 RID: 2633 RVA: 0x00035C55 File Offset: 0x00034055
		public static Ray TransformRay(this Transform t, Ray r)
		{
			return new Ray(t.TransformPoint(r.origin), t.TransformDirection(r.direction));
		}

		// Token: 0x06000A4A RID: 2634 RVA: 0x00035C76 File Offset: 0x00034076
		public static Ray InverseTransformRay(this Matrix4x4 m, Ray r)
		{
			m = m.inverse;
			return new Ray(m.MultiplyPoint(r.origin), m.MultiplyVector(r.direction));
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x00035CA2 File Offset: 0x000340A2
		public static Ray InverseTransformRay(this Transform t, Ray r)
		{
			return new Ray(t.InverseTransformPoint(r.origin), t.InverseTransformDirection(r.direction));
		}

		// Token: 0x06000A4C RID: 2636 RVA: 0x00035CC4 File Offset: 0x000340C4
		public static void TransposeAroundGlobalAnchor(this Transform trans, Vector3 anchor, Vector3 position, Quaternion rotation)
		{
			anchor = trans.InverseTransformPoint(anchor);
			if (trans.parent != null)
			{
				position = trans.parent.InverseTransformPoint(position);
				rotation = trans.parent.InverseTransformRotation(rotation);
			}
			trans.LocalTransposeAroundAnchor(anchor, position, rotation);
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x00035D10 File Offset: 0x00034110
		public static void TransposeAroundAnchor(this Transform trans, Vector3 anchor, Vector3 position, Quaternion rotation)
		{
			if (trans.parent != null)
			{
				position = trans.parent.InverseTransformPoint(position);
				rotation = trans.parent.InverseTransformRotation(rotation);
			}
			trans.LocalTransposeAroundAnchor(anchor, position, rotation);
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00035D48 File Offset: 0x00034148
		public static void TransposeAroundAnchor(this Transform trans, Transform anchor, Vector3 position, Quaternion rotation)
		{
			if (trans.parent != null)
			{
				position = trans.parent.InverseTransformPoint(position);
				rotation = trans.parent.InverseTransformRotation(rotation);
			}
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x00035D77 File Offset: 0x00034177
		public static void LocalTransposeAroundAnchor(this Transform trans, Vector3 anchor, Vector3 position, Quaternion rotation)
		{
			anchor = rotation * Vector3.Scale(anchor, trans.localScale);
			trans.localPosition = position - anchor;
			trans.localRotation = rotation;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x00035DA4 File Offset: 0x000341A4
		public static void LocalTransposeAroundAnchor(this Transform trans, Transform anchor, Vector3 position, Quaternion rotation)
		{
			Matrix4x4 relativeMatrix = anchor.GetRelativeMatrix(trans);
			Vector3 vector = rotation * Vector3.Scale(relativeMatrix.GetTranslation(), trans.localScale);
			trans.localPosition = position - vector;
			trans.localRotation = relativeMatrix.GetRotation() * rotation;
		}
	}
}
