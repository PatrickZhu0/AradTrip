using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005B3 RID: 1459
	public class ShopTable : IFlatbufferObject
	{
		// Token: 0x1700149B RID: 5275
		// (get) Token: 0x06004BAC RID: 19372 RVA: 0x000ED268 File Offset: 0x000EB668
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004BAD RID: 19373 RVA: 0x000ED275 File Offset: 0x000EB675
		public static ShopTable GetRootAsShopTable(ByteBuffer _bb)
		{
			return ShopTable.GetRootAsShopTable(_bb, new ShopTable());
		}

		// Token: 0x06004BAE RID: 19374 RVA: 0x000ED282 File Offset: 0x000EB682
		public static ShopTable GetRootAsShopTable(ByteBuffer _bb, ShopTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004BAF RID: 19375 RVA: 0x000ED29E File Offset: 0x000EB69E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004BB0 RID: 19376 RVA: 0x000ED2B8 File Offset: 0x000EB6B8
		public ShopTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700149C RID: 5276
		// (get) Token: 0x06004BB1 RID: 19377 RVA: 0x000ED2C4 File Offset: 0x000EB6C4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700149D RID: 5277
		// (get) Token: 0x06004BB2 RID: 19378 RVA: 0x000ED310 File Offset: 0x000EB710
		public string ShopName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BB3 RID: 19379 RVA: 0x000ED352 File Offset: 0x000EB752
		public ArraySegment<byte>? GetShopNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700149E RID: 5278
		// (get) Token: 0x06004BB4 RID: 19380 RVA: 0x000ED360 File Offset: 0x000EB760
		public string ShopNamePath
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BB5 RID: 19381 RVA: 0x000ED3A2 File Offset: 0x000EB7A2
		public ArraySegment<byte>? GetShopNamePathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700149F RID: 5279
		// (get) Token: 0x06004BB6 RID: 19382 RVA: 0x000ED3B0 File Offset: 0x000EB7B0
		public string ShopMallIcon
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BB7 RID: 19383 RVA: 0x000ED3F3 File Offset: 0x000EB7F3
		public ArraySegment<byte>? GetShopMallIconBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170014A0 RID: 5280
		// (get) Token: 0x06004BB8 RID: 19384 RVA: 0x000ED404 File Offset: 0x000EB804
		public string ShopSimpleName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BB9 RID: 19385 RVA: 0x000ED447 File Offset: 0x000EB847
		public ArraySegment<byte>? GetShopSimpleNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170014A1 RID: 5281
		// (get) Token: 0x06004BBA RID: 19386 RVA: 0x000ED458 File Offset: 0x000EB858
		public string Link
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BBB RID: 19387 RVA: 0x000ED49B File Offset: 0x000EB89B
		public ArraySegment<byte>? GetLinkBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170014A2 RID: 5282
		// (get) Token: 0x06004BBC RID: 19388 RVA: 0x000ED4AC File Offset: 0x000EB8AC
		public ShopTable.eShopKind ShopKind
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ShopTable.eShopKind)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014A3 RID: 5283
		// (get) Token: 0x06004BBD RID: 19389 RVA: 0x000ED4F0 File Offset: 0x000EB8F0
		public int HelpID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014A4 RID: 5284
		// (get) Token: 0x06004BBE RID: 19390 RVA: 0x000ED53C File Offset: 0x000EB93C
		public int Param1
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014A5 RID: 5285
		// (get) Token: 0x06004BBF RID: 19391 RVA: 0x000ED588 File Offset: 0x000EB988
		public int IsGuildShop
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004BC0 RID: 19392 RVA: 0x000ED5D4 File Offset: 0x000EB9D4
		public int ChildrenArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014A6 RID: 5286
		// (get) Token: 0x06004BC1 RID: 19393 RVA: 0x000ED624 File Offset: 0x000EBA24
		public int ChildrenLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x000ED657 File Offset: 0x000EBA57
		public ArraySegment<byte>? GetChildrenBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170014A7 RID: 5287
		// (get) Token: 0x06004BC3 RID: 19395 RVA: 0x000ED666 File Offset: 0x000EBA66
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

		// Token: 0x06004BC4 RID: 19396 RVA: 0x000ED698 File Offset: 0x000EBA98
		public ShopTable.eFilter FilterArray(int j)
		{
			int num = this.__p.__offset(26);
			return (ShopTable.eFilter)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014A8 RID: 5288
		// (get) Token: 0x06004BC5 RID: 19397 RVA: 0x000ED6E0 File Offset: 0x000EBAE0
		public int FilterLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BC6 RID: 19398 RVA: 0x000ED713 File Offset: 0x000EBB13
		public ArraySegment<byte>? GetFilterBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170014A9 RID: 5289
		// (get) Token: 0x06004BC7 RID: 19399 RVA: 0x000ED722 File Offset: 0x000EBB22
		public FlatBufferArray<ShopTable.eFilter> Filter
		{
			get
			{
				if (this.FilterValue == null)
				{
					this.FilterValue = new FlatBufferArray<ShopTable.eFilter>(new Func<int, ShopTable.eFilter>(this.FilterArray), this.FilterLength);
				}
				return this.FilterValue;
			}
		}

		// Token: 0x06004BC8 RID: 19400 RVA: 0x000ED754 File Offset: 0x000EBB54
		public int Filter2Array(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014AA RID: 5290
		// (get) Token: 0x06004BC9 RID: 19401 RVA: 0x000ED7A4 File Offset: 0x000EBBA4
		public int Filter2Length
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BCA RID: 19402 RVA: 0x000ED7D7 File Offset: 0x000EBBD7
		public ArraySegment<byte>? GetFilter2Bytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170014AB RID: 5291
		// (get) Token: 0x06004BCB RID: 19403 RVA: 0x000ED7E6 File Offset: 0x000EBBE6
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

		// Token: 0x06004BCC RID: 19404 RVA: 0x000ED818 File Offset: 0x000EBC18
		public int HideFilterItemArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014AC RID: 5292
		// (get) Token: 0x06004BCD RID: 19405 RVA: 0x000ED868 File Offset: 0x000EBC68
		public int HideFilterItemLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BCE RID: 19406 RVA: 0x000ED89B File Offset: 0x000EBC9B
		public ArraySegment<byte>? GetHideFilterItemBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170014AD RID: 5293
		// (get) Token: 0x06004BCF RID: 19407 RVA: 0x000ED8AA File Offset: 0x000EBCAA
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

		// Token: 0x06004BD0 RID: 19408 RVA: 0x000ED8DC File Offset: 0x000EBCDC
		public int IsShowFilterTitleArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014AE RID: 5294
		// (get) Token: 0x06004BD1 RID: 19409 RVA: 0x000ED92C File Offset: 0x000EBD2C
		public int IsShowFilterTitleLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BD2 RID: 19410 RVA: 0x000ED95F File Offset: 0x000EBD5F
		public ArraySegment<byte>? GetIsShowFilterTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170014AF RID: 5295
		// (get) Token: 0x06004BD3 RID: 19411 RVA: 0x000ED96E File Offset: 0x000EBD6E
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

		// Token: 0x06004BD4 RID: 19412 RVA: 0x000ED9A0 File Offset: 0x000EBDA0
		public ShopTable.eSubType SubTypeArray(int j)
		{
			int num = this.__p.__offset(34);
			return (ShopTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014B0 RID: 5296
		// (get) Token: 0x06004BD5 RID: 19413 RVA: 0x000ED9E8 File Offset: 0x000EBDE8
		public int SubTypeLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BD6 RID: 19414 RVA: 0x000EDA1B File Offset: 0x000EBE1B
		public ArraySegment<byte>? GetSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x170014B1 RID: 5297
		// (get) Token: 0x06004BD7 RID: 19415 RVA: 0x000EDA2A File Offset: 0x000EBE2A
		public FlatBufferArray<ShopTable.eSubType> SubType
		{
			get
			{
				if (this.SubTypeValue == null)
				{
					this.SubTypeValue = new FlatBufferArray<ShopTable.eSubType>(new Func<int, ShopTable.eSubType>(this.SubTypeArray), this.SubTypeLength);
				}
				return this.SubTypeValue;
			}
		}

		// Token: 0x170014B2 RID: 5298
		// (get) Token: 0x06004BD8 RID: 19416 RVA: 0x000EDA5C File Offset: 0x000EBE5C
		public string ExtraShowMoneys
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BD9 RID: 19417 RVA: 0x000EDA9F File Offset: 0x000EBE9F
		public ArraySegment<byte>? GetExtraShowMoneysBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x06004BDA RID: 19418 RVA: 0x000EDAB0 File Offset: 0x000EBEB0
		public int NeedRefreshTabsArray(int j)
		{
			int num = this.__p.__offset(38);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014B3 RID: 5299
		// (get) Token: 0x06004BDB RID: 19419 RVA: 0x000EDB00 File Offset: 0x000EBF00
		public int NeedRefreshTabsLength
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BDC RID: 19420 RVA: 0x000EDB33 File Offset: 0x000EBF33
		public ArraySegment<byte>? GetNeedRefreshTabsBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170014B4 RID: 5300
		// (get) Token: 0x06004BDD RID: 19421 RVA: 0x000EDB42 File Offset: 0x000EBF42
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

		// Token: 0x170014B5 RID: 5301
		// (get) Token: 0x06004BDE RID: 19422 RVA: 0x000EDB74 File Offset: 0x000EBF74
		public int Refresh
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004BDF RID: 19423 RVA: 0x000EDBC0 File Offset: 0x000EBFC0
		public ShopTable.eRefreshCycle RefreshCycleArray(int j)
		{
			int num = this.__p.__offset(42);
			return (ShopTable.eRefreshCycle)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014B6 RID: 5302
		// (get) Token: 0x06004BE0 RID: 19424 RVA: 0x000EDC08 File Offset: 0x000EC008
		public int RefreshCycleLength
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BE1 RID: 19425 RVA: 0x000EDC3B File Offset: 0x000EC03B
		public ArraySegment<byte>? GetRefreshCycleBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170014B7 RID: 5303
		// (get) Token: 0x06004BE2 RID: 19426 RVA: 0x000EDC4A File Offset: 0x000EC04A
		public FlatBufferArray<ShopTable.eRefreshCycle> RefreshCycle
		{
			get
			{
				if (this.RefreshCycleValue == null)
				{
					this.RefreshCycleValue = new FlatBufferArray<ShopTable.eRefreshCycle>(new Func<int, ShopTable.eRefreshCycle>(this.RefreshCycleArray), this.RefreshCycleLength);
				}
				return this.RefreshCycleValue;
			}
		}

		// Token: 0x170014B8 RID: 5304
		// (get) Token: 0x06004BE3 RID: 19427 RVA: 0x000EDC7C File Offset: 0x000EC07C
		public int OpenLevel
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004BE4 RID: 19428 RVA: 0x000EDCC8 File Offset: 0x000EC0C8
		public int RefreshCostArray(int j)
		{
			int num = this.__p.__offset(46);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014B9 RID: 5305
		// (get) Token: 0x06004BE5 RID: 19429 RVA: 0x000EDD18 File Offset: 0x000EC118
		public int RefreshCostLength
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BE6 RID: 19430 RVA: 0x000EDD4B File Offset: 0x000EC14B
		public ArraySegment<byte>? GetRefreshCostBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x170014BA RID: 5306
		// (get) Token: 0x06004BE7 RID: 19431 RVA: 0x000EDD5A File Offset: 0x000EC15A
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

		// Token: 0x06004BE8 RID: 19432 RVA: 0x000EDD8C File Offset: 0x000EC18C
		public int RefreshTimeArray(int j)
		{
			int num = this.__p.__offset(48);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014BB RID: 5307
		// (get) Token: 0x06004BE9 RID: 19433 RVA: 0x000EDDDC File Offset: 0x000EC1DC
		public int RefreshTimeLength
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BEA RID: 19434 RVA: 0x000EDE0F File Offset: 0x000EC20F
		public ArraySegment<byte>? GetRefreshTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x170014BC RID: 5308
		// (get) Token: 0x06004BEB RID: 19435 RVA: 0x000EDE1E File Offset: 0x000EC21E
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

		// Token: 0x170014BD RID: 5309
		// (get) Token: 0x06004BEC RID: 19436 RVA: 0x000EDE50 File Offset: 0x000EC250
		public int OnSaleNum
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004BED RID: 19437 RVA: 0x000EDE9C File Offset: 0x000EC29C
		public ShopTable.eSubTypeOrder SubTypeOrderArray(int j)
		{
			int num = this.__p.__offset(52);
			return (ShopTable.eSubTypeOrder)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014BE RID: 5310
		// (get) Token: 0x06004BEE RID: 19438 RVA: 0x000EDEE4 File Offset: 0x000EC2E4
		public int SubTypeOrderLength
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BEF RID: 19439 RVA: 0x000EDF17 File Offset: 0x000EC317
		public ArraySegment<byte>? GetSubTypeOrderBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x170014BF RID: 5311
		// (get) Token: 0x06004BF0 RID: 19440 RVA: 0x000EDF26 File Offset: 0x000EC326
		public FlatBufferArray<ShopTable.eSubTypeOrder> SubTypeOrder
		{
			get
			{
				if (this.SubTypeOrderValue == null)
				{
					this.SubTypeOrderValue = new FlatBufferArray<ShopTable.eSubTypeOrder>(new Func<int, ShopTable.eSubTypeOrder>(this.SubTypeOrderArray), this.SubTypeOrderLength);
				}
				return this.SubTypeOrderValue;
			}
		}

		// Token: 0x170014C0 RID: 5312
		// (get) Token: 0x06004BF1 RID: 19441 RVA: 0x000EDF58 File Offset: 0x000EC358
		public int LimitGood1
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014C1 RID: 5313
		// (get) Token: 0x06004BF2 RID: 19442 RVA: 0x000EDFA4 File Offset: 0x000EC3A4
		public int LimitGood2
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004BF3 RID: 19443 RVA: 0x000EDFF0 File Offset: 0x000EC3F0
		public int VIPLvArray(int j)
		{
			int num = this.__p.__offset(58);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014C2 RID: 5314
		// (get) Token: 0x06004BF4 RID: 19444 RVA: 0x000EE040 File Offset: 0x000EC440
		public int VIPLvLength
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BF5 RID: 19445 RVA: 0x000EE073 File Offset: 0x000EC473
		public ArraySegment<byte>? GetVIPLvBytes()
		{
			return this.__p.__vector_as_arraysegment(58);
		}

		// Token: 0x170014C3 RID: 5315
		// (get) Token: 0x06004BF6 RID: 19446 RVA: 0x000EE082 File Offset: 0x000EC482
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

		// Token: 0x06004BF7 RID: 19447 RVA: 0x000EE0B4 File Offset: 0x000EC4B4
		public int VIPDiscountArray(int j)
		{
			int num = this.__p.__offset(60);
			return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170014C4 RID: 5316
		// (get) Token: 0x06004BF8 RID: 19448 RVA: 0x000EE104 File Offset: 0x000EC504
		public int VIPDiscountLength
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004BF9 RID: 19449 RVA: 0x000EE137 File Offset: 0x000EC537
		public ArraySegment<byte>? GetVIPDiscountBytes()
		{
			return this.__p.__vector_as_arraysegment(60);
		}

		// Token: 0x170014C5 RID: 5317
		// (get) Token: 0x06004BFA RID: 19450 RVA: 0x000EE146 File Offset: 0x000EC546
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

		// Token: 0x170014C6 RID: 5318
		// (get) Token: 0x06004BFB RID: 19451 RVA: 0x000EE178 File Offset: 0x000EC578
		public int Version
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014C7 RID: 5319
		// (get) Token: 0x06004BFC RID: 19452 RVA: 0x000EE1C4 File Offset: 0x000EC5C4
		public string ShopNpcBody
		{
			get
			{
				int num = this.__p.__offset(64);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004BFD RID: 19453 RVA: 0x000EE207 File Offset: 0x000EC607
		public ArraySegment<byte>? GetShopNpcBodyBytes()
		{
			return this.__p.__vector_as_arraysegment(64);
		}

		// Token: 0x170014C8 RID: 5320
		// (get) Token: 0x06004BFE RID: 19454 RVA: 0x000EE218 File Offset: 0x000EC618
		public int RareControlType
		{
			get
			{
				int num = this.__p.__offset(66);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014C9 RID: 5321
		// (get) Token: 0x06004BFF RID: 19455 RVA: 0x000EE264 File Offset: 0x000EC664
		public int IsExchangeShopShow
		{
			get
			{
				int num = this.__p.__offset(68);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014CA RID: 5322
		// (get) Token: 0x06004C00 RID: 19456 RVA: 0x000EE2B0 File Offset: 0x000EC6B0
		public int ExchangeShopOrder
		{
			get
			{
				int num = this.__p.__offset(70);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014CB RID: 5323
		// (get) Token: 0x06004C01 RID: 19457 RVA: 0x000EE2FC File Offset: 0x000EC6FC
		public string ExchangeShopShowImage
		{
			get
			{
				int num = this.__p.__offset(72);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C02 RID: 19458 RVA: 0x000EE33F File Offset: 0x000EC73F
		public ArraySegment<byte>? GetExchangeShopShowImageBytes()
		{
			return this.__p.__vector_as_arraysegment(72);
		}

		// Token: 0x170014CC RID: 5324
		// (get) Token: 0x06004C03 RID: 19459 RVA: 0x000EE350 File Offset: 0x000EC750
		public string ExchangeShopNameImage
		{
			get
			{
				int num = this.__p.__offset(74);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C04 RID: 19460 RVA: 0x000EE393 File Offset: 0x000EC793
		public ArraySegment<byte>? GetExchangeShopNameImageBytes()
		{
			return this.__p.__vector_as_arraysegment(74);
		}

		// Token: 0x170014CD RID: 5325
		// (get) Token: 0x06004C05 RID: 19461 RVA: 0x000EE3A4 File Offset: 0x000EC7A4
		public ShopTable.eBindType BindType
		{
			get
			{
				int num = this.__p.__offset(76);
				return (ShopTable.eBindType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014CE RID: 5326
		// (get) Token: 0x06004C06 RID: 19462 RVA: 0x000EE3E8 File Offset: 0x000EC7E8
		public int HonorDiscount
		{
			get
			{
				int num = this.__p.__offset(78);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170014CF RID: 5327
		// (get) Token: 0x06004C07 RID: 19463 RVA: 0x000EE434 File Offset: 0x000EC834
		public string ShopItemRefreshDesc
		{
			get
			{
				int num = this.__p.__offset(80);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004C08 RID: 19464 RVA: 0x000EE477 File Offset: 0x000EC877
		public ArraySegment<byte>? GetShopItemRefreshDescBytes()
		{
			return this.__p.__vector_as_arraysegment(80);
		}

		// Token: 0x170014D0 RID: 5328
		// (get) Token: 0x06004C09 RID: 19465 RVA: 0x000EE488 File Offset: 0x000EC888
		public int CurrencyShowType
		{
			get
			{
				int num = this.__p.__offset(82);
				return (num == 0) ? 0 : (182865018 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004C0A RID: 19466 RVA: 0x000EE4D4 File Offset: 0x000EC8D4
		public string CurrencyExtraItemArray(int j)
		{
			int num = this.__p.__offset(84);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170014D1 RID: 5329
		// (get) Token: 0x06004C0B RID: 19467 RVA: 0x000EE51C File Offset: 0x000EC91C
		public int CurrencyExtraItemLength
		{
			get
			{
				int num = this.__p.__offset(84);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170014D2 RID: 5330
		// (get) Token: 0x06004C0C RID: 19468 RVA: 0x000EE54F File Offset: 0x000EC94F
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

		// Token: 0x06004C0D RID: 19469 RVA: 0x000EE580 File Offset: 0x000EC980
		public static Offset<ShopTable> CreateShopTable(FlatBufferBuilder builder, int ID = 0, StringOffset ShopNameOffset = default(StringOffset), StringOffset ShopNamePathOffset = default(StringOffset), StringOffset ShopMallIconOffset = default(StringOffset), StringOffset ShopSimpleNameOffset = default(StringOffset), StringOffset LinkOffset = default(StringOffset), ShopTable.eShopKind ShopKind = ShopTable.eShopKind.SK_Ancient, int HelpID = 0, int Param1 = 0, int IsGuildShop = 0, VectorOffset ChildrenOffset = default(VectorOffset), VectorOffset FilterOffset = default(VectorOffset), VectorOffset Filter2Offset = default(VectorOffset), VectorOffset HideFilterItemOffset = default(VectorOffset), VectorOffset IsShowFilterTitleOffset = default(VectorOffset), VectorOffset SubTypeOffset = default(VectorOffset), StringOffset ExtraShowMoneysOffset = default(StringOffset), VectorOffset NeedRefreshTabsOffset = default(VectorOffset), int Refresh = 0, VectorOffset RefreshCycleOffset = default(VectorOffset), int OpenLevel = 0, VectorOffset RefreshCostOffset = default(VectorOffset), VectorOffset RefreshTimeOffset = default(VectorOffset), int OnSaleNum = 0, VectorOffset SubTypeOrderOffset = default(VectorOffset), int LimitGood1 = 0, int LimitGood2 = 0, VectorOffset VIPLvOffset = default(VectorOffset), VectorOffset VIPDiscountOffset = default(VectorOffset), int Version = 0, StringOffset ShopNpcBodyOffset = default(StringOffset), int RareControlType = 0, int IsExchangeShopShow = 0, int ExchangeShopOrder = 0, StringOffset ExchangeShopShowImageOffset = default(StringOffset), StringOffset ExchangeShopNameImageOffset = default(StringOffset), ShopTable.eBindType BindType = ShopTable.eBindType.ROLE_BIND, int HonorDiscount = 0, StringOffset ShopItemRefreshDescOffset = default(StringOffset), int CurrencyShowType = 0, VectorOffset CurrencyExtraItemOffset = default(VectorOffset))
		{
			builder.StartObject(41);
			ShopTable.AddCurrencyExtraItem(builder, CurrencyExtraItemOffset);
			ShopTable.AddCurrencyShowType(builder, CurrencyShowType);
			ShopTable.AddShopItemRefreshDesc(builder, ShopItemRefreshDescOffset);
			ShopTable.AddHonorDiscount(builder, HonorDiscount);
			ShopTable.AddBindType(builder, BindType);
			ShopTable.AddExchangeShopNameImage(builder, ExchangeShopNameImageOffset);
			ShopTable.AddExchangeShopShowImage(builder, ExchangeShopShowImageOffset);
			ShopTable.AddExchangeShopOrder(builder, ExchangeShopOrder);
			ShopTable.AddIsExchangeShopShow(builder, IsExchangeShopShow);
			ShopTable.AddRareControlType(builder, RareControlType);
			ShopTable.AddShopNpcBody(builder, ShopNpcBodyOffset);
			ShopTable.AddVersion(builder, Version);
			ShopTable.AddVIPDiscount(builder, VIPDiscountOffset);
			ShopTable.AddVIPLv(builder, VIPLvOffset);
			ShopTable.AddLimitGood2(builder, LimitGood2);
			ShopTable.AddLimitGood1(builder, LimitGood1);
			ShopTable.AddSubTypeOrder(builder, SubTypeOrderOffset);
			ShopTable.AddOnSaleNum(builder, OnSaleNum);
			ShopTable.AddRefreshTime(builder, RefreshTimeOffset);
			ShopTable.AddRefreshCost(builder, RefreshCostOffset);
			ShopTable.AddOpenLevel(builder, OpenLevel);
			ShopTable.AddRefreshCycle(builder, RefreshCycleOffset);
			ShopTable.AddRefresh(builder, Refresh);
			ShopTable.AddNeedRefreshTabs(builder, NeedRefreshTabsOffset);
			ShopTable.AddExtraShowMoneys(builder, ExtraShowMoneysOffset);
			ShopTable.AddSubType(builder, SubTypeOffset);
			ShopTable.AddIsShowFilterTitle(builder, IsShowFilterTitleOffset);
			ShopTable.AddHideFilterItem(builder, HideFilterItemOffset);
			ShopTable.AddFilter2(builder, Filter2Offset);
			ShopTable.AddFilter(builder, FilterOffset);
			ShopTable.AddChildren(builder, ChildrenOffset);
			ShopTable.AddIsGuildShop(builder, IsGuildShop);
			ShopTable.AddParam1(builder, Param1);
			ShopTable.AddHelpID(builder, HelpID);
			ShopTable.AddShopKind(builder, ShopKind);
			ShopTable.AddLink(builder, LinkOffset);
			ShopTable.AddShopSimpleName(builder, ShopSimpleNameOffset);
			ShopTable.AddShopMallIcon(builder, ShopMallIconOffset);
			ShopTable.AddShopNamePath(builder, ShopNamePathOffset);
			ShopTable.AddShopName(builder, ShopNameOffset);
			ShopTable.AddID(builder, ID);
			return ShopTable.EndShopTable(builder);
		}

		// Token: 0x06004C0E RID: 19470 RVA: 0x000EE6E0 File Offset: 0x000ECAE0
		public static void StartShopTable(FlatBufferBuilder builder)
		{
			builder.StartObject(41);
		}

		// Token: 0x06004C0F RID: 19471 RVA: 0x000EE6EA File Offset: 0x000ECAEA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004C10 RID: 19472 RVA: 0x000EE6F5 File Offset: 0x000ECAF5
		public static void AddShopName(FlatBufferBuilder builder, StringOffset ShopNameOffset)
		{
			builder.AddOffset(1, ShopNameOffset.Value, 0);
		}

		// Token: 0x06004C11 RID: 19473 RVA: 0x000EE706 File Offset: 0x000ECB06
		public static void AddShopNamePath(FlatBufferBuilder builder, StringOffset ShopNamePathOffset)
		{
			builder.AddOffset(2, ShopNamePathOffset.Value, 0);
		}

		// Token: 0x06004C12 RID: 19474 RVA: 0x000EE717 File Offset: 0x000ECB17
		public static void AddShopMallIcon(FlatBufferBuilder builder, StringOffset ShopMallIconOffset)
		{
			builder.AddOffset(3, ShopMallIconOffset.Value, 0);
		}

		// Token: 0x06004C13 RID: 19475 RVA: 0x000EE728 File Offset: 0x000ECB28
		public static void AddShopSimpleName(FlatBufferBuilder builder, StringOffset ShopSimpleNameOffset)
		{
			builder.AddOffset(4, ShopSimpleNameOffset.Value, 0);
		}

		// Token: 0x06004C14 RID: 19476 RVA: 0x000EE739 File Offset: 0x000ECB39
		public static void AddLink(FlatBufferBuilder builder, StringOffset LinkOffset)
		{
			builder.AddOffset(5, LinkOffset.Value, 0);
		}

		// Token: 0x06004C15 RID: 19477 RVA: 0x000EE74A File Offset: 0x000ECB4A
		public static void AddShopKind(FlatBufferBuilder builder, ShopTable.eShopKind ShopKind)
		{
			builder.AddInt(6, (int)ShopKind, 0);
		}

		// Token: 0x06004C16 RID: 19478 RVA: 0x000EE755 File Offset: 0x000ECB55
		public static void AddHelpID(FlatBufferBuilder builder, int HelpID)
		{
			builder.AddInt(7, HelpID, 0);
		}

		// Token: 0x06004C17 RID: 19479 RVA: 0x000EE760 File Offset: 0x000ECB60
		public static void AddParam1(FlatBufferBuilder builder, int Param1)
		{
			builder.AddInt(8, Param1, 0);
		}

		// Token: 0x06004C18 RID: 19480 RVA: 0x000EE76B File Offset: 0x000ECB6B
		public static void AddIsGuildShop(FlatBufferBuilder builder, int IsGuildShop)
		{
			builder.AddInt(9, IsGuildShop, 0);
		}

		// Token: 0x06004C19 RID: 19481 RVA: 0x000EE777 File Offset: 0x000ECB77
		public static void AddChildren(FlatBufferBuilder builder, VectorOffset ChildrenOffset)
		{
			builder.AddOffset(10, ChildrenOffset.Value, 0);
		}

		// Token: 0x06004C1A RID: 19482 RVA: 0x000EE78C File Offset: 0x000ECB8C
		public static VectorOffset CreateChildrenVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C1B RID: 19483 RVA: 0x000EE7C9 File Offset: 0x000ECBC9
		public static void StartChildrenVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C1C RID: 19484 RVA: 0x000EE7D4 File Offset: 0x000ECBD4
		public static void AddFilter(FlatBufferBuilder builder, VectorOffset FilterOffset)
		{
			builder.AddOffset(11, FilterOffset.Value, 0);
		}

		// Token: 0x06004C1D RID: 19485 RVA: 0x000EE7E8 File Offset: 0x000ECBE8
		public static VectorOffset CreateFilterVector(FlatBufferBuilder builder, ShopTable.eFilter[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C1E RID: 19486 RVA: 0x000EE825 File Offset: 0x000ECC25
		public static void StartFilterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C1F RID: 19487 RVA: 0x000EE830 File Offset: 0x000ECC30
		public static void AddFilter2(FlatBufferBuilder builder, VectorOffset Filter2Offset)
		{
			builder.AddOffset(12, Filter2Offset.Value, 0);
		}

		// Token: 0x06004C20 RID: 19488 RVA: 0x000EE844 File Offset: 0x000ECC44
		public static VectorOffset CreateFilter2Vector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C21 RID: 19489 RVA: 0x000EE881 File Offset: 0x000ECC81
		public static void StartFilter2Vector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C22 RID: 19490 RVA: 0x000EE88C File Offset: 0x000ECC8C
		public static void AddHideFilterItem(FlatBufferBuilder builder, VectorOffset HideFilterItemOffset)
		{
			builder.AddOffset(13, HideFilterItemOffset.Value, 0);
		}

		// Token: 0x06004C23 RID: 19491 RVA: 0x000EE8A0 File Offset: 0x000ECCA0
		public static VectorOffset CreateHideFilterItemVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C24 RID: 19492 RVA: 0x000EE8DD File Offset: 0x000ECCDD
		public static void StartHideFilterItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C25 RID: 19493 RVA: 0x000EE8E8 File Offset: 0x000ECCE8
		public static void AddIsShowFilterTitle(FlatBufferBuilder builder, VectorOffset IsShowFilterTitleOffset)
		{
			builder.AddOffset(14, IsShowFilterTitleOffset.Value, 0);
		}

		// Token: 0x06004C26 RID: 19494 RVA: 0x000EE8FC File Offset: 0x000ECCFC
		public static VectorOffset CreateIsShowFilterTitleVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C27 RID: 19495 RVA: 0x000EE939 File Offset: 0x000ECD39
		public static void StartIsShowFilterTitleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C28 RID: 19496 RVA: 0x000EE944 File Offset: 0x000ECD44
		public static void AddSubType(FlatBufferBuilder builder, VectorOffset SubTypeOffset)
		{
			builder.AddOffset(15, SubTypeOffset.Value, 0);
		}

		// Token: 0x06004C29 RID: 19497 RVA: 0x000EE958 File Offset: 0x000ECD58
		public static VectorOffset CreateSubTypeVector(FlatBufferBuilder builder, ShopTable.eSubType[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C2A RID: 19498 RVA: 0x000EE995 File Offset: 0x000ECD95
		public static void StartSubTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C2B RID: 19499 RVA: 0x000EE9A0 File Offset: 0x000ECDA0
		public static void AddExtraShowMoneys(FlatBufferBuilder builder, StringOffset ExtraShowMoneysOffset)
		{
			builder.AddOffset(16, ExtraShowMoneysOffset.Value, 0);
		}

		// Token: 0x06004C2C RID: 19500 RVA: 0x000EE9B2 File Offset: 0x000ECDB2
		public static void AddNeedRefreshTabs(FlatBufferBuilder builder, VectorOffset NeedRefreshTabsOffset)
		{
			builder.AddOffset(17, NeedRefreshTabsOffset.Value, 0);
		}

		// Token: 0x06004C2D RID: 19501 RVA: 0x000EE9C4 File Offset: 0x000ECDC4
		public static VectorOffset CreateNeedRefreshTabsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C2E RID: 19502 RVA: 0x000EEA01 File Offset: 0x000ECE01
		public static void StartNeedRefreshTabsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C2F RID: 19503 RVA: 0x000EEA0C File Offset: 0x000ECE0C
		public static void AddRefresh(FlatBufferBuilder builder, int Refresh)
		{
			builder.AddInt(18, Refresh, 0);
		}

		// Token: 0x06004C30 RID: 19504 RVA: 0x000EEA18 File Offset: 0x000ECE18
		public static void AddRefreshCycle(FlatBufferBuilder builder, VectorOffset RefreshCycleOffset)
		{
			builder.AddOffset(19, RefreshCycleOffset.Value, 0);
		}

		// Token: 0x06004C31 RID: 19505 RVA: 0x000EEA2C File Offset: 0x000ECE2C
		public static VectorOffset CreateRefreshCycleVector(FlatBufferBuilder builder, ShopTable.eRefreshCycle[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C32 RID: 19506 RVA: 0x000EEA69 File Offset: 0x000ECE69
		public static void StartRefreshCycleVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C33 RID: 19507 RVA: 0x000EEA74 File Offset: 0x000ECE74
		public static void AddOpenLevel(FlatBufferBuilder builder, int OpenLevel)
		{
			builder.AddInt(20, OpenLevel, 0);
		}

		// Token: 0x06004C34 RID: 19508 RVA: 0x000EEA80 File Offset: 0x000ECE80
		public static void AddRefreshCost(FlatBufferBuilder builder, VectorOffset RefreshCostOffset)
		{
			builder.AddOffset(21, RefreshCostOffset.Value, 0);
		}

		// Token: 0x06004C35 RID: 19509 RVA: 0x000EEA94 File Offset: 0x000ECE94
		public static VectorOffset CreateRefreshCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C36 RID: 19510 RVA: 0x000EEAD1 File Offset: 0x000ECED1
		public static void StartRefreshCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C37 RID: 19511 RVA: 0x000EEADC File Offset: 0x000ECEDC
		public static void AddRefreshTime(FlatBufferBuilder builder, VectorOffset RefreshTimeOffset)
		{
			builder.AddOffset(22, RefreshTimeOffset.Value, 0);
		}

		// Token: 0x06004C38 RID: 19512 RVA: 0x000EEAF0 File Offset: 0x000ECEF0
		public static VectorOffset CreateRefreshTimeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C39 RID: 19513 RVA: 0x000EEB2D File Offset: 0x000ECF2D
		public static void StartRefreshTimeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C3A RID: 19514 RVA: 0x000EEB38 File Offset: 0x000ECF38
		public static void AddOnSaleNum(FlatBufferBuilder builder, int OnSaleNum)
		{
			builder.AddInt(23, OnSaleNum, 0);
		}

		// Token: 0x06004C3B RID: 19515 RVA: 0x000EEB44 File Offset: 0x000ECF44
		public static void AddSubTypeOrder(FlatBufferBuilder builder, VectorOffset SubTypeOrderOffset)
		{
			builder.AddOffset(24, SubTypeOrderOffset.Value, 0);
		}

		// Token: 0x06004C3C RID: 19516 RVA: 0x000EEB58 File Offset: 0x000ECF58
		public static VectorOffset CreateSubTypeOrderVector(FlatBufferBuilder builder, ShopTable.eSubTypeOrder[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C3D RID: 19517 RVA: 0x000EEB95 File Offset: 0x000ECF95
		public static void StartSubTypeOrderVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C3E RID: 19518 RVA: 0x000EEBA0 File Offset: 0x000ECFA0
		public static void AddLimitGood1(FlatBufferBuilder builder, int LimitGood1)
		{
			builder.AddInt(25, LimitGood1, 0);
		}

		// Token: 0x06004C3F RID: 19519 RVA: 0x000EEBAC File Offset: 0x000ECFAC
		public static void AddLimitGood2(FlatBufferBuilder builder, int LimitGood2)
		{
			builder.AddInt(26, LimitGood2, 0);
		}

		// Token: 0x06004C40 RID: 19520 RVA: 0x000EEBB8 File Offset: 0x000ECFB8
		public static void AddVIPLv(FlatBufferBuilder builder, VectorOffset VIPLvOffset)
		{
			builder.AddOffset(27, VIPLvOffset.Value, 0);
		}

		// Token: 0x06004C41 RID: 19521 RVA: 0x000EEBCC File Offset: 0x000ECFCC
		public static VectorOffset CreateVIPLvVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C42 RID: 19522 RVA: 0x000EEC09 File Offset: 0x000ED009
		public static void StartVIPLvVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C43 RID: 19523 RVA: 0x000EEC14 File Offset: 0x000ED014
		public static void AddVIPDiscount(FlatBufferBuilder builder, VectorOffset VIPDiscountOffset)
		{
			builder.AddOffset(28, VIPDiscountOffset.Value, 0);
		}

		// Token: 0x06004C44 RID: 19524 RVA: 0x000EEC28 File Offset: 0x000ED028
		public static VectorOffset CreateVIPDiscountVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C45 RID: 19525 RVA: 0x000EEC65 File Offset: 0x000ED065
		public static void StartVIPDiscountVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C46 RID: 19526 RVA: 0x000EEC70 File Offset: 0x000ED070
		public static void AddVersion(FlatBufferBuilder builder, int Version)
		{
			builder.AddInt(29, Version, 0);
		}

		// Token: 0x06004C47 RID: 19527 RVA: 0x000EEC7C File Offset: 0x000ED07C
		public static void AddShopNpcBody(FlatBufferBuilder builder, StringOffset ShopNpcBodyOffset)
		{
			builder.AddOffset(30, ShopNpcBodyOffset.Value, 0);
		}

		// Token: 0x06004C48 RID: 19528 RVA: 0x000EEC8E File Offset: 0x000ED08E
		public static void AddRareControlType(FlatBufferBuilder builder, int RareControlType)
		{
			builder.AddInt(31, RareControlType, 0);
		}

		// Token: 0x06004C49 RID: 19529 RVA: 0x000EEC9A File Offset: 0x000ED09A
		public static void AddIsExchangeShopShow(FlatBufferBuilder builder, int IsExchangeShopShow)
		{
			builder.AddInt(32, IsExchangeShopShow, 0);
		}

		// Token: 0x06004C4A RID: 19530 RVA: 0x000EECA6 File Offset: 0x000ED0A6
		public static void AddExchangeShopOrder(FlatBufferBuilder builder, int ExchangeShopOrder)
		{
			builder.AddInt(33, ExchangeShopOrder, 0);
		}

		// Token: 0x06004C4B RID: 19531 RVA: 0x000EECB2 File Offset: 0x000ED0B2
		public static void AddExchangeShopShowImage(FlatBufferBuilder builder, StringOffset ExchangeShopShowImageOffset)
		{
			builder.AddOffset(34, ExchangeShopShowImageOffset.Value, 0);
		}

		// Token: 0x06004C4C RID: 19532 RVA: 0x000EECC4 File Offset: 0x000ED0C4
		public static void AddExchangeShopNameImage(FlatBufferBuilder builder, StringOffset ExchangeShopNameImageOffset)
		{
			builder.AddOffset(35, ExchangeShopNameImageOffset.Value, 0);
		}

		// Token: 0x06004C4D RID: 19533 RVA: 0x000EECD6 File Offset: 0x000ED0D6
		public static void AddBindType(FlatBufferBuilder builder, ShopTable.eBindType BindType)
		{
			builder.AddInt(36, (int)BindType, 0);
		}

		// Token: 0x06004C4E RID: 19534 RVA: 0x000EECE2 File Offset: 0x000ED0E2
		public static void AddHonorDiscount(FlatBufferBuilder builder, int HonorDiscount)
		{
			builder.AddInt(37, HonorDiscount, 0);
		}

		// Token: 0x06004C4F RID: 19535 RVA: 0x000EECEE File Offset: 0x000ED0EE
		public static void AddShopItemRefreshDesc(FlatBufferBuilder builder, StringOffset ShopItemRefreshDescOffset)
		{
			builder.AddOffset(38, ShopItemRefreshDescOffset.Value, 0);
		}

		// Token: 0x06004C50 RID: 19536 RVA: 0x000EED00 File Offset: 0x000ED100
		public static void AddCurrencyShowType(FlatBufferBuilder builder, int CurrencyShowType)
		{
			builder.AddInt(39, CurrencyShowType, 0);
		}

		// Token: 0x06004C51 RID: 19537 RVA: 0x000EED0C File Offset: 0x000ED10C
		public static void AddCurrencyExtraItem(FlatBufferBuilder builder, VectorOffset CurrencyExtraItemOffset)
		{
			builder.AddOffset(40, CurrencyExtraItemOffset.Value, 0);
		}

		// Token: 0x06004C52 RID: 19538 RVA: 0x000EED20 File Offset: 0x000ED120
		public static VectorOffset CreateCurrencyExtraItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06004C53 RID: 19539 RVA: 0x000EED66 File Offset: 0x000ED166
		public static void StartCurrencyExtraItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004C54 RID: 19540 RVA: 0x000EED74 File Offset: 0x000ED174
		public static Offset<ShopTable> EndShopTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ShopTable>(value);
		}

		// Token: 0x06004C55 RID: 19541 RVA: 0x000EED8E File Offset: 0x000ED18E
		public static void FinishShopTableBuffer(FlatBufferBuilder builder, Offset<ShopTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B2F RID: 6959
		private Table __p = new Table();

		// Token: 0x04001B30 RID: 6960
		private FlatBufferArray<int> ChildrenValue;

		// Token: 0x04001B31 RID: 6961
		private FlatBufferArray<ShopTable.eFilter> FilterValue;

		// Token: 0x04001B32 RID: 6962
		private FlatBufferArray<int> Filter2Value;

		// Token: 0x04001B33 RID: 6963
		private FlatBufferArray<int> HideFilterItemValue;

		// Token: 0x04001B34 RID: 6964
		private FlatBufferArray<int> IsShowFilterTitleValue;

		// Token: 0x04001B35 RID: 6965
		private FlatBufferArray<ShopTable.eSubType> SubTypeValue;

		// Token: 0x04001B36 RID: 6966
		private FlatBufferArray<int> NeedRefreshTabsValue;

		// Token: 0x04001B37 RID: 6967
		private FlatBufferArray<ShopTable.eRefreshCycle> RefreshCycleValue;

		// Token: 0x04001B38 RID: 6968
		private FlatBufferArray<int> RefreshCostValue;

		// Token: 0x04001B39 RID: 6969
		private FlatBufferArray<int> RefreshTimeValue;

		// Token: 0x04001B3A RID: 6970
		private FlatBufferArray<ShopTable.eSubTypeOrder> SubTypeOrderValue;

		// Token: 0x04001B3B RID: 6971
		private FlatBufferArray<int> VIPLvValue;

		// Token: 0x04001B3C RID: 6972
		private FlatBufferArray<int> VIPDiscountValue;

		// Token: 0x04001B3D RID: 6973
		private FlatBufferArray<string> CurrencyExtraItemValue;

		// Token: 0x020005B4 RID: 1460
		public enum eShopKind
		{
			// Token: 0x04001B3F RID: 6975
			SK_Ancient,
			// Token: 0x04001B40 RID: 6976
			SK_Mystery,
			// Token: 0x04001B41 RID: 6977
			SK_Forge,
			// Token: 0x04001B42 RID: 6978
			SK_Brave,
			// Token: 0x04001B43 RID: 6979
			SK_Fight,
			// Token: 0x04001B44 RID: 6980
			SK_Guild,
			// Token: 0x04001B45 RID: 6981
			SK_Magic,
			// Token: 0x04001B46 RID: 6982
			SK_Gold,
			// Token: 0x04001B47 RID: 6983
			SK_Abyss,
			// Token: 0x04001B48 RID: 6984
			SK_Warehouse,
			// Token: 0x04001B49 RID: 6985
			SK_Activity,
			// Token: 0x04001B4A RID: 6986
			SK_Master = 12,
			// Token: 0x04001B4B RID: 6987
			SK_Lease,
			// Token: 0x04001B4C RID: 6988
			SK_BlessCrystal,
			// Token: 0x04001B4D RID: 6989
			SK_BindCoin = 17,
			// Token: 0x04001B4E RID: 6990
			SK_AdventureCoin,
			// Token: 0x04001B4F RID: 6991
			SK_RecruitShop,
			// Token: 0x04001B50 RID: 6992
			SK_SeasonShop,
			// Token: 0x04001B51 RID: 6993
			SK_Monopoly,
			// Token: 0x04001B52 RID: 6994
			SK_MysteryShop
		}

		// Token: 0x020005B5 RID: 1461
		public enum eFilter
		{
			// Token: 0x04001B54 RID: 6996
			SF_NONE,
			// Token: 0x04001B55 RID: 6997
			SF_OCCU,
			// Token: 0x04001B56 RID: 6998
			SF_ARMOR,
			// Token: 0x04001B57 RID: 6999
			SF_OCCU2,
			// Token: 0x04001B58 RID: 7000
			SF_PLAY_OCCU,
			// Token: 0x04001B59 RID: 7001
			SF_LEVEL,
			// Token: 0x04001B5A RID: 7002
			SF_LEVEL_2,
			// Token: 0x04001B5B RID: 7003
			SF_NUM
		}

		// Token: 0x020005B6 RID: 1462
		public enum eSubType
		{
			// Token: 0x04001B5D RID: 7005
			ST_NONE,
			// Token: 0x04001B5E RID: 7006
			ST_MATERIAL,
			// Token: 0x04001B5F RID: 7007
			ST_WEAPON,
			// Token: 0x04001B60 RID: 7008
			ST_ARMOR,
			// Token: 0x04001B61 RID: 7009
			ST_JEWELRY,
			// Token: 0x04001B62 RID: 7010
			ST_COST,
			// Token: 0x04001B63 RID: 7011
			ST_VALUABLE,
			// Token: 0x04001B64 RID: 7012
			ST_RETINUE,
			// Token: 0x04001B65 RID: 7013
			ST_TITLE,
			// Token: 0x04001B66 RID: 7014
			ST_ENERGY,
			// Token: 0x04001B67 RID: 7015
			ST_FASHION,
			// Token: 0x04001B68 RID: 7016
			ST_ORDINARY,
			// Token: 0x04001B69 RID: 7017
			ST_DAILY,
			// Token: 0x04001B6A RID: 7018
			ST_GOODS,
			// Token: 0x04001B6B RID: 7019
			ST_EQUIP,
			// Token: 0x04001B6C RID: 7020
			ST_EXP,
			// Token: 0x04001B6D RID: 7021
			ST_GOLDJAR
		}

		// Token: 0x020005B7 RID: 1463
		public enum eRefreshCycle
		{
			// Token: 0x04001B6F RID: 7023
			REFRESH_CYCLE_NONE,
			// Token: 0x04001B70 RID: 7024
			REFRESH_CYCLE_DAILY,
			// Token: 0x04001B71 RID: 7025
			REFRESH_CYCLE_WEEK,
			// Token: 0x04001B72 RID: 7026
			REFRESH_CYCLE_MONTH,
			// Token: 0x04001B73 RID: 7027
			REFRESH_CYCLE_ACTIVITY
		}

		// Token: 0x020005B8 RID: 1464
		public enum eSubTypeOrder
		{
			// Token: 0x04001B75 RID: 7029
			STO_NONE,
			// Token: 0x04001B76 RID: 7030
			STO_EQUIP,
			// Token: 0x04001B77 RID: 7031
			STO_EXPENDABLE,
			// Token: 0x04001B78 RID: 7032
			STO_MATERIAL,
			// Token: 0x04001B79 RID: 7033
			STO_TASK,
			// Token: 0x04001B7A RID: 7034
			STO_FASHION
		}

		// Token: 0x020005B9 RID: 1465
		public enum eBindType
		{
			// Token: 0x04001B7C RID: 7036
			ROLE_BIND,
			// Token: 0x04001B7D RID: 7037
			ACCOUNT_BIND
		}

		// Token: 0x020005BA RID: 1466
		public enum eCrypt
		{
			// Token: 0x04001B7F RID: 7039
			code = 182865018
		}
	}
}
