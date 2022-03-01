using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B35 RID: 19253
	public sealed class DSkillFrameGrap : Table
	{
		// Token: 0x0601C2C8 RID: 115400 RVA: 0x008946E6 File Offset: 0x00892AE6
		public static DSkillFrameGrap GetRootAsDSkillFrameGrap(ByteBuffer _bb)
		{
			return DSkillFrameGrap.GetRootAsDSkillFrameGrap(_bb, new DSkillFrameGrap());
		}

		// Token: 0x0601C2C9 RID: 115401 RVA: 0x008946F3 File Offset: 0x00892AF3
		public static DSkillFrameGrap GetRootAsDSkillFrameGrap(ByteBuffer _bb, DSkillFrameGrap obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C2CA RID: 115402 RVA: 0x0089470F File Offset: 0x00892B0F
		public DSkillFrameGrap __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700272B RID: 10027
		// (get) Token: 0x0601C2CB RID: 115403 RVA: 0x00894720 File Offset: 0x00892B20
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700272C RID: 10028
		// (get) Token: 0x0601C2CC RID: 115404 RVA: 0x00894750 File Offset: 0x00892B50
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700272D RID: 10029
		// (get) Token: 0x0601C2CD RID: 115405 RVA: 0x00894784 File Offset: 0x00892B84
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700272E RID: 10030
		// (get) Token: 0x0601C2CE RID: 115406 RVA: 0x008947B8 File Offset: 0x00892BB8
		public int Op
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700272F RID: 10031
		// (get) Token: 0x0601C2CF RID: 115407 RVA: 0x008947F0 File Offset: 0x00892BF0
		public bool FaceGraber
		{
			get
			{
				int num = base.__offset(12);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002730 RID: 10032
		// (get) Token: 0x0601C2D0 RID: 115408 RVA: 0x0089482B File Offset: 0x00892C2B
		public Vector3 TargetPos
		{
			get
			{
				return this.GetTargetPos(new Vector3());
			}
		}

		// Token: 0x0601C2D1 RID: 115409 RVA: 0x00894838 File Offset: 0x00892C38
		public Vector3 GetTargetPos(Vector3 obj)
		{
			int num = base.__offset(14);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002731 RID: 10033
		// (get) Token: 0x0601C2D2 RID: 115410 RVA: 0x00894870 File Offset: 0x00892C70
		public int TargetAction
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C2D3 RID: 115411 RVA: 0x008948A5 File Offset: 0x00892CA5
		public static void StartDSkillFrameGrap(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0601C2D4 RID: 115412 RVA: 0x008948AE File Offset: 0x00892CAE
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C2D5 RID: 115413 RVA: 0x008948BF File Offset: 0x00892CBF
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C2D6 RID: 115414 RVA: 0x008948CA File Offset: 0x00892CCA
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C2D7 RID: 115415 RVA: 0x008948D5 File Offset: 0x00892CD5
		public static void AddOp(FlatBufferBuilder builder, int op)
		{
			builder.AddInt(3, op, 0);
		}

		// Token: 0x0601C2D8 RID: 115416 RVA: 0x008948E0 File Offset: 0x00892CE0
		public static void AddFaceGraber(FlatBufferBuilder builder, bool faceGraber)
		{
			builder.AddBool(4, faceGraber, false);
		}

		// Token: 0x0601C2D9 RID: 115417 RVA: 0x008948EB File Offset: 0x00892CEB
		public static void AddTargetPos(FlatBufferBuilder builder, Offset<Vector3> targetPosOffset)
		{
			builder.AddStruct(5, targetPosOffset.Value, 0);
		}

		// Token: 0x0601C2DA RID: 115418 RVA: 0x008948FC File Offset: 0x00892CFC
		public static void AddTargetAction(FlatBufferBuilder builder, int targetAction)
		{
			builder.AddInt(6, targetAction, 0);
		}

		// Token: 0x0601C2DB RID: 115419 RVA: 0x00894908 File Offset: 0x00892D08
		public static Offset<DSkillFrameGrap> EndDSkillFrameGrap(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFrameGrap>(value);
		}
	}
}
