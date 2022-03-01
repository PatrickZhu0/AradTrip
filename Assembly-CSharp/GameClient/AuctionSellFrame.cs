using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001456 RID: 5206
	internal class AuctionSellFrame : ClientFrame
	{
		// Token: 0x0600CA02 RID: 51714 RVA: 0x003164EA File Offset: 0x003148EA
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Auction/AuctionSellFrame";
		}

		// Token: 0x0600CA03 RID: 51715 RVA: 0x003164F4 File Offset: 0x003148F4
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.bInputModify = false;
			this.SellBaseData = (AuctionSellBaseData)this.userData;
			this.InitInterface();
			this.SendWorldAuctionQueryItemPricesReq();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600CA04 RID: 51716 RVA: 0x0031654C File Offset: 0x0031494C
		protected sealed override void _OnCloseFrame()
		{
			this.ClearData();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600CA05 RID: 51717 RVA: 0x00316570 File Offset: 0x00314970
		protected ulong _backSpaceNumber(ulong num)
		{
			if (num < 10UL)
			{
				num = 1UL;
				this.isTrueNum = false;
			}
			else
			{
				ulong num2 = num / 10UL;
				num = num2;
			}
			return num;
		}

		// Token: 0x0600CA06 RID: 51718 RVA: 0x003165A0 File Offset: 0x003149A0
		protected ulong _AddInputNumber(ulong currentNum, ulong addNum)
		{
			if (addNum < 0UL || addNum > 9UL)
			{
				Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
				return currentNum;
			}
			ulong num;
			if (!this.isTrueNum)
			{
				if (addNum != 0UL)
				{
					num = addNum;
					this.isTrueNum = true;
				}
				else
				{
					num = 1UL;
					this.isTrueNum = false;
				}
			}
			else
			{
				num = currentNum * 10UL + addNum;
			}
			if (num < 1UL)
			{
				Logger.LogErrorFormat("userInputPrice is error", new object[0]);
			}
			return num;
		}

		// Token: 0x0600CA07 RID: 51719 RVA: 0x00316623 File Offset: 0x00314A23
		private int CalcInt(int value, int step, bool bFloor)
		{
			return (value + ((!bFloor) ? (step - 1) : 0)) / step * step;
		}

		// Token: 0x0600CA08 RID: 51720 RVA: 0x0031663A File Offset: 0x00314A3A
		private ulong GetPriceByRate(int Rate)
		{
			return (ulong)(this.ivisAverPrice * (ulong)((long)Rate) / 100f);
		}

		// Token: 0x0600CA09 RID: 51721 RVA: 0x0031664E File Offset: 0x00314A4E
		private int GetPlusNextRate(int Rate)
		{
			if (Rate >= 10)
			{
				return Rate + 10;
			}
			if (Rate < 10 && Rate >= 2)
			{
				return Rate + 2;
			}
			if (Rate < 2)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x0600CA0A RID: 51722 RVA: 0x0031667A File Offset: 0x00314A7A
		private int GetMinusNextRate(int Rate)
		{
			if (Rate > 10)
			{
				return Rate - 10;
			}
			if (Rate <= 10 && Rate > 2)
			{
				return Rate - 2;
			}
			if (Rate <= 2)
			{
				return 1;
			}
			return 1;
		}

		// Token: 0x0600CA0B RID: 51723 RVA: 0x003166A8 File Offset: 0x00314AA8
		private int _CalcRate(ulong mCurrentPrice)
		{
			int num = (int)(mCurrentPrice * 100f / this.ivisAverPrice + 0.5f);
			if (num >= 10)
			{
				num = this.CalcInt(num, 10, true);
			}
			if (num < 10 && num >= 2)
			{
				num = this.CalcInt(num, 2, true);
			}
			if (num < 2)
			{
				num = 1;
			}
			return num;
		}

		// Token: 0x0600CA0C RID: 51724 RVA: 0x00316708 File Offset: 0x00314B08
		private void CalcRate(ulong mCurrentPrice, bool bFloor)
		{
			int num = this._CalcRate(mCurrentPrice);
			ulong priceByRate = this.GetPriceByRate(num);
			if (priceByRate < (ulong)this.mMinServerSinglePrice)
			{
				this.iRate = this.GetPlusNextRate(num);
				return;
			}
			if (priceByRate > (ulong)this.mMaxServerSinglePrice)
			{
				this.iRate = this.GetMinusNextRate(num);
				return;
			}
			if (mCurrentPrice == priceByRate)
			{
				this.iRate = num;
			}
			else if (mCurrentPrice > priceByRate)
			{
				int plusNextRate = this.GetPlusNextRate(num);
				if (mCurrentPrice == this.GetPriceByRate(plusNextRate))
				{
					this.iRate = plusNextRate;
				}
				else
				{
					this.iRate = ((!bFloor) ? plusNextRate : num);
				}
			}
			else if (mCurrentPrice < priceByRate)
			{
				int minusNextRate = this.GetMinusNextRate(num);
				if (mCurrentPrice == this.GetPriceByRate(minusNextRate))
				{
					this.iRate = minusNextRate;
				}
				else
				{
					this.iRate = ((!bFloor) ? num : minusNextRate);
				}
			}
		}

		// Token: 0x0600CA0D RID: 51725 RVA: 0x003167EC File Offset: 0x00314BEC
		private void UpdateRate(ulong mCurrentPrice)
		{
			int rate = this._CalcRate(mCurrentPrice);
			ulong priceByRate = this.GetPriceByRate(rate);
			if (priceByRate < (ulong)this.mMinServerSinglePrice)
			{
				this.iRate = this.GetPlusNextRate(rate);
			}
			if (priceByRate > (ulong)this.mMaxServerSinglePrice)
			{
				this.iRate = this.GetMinusNextRate(rate);
			}
		}

		// Token: 0x0600CA0E RID: 51726 RVA: 0x00316840 File Offset: 0x00314C40
		private void OnEnSureInputNum()
		{
			if (this.SellBaseData.IsTreasure)
			{
				this._UpdateTreasureNumMaxMinInfo();
				this.UpdateShowTreasureSellInfo();
				this.bInputModify = true;
			}
			else
			{
				if (this.isCount && this.ItemNum == this.mNumber)
				{
					return;
				}
				this.ItemNum = this.mNumber;
				if (this.ItemNum <= 0UL)
				{
					Logger.LogErrorFormat("数量为0！", new object[0]);
				}
				this.mPriceNumber = this.Clamp(this.mPriceNumber, (ulong)this.mMinServerSinglePrice, (ulong)this.mMaxServerSinglePrice);
				this.TotalPrice = this.mPriceNumber * this.ItemNum;
				this.SinglePrice = this.mPriceNumber;
				this.UpdateShowSellInfo();
				if (!this.isCount)
				{
					this.bInputModify = true;
				}
			}
		}

		// Token: 0x0600CA0F RID: 51727 RVA: 0x00316914 File Offset: 0x00314D14
		private void OnChangeNum(UIEvent iEvent)
		{
			this.changeNumType = (ChangeNumType)iEvent.Param1;
			if (this.changeNumType == ChangeNumType.EnSure)
			{
				this.OnEnSureInputNum();
				return;
			}
			ulong num = (this.SellBaseData.IsTreasure || !this.isCount) ? this.mPriceNumber : this.mNumber;
			if (this.changeNumType == ChangeNumType.BackSpace)
			{
				num = this._backSpaceNumber(num);
			}
			else if (this.changeNumType == ChangeNumType.Add)
			{
				int num2 = (int)iEvent.Param2;
				num = this._AddInputNumber(num, (ulong)((long)num2));
			}
			if (num <= 0UL || num.ToString().Length > 9)
			{
				return;
			}
			if (this.SellBaseData.IsTreasure)
			{
				this.mPriceNumber = Math.Min(num, (ulong)this.mMaxServerSinglePrice);
				this.mTreasureSinglePrice.text = this.mPriceNumber.ToString();
				this.mTreasureTotalPrice.text = this.mTreasureSinglePrice.text;
			}
			else
			{
				if (this.isCount)
				{
					ulong val = (ulong)((long)DataManager<AuctionDataManager>.GetInstance().GetItemNumByGUID(this.SellBaseData.PackageItemGuid, true));
					this.mNumber = Math.Min(val, num);
					this.ItemNum = this.mNumber;
				}
				else
				{
					this.mPriceNumber = Math.Min(num, (ulong)this.mMaxServerSinglePrice);
					this.SinglePrice = this.mPriceNumber;
				}
				this.TotalPrice = this.SinglePrice * this.ItemNum;
				this.UpdateShowSellInfo();
			}
		}

		// Token: 0x0600CA10 RID: 51728 RVA: 0x00316AA8 File Offset: 0x00314EA8
		private void ClearData()
		{
			this.iDeposit = 0;
			this.MaxPriceRate = 0;
			this.MinPriceRate = 0;
			this.RecoPrice = 1UL;
			this.ItemNum = 1UL;
			this.SinglePrice = 1UL;
			this.TotalPrice = 1UL;
			this.mMaxSinglePrice = 1UL;
			this.mMinSinglePrice = 1UL;
			this.iRate = 100;
			this.iStrengthRate = 0;
			this.iAveragePrice = 0UL;
			this.MaxAveragePriceRate = 0;
			this.MinAveragePriceRate = 0;
			this.mNumber = 1UL;
			this.mPriceNumber = 1UL;
			this.mAuctionOnSaleItemDateList.Clear();
			this.changeNumType = ChangeNumType.BackSpace;
			this.TransactionPrice = 0UL;
			this.treasureItemMaxPrice = 0UL;
		}

		// Token: 0x0600CA11 RID: 51729 RVA: 0x00316B54 File Offset: 0x00314F54
		private void InitInterface()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.SellBaseData.PackageItemGuid);
			if (item == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.InitSellData(item, tableItem);
			this.InitShowSellInfo(item);
			this.UpdateShowSellInfo();
			if (this.SellBaseData.IsTreasure)
			{
				this.SinglePrice = 0UL;
				this.TotalPrice = 0UL;
				this.mPriceNumber = 0UL;
				this.mTreasureRoot.CustomActive(true);
				this.mUnTreasureRoot.CustomActive(false);
				this.mTreasureTotalPrice.text = this.TotalPrice.ToString();
				this.UpdaterDepositInfo();
				this.mFreeRect.localPosition = new Vector3(123f, 204f, 0f);
			}
			else
			{
				this.mTreasureRoot.CustomActive(false);
				this.mUnTreasureRoot.CustomActive(true);
				this.UpdateSingleBtnState(item);
			}
		}

		// Token: 0x0600CA12 RID: 51730 RVA: 0x00316C5C File Offset: 0x0031505C
		private void SendWorldAuctionQueryItemPricesReq()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.SellBaseData.PackageItemGuid);
			if (item == null)
			{
				return;
			}
			WorldAuctionQueryItemPricesReq worldAuctionQueryItemPricesReq = new WorldAuctionQueryItemPricesReq();
			worldAuctionQueryItemPricesReq.type = 0;
			worldAuctionQueryItemPricesReq.itemTypeId = (uint)item.TableID;
			worldAuctionQueryItemPricesReq.strengthen = (uint)item.StrengthenLevel;
			if (item.SubType == 54)
			{
				worldAuctionQueryItemPricesReq.beadbuffid = (uint)item.BeadAdditiveAttributeBuffID;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionQueryItemPricesReq>(ServerType.GATE_SERVER, worldAuctionQueryItemPricesReq);
		}

		// Token: 0x0600CA13 RID: 51731 RVA: 0x00316CD4 File Offset: 0x003150D4
		[MessageHandle(603923U, false, 0)]
		private void OnAuctionQueryItemPricesRet(MsgDATA msg)
		{
			WorldAuctionQueryItemPricesRes worldAuctionQueryItemPricesRes = new WorldAuctionQueryItemPricesRes();
			worldAuctionQueryItemPricesRes.decode(msg.bytes);
			if (worldAuctionQueryItemPricesRes.type != 0)
			{
				return;
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.SellBaseData.PackageItemGuid);
			if (item == null)
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPricesRes.itemTypeId != (ulong)((long)item.TableID))
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPricesRes.strengthen != (ulong)((long)item.StrengthenLevel))
			{
				return;
			}
			this.iAveragePrice = (ulong)worldAuctionQueryItemPricesRes.averagePrice;
			this.ivisAverPrice = (ulong)worldAuctionQueryItemPricesRes.visAverPrice;
			this.mMaxServerSinglePrice = worldAuctionQueryItemPricesRes.maxPrice;
			this.mMinServerSinglePrice = worldAuctionQueryItemPricesRes.minPrice;
			this.mAuctionOnSaleItemDateList.Clear();
			for (int i = 0; i < worldAuctionQueryItemPricesRes.actionItems.Length; i++)
			{
				AuctionBaseInfo auctionBaseInfo = worldAuctionQueryItemPricesRes.actionItems[i];
				AuctionOnSaleItemDate auctionOnSaleItemDate = new AuctionOnSaleItemDate(auctionBaseInfo.guid, auctionBaseInfo.price, auctionBaseInfo.pricetype, auctionBaseInfo.itemScore, 0U, auctionBaseInfo.num, auctionBaseInfo.itemTypeId, auctionBaseInfo.strengthed, auctionBaseInfo.isTreas == 1);
				if (auctionOnSaleItemDate != null)
				{
					this.mAuctionOnSaleItemDateList.Add(auctionOnSaleItemDate);
				}
			}
			if (!this.SellBaseData.IsTreasure)
			{
				this.UpdateSellData();
				this.UpdateShowSellInfo();
				this.UpdateAveragePrice();
			}
			this.UpdatemAveragePriceGoState();
			this.InitOnSaleItemList();
		}

		// Token: 0x0600CA14 RID: 51732 RVA: 0x00316E28 File Offset: 0x00315228
		private void UpdatemAveragePriceGoState()
		{
			bool bActive = this.iAveragePrice > 0UL;
			this.mAveragePriceGo.CustomActive(bActive);
		}

		// Token: 0x0600CA15 RID: 51733 RVA: 0x00316E58 File Offset: 0x00315258
		private void InitOnSaleItemList()
		{
			this.mDesGo.CustomActive(false);
			if (this.mAuctionOnSaleItemDateList.Count <= 0)
			{
				this.mDesGo.CustomActive(true);
				return;
			}
			this.mAuctionOnSaleItemDateList.Sort();
			this.mOnSaleItemUIListScript.Initialize();
			this.mOnSaleItemUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && this.mAuctionOnSaleItemDateList != null && item.m_index < this.mAuctionOnSaleItemDateList.Count)
				{
					this.UpdateAuctionOnSaleItemDetailBind(item, this.mAuctionOnSaleItemDateList);
				}
			};
			this.mOnSaleItemUIListScript.SetElementAmount(this.mAuctionOnSaleItemDateList.Count);
		}

		// Token: 0x0600CA16 RID: 51734 RVA: 0x00316ED4 File Offset: 0x003152D4
		private void UpdateAuctionOnSaleItemDetailBind(ComUIListElementScript item, List<AuctionOnSaleItemDate> onSaleItemList)
		{
			ComAuctionOnSaleItem component = item.GetComponent<ComAuctionOnSaleItem>();
			if (component == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)onSaleItemList[item.m_index].itemTypeId, string.Empty, string.Empty) == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)onSaleItemList[item.m_index].itemTypeId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			itemData.Count = (int)onSaleItemList[item.m_index].num;
			itemData.GUID = onSaleItemList[item.m_index].guid;
			itemData.StrengthenLevel = (int)onSaleItemList[item.m_index].strengthed;
			ComItem comItem = component.pos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(component.pos);
			}
			int index = item.m_index;
			comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowOnSaleItemDetail));
			comItem.SetShowTreasure(onSaleItemList[item.m_index].isTreasure);
			component.name.text = itemData.GetColorName(string.Empty, false);
			if (onSaleItemList[item.m_index].itemScore > 0U)
			{
				component.score.text = string.Format("评分：{0}", onSaleItemList[item.m_index].itemScore);
			}
			else
			{
				component.score.text = string.Empty;
			}
			int num = (int)(onSaleItemList[item.m_index].price / onSaleItemList[item.m_index].num);
			component.price.text = Utility.GetShowPrice((ulong)((long)num), false);
			component.price.text = Utility.ToThousandsSeparator((ulong)((long)num));
		}

		// Token: 0x0600CA17 RID: 51735 RVA: 0x00317099 File Offset: 0x00315499
		private void OnShowOnSaleItemDetail(GameObject Obj, ItemData sitem)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(sitem, sitem.GUID);
		}

		// Token: 0x0600CA18 RID: 51736 RVA: 0x003170AC File Offset: 0x003154AC
		private void OnShowSelfItemData(GameObject obj, ItemData itemData)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, 0UL);
		}

		// Token: 0x0600CA19 RID: 51737 RVA: 0x003170BC File Offset: 0x003154BC
		private void InitSellData(ItemData data, ItemTable TblData)
		{
			this.MaxPriceRate = TblData.AuctionMaxPrice;
			this.MinPriceRate = TblData.AuctionMinPrice;
			this.MaxAveragePriceRate = 150;
			this.MinAveragePriceRate = 50;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(193, string.Empty, string.Empty);
			this.iDepositColumn = tableItem.Value;
			this.iRate = 100;
			this.iStrengthRate = DataManager<AuctionDataManager>.GetInstance().GetEquipStrengthLvAdditionalPriceRate(data.StrengthenLevel);
			this.ItemNum = 1UL;
			this.RecoPrice = DataManager<AuctionDataManager>.GetInstance().GetBasePrice((ulong)((long)TblData.RecommendPrice), this.iStrengthRate);
			this.mNumber = 1UL;
			this.mMaxSinglePrice = this.GetFinalMaxLimitSinglePrice();
			this.mMinSinglePrice = this.GetFinalMinLimitSinglePrice();
			if (this.SellBaseData.IsTreasure)
			{
				this.treasureItemMaxPrice = this.RecoPrice * (ulong)((long)DataManager<AuctionNewDataManager>.GetInstance().TreasureItemRecommendPriceRate);
			}
		}

		// Token: 0x0600CA1A RID: 51738 RVA: 0x003171A5 File Offset: 0x003155A5
		private void UpdateSellData()
		{
			this.SinglePrice = this.ivisAverPrice;
			this.TotalPrice = this.ivisAverPrice;
			this.mPriceNumber = this.ivisAverPrice;
			this.TransactionPrice = this.ivisAverPrice;
		}

		// Token: 0x0600CA1B RID: 51739 RVA: 0x003171D8 File Offset: 0x003155D8
		private void InitShowSellInfo(ItemData data)
		{
			this.mName.text = data.Name;
			ComItem comItem = this.mPos.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.mPos);
			}
			comItem.Setup(data, new ComItem.OnItemClicked(this.OnShowSelfItemData));
			comItem.SetShowTreasure(this.SellBaseData.IsTreasure);
			this.mVIPHandingCharge.text = "贵族" + DataManager<PlayerBaseData>.GetInstance().VipLevel + "手续费:";
			this.mRecoPrice.text = this.RecoPrice.ToString();
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.AUTION_VIP_COMMISSION_PRIVILEGE);
			this.mFee.text = curVipLevelPrivilegeData * 100f + "%";
			this.UpdateAveragePrice();
		}

		// Token: 0x0600CA1C RID: 51740 RVA: 0x003172B3 File Offset: 0x003156B3
		private void UpdateAveragePrice()
		{
			this.mAveragePrice.text = this.iAveragePrice.ToString();
			this.mVisAverPrice.text = this.ivisAverPrice.ToString();
		}

		// Token: 0x0600CA1D RID: 51741 RVA: 0x003172F0 File Offset: 0x003156F0
		private void UpdaterDepositInfo()
		{
			this.iDeposit = Mathf.FloorToInt(this.TotalPrice * (float)this.iDepositColumn / 1000f);
			if (this.iDeposit < 1)
			{
				this.iDeposit = 1;
			}
			if (this.iDeposit > 100000)
			{
				this.iDeposit = 100000;
			}
			this.mDeposit.text = this.iDeposit.ToString();
		}

		// Token: 0x0600CA1E RID: 51742 RVA: 0x00317368 File Offset: 0x00315768
		private void UpdateShowSellInfo()
		{
			this.mNum.text = this.ItemNum.ToString();
			this.mSinglePrice.text = this.SinglePrice.ToString();
			this.mTotalPrice.text = this.TotalPrice.ToString();
			this.UpdaterDepositInfo();
		}

		// Token: 0x0600CA1F RID: 51743 RVA: 0x003173CF File Offset: 0x003157CF
		private void UpdateSingleBtnState(ItemData mData)
		{
			if (mData.Type == ItemTable.eType.EQUIP || mData.Type == ItemTable.eType.FUCKTITTLE)
			{
				this.mSinglePriceBtn.enabled = true;
			}
			else
			{
				this.mSinglePriceBtn.enabled = false;
			}
		}

		// Token: 0x0600CA20 RID: 51744 RVA: 0x00317408 File Offset: 0x00315808
		private void UpdateShowTreasureSellInfo()
		{
			this.mTreasureSinglePrice.text = ((this.SinglePrice <= 0UL) ? string.Format("点击输入价格", new object[0]) : this.SinglePrice.ToString());
			this.mTreasureTotalPrice.text = this.TotalPrice.ToString();
			this.UpdaterDepositInfo();
		}

		// Token: 0x0600CA21 RID: 51745 RVA: 0x00317478 File Offset: 0x00315878
		private void SendOnSaleReq(ItemData data)
		{
			WorldAuctionRequest worldAuctionRequest = new WorldAuctionRequest();
			worldAuctionRequest.id = this.SellBaseData.PackageItemGuid;
			worldAuctionRequest.typeId = (uint)data.TableID;
			worldAuctionRequest.type = 0;
			worldAuctionRequest.price = (uint)this.TotalPrice;
			worldAuctionRequest.duration = 0;
			worldAuctionRequest.num = (uint)this.ItemNum;
			worldAuctionRequest.strength = (byte)data.StrengthenLevel;
			if (data.SubType == 54)
			{
				worldAuctionRequest.beadbuffId = (uint)data.BeadAdditiveAttributeBuffID;
			}
			else
			{
				worldAuctionRequest.beadbuffId = 0U;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldAuctionRequest>(ServerType.GATE_SERVER, worldAuctionRequest);
		}

		// Token: 0x0600CA22 RID: 51746 RVA: 0x00317511 File Offset: 0x00315911
		private ulong GetFinalSinglePrice(int iRate)
		{
			return (ulong)(this.ivisAverPrice * (ulong)((long)iRate) / 100f);
		}

		// Token: 0x0600CA23 RID: 51747 RVA: 0x00317525 File Offset: 0x00315925
		private ulong GetFinalTotalPrice()
		{
			return (ulong)(this.ivisAverPrice * (ulong)((long)this.iRate) * this.ItemNum / 100f);
		}

		// Token: 0x0600CA24 RID: 51748 RVA: 0x00317545 File Offset: 0x00315945
		private ulong GetAverageMaxLimitSinglePrice()
		{
			return (ulong)(this.TransactionPrice * (ulong)((long)this.MaxPriceRate) / 100f);
		}

		// Token: 0x0600CA25 RID: 51749 RVA: 0x0031755E File Offset: 0x0031595E
		private ulong GetAverageMinLimitSinglePrice()
		{
			return (ulong)(this.TransactionPrice * (ulong)((long)this.MinPriceRate) / 100f);
		}

		// Token: 0x0600CA26 RID: 51750 RVA: 0x00317577 File Offset: 0x00315977
		private ulong GetFinalMaxLimitSinglePrice()
		{
			return (ulong)(this.RecoPrice * (ulong)((long)this.MaxPriceRate) / 100f);
		}

		// Token: 0x0600CA27 RID: 51751 RVA: 0x00317590 File Offset: 0x00315990
		private ulong GetFinalMinLimitSinglePrice()
		{
			return (ulong)(this.RecoPrice * (ulong)((long)this.MinPriceRate) / 100f);
		}

		// Token: 0x0600CA28 RID: 51752 RVA: 0x003175A9 File Offset: 0x003159A9
		private ulong GetFinalMaxLimitTotalPrice()
		{
			return (ulong)(this.RecoPrice * (ulong)((long)this.MaxPriceRate) * this.ItemNum / 100f);
		}

		// Token: 0x0600CA29 RID: 51753 RVA: 0x003175C9 File Offset: 0x003159C9
		private ulong GetFinalMinLimitTotalPrice()
		{
			return (ulong)(this.RecoPrice * (ulong)((long)this.MinPriceRate) * this.ItemNum / 100f);
		}

		// Token: 0x0600CA2A RID: 51754 RVA: 0x003175E9 File Offset: 0x003159E9
		private ulong GetFinalMinLimitTotalPrice(ulong ItemNum)
		{
			return (ulong)this.mMinServerSinglePrice * ItemNum;
		}

		// Token: 0x0600CA2B RID: 51755 RVA: 0x003175F4 File Offset: 0x003159F4
		private ulong GetAverageMaxLimitTotalPrice()
		{
			return (ulong)(this.TransactionPrice * (ulong)((long)this.MaxPriceRate) * this.ItemNum / 100f);
		}

		// Token: 0x0600CA2C RID: 51756 RVA: 0x00317614 File Offset: 0x00315A14
		private ulong GetAverageMinLimitTotalPrice()
		{
			return (ulong)(this.TransactionPrice * (ulong)((long)this.MinPriceRate) * this.ItemNum / 100f);
		}

		// Token: 0x0600CA2D RID: 51757 RVA: 0x00317634 File Offset: 0x00315A34
		protected sealed override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mPos = this.mBind.GetGameObject("Pos");
			this.mRecoPrice = this.mBind.GetCom<Text>("RecoPrice");
			this.mDeposit = this.mBind.GetCom<Text>("Deposit");
			this.mFee = this.mBind.GetCom<Text>("Fee");
			this.mNum = this.mBind.GetCom<Text>("Num");
			this.mSinglePrice = this.mBind.GetCom<Text>("SinglePrice");
			this.mTotalPrice = this.mBind.GetCom<Text>("TotalPrice");
			this.mBtNumMin = this.mBind.GetCom<Button>("BtNumMin");
			this.mBtNumMin.onClick.AddListener(new UnityAction(this._onBtNumMinButtonClick));
			this.mBtNumMax = this.mBind.GetCom<Button>("BtNumMax");
			this.mBtNumMax.onClick.AddListener(new UnityAction(this._onBtNumMaxButtonClick));
			this.mBtNumMinus = this.mBind.GetCom<Button>("BtNumMinus");
			this.mBtNumMinus.onClick.AddListener(new UnityAction(this._onBtNumMinusButtonClick));
			this.mBtNumPlus = this.mBind.GetCom<Button>("BtNumPlus");
			this.mBtNumPlus.onClick.AddListener(new UnityAction(this._onBtNumPlusButtonClick));
			this.mBtPriceMinus = this.mBind.GetCom<Button>("BtPriceMinus");
			this.mBtPriceMinus.onClick.AddListener(new UnityAction(this._onBtPriceMinusButtonClick));
			this.mBtPricePlus = this.mBind.GetCom<Button>("BtPricePlus");
			this.mBtPricePlus.onClick.AddListener(new UnityAction(this._onBtPricePlusButtonClick));
			this.mVIPHandingCharge = this.mBind.GetCom<Text>("VIPHandlingCharge");
			this.mBtOnSale = this.mBind.GetCom<Button>("BtOnSale");
			this.mBtOnSale.onClick.AddListener(new UnityAction(this._onBtOnSaleButtonClick));
			this.mOpenKeyBoardBtn = this.mBind.GetCom<Button>("OpenKeyBoardBtn");
			this.mOpenKeyBoardBtn.onClick.AddListener(new UnityAction(this._onOpenKeyBoardBtnButtonClick));
			this.mDesGo = this.mBind.GetGameObject("desGo");
			this.mOnSaleItemUIListScript = this.mBind.GetCom<ComUIListScript>("OnSaleItemUIListScript");
			this.mAveragePrice = this.mBind.GetCom<Text>("AveragePrice");
			this.mSinglePriceBtn = this.mBind.GetCom<Button>("SinglelPriceBtn");
			this.mSinglePriceBtn.onClick.AddListener(new UnityAction(this._onSinglePriceBtnClick));
			this.mUnTreasureRoot = this.mBind.GetGameObject("UnTreasuresRoot");
			this.mTreasureRoot = this.mBind.GetGameObject("TreasuresRoot");
			this.mTreasureTotalPrice = this.mBind.GetCom<Text>("TreasuretotalPrice");
			this.mTreasureSinglePrice = this.mBind.GetCom<Text>("TreasureSinglelPrice");
			this.mTreasureSinglePriceBtn = this.mBind.GetCom<Button>("TreasureSinglelPriceBtn");
			this.mTreasureSinglePriceBtn.onClick.AddListener(new UnityAction(this._onTreasureSinglePriceBtnClick));
			this.mVisAverPrice = this.mBind.GetCom<Text>("VisAveragePrice");
			this.mFreeRect = this.mBind.GetCom<RectTransform>("FeeRect");
			this.mAveragePriceGo = this.mBind.GetGameObject("AveragePriceGo");
		}

		// Token: 0x0600CA2E RID: 51758 RVA: 0x00317A0C File Offset: 0x00315E0C
		protected sealed override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mName = null;
			this.mPos = null;
			this.mRecoPrice = null;
			this.mDeposit = null;
			this.mFee = null;
			this.mNum = null;
			this.mSinglePrice = null;
			this.mTotalPrice = null;
			this.mBtNumMin.onClick.RemoveListener(new UnityAction(this._onBtNumMinButtonClick));
			this.mBtNumMin = null;
			this.mBtNumMax.onClick.RemoveListener(new UnityAction(this._onBtNumMaxButtonClick));
			this.mBtNumMax = null;
			this.mBtNumMinus.onClick.RemoveListener(new UnityAction(this._onBtNumMinusButtonClick));
			this.mBtNumMinus = null;
			this.mBtNumPlus.onClick.RemoveListener(new UnityAction(this._onBtNumPlusButtonClick));
			this.mBtNumPlus = null;
			this.mBtPriceMinus.onClick.RemoveListener(new UnityAction(this._onBtPriceMinusButtonClick));
			this.mBtPriceMinus = null;
			this.mBtPricePlus.onClick.RemoveListener(new UnityAction(this._onBtPricePlusButtonClick));
			this.mBtPricePlus = null;
			this.mVIPHandingCharge = null;
			this.mBtOnSale.onClick.RemoveListener(new UnityAction(this._onBtOnSaleButtonClick));
			this.mBtOnSale = null;
			this.mOpenKeyBoardBtn.onClick.RemoveListener(new UnityAction(this._onOpenKeyBoardBtnButtonClick));
			this.mOpenKeyBoardBtn = null;
			this.mDesGo = null;
			this.mOnSaleItemUIListScript = null;
			this.mAveragePrice = null;
			this.mSinglePriceBtn.onClick.RemoveListener(new UnityAction(this._onSinglePriceBtnClick));
			this.mSinglePriceBtn = null;
			this.mUnTreasureRoot = null;
			this.mTreasureRoot = null;
			this.mTreasureTotalPrice = null;
			this.mTreasureSinglePrice = null;
			this.mTreasureSinglePriceBtn.onClick.RemoveListener(new UnityAction(this._onTreasureSinglePriceBtnClick));
			this.mTreasureSinglePriceBtn = null;
			this.mVisAverPrice = null;
			this.mFreeRect = null;
			this.mAveragePriceGo = null;
		}

		// Token: 0x0600CA2F RID: 51759 RVA: 0x00317C1F File Offset: 0x0031601F
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<AuctionSellFrame>(this, false);
		}

		// Token: 0x0600CA30 RID: 51760 RVA: 0x00317C2E File Offset: 0x0031602E
		private ulong Clamp(ulong value, ulong min, ulong max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		// Token: 0x0600CA31 RID: 51761 RVA: 0x00317C40 File Offset: 0x00316040
		private void _UpdateTreasureNumMaxMinInfo()
		{
			this.mPriceNumber = this.Clamp(this.mPriceNumber, (ulong)this.mMinServerSinglePrice, (ulong)this.mMaxServerSinglePrice);
			this.SinglePrice = (this.TotalPrice = this.mPriceNumber);
		}

		// Token: 0x0600CA32 RID: 51762 RVA: 0x00317C82 File Offset: 0x00316082
		private void _UpdateNumMaxMinInfo()
		{
			this.SinglePrice = this.mPriceNumber;
			this.TotalPrice = this.mPriceNumber * this.mNumber;
		}

		// Token: 0x0600CA33 RID: 51763 RVA: 0x00317CA3 File Offset: 0x003160A3
		private void _onBtNumMinButtonClick()
		{
			this.ItemNum = 1UL;
			this.mNumber = this.ItemNum;
			this._UpdateNumMaxMinInfo();
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA34 RID: 51764 RVA: 0x00317CC5 File Offset: 0x003160C5
		private void _onBtNumMaxButtonClick()
		{
			this.ItemNum = (ulong)((long)DataManager<AuctionDataManager>.GetInstance().GetItemNumByGUID(this.SellBaseData.PackageItemGuid, true));
			this.mNumber = this.ItemNum;
			this._UpdateNumMaxMinInfo();
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA35 RID: 51765 RVA: 0x00317CFC File Offset: 0x003160FC
		private void _onBtNumMinusButtonClick()
		{
			if (this.ItemNum <= 1UL)
			{
				return;
			}
			this.ItemNum -= 1UL;
			this.mNumber = this.ItemNum;
			this._UpdateNumMaxMinInfo();
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA36 RID: 51766 RVA: 0x00317D34 File Offset: 0x00316134
		private void _onBtNumPlusButtonClick()
		{
			int itemNumByGUID = DataManager<AuctionDataManager>.GetInstance().GetItemNumByGUID(this.SellBaseData.PackageItemGuid, true);
			if (this.ItemNum >= (ulong)((long)itemNumByGUID))
			{
				return;
			}
			this.ItemNum += 1UL;
			this.mNumber = this.ItemNum;
			this._UpdateNumMaxMinInfo();
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA37 RID: 51767 RVA: 0x00317D90 File Offset: 0x00316190
		private void _onBtPriceMinusButtonClick()
		{
			if (this.bInputModify)
			{
				this.CalcRate(this.mPriceNumber, false);
				this.bInputModify = false;
			}
			int num = this.iRate;
			if (this.iRate <= 10)
			{
				if (this.iRate <= 2)
				{
					if (this.iRate <= 1)
					{
						return;
					}
					this.iRate--;
				}
				else
				{
					this.iRate -= 2;
				}
			}
			else
			{
				this.iRate -= 10;
			}
			ulong num2 = this.GetFinalSinglePrice(this.iRate);
			if (num2 < (ulong)this.mMinServerSinglePrice)
			{
				this.iRate = this._CalcRate((ulong)this.mMinServerSinglePrice);
			}
			if (num2 > (ulong)this.mMaxServerSinglePrice)
			{
				this.iRate = this._CalcRate((ulong)this.mMaxServerSinglePrice);
			}
			num2 = this.Clamp(num2, (ulong)this.mMinServerSinglePrice, (ulong)this.mMaxServerSinglePrice);
			this.TotalPrice = num2 * this.ItemNum;
			this.SinglePrice = num2;
			this.mPriceNumber = this.SinglePrice;
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA38 RID: 51768 RVA: 0x00317EA8 File Offset: 0x003162A8
		private void _onBtPricePlusButtonClick()
		{
			if (this.bInputModify)
			{
				this.CalcRate(this.mPriceNumber, true);
				this.bInputModify = false;
			}
			if (this.iRate < 10)
			{
				if (this.iRate < 2)
				{
					if (this.iRate < 1)
					{
						return;
					}
					this.iRate++;
				}
				else
				{
					this.iRate += 2;
				}
			}
			else
			{
				this.iRate += 10;
			}
			ulong num = this.GetFinalSinglePrice(this.iRate);
			if (num < (ulong)this.mMinServerSinglePrice)
			{
				this.iRate = this._CalcRate((ulong)this.mMinServerSinglePrice);
			}
			if (num > (ulong)this.mMaxServerSinglePrice)
			{
				this.iRate = this._CalcRate((ulong)this.mMaxServerSinglePrice);
			}
			num = this.Clamp(num, (ulong)this.mMinServerSinglePrice, (ulong)this.mMaxServerSinglePrice);
			this.TotalPrice = num * this.ItemNum;
			this.SinglePrice = num;
			this.mPriceNumber = this.SinglePrice;
			this.UpdateShowSellInfo();
		}

		// Token: 0x0600CA39 RID: 51769 RVA: 0x00317FB9 File Offset: 0x003163B9
		private void _onOpenKeyBoardBtnButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, new Vector3(60f, 123f, 0f), string.Empty);
			this.isTrueNum = false;
			this.isCount = true;
		}

		// Token: 0x0600CA3A RID: 51770 RVA: 0x00317FF3 File Offset: 0x003163F3
		private void _onSinglePriceBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, new Vector3(100f, 82f, 0f), string.Empty);
			this.isTrueNum = false;
			this.isCount = false;
		}

		// Token: 0x0600CA3B RID: 51771 RVA: 0x0031802D File Offset: 0x0031642D
		private void _onTreasureSinglePriceBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, new Vector3(100f, 82f, 0f), string.Empty);
			this.isCount = false;
			this.isTrueNum = false;
		}

		// Token: 0x0600CA3C RID: 51772 RVA: 0x00318068 File Offset: 0x00316468
		private void _onBtOnSaleButtonClick()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.SellBaseData.PackageItemGuid);
			if (item == null)
			{
				Logger.LogErrorFormat("AuctionSellFrame OnSaleButtonClick ItemData is null and itemGuid is {0}", new object[]
				{
					this.SellBaseData.PackageItemGuid
				});
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("AuctionSellFrame OnSaleButtonClick ItemTable is null and tableId is {0}", new object[]
				{
					item.TableID
				});
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.SellBaseData.SelfOnSaleNum >= this.SellBaseData.MaxOnSaleItemNum)
			{
				SystemNotifyManager.SystemNotify(1088, string.Empty);
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().BindGold < this.iDeposit)
			{
				SystemNotifyManager.SystemNotify(1093, string.Empty);
				return;
			}
			if (this.ItemNum < 1UL)
			{
				SystemNotifyManager.SystemNotify(1095, string.Empty);
				return;
			}
			int itemNumByGUID = DataManager<AuctionDataManager>.GetInstance().GetItemNumByGUID(this.SellBaseData.PackageItemGuid, true);
			if (this.ItemNum > (ulong)((long)itemNumByGUID))
			{
				SystemNotifyManager.SystemNotify(1096, string.Empty);
				return;
			}
			if (this.TotalPrice < 1UL)
			{
				SystemNotifyManager.SystemNotify(1095, string.Empty);
				return;
			}
			bool flag;
			if (this.SellBaseData.IsTreasure)
			{
				flag = DataManager<AuctionNewDataManager>.GetInstance().IsShowOnShelfTipOfTreasureItem(new Action(this.OnCloseFrame), new Action(this.OnSendOnShelfRes));
			}
			else
			{
				flag = DataManager<AuctionNewDataManager>.GetInstance().IsShowOnShelfTipOfNormalItem(new Action(this.OnCloseFrame), new Action(this.OnSendOnShelfRes));
			}
			if (flag)
			{
				return;
			}
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			this.SendOnSaleReq(item);
			this.frameMgr.CloseFrame<AuctionSellFrame>(this, false);
		}

		// Token: 0x0600CA3D RID: 51773 RVA: 0x00318249 File Offset: 0x00316649
		private void OnCloseFrame()
		{
			this.frameMgr.CloseFrame<AuctionSellFrame>(this, false);
		}

		// Token: 0x0600CA3E RID: 51774 RVA: 0x00318258 File Offset: 0x00316658
		private void OnSendOnShelfRes()
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.SellBaseData.PackageItemGuid);
			DataManager<AuctionDataManager>.GetInstance().BIsUpdateCurPage = false;
			this.SendOnSaleReq(item);
			this.OnCloseFrame();
		}

		// Token: 0x04007512 RID: 29970
		private AuctionSellBaseData SellBaseData = default(AuctionSellBaseData);

		// Token: 0x04007513 RID: 29971
		private List<AuctionOnSaleItemDate> mAuctionOnSaleItemDateList = new List<AuctionOnSaleItemDate>();

		// Token: 0x04007514 RID: 29972
		private ChangeNumType changeNumType = ChangeNumType.BackSpace;

		// Token: 0x04007515 RID: 29973
		private int iDeposit;

		// Token: 0x04007516 RID: 29974
		private int iDepositColumn;

		// Token: 0x04007517 RID: 29975
		private string FeeStr = "10%";

		// Token: 0x04007518 RID: 29976
		private int MaxPriceRate;

		// Token: 0x04007519 RID: 29977
		private int MinPriceRate;

		// Token: 0x0400751A RID: 29978
		private ulong RecoPrice = 1UL;

		// Token: 0x0400751B RID: 29979
		private ulong ItemNum = 1UL;

		// Token: 0x0400751C RID: 29980
		private ulong SinglePrice = 1UL;

		// Token: 0x0400751D RID: 29981
		private ulong TotalPrice = 1UL;

		// Token: 0x0400751E RID: 29982
		private ulong mMinSinglePrice = 1UL;

		// Token: 0x0400751F RID: 29983
		private ulong mMaxSinglePrice = 1UL;

		// Token: 0x04007520 RID: 29984
		private ulong mNumber = 1UL;

		// Token: 0x04007521 RID: 29985
		private ulong mPriceNumber = 1UL;

		// Token: 0x04007522 RID: 29986
		private int iRate = 100;

		// Token: 0x04007523 RID: 29987
		private int iStrengthRate;

		// Token: 0x04007524 RID: 29988
		private bool isTrueNum;

		// Token: 0x04007525 RID: 29989
		private ulong treasureItemMaxPrice;

		// Token: 0x04007526 RID: 29990
		private bool isCount = true;

		// Token: 0x04007527 RID: 29991
		private int MaxAveragePriceRate;

		// Token: 0x04007528 RID: 29992
		private int MinAveragePriceRate;

		// Token: 0x04007529 RID: 29993
		private ulong iAveragePrice;

		// Token: 0x0400752A RID: 29994
		private ulong ivisAverPrice;

		// Token: 0x0400752B RID: 29995
		private ulong TransactionPrice;

		// Token: 0x0400752C RID: 29996
		private uint mMaxServerSinglePrice;

		// Token: 0x0400752D RID: 29997
		private uint mMinServerSinglePrice;

		// Token: 0x0400752E RID: 29998
		private bool bInputModify;

		// Token: 0x0400752F RID: 29999
		private Button mBtClose;

		// Token: 0x04007530 RID: 30000
		private Text mName;

		// Token: 0x04007531 RID: 30001
		private GameObject mPos;

		// Token: 0x04007532 RID: 30002
		private Text mRecoPrice;

		// Token: 0x04007533 RID: 30003
		private Text mDeposit;

		// Token: 0x04007534 RID: 30004
		private Text mFee;

		// Token: 0x04007535 RID: 30005
		private Text mNum;

		// Token: 0x04007536 RID: 30006
		private Text mSinglePrice;

		// Token: 0x04007537 RID: 30007
		private Text mTotalPrice;

		// Token: 0x04007538 RID: 30008
		private Button mBtNumMin;

		// Token: 0x04007539 RID: 30009
		private Button mBtNumMax;

		// Token: 0x0400753A RID: 30010
		private Button mBtNumMinus;

		// Token: 0x0400753B RID: 30011
		private Button mBtNumPlus;

		// Token: 0x0400753C RID: 30012
		private Button mBtPriceMinus;

		// Token: 0x0400753D RID: 30013
		private Button mBtPricePlus;

		// Token: 0x0400753E RID: 30014
		private Text mVIPHandingCharge;

		// Token: 0x0400753F RID: 30015
		private Button mBtOnSale;

		// Token: 0x04007540 RID: 30016
		private Button mOpenKeyBoardBtn;

		// Token: 0x04007541 RID: 30017
		private GameObject mDesGo;

		// Token: 0x04007542 RID: 30018
		private ComUIListScript mOnSaleItemUIListScript;

		// Token: 0x04007543 RID: 30019
		private Text mAveragePrice;

		// Token: 0x04007544 RID: 30020
		private Button mSinglePriceBtn;

		// Token: 0x04007545 RID: 30021
		private GameObject mUnTreasureRoot;

		// Token: 0x04007546 RID: 30022
		private GameObject mTreasureRoot;

		// Token: 0x04007547 RID: 30023
		private Text mTreasureTotalPrice;

		// Token: 0x04007548 RID: 30024
		private Text mTreasureSinglePrice;

		// Token: 0x04007549 RID: 30025
		private Button mTreasureSinglePriceBtn;

		// Token: 0x0400754A RID: 30026
		private Text mVisAverPrice;

		// Token: 0x0400754B RID: 30027
		private RectTransform mFreeRect;

		// Token: 0x0400754C RID: 30028
		private GameObject mAveragePriceGo;
	}
}
