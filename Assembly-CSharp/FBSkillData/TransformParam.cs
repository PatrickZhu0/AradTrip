using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1E RID: 19230
	public sealed class TransformParam : Struct
	{
		// Token: 0x0601C0DA RID: 114906 RVA: 0x00890BF6 File Offset: 0x0088EFF6
		public TransformParam __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002683 RID: 9859
		// (get) Token: 0x0601C0DB RID: 114907 RVA: 0x00890C07 File Offset: 0x0088F007
		public Vector3 LocalPosition
		{
			get
			{
				return this.GetLocalPosition(new Vector3());
			}
		}

		// Token: 0x0601C0DC RID: 114908 RVA: 0x00890C14 File Offset: 0x0088F014
		public Vector3 GetLocalPosition(Vector3 obj)
		{
			return obj.__init(this.bb_pos, this.bb);
		}

		// Token: 0x17002684 RID: 9860
		// (get) Token: 0x0601C0DD RID: 114909 RVA: 0x00890C28 File Offset: 0x0088F028
		public Quaternion LocalRotation
		{
			get
			{
				return this.GetLocalRotation(new Quaternion());
			}
		}

		// Token: 0x0601C0DE RID: 114910 RVA: 0x00890C35 File Offset: 0x0088F035
		public Quaternion GetLocalRotation(Quaternion obj)
		{
			return obj.__init(this.bb_pos + 12, this.bb);
		}

		// Token: 0x17002685 RID: 9861
		// (get) Token: 0x0601C0DF RID: 114911 RVA: 0x00890C4C File Offset: 0x0088F04C
		public Vector3 LocalScale
		{
			get
			{
				return this.GetLocalScale(new Vector3());
			}
		}

		// Token: 0x0601C0E0 RID: 114912 RVA: 0x00890C59 File Offset: 0x0088F059
		public Vector3 GetLocalScale(Vector3 obj)
		{
			return obj.__init(this.bb_pos + 28, this.bb);
		}

		// Token: 0x0601C0E1 RID: 114913 RVA: 0x00890C70 File Offset: 0x0088F070
		public static Offset<TransformParam> CreateTransformParam(FlatBufferBuilder builder, float localPosition_X, float localPosition_Y, float localPosition_Z, float localRotation_X, float localRotation_Y, float localRotation_Z, float localRotation_W, float localScale_X, float localScale_Y, float localScale_Z)
		{
			builder.Prep(4, 40);
			builder.Prep(4, 12);
			builder.PutFloat(localScale_Z);
			builder.PutFloat(localScale_Y);
			builder.PutFloat(localScale_X);
			builder.Prep(4, 16);
			builder.PutFloat(localRotation_W);
			builder.PutFloat(localRotation_Z);
			builder.PutFloat(localRotation_Y);
			builder.PutFloat(localRotation_X);
			builder.Prep(4, 12);
			builder.PutFloat(localPosition_Z);
			builder.PutFloat(localPosition_Y);
			builder.PutFloat(localPosition_X);
			return new Offset<TransformParam>(builder.Offset);
		}
	}
}
