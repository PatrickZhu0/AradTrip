using System;

namespace Spine
{
	// Token: 0x020049B7 RID: 18871
	public class PointAttachment : Attachment
	{
		// Token: 0x0601B1FD RID: 111101 RVA: 0x00857ABD File Offset: 0x00855EBD
		public PointAttachment(string name) : base(name)
		{
		}

		// Token: 0x17002334 RID: 9012
		// (get) Token: 0x0601B1FE RID: 111102 RVA: 0x00857AC6 File Offset: 0x00855EC6
		// (set) Token: 0x0601B1FF RID: 111103 RVA: 0x00857ACE File Offset: 0x00855ECE
		public float X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17002335 RID: 9013
		// (get) Token: 0x0601B200 RID: 111104 RVA: 0x00857AD7 File Offset: 0x00855ED7
		// (set) Token: 0x0601B201 RID: 111105 RVA: 0x00857ADF File Offset: 0x00855EDF
		public float Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17002336 RID: 9014
		// (get) Token: 0x0601B202 RID: 111106 RVA: 0x00857AE8 File Offset: 0x00855EE8
		// (set) Token: 0x0601B203 RID: 111107 RVA: 0x00857AF0 File Offset: 0x00855EF0
		public float Rotation
		{
			get
			{
				return this.rotation;
			}
			set
			{
				this.rotation = value;
			}
		}

		// Token: 0x0601B204 RID: 111108 RVA: 0x00857AF9 File Offset: 0x00855EF9
		public void ComputeWorldPosition(Bone bone, out float ox, out float oy)
		{
			bone.LocalToWorld(this.x, this.y, out ox, out oy);
		}

		// Token: 0x0601B205 RID: 111109 RVA: 0x00857B10 File Offset: 0x00855F10
		public float ComputeWorldRotation(Bone bone)
		{
			float num = MathUtils.CosDeg(this.rotation);
			float num2 = MathUtils.SinDeg(this.rotation);
			float num3 = num * bone.a + num2 * bone.b;
			float num4 = num * bone.c + num2 * bone.d;
			return MathUtils.Atan2(num4, num3) * 57.295776f;
		}

		// Token: 0x04012EC3 RID: 77507
		internal float x;

		// Token: 0x04012EC4 RID: 77508
		internal float y;

		// Token: 0x04012EC5 RID: 77509
		internal float rotation;
	}
}
