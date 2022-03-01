using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200053F RID: 1343
	public class OpActivityTable : IFlatbufferObject
	{
		// Token: 0x17001277 RID: 4727
		// (get) Token: 0x06004500 RID: 17664 RVA: 0x000DE334 File Offset: 0x000DC734
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004501 RID: 17665 RVA: 0x000DE341 File Offset: 0x000DC741
		public static OpActivityTable GetRootAsOpActivityTable(ByteBuffer _bb)
		{
			return OpActivityTable.GetRootAsOpActivityTable(_bb, new OpActivityTable());
		}

		// Token: 0x06004502 RID: 17666 RVA: 0x000DE34E File Offset: 0x000DC74E
		public static OpActivityTable GetRootAsOpActivityTable(ByteBuffer _bb, OpActivityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004503 RID: 17667 RVA: 0x000DE36A File Offset: 0x000DC76A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004504 RID: 17668 RVA: 0x000DE384 File Offset: 0x000DC784
		public OpActivityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001278 RID: 4728
		// (get) Token: 0x06004505 RID: 17669 RVA: 0x000DE390 File Offset: 0x000DC790
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001279 RID: 4729
		// (get) Token: 0x06004506 RID: 17670 RVA: 0x000DE3DC File Offset: 0x000DC7DC
		public OpActivityTable.eTmplateType TmplateType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (OpActivityTable.eTmplateType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700127A RID: 4730
		// (get) Token: 0x06004507 RID: 17671 RVA: 0x000DE420 File Offset: 0x000DC820
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004508 RID: 17672 RVA: 0x000DE462 File Offset: 0x000DC862
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700127B RID: 4731
		// (get) Token: 0x06004509 RID: 17673 RVA: 0x000DE470 File Offset: 0x000DC870
		public int Tag
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700127C RID: 4732
		// (get) Token: 0x0600450A RID: 17674 RVA: 0x000DE4BC File Offset: 0x000DC8BC
		public int PrepareTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700127D RID: 4733
		// (get) Token: 0x0600450B RID: 17675 RVA: 0x000DE508 File Offset: 0x000DC908
		public int TagEndTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700127E RID: 4734
		// (get) Token: 0x0600450C RID: 17676 RVA: 0x000DE554 File Offset: 0x000DC954
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700127F RID: 4735
		// (get) Token: 0x0600450D RID: 17677 RVA: 0x000DE5A0 File Offset: 0x000DC9A0
		public int EndTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001280 RID: 4736
		// (get) Token: 0x0600450E RID: 17678 RVA: 0x000DE5EC File Offset: 0x000DC9EC
		public int PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001281 RID: 4737
		// (get) Token: 0x0600450F RID: 17679 RVA: 0x000DE638 File Offset: 0x000DCA38
		public int MinLevel
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001282 RID: 4738
		// (get) Token: 0x06004510 RID: 17680 RVA: 0x000DE684 File Offset: 0x000DCA84
		public int MaxLevel
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001283 RID: 4739
		// (get) Token: 0x06004511 RID: 17681 RVA: 0x000DE6D0 File Offset: 0x000DCAD0
		public string NeedStartServiceTime
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004512 RID: 17682 RVA: 0x000DE713 File Offset: 0x000DCB13
		public ArraySegment<byte>? GetNeedStartServiceTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17001284 RID: 4740
		// (get) Token: 0x06004513 RID: 17683 RVA: 0x000DE724 File Offset: 0x000DCB24
		public string StartTimeFromService
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004514 RID: 17684 RVA: 0x000DE767 File Offset: 0x000DCB67
		public ArraySegment<byte>? GetStartTimeFromServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17001285 RID: 4741
		// (get) Token: 0x06004515 RID: 17685 RVA: 0x000DE778 File Offset: 0x000DCB78
		public string EndTimeFromService
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004516 RID: 17686 RVA: 0x000DE7BB File Offset: 0x000DCBBB
		public ArraySegment<byte>? GetEndTimeFromServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17001286 RID: 4742
		// (get) Token: 0x06004517 RID: 17687 RVA: 0x000DE7CC File Offset: 0x000DCBCC
		public string StartTimeFromFirstService
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004518 RID: 17688 RVA: 0x000DE80F File Offset: 0x000DCC0F
		public ArraySegment<byte>? GetStartTimeFromFirstServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17001287 RID: 4743
		// (get) Token: 0x06004519 RID: 17689 RVA: 0x000DE820 File Offset: 0x000DCC20
		public string EndTimeFromFirstService
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600451A RID: 17690 RVA: 0x000DE863 File Offset: 0x000DCC63
		public ArraySegment<byte>? GetEndTimeFromFirstServiceBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17001288 RID: 4744
		// (get) Token: 0x0600451B RID: 17691 RVA: 0x000DE874 File Offset: 0x000DCC74
		public string OpenInterval
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600451C RID: 17692 RVA: 0x000DE8B7 File Offset: 0x000DCCB7
		public ArraySegment<byte>? GetOpenIntervalBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17001289 RID: 4745
		// (get) Token: 0x0600451D RID: 17693 RVA: 0x000DE8C8 File Offset: 0x000DCCC8
		public string CloseInterval
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600451E RID: 17694 RVA: 0x000DE90B File Offset: 0x000DCD0B
		public ArraySegment<byte>? GetCloseIntervalBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x1700128A RID: 4746
		// (get) Token: 0x0600451F RID: 17695 RVA: 0x000DE91C File Offset: 0x000DCD1C
		public string Description
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004520 RID: 17696 RVA: 0x000DE95F File Offset: 0x000DCD5F
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x1700128B RID: 4747
		// (get) Token: 0x06004521 RID: 17697 RVA: 0x000DE970 File Offset: 0x000DCD70
		public string RuleDscription
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004522 RID: 17698 RVA: 0x000DE9B3 File Offset: 0x000DCDB3
		public ArraySegment<byte>? GetRuleDscriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x1700128C RID: 4748
		// (get) Token: 0x06004523 RID: 17699 RVA: 0x000DE9C4 File Offset: 0x000DCDC4
		public int CircleType
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700128D RID: 4749
		// (get) Token: 0x06004524 RID: 17700 RVA: 0x000DEA10 File Offset: 0x000DCE10
		public int Param
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004525 RID: 17701 RVA: 0x000DEA5C File Offset: 0x000DCE5C
		public int Param2Array(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700128E RID: 4750
		// (get) Token: 0x06004526 RID: 17702 RVA: 0x000DEAAC File Offset: 0x000DCEAC
		public int Param2Length
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004527 RID: 17703 RVA: 0x000DEADF File Offset: 0x000DCEDF
		public ArraySegment<byte>? GetParam2Bytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x1700128F RID: 4751
		// (get) Token: 0x06004528 RID: 17704 RVA: 0x000DEAEE File Offset: 0x000DCEEE
		public FlatBufferArray<int> Param2
		{
			get
			{
				if (this.Param2Value == null)
				{
					this.Param2Value = new FlatBufferArray<int>(new Func<int, int>(this.Param2Array), this.Param2Length);
				}
				return this.Param2Value;
			}
		}

		// Token: 0x17001290 RID: 4752
		// (get) Token: 0x06004529 RID: 17705 RVA: 0x000DEB20 File Offset: 0x000DCF20
		public string Task
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600452A RID: 17706 RVA: 0x000DEB63 File Offset: 0x000DCF63
		public ArraySegment<byte>? GetTaskBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17001291 RID: 4753
		// (get) Token: 0x0600452B RID: 17707 RVA: 0x000DEB74 File Offset: 0x000DCF74
		public string LogoDesc
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600452C RID: 17708 RVA: 0x000DEBB7 File Offset: 0x000DCFB7
		public ArraySegment<byte>? GetLogoDescBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17001292 RID: 4754
		// (get) Token: 0x0600452D RID: 17709 RVA: 0x000DEBC8 File Offset: 0x000DCFC8
		public string BgPath
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600452E RID: 17710 RVA: 0x000DEC0B File Offset: 0x000DD00B
		public ArraySegment<byte>? GetBgPathBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17001293 RID: 4755
		// (get) Token: 0x0600452F RID: 17711 RVA: 0x000DEC1C File Offset: 0x000DD01C
		public string TextIconPath
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004530 RID: 17712 RVA: 0x000DEC5F File Offset: 0x000DD05F
		public ArraySegment<byte>? GetTextIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17001294 RID: 4756
		// (get) Token: 0x06004531 RID: 17713 RVA: 0x000DEC70 File Offset: 0x000DD070
		public int SuperNewService
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001295 RID: 4757
		// (get) Token: 0x06004532 RID: 17714 RVA: 0x000DECBC File Offset: 0x000DD0BC
		public string CountParam
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004533 RID: 17715 RVA: 0x000DECFF File Offset: 0x000DD0FF
		public ArraySegment<byte>? GetCountParamBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x06004534 RID: 17716 RVA: 0x000DED10 File Offset: 0x000DD110
		public int Param3Array(int j)
		{
			int num = this.__p.__offset(62);
			return (num == 0) ? 0 : (1784045956 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001296 RID: 4758
		// (get) Token: 0x06004535 RID: 17717 RVA: 0x000DED60 File Offset: 0x000DD160
		public int Param3Length
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004536 RID: 17718 RVA: 0x000DED93 File Offset: 0x000DD193
		public ArraySegment<byte>? GetParam3Bytes()
		{
			return this.__p.__vector_as_arraysegment(62);
		}

		// Token: 0x17001297 RID: 4759
		// (get) Token: 0x06004537 RID: 17719 RVA: 0x000DEDA2 File Offset: 0x000DD1A2
		public FlatBufferArray<int> Param3
		{
			get
			{
				if (this.Param3Value == null)
				{
					this.Param3Value = new FlatBufferArray<int>(new Func<int, int>(this.Param3Array), this.Param3Length);
				}
				return this.Param3Value;
			}
		}

		// Token: 0x17001298 RID: 4760
		// (get) Token: 0x06004538 RID: 17720 RVA: 0x000DEDD4 File Offset: 0x000DD1D4
		public string PrefabPath
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004539 RID: 17721 RVA: 0x000DEE17 File Offset: 0x000DD217
		public ArraySegment<byte>? GetPrefabPathBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17001299 RID: 4761
		// (get) Token: 0x0600453A RID: 17722 RVA: 0x000DEE28 File Offset: 0x000DD228
		public string LogoPath
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600453B RID: 17723 RVA: 0x000DEE6B File Offset: 0x000DD26B
		public ArraySegment<byte>? GetLogoPathBytes()
		{
			return this.__p.__vector_as_arraysegment(66);
		}

		// Token: 0x1700129A RID: 4762
		// (get) Token: 0x0600453C RID: 17724 RVA: 0x000DEE7C File Offset: 0x000DD27C
		public string paramStr
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600453D RID: 17725 RVA: 0x000DEEBF File Offset: 0x000DD2BF
		public ArraySegment<byte>? GetParamStrBytes()
		{
			return this.__p.__vector_as_arraysegment(68);
		}

		// Token: 0x0600453E RID: 17726 RVA: 0x000DEED0 File Offset: 0x000DD2D0
		public static Offset<OpActivityTable> CreateOpActivityTable(FlatBufferBuilder builder, int ID = 0, OpActivityTable.eTmplateType TmplateType = OpActivityTable.eTmplateType.TmplateType_None, StringOffset NameOffset = default(StringOffset), int Tag = 0, int PrepareTime = 0, int TagEndTime = 0, int StartTime = 0, int EndTime = 0, int PlayerLevelLimit = 0, int MinLevel = 0, int MaxLevel = 0, StringOffset NeedStartServiceTimeOffset = default(StringOffset), StringOffset StartTimeFromServiceOffset = default(StringOffset), StringOffset EndTimeFromServiceOffset = default(StringOffset), StringOffset StartTimeFromFirstServiceOffset = default(StringOffset), StringOffset EndTimeFromFirstServiceOffset = default(StringOffset), StringOffset OpenIntervalOffset = default(StringOffset), StringOffset CloseIntervalOffset = default(StringOffset), StringOffset DescriptionOffset = default(StringOffset), StringOffset RuleDscriptionOffset = default(StringOffset), int CircleType = 0, int Param = 0, VectorOffset Param2Offset = default(VectorOffset), StringOffset TaskOffset = default(StringOffset), StringOffset LogoDescOffset = default(StringOffset), StringOffset BgPathOffset = default(StringOffset), StringOffset TextIconPathOffset = default(StringOffset), int SuperNewService = 0, StringOffset CountParamOffset = default(StringOffset), VectorOffset Param3Offset = default(VectorOffset), StringOffset PrefabPathOffset = default(StringOffset), StringOffset LogoPathOffset = default(StringOffset), StringOffset paramStrOffset = default(StringOffset))
		{
			builder.StartObject(33);
			OpActivityTable.AddParamStr(builder, paramStrOffset);
			OpActivityTable.AddLogoPath(builder, LogoPathOffset);
			OpActivityTable.AddPrefabPath(builder, PrefabPathOffset);
			OpActivityTable.AddParam3(builder, Param3Offset);
			OpActivityTable.AddCountParam(builder, CountParamOffset);
			OpActivityTable.AddSuperNewService(builder, SuperNewService);
			OpActivityTable.AddTextIconPath(builder, TextIconPathOffset);
			OpActivityTable.AddBgPath(builder, BgPathOffset);
			OpActivityTable.AddLogoDesc(builder, LogoDescOffset);
			OpActivityTable.AddTask(builder, TaskOffset);
			OpActivityTable.AddParam2(builder, Param2Offset);
			OpActivityTable.AddParam(builder, Param);
			OpActivityTable.AddCircleType(builder, CircleType);
			OpActivityTable.AddRuleDscription(builder, RuleDscriptionOffset);
			OpActivityTable.AddDescription(builder, DescriptionOffset);
			OpActivityTable.AddCloseInterval(builder, CloseIntervalOffset);
			OpActivityTable.AddOpenInterval(builder, OpenIntervalOffset);
			OpActivityTable.AddEndTimeFromFirstService(builder, EndTimeFromFirstServiceOffset);
			OpActivityTable.AddStartTimeFromFirstService(builder, StartTimeFromFirstServiceOffset);
			OpActivityTable.AddEndTimeFromService(builder, EndTimeFromServiceOffset);
			OpActivityTable.AddStartTimeFromService(builder, StartTimeFromServiceOffset);
			OpActivityTable.AddNeedStartServiceTime(builder, NeedStartServiceTimeOffset);
			OpActivityTable.AddMaxLevel(builder, MaxLevel);
			OpActivityTable.AddMinLevel(builder, MinLevel);
			OpActivityTable.AddPlayerLevelLimit(builder, PlayerLevelLimit);
			OpActivityTable.AddEndTime(builder, EndTime);
			OpActivityTable.AddStartTime(builder, StartTime);
			OpActivityTable.AddTagEndTime(builder, TagEndTime);
			OpActivityTable.AddPrepareTime(builder, PrepareTime);
			OpActivityTable.AddTag(builder, Tag);
			OpActivityTable.AddName(builder, NameOffset);
			OpActivityTable.AddTmplateType(builder, TmplateType);
			OpActivityTable.AddID(builder, ID);
			return OpActivityTable.EndOpActivityTable(builder);
		}

		// Token: 0x0600453F RID: 17727 RVA: 0x000DEFF0 File Offset: 0x000DD3F0
		public static void StartOpActivityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(33);
		}

		// Token: 0x06004540 RID: 17728 RVA: 0x000DEFFA File Offset: 0x000DD3FA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004541 RID: 17729 RVA: 0x000DF005 File Offset: 0x000DD405
		public static void AddTmplateType(FlatBufferBuilder builder, OpActivityTable.eTmplateType TmplateType)
		{
			builder.AddInt(1, (int)TmplateType, 0);
		}

		// Token: 0x06004542 RID: 17730 RVA: 0x000DF010 File Offset: 0x000DD410
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06004543 RID: 17731 RVA: 0x000DF021 File Offset: 0x000DD421
		public static void AddTag(FlatBufferBuilder builder, int Tag)
		{
			builder.AddInt(3, Tag, 0);
		}

		// Token: 0x06004544 RID: 17732 RVA: 0x000DF02C File Offset: 0x000DD42C
		public static void AddPrepareTime(FlatBufferBuilder builder, int PrepareTime)
		{
			builder.AddInt(4, PrepareTime, 0);
		}

		// Token: 0x06004545 RID: 17733 RVA: 0x000DF037 File Offset: 0x000DD437
		public static void AddTagEndTime(FlatBufferBuilder builder, int TagEndTime)
		{
			builder.AddInt(5, TagEndTime, 0);
		}

		// Token: 0x06004546 RID: 17734 RVA: 0x000DF042 File Offset: 0x000DD442
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(6, StartTime, 0);
		}

		// Token: 0x06004547 RID: 17735 RVA: 0x000DF04D File Offset: 0x000DD44D
		public static void AddEndTime(FlatBufferBuilder builder, int EndTime)
		{
			builder.AddInt(7, EndTime, 0);
		}

		// Token: 0x06004548 RID: 17736 RVA: 0x000DF058 File Offset: 0x000DD458
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, int PlayerLevelLimit)
		{
			builder.AddInt(8, PlayerLevelLimit, 0);
		}

		// Token: 0x06004549 RID: 17737 RVA: 0x000DF063 File Offset: 0x000DD463
		public static void AddMinLevel(FlatBufferBuilder builder, int MinLevel)
		{
			builder.AddInt(9, MinLevel, 0);
		}

		// Token: 0x0600454A RID: 17738 RVA: 0x000DF06F File Offset: 0x000DD46F
		public static void AddMaxLevel(FlatBufferBuilder builder, int MaxLevel)
		{
			builder.AddInt(10, MaxLevel, 0);
		}

		// Token: 0x0600454B RID: 17739 RVA: 0x000DF07B File Offset: 0x000DD47B
		public static void AddNeedStartServiceTime(FlatBufferBuilder builder, StringOffset NeedStartServiceTimeOffset)
		{
			builder.AddOffset(11, NeedStartServiceTimeOffset.Value, 0);
		}

		// Token: 0x0600454C RID: 17740 RVA: 0x000DF08D File Offset: 0x000DD48D
		public static void AddStartTimeFromService(FlatBufferBuilder builder, StringOffset StartTimeFromServiceOffset)
		{
			builder.AddOffset(12, StartTimeFromServiceOffset.Value, 0);
		}

		// Token: 0x0600454D RID: 17741 RVA: 0x000DF09F File Offset: 0x000DD49F
		public static void AddEndTimeFromService(FlatBufferBuilder builder, StringOffset EndTimeFromServiceOffset)
		{
			builder.AddOffset(13, EndTimeFromServiceOffset.Value, 0);
		}

		// Token: 0x0600454E RID: 17742 RVA: 0x000DF0B1 File Offset: 0x000DD4B1
		public static void AddStartTimeFromFirstService(FlatBufferBuilder builder, StringOffset StartTimeFromFirstServiceOffset)
		{
			builder.AddOffset(14, StartTimeFromFirstServiceOffset.Value, 0);
		}

		// Token: 0x0600454F RID: 17743 RVA: 0x000DF0C3 File Offset: 0x000DD4C3
		public static void AddEndTimeFromFirstService(FlatBufferBuilder builder, StringOffset EndTimeFromFirstServiceOffset)
		{
			builder.AddOffset(15, EndTimeFromFirstServiceOffset.Value, 0);
		}

		// Token: 0x06004550 RID: 17744 RVA: 0x000DF0D5 File Offset: 0x000DD4D5
		public static void AddOpenInterval(FlatBufferBuilder builder, StringOffset OpenIntervalOffset)
		{
			builder.AddOffset(16, OpenIntervalOffset.Value, 0);
		}

		// Token: 0x06004551 RID: 17745 RVA: 0x000DF0E7 File Offset: 0x000DD4E7
		public static void AddCloseInterval(FlatBufferBuilder builder, StringOffset CloseIntervalOffset)
		{
			builder.AddOffset(17, CloseIntervalOffset.Value, 0);
		}

		// Token: 0x06004552 RID: 17746 RVA: 0x000DF0F9 File Offset: 0x000DD4F9
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(18, DescriptionOffset.Value, 0);
		}

		// Token: 0x06004553 RID: 17747 RVA: 0x000DF10B File Offset: 0x000DD50B
		public static void AddRuleDscription(FlatBufferBuilder builder, StringOffset RuleDscriptionOffset)
		{
			builder.AddOffset(19, RuleDscriptionOffset.Value, 0);
		}

		// Token: 0x06004554 RID: 17748 RVA: 0x000DF11D File Offset: 0x000DD51D
		public static void AddCircleType(FlatBufferBuilder builder, int CircleType)
		{
			builder.AddInt(20, CircleType, 0);
		}

		// Token: 0x06004555 RID: 17749 RVA: 0x000DF129 File Offset: 0x000DD529
		public static void AddParam(FlatBufferBuilder builder, int Param)
		{
			builder.AddInt(21, Param, 0);
		}

		// Token: 0x06004556 RID: 17750 RVA: 0x000DF135 File Offset: 0x000DD535
		public static void AddParam2(FlatBufferBuilder builder, VectorOffset Param2Offset)
		{
			builder.AddOffset(22, Param2Offset.Value, 0);
		}

		// Token: 0x06004557 RID: 17751 RVA: 0x000DF148 File Offset: 0x000DD548
		public static VectorOffset CreateParam2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004558 RID: 17752 RVA: 0x000DF185 File Offset: 0x000DD585
		public static void StartParam2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004559 RID: 17753 RVA: 0x000DF190 File Offset: 0x000DD590
		public static void AddTask(FlatBufferBuilder builder, StringOffset TaskOffset)
		{
			builder.AddOffset(23, TaskOffset.Value, 0);
		}

		// Token: 0x0600455A RID: 17754 RVA: 0x000DF1A2 File Offset: 0x000DD5A2
		public static void AddLogoDesc(FlatBufferBuilder builder, StringOffset LogoDescOffset)
		{
			builder.AddOffset(24, LogoDescOffset.Value, 0);
		}

		// Token: 0x0600455B RID: 17755 RVA: 0x000DF1B4 File Offset: 0x000DD5B4
		public static void AddBgPath(FlatBufferBuilder builder, StringOffset BgPathOffset)
		{
			builder.AddOffset(25, BgPathOffset.Value, 0);
		}

		// Token: 0x0600455C RID: 17756 RVA: 0x000DF1C6 File Offset: 0x000DD5C6
		public static void AddTextIconPath(FlatBufferBuilder builder, StringOffset TextIconPathOffset)
		{
			builder.AddOffset(26, TextIconPathOffset.Value, 0);
		}

		// Token: 0x0600455D RID: 17757 RVA: 0x000DF1D8 File Offset: 0x000DD5D8
		public static void AddSuperNewService(FlatBufferBuilder builder, int SuperNewService)
		{
			builder.AddInt(27, SuperNewService, 0);
		}

		// Token: 0x0600455E RID: 17758 RVA: 0x000DF1E4 File Offset: 0x000DD5E4
		public static void AddCountParam(FlatBufferBuilder builder, StringOffset CountParamOffset)
		{
			builder.AddOffset(28, CountParamOffset.Value, 0);
		}

		// Token: 0x0600455F RID: 17759 RVA: 0x000DF1F6 File Offset: 0x000DD5F6
		public static void AddParam3(FlatBufferBuilder builder, VectorOffset Param3Offset)
		{
			builder.AddOffset(29, Param3Offset.Value, 0);
		}

		// Token: 0x06004560 RID: 17760 RVA: 0x000DF208 File Offset: 0x000DD608
		public static VectorOffset CreateParam3Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004561 RID: 17761 RVA: 0x000DF245 File Offset: 0x000DD645
		public static void StartParam3Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004562 RID: 17762 RVA: 0x000DF250 File Offset: 0x000DD650
		public static void AddPrefabPath(FlatBufferBuilder builder, StringOffset PrefabPathOffset)
		{
			builder.AddOffset(30, PrefabPathOffset.Value, 0);
		}

		// Token: 0x06004563 RID: 17763 RVA: 0x000DF262 File Offset: 0x000DD662
		public static void AddLogoPath(FlatBufferBuilder builder, StringOffset LogoPathOffset)
		{
			builder.AddOffset(31, LogoPathOffset.Value, 0);
		}

		// Token: 0x06004564 RID: 17764 RVA: 0x000DF274 File Offset: 0x000DD674
		public static void AddParamStr(FlatBufferBuilder builder, StringOffset paramStrOffset)
		{
			builder.AddOffset(32, paramStrOffset.Value, 0);
		}

		// Token: 0x06004565 RID: 17765 RVA: 0x000DF288 File Offset: 0x000DD688
		public static Offset<OpActivityTable> EndOpActivityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OpActivityTable>(value);
		}

		// Token: 0x06004566 RID: 17766 RVA: 0x000DF2A2 File Offset: 0x000DD6A2
		public static void FinishOpActivityTableBuffer(FlatBufferBuilder builder, Offset<OpActivityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001996 RID: 6550
		private Table __p = new Table();

		// Token: 0x04001997 RID: 6551
		private FlatBufferArray<int> Param2Value;

		// Token: 0x04001998 RID: 6552
		private FlatBufferArray<int> Param3Value;

		// Token: 0x02000540 RID: 1344
		public enum eTmplateType
		{
			// Token: 0x0400199A RID: 6554
			TmplateType_None,
			// Token: 0x0400199B RID: 6555
			OAT_DAY_LOGIN = 10,
			// Token: 0x0400199C RID: 6556
			OAT_PLAYER_LEVEL_UP = 15,
			// Token: 0x0400199D RID: 6557
			OAT_BIND_PHONE,
			// Token: 0x0400199E RID: 6558
			OAT_MALL_DISCOUNT_FOR_NEW_SERVER = 1000,
			// Token: 0x0400199F RID: 6559
			OAI_LEVEL_FIGHTING_FOR_NEW_SERVER,
			// Token: 0x040019A0 RID: 6560
			OAI_LEVEL_SHOW_FOR_NEW_SERVER,
			// Token: 0x040019A1 RID: 6561
			OAT_DUNGEON_DROP_ACTIVITY = 1100,
			// Token: 0x040019A2 RID: 6562
			OAT_DUNGEON_EXP_ADDITION = 1200,
			// Token: 0x040019A3 RID: 6563
			OAT_PVP_PK_COIN = 1300,
			// Token: 0x040019A4 RID: 6564
			OAT_APPOINTMENT_OCCU = 1400,
			// Token: 0x040019A5 RID: 6565
			OAT_HELL_TICKET_FOR_DRAW_PRIZE = 1500,
			// Token: 0x040019A6 RID: 6566
			OAT_FATIGUE_FOR_BUFF = 1600,
			// Token: 0x040019A7 RID: 6567
			OAT_FATIGUE_FOR_TOKEN_COIN = 1700,
			// Token: 0x040019A8 RID: 6568
			OAT_FATIGUE_BURNING = 1800,
			// Token: 0x040019A9 RID: 6569
			OAT_GAMBING = 1900,
			// Token: 0x040019AA RID: 6570
			OAT_DAILY_REWARD = 2000,
			// Token: 0x040019AB RID: 6571
			OAT_MAGPIE_BRIDGE = 2100,
			// Token: 0x040019AC RID: 6572
			OAT_MONTH_CARD = 2200,
			// Token: 0x040019AD RID: 6573
			OAT_BUFF_ADDITION = 2300,
			// Token: 0x040019AE RID: 6574
			OAT_DUNGEON_DROP_RATE_ADDITION = 2400,
			// Token: 0x040019AF RID: 6575
			OAT_CHANGE_FASHION = 2500,
			// Token: 0x040019B0 RID: 6576
			OAT_CHANGE_FASHION_EXCHANGE = 2600,
			// Token: 0x040019B1 RID: 6577
			OAT_CHANGE_FASHION_WELFARE = 2700,
			// Token: 0x040019B2 RID: 6578
			OAT_DUNGEON_RANDOM_BUFF = 2800,
			// Token: 0x040019B3 RID: 6579
			OAT_DUNGEON_CLEAR_GET_REWARD = 2900,
			// Token: 0x040019B4 RID: 6580
			OAT_BUY_FASHION_TICKET = 3000,
			// Token: 0x040019B5 RID: 6581
			OAT_BUFF_PRAY = 3100,
			// Token: 0x040019B6 RID: 6582
			OAT_STRENGTHEN_TICKET_MERGE = 3200,
			// Token: 0x040019B7 RID: 6583
			OAT_CHANGE_FASHION_ACT = 3300,
			// Token: 0x040019B8 RID: 6584
			OAT_MALL_BUY_GOT = 3400,
			// Token: 0x040019B9 RID: 6585
			OAT_ARTIFACT_JAR = 3500,
			// Token: 0x040019BA RID: 6586
			OAT_JAR_DRAW_LOTTERY = 3600,
			// Token: 0x040019BB RID: 6587
			OAT_LIMIT_TIME_HELL = 3700,
			// Token: 0x040019BC RID: 6588
			OAT_PET_GIFT_PACK = 3800,
			// Token: 0x040019BD RID: 6589
			OAT_MALL_BINDINGGOLD = 3900,
			// Token: 0x040019BE RID: 6590
			OAT_BLACK_MARKET_SHOP = 4000,
			// Token: 0x040019BF RID: 6591
			OAT_RETURN_GIFT = 4100,
			// Token: 0x040019C0 RID: 6592
			OAT_ACCOUNT_SHOP = 4200,
			// Token: 0x040019C1 RID: 6593
			OAT_RETURN_REBATE = 4300,
			// Token: 0x040019C2 RID: 6594
			OAT_CHALLENGE_CHAPTER = 4400,
			// Token: 0x040019C3 RID: 6595
			OAT_RETURN_PRIVILEGE = 4500,
			// Token: 0x040019C4 RID: 6596
			OAT_WEEK_DEEP = 4600,
			// Token: 0x040019C5 RID: 6597
			OAT_BUY_PRRSENT = 4700,
			// Token: 0x040019C6 RID: 6598
			OAT_CUMULATE_LOGIN_REWARD = 4800,
			// Token: 0x040019C7 RID: 6599
			OAT_PASS_DUNGEON_REWARD = 4900,
			// Token: 0x040019C8 RID: 6600
			OAT_LIMIT_TIME_GIFT_PACK = 5000,
			// Token: 0x040019C9 RID: 6601
			OAT_HORSE_GAMBLING = 5100,
			// Token: 0x040019CA RID: 6602
			OAT_ARTIFACT_JAR_SHOW = 5200,
			// Token: 0x040019CB RID: 6603
			OAT_PROMOTE_EQUIP_STRENGTHEN_RATE = 5300,
			// Token: 0x040019CC RID: 6604
			OAT_WEEK_SIGN_ACTIVITY = 5500,
			// Token: 0x040019CD RID: 6605
			OAT_WEEK_CHALLENGE = 5600,
			// Token: 0x040019CE RID: 6606
			OAT_FLYUP_GIFT = 5900,
			// Token: 0x040019CF RID: 6607
			OAT_TEAM_COPY_SUPPORT = 6000,
			// Token: 0x040019D0 RID: 6608
			OAT_ANNIVE_CUMULATE_ONLINE = 6100,
			// Token: 0x040019D1 RID: 6609
			OAT_HALLOWEEN_PUMPKIN_HELMET = 6300,
			// Token: 0x040019D2 RID: 6610
			OAT_NEW_YEAR_2020 = 6400,
			// Token: 0x040019D3 RID: 6611
			OAT_MONEY_CONSUME_REBATE = 6500,
			// Token: 0x040019D4 RID: 6612
			OAT_CHALLENGE_HUB = 6600,
			// Token: 0x040019D5 RID: 6613
			OAT_NEW_SERVER_GIFT_DISCOUNT = 6800,
			// Token: 0x040019D6 RID: 6614
			OAT_CHALLENGE_HUB_SCORE = 7200,
			// Token: 0x040019D7 RID: 6615
			OAT_SPRING_CHALLENGE = 7300,
			// Token: 0x040019D8 RID: 6616
			OAT_SPRING_CHALLENGE_SCORE = 7400,
			// Token: 0x040019D9 RID: 6617
			OAT_WEEK_SIGN_SPRING = 7500,
			// Token: 0x040019DA RID: 6618
			OAT_ONLINE_GIFT = 7600,
			// Token: 0x040019DB RID: 6619
			OAT_PLANT_TREE = 7700,
			// Token: 0x040019DC RID: 6620
			OAT_FASHION_COMP = 7800,
			// Token: 0x040019DD RID: 6621
			OAT_GNOME_COIN_GIFT = 7900,
			// Token: 0x040019DE RID: 6622
			OAT_WHOLE_BARGAIN_DISCOUNT = 50001,
			// Token: 0x040019DF RID: 6623
			OAT_WHOLE_BARGAIN_SHOP,
			// Token: 0x040019E0 RID: 6624
			OAT_COMPLETE_PK = 50004,
			// Token: 0x040019E1 RID: 6625
			OAT_CHAMPION_GIFT,
			// Token: 0x040019E2 RID: 6626
			OAT_UPGRADE_GIFT,
			// Token: 0x040019E3 RID: 6627
			OAT_DAY_CHALLENGE,
			// Token: 0x040019E4 RID: 6628
			OAT_ACCOUNT_ONLINE,
			// Token: 0x040019E5 RID: 6629
			OAT_GIFT_RIGHT,
			// Token: 0x040019E6 RID: 6630
			OAT_ACTIVITY_SHOW = 60001,
			// Token: 0x040019E7 RID: 6631
			OAT_CUMULATIVE_GIFT
		}

		// Token: 0x02000541 RID: 1345
		public enum eCrypt
		{
			// Token: 0x040019E9 RID: 6633
			code = 1784045956
		}
	}
}
