using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B36 RID: 19254
	public sealed class DSkillFrameStateOp : Table
	{
		// Token: 0x0601C2DD RID: 115421 RVA: 0x0089492A File Offset: 0x00892D2A
		public static DSkillFrameStateOp GetRootAsDSkillFrameStateOp(ByteBuffer _bb)
		{
			return DSkillFrameStateOp.GetRootAsDSkillFrameStateOp(_bb, new DSkillFrameStateOp());
		}

		// Token: 0x0601C2DE RID: 115422 RVA: 0x00894937 File Offset: 0x00892D37
		public static DSkillFrameStateOp GetRootAsDSkillFrameStateOp(ByteBuffer _bb, DSkillFrameStateOp obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C2DF RID: 115423 RVA: 0x00894953 File Offset: 0x00892D53
		public DSkillFrameStateOp __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002732 RID: 10034
		// (get) Token: 0x0601C2E0 RID: 115424 RVA: 0x00894964 File Offset: 0x00892D64
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002733 RID: 10035
		// (get) Token: 0x0601C2E1 RID: 115425 RVA: 0x00894994 File Offset: 0x00892D94
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002734 RID: 10036
		// (get) Token: 0x0601C2E2 RID: 115426 RVA: 0x008949C8 File Offset: 0x00892DC8
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002735 RID: 10037
		// (get) Token: 0x0601C2E3 RID: 115427 RVA: 0x008949FC File Offset: 0x00892DFC
		public int Op
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002736 RID: 10038
		// (get) Token: 0x0601C2E4 RID: 115428 RVA: 0x00894A34 File Offset: 0x00892E34
		public int State
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002737 RID: 10039
		// (get) Token: 0x0601C2E5 RID: 115429 RVA: 0x00894A6C File Offset: 0x00892E6C
		public int Idata1
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002738 RID: 10040
		// (get) Token: 0x0601C2E6 RID: 115430 RVA: 0x00894AA4 File Offset: 0x00892EA4
		public int Idata2
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002739 RID: 10041
		// (get) Token: 0x0601C2E7 RID: 115431 RVA: 0x00894ADC File Offset: 0x00892EDC
		public float Fdata1
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700273A RID: 10042
		// (get) Token: 0x0601C2E8 RID: 115432 RVA: 0x00894B18 File Offset: 0x00892F18
		public float Fdata2
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700273B RID: 10043
		// (get) Token: 0x0601C2E9 RID: 115433 RVA: 0x00894B54 File Offset: 0x00892F54
		public int Statetag
		{
			get
			{
				int num = base.__offset(22);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C2EA RID: 115434 RVA: 0x00894B8C File Offset: 0x00892F8C
		public static Offset<DSkillFrameStateOp> CreateDSkillFrameStateOp(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int op = 0, int state = 0, int idata1 = 0, int idata2 = 0, float fdata1 = 0f, float fdata2 = 0f, int statetag = 0)
		{
			builder.StartObject(10);
			DSkillFrameStateOp.AddStatetag(builder, statetag);
			DSkillFrameStateOp.AddFdata2(builder, fdata2);
			DSkillFrameStateOp.AddFdata1(builder, fdata1);
			DSkillFrameStateOp.AddIdata2(builder, idata2);
			DSkillFrameStateOp.AddIdata1(builder, idata1);
			DSkillFrameStateOp.AddState(builder, state);
			DSkillFrameStateOp.AddOp(builder, op);
			DSkillFrameStateOp.AddLength(builder, length);
			DSkillFrameStateOp.AddStartframe(builder, startframe);
			DSkillFrameStateOp.AddName(builder, name);
			return DSkillFrameStateOp.EndDSkillFrameStateOp(builder);
		}

		// Token: 0x0601C2EB RID: 115435 RVA: 0x00894BF4 File Offset: 0x00892FF4
		public static void StartDSkillFrameStateOp(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0601C2EC RID: 115436 RVA: 0x00894BFE File Offset: 0x00892FFE
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C2ED RID: 115437 RVA: 0x00894C0F File Offset: 0x0089300F
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C2EE RID: 115438 RVA: 0x00894C1A File Offset: 0x0089301A
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C2EF RID: 115439 RVA: 0x00894C25 File Offset: 0x00893025
		public static void AddOp(FlatBufferBuilder builder, int op)
		{
			builder.AddInt(3, op, 0);
		}

		// Token: 0x0601C2F0 RID: 115440 RVA: 0x00894C30 File Offset: 0x00893030
		public static void AddState(FlatBufferBuilder builder, int state)
		{
			builder.AddInt(4, state, 0);
		}

		// Token: 0x0601C2F1 RID: 115441 RVA: 0x00894C3B File Offset: 0x0089303B
		public static void AddIdata1(FlatBufferBuilder builder, int idata1)
		{
			builder.AddInt(5, idata1, 0);
		}

		// Token: 0x0601C2F2 RID: 115442 RVA: 0x00894C46 File Offset: 0x00893046
		public static void AddIdata2(FlatBufferBuilder builder, int idata2)
		{
			builder.AddInt(6, idata2, 0);
		}

		// Token: 0x0601C2F3 RID: 115443 RVA: 0x00894C51 File Offset: 0x00893051
		public static void AddFdata1(FlatBufferBuilder builder, float fdata1)
		{
			builder.AddFloat(7, fdata1, 0.0);
		}

		// Token: 0x0601C2F4 RID: 115444 RVA: 0x00894C64 File Offset: 0x00893064
		public static void AddFdata2(FlatBufferBuilder builder, float fdata2)
		{
			builder.AddFloat(8, fdata2, 0.0);
		}

		// Token: 0x0601C2F5 RID: 115445 RVA: 0x00894C77 File Offset: 0x00893077
		public static void AddStatetag(FlatBufferBuilder builder, int statetag)
		{
			builder.AddInt(9, statetag, 0);
		}

		// Token: 0x0601C2F6 RID: 115446 RVA: 0x00894C84 File Offset: 0x00893084
		public static Offset<DSkillFrameStateOp> EndDSkillFrameStateOp(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillFrameStateOp>(value);
		}
	}
}
