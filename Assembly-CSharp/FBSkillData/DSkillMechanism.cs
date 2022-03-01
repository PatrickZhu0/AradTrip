using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3C RID: 19260
	public sealed class DSkillMechanism : Table
	{
		// Token: 0x0601C37D RID: 115581 RVA: 0x00895DAA File Offset: 0x008941AA
		public static DSkillMechanism GetRootAsDSkillMechanism(ByteBuffer _bb)
		{
			return DSkillMechanism.GetRootAsDSkillMechanism(_bb, new DSkillMechanism());
		}

		// Token: 0x0601C37E RID: 115582 RVA: 0x00895DB7 File Offset: 0x008941B7
		public static DSkillMechanism GetRootAsDSkillMechanism(ByteBuffer _bb, DSkillMechanism obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C37F RID: 115583 RVA: 0x00895DD3 File Offset: 0x008941D3
		public DSkillMechanism __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700276A RID: 10090
		// (get) Token: 0x0601C380 RID: 115584 RVA: 0x00895DE4 File Offset: 0x008941E4
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700276B RID: 10091
		// (get) Token: 0x0601C381 RID: 115585 RVA: 0x00895E14 File Offset: 0x00894214
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700276C RID: 10092
		// (get) Token: 0x0601C382 RID: 115586 RVA: 0x00895E48 File Offset: 0x00894248
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700276D RID: 10093
		// (get) Token: 0x0601C383 RID: 115587 RVA: 0x00895E7C File Offset: 0x0089427C
		public int Id
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700276E RID: 10094
		// (get) Token: 0x0601C384 RID: 115588 RVA: 0x00895EB4 File Offset: 0x008942B4
		public float Time
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700276F RID: 10095
		// (get) Token: 0x0601C385 RID: 115589 RVA: 0x00895EF0 File Offset: 0x008942F0
		public int Level
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002770 RID: 10096
		// (get) Token: 0x0601C386 RID: 115590 RVA: 0x00895F28 File Offset: 0x00894328
		public bool LevelBySkill
		{
			get
			{
				int num = base.__offset(16);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002771 RID: 10097
		// (get) Token: 0x0601C387 RID: 115591 RVA: 0x00895F64 File Offset: 0x00894364
		public bool PhaseDelete
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002772 RID: 10098
		// (get) Token: 0x0601C388 RID: 115592 RVA: 0x00895FA0 File Offset: 0x008943A0
		public bool FinishDeleteAll
		{
			get
			{
				int num = base.__offset(20);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C389 RID: 115593 RVA: 0x00895FDC File Offset: 0x008943DC
		public static Offset<DSkillMechanism> CreateDSkillMechanism(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int id = 0, float time = 0f, int level = 0, bool levelBySkill = false, bool phaseDelete = false, bool finishDeleteAll = false)
		{
			builder.StartObject(9);
			DSkillMechanism.AddLevel(builder, level);
			DSkillMechanism.AddTime(builder, time);
			DSkillMechanism.AddId(builder, id);
			DSkillMechanism.AddLength(builder, length);
			DSkillMechanism.AddStartframe(builder, startframe);
			DSkillMechanism.AddName(builder, name);
			DSkillMechanism.AddFinishDeleteAll(builder, finishDeleteAll);
			DSkillMechanism.AddPhaseDelete(builder, phaseDelete);
			DSkillMechanism.AddLevelBySkill(builder, levelBySkill);
			return DSkillMechanism.EndDSkillMechanism(builder);
		}

		// Token: 0x0601C38A RID: 115594 RVA: 0x0089603C File Offset: 0x0089443C
		public static void StartDSkillMechanism(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x0601C38B RID: 115595 RVA: 0x00896046 File Offset: 0x00894446
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C38C RID: 115596 RVA: 0x00896057 File Offset: 0x00894457
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C38D RID: 115597 RVA: 0x00896062 File Offset: 0x00894462
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C38E RID: 115598 RVA: 0x0089606D File Offset: 0x0089446D
		public static void AddId(FlatBufferBuilder builder, int id)
		{
			builder.AddInt(3, id, 0);
		}

		// Token: 0x0601C38F RID: 115599 RVA: 0x00896078 File Offset: 0x00894478
		public static void AddTime(FlatBufferBuilder builder, float time)
		{
			builder.AddFloat(4, time, 0.0);
		}

		// Token: 0x0601C390 RID: 115600 RVA: 0x0089608B File Offset: 0x0089448B
		public static void AddLevel(FlatBufferBuilder builder, int level)
		{
			builder.AddInt(5, level, 0);
		}

		// Token: 0x0601C391 RID: 115601 RVA: 0x00896096 File Offset: 0x00894496
		public static void AddLevelBySkill(FlatBufferBuilder builder, bool levelBySkill)
		{
			builder.AddBool(6, levelBySkill, false);
		}

		// Token: 0x0601C392 RID: 115602 RVA: 0x008960A1 File Offset: 0x008944A1
		public static void AddPhaseDelete(FlatBufferBuilder builder, bool phaseDelete)
		{
			builder.AddBool(7, phaseDelete, false);
		}

		// Token: 0x0601C393 RID: 115603 RVA: 0x008960AC File Offset: 0x008944AC
		public static void AddFinishDeleteAll(FlatBufferBuilder builder, bool finishDeleteAll)
		{
			builder.AddBool(8, finishDeleteAll, false);
		}

		// Token: 0x0601C394 RID: 115604 RVA: 0x008960B8 File Offset: 0x008944B8
		public static Offset<DSkillMechanism> EndDSkillMechanism(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillMechanism>(value);
		}
	}
}
