using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200176C RID: 5996
	public class FashionBuyFrame : ClientFrame
	{
		// Token: 0x0600ECAF RID: 60591 RVA: 0x003F2EEB File Offset: 0x003F12EB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/FashionBuyFrame";
		}

		// Token: 0x0600ECB0 RID: 60592 RVA: 0x003F2EF4 File Offset: 0x003F12F4
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			List<MallItemInfo> list = (List<MallItemInfo>)this.userData;
			if (list.Count != 3)
			{
				Logger.LogErrorFormat("oh FashionBuyData is error", new object[0]);
			}
			for (int i = 0; i < list.Count; i++)
			{
				this.FashionItem.Add(list[i]);
			}
			this.InitData();
			this.mItemForever.isOn = true;
		}

		// Token: 0x0600ECB1 RID: 60593 RVA: 0x003F2F70 File Offset: 0x003F1370
		protected override void _OnCloseFrame()
		{
			this.cleardata();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionBuyFrame>(null, false);
		}

		// Token: 0x0600ECB2 RID: 60594 RVA: 0x003F2F84 File Offset: 0x003F1384
		private void InitData()
		{
			this.BuyIndex = -1;
			this.mPrice7.text = this.FashionItem[0].discountprice.ToString();
			this.mPrice30.text = this.FashionItem[1].discountprice.ToString();
			this.mPriceForever.text = this.FashionItem[2].discountprice.ToString();
		}

		// Token: 0x0600ECB3 RID: 60595 RVA: 0x003F300D File Offset: 0x003F140D
		private void cleardata()
		{
			this.FashionItem.Clear();
			this.BuyIndex = -1;
		}

		// Token: 0x0600ECB4 RID: 60596 RVA: 0x003F3024 File Offset: 0x003F1424
		protected override void _bindExUI()
		{
			this.mItem7 = this.mBind.GetCom<Toggle>("Item7");
			this.mItem7.onValueChanged.AddListener(new UnityAction<bool>(this._onItem7ToggleValueChange));
			this.mItem30 = this.mBind.GetCom<Toggle>("Item30");
			this.mItem30.onValueChanged.AddListener(new UnityAction<bool>(this._onItem30ToggleValueChange));
			this.mItemForever = this.mBind.GetCom<Toggle>("ItemForever");
			this.mItemForever.onValueChanged.AddListener(new UnityAction<bool>(this._onItemForeverToggleValueChange));
			this.mBuy = this.mBind.GetCom<Button>("Buy");
			this.mBuy.onClick.AddListener(new UnityAction(this._onBuyButtonClick));
			this.mPrice7 = this.mBind.GetCom<Text>("price7");
			this.mPrice30 = this.mBind.GetCom<Text>("price30");
			this.mPriceForever = this.mBind.GetCom<Text>("priceForever");
			this.mAwards = this.mBind.GetGameObject("awards");
			this.mget7 = this.mBind.GetGameObject("get7");
			this.mget30 = this.mBind.GetGameObject("get30");
			this.mgetforever = this.mBind.GetGameObject("getforever");
			this.mSetButtonCD = this.mBind.GetCom<SetButtonCD>("SetButtonCD");
		}

		// Token: 0x0600ECB5 RID: 60597 RVA: 0x003F31AC File Offset: 0x003F15AC
		protected override void _unbindExUI()
		{
			this.mItem7.onValueChanged.RemoveListener(new UnityAction<bool>(this._onItem7ToggleValueChange));
			this.mItem7 = null;
			this.mItem30.onValueChanged.RemoveListener(new UnityAction<bool>(this._onItem30ToggleValueChange));
			this.mItem30 = null;
			this.mItemForever.onValueChanged.RemoveListener(new UnityAction<bool>(this._onItemForeverToggleValueChange));
			this.mItemForever = null;
			this.mBuy.onClick.RemoveListener(new UnityAction(this._onBuyButtonClick));
			this.mBuy = null;
			this.mPrice7 = null;
			this.mPrice30 = null;
			this.mPriceForever = null;
			this.mAwards = null;
			this.mget7 = null;
			this.mget30 = null;
			this.mgetforever = null;
			this.mSetButtonCD = null;
		}

		// Token: 0x0600ECB6 RID: 60598 RVA: 0x003F3280 File Offset: 0x003F1680
		private void _onItem7ToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.BuyIndex = 0;
				this.mget7.CustomActive(true);
				this.mget30.CustomActive(false);
				this.mgetforever.CustomActive(false);
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.FashionItem[0].id, string.Empty, string.Empty);
				string[] array = tableItem.giftpackitems.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < 5; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						':'
					});
					int result_ID = 0;
					int.TryParse(array2[0], out result_ID);
					ItemData item = ItemDataManager.CreateItemDataFromTable(result_ID, 100, 0);
					if (this.FashionElement[i] == null)
					{
						Logger.LogErrorFormat("Fashionelement[{0}] is null", new object[]
						{
							i
						});
						return;
					}
					ComItem comItem = this.FashionElement[i].GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(this.FashionElement[i].gameObject);
					}
					comItem.Setup(item, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob(result_ID);
					});
				}
			}
		}

		// Token: 0x0600ECB7 RID: 60599 RVA: 0x003F33CC File Offset: 0x003F17CC
		private void _onItem30ToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.BuyIndex = 1;
				this.mget7.CustomActive(false);
				this.mget30.CustomActive(true);
				this.mgetforever.CustomActive(false);
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.FashionItem[1].id, string.Empty, string.Empty);
				string[] array = tableItem.giftpackitems.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < 5; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						':'
					});
					int result_ID = 0;
					int.TryParse(array2[0], out result_ID);
					ItemData item = ItemDataManager.CreateItemDataFromTable(result_ID, 100, 0);
					if (this.FashionElement[i] == null)
					{
						Logger.LogErrorFormat("Fashionelement[{0}] is null", new object[]
						{
							i
						});
						return;
					}
					ComItem comItem = this.FashionElement[i].GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(this.FashionElement[i].gameObject);
					}
					comItem.Setup(item, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob(result_ID);
					});
				}
			}
		}

		// Token: 0x0600ECB8 RID: 60600 RVA: 0x003F3518 File Offset: 0x003F1918
		private void _onItemForeverToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.BuyIndex = 2;
				this.mget7.CustomActive(false);
				this.mget30.CustomActive(false);
				this.mgetforever.CustomActive(true);
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.FashionItem[2].id, string.Empty, string.Empty);
				string[] array = tableItem.giftpackitems.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < 5; i++)
				{
					string[] array2 = array[i].Split(new char[]
					{
						':'
					});
					int result_ID = 0;
					int.TryParse(array2[0], out result_ID);
					ItemData item = ItemDataManager.CreateItemDataFromTable(result_ID, 100, 0);
					if (this.FashionElement[i] == null)
					{
						Logger.LogErrorFormat("Fashionelement[{0}] is null", new object[]
						{
							i
						});
						return;
					}
					ComItem comItem = this.FashionElement[i].GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(this.FashionElement[i].gameObject);
					}
					comItem.Setup(item, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob(result_ID);
					});
				}
			}
		}

		// Token: 0x0600ECB9 RID: 60601 RVA: 0x003F3664 File Offset: 0x003F1A64
		private void OnShowTipsFromJob(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600ECBA RID: 60602 RVA: 0x003F368C File Offset: 0x003F1A8C
		private void _onBuyButtonClick()
		{
			if (!this.mSetButtonCD.BtIsWork)
			{
				return;
			}
			this.mSetButtonCD.BtIsWork = false;
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			if (this.BuyIndex >= 0 && this.BuyIndex < this.FashionItem.Count)
			{
				MallItemInfo mallItemInfo = this.FashionItem[this.BuyIndex];
				costInfo.IsCreditPointDeduction = MallNewUtility.IsMallItemCanCreditPointDeduction(mallItemInfo);
			}
			if (this.BuyIndex == 0)
			{
				int nCount = -1;
				int.TryParse(this.mPrice7.text, out nCount);
				costInfo.nCount = nCount;
			}
			else if (this.BuyIndex == 1)
			{
				int nCount2 = -1;
				int.TryParse(this.mPrice30.text, out nCount2);
				costInfo.nCount = nCount2;
			}
			if (this.BuyIndex == 2)
			{
				int nCount3 = -1;
				int.TryParse(this.mPriceForever.text, out nCount3);
				costInfo.nCount = nCount3;
			}
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				WorldMallBuy worldMallBuy = new WorldMallBuy();
				worldMallBuy.itemId = this.FashionItem[this.BuyIndex].id;
				worldMallBuy.num = 1;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
			}, "common_money_cost", null);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionBuyFrame>(null, false);
		}

		// Token: 0x04008FF0 RID: 36848
		private List<MallItemInfo> FashionItem = new List<MallItemInfo>();

		// Token: 0x04008FF1 RID: 36849
		private int BuyIndex = -1;

		// Token: 0x04008FF2 RID: 36850
		[UIControl("PanelBG/Content/giftContent/awards/Item{0}", typeof(RectTransform), 1)]
		private RectTransform[] FashionElement = new RectTransform[5];

		// Token: 0x04008FF3 RID: 36851
		private Toggle mItem7;

		// Token: 0x04008FF4 RID: 36852
		private Toggle mItem30;

		// Token: 0x04008FF5 RID: 36853
		private Toggle mItemForever;

		// Token: 0x04008FF6 RID: 36854
		private Button mBuy;

		// Token: 0x04008FF7 RID: 36855
		private Text mPrice7;

		// Token: 0x04008FF8 RID: 36856
		private Text mPrice30;

		// Token: 0x04008FF9 RID: 36857
		private Text mPriceForever;

		// Token: 0x04008FFA RID: 36858
		private GameObject mAwards;

		// Token: 0x04008FFB RID: 36859
		private GameObject mget7;

		// Token: 0x04008FFC RID: 36860
		private GameObject mget30;

		// Token: 0x04008FFD RID: 36861
		private GameObject mgetforever;

		// Token: 0x04008FFE RID: 36862
		private SetButtonCD mSetButtonCD;
	}
}
