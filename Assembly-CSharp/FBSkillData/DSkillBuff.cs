using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3A RID: 19258
	public sealed class DSkillBuff : Table
	{
		// Token: 0x0601C33F RID: 115519 RVA: 0x0089557E File Offset: 0x0089397E
		public static DSkillBuff GetRootAsDSkillBuff(ByteBuffer _bb)
		{
			return DSkillBuff.GetRootAsDSkillBuff(_bb, new DSkillBuff());
		}

		// Token: 0x0601C340 RID: 115520 RVA: 0x0089558B File Offset: 0x0089398B
		public static DSkillBuff GetRootAsDSkillBuff(ByteBuffer _bb, DSkillBuff obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C341 RID: 115521 RVA: 0x008955A7 File Offset: 0x008939A7
		public DSkillBuff __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002755 RID: 10069
		// (get) Token: 0x0601C342 RID: 115522 RVA: 0x008955B8 File Offset: 0x008939B8
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002756 RID: 10070
		// (get) Token: 0x0601C343 RID: 115523 RVA: 0x008955E8 File Offset: 0x008939E8
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002757 RID: 10071
		// (get) Token: 0x0601C344 RID: 115524 RVA: 0x0089561C File Offset: 0x00893A1C
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002758 RID: 10072
		// (get) Token: 0x0601C345 RID: 115525 RVA: 0x00895650 File Offset: 0x00893A50
		public float BuffTime
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002759 RID: 10073
		// (get) Token: 0x0601C346 RID: 115526 RVA: 0x0089568C File Offset: 0x00893A8C
		public int BuffID
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700275A RID: 10074
		// (get) Token: 0x0601C347 RID: 115527 RVA: 0x008956C4 File Offset: 0x00893AC4
		public bool PhaseDelete
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C348 RID: 115528 RVA: 0x00895700 File Offset: 0x00893B00
		public int GetBuffInfoList(int j)
		{
			int num = base.__offset(16);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x1700275B RID: 10075
		// (get) Token: 0x0601C349 RID: 115529 RVA: 0x00895738 File Offset: 0x00893B38
		public int BuffInfoListLength
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x1700275C RID: 10076
		// (get) Token: 0x0601C34A RID: 115530 RVA: 0x00895764 File Offset: 0x00893B64
		public bool FinishDeleteAll
		{
			get
			{
				int num = base.__offset(18);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700275D RID: 10077
		// (get) Token: 0x0601C34B RID: 115531 RVA: 0x008957A0 File Offset: 0x00893BA0
		public int Level
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700275E RID: 10078
		// (get) Token: 0x0601C34C RID: 115532 RVA: 0x008957D8 File Offset: 0x00893BD8
		public bool LevelBySkill
		{
			get
			{
				int num = base.__offset(22);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C34D RID: 115533 RVA: 0x00895814 File Offset: 0x00893C14
		public static Offset<DSkillBuff> CreateDSkillBuff(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, float buffTime = 0f, int buffID = 0, bool phaseDelete = false, VectorOffset buffInfoList = default(VectorOffset), bool finishDeleteAll = false, int level = 0, bool levelBySkill = false)
		{
			builder.StartObject(10);
			DSkillBuff.AddLevel(builder, level);
			DSkillBuff.AddBuffInfoList(builder, buffInfoList);
			DSkillBuff.AddBuffID(builder, buffID);
			DSkillBuff.AddBuffTime(builder, buffTime);
			DSkillBuff.AddLength(builder, length);
			DSkillBuff.AddStartframe(builder, startframe);
			DSkillBuff.AddName(builder, name);
			DSkillBuff.AddLevelBySkill(builder, levelBySkill);
			DSkillBuff.AddFinishDeleteAll(builder, finishDeleteAll);
			DSkillBuff.AddPhaseDelete(builder, phaseDelete);
			return DSkillBuff.EndDSkillBuff(builder);
		}

		// Token: 0x0601C34E RID: 115534 RVA: 0x0089587C File Offset: 0x00893C7C
		public static void StartDSkillBuff(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0601C34F RID: 115535 RVA: 0x00895886 File Offset: 0x00893C86
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C350 RID: 115536 RVA: 0x00895897 File Offset: 0x00893C97
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C351 RID: 115537 RVA: 0x008958A2 File Offset: 0x00893CA2
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C352 RID: 115538 RVA: 0x008958AD File Offset: 0x00893CAD
		public static void AddBuffTime(FlatBufferBuilder builder, float buffTime)
		{
			builder.AddFloat(3, buffTime, 0.0);
		}

		// Token: 0x0601C353 RID: 115539 RVA: 0x008958C0 File Offset: 0x00893CC0
		public static void AddBuffID(FlatBufferBuilder builder, int buffID)
		{
			builder.AddInt(4, buffID, 0);
		}

		// Token: 0x0601C354 RID: 115540 RVA: 0x008958CB File Offset: 0x00893CCB
		public static void AddPhaseDelete(FlatBufferBuilder builder, bool phaseDelete)
		{
			builder.AddBool(5, phaseDelete, false);
		}

		// Token: 0x0601C355 RID: 115541 RVA: 0x008958D6 File Offset: 0x00893CD6
		public static void AddBuffInfoList(FlatBufferBuilder builder, VectorOffset buffInfoListOffset)
		{
			builder.AddOffset(6, buffInfoListOffset.Value, 0);
		}

		// Token: 0x0601C356 RID: 115542 RVA: 0x008958E8 File Offset: 0x00893CE8
		public static VectorOffset CreateBuffInfoListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C357 RID: 115543 RVA: 0x00895925 File Offset: 0x00893D25
		public static void StartBuffInfoListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C358 RID: 115544 RVA: 0x00895930 File Offset: 0x00893D30
		public static void AddFinishDeleteAll(FlatBufferBuilder builder, bool finishDeleteAll)
		{
			builder.AddBool(7, finishDeleteAll, false);
		}

		// Token: 0x0601C359 RID: 115545 RVA: 0x0089593B File Offset: 0x00893D3B
		public static void AddLevel(FlatBufferBuilder builder, int level)
		{
			builder.AddInt(8, level, 0);
		}

		// Token: 0x0601C35A RID: 115546 RVA: 0x00895946 File Offset: 0x00893D46
		public static void AddLevelBySkill(FlatBufferBuilder builder, bool levelBySkill)
		{
			builder.AddBool(9, levelBySkill, false);
		}

		// Token: 0x0601C35B RID: 115547 RVA: 0x00895954 File Offset: 0x00893D54
		public static Offset<DSkillBuff> EndDSkillBuff(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillBuff>(value);
		}
	}
}
