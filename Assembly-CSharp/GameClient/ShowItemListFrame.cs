using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001776 RID: 6006
	internal class ShowItemListFrame : ClientFrame
	{
		// Token: 0x0600ED50 RID: 60752 RVA: 0x003F9964 File Offset: 0x003F7D64
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/ShowItemListFrame";
		}

		// Token: 0x0600ED51 RID: 60753 RVA: 0x003F996B File Offset: 0x003F7D6B
		protected override void _OnOpenFrame()
		{
			this.detailData = (this.userData as List<MallItemDetailInfo>);
			this.InitInterface();
		}

		// Token: 0x0600ED52 RID: 60754 RVA: 0x003F9984 File Offset: 0x003F7D84
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600ED53 RID: 60755 RVA: 0x003F998C File Offset: 0x003F7D8C
		private void ClearData()
		{
			this.moneyType = ItemTable.eSubType.BindPOINT;
			this.iNeedCostMoney = 0;
			this.detailData = null;
		}

		// Token: 0x0600ED54 RID: 60756 RVA: 0x003F99A4 File Offset: 0x003F7DA4
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.ClearData();
			this.frameMgr.CloseFrame<ShowItemListFrame>(this, false);
		}

		// Token: 0x0600ED55 RID: 60757 RVA: 0x003F99BC File Offset: 0x003F7DBC
		[UIEventHandle("ListPanel/btBuy")]
		private void OnBuy()
		{
			if (this.detailData.Count <= 0)
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			if (this.moneyType == ItemTable.eSubType.BindPOINT)
			{
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
			}
			else if (this.moneyType == ItemTable.eSubType.POINT)
			{
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			}
			costInfo.nCount = this.iNeedCostMoney;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				if (this.detailData[0].BelongSuit)
				{
					WorldMallBuy worldMallBuy = new WorldMallBuy();
					worldMallBuy.itemId = this.detailData[0].id;
					worldMallBuy.num = 1;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
				}
				else
				{
					MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(this.detailData[0].MallTableIndex, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return;
					}
					if (tableItem.MallType == MallTypeTable.eMallType.SN_FASHION)
					{
						ItemReward[] array = new ItemReward[this.detailData.Count];
						for (int i = 0; i < this.detailData.Count; i++)
						{
							array[i] = new ItemReward
							{
								id = this.detailData[i].id,
								num = (uint)this.detailData[i].num
							};
						}
						CWMallBatchBuyReq cwmallBatchBuyReq = new CWMallBatchBuyReq();
						cwmallBatchBuyReq.items = new ItemReward[this.detailData.Count];
						cwmallBatchBuyReq.items = array;
						NetManager netManager2 = NetManager.Instance();
						netManager2.SendCommand<CWMallBatchBuyReq>(ServerType.GATE_SERVER, cwmallBatchBuyReq);
					}
					else
					{
						for (int j = 0; j < this.detailData.Count; j++)
						{
							WorldMallBuy worldMallBuy2 = new WorldMallBuy();
							worldMallBuy2.itemId = this.detailData[j].id;
							worldMallBuy2.num = 1;
							NetManager netManager3 = NetManager.Instance();
							netManager3.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy2);
						}
					}
				}
				this.OnClose();
			}, "common_money_cost", null);
		}

		// Token: 0x0600ED56 RID: 60758 RVA: 0x003F9A50 File Offset: 0x003F7E50
		private void InitInterface()
		{
			if (this.detailData.Count <= 0)
			{
				return;
			}
			this.moneyType = (ItemTable.eSubType)this.detailData[0].moneytype;
			if (this.moneyType == ItemTable.eSubType.BindPOINT)
			{
				this.bindTicketIcon.gameObject.SetActive(true);
				this.ticketicon.gameObject.SetActive(false);
			}
			else
			{
				if (this.moneyType != ItemTable.eSubType.POINT)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("商城商品配置货币类型错误", null, string.Empty, false);
					return;
				}
				this.bindTicketIcon.gameObject.SetActive(false);
				this.ticketicon.gameObject.SetActive(true);
			}
			if (this.detailData[0].BelongSuit)
			{
				this.iNeedCostMoney = Utility.GetMallRealPrice(this.detailData[0]);
			}
			else
			{
				for (int i = 0; i < this.detailData.Count; i++)
				{
					this.iNeedCostMoney += Utility.GetMallRealPrice(this.detailData[i]);
				}
			}
			this.money.text = this.iNeedCostMoney.ToString();
			for (int j = 0; j < this.detailData.Count; j++)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.detailData[j].itemId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ItemElePath, true, 0U);
					if (gameObject == null)
					{
						Logger.LogError("can't create obj in ShowItemListFrame");
					}
					else
					{
						Utility.AttachTo(gameObject, this.Content, false);
						RectTransform[] componentsInChildren = gameObject.GetComponentsInChildren<RectTransform>();
						for (int k = 0; k < componentsInChildren.Length; k++)
						{
							if (componentsInChildren[k].name == "pos")
							{
								ItemData item2 = ItemDataManager.CreateItemDataFromTable((int)this.detailData[j].itemId, 100, 0);
								ComItem comItem = base.CreateComItem(componentsInChildren[k].gameObject);
								int idx = j;
								comItem.Setup(item2, delegate(GameObject obj, ItemData item)
								{
									this.OnShowItemDetail(idx);
								});
								break;
							}
						}
						Text[] componentsInChildren2 = gameObject.GetComponentsInChildren<Text>();
						for (int l = 0; l < componentsInChildren2.Length; l++)
						{
							if (componentsInChildren2[l].name == "name")
							{
								componentsInChildren2[l].text = tableItem.Name + "*" + this.detailData[j].num.ToString();
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600ED57 RID: 60759 RVA: 0x003F9D38 File Offset: 0x003F8138
		private void OnShowItemDetail(int iIndex)
		{
			if (iIndex < 0)
			{
				return;
			}
		}

		// Token: 0x040090CF RID: 37071
		private string ItemElePath = "UIFlatten/Prefabs/Mall/MallShowItemEle";

		// Token: 0x040090D0 RID: 37072
		private ItemTable.eSubType moneyType = ItemTable.eSubType.BindPOINT;

		// Token: 0x040090D1 RID: 37073
		private int iNeedCostMoney;

		// Token: 0x040090D2 RID: 37074
		private List<MallItemDetailInfo> detailData;

		// Token: 0x040090D3 RID: 37075
		[UIObject("ListPanel/Scroll View/Viewport/Content")]
		protected GameObject Content;

		// Token: 0x040090D4 RID: 37076
		[UIControl("ListPanel/btBuy/bindTicketIcon", null, 0)]
		protected Image bindTicketIcon;

		// Token: 0x040090D5 RID: 37077
		[UIControl("ListPanel/btBuy/ticketIcon", null, 0)]
		protected Image ticketicon;

		// Token: 0x040090D6 RID: 37078
		[UIControl("ListPanel/btBuy/money", null, 0)]
		protected Text money;
	}
}
