using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200051E RID: 1310
	public class MonthSignAward : IFlatbufferObject
	{
		// Token: 0x170011EC RID: 4588
		// (get) Token: 0x06004353 RID: 17235 RVA: 0x000DA57C File Offset: 0x000D897C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004354 RID: 17236 RVA: 0x000DA589 File Offset: 0x000D8989
		public static MonthSignAward GetRootAsMonthSignAward(ByteBuffer _bb)
		{
			return MonthSignAward.GetRootAsMonthSignAward(_bb, new MonthSignAward());
		}

		// Token: 0x06004355 RID: 17237 RVA: 0x000DA596 File Offset: 0x000D8996
		public static MonthSignAward GetRootAsMonthSignAward(ByteBuffer _bb, MonthSignAward obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004356 RID: 17238 RVA: 0x000DA5B2 File Offset: 0x000D89B2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004357 RID: 17239 RVA: 0x000DA5CC File Offset: 0x000D89CC
		public MonthSignAward __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011ED RID: 4589
		// (get) Token: 0x06004358 RID: 17240 RVA: 0x000DA5D8 File Offset: 0x000D89D8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011EE RID: 4590
		// (get) Token: 0x06004359 RID: 17241 RVA: 0x000DA624 File Offset: 0x000D8A24
		public int Month
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011EF RID: 4591
		// (get) Token: 0x0600435A RID: 17242 RVA: 0x000DA670 File Offset: 0x000D8A70
		public int Day
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F0 RID: 4592
		// (get) Token: 0x0600435B RID: 17243 RVA: 0x000DA6BC File Offset: 0x000D8ABC
		public int VIPDouble
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F1 RID: 4593
		// (get) Token: 0x0600435C RID: 17244 RVA: 0x000DA708 File Offset: 0x000D8B08
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F2 RID: 4594
		// (get) Token: 0x0600435D RID: 17245 RVA: 0x000DA754 File Offset: 0x000D8B54
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-187394098 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600435E RID: 17246 RVA: 0x000DA79E File Offset: 0x000D8B9E
		public static Offset<MonthSignAward> CreateMonthSignAward(FlatBufferBuilder builder, int ID = 0, int Month = 0, int Day = 0, int VIPDouble = 0, int ItemID = 0, int ItemNum = 0)
		{
			builder.StartObject(6);
			MonthSignAward.AddItemNum(builder, ItemNum);
			MonthSignAward.AddItemID(builder, ItemID);
			MonthSignAward.AddVIPDouble(builder, VIPDouble);
			MonthSignAward.AddDay(builder, Day);
			MonthSignAward.AddMonth(builder, Month);
			MonthSignAward.AddID(builder, ID);
			return MonthSignAward.EndMonthSignAward(builder);
		}

		// Token: 0x0600435F RID: 17247 RVA: 0x000DA7DA File Offset: 0x000D8BDA
		public static void StartMonthSignAward(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004360 RID: 17248 RVA: 0x000DA7E3 File Offset: 0x000D8BE3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004361 RID: 17249 RVA: 0x000DA7EE File Offset: 0x000D8BEE
		public static void AddMonth(FlatBufferBuilder builder, int Month)
		{
			builder.AddInt(1, Month, 0);
		}

		// Token: 0x06004362 RID: 17250 RVA: 0x000DA7F9 File Offset: 0x000D8BF9
		public static void AddDay(FlatBufferBuilder builder, int Day)
		{
			builder.AddInt(2, Day, 0);
		}

		// Token: 0x06004363 RID: 17251 RVA: 0x000DA804 File Offset: 0x000D8C04
		public static void AddVIPDouble(FlatBufferBuilder builder, int VIPDouble)
		{
			builder.AddInt(3, VIPDouble, 0);
		}

		// Token: 0x06004364 RID: 17252 RVA: 0x000DA80F File Offset: 0x000D8C0F
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(4, ItemID, 0);
		}

		// Token: 0x06004365 RID: 17253 RVA: 0x000DA81A File Offset: 0x000D8C1A
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(5, ItemNum, 0);
		}

		// Token: 0x06004366 RID: 17254 RVA: 0x000DA828 File Offset: 0x000D8C28
		public static Offset<MonthSignAward> EndMonthSignAward(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonthSignAward>(value);
		}

		// Token: 0x06004367 RID: 17255 RVA: 0x000DA842 File Offset: 0x000D8C42
		public static void FinishMonthSignAwardBuffer(FlatBufferBuilder builder, Offset<MonthSignAward> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018EA RID: 6378
		private Table __p = new Table();

		// Token: 0x0200051F RID: 1311
		public enum eCrypt
		{
			// Token: 0x040018EC RID: 6380
			code = -187394098
		}
	}
}
