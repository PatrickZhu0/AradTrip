using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000532 RID: 1330
	public class NpcTable : IFlatbufferObject
	{
		// Token: 0x1700122F RID: 4655
		// (get) Token: 0x06004432 RID: 17458 RVA: 0x000DC35C File Offset: 0x000DA75C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004433 RID: 17459 RVA: 0x000DC369 File Offset: 0x000DA769
		public static NpcTable GetRootAsNpcTable(ByteBuffer _bb)
		{
			return NpcTable.GetRootAsNpcTable(_bb, new NpcTable());
		}

		// Token: 0x06004434 RID: 17460 RVA: 0x000DC376 File Offset: 0x000DA776
		public static NpcTable GetRootAsNpcTable(ByteBuffer _bb, NpcTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004435 RID: 17461 RVA: 0x000DC392 File Offset: 0x000DA792
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004436 RID: 17462 RVA: 0x000DC3AC File Offset: 0x000DA7AC
		public NpcTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001230 RID: 4656
		// (get) Token: 0x06004437 RID: 17463 RVA: 0x000DC3B8 File Offset: 0x000DA7B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001231 RID: 4657
		// (get) Token: 0x06004438 RID: 17464 RVA: 0x000DC404 File Offset: 0x000DA804
		public string NpcName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004439 RID: 17465 RVA: 0x000DC446 File Offset: 0x000DA846
		public ArraySegment<byte>? GetNpcNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001232 RID: 4658
		// (get) Token: 0x0600443A RID: 17466 RVA: 0x000DC454 File Offset: 0x000DA854
		public string NpcIcon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600443B RID: 17467 RVA: 0x000DC496 File Offset: 0x000DA896
		public ArraySegment<byte>? GetNpcIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001233 RID: 4659
		// (get) Token: 0x0600443C RID: 17468 RVA: 0x000DC4A4 File Offset: 0x000DA8A4
		public string NpcBody
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600443D RID: 17469 RVA: 0x000DC4E7 File Offset: 0x000DA8E7
		public ArraySegment<byte>? GetNpcBodyBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001234 RID: 4660
		// (get) Token: 0x0600443E RID: 17470 RVA: 0x000DC4F8 File Offset: 0x000DA8F8
		public string NpcTitle
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600443F RID: 17471 RVA: 0x000DC53B File Offset: 0x000DA93B
		public ArraySegment<byte>? GetNpcTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001235 RID: 4661
		// (get) Token: 0x06004440 RID: 17472 RVA: 0x000DC54C File Offset: 0x000DA94C
		public string NpcTitleIcon
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004441 RID: 17473 RVA: 0x000DC58F File Offset: 0x000DA98F
		public ArraySegment<byte>? GetNpcTitleIconBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06004442 RID: 17474 RVA: 0x000DC5A0 File Offset: 0x000DA9A0
		public int MapIDArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001236 RID: 4662
		// (get) Token: 0x06004443 RID: 17475 RVA: 0x000DC5F0 File Offset: 0x000DA9F0
		public int MapIDLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004444 RID: 17476 RVA: 0x000DC623 File Offset: 0x000DAA23
		public ArraySegment<byte>? GetMapIDBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001237 RID: 4663
		// (get) Token: 0x06004445 RID: 17477 RVA: 0x000DC632 File Offset: 0x000DAA32
		public FlatBufferArray<int> MapID
		{
			get
			{
				if (this.MapIDValue == null)
				{
					this.MapIDValue = new FlatBufferArray<int>(new Func<int, int>(this.MapIDArray), this.MapIDLength);
				}
				return this.MapIDValue;
			}
		}

		// Token: 0x17001238 RID: 4664
		// (get) Token: 0x06004446 RID: 17478 RVA: 0x000DC664 File Offset: 0x000DAA64
		public int Location
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001239 RID: 4665
		// (get) Token: 0x06004447 RID: 17479 RVA: 0x000DC6B0 File Offset: 0x000DAAB0
		public int ResID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700123A RID: 4666
		// (get) Token: 0x06004448 RID: 17480 RVA: 0x000DC6FC File Offset: 0x000DAAFC
		public int UnitTableID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700123B RID: 4667
		// (get) Token: 0x06004449 RID: 17481 RVA: 0x000DC748 File Offset: 0x000DAB48
		public string NpcRandomTalk
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600444A RID: 17482 RVA: 0x000DC78B File Offset: 0x000DAB8B
		public ArraySegment<byte>? GetNpcRandomTalkBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700123C RID: 4668
		// (get) Token: 0x0600444B RID: 17483 RVA: 0x000DC79C File Offset: 0x000DAB9C
		public string NpcTalk
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600444C RID: 17484 RVA: 0x000DC7DF File Offset: 0x000DABDF
		public ArraySegment<byte>? GetNpcTalkBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x1700123D RID: 4669
		// (get) Token: 0x0600444D RID: 17485 RVA: 0x000DC7F0 File Offset: 0x000DABF0
		public NpcTable.eFunction Function
		{
			get
			{
				int num = this.__p.__offset(28);
				return (NpcTable.eFunction)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700123E RID: 4670
		// (get) Token: 0x0600444E RID: 17486 RVA: 0x000DC834 File Offset: 0x000DAC34
		public NpcTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(30);
				return (NpcTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700123F RID: 4671
		// (get) Token: 0x0600444F RID: 17487 RVA: 0x000DC878 File Offset: 0x000DAC78
		public int OpenLevel
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004450 RID: 17488 RVA: 0x000DC8C4 File Offset: 0x000DACC4
		public int FunctionIntParamArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001240 RID: 4672
		// (get) Token: 0x06004451 RID: 17489 RVA: 0x000DC914 File Offset: 0x000DAD14
		public int FunctionIntParamLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004452 RID: 17490 RVA: 0x000DC947 File Offset: 0x000DAD47
		public ArraySegment<byte>? GetFunctionIntParamBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17001241 RID: 4673
		// (get) Token: 0x06004453 RID: 17491 RVA: 0x000DC956 File Offset: 0x000DAD56
		public FlatBufferArray<int> FunctionIntParam
		{
			get
			{
				if (this.FunctionIntParamValue == null)
				{
					this.FunctionIntParamValue = new FlatBufferArray<int>(new Func<int, int>(this.FunctionIntParamArray), this.FunctionIntParamLength);
				}
				return this.FunctionIntParamValue;
			}
		}

		// Token: 0x17001242 RID: 4674
		// (get) Token: 0x06004454 RID: 17492 RVA: 0x000DC988 File Offset: 0x000DAD88
		public int FunctionIntParam2
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001243 RID: 4675
		// (get) Token: 0x06004455 RID: 17493 RVA: 0x000DC9D4 File Offset: 0x000DADD4
		public string FunctionIcon
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004456 RID: 17494 RVA: 0x000DCA17 File Offset: 0x000DAE17
		public ArraySegment<byte>? GetFunctionIconBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17001244 RID: 4676
		// (get) Token: 0x06004457 RID: 17495 RVA: 0x000DCA28 File Offset: 0x000DAE28
		public string TalkContent
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004458 RID: 17496 RVA: 0x000DCA6B File Offset: 0x000DAE6B
		public ArraySegment<byte>? GetTalkContentBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17001245 RID: 4677
		// (get) Token: 0x06004459 RID: 17497 RVA: 0x000DCA7C File Offset: 0x000DAE7C
		public int Interval
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001246 RID: 4678
		// (get) Token: 0x0600445A RID: 17498 RVA: 0x000DCAC8 File Offset: 0x000DAEC8
		public NpcTable.eDialogType DialogType
		{
			get
			{
				int num = this.__p.__offset(44);
				return (NpcTable.eDialogType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001247 RID: 4679
		// (get) Token: 0x0600445B RID: 17499 RVA: 0x000DCB0C File Offset: 0x000DAF0C
		public int Height
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600445C RID: 17500 RVA: 0x000DCB58 File Offset: 0x000DAF58
		public string SEStartArray(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001248 RID: 4680
		// (get) Token: 0x0600445D RID: 17501 RVA: 0x000DCBA0 File Offset: 0x000DAFA0
		public int SEStartLength
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001249 RID: 4681
		// (get) Token: 0x0600445E RID: 17502 RVA: 0x000DCBD3 File Offset: 0x000DAFD3
		public FlatBufferArray<string> SEStart
		{
			get
			{
				if (this.SEStartValue == null)
				{
					this.SEStartValue = new FlatBufferArray<string>(new Func<int, string>(this.SEStartArray), this.SEStartLength);
				}
				return this.SEStartValue;
			}
		}

		// Token: 0x0600445F RID: 17503 RVA: 0x000DCC04 File Offset: 0x000DB004
		public string SEEndArray(int j)
		{
			int num = this.__p.__offset(50);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700124A RID: 4682
		// (get) Token: 0x06004460 RID: 17504 RVA: 0x000DCC4C File Offset: 0x000DB04C
		public int SEEndLength
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700124B RID: 4683
		// (get) Token: 0x06004461 RID: 17505 RVA: 0x000DCC7F File Offset: 0x000DB07F
		public FlatBufferArray<string> SEEnd
		{
			get
			{
				if (this.SEEndValue == null)
				{
					this.SEEndValue = new FlatBufferArray<string>(new Func<int, string>(this.SEEndArray), this.SEEndLength);
				}
				return this.SEEndValue;
			}
		}

		// Token: 0x06004462 RID: 17506 RVA: 0x000DCCB0 File Offset: 0x000DB0B0
		public string SEStandArray(int j)
		{
			int num = this.__p.__offset(52);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700124C RID: 4684
		// (get) Token: 0x06004463 RID: 17507 RVA: 0x000DCCF8 File Offset: 0x000DB0F8
		public int SEStandLength
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700124D RID: 4685
		// (get) Token: 0x06004464 RID: 17508 RVA: 0x000DCD2B File Offset: 0x000DB12B
		public FlatBufferArray<string> SEStand
		{
			get
			{
				if (this.SEStandValue == null)
				{
					this.SEStandValue = new FlatBufferArray<string>(new Func<int, string>(this.SEStandArray), this.SEStandLength);
				}
				return this.SEStandValue;
			}
		}

		// Token: 0x1700124E RID: 4686
		// (get) Token: 0x06004465 RID: 17509 RVA: 0x000DCD5C File Offset: 0x000DB15C
		public int SEPeriod
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700124F RID: 4687
		// (get) Token: 0x06004466 RID: 17510 RVA: 0x000DCDA8 File Offset: 0x000DB1A8
		public int Probability
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001250 RID: 4688
		// (get) Token: 0x06004467 RID: 17511 RVA: 0x000DCDF4 File Offset: 0x000DB1F4
		public string ExchangeShopData
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004468 RID: 17512 RVA: 0x000DCE37 File Offset: 0x000DB237
		public ArraySegment<byte>? GetExchangeShopDataBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17001251 RID: 4689
		// (get) Token: 0x06004469 RID: 17513 RVA: 0x000DCE48 File Offset: 0x000DB248
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001252 RID: 4690
		// (get) Token: 0x0600446A RID: 17514 RVA: 0x000DCE94 File Offset: 0x000DB294
		public int ChallengeTimes
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001253 RID: 4691
		// (get) Token: 0x0600446B RID: 17515 RVA: 0x000DCEE0 File Offset: 0x000DB2E0
		public int MustTeam
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001254 RID: 4692
		// (get) Token: 0x0600446C RID: 17516 RVA: 0x000DCF2C File Offset: 0x000DB32C
		public int NameLocalPosY
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001255 RID: 4693
		// (get) Token: 0x0600446D RID: 17517 RVA: 0x000DCF78 File Offset: 0x000DB378
		public int Hard
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (482128735 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600446E RID: 17518 RVA: 0x000DCFC4 File Offset: 0x000DB3C4
		public static Offset<NpcTable> CreateNpcTable(FlatBufferBuilder builder, int ID = 0, StringOffset NpcNameOffset = default(StringOffset), StringOffset NpcIconOffset = default(StringOffset), StringOffset NpcBodyOffset = default(StringOffset), StringOffset NpcTitleOffset = default(StringOffset), StringOffset NpcTitleIconOffset = default(StringOffset), VectorOffset MapIDOffset = default(VectorOffset), int Location = 0, int ResID = 0, int UnitTableID = 0, StringOffset NpcRandomTalkOffset = default(StringOffset), StringOffset NpcTalkOffset = default(StringOffset), NpcTable.eFunction Function = NpcTable.eFunction.none, NpcTable.eSubType SubType = NpcTable.eSubType.None, int OpenLevel = 0, VectorOffset FunctionIntParamOffset = default(VectorOffset), int FunctionIntParam2 = 0, StringOffset FunctionIconOffset = default(StringOffset), StringOffset TalkContentOffset = default(StringOffset), int Interval = 0, NpcTable.eDialogType DialogType = NpcTable.eDialogType.DialogType_None, int Height = 0, VectorOffset SEStartOffset = default(VectorOffset), VectorOffset SEEndOffset = default(VectorOffset), VectorOffset SEStandOffset = default(VectorOffset), int SEPeriod = 0, int Probability = 0, StringOffset ExchangeShopDataOffset = default(StringOffset), int DungeonID = 0, int ChallengeTimes = 0, int MustTeam = 0, int NameLocalPosY = 0, int Hard = 0)
		{
			builder.StartObject(33);
			NpcTable.AddHard(builder, Hard);
			NpcTable.AddNameLocalPosY(builder, NameLocalPosY);
			NpcTable.AddMustTeam(builder, MustTeam);
			NpcTable.AddChallengeTimes(builder, ChallengeTimes);
			NpcTable.AddDungeonID(builder, DungeonID);
			NpcTable.AddExchangeShopData(builder, ExchangeShopDataOffset);
			NpcTable.AddProbability(builder, Probability);
			NpcTable.AddSEPeriod(builder, SEPeriod);
			NpcTable.AddSEStand(builder, SEStandOffset);
			NpcTable.AddSEEnd(builder, SEEndOffset);
			NpcTable.AddSEStart(builder, SEStartOffset);
			NpcTable.AddHeight(builder, Height);
			NpcTable.AddDialogType(builder, DialogType);
			NpcTable.AddInterval(builder, Interval);
			NpcTable.AddTalkContent(builder, TalkContentOffset);
			NpcTable.AddFunctionIcon(builder, FunctionIconOffset);
			NpcTable.AddFunctionIntParam2(builder, FunctionIntParam2);
			NpcTable.AddFunctionIntParam(builder, FunctionIntParamOffset);
			NpcTable.AddOpenLevel(builder, OpenLevel);
			NpcTable.AddSubType(builder, SubType);
			NpcTable.AddFunction(builder, Function);
			NpcTable.AddNpcTalk(builder, NpcTalkOffset);
			NpcTable.AddNpcRandomTalk(builder, NpcRandomTalkOffset);
			NpcTable.AddUnitTableID(builder, UnitTableID);
			NpcTable.AddResID(builder, ResID);
			NpcTable.AddLocation(builder, Location);
			NpcTable.AddMapID(builder, MapIDOffset);
			NpcTable.AddNpcTitleIcon(builder, NpcTitleIconOffset);
			NpcTable.AddNpcTitle(builder, NpcTitleOffset);
			NpcTable.AddNpcBody(builder, NpcBodyOffset);
			NpcTable.AddNpcIcon(builder, NpcIconOffset);
			NpcTable.AddNpcName(builder, NpcNameOffset);
			NpcTable.AddID(builder, ID);
			return NpcTable.EndNpcTable(builder);
		}

		// Token: 0x0600446F RID: 17519 RVA: 0x000DD0E4 File Offset: 0x000DB4E4
		public static void StartNpcTable(FlatBufferBuilder builder)
		{
			builder.StartObject(33);
		}

		// Token: 0x06004470 RID: 17520 RVA: 0x000DD0EE File Offset: 0x000DB4EE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004471 RID: 17521 RVA: 0x000DD0F9 File Offset: 0x000DB4F9
		public static void AddNpcName(FlatBufferBuilder builder, StringOffset NpcNameOffset)
		{
			builder.AddOffset(1, NpcNameOffset.Value, 0);
		}

		// Token: 0x06004472 RID: 17522 RVA: 0x000DD10A File Offset: 0x000DB50A
		public static void AddNpcIcon(FlatBufferBuilder builder, StringOffset NpcIconOffset)
		{
			builder.AddOffset(2, NpcIconOffset.Value, 0);
		}

		// Token: 0x06004473 RID: 17523 RVA: 0x000DD11B File Offset: 0x000DB51B
		public static void AddNpcBody(FlatBufferBuilder builder, StringOffset NpcBodyOffset)
		{
			builder.AddOffset(3, NpcBodyOffset.Value, 0);
		}

		// Token: 0x06004474 RID: 17524 RVA: 0x000DD12C File Offset: 0x000DB52C
		public static void AddNpcTitle(FlatBufferBuilder builder, StringOffset NpcTitleOffset)
		{
			builder.AddOffset(4, NpcTitleOffset.Value, 0);
		}

		// Token: 0x06004475 RID: 17525 RVA: 0x000DD13D File Offset: 0x000DB53D
		public static void AddNpcTitleIcon(FlatBufferBuilder builder, StringOffset NpcTitleIconOffset)
		{
			builder.AddOffset(5, NpcTitleIconOffset.Value, 0);
		}

		// Token: 0x06004476 RID: 17526 RVA: 0x000DD14E File Offset: 0x000DB54E
		public static void AddMapID(FlatBufferBuilder builder, VectorOffset MapIDOffset)
		{
			builder.AddOffset(6, MapIDOffset.Value, 0);
		}

		// Token: 0x06004477 RID: 17527 RVA: 0x000DD160 File Offset: 0x000DB560
		public static VectorOffset CreateMapIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004478 RID: 17528 RVA: 0x000DD19D File Offset: 0x000DB59D
		public static void StartMapIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004479 RID: 17529 RVA: 0x000DD1A8 File Offset: 0x000DB5A8
		public static void AddLocation(FlatBufferBuilder builder, int Location)
		{
			builder.AddInt(7, Location, 0);
		}

		// Token: 0x0600447A RID: 17530 RVA: 0x000DD1B3 File Offset: 0x000DB5B3
		public static void AddResID(FlatBufferBuilder builder, int ResID)
		{
			builder.AddInt(8, ResID, 0);
		}

		// Token: 0x0600447B RID: 17531 RVA: 0x000DD1BE File Offset: 0x000DB5BE
		public static void AddUnitTableID(FlatBufferBuilder builder, int UnitTableID)
		{
			builder.AddInt(9, UnitTableID, 0);
		}

		// Token: 0x0600447C RID: 17532 RVA: 0x000DD1CA File Offset: 0x000DB5CA
		public static void AddNpcRandomTalk(FlatBufferBuilder builder, StringOffset NpcRandomTalkOffset)
		{
			builder.AddOffset(10, NpcRandomTalkOffset.Value, 0);
		}

		// Token: 0x0600447D RID: 17533 RVA: 0x000DD1DC File Offset: 0x000DB5DC
		public static void AddNpcTalk(FlatBufferBuilder builder, StringOffset NpcTalkOffset)
		{
			builder.AddOffset(11, NpcTalkOffset.Value, 0);
		}

		// Token: 0x0600447E RID: 17534 RVA: 0x000DD1EE File Offset: 0x000DB5EE
		public static void AddFunction(FlatBufferBuilder builder, NpcTable.eFunction Function)
		{
			builder.AddInt(12, (int)Function, 0);
		}

		// Token: 0x0600447F RID: 17535 RVA: 0x000DD1FA File Offset: 0x000DB5FA
		public static void AddSubType(FlatBufferBuilder builder, NpcTable.eSubType SubType)
		{
			builder.AddInt(13, (int)SubType, 0);
		}

		// Token: 0x06004480 RID: 17536 RVA: 0x000DD206 File Offset: 0x000DB606
		public static void AddOpenLevel(FlatBufferBuilder builder, int OpenLevel)
		{
			builder.AddInt(14, OpenLevel, 0);
		}

		// Token: 0x06004481 RID: 17537 RVA: 0x000DD212 File Offset: 0x000DB612
		public static void AddFunctionIntParam(FlatBufferBuilder builder, VectorOffset FunctionIntParamOffset)
		{
			builder.AddOffset(15, FunctionIntParamOffset.Value, 0);
		}

		// Token: 0x06004482 RID: 17538 RVA: 0x000DD224 File Offset: 0x000DB624
		public static VectorOffset CreateFunctionIntParamVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004483 RID: 17539 RVA: 0x000DD261 File Offset: 0x000DB661
		public static void StartFunctionIntParamVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004484 RID: 17540 RVA: 0x000DD26C File Offset: 0x000DB66C
		public static void AddFunctionIntParam2(FlatBufferBuilder builder, int FunctionIntParam2)
		{
			builder.AddInt(16, FunctionIntParam2, 0);
		}

		// Token: 0x06004485 RID: 17541 RVA: 0x000DD278 File Offset: 0x000DB678
		public static void AddFunctionIcon(FlatBufferBuilder builder, StringOffset FunctionIconOffset)
		{
			builder.AddOffset(17, FunctionIconOffset.Value, 0);
		}

		// Token: 0x06004486 RID: 17542 RVA: 0x000DD28A File Offset: 0x000DB68A
		public static void AddTalkContent(FlatBufferBuilder builder, StringOffset TalkContentOffset)
		{
			builder.AddOffset(18, TalkContentOffset.Value, 0);
		}

		// Token: 0x06004487 RID: 17543 RVA: 0x000DD29C File Offset: 0x000DB69C
		public static void AddInterval(FlatBufferBuilder builder, int Interval)
		{
			builder.AddInt(19, Interval, 0);
		}

		// Token: 0x06004488 RID: 17544 RVA: 0x000DD2A8 File Offset: 0x000DB6A8
		public static void AddDialogType(FlatBufferBuilder builder, NpcTable.eDialogType DialogType)
		{
			builder.AddInt(20, (int)DialogType, 0);
		}

		// Token: 0x06004489 RID: 17545 RVA: 0x000DD2B4 File Offset: 0x000DB6B4
		public static void AddHeight(FlatBufferBuilder builder, int Height)
		{
			builder.AddInt(21, Height, 0);
		}

		// Token: 0x0600448A RID: 17546 RVA: 0x000DD2C0 File Offset: 0x000DB6C0
		public static void AddSEStart(FlatBufferBuilder builder, VectorOffset SEStartOffset)
		{
			builder.AddOffset(22, SEStartOffset.Value, 0);
		}

		// Token: 0x0600448B RID: 17547 RVA: 0x000DD2D4 File Offset: 0x000DB6D4
		public static VectorOffset CreateSEStartVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600448C RID: 17548 RVA: 0x000DD31A File Offset: 0x000DB71A
		public static void StartSEStartVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600448D RID: 17549 RVA: 0x000DD325 File Offset: 0x000DB725
		public static void AddSEEnd(FlatBufferBuilder builder, VectorOffset SEEndOffset)
		{
			builder.AddOffset(23, SEEndOffset.Value, 0);
		}

		// Token: 0x0600448E RID: 17550 RVA: 0x000DD338 File Offset: 0x000DB738
		public static VectorOffset CreateSEEndVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0600448F RID: 17551 RVA: 0x000DD37E File Offset: 0x000DB77E
		public static void StartSEEndVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004490 RID: 17552 RVA: 0x000DD389 File Offset: 0x000DB789
		public static void AddSEStand(FlatBufferBuilder builder, VectorOffset SEStandOffset)
		{
			builder.AddOffset(24, SEStandOffset.Value, 0);
		}

		// Token: 0x06004491 RID: 17553 RVA: 0x000DD39C File Offset: 0x000DB79C
		public static VectorOffset CreateSEStandVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004492 RID: 17554 RVA: 0x000DD3E2 File Offset: 0x000DB7E2
		public static void StartSEStandVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004493 RID: 17555 RVA: 0x000DD3ED File Offset: 0x000DB7ED
		public static void AddSEPeriod(FlatBufferBuilder builder, int SEPeriod)
		{
			builder.AddInt(25, SEPeriod, 0);
		}

		// Token: 0x06004494 RID: 17556 RVA: 0x000DD3F9 File Offset: 0x000DB7F9
		public static void AddProbability(FlatBufferBuilder builder, int Probability)
		{
			builder.AddInt(26, Probability, 0);
		}

		// Token: 0x06004495 RID: 17557 RVA: 0x000DD405 File Offset: 0x000DB805
		public static void AddExchangeShopData(FlatBufferBuilder builder, StringOffset ExchangeShopDataOffset)
		{
			builder.AddOffset(27, ExchangeShopDataOffset.Value, 0);
		}

		// Token: 0x06004496 RID: 17558 RVA: 0x000DD417 File Offset: 0x000DB817
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(28, DungeonID, 0);
		}

		// Token: 0x06004497 RID: 17559 RVA: 0x000DD423 File Offset: 0x000DB823
		public static void AddChallengeTimes(FlatBufferBuilder builder, int ChallengeTimes)
		{
			builder.AddInt(29, ChallengeTimes, 0);
		}

		// Token: 0x06004498 RID: 17560 RVA: 0x000DD42F File Offset: 0x000DB82F
		public static void AddMustTeam(FlatBufferBuilder builder, int MustTeam)
		{
			builder.AddInt(30, MustTeam, 0);
		}

		// Token: 0x06004499 RID: 17561 RVA: 0x000DD43B File Offset: 0x000DB83B
		public static void AddNameLocalPosY(FlatBufferBuilder builder, int NameLocalPosY)
		{
			builder.AddInt(31, NameLocalPosY, 0);
		}

		// Token: 0x0600449A RID: 17562 RVA: 0x000DD447 File Offset: 0x000DB847
		public static void AddHard(FlatBufferBuilder builder, int Hard)
		{
			builder.AddInt(32, Hard, 0);
		}

		// Token: 0x0600449B RID: 17563 RVA: 0x000DD454 File Offset: 0x000DB854
		public static Offset<NpcTable> EndNpcTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NpcTable>(value);
		}

		// Token: 0x0600449C RID: 17564 RVA: 0x000DD46E File Offset: 0x000DB86E
		public static void FinishNpcTableBuffer(FlatBufferBuilder builder, Offset<NpcTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001956 RID: 6486
		private Table __p = new Table();

		// Token: 0x04001957 RID: 6487
		private FlatBufferArray<int> MapIDValue;

		// Token: 0x04001958 RID: 6488
		private FlatBufferArray<int> FunctionIntParamValue;

		// Token: 0x04001959 RID: 6489
		private FlatBufferArray<string> SEStartValue;

		// Token: 0x0400195A RID: 6490
		private FlatBufferArray<string> SEEndValue;

		// Token: 0x0400195B RID: 6491
		private FlatBufferArray<string> SEStandValue;

		// Token: 0x02000533 RID: 1331
		public enum eFunction
		{
			// Token: 0x0400195D RID: 6493
			none,
			// Token: 0x0400195E RID: 6494
			invalid = -1,
			// Token: 0x0400195F RID: 6495
			production = 1,
			// Token: 0x04001960 RID: 6496
			shopping,
			// Token: 0x04001961 RID: 6497
			strengthen,
			// Token: 0x04001962 RID: 6498
			decompose,
			// Token: 0x04001963 RID: 6499
			enchanting,
			// Token: 0x04001964 RID: 6500
			store,
			// Token: 0x04001965 RID: 6501
			mail,
			// Token: 0x04001966 RID: 6502
			Townstatue,
			// Token: 0x04001967 RID: 6503
			RandomTreasure,
			// Token: 0x04001968 RID: 6504
			clicknpc = 100,
			// Token: 0x04001969 RID: 6505
			attackCityMonster = 200,
			// Token: 0x0400196A RID: 6506
			TAPGraduation = 300,
			// Token: 0x0400196B RID: 6507
			guildDungeonActivityChest,
			// Token: 0x0400196C RID: 6508
			guildGuardStatue,
			// Token: 0x0400196D RID: 6509
			BlackMarketMerchan,
			// Token: 0x0400196E RID: 6510
			Chiji,
			// Token: 0x0400196F RID: 6511
			AnniersaryParty,
			// Token: 0x04001970 RID: 6512
			SendDoor = 307
		}

		// Token: 0x02000534 RID: 1332
		public enum eSubType
		{
			// Token: 0x04001972 RID: 6514
			None,
			// Token: 0x04001973 RID: 6515
			TownOwner,
			// Token: 0x04001974 RID: 6516
			TownViceOwner_1,
			// Token: 0x04001975 RID: 6517
			TownViceOwner_2,
			// Token: 0x04001976 RID: 6518
			GuildGuard1,
			// Token: 0x04001977 RID: 6519
			GuildGuard2,
			// Token: 0x04001978 RID: 6520
			GuildGuard3,
			// Token: 0x04001979 RID: 6521
			ShopNpc,
			// Token: 0x0400197A RID: 6522
			MonsterNpc
		}

		// Token: 0x02000535 RID: 1333
		public enum eDialogType
		{
			// Token: 0x0400197C RID: 6524
			DialogType_None,
			// Token: 0x0400197D RID: 6525
			random,
			// Token: 0x0400197E RID: 6526
			trival
		}

		// Token: 0x02000536 RID: 1334
		public enum eCrypt
		{
			// Token: 0x04001980 RID: 6528
			code = 482128735
		}
	}
}
