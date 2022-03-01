using System;
using UnityEngine;

namespace Spine.Unity
{
	// Token: 0x02004A23 RID: 18979
	public static class SkeletonExtensions
	{
		// Token: 0x0601B68D RID: 112269 RVA: 0x00873E0C File Offset: 0x0087220C
		public static Color GetColor(this Skeleton s)
		{
			return new Color(s.r, s.g, s.b, s.a);
		}

		// Token: 0x0601B68E RID: 112270 RVA: 0x00873E2B File Offset: 0x0087222B
		public static Color GetColor(this RegionAttachment a)
		{
			return new Color(a.r, a.g, a.b, a.a);
		}

		// Token: 0x0601B68F RID: 112271 RVA: 0x00873E4A File Offset: 0x0087224A
		public static Color GetColor(this MeshAttachment a)
		{
			return new Color(a.r, a.g, a.b, a.a);
		}

		// Token: 0x0601B690 RID: 112272 RVA: 0x00873E69 File Offset: 0x00872269
		public static Color GetColor(this Slot s)
		{
			return new Color(s.r, s.g, s.b, s.a);
		}

		// Token: 0x0601B691 RID: 112273 RVA: 0x00873E88 File Offset: 0x00872288
		public static Color GetColorTintBlack(this Slot s)
		{
			return new Color(s.r2, s.g2, s.b2, 1f);
		}

		// Token: 0x0601B692 RID: 112274 RVA: 0x00873EA6 File Offset: 0x008722A6
		public static void SetColor(this Skeleton skeleton, Color color)
		{
			skeleton.A = color.a;
			skeleton.R = color.r;
			skeleton.G = color.g;
			skeleton.B = color.b;
		}

		// Token: 0x0601B693 RID: 112275 RVA: 0x00873EDC File Offset: 0x008722DC
		public static void SetColor(this Skeleton skeleton, Color32 color)
		{
			skeleton.A = (float)color.a * 0.003921569f;
			skeleton.R = (float)color.r * 0.003921569f;
			skeleton.G = (float)color.g * 0.003921569f;
			skeleton.B = (float)color.b * 0.003921569f;
		}

		// Token: 0x0601B694 RID: 112276 RVA: 0x00873F39 File Offset: 0x00872339
		public static void SetColor(this Slot slot, Color color)
		{
			slot.A = color.a;
			slot.R = color.r;
			slot.G = color.g;
			slot.B = color.b;
		}

		// Token: 0x0601B695 RID: 112277 RVA: 0x00873F70 File Offset: 0x00872370
		public static void SetColor(this Slot slot, Color32 color)
		{
			slot.A = (float)color.a * 0.003921569f;
			slot.R = (float)color.r * 0.003921569f;
			slot.G = (float)color.g * 0.003921569f;
			slot.B = (float)color.b * 0.003921569f;
		}

		// Token: 0x0601B696 RID: 112278 RVA: 0x00873FCD File Offset: 0x008723CD
		public static void SetColor(this RegionAttachment attachment, Color color)
		{
			attachment.A = color.a;
			attachment.R = color.r;
			attachment.G = color.g;
			attachment.B = color.b;
		}

		// Token: 0x0601B697 RID: 112279 RVA: 0x00874004 File Offset: 0x00872404
		public static void SetColor(this RegionAttachment attachment, Color32 color)
		{
			attachment.A = (float)color.a * 0.003921569f;
			attachment.R = (float)color.r * 0.003921569f;
			attachment.G = (float)color.g * 0.003921569f;
			attachment.B = (float)color.b * 0.003921569f;
		}

		// Token: 0x0601B698 RID: 112280 RVA: 0x00874061 File Offset: 0x00872461
		public static void SetColor(this MeshAttachment attachment, Color color)
		{
			attachment.A = color.a;
			attachment.R = color.r;
			attachment.G = color.g;
			attachment.B = color.b;
		}

		// Token: 0x0601B699 RID: 112281 RVA: 0x00874098 File Offset: 0x00872498
		public static void SetColor(this MeshAttachment attachment, Color32 color)
		{
			attachment.A = (float)color.a * 0.003921569f;
			attachment.R = (float)color.r * 0.003921569f;
			attachment.G = (float)color.g * 0.003921569f;
			attachment.B = (float)color.b * 0.003921569f;
		}

