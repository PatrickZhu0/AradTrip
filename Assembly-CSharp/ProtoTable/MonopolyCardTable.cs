using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000510 RID: 1296
	public class MonopolyCardTable : IFlatbufferObject
	{
		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x0600427F RID: 17023 RVA: 0x000D8798 File Offset: 0x000D6B98
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004280 RID: 17024 RVA: 0x000D87A5 File Offset: 0x000D6BA5
		public static MonopolyCardTable GetRootAsMonopolyCardTable(ByteBuffer _bb)
		{
			return MonopolyCardTable.GetRootAsMonopolyCardTable(_bb, new MonopolyCardTable());
		}

		// Token: 0x06004281 RID: 17025 RVA: 0x000D87B2 File Offset: 0x000D6BB2
		public static MonopolyCardTable GetRootAsMonopolyCardTable(ByteBuffer _bb, MonopolyCardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004282 RID: 17026 RVA: 0x000D87CE File Offset: 0x000D6BCE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004283 RID: 17027 RVA: 0x000D87E8 File Offset: 0x000D6BE8
		public MonopolyCardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x06004284 RID: 17028 RVA: 0x000D87F4 File Offset: 0x000D6BF4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-698979293 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x06004285 RID: 17029 RVA: 0x000D8840 File Offset: 0x000D6C40
		public int card
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-698979293 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x06004286 RID: 17030 RVA: 0x000D888C File Offset: 0x000D6C8C
		public int coinNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-698979293 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004287 RID: 17031 RVA: 0x000D88D5 File Offset: 0x000D6CD5
		public static Offset<MonopolyCardTable> CreateMonopolyCardTable(FlatBufferBuilder builder, int ID = 0, int card = 0, int coinNum = 0)
		{
			builder.StartObject(3);
			MonopolyCardTable.AddCoinNum(builder, coinNum);
			MonopolyCardTable.AddCard(builder, card);
			MonopolyCardTable.AddID(builder, ID);
			return MonopolyCardTable.EndMonopolyCardTable(builder);
		}

		// Token: 0x06004288 RID: 17032 RVA: 0x000D88F9 File Offset: 0x000D6CF9
		public static void StartMonopolyCardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004289 RID: 17033 RVA: 0x000D8902 File Offset: 0x000D6D02
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600428A RID: 17034 RVA: 0x000D890D File Offset: 0x000D6D0D
		public static void AddCard(FlatBufferBuilder builder, int card)
		{
			builder.AddInt(1, card, 0);
		}

		// Token: 0x0600428B RID: 17035 RVA: 0x000D8918 File Offset: 0x000D6D18
		public static void AddCoinNum(FlatBufferBuilder builder, int coinNum)
		{
			builder.AddInt(2, coinNum, 0);
		}

		// Token: 0x0600428C RID: 17036 RVA: 0x000D8924 File Offset: 0x000D6D24
		public static Offset<MonopolyCardTable> EndMonopolyCardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonopolyCardTable>(value);
		}

		// Token: 0x0600428D RID: 17037 RVA: 0x000D893E File Offset: 0x000D6D3E
		public static void FinishMonopolyCardTableBuffer(FlatBufferBuilder builder, Offset<MonopolyCardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018D2 RID: 6354
		private Table __p = new Table();

		// Token: 0x02000511 RID: 1297
		public enum eCrypt
		{
			// Token: 0x040018D4 RID: 6356
			code = -698979293
		}
	}
}
