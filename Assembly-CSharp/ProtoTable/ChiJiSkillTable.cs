using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000334 RID: 820
	public class ChiJiSkillTable : IFlatbufferObject
	{
		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x0600210B RID: 8459 RVA: 0x00087D58 File Offset: 0x00086158
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600210C RID: 8460 RVA: 0x00087D65 File Offset: 0x00086165
		public static ChiJiSkillTable GetRootAsChiJiSkillTable(ByteBuffer _bb)
		{
			return ChiJiSkillTable.GetRootAsChiJiSkillTable(_bb, new ChiJiSkillTable());
		}

		// Token: 0x0600210D RID: 8461 RVA: 0x00087D72 File Offset: 0x00086172
		public static ChiJiSkillTable GetRootAsChiJiSkillTable(ByteBuffer _bb, ChiJiSkillTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600210E RID: 8462 RVA: 0x00087D8E File Offset: 0x0008618E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600210F RID: 8463 RVA: 0x00087DA8 File Offset: 0x000861A8
		public ChiJiSkillTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06002110 RID: 8464 RVA: 0x00087DB4 File Offset: 0x000861B4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (881621158 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06002111 RID: 8465 RVA: 0x00087E00 File Offset: 0x00086200
		public int MaxLvl
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (881621158 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06002112 RID: 8466 RVA: 0x00087E4C File Offset: 0x0008624C
		public string Job
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002113 RID: 8467 RVA: 0x00087E8E File Offset: 0x0008628E
		public ArraySegment<byte>? GetJobBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06002114 RID: 8468 RVA: 0x00087E9C File Offset: 0x0008629C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002115 RID: 8469 RVA: 0x00087EDF File Offset: 0x000862DF
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06002116 RID: 8470 RVA: 0x00087EEE File Offset: 0x000862EE
		public static Offset<ChiJiSkillTable> CreateChiJiSkillTable(FlatBufferBuilder builder, int ID = 0, int MaxLvl = 0, StringOffset JobOffset = default(StringOffset), StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(4);
			ChiJiSkillTable.AddName(builder, NameOffset);
			ChiJiSkillTable.AddJob(builder, JobOffset);
			ChiJiSkillTable.AddMaxLvl(builder, MaxLvl);
			ChiJiSkillTable.AddID(builder, ID);
			return ChiJiSkillTable.EndChiJiSkillTable(builder);
		}

		// Token: 0x06002117 RID: 8471 RVA: 0x00087F1A File Offset: 0x0008631A
		public static void StartChiJiSkillTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06002118 RID: 8472 RVA: 0x00087F23 File Offset: 0x00086323
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002119 RID: 8473 RVA: 0x00087F2E File Offset: 0x0008632E
		public static void AddMaxLvl(FlatBufferBuilder builder, int MaxLvl)
		{
			builder.AddInt(1, MaxLvl, 0);
		}

		// Token: 0x0600211A RID: 8474 RVA: 0x00087F39 File Offset: 0x00086339
		public static void AddJob(FlatBufferBuilder builder, StringOffset JobOffset)
		{
			builder.AddOffset(2, JobOffset.Value, 0);
		}

		// Token: 0x0600211B RID: 8475 RVA: 0x00087F4A File Offset: 0x0008634A
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(3, NameOffset.Value, 0);
		}

		// Token: 0x0600211C RID: 8476 RVA: 0x00087F5C File Offset: 0x0008635C
		public static Offset<ChiJiSkillTable> EndChiJiSkillTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiSkillTable>(value);
		}

		// Token: 0x0600211D RID: 8477 RVA: 0x00087F76 File Offset: 0x00086376
		public static void FinishChiJiSkillTableBuffer(FlatBufferBuilder builder, Offset<ChiJiSkillTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000FE0 RID: 4064
		private Table __p = new Table();

		// Token: 0x02000335 RID: 821
		public enum eCrypt
		{
			// Token: 0x04000FE2 RID: 4066
			code = 881621158
		}
	}
}
