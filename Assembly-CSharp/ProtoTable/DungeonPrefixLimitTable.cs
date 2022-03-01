using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003A8 RID: 936
	public class DungeonPrefixLimitTable : IFlatbufferObject
	{
		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x060028E1 RID: 10465 RVA: 0x0009B0A4 File Offset: 0x000994A4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060028E2 RID: 10466 RVA: 0x0009B0B1 File Offset: 0x000994B1
		public static DungeonPrefixLimitTable GetRootAsDungeonPrefixLimitTable(ByteBuffer _bb)
		{
			return DungeonPrefixLimitTable.GetRootAsDungeonPrefixLimitTable(_bb, new DungeonPrefixLimitTable());
		}

		// Token: 0x060028E3 RID: 10467 RVA: 0x0009B0BE File Offset: 0x000994BE
		public static DungeonPrefixLimitTable GetRootAsDungeonPrefixLimitTable(ByteBuffer _bb, DungeonPrefixLimitTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060028E4 RID: 10468 RVA: 0x0009B0DA File Offset: 0x000994DA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060028E5 RID: 10469 RVA: 0x0009B0F4 File Offset: 0x000994F4
		public DungeonPrefixLimitTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x060028E6 RID: 10470 RVA: 0x0009B100 File Offset: 0x00099500
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1552596403 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x060028E7 RID: 10471 RVA: 0x0009B14C File Offset: 0x0009954C
		public string Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060028E8 RID: 10472 RVA: 0x0009B18E File Offset: 0x0009958E
		public ArraySegment<byte>? GetLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x060028E9 RID: 10473 RVA: 0x0009B19C File Offset: 0x0009959C
		public int Hard
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1552596403 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060028EA RID: 10474 RVA: 0x0009B1E8 File Offset: 0x000995E8
		public int TotalNumArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (1552596403 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x060028EB RID: 10475 RVA: 0x0009B238 File Offset: 0x00099638
		public int TotalNumLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060028EC RID: 10476 RVA: 0x0009B26B File Offset: 0x0009966B
		public ArraySegment<byte>? GetTotalNumBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x060028ED RID: 10477 RVA: 0x0009B27A File Offset: 0x0009967A
		public FlatBufferArray<int> TotalNum
		{
			get
			{
				if (this.TotalNumValue == null)
				{
					this.TotalNumValue = new FlatBufferArray<int>(new Func<int, int>(this.TotalNumArray), this.TotalNumLength);
				}
				return this.TotalNumValue;
			}
		}

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x060028EE RID: 10478 RVA: 0x0009B2AC File Offset: 0x000996AC
		public int SeniorPrefixNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1552596403 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x060028EF RID: 10479 RVA: 0x0009B2F8 File Offset: 0x000996F8
		public int LowPrefixNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1552596403 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060028F0 RID: 10480 RVA: 0x0009B342 File Offset: 0x00099742
		public static Offset<DungeonPrefixLimitTable> CreateDungeonPrefixLimitTable(FlatBufferBuilder builder, int ID = 0, StringOffset LevelOffset = default(StringOffset), int Hard = 0, VectorOffset TotalNumOffset = default(VectorOffset), int SeniorPrefixNum = 0, int LowPrefixNum = 0)
		{
			builder.StartObject(6);
			DungeonPrefixLimitTable.AddLowPrefixNum(builder, LowPrefixNum);
			DungeonPrefixLimitTable.AddSeniorPrefixNum(builder, SeniorPrefixNum);
			DungeonPrefixLimitTable.AddTotalNum(builder, TotalNumOffset);
			DungeonPrefixLimitTable.AddHard(builder, Hard);
			DungeonPrefixLimitTable.AddLevel(builder, LevelOffset);
			DungeonPrefixLimitTable.AddID(builder, ID);
			return DungeonPrefixLimitTable.EndDungeonPrefixLimitTable(builder);
		}

		// Token: 0x060028F1 RID: 10481 RVA: 0x0009B37E File Offset: 0x0009977E
		public static void StartDungeonPrefixLimitTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060028F2 RID: 10482 RVA: 0x0009B387 File Offset: 0x00099787
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060028F3 RID: 10483 RVA: 0x0009B392 File Offset: 0x00099792
		public static void AddLevel(FlatBufferBuilder builder, StringOffset LevelOffset)
		{
			builder.AddOffset(1, LevelOffset.Value, 0);
		}

		// Token: 0x060028F4 RID: 10484 RVA: 0x0009B3A3 File Offset: 0x000997A3
		public static void AddHard(FlatBufferBuilder builder, int Hard)
		{
			builder.AddInt(2, Hard, 0);
		}

		// Token: 0x060028F5 RID: 10485 RVA: 0x0009B3AE File Offset: 0x000997AE
		public static void AddTotalNum(FlatBufferBuilder builder, VectorOffset TotalNumOffset)
		{
			builder.AddOffset(3, TotalNumOffset.Value, 0);
		}

		// Token: 0x060028F6 RID: 10486 RVA: 0x0009B3C0 File Offset: 0x000997C0
		public static VectorOffset CreateTotalNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060028F7 RID: 10487 RVA: 0x0009B3FD File Offset: 0x000997FD
		public static void StartTotalNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060028F8 RID: 10488 RVA: 0x0009B408 File Offset: 0x00099808
		public static void AddSeniorPrefixNum(FlatBufferBuilder builder, int SeniorPrefixNum)
		{
			builder.AddInt(4, SeniorPrefixNum, 0);
		}

		// Token: 0x060028F9 RID: 10489 RVA: 0x0009B413 File Offset: 0x00099813
		public static void AddLowPrefixNum(FlatBufferBuilder builder, int LowPrefixNum)
		{
			builder.AddInt(5, LowPrefixNum, 0);
		}

		// Token: 0x060028FA RID: 10490 RVA: 0x0009B420 File Offset: 0x00099820
		public static Offset<DungeonPrefixLimitTable> EndDungeonPrefixLimitTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonPrefixLimitTable>(value);
		}

		// Token: 0x060028FB RID: 10491 RVA: 0x0009B43A File Offset: 0x0009983A
		public static void FinishDungeonPrefixLimitTableBuffer(FlatBufferBuilder builder, Offset<DungeonPrefixLimitTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011FA RID: 4602
		private Table __p = new Table();

		// Token: 0x040011FB RID: 4603
		private FlatBufferArray<int> TotalNumValue;

		// Token: 0x020003A9 RID: 937
		public enum eCrypt
		{
			// Token: 0x040011FD RID: 4605
			code = 1552596403
		}
	}
}