		// Token: 0x0601B69A RID: 112282 RVA: 0x008740F5 File Offset: 0x008724F5
		public static void SetPosition(this Bone bone, Vector2 position)
		{
			bone.X = position.x;
			bone.Y = position.y;
		}

		// Token: 0x0601B69B RID: 112283 RVA: 0x00874111 File Offset: 0x00872511
		public static void SetPosition(this Bone bone, Vector3 position)
		{
			bone.X = position.x;
			bone.Y = position.y;
		}

		// Token: 0x0601B69C RID: 112284 RVA: 0x0087412D File Offset: 0x0087252D
		public static Vector2 GetLocalPosition(this Bone bone)
		{
			return new Vector2(bone.x, bone.y);
		}

		// Token: 0x0601B69D RID: 112285 RVA: 0x00874140 File Offset: 0x00872540
		public static Vector2 GetSkeletonSpacePosition(this Bone bone)
		{
			return new Vector2(bone.worldX, bone.worldY);
		}

		// Token: 0x0601B69E RID: 112286 RVA: 0x00874154 File Offset: 0x00872554
		public static Vector2 GetSkeletonSpacePosition(this Bone bone, Vector2 boneLocal)
		{
			Vector2 result;
			bone.LocalToWorld(boneLocal.x, boneLocal.y, out result.x, out result.y);
			return result;
		}

		// Token: 0x0601B69F RID: 112287 RVA: 0x00874184 File Offset: 0x00872584
		public static Vector3 GetWorldPosition(this Bone bone, Transform spineGameObjectTransform)
		{
			return spineGameObjectTransform.TransformPoint(new Vector3(bone.worldX, bone.worldY));
		}

		// Token: 0x0601B6A0 RID: 112288 RVA: 0x0087419D File Offset: 0x0087259D
		public static Vector3 GetWorldPosition(this Bone bone, Transform spineGameObjectTransform, float positionScale)
		{
			return spineGameObjectTransform.TransformPoint(new Vector3(bone.worldX * positionScale, bone.worldY * positionScale));
		}

		// Token: 0x0601B6A1 RID: 112289 RVA: 0x008741BC File Offset: 0x008725BC
		public static Quaternion GetQuaternion(this Bone bone)
		{
			float num = Mathf.Atan2(bone.c, bone.a) * 0.5f;
			return new Quaternion(0f, 0f, Mathf.Sin(num), Mathf.Cos(num));
		}

		// Token: 0x0601B6A2 RID: 112290 RVA: 0x008741FC File Offset: 0x008725FC
		public static Quaternion GetLocalQuaternion(this Bone bone)
		{
			float num = bone.rotation * 0.017453292f * 0.5f;
			return new Quaternion(0f, 0f, Mathf.Sin(num), Mathf.Cos(num));
		}

		// Token: 0x0601B6A3 RID: 112291 RVA: 0x00874238 File Offset: 0x00872638
		public static Matrix4x4 GetMatrix4x4(this Bone bone)
		{
			Matrix4x4 result = default(Matrix4x4);
			result.m00 = bone.a;
			result.m01 = bone.b;
			result.m03 = bone.worldX;
			result.m10 = bone.c;
			result.m11 = bone.d;
			result.m13 = bone.worldY;
			result.m33 = 1f;
			return result;
		}

		// Token: 0x0601B6A4 RID: 112292 RVA: 0x008742A8 File Offset: 0x008726A8
		public static void GetWorldToLocalMatrix(this Bone bone, out float ia, out float ib, out float ic, out float id)
		{
			float a = bone.a;
			float b = bone.b;
			float c = bone.c;
			float d = bone.d;
			float num = 1f / (a * d - b * c);
			ia = num * d;
			ib = num * -b;
			ic = num * -c;
			id = num * a;
		}

		// Token: 0x0601B6A5 RID: 112293 RVA: 0x008742FC File Offset: 0x008726FC
		public static Vector2 WorldToLocal(this Bone bone, Vector2 worldPosition)
		{
			Vector2 result;
			bone.WorldToLocal(worldPosition.x, worldPosition.y, out result.x, out result.y);
			return result;
		}

