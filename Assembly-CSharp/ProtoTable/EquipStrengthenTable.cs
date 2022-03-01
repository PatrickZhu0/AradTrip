using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000413 RID: 1043
	public class EquipStrengthenTable : IFlatbufferObject
	{
		// Token: 0x17000BD9 RID: 3033
		// (get) Token: 0x06003113 RID: 12563 RVA: 0x000AF14C File Offset: 0x000AD54C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003114 RID: 12564 RVA: 0x000AF159 File Offset: 0x000AD559
		public static EquipStrengthenTable GetRootAsEquipStrengthenTable(ByteBuffer _bb)
		{
			return EquipStrengthenTable.GetRootAsEquipStrengthenTable(_bb, new EquipStrengthenTable());
		}

		// Token: 0x06003115 RID: 12565 RVA: 0x000AF166 File Offset: 0x000AD566
		public static EquipStrengthenTable GetRootAsEquipStrengthenTable(ByteBuffer _bb, EquipStrengthenTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003116 RID: 12566 RVA: 0x000AF182 File Offset: 0x000AD582
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003117 RID: 12567 RVA: 0x000AF19C File Offset: 0x000AD59C
		public EquipStrengthenTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000BDA RID: 3034
		// (get) Token: 0x06003118 RID: 12568 RVA: 0x000AF1A8 File Offset: 0x000AD5A8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BDB RID: 3035
		// (get) Token: 0x06003119 RID: 12569 RVA: 0x000AF1F4 File Offset: 0x000AD5F4
		public int Strengthen
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600311A RID: 12570 RVA: 0x000AF240 File Offset: 0x000AD640
		public int LvArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BDC RID: 3036
		// (get) Token: 0x0600311B RID: 12571 RVA: 0x000AF28C File Offset: 0x000AD68C
		public int LvLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600311C RID: 12572 RVA: 0x000AF2BE File Offset: 0x000AD6BE
		public ArraySegment<byte>? GetLvBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000BDD RID: 3037
		// (get) Token: 0x0600311D RID: 12573 RVA: 0x000AF2CC File Offset: 0x000AD6CC
		public FlatBufferArray<int> Lv
		{
			get
			{
				if (this.LvValue == null)
				{
					this.LvValue = new FlatBufferArray<int>(new Func<int, int>(this.LvArray), this.LvLength);
				}
				return this.LvValue;
			}
		}

		// Token: 0x17000BDE RID: 3038
		// (get) Token: 0x0600311E RID: 12574 RVA: 0x000AF2FC File Offset: 0x000AD6FC
		public int WhiteGoldCost
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BDF RID: 3039
		// (get) Token: 0x0600311F RID: 12575 RVA: 0x000AF348 File Offset: 0x000AD748
		public int WhiteGoldRet
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003120 RID: 12576 RVA: 0x000AF394 File Offset: 0x000AD794
		public int WhiteCostArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BE0 RID: 3040
		// (get) Token: 0x06003121 RID: 12577 RVA: 0x000AF3E4 File Offset: 0x000AD7E4
		public int WhiteCostLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003122 RID: 12578 RVA: 0x000AF417 File Offset: 0x000AD817
		public ArraySegment<byte>? GetWhiteCostBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000BE1 RID: 3041
		// (get) Token: 0x06003123 RID: 12579 RVA: 0x000AF426 File Offset: 0x000AD826
		public FlatBufferArray<int> WhiteCost
		{
			get
			{
				if (this.WhiteCostValue == null)
				{
					this.WhiteCostValue = new FlatBufferArray<int>(new Func<int, int>(this.WhiteCostArray), this.WhiteCostLength);
				}
				return this.WhiteCostValue;
			}
		}

		// Token: 0x06003124 RID: 12580 RVA: 0x000AF458 File Offset: 0x000AD858
		public int WhiteMatRetArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BE2 RID: 3042
		// (get) Token: 0x06003125 RID: 12581 RVA: 0x000AF4A8 File Offset: 0x000AD8A8
		public int WhiteMatRetLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x000AF4DB File Offset: 0x000AD8DB
		public ArraySegment<byte>? GetWhiteMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000BE3 RID: 3043
		// (get) Token: 0x06003127 RID: 12583 RVA: 0x000AF4EA File Offset: 0x000AD8EA
		public FlatBufferArray<int> WhiteMatRet
		{
			get
			{
				if (this.WhiteMatRetValue == null)
				{
					this.WhiteMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.WhiteMatRetArray), this.WhiteMatRetLength);
				}
				return this.WhiteMatRetValue;
			}
		}

		// Token: 0x17000BE4 RID: 3044
		// (get) Token: 0x06003128 RID: 12584 RVA: 0x000AF51C File Offset: 0x000AD91C
		public int WhiteStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BE5 RID: 3045
		// (get) Token: 0x06003129 RID: 12585 RVA: 0x000AF568 File Offset: 0x000AD968
		public int WhiteStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BE6 RID: 3046
		// (get) Token: 0x0600312A RID: 12586 RVA: 0x000AF5B4 File Offset: 0x000AD9B4
		public string WhiteItemNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600312B RID: 12587 RVA: 0x000AF5F7 File Offset: 0x000AD9F7
		public ArraySegment<byte>? GetWhiteItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000BE7 RID: 3047
		// (get) Token: 0x0600312C RID: 12588 RVA: 0x000AF608 File Offset: 0x000ADA08
		public int BlueGoldCost
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BE8 RID: 3048
		// (get) Token: 0x0600312D RID: 12589 RVA: 0x000AF654 File Offset: 0x000ADA54
		public int BlueGoldRet
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x000AF6A0 File Offset: 0x000ADAA0
		public int BlueCostArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BE9 RID: 3049
		// (get) Token: 0x0600312F RID: 12591 RVA: 0x000AF6F0 File Offset: 0x000ADAF0
		public int BlueCostLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x000AF723 File Offset: 0x000ADB23
		public ArraySegment<byte>? GetBlueCostBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000BEA RID: 3050
		// (get) Token: 0x06003131 RID: 12593 RVA: 0x000AF732 File Offset: 0x000ADB32
		public FlatBufferArray<int> BlueCost
		{
			get
			{
				if (this.BlueCostValue == null)
				{
					this.BlueCostValue = new FlatBufferArray<int>(new Func<int, int>(this.BlueCostArray), this.BlueCostLength);
				}
				return this.BlueCostValue;
			}
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x000AF764 File Offset: 0x000ADB64
		public int BlueMatRetArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BEB RID: 3051
		// (get) Token: 0x06003133 RID: 12595 RVA: 0x000AF7B4 File Offset: 0x000ADBB4
		public int BlueMatRetLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x000AF7E7 File Offset: 0x000ADBE7
		public ArraySegment<byte>? GetBlueMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000BEC RID: 3052
		// (get) Token: 0x06003135 RID: 12597 RVA: 0x000AF7F6 File Offset: 0x000ADBF6
		public FlatBufferArray<int> BlueMatRet
		{
			get
			{
				if (this.BlueMatRetValue == null)
				{
					this.BlueMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.BlueMatRetArray), this.BlueMatRetLength);
				}
				return this.BlueMatRetValue;
			}
		}

		// Token: 0x17000BED RID: 3053
		// (get) Token: 0x06003136 RID: 12598 RVA: 0x000AF828 File Offset: 0x000ADC28
		public int BlueStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BEE RID: 3054
		// (get) Token: 0x06003137 RID: 12599 RVA: 0x000AF874 File Offset: 0x000ADC74
		public int BlueStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BEF RID: 3055
		// (get) Token: 0x06003138 RID: 12600 RVA: 0x000AF8C0 File Offset: 0x000ADCC0
		public string BlueItemNum
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003139 RID: 12601 RVA: 0x000AF903 File Offset: 0x000ADD03
		public ArraySegment<byte>? GetBlueItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000BF0 RID: 3056
		// (get) Token: 0x0600313A RID: 12602 RVA: 0x000AF914 File Offset: 0x000ADD14
		public int PurpleGoldCost
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BF1 RID: 3057
		// (get) Token: 0x0600313B RID: 12603 RVA: 0x000AF960 File Offset: 0x000ADD60
		public int PurpleGoldRet
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600313C RID: 12604 RVA: 0x000AF9AC File Offset: 0x000ADDAC
		public int PurpleCostArray(int j)
		{
			int num = this.__p.__offset(42);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BF2 RID: 3058
		// (get) Token: 0x0600313D RID: 12605 RVA: 0x000AF9FC File Offset: 0x000ADDFC
		public int PurpleCostLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600313E RID: 12606 RVA: 0x000AFA2F File Offset: 0x000ADE2F
		public ArraySegment<byte>? GetPurpleCostBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000BF3 RID: 3059
		// (get) Token: 0x0600313F RID: 12607 RVA: 0x000AFA3E File Offset: 0x000ADE3E
		public FlatBufferArray<int> PurpleCost
		{
			get
			{
				if (this.PurpleCostValue == null)
				{
					this.PurpleCostValue = new FlatBufferArray<int>(new Func<int, int>(this.PurpleCostArray), this.PurpleCostLength);
				}
				return this.PurpleCostValue;
			}
		}

		// Token: 0x06003140 RID: 12608 RVA: 0x000AFA70 File Offset: 0x000ADE70
		public int PurpleMatRetArray(int j)
		{
			int num = this.__p.__offset(44);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BF4 RID: 3060
		// (get) Token: 0x06003141 RID: 12609 RVA: 0x000AFAC0 File Offset: 0x000ADEC0
		public int PurpleMatRetLength
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x000AFAF3 File Offset: 0x000ADEF3
		public ArraySegment<byte>? GetPurpleMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000BF5 RID: 3061
		// (get) Token: 0x06003143 RID: 12611 RVA: 0x000AFB02 File Offset: 0x000ADF02
		public FlatBufferArray<int> PurpleMatRet
		{
			get
			{
				if (this.PurpleMatRetValue == null)
				{
					this.PurpleMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.PurpleMatRetArray), this.PurpleMatRetLength);
				}
				return this.PurpleMatRetValue;
			}
		}

		// Token: 0x17000BF6 RID: 3062
		// (get) Token: 0x06003144 RID: 12612 RVA: 0x000AFB34 File Offset: 0x000ADF34
		public int PurpleStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x06003145 RID: 12613 RVA: 0x000AFB80 File Offset: 0x000ADF80
		public int PurpleStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x06003146 RID: 12614 RVA: 0x000AFBCC File Offset: 0x000ADFCC
		public string PurpleItemNum
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003147 RID: 12615 RVA: 0x000AFC0F File Offset: 0x000AE00F
		public ArraySegment<byte>? GetPurpleItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17000BF9 RID: 3065
		// (get) Token: 0x06003148 RID: 12616 RVA: 0x000AFC20 File Offset: 0x000AE020
		public int GreenGoldCost
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000BFA RID: 3066
		// (get) Token: 0x06003149 RID: 12617 RVA: 0x000AFC6C File Offset: 0x000AE06C
		public int GreenGoldRet
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x000AFCB8 File Offset: 0x000AE0B8
		public int GreenCostArray(int j)
		{
			int num = this.__p.__offset(56);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BFB RID: 3067
		// (get) Token: 0x0600314B RID: 12619 RVA: 0x000AFD08 File Offset: 0x000AE108
		public int GreenCostLength
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600314C RID: 12620 RVA: 0x000AFD3B File Offset: 0x000AE13B
		public ArraySegment<byte>? GetGreenCostBytes()
		{
			return this.__p.__vector_as_arraysegment(56);
		}

		// Token: 0x17000BFC RID: 3068
		// (get) Token: 0x0600314D RID: 12621 RVA: 0x000AFD4A File Offset: 0x000AE14A
		public FlatBufferArray<int> GreenCost
		{
			get
			{
				if (this.GreenCostValue == null)
				{
					this.GreenCostValue = new FlatBufferArray<int>(new Func<int, int>(this.GreenCostArray), this.GreenCostLength);
				}
				return this.GreenCostValue;
			}
		}

		// Token: 0x0600314E RID: 12622 RVA: 0x000AFD7C File Offset: 0x000AE17C
		public int GreenMatRetArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000BFD RID: 3069
		// (get) Token: 0x0600314F RID: 12623 RVA: 0x000AFDCC File Offset: 0x000AE1CC
		public int GreenMatRetLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003150 RID: 12624 RVA: 0x000AFDFF File Offset: 0x000AE1FF
		public ArraySegment<byte>? GetGreenMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17000BFE RID: 3070
		// (get) Token: 0x06003151 RID: 12625 RVA: 0x000AFE0E File Offset: 0x000AE20E
		public FlatBufferArray<int> GreenMatRet
		{
			get
			{
				if (this.GreenMatRetValue == null)
				{
					this.GreenMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.GreenMatRetArray), this.GreenMatRetLength);
				}
				return this.GreenMatRetValue;
			}
		}

		// Token: 0x17000BFF RID: 3071
		// (get) Token: 0x06003152 RID: 12626 RVA: 0x000AFE40 File Offset: 0x000AE240
		public int GreenStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C00 RID: 3072
		// (get) Token: 0x06003153 RID: 12627 RVA: 0x000AFE8C File Offset: 0x000AE28C
		public int GreenStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C01 RID: 3073
		// (get) Token: 0x06003154 RID: 12628 RVA: 0x000AFED8 File Offset: 0x000AE2D8
		public string GreenItemNum
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003155 RID: 12629 RVA: 0x000AFF1B File Offset: 0x000AE31B
		public ArraySegment<byte>? GetGreenItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17000C02 RID: 3074
		// (get) Token: 0x06003156 RID: 12630 RVA: 0x000AFF2C File Offset: 0x000AE32C
		public int PinkGoldCost
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C03 RID: 3075
		// (get) Token: 0x06003157 RID: 12631 RVA: 0x000AFF78 File Offset: 0x000AE378
		public int PinkGoldRet
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003158 RID: 12632 RVA: 0x000AFFC4 File Offset: 0x000AE3C4
		public int PinkCostArray(int j)
		{
			int num = this.__p.__offset(70);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C04 RID: 3076
		// (get) Token: 0x06003159 RID: 12633 RVA: 0x000B0014 File Offset: 0x000AE414
		public int PinkCostLength
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600315A RID: 12634 RVA: 0x000B0047 File Offset: 0x000AE447
		public ArraySegment<byte>? GetPinkCostBytes()
		{
			return this.__p.__vector_as_arraysegment(70);
		}

		// Token: 0x17000C05 RID: 3077
		// (get) Token: 0x0600315B RID: 12635 RVA: 0x000B0056 File Offset: 0x000AE456
		public FlatBufferArray<int> PinkCost
		{
			get
			{
				if (this.PinkCostValue == null)
				{
					this.PinkCostValue = new FlatBufferArray<int>(new Func<int, int>(this.PinkCostArray), this.PinkCostLength);
				}
				return this.PinkCostValue;
			}
		}

		// Token: 0x0600315C RID: 12636 RVA: 0x000B0088 File Offset: 0x000AE488
		public int PinkMatRetArray(int j)
		{
			int num = this.__p.__offset(72);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C06 RID: 3078
		// (get) Token: 0x0600315D RID: 12637 RVA: 0x000B00D8 File Offset: 0x000AE4D8
		public int PinkMatRetLength
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600315E RID: 12638 RVA: 0x000B010B File Offset: 0x000AE50B
		public ArraySegment<byte>? GetPinkMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x17000C07 RID: 3079
		// (get) Token: 0x0600315F RID: 12639 RVA: 0x000B011A File Offset: 0x000AE51A
		public FlatBufferArray<int> PinkMatRet
		{
			get
			{
				if (this.PinkMatRetValue == null)
				{
					this.PinkMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.PinkMatRetArray), this.PinkMatRetLength);
				}
				return this.PinkMatRetValue;
			}
		}

		// Token: 0x17000C08 RID: 3080
		// (get) Token: 0x06003160 RID: 12640 RVA: 0x000B014C File Offset: 0x000AE54C
		public int PinkStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C09 RID: 3081
		// (get) Token: 0x06003161 RID: 12641 RVA: 0x000B0198 File Offset: 0x000AE598
		public int PinkStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(76);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C0A RID: 3082
		// (get) Token: 0x06003162 RID: 12642 RVA: 0x000B01E4 File Offset: 0x000AE5E4
		public string PinkItemNum
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003163 RID: 12643 RVA: 0x000B0227 File Offset: 0x000AE627
		public ArraySegment<byte>? GetPinkItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(78);
		}

		// Token: 0x17000C0B RID: 3083
		// (get) Token: 0x06003164 RID: 12644 RVA: 0x000B0238 File Offset: 0x000AE638
		public int YellowGoldCost
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C0C RID: 3084
		// (get) Token: 0x06003165 RID: 12645 RVA: 0x000B0284 File Offset: 0x000AE684
		public int YellowGoldRet
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003166 RID: 12646 RVA: 0x000B02D0 File Offset: 0x000AE6D0
		public int YellowCostArray(int j)
		{
			int num = this.__p.__offset(84);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C0D RID: 3085
		// (get) Token: 0x06003167 RID: 12647 RVA: 0x000B0320 File Offset: 0x000AE720
		public int YellowCostLength
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003168 RID: 12648 RVA: 0x000B0353 File Offset: 0x000AE753
		public ArraySegment<byte>? GetYellowCostBytes()
		{
			return this.__p.__vector_as_arraysegment(84);
		}

		// Token: 0x17000C0E RID: 3086
		// (get) Token: 0x06003169 RID: 12649 RVA: 0x000B0362 File Offset: 0x000AE762
		public FlatBufferArray<int> YellowCost
		{
			get
			{
				if (this.YellowCostValue == null)
				{
					this.YellowCostValue = new FlatBufferArray<int>(new Func<int, int>(this.YellowCostArray), this.YellowCostLength);
				}
				return this.YellowCostValue;
			}
		}

		// Token: 0x0600316A RID: 12650 RVA: 0x000B0394 File Offset: 0x000AE794
		public int YellowMatRetArray(int j)
		{
			int num = this.__p.__offset(86);
			return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C0F RID: 3087
		// (get) Token: 0x0600316B RID: 12651 RVA: 0x000B03E4 File Offset: 0x000AE7E4
		public int YellowMatRetLength
		{
			get
			{
				int num = this.__p.__offset(86);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600316C RID: 12652 RVA: 0x000B0417 File Offset: 0x000AE817
		public ArraySegment<byte>? GetYellowMatRetBytes()
		{
			return this.__p.__vector_as_arraysegment(86);
		}

		// Token: 0x17000C10 RID: 3088
		// (get) Token: 0x0600316D RID: 12653 RVA: 0x000B0426 File Offset: 0x000AE826
		public FlatBufferArray<int> YellowMatRet
		{
			get
			{
				if (this.YellowMatRetValue == null)
				{
					this.YellowMatRetValue = new FlatBufferArray<int>(new Func<int, int>(this.YellowMatRetArray), this.YellowMatRetLength);
				}
				return this.YellowMatRetValue;
			}
		}

		// Token: 0x17000C11 RID: 3089
		// (get) Token: 0x0600316E RID: 12654 RVA: 0x000B0458 File Offset: 0x000AE858
		public int YellowStrToTenRate
		{
			get
			{
				int num = this.__p.__offset(88);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C12 RID: 3090
		// (get) Token: 0x0600316F RID: 12655 RVA: 0x000B04A4 File Offset: 0x000AE8A4
		public int YellowStrToTenNum
		{
			get
			{
				int num = this.__p.__offset(90);
				return (num == 0) ? 0 : (-1147709044 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C13 RID: 3091
		// (get) Token: 0x06003170 RID: 12656 RVA: 0x000B04F0 File Offset: 0x000AE8F0
		public string YellowItemNum
		{
			get
			{
				int num = this.__p.__offset(92);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003171 RID: 12657 RVA: 0x000B0533 File Offset: 0x000AE933
		public ArraySegment<byte>? GetYellowItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(92);
		}

		// Token: 0x06003172 RID: 12658 RVA: 0x000B0544 File Offset: 0x000AE944
		public static Offset<EquipStrengthenTable> CreateEquipStrengthenTable(FlatBufferBuilder builder, int ID = 0, int Strengthen = 0, VectorOffset LvOffset = default(VectorOffset), int WhiteGoldCost = 0, int WhiteGoldRet = 0, VectorOffset WhiteCostOffset = default(VectorOffset), VectorOffset WhiteMatRetOffset = default(VectorOffset), int WhiteStrToTenRate = 0, int WhiteStrToTenNum = 0, StringOffset WhiteItemNumOffset = default(StringOffset), int BlueGoldCost = 0, int BlueGoldRet = 0, VectorOffset BlueCostOffset = default(VectorOffset), VectorOffset BlueMatRetOffset = default(VectorOffset), int BlueStrToTenRate = 0, int BlueStrToTenNum = 0, StringOffset BlueItemNumOffset = default(StringOffset), int PurpleGoldCost = 0, int PurpleGoldRet = 0, VectorOffset PurpleCostOffset = default(VectorOffset), VectorOffset PurpleMatRetOffset = default(VectorOffset), int PurpleStrToTenRate = 0, int PurpleStrToTenNum = 0, StringOffset PurpleItemNumOffset = default(StringOffset), int GreenGoldCost = 0, int GreenGoldRet = 0, VectorOffset GreenCostOffset = default(VectorOffset), VectorOffset GreenMatRetOffset = default(VectorOffset), int GreenStrToTenRate = 0, int GreenStrToTenNum = 0, StringOffset GreenItemNumOffset = default(StringOffset), int PinkGoldCost = 0, int PinkGoldRet = 0, VectorOffset PinkCostOffset = default(VectorOffset), VectorOffset PinkMatRetOffset = default(VectorOffset), int PinkStrToTenRate = 0, int PinkStrToTenNum = 0, StringOffset PinkItemNumOffset = default(StringOffset), int YellowGoldCost = 0, int YellowGoldRet = 0, VectorOffset YellowCostOffset = default(VectorOffset), VectorOffset YellowMatRetOffset = default(VectorOffset), int YellowStrToTenRate = 0, int YellowStrToTenNum = 0, StringOffset YellowItemNumOffset = default(StringOffset))
		{
			builder.StartObject(45);
			EquipStrengthenTable.AddYellowItemNum(builder, YellowItemNumOffset);
			EquipStrengthenTable.AddYellowStrToTenNum(builder, YellowStrToTenNum);
			EquipStrengthenTable.AddYellowStrToTenRate(builder, YellowStrToTenRate);
			EquipStrengthenTable.AddYellowMatRet(builder, YellowMatRetOffset);
			EquipStrengthenTable.AddYellowCost(builder, YellowCostOffset);
			EquipStrengthenTable.AddYellowGoldRet(builder, YellowGoldRet);
			EquipStrengthenTable.AddYellowGoldCost(builder, YellowGoldCost);
			EquipStrengthenTable.AddPinkItemNum(builder, PinkItemNumOffset);
			EquipStrengthenTable.AddPinkStrToTenNum(builder, PinkStrToTenNum);
			EquipStrengthenTable.AddPinkStrToTenRate(builder, PinkStrToTenRate);
			EquipStrengthenTable.AddPinkMatRet(builder, PinkMatRetOffset);
			EquipStrengthenTable.AddPinkCost(builder, PinkCostOffset);
			EquipStrengthenTable.AddPinkGoldRet(builder, PinkGoldRet);
			EquipStrengthenTable.AddPinkGoldCost(builder, PinkGoldCost);
			EquipStrengthenTable.AddGreenItemNum(builder, GreenItemNumOffset);
			EquipStrengthenTable.AddGreenStrToTenNum(builder, GreenStrToTenNum);
			EquipStrengthenTable.AddGreenStrToTenRate(builder, GreenStrToTenRate);
			EquipStrengthenTable.AddGreenMatRet(builder, GreenMatRetOffset);
			EquipStrengthenTable.AddGreenCost(builder, GreenCostOffset);
			EquipStrengthenTable.AddGreenGoldRet(builder, GreenGoldRet);
			EquipStrengthenTable.AddGreenGoldCost(builder, GreenGoldCost);
			EquipStrengthenTable.AddPurpleItemNum(builder, PurpleItemNumOffset);
			EquipStrengthenTable.AddPurpleStrToTenNum(builder, PurpleStrToTenNum);
			EquipStrengthenTable.AddPurpleStrToTenRate(builder, PurpleStrToTenRate);
			EquipStrengthenTable.AddPurpleMatRet(builder, PurpleMatRetOffset);
			EquipStrengthenTable.AddPurpleCost(builder, PurpleCostOffset);
			EquipStrengthenTable.AddPurpleGoldRet(builder, PurpleGoldRet);
			EquipStrengthenTable.AddPurpleGoldCost(builder, PurpleGoldCost);
			EquipStrengthenTable.AddBlueItemNum(builder, BlueItemNumOffset);
			EquipStrengthenTable.AddBlueStrToTenNum(builder, BlueStrToTenNum);
			EquipStrengthenTable.AddBlueStrToTenRate(builder, BlueStrToTenRate);
			EquipStrengthenTable.AddBlueMatRet(builder, BlueMatRetOffset);
			EquipStrengthenTable.AddBlueCost(builder, BlueCostOffset);
			EquipStrengthenTable.AddBlueGoldRet(builder, BlueGoldRet);
			EquipStrengthenTable.AddBlueGoldCost(builder, BlueGoldCost);
			EquipStrengthenTable.AddWhiteItemNum(builder, WhiteItemNumOffset);
			EquipStrengthenTable.AddWhiteStrToTenNum(builder, WhiteStrToTenNum);
			EquipStrengthenTable.AddWhiteStrToTenRate(builder, WhiteStrToTenRate);
			EquipStrengthenTable.AddWhiteMatRet(builder, WhiteMatRetOffset);
			EquipStrengthenTable.AddWhiteCost(builder, WhiteCostOffset);
			EquipStrengthenTable.AddWhiteGoldRet(builder, WhiteGoldRet);
			EquipStrengthenTable.AddWhiteGoldCost(builder, WhiteGoldCost);
			EquipStrengthenTable.AddLv(builder, LvOffset);
			EquipStrengthenTable.AddStrengthen(builder, Strengthen);
			EquipStrengthenTable.AddID(builder, ID);
			return EquipStrengthenTable.EndEquipStrengthenTable(builder);
		}

		// Token: 0x06003173 RID: 12659 RVA: 0x000B06C4 File Offset: 0x000AEAC4
		public static void StartEquipStrengthenTable(FlatBufferBuilder builder)
		{
			builder.StartObject(45);
		}

		// Token: 0x06003174 RID: 12660 RVA: 0x000B06CE File Offset: 0x000AEACE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003175 RID: 12661 RVA: 0x000B06D9 File Offset: 0x000AEAD9
		public static void AddStrengthen(FlatBufferBuilder builder, int Strengthen)
		{
			builder.AddInt(1, Strengthen, 0);
		}

		// Token: 0x06003176 RID: 12662 RVA: 0x000B06E4 File Offset: 0x000AEAE4
		public static void AddLv(FlatBufferBuilder builder, VectorOffset LvOffset)
		{
			builder.AddOffset(2, LvOffset.Value, 0);
		}

		// Token: 0x06003177 RID: 12663 RVA: 0x000B06F8 File Offset: 0x000AEAF8
		public static VectorOffset CreateLvVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x000B0735 File Offset: 0x000AEB35
		public static void StartLvVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x000B0740 File Offset: 0x000AEB40
		public static void AddWhiteGoldCost(FlatBufferBuilder builder, int WhiteGoldCost)
		{
			builder.AddInt(3, WhiteGoldCost, 0);
		}

		// Token: 0x0600317A RID: 12666 RVA: 0x000B074B File Offset: 0x000AEB4B
		public static void AddWhiteGoldRet(FlatBufferBuilder builder, int WhiteGoldRet)
		{
			builder.AddInt(4, WhiteGoldRet, 0);
		}

		// Token: 0x0600317B RID: 12667 RVA: 0x000B0756 File Offset: 0x000AEB56
		public static void AddWhiteCost(FlatBufferBuilder builder, VectorOffset WhiteCostOffset)
		{
			builder.AddOffset(5, WhiteCostOffset.Value, 0);
		}

		// Token: 0x0600317C RID: 12668 RVA: 0x000B0768 File Offset: 0x000AEB68
		public static VectorOffset CreateWhiteCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600317D RID: 12669 RVA: 0x000B07A5 File Offset: 0x000AEBA5
		public static void StartWhiteCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600317E RID: 12670 RVA: 0x000B07B0 File Offset: 0x000AEBB0
		public static void AddWhiteMatRet(FlatBufferBuilder builder, VectorOffset WhiteMatRetOffset)
		{
			builder.AddOffset(6, WhiteMatRetOffset.Value, 0);
		}

		// Token: 0x0600317F RID: 12671 RVA: 0x000B07C4 File Offset: 0x000AEBC4
		public static VectorOffset CreateWhiteMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x000B0801 File Offset: 0x000AEC01
		public static void StartWhiteMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003181 RID: 12673 RVA: 0x000B080C File Offset: 0x000AEC0C
		public static void AddWhiteStrToTenRate(FlatBufferBuilder builder, int WhiteStrToTenRate)
		{
			builder.AddInt(7, WhiteStrToTenRate, 0);
		}

		// Token: 0x06003182 RID: 12674 RVA: 0x000B0817 File Offset: 0x000AEC17
		public static void AddWhiteStrToTenNum(FlatBufferBuilder builder, int WhiteStrToTenNum)
		{
			builder.AddInt(8, WhiteStrToTenNum, 0);
		}

		// Token: 0x06003183 RID: 12675 RVA: 0x000B0822 File Offset: 0x000AEC22
		public static void AddWhiteItemNum(FlatBufferBuilder builder, StringOffset WhiteItemNumOffset)
		{
			builder.AddOffset(9, WhiteItemNumOffset.Value, 0);
		}

		// Token: 0x06003184 RID: 12676 RVA: 0x000B0834 File Offset: 0x000AEC34
		public static void AddBlueGoldCost(FlatBufferBuilder builder, int BlueGoldCost)
		{
			builder.AddInt(10, BlueGoldCost, 0);
		}

		// Token: 0x06003185 RID: 12677 RVA: 0x000B0840 File Offset: 0x000AEC40
		public static void AddBlueGoldRet(FlatBufferBuilder builder, int BlueGoldRet)
		{
			builder.AddInt(11, BlueGoldRet, 0);
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000B084C File Offset: 0x000AEC4C
		public static void AddBlueCost(FlatBufferBuilder builder, VectorOffset BlueCostOffset)
		{
			builder.AddOffset(12, BlueCostOffset.Value, 0);
		}

		// Token: 0x06003187 RID: 12679 RVA: 0x000B0860 File Offset: 0x000AEC60
		public static VectorOffset CreateBlueCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003188 RID: 12680 RVA: 0x000B089D File Offset: 0x000AEC9D
		public static void StartBlueCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003189 RID: 12681 RVA: 0x000B08A8 File Offset: 0x000AECA8
		public static void AddBlueMatRet(FlatBufferBuilder builder, VectorOffset BlueMatRetOffset)
		{
			builder.AddOffset(13, BlueMatRetOffset.Value, 0);
		}

		// Token: 0x0600318A RID: 12682 RVA: 0x000B08BC File Offset: 0x000AECBC
		public static VectorOffset CreateBlueMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600318B RID: 12683 RVA: 0x000B08F9 File Offset: 0x000AECF9
		public static void StartBlueMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x000B0904 File Offset: 0x000AED04
		public static void AddBlueStrToTenRate(FlatBufferBuilder builder, int BlueStrToTenRate)
		{
			builder.AddInt(14, BlueStrToTenRate, 0);
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x000B0910 File Offset: 0x000AED10
		public static void AddBlueStrToTenNum(FlatBufferBuilder builder, int BlueStrToTenNum)
		{
			builder.AddInt(15, BlueStrToTenNum, 0);
		}

		// Token: 0x0600318E RID: 12686 RVA: 0x000B091C File Offset: 0x000AED1C
		public static void AddBlueItemNum(FlatBufferBuilder builder, StringOffset BlueItemNumOffset)
		{
			builder.AddOffset(16, BlueItemNumOffset.Value, 0);
		}

		// Token: 0x0600318F RID: 12687 RVA: 0x000B092E File Offset: 0x000AED2E
		public static void AddPurpleGoldCost(FlatBufferBuilder builder, int PurpleGoldCost)
		{
			builder.AddInt(17, PurpleGoldCost, 0);
		}

		// Token: 0x06003190 RID: 12688 RVA: 0x000B093A File Offset: 0x000AED3A
		public static void AddPurpleGoldRet(FlatBufferBuilder builder, int PurpleGoldRet)
		{
			builder.AddInt(18, PurpleGoldRet, 0);
		}

		// Token: 0x06003191 RID: 12689 RVA: 0x000B0946 File Offset: 0x000AED46
		public static void AddPurpleCost(FlatBufferBuilder builder, VectorOffset PurpleCostOffset)
		{
			builder.AddOffset(19, PurpleCostOffset.Value, 0);
		}

		// Token: 0x06003192 RID: 12690 RVA: 0x000B0958 File Offset: 0x000AED58
		public static VectorOffset CreatePurpleCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003193 RID: 12691 RVA: 0x000B0995 File Offset: 0x000AED95
		public static void StartPurpleCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003194 RID: 12692 RVA: 0x000B09A0 File Offset: 0x000AEDA0
		public static void AddPurpleMatRet(FlatBufferBuilder builder, VectorOffset PurpleMatRetOffset)
		{
			builder.AddOffset(20, PurpleMatRetOffset.Value, 0);
		}

		// Token: 0x06003195 RID: 12693 RVA: 0x000B09B4 File Offset: 0x000AEDB4
		public static VectorOffset CreatePurpleMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003196 RID: 12694 RVA: 0x000B09F1 File Offset: 0x000AEDF1
		public static void StartPurpleMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003197 RID: 12695 RVA: 0x000B09FC File Offset: 0x000AEDFC
		public static void AddPurpleStrToTenRate(FlatBufferBuilder builder, int PurpleStrToTenRate)
		{
			builder.AddInt(21, PurpleStrToTenRate, 0);
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x000B0A08 File Offset: 0x000AEE08
		public static void AddPurpleStrToTenNum(FlatBufferBuilder builder, int PurpleStrToTenNum)
		{
			builder.AddInt(22, PurpleStrToTenNum, 0);
		}

		// Token: 0x06003199 RID: 12697 RVA: 0x000B0A14 File Offset: 0x000AEE14
		public static void AddPurpleItemNum(FlatBufferBuilder builder, StringOffset PurpleItemNumOffset)
		{
			builder.AddOffset(23, PurpleItemNumOffset.Value, 0);
		}

		// Token: 0x0600319A RID: 12698 RVA: 0x000B0A26 File Offset: 0x000AEE26
		public static void AddGreenGoldCost(FlatBufferBuilder builder, int GreenGoldCost)
		{
			builder.AddInt(24, GreenGoldCost, 0);
		}

		// Token: 0x0600319B RID: 12699 RVA: 0x000B0A32 File Offset: 0x000AEE32
		public static void AddGreenGoldRet(FlatBufferBuilder builder, int GreenGoldRet)
		{
			builder.AddInt(25, GreenGoldRet, 0);
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x000B0A3E File Offset: 0x000AEE3E
		public static void AddGreenCost(FlatBufferBuilder builder, VectorOffset GreenCostOffset)
		{
			builder.AddOffset(26, GreenCostOffset.Value, 0);
		}

		// Token: 0x0600319D RID: 12701 RVA: 0x000B0A50 File Offset: 0x000AEE50
		public static VectorOffset CreateGreenCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600319E RID: 12702 RVA: 0x000B0A8D File Offset: 0x000AEE8D
		public static void StartGreenCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600319F RID: 12703 RVA: 0x000B0A98 File Offset: 0x000AEE98
		public static void AddGreenMatRet(FlatBufferBuilder builder, VectorOffset GreenMatRetOffset)
		{
			builder.AddOffset(27, GreenMatRetOffset.Value, 0);
		}

		// Token: 0x060031A0 RID: 12704 RVA: 0x000B0AAC File Offset: 0x000AEEAC
		public static VectorOffset CreateGreenMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031A1 RID: 12705 RVA: 0x000B0AE9 File Offset: 0x000AEEE9
		public static void StartGreenMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031A2 RID: 12706 RVA: 0x000B0AF4 File Offset: 0x000AEEF4
		public static void AddGreenStrToTenRate(FlatBufferBuilder builder, int GreenStrToTenRate)
		{
			builder.AddInt(28, GreenStrToTenRate, 0);
		}

		// Token: 0x060031A3 RID: 12707 RVA: 0x000B0B00 File Offset: 0x000AEF00
		public static void AddGreenStrToTenNum(FlatBufferBuilder builder, int GreenStrToTenNum)
		{
			builder.AddInt(29, GreenStrToTenNum, 0);
		}

		// Token: 0x060031A4 RID: 12708 RVA: 0x000B0B0C File Offset: 0x000AEF0C
		public static void AddGreenItemNum(FlatBufferBuilder builder, StringOffset GreenItemNumOffset)
		{
			builder.AddOffset(30, GreenItemNumOffset.Value, 0);
		}

		// Token: 0x060031A5 RID: 12709 RVA: 0x000B0B1E File Offset: 0x000AEF1E
		public static void AddPinkGoldCost(FlatBufferBuilder builder, int PinkGoldCost)
		{
			builder.AddInt(31, PinkGoldCost, 0);
		}

		// Token: 0x060031A6 RID: 12710 RVA: 0x000B0B2A File Offset: 0x000AEF2A
		public static void AddPinkGoldRet(FlatBufferBuilder builder, int PinkGoldRet)
		{
			builder.AddInt(32, PinkGoldRet, 0);
		}

		// Token: 0x060031A7 RID: 12711 RVA: 0x000B0B36 File Offset: 0x000AEF36
		public static void AddPinkCost(FlatBufferBuilder builder, VectorOffset PinkCostOffset)
		{
			builder.AddOffset(33, PinkCostOffset.Value, 0);
		}

		// Token: 0x060031A8 RID: 12712 RVA: 0x000B0B48 File Offset: 0x000AEF48
		public static VectorOffset CreatePinkCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031A9 RID: 12713 RVA: 0x000B0B85 File Offset: 0x000AEF85
		public static void StartPinkCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031AA RID: 12714 RVA: 0x000B0B90 File Offset: 0x000AEF90
		public static void AddPinkMatRet(FlatBufferBuilder builder, VectorOffset PinkMatRetOffset)
		{
			builder.AddOffset(34, PinkMatRetOffset.Value, 0);
		}

		// Token: 0x060031AB RID: 12715 RVA: 0x000B0BA4 File Offset: 0x000AEFA4
		public static VectorOffset CreatePinkMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031AC RID: 12716 RVA: 0x000B0BE1 File Offset: 0x000AEFE1
		public static void StartPinkMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031AD RID: 12717 RVA: 0x000B0BEC File Offset: 0x000AEFEC
		public static void AddPinkStrToTenRate(FlatBufferBuilder builder, int PinkStrToTenRate)
		{
			builder.AddInt(35, PinkStrToTenRate, 0);
		}

		// Token: 0x060031AE RID: 12718 RVA: 0x000B0BF8 File Offset: 0x000AEFF8
		public static void AddPinkStrToTenNum(FlatBufferBuilder builder, int PinkStrToTenNum)
		{
			builder.AddInt(36, PinkStrToTenNum, 0);
		}

		// Token: 0x060031AF RID: 12719 RVA: 0x000B0C04 File Offset: 0x000AF004
		public static void AddPinkItemNum(FlatBufferBuilder builder, StringOffset PinkItemNumOffset)
		{
			builder.AddOffset(37, PinkItemNumOffset.Value, 0);
		}

		// Token: 0x060031B0 RID: 12720 RVA: 0x000B0C16 File Offset: 0x000AF016
		public static void AddYellowGoldCost(FlatBufferBuilder builder, int YellowGoldCost)
		{
			builder.AddInt(38, YellowGoldCost, 0);
		}

		// Token: 0x060031B1 RID: 12721 RVA: 0x000B0C22 File Offset: 0x000AF022
		public static void AddYellowGoldRet(FlatBufferBuilder builder, int YellowGoldRet)
		{
			builder.AddInt(39, YellowGoldRet, 0);
		}

		// Token: 0x060031B2 RID: 12722 RVA: 0x000B0C2E File Offset: 0x000AF02E
		public static void AddYellowCost(FlatBufferBuilder builder, VectorOffset YellowCostOffset)
		{
			builder.AddOffset(40, YellowCostOffset.Value, 0);
		}

		// Token: 0x060031B3 RID: 12723 RVA: 0x000B0C40 File Offset: 0x000AF040
		public static VectorOffset CreateYellowCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031B4 RID: 12724 RVA: 0x000B0C7D File Offset: 0x000AF07D
		public static void StartYellowCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031B5 RID: 12725 RVA: 0x000B0C88 File Offset: 0x000AF088
		public static void AddYellowMatRet(FlatBufferBuilder builder, VectorOffset YellowMatRetOffset)
		{
			builder.AddOffset(41, YellowMatRetOffset.Value, 0);
		}

		// Token: 0x060031B6 RID: 12726 RVA: 0x000B0C9C File Offset: 0x000AF09C
		public static VectorOffset CreateYellowMatRetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031B7 RID: 12727 RVA: 0x000B0CD9 File Offset: 0x000AF0D9
		public static void StartYellowMatRetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031B8 RID: 12728 RVA: 0x000B0CE4 File Offset: 0x000AF0E4
		public static void AddYellowStrToTenRate(FlatBufferBuilder builder, int YellowStrToTenRate)
		{
			builder.AddInt(42, YellowStrToTenRate, 0);
		}

		// Token: 0x060031B9 RID: 12729 RVA: 0x000B0CF0 File Offset: 0x000AF0F0
		public static void AddYellowStrToTenNum(FlatBufferBuilder builder, int YellowStrToTenNum)
		{
			builder.AddInt(43, YellowStrToTenNum, 0);
		}

		// Token: 0x060031BA RID: 12730 RVA: 0x000B0CFC File Offset: 0x000AF0FC
		public static void AddYellowItemNum(FlatBufferBuilder builder, StringOffset YellowItemNumOffset)
		{
			builder.AddOffset(44, YellowItemNumOffset.Value, 0);
		}

		// Token: 0x060031BB RID: 12731 RVA: 0x000B0D10 File Offset: 0x000AF110
		public static Offset<EquipStrengthenTable> EndEquipStrengthenTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipStrengthenTable>(value);
		}

		// Token: 0x060031BC RID: 12732 RVA: 0x000B0D2A File Offset: 0x000AF12A
		public static void FinishEquipStrengthenTableBuffer(FlatBufferBuilder builder, Offset<EquipStrengthenTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001459 RID: 5209
		private Table __p = new Table();

		// Token: 0x0400145A RID: 5210
		private FlatBufferArray<int> LvValue;

		// Token: 0x0400145B RID: 5211
		private FlatBufferArray<int> WhiteCostValue;

		// Token: 0x0400145C RID: 5212
		private FlatBufferArray<int> WhiteMatRetValue;

		// Token: 0x0400145D RID: 5213
		private FlatBufferArray<int> BlueCostValue;

		// Token: 0x0400145E RID: 5214
		private FlatBufferArray<int> BlueMatRetValue;

		// Token: 0x0400145F RID: 5215
		private FlatBufferArray<int> PurpleCostValue;

		// Token: 0x04001460 RID: 5216
		private FlatBufferArray<int> PurpleMatRetValue;

		// Token: 0x04001461 RID: 5217
		private FlatBufferArray<int> GreenCostValue;

		// Token: 0x04001462 RID: 5218
		private FlatBufferArray<int> GreenMatRetValue;

		// Token: 0x04001463 RID: 5219
		private FlatBufferArray<int> PinkCostValue;

		// Token: 0x04001464 RID: 5220
		private FlatBufferArray<int> PinkMatRetValue;

		// Token: 0x04001465 RID: 5221
		private FlatBufferArray<int> YellowCostValue;

		// Token: 0x04001466 RID: 5222
		private FlatBufferArray<int> YellowMatRetValue;

		// Token: 0x02000414 RID: 1044
		public enum eCrypt
		{
			// Token: 0x04001468 RID: 5224
			code = -1147709044
		}
	}
}
