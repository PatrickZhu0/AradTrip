using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000575 RID: 1397
	public class RareItemTable : IFlatbufferObject
	{
		// Token: 0x17001354 RID: 4948
		// (get) Token: 0x060047C3 RID: 18371 RVA: 0x000E4418 File Offset: 0x000E2818
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060047C4 RID: 18372 RVA: 0x000E4425 File Offset: 0x000E2825
		public static RareItemTable GetRootAsRareItemTable(ByteBuffer _bb)
		{
			return RareItemTable.GetRootAsRareItemTable(_bb, new RareItemTable());
		}

		// Token: 0x060047C5 RID: 18373 RVA: 0x000E4432 File Offset: 0x000E2832
		public static RareItemTable GetRootAsRareItemTable(ByteBuffer _bb, RareItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060047C6 RID: 18374 RVA: 0x000E444E File Offset: 0x000E284E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060047C7 RID: 18375 RVA: 0x000E4468 File Offset: 0x000E2868
		public RareItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001355 RID: 4949
		// (get) Token: 0x060047C8 RID: 18376 RVA: 0x000E4474 File Offset: 0x000E2874
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001356 RID: 4950
		// (get) Token: 0x060047C9 RID: 18377 RVA: 0x000E44C0 File Offset: 0x000E28C0
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001357 RID: 4951
		// (get) Token: 0x060047CA RID: 18378 RVA: 0x000E450C File Offset: 0x000E290C
		public int Value
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001358 RID: 4952
		// (get) Token: 0x060047CB RID: 18379 RVA: 0x000E4558 File Offset: 0x000E2958
		public int MinPay
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001359 RID: 4953
		// (get) Token: 0x060047CC RID: 18380 RVA: 0x000E45A4 File Offset: 0x000E29A4
		public int TimeLimit
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135A RID: 4954
		// (get) Token: 0x060047CD RID: 18381 RVA: 0x000E45F0 File Offset: 0x000E29F0
		public int PersonalDailyNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135B RID: 4955
		// (get) Token: 0x060047CE RID: 18382 RVA: 0x000E463C File Offset: 0x000E2A3C
		public int PersonalWeeklyNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135C RID: 4956
		// (get) Token: 0x060047CF RID: 18383 RVA: 0x000E4688 File Offset: 0x000E2A88
		public int PersonalMonthlyNum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135D RID: 4957
		// (get) Token: 0x060047D0 RID: 18384 RVA: 0x000E46D4 File Offset: 0x000E2AD4
		public int PersonalTotalNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135E RID: 4958
		// (get) Token: 0x060047D1 RID: 18385 RVA: 0x000E4720 File Offset: 0x000E2B20
		public int ServerDailyNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700135F RID: 4959
		// (get) Token: 0x060047D2 RID: 18386 RVA: 0x000E476C File Offset: 0x000E2B6C
		public int ServerWeeklyNum
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001360 RID: 4960
		// (get) Token: 0x060047D3 RID: 18387 RVA: 0x000E47B8 File Offset: 0x000E2BB8
		public int ServerMonthlyNum
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001361 RID: 4961
		// (get) Token: 0x060047D4 RID: 18388 RVA: 0x000E4804 File Offset: 0x000E2C04
		public int ServerTotalNum
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (754270407 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060047D5 RID: 18389 RVA: 0x000E4850 File Offset: 0x000E2C50
		public static Offset<RareItemTable> CreateRareItemTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Value = 0, int MinPay = 0, int TimeLimit = 0, int PersonalDailyNum = 0, int PersonalWeeklyNum = 0, int PersonalMonthlyNum = 0, int PersonalTotalNum = 0, int ServerDailyNum = 0, int ServerWeeklyNum = 0, int ServerMonthlyNum = 0, int ServerTotalNum = 0)
		{
			builder.StartObject(13);
			RareItemTable.AddServerTotalNum(builder, ServerTotalNum);
			RareItemTable.AddServerMonthlyNum(builder, ServerMonthlyNum);
			RareItemTable.AddServerWeeklyNum(builder, ServerWeeklyNum);
			RareItemTable.AddServerDailyNum(builder, ServerDailyNum);
			RareItemTable.AddPersonalTotalNum(builder, PersonalTotalNum);
			RareItemTable.AddPersonalMonthlyNum(builder, PersonalMonthlyNum);
			RareItemTable.AddPersonalWeeklyNum(builder, PersonalWeeklyNum);
			RareItemTable.AddPersonalDailyNum(builder, PersonalDailyNum);
			RareItemTable.AddTimeLimit(builder, TimeLimit);
			RareItemTable.AddMinPay(builder, MinPay);
			RareItemTable.AddValue(builder, Value);
			RareItemTable.AddType(builder, Type);
			RareItemTable.AddID(builder, ID);
			return RareItemTable.EndRareItemTable(builder);
		}

		// Token: 0x060047D6 RID: 18390 RVA: 0x000E48D0 File Offset: 0x000E2CD0
		public static void StartRareItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x060047D7 RID: 18391 RVA: 0x000E48DA File Offset: 0x000E2CDA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060047D8 RID: 18392 RVA: 0x000E48E5 File Offset: 0x000E2CE5
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060047D9 RID: 18393 RVA: 0x000E48F0 File Offset: 0x000E2CF0
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(2, Value, 0);
		}

		// Token: 0x060047DA RID: 18394 RVA: 0x000E48FB File Offset: 0x000E2CFB
		public static void AddMinPay(FlatBufferBuilder builder, int MinPay)
		{
			builder.AddInt(3, MinPay, 0);
		}

		// Token: 0x060047DB RID: 18395 RVA: 0x000E4906 File Offset: 0x000E2D06
		public static void AddTimeLimit(FlatBufferBuilder builder, int TimeLimit)
		{
			builder.AddInt(4, TimeLimit, 0);
		}

		// Token: 0x060047DC RID: 18396 RVA: 0x000E4911 File Offset: 0x000E2D11
		public static void AddPersonalDailyNum(FlatBufferBuilder builder, int PersonalDailyNum)
		{
			builder.AddInt(5, PersonalDailyNum, 0);
		}

		// Token: 0x060047DD RID: 18397 RVA: 0x000E491C File Offset: 0x000E2D1C
		public static void AddPersonalWeeklyNum(FlatBufferBuilder builder, int PersonalWeeklyNum)
		{
			builder.AddInt(6, PersonalWeeklyNum, 0);
		}

		// Token: 0x060047DE RID: 18398 RVA: 0x000E4927 File Offset: 0x000E2D27
		public static void AddPersonalMonthlyNum(FlatBufferBuilder builder, int PersonalMonthlyNum)
		{
			builder.AddInt(7, PersonalMonthlyNum, 0);
		}

		// Token: 0x060047DF RID: 18399 RVA: 0x000E4932 File Offset: 0x000E2D32
		public static void AddPersonalTotalNum(FlatBufferBuilder builder, int PersonalTotalNum)
		{
			builder.AddInt(8, PersonalTotalNum, 0);
		}

		// Token: 0x060047E0 RID: 18400 RVA: 0x000E493D File Offset: 0x000E2D3D
		public static void AddServerDailyNum(FlatBufferBuilder builder, int ServerDailyNum)
		{
			builder.AddInt(9, ServerDailyNum, 0);
		}

		// Token: 0x060047E1 RID: 18401 RVA: 0x000E4949 File Offset: 0x000E2D49
		public static void AddServerWeeklyNum(FlatBufferBuilder builder, int ServerWeeklyNum)
		{
			builder.AddInt(10, ServerWeeklyNum, 0);
		}

		// Token: 0x060047E2 RID: 18402 RVA: 0x000E4955 File Offset: 0x000E2D55
		public static void AddServerMonthlyNum(FlatBufferBuilder builder, int ServerMonthlyNum)
		{
			builder.AddInt(11, ServerMonthlyNum, 0);
		}

		// Token: 0x060047E3 RID: 18403 RVA: 0x000E4961 File Offset: 0x000E2D61
		public static void AddServerTotalNum(FlatBufferBuilder builder, int ServerTotalNum)
		{
			builder.AddInt(12, ServerTotalNum, 0);
		}

		// Token: 0x060047E4 RID: 18404 RVA: 0x000E4970 File Offset: 0x000E2D70
		public static Offset<RareItemTable> EndRareItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RareItemTable>(value);
		}

		// Token: 0x060047E5 RID: 18405 RVA: 0x000E498A File Offset: 0x000E2D8A
		public static void FinishRareItemTableBuffer(FlatBufferBuilder builder, Offset<RareItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A88 RID: 6792
		private Table __p = new Table();

		// Token: 0x02000576 RID: 1398
		public enum eCrypt
		{
			// Token: 0x04001A8A RID: 6794
			code = 754270407
		}
	}
}