		// Token: 0x0601B6A6 RID: 112294 RVA: 0x0087432C File Offset: 0x0087272C
		public static Vector2 SetPositionSkeletonSpace(this Bone bone, Vector2 skeletonSpacePosition)
		{
			if (bone.parent == null)
			{
				bone.SetPosition(skeletonSpacePosition);
				return skeletonSpacePosition;
			}
			Bone parent = bone.parent;
			Vector2 vector = parent.WorldToLocal(skeletonSpacePosition);
			bone.SetPosition(vector);
			return vector;
		}

		// Token: 0x0601B6A7 RID: 112295 RVA: 0x00874364 File Offset: 0x00872764
		public static Material GetMaterial(this Attachment a)
		{
			object obj = null;
			IHasRendererObject hasRendererObject = a as IHasRendererObject;
			if (hasRendererObject != null)
			{
				obj = hasRendererObject.RendererObject;
			}
			if (obj == null)
			{
				return null;
			}
			return (Material)((AtlasRegion)obj).page.rendererObject;
		}

		// Token: 0x0601B6A8 RID: 112296 RVA: 0x008743A4 File Offset: 0x008727A4
		public static Vector2[] GetLocalVertices(this VertexAttachment va, Slot slot, Vector2[] buffer)
		{
			int worldVerticesLength = va.worldVerticesLength;
			int num = worldVerticesLength >> 1;
			buffer = (buffer ?? new Vector2[num]);
			if (buffer.Length < num)
			{
				throw new ArgumentException(string.Format("Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment's .WorldVerticesLength to get the correct size.", va.Name, worldVerticesLength), "buffer");
			}
			if (va.bones == null)
			{
				float[] vertices = va.vertices;
				for (int i = 0; i < num; i++)
				{
					int num2 = i * 2;
					buffer[i] = new Vector2(vertices[num2], vertices[num2 + 1]);
				}
			}
			else
			{
				float[] array = new float[worldVerticesLength];
				va.ComputeWorldVertices(slot, array);
				Bone bone = slot.bone;
				float worldX = bone.worldX;
				float worldY = bone.worldY;
				float num3;
				float num4;
				float num5;
				float num6;
				bone.GetWorldToLocalMatrix(out num3, out num4, out num5, out num6);
				for (int j = 0; j < num; j++)
				{
					int num7 = j * 2;
					float num8 = array[num7] - worldX;
					float num9 = array[num7 + 1] - worldY;
					buffer[j] = new Vector2(num8 * num3 + num9 * num4, num8 * num5 + num9 * num6);
				}
			}
			return buffer;
		}

		// Token: 0x0601B6A9 RID: 112297 RVA: 0x008744D4 File Offset: 0x008728D4
		public static Vector2[] GetWorldVertices(this VertexAttachment a, Slot slot, Vector2[] buffer)
		{
			int worldVerticesLength = a.worldVerticesLength;
			int num = worldVerticesLength >> 1;
			buffer = (buffer ?? new Vector2[num]);
			if (buffer.Length < num)
			{
				throw new ArgumentException(string.Format("Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment's .WorldVerticesLength to get the correct size.", a.Name, worldVerticesLength), "buffer");
			}
			float[] array = new float[worldVerticesLength];
			a.ComputeWorldVertices(slot, array);
			int i = 0;
			int num2 = worldVerticesLength >> 1;
			while (i < num2)
			{
				int num3 = i * 2;
				buffer[i] = new Vector2(array[num3], array[num3 + 1]);
				i++;
			}
			return buffer;
		}

		// Token: 0x0601B6AA RID: 112298 RVA: 0x00874570 File Offset: 0x00872970
		public static Vector3 GetWorldPosition(this PointAttachment attachment, Slot slot, Transform spineGameObjectTransform)
		{
			Vector3 vector;
			vector.z = 0f;
			attachment.ComputeWorldPosition(slot.bone, out vector.x, out vector.y);
			return spineGameObjectTransform.TransformPoint(vector);
		}

		// Token: 0x0601B6AB RID: 112299 RVA: 0x008745AC File Offset: 0x008729AC
		public static Vector3 GetWorldPosition(this PointAttachment attachment, Bone bone, Transform spineGameObjectTransform)
		{
			Vector3 vector;
			vector.z = 0f;
			attachment.ComputeWorldPosition(bone, out vector.x, out vector.y);
			return spineGameObjectTransform.TransformPoint(vector);
		}

		// Token: 0x0401316D RID: 78189
		private const float ByteToFloat = 0.003921569f;
	}
}
