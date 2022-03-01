using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3B RID: 19259
	public sealed class DSkillSummon : Table
	{
		// Token: 0x0601C35D RID: 115549 RVA: 0x00895976 File Offset: 0x00893D76
		public static DSkillSummon GetRootAsDSkillSummon(ByteBuffer _bb)
		{
			return DSkillSummon.GetRootAsDSkillSummon(_bb, new DSkillSummon());
		}

		// Token: 0x0601C35E RID: 115550 RVA: 0x00895983 File Offset: 0x00893D83
		public static DSkillSummon GetRootAsDSkillSummon(ByteBuffer _bb, DSkillSummon obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C35F RID: 115551 RVA: 0x0089599F File Offset: 0x00893D9F
		public DSkillSummon __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700275F RID: 10079
		// (get) Token: 0x0601C360 RID: 115552 RVA: 0x008959B0 File Offset: 0x00893DB0
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17002760 RID: 10080
		// (get) Token: 0x0601C361 RID: 115553 RVA: 0x008959E0 File Offset: 0x00893DE0
		public int Startframe
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002761 RID: 10081
		// (get) Token: 0x0601C362 RID: 115554 RVA: 0x00895A14 File Offset: 0x00893E14
		public int Length
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002762 RID: 10082
		// (get) Token: 0x0601C363 RID: 115555 RVA: 0x00895A48 File Offset: 0x00893E48
		public int SummonID
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002763 RID: 10083
		// (get) Token: 0x0601C364 RID: 115556 RVA: 0x00895A80 File Offset: 0x00893E80
		public int SummonLevel
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002764 RID: 10084
		// (get) Token: 0x0601C365 RID: 115557 RVA: 0x00895AB8 File Offset: 0x00893EB8
		public bool LevelGrowBySkill
		{
			get
			{
				int num = base.__offset(14);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002765 RID: 10085
		// (get) Token: 0x0601C366 RID: 115558 RVA: 0x00895AF4 File Offset: 0x00893EF4
		public int SummonNum
		{
			get
			{
				int num = base.__offset(16);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002766 RID: 10086
		// (get) Token: 0x0601C367 RID: 115559 RVA: 0x00895B2C File Offset: 0x00893F2C
		public int PosType
		{
			get
			{
				int num = base.__offset(18);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C368 RID: 115560 RVA: 0x00895B64 File Offset: 0x00893F64
		public int GetPosType2(int j)
		{
			int num = base.__offset(20);
			return (num == 0) ? 0 : this.bb.GetInt(base.__vector(num) + j * 4);
		}

		// Token: 0x17002767 RID: 10087
		// (get) Token: 0x0601C369 RID: 115561 RVA: 0x00895B9C File Offset: 0x00893F9C
		public int PosType2Length
		{
			get
			{
				int num = base.__offset(20);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17002768 RID: 10088
		// (get) Token: 0x0601C36A RID: 115562 RVA: 0x00895BC8 File Offset: 0x00893FC8
		public bool IsSameFace
		{
			get
			{
				int num = base.__offset(22);
				return num == 0 || 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002769 RID: 10089
		// (get) Token: 0x0601C36B RID: 115563 RVA: 0x00895C04 File Offset: 0x00894004
		public int SummonNumLimit
		{
			get
			{
				int num = base.__offset(24);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C36C RID: 115564 RVA: 0x00895C3C File Offset: 0x0089403C
		public static Offset<DSkillSummon> CreateDSkillSummon(FlatBufferBuilder builder, StringOffset name = default(StringOffset), int startframe = 0, int length = 0, int summonID = 0, int summonLevel = 0, bool levelGrowBySkill = false, int summonNum = 0, int posType = 0, VectorOffset posType2 = default(VectorOffset), bool isSameFace = true, int summonNumLimit = 0)
		{
			builder.StartObject(11);
			DSkillSummon.AddSummonNumLimit(builder, summonNumLimit);
			DSkillSummon.AddPosType2(builder, posType2);
			DSkillSummon.AddPosType(builder, posType);
			DSkillSummon.AddSummonNum(builder, summonNum);
			DSkillSummon.AddSummonLevel(builder, summonLevel);
			DSkillSummon.AddSummonID(builder, summonID);
			DSkillSummon.AddLength(builder, length);
			DSkillSummon.AddStartframe(builder, startframe);
			DSkillSummon.AddName(builder, name);
			DSkillSummon.AddIsSameFace(builder, isSameFace);
			DSkillSummon.AddLevelGrowBySkill(builder, levelGrowBySkill);
			return DSkillSummon.EndDSkillSummon(builder);
		}

		// Token: 0x0601C36D RID: 115565 RVA: 0x00895CAC File Offset: 0x008940AC
		public static void StartDSkillSummon(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x0601C36E RID: 115566 RVA: 0x00895CB6 File Offset: 0x008940B6
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x0601C36F RID: 115567 RVA: 0x00895CC7 File Offset: 0x008940C7
		public static void AddStartframe(FlatBufferBuilder builder, int startframe)
		{
			builder.AddInt(1, startframe, 0);
		}

		// Token: 0x0601C370 RID: 115568 RVA: 0x00895CD2 File Offset: 0x008940D2
		public static void AddLength(FlatBufferBuilder builder, int length)
		{
			builder.AddInt(2, length, 0);
		}

		// Token: 0x0601C371 RID: 115569 RVA: 0x00895CDD File Offset: 0x008940DD
		public static void AddSummonID(FlatBufferBuilder builder, int summonID)
		{
			builder.AddInt(3, summonID, 0);
		}

		// Token: 0x0601C372 RID: 115570 RVA: 0x00895CE8 File Offset: 0x008940E8
		public static void AddSummonLevel(FlatBufferBuilder builder, int summonLevel)
		{
			builder.AddInt(4, summonLevel, 0);
		}

		// Token: 0x0601C373 RID: 115571 RVA: 0x00895CF3 File Offset: 0x008940F3
		public static void AddLevelGrowBySkill(FlatBufferBuilder builder, bool levelGrowBySkill)
		{
			builder.AddBool(5, levelGrowBySkill, false);
		}

		// Token: 0x0601C374 RID: 115572 RVA: 0x00895CFE File Offset: 0x008940FE
		public static void AddSummonNum(FlatBufferBuilder builder, int summonNum)
		{
			builder.AddInt(6, summonNum, 0);
		}

		// Token: 0x0601C375 RID: 115573 RVA: 0x00895D09 File Offset: 0x00894109
		public static void AddPosType(FlatBufferBuilder builder, int posType)
		{
			builder.AddInt(7, posType, 0);
		}

		// Token: 0x0601C376 RID: 115574 RVA: 0x00895D14 File Offset: 0x00894114
		public static void AddPosType2(FlatBufferBuilder builder, VectorOffset posType2Offset)
		{
			builder.AddOffset(8, posType2Offset.Value, 0);
		}

		// Token: 0x0601C377 RID: 115575 RVA: 0x00895D28 File Offset: 0x00894128
		public static VectorOffset CreatePosType2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C378 RID: 115576 RVA: 0x00895D65 File Offset: 0x00894165
		public static void StartPosType2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C379 RID: 115577 RVA: 0x00895D70 File Offset: 0x00894170
		public static void AddIsSameFace(FlatBufferBuilder builder, bool isSameFace)
		{
			builder.AddBool(9, isSameFace, true);
		}

		// Token: 0x0601C37A RID: 115578 RVA: 0x00895D7C File Offset: 0x0089417C
		public static void AddSummonNumLimit(FlatBufferBuilder builder, int summonNumLimit)
		{
			builder.AddInt(10, summonNumLimit, 0);
		}

		// Token: 0x0601C37B RID: 115579 RVA: 0x00895D88 File Offset: 0x00894188
		public static Offset<DSkillSummon> EndDSkillSummon(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DSkillSummon>(value);
		}
	}
}
