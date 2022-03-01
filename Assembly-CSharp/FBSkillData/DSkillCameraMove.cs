using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B33 RID: 19251
	public sealed class DSkillCameraMove : Table
	{
		// Token: 0x0601C2A0 RID: 115360 RVA: 0x00894206 File Offset: 0x00892606
		public static DSkillCameraMove GetRootAsDSkillCameraMove(ByteBuffer _bb)
		{
			return DSkillCameraMove.GetRootAsDSkillCameraMove(_bb, new DSkillCameraMove());
		}

		// Token: 0x0601C2A1 RID: 115361 RVA: 0x00894213 File Offset: 0x00892613
		public static DSkillCameraMove GetRootAsDSkillCameraMove(ByteBuffer _bb, DSkillCameraMove obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C2A2 RID: 115362 RVA: 0x0089422F File Offset: 0x0089262F
		public DSkillCameraMove __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700271E RID: 10014
		// (get) Token: 0x0601C2A3 RID: 115363 RVA: 0x00894240 File Offset: 0x00892640
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700271F RID: 10015
		// (get) Token: 0x0601C2A4 RID: 115364 RVA: 0x00894270 File Offset: 0x00892670
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002720 RID: 10016
		// (get) Token: 0x0601C2A5 RID: 115365 RVA: 0x008942A4 File Offset: 0x008926A4
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002721 RID: 10017
		// (get) Token: 0x0601C2A6 RID: 115366 RVA: 0x008942D8 File Offset: 0x008926D8
		public float Offset
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002722 RID: 10018
		// (get) Token: 0x0601C2A7 RID: 115367 RVA: 0x00894314 File Offset: 0x00892714
		public float Duraction
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002723 RID: 10019
		// (get) Token: 0x0601C2A8 RID: 115368 RVA: 0x00894350 File Offset: 0x00892750
		public bool Newoffset
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C2A9 RID: 115369 RVA: 0x0089438B File Offset: 0x0089278B
		public static Offset<DSkillCameraMove> CreateDSkillCameraMove(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, float offset = 0f, float duraction = 0f, bool newoffset = false)
		{
			builder.StartObject(6);
			DSkillCameraMove.AddDuraction(builder, duraction);
			DSkillCameraMove.AddOffset(builder, offset);
			DSkillCameraMove.AddLength(builder, length);
			DSkillCameraMove.AddStartframe(builder, startframe);
			DSkillCameraMove.AddName(builder, name);
			DSkillCameraMove.AddNewoffset(builder, newoffset);
			return DSkillCameraMove.EndDSkillCameraMove(builder);
		}

		// Token: 0x0601C2AA RID: 115370 RVA: 0x008943C7 File Offset: 0x008927C7
		public static void StartDSkillCameraMove(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0601C2AB RID: 115371 RVA: 0x008943D0 File Offset: 0x008927D0
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C2AC RID: 115372 RVA: 0x008943E1 File Offset: 0x008927E1
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C2AD RID: 115373 RVA: 0x008943EC File Offset: 0x008927EC
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C2AE RID: 115374 RVA: 0x008943F7 File Offset: 0x008927F7
		public static void AddOffset(FlatBufferBuilder builder, float offset)
		{
			builder.AddFloat(3, offset, 0.0);
		}

		// Token: 0x0601C2AF RID: 115375 RVA: 0x0089440A File Offset: 0x0089280A
		public static void AddDuraction(FlatBufferBuilder builder, float duraction)
		{
			builder.AddFloat(4, duraction, 0.0);
		}

		// Token: 0x0601C2B0 RID: 115376 RVA: 0x0089441D File Offset: 0x0089281D
		public static void AddNewoffset(FlatBufferBuilder builder, bool newoffset)
		{
			builder.AddBool(5, newoffset, false);
		}

		// Token: 0x0601C2B1 RID: 115377 RVA: 0x00894428 File Offset: 0x00892828
		public static Offset<DSkillCameraMove> EndDSkillCameraMove(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillCameraMove>(value);
		}
	}
}
