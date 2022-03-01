using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200032A RID: 810
	public class ChiJiShopTable : IFlatbufferObject
	{
		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06002050 RID: 8272 RVA: 0x00086048 File Offset: 0x00084448
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002051 RID: 8273 RVA: 0x00086055 File Offset: 0x00084455
		public static ChiJiShopTable GetRootAsChiJiShopTable(ByteBuffer _bb)
		{
			return ChiJiShopTable.GetRootAsChiJiShopTable(_bb, new ChiJiShopTable());
		}

		// Token: 0x06002052 RID: 8274 RVA: 0x00086062 File Offset: 0x00084462
		public static ChiJiShopTable GetRootAsChiJiShopTable(ByteBuffer _bb, ChiJiShopTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002053 RID: 8275 RVA: 0x0008607E File Offset: 0x0008447E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002054 RID: 8276 RVA: 0x00086098 File Offset: 0x00084498
		public ChiJiShopTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06002055 RID: 8277 RVA: 0x000860A4 File Offset: 0x000844A4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06002056 RID: 8278 RVA: 0x000860F0 File Offset: 0x000844F0
		public string ShopName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002057 RID: 8279 RVA: 0x00086132 File Offset: 0x00084532
		public ArraySegment<byte>? GetShopNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06002058 RID: 8280 RVA: 0x00086140 File Offset: 0x00084540
		public string ShopNamePath
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002059 RID: 8281 RVA: 0x00086182 File Offset: 0x00084582
		public ArraySegment<byte>? GetShopNamePathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x0600205A RID: 8282 RVA: 0x00086190 File Offset: 0x00084590
		public string ShopMallIcon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600205B RID: 8283 RVA: 0x000861D3 File Offset: 0x000845D3
		public ArraySegment<byte>? GetShopMallIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x0600205C RID: 8284 RVA: 0x000861E4 File Offset: 0x000845E4
		public string ShopSimpleName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600205D RID: 8285 RVA: 0x00086227 File Offset: 0x00084627
		public ArraySegment<byte>? GetShopSimpleNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x0600205E RID: 8286 RVA: 0x00086238 File Offset: 0x00084638
		public string Link
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600205F RID: 8287 RVA: 0x0008627B File Offset: 0x0008467B
		public ArraySegment<byte>? GetLinkBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06002060 RID: 8288 RVA: 0x0008628C File Offset: 0x0008468C
		public ChiJiShopTable.eShopKind ShopKind
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ChiJiShopTable.eShopKind)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x06002061 RID: 8289 RVA: 0x000862D0 File Offset: 0x000846D0
		public int HelpID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x06002062 RID: 8290 RVA: 0x0008631C File Offset: 0x0008471C
		public int Param1
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x06002063 RID: 8291 RVA: 0x00086368 File Offset: 0x00084768
		public int IsGuildShop
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002064 RID: 8292 RVA: 0x000863B4 File Offset: 0x000847B4
		public int ChildrenArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06002065 RID: 8293 RVA: 0x00086404 File Offset: 0x00084804
		public int ChildrenLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002066 RID: 8294 RVA: 0x00086437 File Offset: 0x00084837
		public ArraySegment<byte>? GetChildrenBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x06002067 RID: 8295 RVA: 0x00086446 File Offset: 0x00084846
		public FlatBufferArray<int> Children
		{
			get
			{
				if (this.ChildrenValue == null)
				{
					this.ChildrenValue = new FlatBufferArray<int>(new Func<int, int>(this.ChildrenArray), this.ChildrenLength);
				}
				return this.ChildrenValue;
			}
		}

		// Token: 0x06002068 RID: 8296 RVA: 0x00086478 File Offset: 0x00084878
		public ChiJiShopTable.eFilter FilterArray(int j)
		{
			int num = this.__p.__offset(26);
			return (ChiJiShopTable.eFilter)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06002069 RID: 8297 RVA: 0x000864C0 File Offset: 0x000848C0
		public int FilterLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600206A RID: 8298 RVA: 0x000864F3 File Offset: 0x000848F3
		public ArraySegment<byte>? GetFilterBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x0600206B RID: 8299 RVA: 0x00086502 File Offset: 0x00084902
		public FlatBufferArray<ChiJiShopTable.eFilter> Filter
		{
			get
			{
				if (this.FilterValue == null)
				{
					this.FilterValue = new FlatBufferArray<ChiJiShopTable.eFilter>(new Func<int, ChiJiShopTable.eFilter>(this.FilterArray), this.FilterLength);
				}
				return this.FilterValue;
			}
		}

		// Token: 0x0600206C RID: 8300 RVA: 0x00086534 File Offset: 0x00084934
		public int Filter2Array(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x0600206D RID: 8301 RVA: 0x00086584 File Offset: 0x00084984
		public int Filter2Length
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600206E RID: 8302 RVA: 0x000865B7 File Offset: 0x000849B7
		public ArraySegment<byte>? GetFilter2Bytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x0600206F RID: 8303 RVA: 0x000865C6 File Offset: 0x000849C6
		public FlatBufferArray<int> Filter2
		{
			get
			{
				if (this.Filter2Value == null)
				{
					this.Filter2Value = new FlatBufferArray<int>(new Func<int, int>(this.Filter2Array), this.Filter2Length);
				}
				return this.Filter2Value;
			}
		}

		// Token: 0x06002070 RID: 8304 RVA: 0x000865F8 File Offset: 0x000849F8
		public int HideFilterItemArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06002071 RID: 8305 RVA: 0x00086648 File Offset: 0x00084A48
		public int HideFilterItemLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002072 RID: 8306 RVA: 0x0008667B File Offset: 0x00084A7B
		public ArraySegment<byte>? GetHideFilterItemBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06002073 RID: 8307 RVA: 0x0008668A File Offset: 0x00084A8A
		public FlatBufferArray<int> HideFilterItem
		{
			get
			{
				if (this.HideFilterItemValue == null)
				{
					this.HideFilterItemValue = new FlatBufferArray<int>(new Func<int, int>(this.HideFilterItemArray), this.HideFilterItemLength);
				}
				return this.HideFilterItemValue;
			}
		}

		// Token: 0x06002074 RID: 8308 RVA: 0x000866BC File Offset: 0x00084ABC
		public int IsShowFilterTitleArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06002075 RID: 8309 RVA: 0x0008670C File Offset: 0x00084B0C
		public int IsShowFilterTitleLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002076 RID: 8310 RVA: 0x0008673F File Offset: 0x00084B3F
		public ArraySegment<byte>? GetIsShowFilterTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x06002077 RID: 8311 RVA: 0x0008674E File Offset: 0x00084B4E
		public FlatBufferArray<int> IsShowFilterTitle
		{
			get
			{
				if (this.IsShowFilterTitleValue == null)
				{
					this.IsShowFilterTitleValue = new FlatBufferArray<int>(new Func<int, int>(this.IsShowFilterTitleArray), this.IsShowFilterTitleLength);
				}
				return this.IsShowFilterTitleValue;
			}
		}

		// Token: 0x06002078 RID: 8312 RVA: 0x00086780 File Offset: 0x00084B80
		public ChiJiShopTable.eSubType SubTypeArray(int j)
		{
			int num = this.__p.__offset(34);
			return (ChiJiShopTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x06002079 RID: 8313 RVA: 0x000867C8 File Offset: 0x00084BC8
		public int SubTypeLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600207A RID: 8314 RVA: 0x000867FB File Offset: 0x00084BFB
		public ArraySegment<byte>? GetSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x0600207B RID: 8315 RVA: 0x0008680A File Offset: 0x00084C0A
		public FlatBufferArray<ChiJiShopTable.eSubType> SubType
		{
			get
			{
				if (this.SubTypeValue == null)
				{
					this.SubTypeValue = new FlatBufferArray<ChiJiShopTable.eSubType>(new Func<int, ChiJiShopTable.eSubType>(this.SubTypeArray), this.SubTypeLength);
				}
				return this.SubTypeValue;
			}
		}

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x0600207C RID: 8316 RVA: 0x0008683C File Offset: 0x00084C3C
		public string ExtraShowMoneys
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600207D RID: 8317 RVA: 0x0008687F File Offset: 0x00084C7F
		public ArraySegment<byte>? GetExtraShowMoneysBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x0600207E RID: 8318 RVA: 0x00086890 File Offset: 0x00084C90
		public int NeedRefreshTabsArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x0600207F RID: 8319 RVA: 0x000868E0 File Offset: 0x00084CE0
		public int NeedRefreshTabsLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002080 RID: 8320 RVA: 0x00086913 File Offset: 0x00084D13
		public ArraySegment<byte>? GetNeedRefreshTabsBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06002081 RID: 8321 RVA: 0x00086922 File Offset: 0x00084D22
		public FlatBufferArray<int> NeedRefreshTabs
		{
			get
			{
				if (this.NeedRefreshTabsValue == null)
				{
					this.NeedRefreshTabsValue = new FlatBufferArray<int>(new Func<int, int>(this.NeedRefreshTabsArray), this.NeedRefreshTabsLength);
				}
				return this.NeedRefreshTabsValue;
			}
		}

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06002082 RID: 8322 RVA: 0x00086954 File Offset: 0x00084D54
		public int Refresh
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002083 RID: 8323 RVA: 0x000869A0 File Offset: 0x00084DA0
		public ChiJiShopTable.eRefreshCycle RefreshCycleArray(int j)
		{
			int num = this.__p.__offset(42);
			return (ChiJiShopTable.eRefreshCycle)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06002084 RID: 8324 RVA: 0x000869E8 File Offset: 0x00084DE8
		public int RefreshCycleLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002085 RID: 8325 RVA: 0x00086A1B File Offset: 0x00084E1B
		public ArraySegment<byte>? GetRefreshCycleBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06002086 RID: 8326 RVA: 0x00086A2A File Offset: 0x00084E2A
		public FlatBufferArray<ChiJiShopTable.eRefreshCycle> RefreshCycle
		{
			get
			{
				if (this.RefreshCycleValue == null)
				{
					this.RefreshCycleValue = new FlatBufferArray<ChiJiShopTable.eRefreshCycle>(new Func<int, ChiJiShopTable.eRefreshCycle>(this.RefreshCycleArray), this.RefreshCycleLength);
				}
				return this.RefreshCycleValue;
			}
		}

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06002087 RID: 8327 RVA: 0x00086A5C File Offset: 0x00084E5C
		public int OpenLevel
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002088 RID: 8328 RVA: 0x00086AA8 File Offset: 0x00084EA8
		public int RefreshCostArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06002089 RID: 8329 RVA: 0x00086AF8 File Offset: 0x00084EF8
		public int RefreshCostLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600208A RID: 8330 RVA: 0x00086B2B File Offset: 0x00084F2B
		public ArraySegment<byte>? GetRefreshCostBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x0600208B RID: 8331 RVA: 0x00086B3A File Offset: 0x00084F3A
		public FlatBufferArray<int> RefreshCost
		{
			get
			{
				if (this.RefreshCostValue == null)
				{
					this.RefreshCostValue = new FlatBufferArray<int>(new Func<int, int>(this.RefreshCostArray), this.RefreshCostLength);
				}
				return this.RefreshCostValue;
			}
		}

		// Token: 0x0600208C RID: 8332 RVA: 0x00086B6C File Offset: 0x00084F6C
		public int RefreshTimeArray(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x0600208D RID: 8333 RVA: 0x00086BBC File Offset: 0x00084FBC
		public int RefreshTimeLength
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600208E RID: 8334 RVA: 0x00086BEF File Offset: 0x00084FEF
		public ArraySegment<byte>? GetRefreshTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x0600208F RID: 8335 RVA: 0x00086BFE File Offset: 0x00084FFE
		public FlatBufferArray<int> RefreshTime
		{
			get
			{
				if (this.RefreshTimeValue == null)
				{
					this.RefreshTimeValue = new FlatBufferArray<int>(new Func<int, int>(this.RefreshTimeArray), this.RefreshTimeLength);
				}
				return this.RefreshTimeValue;
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06002090 RID: 8336 RVA: 0x00086C30 File Offset: 0x00085030
		public int OnSaleNum
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002091 RID: 8337 RVA: 0x00086C7C File Offset: 0x0008507C
		public ChiJiShopTable.eSubTypeOrder SubTypeOrderArray(int j)
		{
			int num = this.__p.__offset(52);
			return (ChiJiShopTable.eSubTypeOrder)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06002092 RID: 8338 RVA: 0x00086CC4 File Offset: 0x000850C4
		public int SubTypeOrderLength
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002093 RID: 8339 RVA: 0x00086CF7 File Offset: 0x000850F7
		public ArraySegment<byte>? GetSubTypeOrderBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06002094 RID: 8340 RVA: 0x00086D06 File Offset: 0x00085106
		public FlatBufferArray<ChiJiShopTable.eSubTypeOrder> SubTypeOrder
		{
			get
			{
				if (this.SubTypeOrderValue == null)
				{
					this.SubTypeOrderValue = new FlatBufferArray<ChiJiShopTable.eSubTypeOrder>(new Func<int, ChiJiShopTable.eSubTypeOrder>(this.SubTypeOrderArray), this.SubTypeOrderLength);
				}
				return this.SubTypeOrderValue;
			}
		}

		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06002095 RID: 8341 RVA: 0x00086D38 File Offset: 0x00085138
		public int LimitGood1
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06002096 RID: 8342 RVA: 0x00086D84 File Offset: 0x00085184
		public int LimitGood2
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002097 RID: 8343 RVA: 0x00086DD0 File Offset: 0x000851D0
		public int VIPLvArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06002098 RID: 8344 RVA: 0x00086E20 File Offset: 0x00085220
		public int VIPLvLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002099 RID: 8345 RVA: 0x00086E53 File Offset: 0x00085253
		public ArraySegment<byte>? GetVIPLvBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x0600209A RID: 8346 RVA: 0x00086E62 File Offset: 0x00085262
		public FlatBufferArray<int> VIPLv
		{
			get
			{
				if (this.VIPLvValue == null)
				{
					this.VIPLvValue = new FlatBufferArray<int>(new Func<int, int>(this.VIPLvArray), this.VIPLvLength);
				}
				return this.VIPLvValue;
			}
		}

		// Token: 0x0600209B RID: 8347 RVA: 0x00086E94 File Offset: 0x00085294
		public int VIPDiscountArray(int j)
		{
			int num = this.__p.__offset(60);
			return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x0600209C RID: 8348 RVA: 0x00086EE4 File Offset: 0x000852E4
		public int VIPDiscountLength
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600209D RID: 8349 RVA: 0x00086F17 File Offset: 0x00085317
		public ArraySegment<byte>? GetVIPDiscountBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x0600209E RID: 8350 RVA: 0x00086F26 File Offset: 0x00085326
		public FlatBufferArray<int> VIPDiscount
		{
			get
			{
				if (this.VIPDiscountValue == null)
				{
					this.VIPDiscountValue = new FlatBufferArray<int>(new Func<int, int>(this.VIPDiscountArray), this.VIPDiscountLength);
				}
				return this.VIPDiscountValue;
			}
		}

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x0600209F RID: 8351 RVA: 0x00086F58 File Offset: 0x00085358
		public int Version
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x060020A0 RID: 8352 RVA: 0x00086FA4 File Offset: 0x000853A4
		public string ShopNpcBody
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060020A1 RID: 8353 RVA: 0x00086FE7 File Offset: 0x000853E7
		public ArraySegment<byte>? GetShopNpcBodyBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x060020A2 RID: 8354 RVA: 0x00086FF8 File Offset: 0x000853F8
		public int RareControlType
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x060020A3 RID: 8355 RVA: 0x00087044 File Offset: 0x00085444
		public int IsExchangeShopShow
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x060020A4 RID: 8356 RVA: 0x00087090 File Offset: 0x00085490
		public int ExchangeShopOrder
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x060020A5 RID: 8357 RVA: 0x000870DC File Offset: 0x000854DC
		public string ExchangeShopShowImage
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060020A6 RID: 8358 RVA: 0x0008711F File Offset: 0x0008551F
		public ArraySegment<byte>? GetExchangeShopShowImageBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x060020A7 RID: 8359 RVA: 0x00087130 File Offset: 0x00085530
		public string ExchangeShopNameImage
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060020A8 RID: 8360 RVA: 0x00087173 File Offset: 0x00085573
		public ArraySegment<byte>? GetExchangeShopNameImageBytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x060020A9 RID: 8361 RVA: 0x00087184 File Offset: 0x00085584
		public ChiJiShopTable.eBindType BindType
		{
			get
			{
				int num = this.__p.__offset(76);
				return (ChiJiShopTable.eBindType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x060020AA RID: 8362 RVA: 0x000871C8 File Offset: 0x000855C8
		public int HonorDiscount
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x060020AB RID: 8363 RVA: 0x00087214 File Offset: 0x00085614
		public string ShopItemRefreshDesc
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060020AC RID: 8364 RVA: 0x00087257 File Offset: 0x00085657
		public ArraySegment<byte>? GetShopItemRefreshDescBytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x060020AD RID: 8365 RVA: 0x00087268 File Offset: 0x00085668
		public int CurrencyShowType
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (634594983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060020AE RID: 8366 RVA: 0x000872B4 File Offset: 0x000856B4
		public string CurrencyExtraItemArray(int j)
		{
			int num = this.__p.__offset(84);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x060020AF RID: 8367 RVA: 0x000872FC File Offset: 0x000856FC
		public int CurrencyExtraItemLength
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x060020B0 RID: 8368 RVA: 0x0008732F File Offset: 0x0008572F
		public FlatBufferArray<string> CurrencyExtraItem
		{
			get
			{
				if (this.CurrencyExtraItemValue == null)
				{
					this.CurrencyExtraItemValue = new FlatBufferArray<string>(new Func<int, string>(this.CurrencyExtraItemArray), this.CurrencyExtraItemLength);
				}
				return this.CurrencyExtraItemValue;
			}
		}

		// Token: 0x060020B1 RID: 8369 RVA: 0x00087360 File Offset: 0x00085760
		public static Offset<ChiJiShopTable> CreateChiJiShopTable(FlatBufferBuilder builder, int ID = 0, StringOffset ShopNameOffset = default(StringOffset), StringOffset ShopNamePathOffset = default(StringOffset), StringOffset ShopMallIconOffset = default(StringOffset), StringOffset ShopSimpleNameOffset = default(StringOffset), StringOffset LinkOffset = default(StringOffset), ChiJiShopTable.eShopKind ShopKind = ChiJiShopTable.eShopKind.SK_Ancient, int HelpID = 0, int Param1 = 0, int IsGuildShop = 0, VectorOffset ChildrenOffset = default(VectorOffset), VectorOffset FilterOffset = default(VectorOffset), VectorOffset Filter2Offset = default(VectorOffset), VectorOffset HideFilterItemOffset = default(VectorOffset), VectorOffset IsShowFilterTitleOffset = default(VectorOffset), VectorOffset SubTypeOffset = default(VectorOffset), StringOffset ExtraShowMoneysOffset = default(StringOffset), VectorOffset NeedRefreshTabsOffset = default(VectorOffset), int Refresh = 0, VectorOffset RefreshCycleOffset = default(VectorOffset), int OpenLevel = 0, VectorOffset RefreshCostOffset = default(VectorOffset), VectorOffset RefreshTimeOffset = default(VectorOffset), int OnSaleNum = 0, VectorOffset SubTypeOrderOffset = default(VectorOffset), int LimitGood1 = 0, int LimitGood2 = 0, VectorOffset VIPLvOffset = default(VectorOffset), VectorOffset VIPDiscountOffset = default(VectorOffset), int Version = 0, StringOffset ShopNpcBodyOffset = default(StringOffset), int RareControlType = 0, int IsExchangeShopShow = 0, int ExchangeShopOrder = 0, StringOffset ExchangeShopShowImageOffset = default(StringOffset), StringOffset ExchangeShopNameImageOffset = default(StringOffset), ChiJiShopTable.eBindType BindType = ChiJiShopTable.eBindType.ROLE_BIND, int HonorDiscount = 0, StringOffset ShopItemRefreshDescOffset = default(StringOffset), int CurrencyShowType = 0, VectorOffset CurrencyExtraItemOffset = default(VectorOffset))
		{
			builder.StartObject(41);
			ChiJiShopTable.AddCurrencyExtraItem(builder, CurrencyExtraItemOffset);
			ChiJiShopTable.AddCurrencyShowType(builder, CurrencyShowType);
			ChiJiShopTable.AddShopItemRefreshDesc(builder, ShopItemRefreshDescOffset);
			ChiJiShopTable.AddHonorDiscount(builder, HonorDiscount);
			ChiJiShopTable.AddBindType(builder, BindType);
			ChiJiShopTable.AddExchangeShopNameImage(builder, ExchangeShopNameImageOffset);
			ChiJiShopTable.AddExchangeShopShowImage(builder, ExchangeShopShowImageOffset);
			ChiJiShopTable.AddExchangeShopOrder(builder, ExchangeShopOrder);
			ChiJiShopTable.AddIsExchangeShopShow(builder, IsExchangeShopShow);
			ChiJiShopTable.AddRareControlType(builder, RareControlType);
			ChiJiShopTable.AddShopNpcBody(builder, ShopNpcBodyOffset);
			ChiJiShopTable.AddVersion(builder, Version);
			ChiJiShopTable.AddVIPDiscount(builder, VIPDiscountOffset);
			ChiJiShopTable.AddVIPLv(builder, VIPLvOffset);
			ChiJiShopTable.AddLimitGood2(builder, LimitGood2);
			ChiJiShopTable.AddLimitGood1(builder, LimitGood1);
			ChiJiShopTable.AddSubTypeOrder(builder, SubTypeOrderOffset);
			ChiJiShopTable.AddOnSaleNum(builder, OnSaleNum);
			ChiJiShopTable.AddRefreshTime(builder, RefreshTimeOffset);
			ChiJiShopTable.AddRefreshCost(builder, RefreshCostOffset);
			ChiJiShopTable.AddOpenLevel(builder, OpenLevel);
			ChiJiShopTable.AddRefreshCycle(builder, RefreshCycleOffset);
			ChiJiShopTable.AddRefresh(builder, Refresh);
			ChiJiShopTable.AddNeedRefreshTabs(builder, NeedRefreshTabsOffset);
			ChiJiShopTable.AddExtraShowMoneys(builder, ExtraShowMoneysOffset);
			ChiJiShopTable.AddSubType(builder, SubTypeOffset);
			ChiJiShopTable.AddIsShowFilterTitle(builder, IsShowFilterTitleOffset);
			ChiJiShopTable.AddHideFilterItem(builder, HideFilterItemOffset);
			ChiJiShopTable.AddFilter2(builder, Filter2Offset);
			ChiJiShopTable.AddFilter(builder, FilterOffset);
			ChiJiShopTable.AddChildren(builder, ChildrenOffset);
			ChiJiShopTable.AddIsGuildShop(builder, IsGuildShop);
			ChiJiShopTable.AddParam1(builder, Param1);
			ChiJiShopTable.AddHelpID(builder, HelpID);
			ChiJiShopTable.AddShopKind(builder, ShopKind);
			ChiJiShopTable.AddLink(builder, LinkOffset);
			ChiJiShopTable.AddShopSimpleName(builder, ShopSimpleNameOffset);
			ChiJiShopTable.AddShopMallIcon(builder, ShopMallIconOffset);
			ChiJiShopTable.AddShopNamePath(builder, ShopNamePathOffset);
			ChiJiShopTable.AddShopName(builder, ShopNameOffset);
			ChiJiShopTable.AddID(builder, ID);
			return ChiJiShopTable.EndChiJiShopTable(builder);
		}

		// Token: 0x060020B2 RID: 8370 RVA: 0x000874C0 File Offset: 0x000858C0
		public static void StartChiJiShopTable(FlatBufferBuilder builder)
		{
			builder.StartObject(41);
		}

		// Token: 0x060020B3 RID: 8371 RVA: 0x000874CA File Offset: 0x000858CA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x000874D5 File Offset: 0x000858D5
		public static void AddShopName(FlatBufferBuilder builder, StringOffset ShopNameOffset)
		{
			builder.AddOffset(1, ShopNameOffset.Value, 0);
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x000874E6 File Offset: 0x000858E6
		public static void AddShopNamePath(FlatBufferBuilder builder, StringOffset ShopNamePathOffset)
		{
			builder.AddOffset(2, ShopNamePathOffset.Value, 0);
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x000874F7 File Offset: 0x000858F7
		public static void AddShopMallIcon(FlatBufferBuilder builder, StringOffset ShopMallIconOffset)
		{
			builder.AddOffset(3, ShopMallIconOffset.Value, 0);
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x00087508 File Offset: 0x00085908
		public static void AddShopSimpleName(FlatBufferBuilder builder, StringOffset ShopSimpleNameOffset)
		{
			builder.AddOffset(4, ShopSimpleNameOffset.Value, 0);
		}

		// Token: 0x060020B8 RID: 8376 RVA: 0x00087519 File Offset: 0x00085919
		public static void AddLink(FlatBufferBuilder builder, StringOffset LinkOffset)
		{
			builder.AddOffset(5, LinkOffset.Value, 0);
		}

		// Token: 0x060020B9 RID: 8377 RVA: 0x0008752A File Offset: 0x0008592A
		public static void AddShopKind(FlatBufferBuilder builder, ChiJiShopTable.eShopKind ShopKind)
		{
			builder.AddInt(6, (int)ShopKind, 0);
		}

		// Token: 0x060020BA RID: 8378 RVA: 0x00087535 File Offset: 0x00085935
		public static void AddHelpID(FlatBufferBuilder builder, int HelpID)
		{
			builder.AddInt(7, HelpID, 0);
		}

		// Token: 0x060020BB RID: 8379 RVA: 0x00087540 File Offset: 0x00085940
		public static void AddParam1(FlatBufferBuilder builder, int Param1)
		{
			builder.AddInt(8, Param1, 0);
		}

		// Token: 0x060020BC RID: 8380 RVA: 0x0008754B File Offset: 0x0008594B
		public static void AddIsGuildShop(FlatBufferBuilder builder, int IsGuildShop)
		{
			builder.AddInt(9, IsGuildShop, 0);
		}

		// Token: 0x060020BD RID: 8381 RVA: 0x00087557 File Offset: 0x00085957
		public static void AddChildren(FlatBufferBuilder builder, VectorOffset ChildrenOffset)
		{
			builder.AddOffset(10, ChildrenOffset.Value, 0);
		}

		// Token: 0x060020BE RID: 8382 RVA: 0x0008756C File Offset: 0x0008596C
		public static VectorOffset CreateChildrenVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020BF RID: 8383 RVA: 0x000875A9 File Offset: 0x000859A9
		public static void StartChildrenVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020C0 RID: 8384 RVA: 0x000875B4 File Offset: 0x000859B4
		public static void AddFilter(FlatBufferBuilder builder, VectorOffset FilterOffset)
		{
			builder.AddOffset(11, FilterOffset.Value, 0);
		}

		// Token: 0x060020C1 RID: 8385 RVA: 0x000875C8 File Offset: 0x000859C8
		public static VectorOffset CreateFilterVector(FlatBufferBuilder builder, ChiJiShopTable.eFilter[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020C2 RID: 8386 RVA: 0x00087605 File Offset: 0x00085A05
		public static void StartFilterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020C3 RID: 8387 RVA: 0x00087610 File Offset: 0x00085A10
		public static void AddFilter2(FlatBufferBuilder builder, VectorOffset Filter2Offset)
		{
			builder.AddOffset(12, Filter2Offset.Value, 0);
		}

		// Token: 0x060020C4 RID: 8388 RVA: 0x00087624 File Offset: 0x00085A24
		public static VectorOffset CreateFilter2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x00087661 File Offset: 0x00085A61
		public static void StartFilter2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x0008766C File Offset: 0x00085A6C
		public static void AddHideFilterItem(FlatBufferBuilder builder, VectorOffset HideFilterItemOffset)
		{
			builder.AddOffset(13, HideFilterItemOffset.Value, 0);
		}

		// Token: 0x060020C7 RID: 8391 RVA: 0x00087680 File Offset: 0x00085A80
		public static VectorOffset CreateHideFilterItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020C8 RID: 8392 RVA: 0x000876BD File Offset: 0x00085ABD
		public static void StartHideFilterItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020C9 RID: 8393 RVA: 0x000876C8 File Offset: 0x00085AC8
		public static void AddIsShowFilterTitle(FlatBufferBuilder builder, VectorOffset IsShowFilterTitleOffset)
		{
			builder.AddOffset(14, IsShowFilterTitleOffset.Value, 0);
		}

		// Token: 0x060020CA RID: 8394 RVA: 0x000876DC File Offset: 0x00085ADC
		public static VectorOffset CreateIsShowFilterTitleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020CB RID: 8395 RVA: 0x00087719 File Offset: 0x00085B19
		public static void StartIsShowFilterTitleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020CC RID: 8396 RVA: 0x00087724 File Offset: 0x00085B24
		public static void AddSubType(FlatBufferBuilder builder, VectorOffset SubTypeOffset)
		{
			builder.AddOffset(15, SubTypeOffset.Value, 0);
		}

		// Token: 0x060020CD RID: 8397 RVA: 0x00087738 File Offset: 0x00085B38
		public static VectorOffset CreateSubTypeVector(FlatBufferBuilder builder, ChiJiShopTable.eSubType[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020CE RID: 8398 RVA: 0x00087775 File Offset: 0x00085B75
		public static void StartSubTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020CF RID: 8399 RVA: 0x00087780 File Offset: 0x00085B80
		public static void AddExtraShowMoneys(FlatBufferBuilder builder, StringOffset ExtraShowMoneysOffset)
		{
			builder.AddOffset(16, ExtraShowMoneysOffset.Value, 0);
		}

		// Token: 0x060020D0 RID: 8400 RVA: 0x00087792 File Offset: 0x00085B92
		public static void AddNeedRefreshTabs(FlatBufferBuilder builder, VectorOffset NeedRefreshTabsOffset)
		{
			builder.AddOffset(17, NeedRefreshTabsOffset.Value, 0);
		}

		// Token: 0x060020D1 RID: 8401 RVA: 0x000877A4 File Offset: 0x00085BA4
		public static VectorOffset CreateNeedRefreshTabsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020D2 RID: 8402 RVA: 0x000877E1 File Offset: 0x00085BE1
		public static void StartNeedRefreshTabsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020D3 RID: 8403 RVA: 0x000877EC File Offset: 0x00085BEC
		public static void AddRefresh(FlatBufferBuilder builder, int Refresh)
		{
			builder.AddInt(18, Refresh, 0);
		}

		// Token: 0x060020D4 RID: 8404 RVA: 0x000877F8 File Offset: 0x00085BF8
		public static void AddRefreshCycle(FlatBufferBuilder builder, VectorOffset RefreshCycleOffset)
		{
			builder.AddOffset(19, RefreshCycleOffset.Value, 0);
		}

		// Token: 0x060020D5 RID: 8405 RVA: 0x0008780C File Offset: 0x00085C0C
		public static VectorOffset CreateRefreshCycleVector(FlatBufferBuilder builder, ChiJiShopTable.eRefreshCycle[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020D6 RID: 8406 RVA: 0x00087849 File Offset: 0x00085C49
		public static void StartRefreshCycleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020D7 RID: 8407 RVA: 0x00087854 File Offset: 0x00085C54
		public static void AddOpenLevel(FlatBufferBuilder builder, int OpenLevel)
		{
			builder.AddInt(20, OpenLevel, 0);
		}

		// Token: 0x060020D8 RID: 8408 RVA: 0x00087860 File Offset: 0x00085C60
		public static void AddRefreshCost(FlatBufferBuilder builder, VectorOffset RefreshCostOffset)
		{
			builder.AddOffset(21, RefreshCostOffset.Value, 0);
		}

		// Token: 0x060020D9 RID: 8409 RVA: 0x00087874 File Offset: 0x00085C74
		public static VectorOffset CreateRefreshCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020DA RID: 8410 RVA: 0x000878B1 File Offset: 0x00085CB1
		public static void StartRefreshCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020DB RID: 8411 RVA: 0x000878BC File Offset: 0x00085CBC
		public static void AddRefreshTime(FlatBufferBuilder builder, VectorOffset RefreshTimeOffset)
		{
			builder.AddOffset(22, RefreshTimeOffset.Value, 0);
		}

		// Token: 0x060020DC RID: 8412 RVA: 0x000878D0 File Offset: 0x00085CD0
		public static VectorOffset CreateRefreshTimeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020DD RID: 8413 RVA: 0x0008790D File Offset: 0x00085D0D
		public static void StartRefreshTimeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020DE RID: 8414 RVA: 0x00087918 File Offset: 0x00085D18
		public static void AddOnSaleNum(FlatBufferBuilder builder, int OnSaleNum)
		{
			builder.AddInt(23, OnSaleNum, 0);
		}

		// Token: 0x060020DF RID: 8415 RVA: 0x00087924 File Offset: 0x00085D24
		public static void AddSubTypeOrder(FlatBufferBuilder builder, VectorOffset SubTypeOrderOffset)
		{
			builder.AddOffset(24, SubTypeOrderOffset.Value, 0);
		}

		// Token: 0x060020E0 RID: 8416 RVA: 0x00087938 File Offset: 0x00085D38
		public static VectorOffset CreateSubTypeOrderVector(FlatBufferBuilder builder, ChiJiShopTable.eSubTypeOrder[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020E1 RID: 8417 RVA: 0x00087975 File Offset: 0x00085D75
		public static void StartSubTypeOrderVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020E2 RID: 8418 RVA: 0x00087980 File Offset: 0x00085D80
		public static void AddLimitGood1(FlatBufferBuilder builder, int LimitGood1)
		{
			builder.AddInt(25, LimitGood1, 0);
		}

		// Token: 0x060020E3 RID: 8419 RVA: 0x0008798C File Offset: 0x00085D8C
		public static void AddLimitGood2(FlatBufferBuilder builder, int LimitGood2)
		{
			builder.AddInt(26, LimitGood2, 0);
		}

		// Token: 0x060020E4 RID: 8420 RVA: 0x00087998 File Offset: 0x00085D98
		public static void AddVIPLv(FlatBufferBuilder builder, VectorOffset VIPLvOffset)
		{
			builder.AddOffset(27, VIPLvOffset.Value, 0);
		}

		// Token: 0x060020E5 RID: 8421 RVA: 0x000879AC File Offset: 0x00085DAC
		public static VectorOffset CreateVIPLvVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020E6 RID: 8422 RVA: 0x000879E9 File Offset: 0x00085DE9
		public static void StartVIPLvVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020E7 RID: 8423 RVA: 0x000879F4 File Offset: 0x00085DF4
		public static void AddVIPDiscount(FlatBufferBuilder builder, VectorOffset VIPDiscountOffset)
		{
			builder.AddOffset(28, VIPDiscountOffset.Value, 0);
		}

		// Token: 0x060020E8 RID: 8424 RVA: 0x00087A08 File Offset: 0x00085E08
		public static VectorOffset CreateVIPDiscountVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060020E9 RID: 8425 RVA: 0x00087A45 File Offset: 0x00085E45
		public static void StartVIPDiscountVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020EA RID: 8426 RVA: 0x00087A50 File Offset: 0x00085E50
		public static void AddVersion(FlatBufferBuilder builder, int Version)
		{
			builder.AddInt(29, Version, 0);
		}

		// Token: 0x060020EB RID: 8427 RVA: 0x00087A5C File Offset: 0x00085E5C
		public static void AddShopNpcBody(FlatBufferBuilder builder, StringOffset ShopNpcBodyOffset)
		{
			builder.AddOffset(30, ShopNpcBodyOffset.Value, 0);
		}

		// Token: 0x060020EC RID: 8428 RVA: 0x00087A6E File Offset: 0x00085E6E
		public static void AddRareControlType(FlatBufferBuilder builder, int RareControlType)
		{
			builder.AddInt(31, RareControlType, 0);
		}

		// Token: 0x060020ED RID: 8429 RVA: 0x00087A7A File Offset: 0x00085E7A
		public static void AddIsExchangeShopShow(FlatBufferBuilder builder, int IsExchangeShopShow)
		{
			builder.AddInt(32, IsExchangeShopShow, 0);
		}

		// Token: 0x060020EE RID: 8430 RVA: 0x00087A86 File Offset: 0x00085E86
		public static void AddExchangeShopOrder(FlatBufferBuilder builder, int ExchangeShopOrder)
		{
			builder.AddInt(33, ExchangeShopOrder, 0);
		}

		// Token: 0x060020EF RID: 8431 RVA: 0x00087A92 File Offset: 0x00085E92
		public static void AddExchangeShopShowImage(FlatBufferBuilder builder, StringOffset ExchangeShopShowImageOffset)
		{
			builder.AddOffset(34, ExchangeShopShowImageOffset.Value, 0);
		}

		// Token: 0x060020F0 RID: 8432 RVA: 0x00087AA4 File Offset: 0x00085EA4
		public static void AddExchangeShopNameImage(FlatBufferBuilder builder, StringOffset ExchangeShopNameImageOffset)
		{
			builder.AddOffset(35, ExchangeShopNameImageOffset.Value, 0);
		}

		// Token: 0x060020F1 RID: 8433 RVA: 0x00087AB6 File Offset: 0x00085EB6
		public static void AddBindType(FlatBufferBuilder builder, ChiJiShopTable.eBindType BindType)
		{
			builder.AddInt(36, (int)BindType, 0);
		}

		// Token: 0x060020F2 RID: 8434 RVA: 0x00087AC2 File Offset: 0x00085EC2
		public static void AddHonorDiscount(FlatBufferBuilder builder, int HonorDiscount)
		{
			builder.AddInt(37, HonorDiscount, 0);
		}

		// Token: 0x060020F3 RID: 8435 RVA: 0x00087ACE File Offset: 0x00085ECE
		public static void AddShopItemRefreshDesc(FlatBufferBuilder builder, StringOffset ShopItemRefreshDescOffset)
		{
			builder.AddOffset(38, ShopItemRefreshDescOffset.Value, 0);
		}

		// Token: 0x060020F4 RID: 8436 RVA: 0x00087AE0 File Offset: 0x00085EE0
		public static void AddCurrencyShowType(FlatBufferBuilder builder, int CurrencyShowType)
		{
			builder.AddInt(39, CurrencyShowType, 0);
		}

		// Token: 0x060020F5 RID: 8437 RVA: 0x00087AEC File Offset: 0x00085EEC
		public static void AddCurrencyExtraItem(FlatBufferBuilder builder, VectorOffset CurrencyExtraItemOffset)
		{
			builder.AddOffset(40, CurrencyExtraItemOffset.Value, 0);
		}

		// Token: 0x060020F6 RID: 8438 RVA: 0x00087B00 File Offset: 0x00085F00
		public static VectorOffset CreateCurrencyExtraItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060020F7 RID: 8439 RVA: 0x00087B46 File Offset: 0x00085F46
		public static void StartCurrencyExtraItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060020F8 RID: 8440 RVA: 0x00087B54 File Offset: 0x00085F54
		public static Offset<ChiJiShopTable> EndChiJiShopTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiShopTable>(value);
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x00087B6E File Offset: 0x00085F6E
		public static void FinishChiJiShopTableBuffer(FlatBufferBuilder builder, Offset<ChiJiShopTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F91 RID: 3985
		private Table __p = new Table();

		// Token: 0x04000F92 RID: 3986
		private FlatBufferArray<int> ChildrenValue;

		// Token: 0x04000F93 RID: 3987
		private FlatBufferArray<ChiJiShopTable.eFilter> FilterValue;

		// Token: 0x04000F94 RID: 3988
		private FlatBufferArray<int> Filter2Value;

		// Token: 0x04000F95 RID: 3989
		private FlatBufferArray<int> HideFilterItemValue;

		// Token: 0x04000F96 RID: 3990
		private FlatBufferArray<int> IsShowFilterTitleValue;

		// Token: 0x04000F97 RID: 3991
		private FlatBufferArray<ChiJiShopTable.eSubType> SubTypeValue;

		// Token: 0x04000F98 RID: 3992
		private FlatBufferArray<int> NeedRefreshTabsValue;

		// Token: 0x04000F99 RID: 3993
		private FlatBufferArray<ChiJiShopTable.eRefreshCycle> RefreshCycleValue;

		// Token: 0x04000F9A RID: 3994
		private FlatBufferArray<int> RefreshCostValue;

		// Token: 0x04000F9B RID: 3995
		private FlatBufferArray<int> RefreshTimeValue;

		// Token: 0x04000F9C RID: 3996
		private FlatBufferArray<ChiJiShopTable.eSubTypeOrder> SubTypeOrderValue;

		// Token: 0x04000F9D RID: 3997
		private FlatBufferArray<int> VIPLvValue;

		// Token: 0x04000F9E RID: 3998
		private FlatBufferArray<int> VIPDiscountValue;

		// Token: 0x04000F9F RID: 3999
		private FlatBufferArray<string> CurrencyExtraItemValue;

		// Token: 0x0200032B RID: 811
		public enum eShopKind
		{
			// Token: 0x04000FA1 RID: 4001
			SK_Ancient,
			// Token: 0x04000FA2 RID: 4002
			SK_Mystery,
			// Token: 0x04000FA3 RID: 4003
			SK_Forge,
			// Token: 0x04000FA4 RID: 4004
			SK_Brave,
			// Token: 0x04000FA5 RID: 4005
			SK_Fight,
			// Token: 0x04000FA6 RID: 4006
			SK_Guild,
			// Token: 0x04000FA7 RID: 4007
			SK_Magic,
			// Token: 0x04000FA8 RID: 4008
			SK_Gold,
			// Token: 0x04000FA9 RID: 4009
			SK_Abyss,
			// Token: 0x04000FAA RID: 4010
			SK_Warehouse,
			// Token: 0x04000FAB RID: 4011
			SK_Activity,
			// Token: 0x04000FAC RID: 4012
			SK_Master = 12,
			// Token: 0x04000FAD RID: 4013
			SK_Lease,
			// Token: 0x04000FAE RID: 4014
			SK_BlessCrystal,
			// Token: 0x04000FAF RID: 4015
			SK_BindCoin = 17,
			// Token: 0x04000FB0 RID: 4016
			SK_AdventureCoin
		}

		// Token: 0x0200032C RID: 812
		public enum eFilter
		{
			// Token: 0x04000FB2 RID: 4018
			SF_NONE,
			// Token: 0x04000FB3 RID: 4019
			SF_OCCU,
			// Token: 0x04000FB4 RID: 4020
			SF_ARMOR,
			// Token: 0x04000FB5 RID: 4021
			SF_OCCU2,
			// Token: 0x04000FB6 RID: 4022
			SF_PLAY_OCCU,
			// Token: 0x04000FB7 RID: 4023
			SF_LEVEL,
			// Token: 0x04000FB8 RID: 4024
			SF_COUNT
		}

		// Token: 0x0200032D RID: 813
		public enum eSubType
		{
			// Token: 0x04000FBA RID: 4026
			ST_NONE,
			// Token: 0x04000FBB RID: 4027
			ST_MATERIAL,
			// Token: 0x04000FBC RID: 4028
			ST_WEAPON,
			// Token: 0x04000FBD RID: 4029
			ST_ARMOR,
			// Token: 0x04000FBE RID: 4030
			ST_JEWELRY,
			// Token: 0x04000FBF RID: 4031
			ST_COST,
			// Token: 0x04000FC0 RID: 4032
			ST_VALUABLE,
			// Token: 0x04000FC1 RID: 4033
			ST_RETINUE,
			// Token: 0x04000FC2 RID: 4034
			ST_TITLE,
			// Token: 0x04000FC3 RID: 4035
			ST_ENERGY,
			// Token: 0x04000FC4 RID: 4036
			ST_FASHION,
			// Token: 0x04000FC5 RID: 4037
			ST_ORDINARY,
			// Token: 0x04000FC6 RID: 4038
			ST_DAILY,
			// Token: 0x04000FC7 RID: 4039
			ST_GOODS,
			// Token: 0x04000FC8 RID: 4040
			ST_EQUIP,
			// Token: 0x04000FC9 RID: 4041
			ST_EXP,
			// Token: 0x04000FCA RID: 4042
			ST_GOLDJAR
		}

		// Token: 0x0200032E RID: 814
		public enum eRefreshCycle
		{
			// Token: 0x04000FCC RID: 4044
			REFRESH_CYCLE_NONE,
			// Token: 0x04000FCD RID: 4045
			REFRESH_CYCLE_DAILY,
			// Token: 0x04000FCE RID: 4046
			REFRESH_CYCLE_WEEK,
			// Token: 0x04000FCF RID: 4047
			REFRESH_CYCLE_MONTH,
			// Token: 0x04000FD0 RID: 4048
			REFRESH_CYCLE_ACTIVITY
		}

		// Token: 0x0200032F RID: 815
		public enum eSubTypeOrder
		{
			// Token: 0x04000FD2 RID: 4050
			STO_NONE,
			// Token: 0x04000FD3 RID: 4051
			STO_EQUIP,
			// Token: 0x04000FD4 RID: 4052
			STO_EXPENDABLE,
			// Token: 0x04000FD5 RID: 4053
			STO_MATERIAL,
			// Token: 0x04000FD6 RID: 4054
			STO_TASK,
			// Token: 0x04000FD7 RID: 4055
			STO_FASHION
		}

		// Token: 0x02000330 RID: 816
		public enum eBindType
		{
			// Token: 0x04000FD9 RID: 4057
			ROLE_BIND,
			// Token: 0x04000FDA RID: 4058
			ACCOUNT_BIND
		}

		// Token: 0x02000331 RID: 817
		public enum eCrypt
		{
			// Token: 0x04000FDC RID: 4060
			code = 634594983
		}
	}
}
