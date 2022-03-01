using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000518 RID: 1304
	public class MonsterGroupTable : IFlatbufferObject
	{
		// Token: 0x170011D9 RID: 4569
		// (get) Token: 0x0600430D RID: 17165 RVA: 0x000D9C94 File Offset: 0x000D8094
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600430E RID: 17166 RVA: 0x000D9CA1 File Offset: 0x000D80A1
		public static MonsterGroupTable GetRootAsMonsterGroupTable(ByteBuffer _bb)
		{
			return MonsterGroupTable.GetRootAsMonsterGroupTable(_bb, new MonsterGroupTable());
		}

		// Token: 0x0600430F RID: 17167 RVA: 0x000D9CAE File Offset: 0x000D80AE
		public static MonsterGroupTable GetRootAsMonsterGroupTable(ByteBuffer _bb, MonsterGroupTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004310 RID: 17168 RVA: 0x000D9CCA File Offset: 0x000D80CA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004311 RID: 17169 RVA: 0x000D9CE4 File Offset: 0x000D80E4
		public MonsterGroupTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011DA RID: 4570
		// (get) Token: 0x06004312 RID: 17170 RVA: 0x000D9CF0 File Offset: 0x000D80F0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011DB RID: 4571
		// (get) Token: 0x06004313 RID: 17171 RVA: 0x000D9D3C File Offset: 0x000D813C
		public int SetID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011DC RID: 4572
		// (get) Token: 0x06004314 RID: 17172 RVA: 0x000D9D88 File Offset: 0x000D8188
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011DD RID: 4573
		// (get) Token: 0x06004315 RID: 17173 RVA: 0x000D9DD4 File Offset: 0x000D81D4
		public int GroupProb
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011DE RID: 4574
		// (get) Token: 0x06004316 RID: 17174 RVA: 0x000D9E20 File Offset: 0x000D8220
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011DF RID: 4575
		// (get) Token: 0x06004317 RID: 17175 RVA: 0x000D9E6C File Offset: 0x000D826C
		public int LossyType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011E0 RID: 4576
		// (get) Token: 0x06004318 RID: 17176 RVA: 0x000D9EB8 File Offset: 0x000D82B8
		public int LossyNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004319 RID: 17177 RVA: 0x000D9F04 File Offset: 0x000D8304
		public int MonsterListArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1363400085 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170011E1 RID: 4577
		// (get) Token: 0x0600431A RID: 17178 RVA: 0x000D9F54 File Offset: 0x000D8354
		public int MonsterListLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600431B RID: 17179 RVA: 0x000D9F87 File Offset: 0x000D8387
		public ArraySegment<byte>? GetMonsterListBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170011E2 RID: 4578
		// (get) Token: 0x0600431C RID: 17180 RVA: 0x000D9F96 File Offset: 0x000D8396
		public FlatBufferArray<int> MonsterList
		{
			get
			{
				if (this.MonsterListValue == null)
				{
					this.MonsterListValue = new FlatBufferArray<int>(new Func<int, int>(this.MonsterListArray), this.MonsterListLength);
				}
				return this.MonsterListValue;
			}
		}

		// Token: 0x0600431D RID: 17181 RVA: 0x000D9FC8 File Offset: 0x000D83C8
		public static Offset<MonsterGroupTable> CreateMonsterGroupTable(FlatBufferBuilder builder, int ID = 0, int SetID = 0, int GroupID = 0, int GroupProb = 0, int Prob = 0, int LossyType = 0, int LossyNum = 0, VectorOffset MonsterListOffset = default(VectorOffset))
		{
			builder.StartObject(8);
			MonsterGroupTable.AddMonsterList(builder, MonsterListOffset);
			MonsterGroupTable.AddLossyNum(builder, LossyNum);
			MonsterGroupTable.AddLossyType(builder, LossyType);
			MonsterGroupTable.AddProb(builder, Prob);
			MonsterGroupTable.AddGroupProb(builder, GroupProb);
			MonsterGroupTable.AddGroupID(builder, GroupID);
			MonsterGroupTable.AddSetID(builder, SetID);
			MonsterGroupTable.AddID(builder, ID);
			return MonsterGroupTable.EndMonsterGroupTable(builder);
		}

		// Token: 0x0600431E RID: 17182 RVA: 0x000DA01F File Offset: 0x000D841F
		public static void StartMonsterGroupTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0600431F RID: 17183 RVA: 0x000DA028 File Offset: 0x000D8428
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004320 RID: 17184 RVA: 0x000DA033 File Offset: 0x000D8433
		public static void AddSetID(FlatBufferBuilder builder, int SetID)
		{
			builder.AddInt(1, SetID, 0);
		}

		// Token: 0x06004321 RID: 17185 RVA: 0x000DA03E File Offset: 0x000D843E
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(2, GroupID, 0);
		}

		// Token: 0x06004322 RID: 17186 RVA: 0x000DA049 File Offset: 0x000D8449
		public static void AddGroupProb(FlatBufferBuilder builder, int GroupProb)
		{
			builder.AddInt(3, GroupProb, 0);
		}

		// Token: 0x06004323 RID: 17187 RVA: 0x000DA054 File Offset: 0x000D8454
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(4, Prob, 0);
		}

		// Token: 0x06004324 RID: 17188 RVA: 0x000DA05F File Offset: 0x000D845F
		public static void AddLossyType(FlatBufferBuilder builder, int LossyType)
		{
			builder.AddInt(5, LossyType, 0);
		}

		// Token: 0x06004325 RID: 17189 RVA: 0x000DA06A File Offset: 0x000D846A
		public static void AddLossyNum(FlatBufferBuilder builder, int LossyNum)
		{
			builder.AddInt(6, LossyNum, 0);
		}

		// Token: 0x06004326 RID: 17190 RVA: 0x000DA075 File Offset: 0x000D8475
		public static void AddMonsterList(FlatBufferBuilder builder, VectorOffset MonsterListOffset)
		{
			builder.AddOffset(7, MonsterListOffset.Value, 0);
		}

		// Token: 0x06004327 RID: 17191 RVA: 0x000DA088 File Offset: 0x000D8488
		public static VectorOffset CreateMonsterListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004328 RID: 17192 RVA: 0x000DA0C5 File Offset: 0x000D84C5
		public static void StartMonsterListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004329 RID: 17193 RVA: 0x000DA0D0 File Offset: 0x000D84D0
		public static Offset<MonsterGroupTable> EndMonsterGroupTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonsterGroupTable>(value);
		}

		// Token: 0x0600432A RID: 17194 RVA: 0x000DA0EA File Offset: 0x000D84EA
		public static void FinishMonsterGroupTableBuffer(FlatBufferBuilder builder, Offset<MonsterGroupTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018DF RID: 6367
		private Table __p = new Table();

		// Token: 0x040018E0 RID: 6368
		private FlatBufferArray<int> MonsterListValue;

		// Token: 0x02000519 RID: 1305
		public enum eCrypt
		{
			// Token: 0x040018E2 RID: 6370
			code = 1363400085
		}
	}
}
