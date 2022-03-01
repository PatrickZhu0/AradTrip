using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000520 RID: 1312
	public class MonthSignCollectAward : IFlatbufferObject
	{
		// Token: 0x170011F3 RID: 4595
		// (get) Token: 0x06004369 RID: 17257 RVA: 0x000DA864 File Offset: 0x000D8C64
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600436A RID: 17258 RVA: 0x000DA871 File Offset: 0x000D8C71
		public static MonthSignCollectAward GetRootAsMonthSignCollectAward(ByteBuffer _bb)
		{
			return MonthSignCollectAward.GetRootAsMonthSignCollectAward(_bb, new MonthSignCollectAward());
		}

		// Token: 0x0600436B RID: 17259 RVA: 0x000DA87E File Offset: 0x000D8C7E
		public static MonthSignCollectAward GetRootAsMonthSignCollectAward(ByteBuffer _bb, MonthSignCollectAward obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600436C RID: 17260 RVA: 0x000DA89A File Offset: 0x000D8C9A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600436D RID: 17261 RVA: 0x000DA8B4 File Offset: 0x000D8CB4
		public MonthSignCollectAward __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011F4 RID: 4596
		// (get) Token: 0x0600436E RID: 17262 RVA: 0x000DA8C0 File Offset: 0x000D8CC0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (764791480 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F5 RID: 4597
		// (get) Token: 0x0600436F RID: 17263 RVA: 0x000DA90C File Offset: 0x000D8D0C
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (764791480 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F6 RID: 4598
		// (get) Token: 0x06004370 RID: 17264 RVA: 0x000DA958 File Offset: 0x000D8D58
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (764791480 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004371 RID: 17265 RVA: 0x000DA9A1 File Offset: 0x000D8DA1
		public static Offset<MonthSignCollectAward> CreateMonthSignCollectAward(FlatBufferBuilder builder, int ID = 0, int ItemID = 0, int ItemNum = 0)
		{
			builder.StartObject(3);
			MonthSignCollectAward.AddItemNum(builder, ItemNum);
			MonthSignCollectAward.AddItemID(builder, ItemID);
			MonthSignCollectAward.AddID(builder, ID);
			return MonthSignCollectAward.EndMonthSignCollectAward(builder);
		}

		// Token: 0x06004372 RID: 17266 RVA: 0x000DA9C5 File Offset: 0x000D8DC5
		public static void StartMonthSignCollectAward(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004373 RID: 17267 RVA: 0x000DA9CE File Offset: 0x000D8DCE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004374 RID: 17268 RVA: 0x000DA9D9 File Offset: 0x000D8DD9
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(1, ItemID, 0);
		}

		// Token: 0x06004375 RID: 17269 RVA: 0x000DA9E4 File Offset: 0x000D8DE4
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(2, ItemNum, 0);
		}

		// Token: 0x06004376 RID: 17270 RVA: 0x000DA9F0 File Offset: 0x000D8DF0
		public static Offset<MonthSignCollectAward> EndMonthSignCollectAward(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonthSignCollectAward>(value);
		}

		// Token: 0x06004377 RID: 17271 RVA: 0x000DAA0A File Offset: 0x000D8E0A
		public static void FinishMonthSignCollectAwardBuffer(FlatBufferBuilder builder, Offset<MonthSignCollectAward> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018ED RID: 6381
		private Table __p = new Table();

		// Token: 0x02000521 RID: 1313
		public enum eCrypt
		{
			// Token: 0x040018EF RID: 6383
			code = 764791480
		}
	}
}
