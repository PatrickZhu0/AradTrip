using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004EB RID: 1259
	public class MallItemTable : IFlatbufferObject
	{
		// Token: 0x170010D0 RID: 4304
		// (get) Token: 0x0600401A RID: 16410 RVA: 0x000D2AD8 File Offset: 0x000D0ED8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600401B RID: 16411 RVA: 0x000D2AE5 File Offset: 0x000D0EE5
		public static MallItemTable GetRootAsMallItemTable(ByteBuffer _bb)
		{
			return MallItemTable.GetRootAsMallItemTable(_bb, new MallItemTable());
		}

		// Token: 0x0600401C RID: 16412 RVA: 0x000D2AF2 File Offset: 0x000D0EF2
		public static MallItemTable GetRootAsMallItemTable(ByteBuffer _bb, MallItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600401D RID: 16413 RVA: 0x000D2B0E File Offset: 0x000D0F0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600401E RID: 16414 RVA: 0x000D2B28 File Offset: 0x000D0F28
		public MallItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x0600401F RID: 16415 RVA: 0x000D2B34 File Offset: 0x000D0F34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D2 RID: 4306
		// (get) Token: 0x06004020 RID: 16416 RVA: 0x000D2B80 File Offset: 0x000D0F80
		public string giftpackname
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x000D2BC2 File Offset: 0x000D0FC2
		public ArraySegment<byte>? GetGiftpacknameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170010D3 RID: 4307
		// (get) Token: 0x06004022 RID: 16418 RVA: 0x000D2BD0 File Offset: 0x000D0FD0
		public int type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x06004023 RID: 16419 RVA: 0x000D2C1C File Offset: 0x000D101C
		public int subtype
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D5 RID: 4309
		// (get) Token: 0x06004024 RID: 16420 RVA: 0x000D2C68 File Offset: 0x000D1068
		public int jobtype
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D6 RID: 4310
		// (get) Token: 0x06004025 RID: 16421 RVA: 0x000D2CB4 File Offset: 0x000D10B4
		public int itemid
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D7 RID: 4311
		// (get) Token: 0x06004026 RID: 16422 RVA: 0x000D2D00 File Offset: 0x000D1100
		public int groupnum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D8 RID: 4312
		// (get) Token: 0x06004027 RID: 16423 RVA: 0x000D2D4C File Offset: 0x000D114C
		public int price
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010D9 RID: 4313
		// (get) Token: 0x06004028 RID: 16424 RVA: 0x000D2D98 File Offset: 0x000D1198
		public int disprice
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010DA RID: 4314
		// (get) Token: 0x06004029 RID: 16425 RVA: 0x000D2DE4 File Offset: 0x000D11E4
		public int moneytype
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010DB RID: 4315
		// (get) Token: 0x0600402A RID: 16426 RVA: 0x000D2E30 File Offset: 0x000D1230
		public int limittype
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010DC RID: 4316
		// (get) Token: 0x0600402B RID: 16427 RVA: 0x000D2E7C File Offset: 0x000D127C
		public int limitnum
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010DD RID: 4317
		// (get) Token: 0x0600402C RID: 16428 RVA: 0x000D2EC8 File Offset: 0x000D12C8
		public string giftpackitems
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600402D RID: 16429 RVA: 0x000D2F0B File Offset: 0x000D130B
		public ArraySegment<byte>? GetGiftpackitemsBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170010DE RID: 4318
		// (get) Token: 0x0600402E RID: 16430 RVA: 0x000D2F1C File Offset: 0x000D131C
		public string giftpackicon
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600402F RID: 16431 RVA: 0x000D2F5F File Offset: 0x000D135F
		public ArraySegment<byte>? GetGiftpackiconBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x06004030 RID: 16432 RVA: 0x000D2F70 File Offset: 0x000D1370
		public int TimeCalcType
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x06004031 RID: 16433 RVA: 0x000D2FBC File Offset: 0x000D13BC
		public int limtstarttime
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x06004032 RID: 16434 RVA: 0x000D3008 File Offset: 0x000D1408
		public int limitendtime
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E2 RID: 4322
		// (get) Token: 0x06004033 RID: 16435 RVA: 0x000D3054 File Offset: 0x000D1454
		public string StartTimeFromService
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004034 RID: 16436 RVA: 0x000D3097 File Offset: 0x000D1497
		public ArraySegment<byte>? GetStartTimeFromServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170010E3 RID: 4323
		// (get) Token: 0x06004035 RID: 16437 RVA: 0x000D30A8 File Offset: 0x000D14A8
		public string EndTimeFromService
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004036 RID: 16438 RVA: 0x000D30EB File Offset: 0x000D14EB
		public ArraySegment<byte>? GetEndTimeFromServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x06004037 RID: 16439 RVA: 0x000D30FC File Offset: 0x000D14FC
		public string StartTimeFromFirstService
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004038 RID: 16440 RVA: 0x000D313F File Offset: 0x000D153F
		public ArraySegment<byte>? GetStartTimeFromFirstServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170010E5 RID: 4325
		// (get) Token: 0x06004039 RID: 16441 RVA: 0x000D3150 File Offset: 0x000D1550
		public string EndTimeFromFirstService
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600403A RID: 16442 RVA: 0x000D3193 File Offset: 0x000D1593
		public ArraySegment<byte>? GetEndTimeFromFirstServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170010E6 RID: 4326
		// (get) Token: 0x0600403B RID: 16443 RVA: 0x000D31A4 File Offset: 0x000D15A4
		public int openInterval
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E7 RID: 4327
		// (get) Token: 0x0600403C RID: 16444 RVA: 0x000D31F0 File Offset: 0x000D15F0
		public int cloesdInterval
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E8 RID: 4328
		// (get) Token: 0x0600403D RID: 16445 RVA: 0x000D323C File Offset: 0x000D163C
		public int limitetotlenum
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010E9 RID: 4329
		// (get) Token: 0x0600403E RID: 16446 RVA: 0x000D3288 File Offset: 0x000D1688
		public int vipscore
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010EA RID: 4330
		// (get) Token: 0x0600403F RID: 16447 RVA: 0x000D32D4 File Offset: 0x000D16D4
		public int tagtype
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010EB RID: 4331
		// (get) Token: 0x06004040 RID: 16448 RVA: 0x000D3320 File Offset: 0x000D1720
		public int sort
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010EC RID: 4332
		// (get) Token: 0x06004041 RID: 16449 RVA: 0x000D336C File Offset: 0x000D176C
		public int hotsort
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010ED RID: 4333
		// (get) Token: 0x06004042 RID: 16450 RVA: 0x000D33B8 File Offset: 0x000D17B8
		public int goodsType
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010EE RID: 4334
		// (get) Token: 0x06004043 RID: 16451 RVA: 0x000D3404 File Offset: 0x000D1804
		public int goodsSubType
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010EF RID: 4335
		// (get) Token: 0x06004044 RID: 16452 RVA: 0x000D3450 File Offset: 0x000D1850
		public int goodsState
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F0 RID: 4336
		// (get) Token: 0x06004045 RID: 16453 RVA: 0x000D349C File Offset: 0x000D189C
		public int isRecommend
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F1 RID: 4337
		// (get) Token: 0x06004046 RID: 16454 RVA: 0x000D34E8 File Offset: 0x000D18E8
		public int PersonalTailID
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F2 RID: 4338
		// (get) Token: 0x06004047 RID: 16455 RVA: 0x000D3534 File Offset: 0x000D1934
		public int discountRate
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F3 RID: 4339
		// (get) Token: 0x06004048 RID: 16456 RVA: 0x000D3580 File Offset: 0x000D1980
		public int loginPushId
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F4 RID: 4340
		// (get) Token: 0x06004049 RID: 16457 RVA: 0x000D35CC File Offset: 0x000D19CC
		public string FashionImagePath
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600404A RID: 16458 RVA: 0x000D360F File Offset: 0x000D1A0F
		public ArraySegment<byte>? GetFashionImagePathBytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x170010F5 RID: 4341
		// (get) Token: 0x0600404B RID: 16459 RVA: 0x000D3620 File Offset: 0x000D1A20
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600404C RID: 16460 RVA: 0x000D3663 File Offset: 0x000D1A63
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(76);
		}

		// Token: 0x170010F6 RID: 4342
		// (get) Token: 0x0600404D RID: 16461 RVA: 0x000D3674 File Offset: 0x000D1A74
		public string BuyGotInfo
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600404E RID: 16462 RVA: 0x000D36B7 File Offset: 0x000D1AB7
		public ArraySegment<byte>? GetBuyGotInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x170010F7 RID: 4343
		// (get) Token: 0x0600404F RID: 16463 RVA: 0x000D36C8 File Offset: 0x000D1AC8
		public string ExtParams
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004050 RID: 16464 RVA: 0x000D370B File Offset: 0x000D1B0B
		public ArraySegment<byte>? GetExtParamsBytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x170010F8 RID: 4344
		// (get) Token: 0x06004051 RID: 16465 RVA: 0x000D371C File Offset: 0x000D1B1C
		public int PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010F9 RID: 4345
		// (get) Token: 0x06004052 RID: 16466 RVA: 0x000D3768 File Offset: 0x000D1B68
		public int MallPushCond
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010FA RID: 4346
		// (get) Token: 0x06004053 RID: 16467 RVA: 0x000D37B4 File Offset: 0x000D1BB4
		public int AccountRefreshType
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010FB RID: 4347
		// (get) Token: 0x06004054 RID: 16468 RVA: 0x000D3800 File Offset: 0x000D1C00
		public string AccountRefreshTimePoint
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004055 RID: 16469 RVA: 0x000D3843 File Offset: 0x000D1C43
		public ArraySegment<byte>? GetAccountRefreshTimePointBytes()
		{
			return this.__p.__vector_as_arraysegment(88);
		}

		// Token: 0x170010FC RID: 4348
		// (get) Token: 0x06004056 RID: 16470 RVA: 0x000D3854 File Offset: 0x000D1C54
		public int AccountLimitBuyNum
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010FD RID: 4349
		// (get) Token: 0x06004057 RID: 16471 RVA: 0x000D38A0 File Offset: 0x000D1CA0
		public int DiscountCoupon
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010FE RID: 4350
		// (get) Token: 0x06004058 RID: 16472 RVA: 0x000D38EC File Offset: 0x000D1CEC
		public int multiple
		{
			get
			{
				int num = this.__p.__offset(94);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010FF RID: 4351
		// (get) Token: 0x06004059 RID: 16473 RVA: 0x000D3938 File Offset: 0x000D1D38
		public int deductionCoupon
		{
			get
			{
				int num = this.__p.__offset(96);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001100 RID: 4352
		// (get) Token: 0x0600405A RID: 16474 RVA: 0x000D3984 File Offset: 0x000D1D84
		public int creditpointDeduction
		{
			get
			{
				int num = this.__p.__offset(98);
				return (num == 0) ? 0 : (-1595037077 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600405B RID: 16475 RVA: 0x000D39D0 File Offset: 0x000D1DD0
		public static Offset<MallItemTable> CreateMallItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset giftpacknameOffset = default(StringOffset), int type = 0, int subtype = 0, int jobtype = 0, int itemid = 0, int groupnum = 0, int price = 0, int disprice = 0, int moneytype = 0, int limittype = 0, int limitnum = 0, StringOffset giftpackitemsOffset = default(StringOffset), StringOffset giftpackiconOffset = default(StringOffset), int TimeCalcType = 0, int limtstarttime = 0, int limitendtime = 0, StringOffset StartTimeFromServiceOffset = default(StringOffset), StringOffset EndTimeFromServiceOffset = default(StringOffset), StringOffset StartTimeFromFirstServiceOffset = default(StringOffset), StringOffset EndTimeFromFirstServiceOffset = default(StringOffset), int openInterval = 0, int cloesdInterval = 0, int limitetotlenum = 0, int vipscore = 0, int tagtype = 0, int sort = 0, int hotsort = 0, int goodsType = 0, int goodsSubType = 0, int goodsState = 0, int isRecommend = 0, int PersonalTailID = 0, int discountRate = 0, int loginPushId = 0, StringOffset FashionImagePathOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), StringOffset BuyGotInfoOffset = default(StringOffset), StringOffset ExtParamsOffset = default(StringOffset), int PlayerLevelLimit = 0, int MallPushCond = 0, int AccountRefreshType = 0, StringOffset AccountRefreshTimePointOffset = default(StringOffset), int AccountLimitBuyNum = 0, int DiscountCoupon = 0, int multiple = 0, int deductionCoupon = 0, int creditpointDeduction = 0)
		{
			builder.StartObject(48);
			MallItemTable.AddCreditpointDeduction(builder, creditpointDeduction);
			MallItemTable.AddDeductionCoupon(builder, deductionCoupon);
			MallItemTable.AddMultiple(builder, multiple);
			MallItemTable.AddDiscountCoupon(builder, DiscountCoupon);
			MallItemTable.AddAccountLimitBuyNum(builder, AccountLimitBuyNum);
			MallItemTable.AddAccountRefreshTimePoint(builder, AccountRefreshTimePointOffset);
			MallItemTable.AddAccountRefreshType(builder, AccountRefreshType);
			MallItemTable.AddMallPushCond(builder, MallPushCond);
			MallItemTable.AddPlayerLevelLimit(builder, PlayerLevelLimit);
			MallItemTable.AddExtParams(builder, ExtParamsOffset);
			MallItemTable.AddBuyGotInfo(builder, BuyGotInfoOffset);
			MallItemTable.AddDesc(builder, DescOffset);
			MallItemTable.AddFashionImagePath(builder, FashionImagePathOffset);
			MallItemTable.AddLoginPushId(builder, loginPushId);
			MallItemTable.AddDiscountRate(builder, discountRate);
			MallItemTable.AddPersonalTailID(builder, PersonalTailID);
			MallItemTable.AddIsRecommend(builder, isRecommend);
			MallItemTable.AddGoodsState(builder, goodsState);
			MallItemTable.AddGoodsSubType(builder, goodsSubType);
			MallItemTable.AddGoodsType(builder, goodsType);
			MallItemTable.AddHotsort(builder, hotsort);
			MallItemTable.AddSort(builder, sort);
			MallItemTable.AddTagtype(builder, tagtype);
			MallItemTable.AddVipscore(builder, vipscore);
			MallItemTable.AddLimitetotlenum(builder, limitetotlenum);
			MallItemTable.AddCloesdInterval(builder, cloesdInterval);
			MallItemTable.AddOpenInterval(builder, openInterval);
			MallItemTable.AddEndTimeFromFirstService(builder, EndTimeFromFirstServiceOffset);
			MallItemTable.AddStartTimeFromFirstService(builder, StartTimeFromFirstServiceOffset);
			MallItemTable.AddEndTimeFromService(builder, EndTimeFromServiceOffset);
			MallItemTable.AddStartTimeFromService(builder, StartTimeFromServiceOffset);
			MallItemTable.AddLimitendtime(builder, limitendtime);
			MallItemTable.AddLimtstarttime(builder, limtstarttime);
			MallItemTable.AddTimeCalcType(builder, TimeCalcType);
			MallItemTable.AddGiftpackicon(builder, giftpackiconOffset);
			MallItemTable.AddGiftpackitems(builder, giftpackitemsOffset);
			MallItemTable.AddLimitnum(builder, limitnum);
			MallItemTable.AddLimittype(builder, limittype);
			MallItemTable.AddMoneytype(builder, moneytype);
			MallItemTable.AddDisprice(builder, disprice);
			MallItemTable.AddPrice(builder, price);
			MallItemTable.AddGroupnum(builder, groupnum);
			MallItemTable.AddItemid(builder, itemid);
			MallItemTable.AddJobtype(builder, jobtype);
			MallItemTable.AddSubtype(builder, subtype);
			MallItemTable.AddType(builder, type);
			MallItemTable.AddGiftpackname(builder, giftpacknameOffset);
			MallItemTable.AddID(builder, ID);
			return MallItemTable.EndMallItemTable(builder);
		}

		// Token: 0x0600405C RID: 16476 RVA: 0x000D3B68 File Offset: 0x000D1F68
		public static void StartMallItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(48);
		}

		// Token: 0x0600405D RID: 16477 RVA: 0x000D3B72 File Offset: 0x000D1F72
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600405E RID: 16478 RVA: 0x000D3B7D File Offset: 0x000D1F7D
		public static void AddGiftpackname(FlatBufferBuilder builder, StringOffset giftpacknameOffset)
		{
			builder.AddOffset(1, giftpacknameOffset.Value, 0);
		}

		// Token: 0x0600405F RID: 16479 RVA: 0x000D3B8E File Offset: 0x000D1F8E
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(2, type, 0);
		}

		// Token: 0x06004060 RID: 16480 RVA: 0x000D3B99 File Offset: 0x000D1F99
		public static void AddSubtype(FlatBufferBuilder builder, int subtype)
		{
			builder.AddInt(3, subtype, 0);
		}

		// Token: 0x06004061 RID: 16481 RVA: 0x000D3BA4 File Offset: 0x000D1FA4
		public static void AddJobtype(FlatBufferBuilder builder, int jobtype)
		{
			builder.AddInt(4, jobtype, 0);
		}

		// Token: 0x06004062 RID: 16482 RVA: 0x000D3BAF File Offset: 0x000D1FAF
		public static void AddItemid(FlatBufferBuilder builder, int itemid)
		{
			builder.AddInt(5, itemid, 0);
		}

		// Token: 0x06004063 RID: 16483 RVA: 0x000D3BBA File Offset: 0x000D1FBA
		public static void AddGroupnum(FlatBufferBuilder builder, int groupnum)
		{
			builder.AddInt(6, groupnum, 0);
		}

		// Token: 0x06004064 RID: 16484 RVA: 0x000D3BC5 File Offset: 0x000D1FC5
		public static void AddPrice(FlatBufferBuilder builder, int price)
		{
			builder.AddInt(7, price, 0);
		}

		// Token: 0x06004065 RID: 16485 RVA: 0x000D3BD0 File Offset: 0x000D1FD0
		public static void AddDisprice(FlatBufferBuilder builder, int disprice)
		{
			builder.AddInt(8, disprice, 0);
		}

		// Token: 0x06004066 RID: 16486 RVA: 0x000D3BDB File Offset: 0x000D1FDB
		public static void AddMoneytype(FlatBufferBuilder builder, int moneytype)
		{
			builder.AddInt(9, moneytype, 0);
		}

		// Token: 0x06004067 RID: 16487 RVA: 0x000D3BE7 File Offset: 0x000D1FE7
		public static void AddLimittype(FlatBufferBuilder builder, int limittype)
		{
			builder.AddInt(10, limittype, 0);
		}

		// Token: 0x06004068 RID: 16488 RVA: 0x000D3BF3 File Offset: 0x000D1FF3
		public static void AddLimitnum(FlatBufferBuilder builder, int limitnum)
		{
			builder.AddInt(11, limitnum, 0);
		}

		// Token: 0x06004069 RID: 16489 RVA: 0x000D3BFF File Offset: 0x000D1FFF
		public static void AddGiftpackitems(FlatBufferBuilder builder, StringOffset giftpackitemsOffset)
		{
			builder.AddOffset(12, giftpackitemsOffset.Value, 0);
		}

		// Token: 0x0600406A RID: 16490 RVA: 0x000D3C11 File Offset: 0x000D2011
		public static void AddGiftpackicon(FlatBufferBuilder builder, StringOffset giftpackiconOffset)
		{
			builder.AddOffset(13, giftpackiconOffset.Value, 0);
		}

		// Token: 0x0600406B RID: 16491 RVA: 0x000D3C23 File Offset: 0x000D2023
		public static void AddTimeCalcType(FlatBufferBuilder builder, int TimeCalcType)
		{
			builder.AddInt(14, TimeCalcType, 0);
		}

		// Token: 0x0600406C RID: 16492 RVA: 0x000D3C2F File Offset: 0x000D202F
		public static void AddLimtstarttime(FlatBufferBuilder builder, int limtstarttime)
		{
			builder.AddInt(15, limtstarttime, 0);
		}

		// Token: 0x0600406D RID: 16493 RVA: 0x000D3C3B File Offset: 0x000D203B
		public static void AddLimitendtime(FlatBufferBuilder builder, int limitendtime)
		{
			builder.AddInt(16, limitendtime, 0);
		}

		// Token: 0x0600406E RID: 16494 RVA: 0x000D3C47 File Offset: 0x000D2047
		public static void AddStartTimeFromService(FlatBufferBuilder builder, StringOffset StartTimeFromServiceOffset)
		{
			builder.AddOffset(17, StartTimeFromServiceOffset.Value, 0);
		}

		// Token: 0x0600406F RID: 16495 RVA: 0x000D3C59 File Offset: 0x000D2059
		public static void AddEndTimeFromService(FlatBufferBuilder builder, StringOffset EndTimeFromServiceOffset)
		{
			builder.AddOffset(18, EndTimeFromServiceOffset.Value, 0);
		}

		// Token: 0x06004070 RID: 16496 RVA: 0x000D3C6B File Offset: 0x000D206B
		public static void AddStartTimeFromFirstService(FlatBufferBuilder builder, StringOffset StartTimeFromFirstServiceOffset)
		{
			builder.AddOffset(19, StartTimeFromFirstServiceOffset.Value, 0);
		}

		// Token: 0x06004071 RID: 16497 RVA: 0x000D3C7D File Offset: 0x000D207D
		public static void AddEndTimeFromFirstService(FlatBufferBuilder builder, StringOffset EndTimeFromFirstServiceOffset)
		{
			builder.AddOffset(20, EndTimeFromFirstServiceOffset.Value, 0);
		}

		// Token: 0x06004072 RID: 16498 RVA: 0x000D3C8F File Offset: 0x000D208F
		public static void AddOpenInterval(FlatBufferBuilder builder, int openInterval)
		{
			builder.AddInt(21, openInterval, 0);
		}

		// Token: 0x06004073 RID: 16499 RVA: 0x000D3C9B File Offset: 0x000D209B
		public static void AddCloesdInterval(FlatBufferBuilder builder, int cloesdInterval)
		{
			builder.AddInt(22, cloesdInterval, 0);
		}

		// Token: 0x06004074 RID: 16500 RVA: 0x000D3CA7 File Offset: 0x000D20A7
		public static void AddLimitetotlenum(FlatBufferBuilder builder, int limitetotlenum)
		{
			builder.AddInt(23, limitetotlenum, 0);
		}

		// Token: 0x06004075 RID: 16501 RVA: 0x000D3CB3 File Offset: 0x000D20B3
		public static void AddVipscore(FlatBufferBuilder builder, int vipscore)
		{
			builder.AddInt(24, vipscore, 0);
		}

		// Token: 0x06004076 RID: 16502 RVA: 0x000D3CBF File Offset: 0x000D20BF
		public static void AddTagtype(FlatBufferBuilder builder, int tagtype)
		{
			builder.AddInt(25, tagtype, 0);
		}

		// Token: 0x06004077 RID: 16503 RVA: 0x000D3CCB File Offset: 0x000D20CB
		public static void AddSort(FlatBufferBuilder builder, int sort)
		{
			builder.AddInt(26, sort, 0);
		}

		// Token: 0x06004078 RID: 16504 RVA: 0x000D3CD7 File Offset: 0x000D20D7
		public static void AddHotsort(FlatBufferBuilder builder, int hotsort)
		{
			builder.AddInt(27, hotsort, 0);
		}

		// Token: 0x06004079 RID: 16505 RVA: 0x000D3CE3 File Offset: 0x000D20E3
		public static void AddGoodsType(FlatBufferBuilder builder, int goodsType)
		{
			builder.AddInt(28, goodsType, 0);
		}

		// Token: 0x0600407A RID: 16506 RVA: 0x000D3CEF File Offset: 0x000D20EF
		public static void AddGoodsSubType(FlatBufferBuilder builder, int goodsSubType)
		{
			builder.AddInt(29, goodsSubType, 0);
		}

		// Token: 0x0600407B RID: 16507 RVA: 0x000D3CFB File Offset: 0x000D20FB
		public static void AddGoodsState(FlatBufferBuilder builder, int goodsState)
		{
			builder.AddInt(30, goodsState, 0);
		}

		// Token: 0x0600407C RID: 16508 RVA: 0x000D3D07 File Offset: 0x000D2107
		public static void AddIsRecommend(FlatBufferBuilder builder, int isRecommend)
		{
			builder.AddInt(31, isRecommend, 0);
		}

		// Token: 0x0600407D RID: 16509 RVA: 0x000D3D13 File Offset: 0x000D2113
		public static void AddPersonalTailID(FlatBufferBuilder builder, int PersonalTailID)
		{
			builder.AddInt(32, PersonalTailID, 0);
		}

		// Token: 0x0600407E RID: 16510 RVA: 0x000D3D1F File Offset: 0x000D211F
		public static void AddDiscountRate(FlatBufferBuilder builder, int discountRate)
		{
			builder.AddInt(33, discountRate, 0);
		}

		// Token: 0x0600407F RID: 16511 RVA: 0x000D3D2B File Offset: 0x000D212B
		public static void AddLoginPushId(FlatBufferBuilder builder, int loginPushId)
		{
			builder.AddInt(34, loginPushId, 0);
		}

		// Token: 0x06004080 RID: 16512 RVA: 0x000D3D37 File Offset: 0x000D2137
		public static void AddFashionImagePath(FlatBufferBuilder builder, StringOffset FashionImagePathOffset)
		{
			builder.AddOffset(35, FashionImagePathOffset.Value, 0);
		}

		// Token: 0x06004081 RID: 16513 RVA: 0x000D3D49 File Offset: 0x000D2149
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(36, DescOffset.Value, 0);
		}

		// Token: 0x06004082 RID: 16514 RVA: 0x000D3D5B File Offset: 0x000D215B
		public static void AddBuyGotInfo(FlatBufferBuilder builder, StringOffset BuyGotInfoOffset)
		{
			builder.AddOffset(37, BuyGotInfoOffset.Value, 0);
		}

		// Token: 0x06004083 RID: 16515 RVA: 0x000D3D6D File Offset: 0x000D216D
		public static void AddExtParams(FlatBufferBuilder builder, StringOffset ExtParamsOffset)
		{
			builder.AddOffset(38, ExtParamsOffset.Value, 0);
		}

		// Token: 0x06004084 RID: 16516 RVA: 0x000D3D7F File Offset: 0x000D217F
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, int PlayerLevelLimit)
		{
			builder.AddInt(39, PlayerLevelLimit, 0);
		}

		// Token: 0x06004085 RID: 16517 RVA: 0x000D3D8B File Offset: 0x000D218B
		public static void AddMallPushCond(FlatBufferBuilder builder, int MallPushCond)
		{
			builder.AddInt(40, MallPushCond, 0);
		}

		// Token: 0x06004086 RID: 16518 RVA: 0x000D3D97 File Offset: 0x000D2197
		public static void AddAccountRefreshType(FlatBufferBuilder builder, int AccountRefreshType)
		{
			builder.AddInt(41, AccountRefreshType, 0);
		}

		// Token: 0x06004087 RID: 16519 RVA: 0x000D3DA3 File Offset: 0x000D21A3
		public static void AddAccountRefreshTimePoint(FlatBufferBuilder builder, StringOffset AccountRefreshTimePointOffset)
		{
			builder.AddOffset(42, AccountRefreshTimePointOffset.Value, 0);
		}

		// Token: 0x06004088 RID: 16520 RVA: 0x000D3DB5 File Offset: 0x000D21B5
		public static void AddAccountLimitBuyNum(FlatBufferBuilder builder, int AccountLimitBuyNum)
		{
			builder.AddInt(43, AccountLimitBuyNum, 0);
		}

		// Token: 0x06004089 RID: 16521 RVA: 0x000D3DC1 File Offset: 0x000D21C1
		public static void AddDiscountCoupon(FlatBufferBuilder builder, int DiscountCoupon)
		{
			builder.AddInt(44, DiscountCoupon, 0);
		}

		// Token: 0x0600408A RID: 16522 RVA: 0x000D3DCD File Offset: 0x000D21CD
		public static void AddMultiple(FlatBufferBuilder builder, int multiple)
		{
			builder.AddInt(45, multiple, 0);
		}

		// Token: 0x0600408B RID: 16523 RVA: 0x000D3DD9 File Offset: 0x000D21D9
		public static void AddDeductionCoupon(FlatBufferBuilder builder, int deductionCoupon)
		{
			builder.AddInt(46, deductionCoupon, 0);
		}

		// Token: 0x0600408C RID: 16524 RVA: 0x000D3DE5 File Offset: 0x000D21E5
		public static void AddCreditpointDeduction(FlatBufferBuilder builder, int creditpointDeduction)
		{
			builder.AddInt(47, creditpointDeduction, 0);
		}

		// Token: 0x0600408D RID: 16525 RVA: 0x000D3DF4 File Offset: 0x000D21F4
		public static Offset<MallItemTable> EndMallItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MallItemTable>(value);
		}

		// Token: 0x0600408E RID: 16526 RVA: 0x000D3E0E File Offset: 0x000D220E
		public static void FinishMallItemTableBuffer(FlatBufferBuilder builder, Offset<MallItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001820 RID: 6176
		private Table __p = new Table();

		// Token: 0x020004EC RID: 1260
		public enum eCrypt
		{
			// Token: 0x04001822 RID: 6178
			code = -1595037077
		}
	}
}
