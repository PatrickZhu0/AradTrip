using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000577 RID: 1399
	public class RechargePushTable : IFlatbufferObject
	{
		// Token: 0x17001362 RID: 4962
		// (get) Token: 0x060047E7 RID: 18407 RVA: 0x000E49AC File Offset: 0x000E2DAC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060047E8 RID: 18408 RVA: 0x000E49B9 File Offset: 0x000E2DB9
		public static RechargePushTable GetRootAsRechargePushTable(ByteBuffer _bb)
		{
			return RechargePushTable.GetRootAsRechargePushTable(_bb, new RechargePushTable());
		}

		// Token: 0x060047E9 RID: 18409 RVA: 0x000E49C6 File Offset: 0x000E2DC6
		public static RechargePushTable GetRootAsRechargePushTable(ByteBuffer _bb, RechargePushTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060047EA RID: 18410 RVA: 0x000E49E2 File Offset: 0x000E2DE2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060047EB RID: 18411 RVA: 0x000E49FC File Offset: 0x000E2DFC
		public RechargePushTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001363 RID: 4963
		// (get) Token: 0x060047EC RID: 18412 RVA: 0x000E4A08 File Offset: 0x000E2E08
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001364 RID: 4964
		// (get) Token: 0x060047ED RID: 18413 RVA: 0x000E4A54 File Offset: 0x000E2E54
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001365 RID: 4965
		// (get) Token: 0x060047EE RID: 18414 RVA: 0x000E4AA0 File Offset: 0x000E2EA0
		public int LvLower
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001366 RID: 4966
		// (get) Token: 0x060047EF RID: 18415 RVA: 0x000E4AEC File Offset: 0x000E2EEC
		public int LvToplimit
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001367 RID: 4967
		// (get) Token: 0x060047F0 RID: 18416 RVA: 0x000E4B38 File Offset: 0x000E2F38
		public int VipLvLower
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001368 RID: 4968
		// (get) Token: 0x060047F1 RID: 18417 RVA: 0x000E4B84 File Offset: 0x000E2F84
		public string JudgePropID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060047F2 RID: 18418 RVA: 0x000E4BC7 File Offset: 0x000E2FC7
		public ArraySegment<byte>? GetJudgePropIDBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001369 RID: 4969
		// (get) Token: 0x060047F3 RID: 18419 RVA: 0x000E4BD8 File Offset: 0x000E2FD8
		public int ParameterType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700136A RID: 4970
		// (get) Token: 0x060047F4 RID: 18420 RVA: 0x000E4C24 File Offset: 0x000E3024
		public string DaysBefore
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060047F5 RID: 18421 RVA: 0x000E4C67 File Offset: 0x000E3067
		public ArraySegment<byte>? GetDaysBeforeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700136B RID: 4971
		// (get) Token: 0x060047F6 RID: 18422 RVA: 0x000E4C78 File Offset: 0x000E3078
		public int Parameter1
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700136C RID: 4972
		// (get) Token: 0x060047F7 RID: 18423 RVA: 0x000E4CC4 File Offset: 0x000E30C4
		public int Recent
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700136D RID: 4973
		// (get) Token: 0x060047F8 RID: 18424 RVA: 0x000E4D10 File Offset: 0x000E3110
		public int Parameter2
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700136E RID: 4974
		// (get) Token: 0x060047F9 RID: 18425 RVA: 0x000E4D5C File Offset: 0x000E315C
		public string PushID
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060047FA RID: 18426 RVA: 0x000E4D9F File Offset: 0x000E319F
		public ArraySegment<byte>? GetPushIDBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700136F RID: 4975
		// (get) Token: 0x060047FB RID: 18427 RVA: 0x000E4DB0 File Offset: 0x000E31B0
		public int BuyTimes
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001370 RID: 4976
		// (get) Token: 0x060047FC RID: 18428 RVA: 0x000E4DFC File Offset: 0x000E31FC
		public int PushPrice
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001371 RID: 4977
		// (get) Token: 0x060047FD RID: 18429 RVA: 0x000E4E48 File Offset: 0x000E3248
		public int PushBeforePrice
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001372 RID: 4978
		// (get) Token: 0x060047FE RID: 18430 RVA: 0x000E4E94 File Offset: 0x000E3294
		public int PushCD
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001373 RID: 4979
		// (get) Token: 0x060047FF RID: 18431 RVA: 0x000E4EE0 File Offset: 0x000E32E0
		public int CoolCD
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (783499981 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004800 RID: 18432 RVA: 0x000E4F2C File Offset: 0x000E332C
		public static Offset<RechargePushTable> CreateRechargePushTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int LvLower = 0, int LvToplimit = 0, int VipLvLower = 0, StringOffset JudgePropIDOffset = default(StringOffset), int ParameterType = 0, StringOffset DaysBeforeOffset = default(StringOffset), int Parameter1 = 0, int Recent = 0, int Parameter2 = 0, StringOffset PushIDOffset = default(StringOffset), int BuyTimes = 0, int PushPrice = 0, int PushBeforePrice = 0, int PushCD = 0, int CoolCD = 0)
		{
			builder.StartObject(17);
			RechargePushTable.AddCoolCD(builder, CoolCD);
			RechargePushTable.AddPushCD(builder, PushCD);
			RechargePushTable.AddPushBeforePrice(builder, PushBeforePrice);
			RechargePushTable.AddPushPrice(builder, PushPrice);
			RechargePushTable.AddBuyTimes(builder, BuyTimes);
			RechargePushTable.AddPushID(builder, PushIDOffset);
			RechargePushTable.AddParameter2(builder, Parameter2);
			RechargePushTable.AddRecent(builder, Recent);
			RechargePushTable.AddParameter1(builder, Parameter1);
			RechargePushTable.AddDaysBefore(builder, DaysBeforeOffset);
			RechargePushTable.AddParameterType(builder, ParameterType);
			RechargePushTable.AddJudgePropID(builder, JudgePropIDOffset);
			RechargePushTable.AddVipLvLower(builder, VipLvLower);
			RechargePushTable.AddLvToplimit(builder, LvToplimit);
			RechargePushTable.AddLvLower(builder, LvLower);
			RechargePushTable.AddType(builder, Type);
			RechargePushTable.AddID(builder, ID);
			return RechargePushTable.EndRechargePushTable(builder);
		}

		// Token: 0x06004801 RID: 18433 RVA: 0x000E4FCC File Offset: 0x000E33CC
		public static void StartRechargePushTable(FlatBufferBuilder builder)
		{
			builder.StartObject(17);
		}

		// Token: 0x06004802 RID: 18434 RVA: 0x000E4FD6 File Offset: 0x000E33D6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004803 RID: 18435 RVA: 0x000E4FE1 File Offset: 0x000E33E1
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06004804 RID: 18436 RVA: 0x000E4FEC File Offset: 0x000E33EC
		public static void AddLvLower(FlatBufferBuilder builder, int LvLower)
		{
			builder.AddInt(2, LvLower, 0);
		}

		// Token: 0x06004805 RID: 18437 RVA: 0x000E4FF7 File Offset: 0x000E33F7
		public static void AddLvToplimit(FlatBufferBuilder builder, int LvToplimit)
		{
			builder.AddInt(3, LvToplimit, 0);
		}

		// Token: 0x06004806 RID: 18438 RVA: 0x000E5002 File Offset: 0x000E3402
		public static void AddVipLvLower(FlatBufferBuilder builder, int VipLvLower)
		{
			builder.AddInt(4, VipLvLower, 0);
		}

		// Token: 0x06004807 RID: 18439 RVA: 0x000E500D File Offset: 0x000E340D
		public static void AddJudgePropID(FlatBufferBuilder builder, StringOffset JudgePropIDOffset)
		{
			builder.AddOffset(5, JudgePropIDOffset.Value, 0);
		}

		// Token: 0x06004808 RID: 18440 RVA: 0x000E501E File Offset: 0x000E341E
		public static void AddParameterType(FlatBufferBuilder builder, int ParameterType)
		{
			builder.AddInt(6, ParameterType, 0);
		}

		// Token: 0x06004809 RID: 18441 RVA: 0x000E5029 File Offset: 0x000E3429
		public static void AddDaysBefore(FlatBufferBuilder builder, StringOffset DaysBeforeOffset)
		{
			builder.AddOffset(7, DaysBeforeOffset.Value, 0);
		}

		// Token: 0x0600480A RID: 18442 RVA: 0x000E503A File Offset: 0x000E343A
		public static void AddParameter1(FlatBufferBuilder builder, int Parameter1)
		{
			builder.AddInt(8, Parameter1, 0);
		}

		// Token: 0x0600480B RID: 18443 RVA: 0x000E5045 File Offset: 0x000E3445
		public static void AddRecent(FlatBufferBuilder builder, int Recent)
		{
			builder.AddInt(9, Recent, 0);
		}

		// Token: 0x0600480C RID: 18444 RVA: 0x000E5051 File Offset: 0x000E3451
		public static void AddParameter2(FlatBufferBuilder builder, int Parameter2)
		{
			builder.AddInt(10, Parameter2, 0);
		}

		// Token: 0x0600480D RID: 18445 RVA: 0x000E505D File Offset: 0x000E345D
		public static void AddPushID(FlatBufferBuilder builder, StringOffset PushIDOffset)
		{
			builder.AddOffset(11, PushIDOffset.Value, 0);
		}

		// Token: 0x0600480E RID: 18446 RVA: 0x000E506F File Offset: 0x000E346F
		public static void AddBuyTimes(FlatBufferBuilder builder, int BuyTimes)
		{
			builder.AddInt(12, BuyTimes, 0);
		}

		// Token: 0x0600480F RID: 18447 RVA: 0x000E507B File Offset: 0x000E347B
		public static void AddPushPrice(FlatBufferBuilder builder, int PushPrice)
		{
			builder.AddInt(13, PushPrice, 0);
		}

		// Token: 0x06004810 RID: 18448 RVA: 0x000E5087 File Offset: 0x000E3487
		public static void AddPushBeforePrice(FlatBufferBuilder builder, int PushBeforePrice)
		{
			builder.AddInt(14, PushBeforePrice, 0);
		}

		// Token: 0x06004811 RID: 18449 RVA: 0x000E5093 File Offset: 0x000E3493
		public static void AddPushCD(FlatBufferBuilder builder, int PushCD)
		{
			builder.AddInt(15, PushCD, 0);
		}

		// Token: 0x06004812 RID: 18450 RVA: 0x000E509F File Offset: 0x000E349F
		public static void AddCoolCD(FlatBufferBuilder builder, int CoolCD)
		{
			builder.AddInt(16, CoolCD, 0);
		}

		// Token: 0x06004813 RID: 18451 RVA: 0x000E50AC File Offset: 0x000E34AC
		public static Offset<RechargePushTable> EndRechargePushTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RechargePushTable>(value);
		}

		// Token: 0x06004814 RID: 18452 RVA: 0x000E50C6 File Offset: 0x000E34C6
		public static void FinishRechargePushTableBuffer(FlatBufferBuilder builder, Offset<RechargePushTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A8B RID: 6795
		private Table __p = new Table();

		// Token: 0x02000578 RID: 1400
		public enum eCrypt
		{
			// Token: 0x04001A8D RID: 6797
			code = 783499981
		}
	}
}
