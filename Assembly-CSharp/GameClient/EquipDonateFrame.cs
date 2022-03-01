using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015C8 RID: 5576
	internal class EquipDonateFrame : ClientFrame
	{
		// Token: 0x0600DA4F RID: 55887 RVA: 0x0036E0C3 File Offset: 0x0036C4C3
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipRecovery/EquipDonateFrame";
		}

		// Token: 0x0600DA50 RID: 55888 RVA: 0x0036E0CA File Offset: 0x0036C4CA
		protected sealed override void _OnOpenFrame()
		{
			this._InitData();
			this._InitEquipItemScrollListBind();
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DA51 RID: 55889 RVA: 0x0036E0E4 File Offset: 0x0036C4E4
		protected sealed override void _OnCloseFrame()
		{
			this._ClearData();
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DA52 RID: 55890 RVA: 0x0036E0F8 File Offset: 0x0036C4F8
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipSubmitSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewFrameClosed, new ClientEventSystem.UIEventHandler(this._OnEquipDonatePackageUpdate));
		}

		// Token: 0x0600DA53 RID: 55891 RVA: 0x0036E158 File Offset: 0x0036C558
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipSubmitSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipSubmitSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewFrameClosed, new ClientEventSystem.UIEventHandler(this._OnEquipDonatePackageUpdate));
		}

		// Token: 0x0600DA54 RID: 55892 RVA: 0x0036E1B8 File Offset: 0x0036C5B8
		private void _InitEquipItemScrollListBind()
		{
			this.mContent.Initialize();
			this.mContent.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdatePackageItemScrollListBind(item);
				}
			};
			this.mContent.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("add");
				if (com != null)
				{
					com.onClick.RemoveAllListeners();
				}
				Button com2 = component.GetCom<Button>("haveAdd");
				if (com2 != null)
				{
					com2.onClick.RemoveAllListeners();
				}
			};
		}

		// Token: 0x0600DA55 RID: 55893 RVA: 0x0036E210 File Offset: 0x0036C610
		private void _UpdatePackageItemScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.displayList.Count)
			{
				return;
			}
			ulong guid = this.displayList[item.m_index];
			ItemData itemData = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (itemData == null)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("itemRoot");
			Text com = component.GetCom<Text>("itemName");
			Text com2 = component.GetCom<Text>("count");
			Button mAdd = component.GetCom<Button>("add");
			Button mHaveAdd = component.GetCom<Button>("haveAdd");
			bool flag = this.donateList.Contains(guid);
			mAdd.CustomActive(!flag);
			mHaveAdd.CustomActive(flag);
			int tempMinPrice = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData, true);
			int tempMaxPrice = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData, false);
			mAdd.onClick.AddListener(delegate()
			{
				if (!this._CannotSelect())
				{
					mAdd.CustomActive(false);
					mHaveAdd.CustomActive(true);
					this.donateList.Add(guid);
					this.maxPrice += tempMaxPrice;
					this.minPrice += tempMinPrice;
					this._UpdateExpectPrice();
					this._UpdateWeekCount();
				}
				else
				{
					SystemNotifyManager.SystemNotify(9075, string.Empty);
				}
			});
			mHaveAdd.onClick.AddListener(delegate()
			{
				mAdd.CustomActive(true);
				mHaveAdd.CustomActive(false);
				this.donateList.Remove(guid);
				this.maxPrice -= tempMaxPrice;
				this.minPrice -= tempMinPrice;
				this._UpdateExpectPrice();
				this._UpdateWeekCount();
			});
			if (ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0) != null)
			{
				ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = base.CreateComItem(gameObject);
				}
				int tableID = itemData.TableID;
				comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
				{
					this._OnShowTips(itemData);
				});
			}
			com.text = itemData.Name;
			com2.text = DataManager<EquipRecoveryDataManager>.GetInstance()._GetEquipPrice(itemData);
		}

		// Token: 0x0600DA56 RID: 55894 RVA: 0x0036E404 File Offset: 0x0036C804
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600DA57 RID: 55895 RVA: 0x0036E41D File Offset: 0x0036C81D
		private void _InitData()
		{
			this.donateList.Clear();
			this.displayList.Clear();
			this.levelList.Clear();
		}

		// Token: 0x0600DA58 RID: 55896 RVA: 0x0036E440 File Offset: 0x0036C840
		private void _InitUI()
		{
			DataManager<ItemDataManager>.GetInstance().ArrangeItems(EPackageType.Equip);
			this._InitLevelList();
			this._InitPackage();
			this._UpdateWeekCount();
			this._UpdateNowScore();
		}

		// Token: 0x0600DA59 RID: 55897 RVA: 0x0036E468 File Offset: 0x0036C868
		private void _InitLevelList()
		{
			this.levelList.Add(0);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<EquipRecoveryPriceTable>();
			Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
			while (enumerator.MoveNext())
			{
				List<int> list = this.levelList;
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				list.Add(keyValuePair.Key);
			}
		}

		// Token: 0x0600DA5A RID: 55898 RVA: 0x0036E4BE File Offset: 0x0036C8BE
		private void _InitPackage()
		{
			this._UpdatePackage();
		}

		// Token: 0x0600DA5B RID: 55899 RVA: 0x0036E4C6 File Offset: 0x0036C8C6
		private void _ClearData()
		{
			this.curSelSubType = 0;
			this.curSelColor = 0;
			this.minPrice = 0;
			this.maxPrice = 0;
			this.donateList.Clear();
			this.displayList.Clear();
		}

		// Token: 0x0600DA5C RID: 55900 RVA: 0x0036E4FA File Offset: 0x0036C8FA
		private void _ClearUI()
		{
		}

		// Token: 0x0600DA5D RID: 55901 RVA: 0x0036E4FC File Offset: 0x0036C8FC
		private void _PlayEffect()
		{
		}

		// Token: 0x0600DA5E RID: 55902 RVA: 0x0036E500 File Offset: 0x0036C900
		private void _OnEquipSubmitSuccess(UIEvent uiEvent)
		{
			this._PlayEffect();
			this.minPrice = 0;
			this.maxPrice = 0;
			this.donateList.Clear();
			this._UpdateExpectPrice();
			this._UpdatePackage();
			this._UpdateWeekCount();
			this._UpdateNowScore();
			this.frameMgr.CloseFrame<EquipDonateFrame>(this, false);
		}

		// Token: 0x0600DA5F RID: 55903 RVA: 0x0036E551 File Offset: 0x0036C951
		private void _OnCountValueChange(UIEvent uievent)
		{
			this._UpdateWeekCount();
			this._UpdateNowScore();
		}

		// Token: 0x0600DA60 RID: 55904 RVA: 0x0036E560 File Offset: 0x0036C960
		private void _OnEquipDonatePackageUpdate(UIEvent uiEvent)
		{
			this._UpdatePackage();
			if (this.donateList == null || this.donateList.Count <= 0)
			{
				return;
			}
			for (int i = this.donateList.Count - 1; i >= 0; i--)
			{
				ulong num = this.donateList[i];
				bool flag = false;
				for (int j = 0; j < this.displayList.Count; j++)
				{
					if (num == this.displayList[j])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.donateList.RemoveAt(i);
				}
			}
		}

		// Token: 0x0600DA61 RID: 55905 RVA: 0x0036E604 File Offset: 0x0036CA04
		private void _RefreshItemListCount()
		{
			this.mContent.SetElementAmount(this.displayList.Count);
		}

		// Token: 0x0600DA62 RID: 55906 RVA: 0x0036E61C File Offset: 0x0036CA1C
		private void _UpdatePackage()
		{
			this.displayList.Clear();
			List<ulong> list = new List<ulong>();
			list = DataManager<EquipRecoveryDataManager>.GetInstance().GetItemForType(this.levelList[this.curSelSubType], (ItemTable.eColor)this.curSelColor, this.levelList[1]);
			for (int i = 0; i < list.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(list[i]);
				if (item != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (!item.IsItemInUnUsedEquipPlan)
						{
							if (tableItem.Color2 != 3 && !item.bLocked)
							{
								this.displayList.Add(list[i]);
							}
						}
					}
				}
			}
			this._RefreshItemListCount();
			this.mTips.CustomActive(this.displayList.Count == 0);
		}

		// Token: 0x0600DA63 RID: 55907 RVA: 0x0036E71A File Offset: 0x0036CB1A
		private void _UpdateExpectPrice()
		{
			this.mExpectScore.text = string.Format("{0}-{1}", this.minPrice, this.maxPrice);
		}

		// Token: 0x0600DA64 RID: 55908 RVA: 0x0036E748 File Offset: 0x0036CB48
		private void _UpdateWeekCount()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(374, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int value = tableItem.Value;
				this.mDonateCount.text = string.Concat(new object[]
				{
					(DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_WEEK_COUNT) + this.donateList.Count).ToString(),
					"/",
					value,
					"次"
				});
			}
		}

		// Token: 0x0600DA65 RID: 55909 RVA: 0x0036E7D8 File Offset: 0x0036CBD8
		private bool _CannotSelect()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(374, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int value = tableItem.Value;
				return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_WEEK_COUNT) + this.donateList.Count == value;
			}
			return false;
		}

		// Token: 0x0600DA66 RID: 55910 RVA: 0x0036E82C File Offset: 0x0036CC2C
		private void _UpdateNowScore()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.EQUIP_RECOVERY_REWARD_SCORE);
			this.mHaveScore.text = count.ToString();
		}

		// Token: 0x0600DA67 RID: 55911 RVA: 0x0036E864 File Offset: 0x0036CC64
		protected override void _bindExUI()
		{
			this.mQualitySelect = this.mBind.GetCom<Dropdown>("QualitySelect");
			if (null != this.mQualitySelect)
			{
				this.mQualitySelect.onValueChanged.AddListener(new UnityAction<int>(this._onQualitySelectDropdownValueChange));
			}
			this.mSubTypeSelect = this.mBind.GetCom<Dropdown>("SubTypeSelect");
			if (null != this.mSubTypeSelect)
			{
				this.mSubTypeSelect.onValueChanged.AddListener(new UnityAction<int>(this._onSubTypeSelectDropdownValueChange));
			}
			this.mContent = this.mBind.GetCom<ComUIListScript>("Content");
			this.mRecord = this.mBind.GetCom<ComUIListElementScript>("Record");
			this.mHaveScore = this.mBind.GetCom<Text>("HaveScore");
			this.mExpectScore = this.mBind.GetCom<Text>("ExpectScore");
			this.mDonateCount = this.mBind.GetCom<Text>("DonateCount");
			this.mSubmit = this.mBind.GetCom<Button>("Submit");
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.AddListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mContentRoot = this.mBind.GetGameObject("ContentRoot");
			this.mOpenPriceTable = this.mBind.GetCom<Button>("openPriceTable");
			if (null != this.mOpenPriceTable)
			{
				this.mOpenPriceTable.onClick.AddListener(new UnityAction(this._onOpenPriceTableButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mTips = this.mBind.GetCom<Text>("tips");
			this.mAuction = this.mBind.GetCom<Button>("auction");
			if (null != this.mAuction)
			{
				this.mAuction.onClick.AddListener(new UnityAction(this._onAuctionButtonClick));
			}
		}

		// Token: 0x0600DA68 RID: 55912 RVA: 0x0036EAA0 File Offset: 0x0036CEA0
		protected override void _unbindExUI()
		{
			if (null != this.mQualitySelect)
			{
				this.mQualitySelect.onValueChanged.RemoveListener(new UnityAction<int>(this._onQualitySelectDropdownValueChange));
			}
			this.mQualitySelect = null;
			if (null != this.mSubTypeSelect)
			{
				this.mSubTypeSelect.onValueChanged.RemoveListener(new UnityAction<int>(this._onSubTypeSelectDropdownValueChange));
			}
			this.mSubTypeSelect = null;
			this.mContent = null;
			this.mRecord = null;
			this.mHaveScore = null;
			this.mExpectScore = null;
			this.mDonateCount = null;
			if (null != this.mSubmit)
			{
				this.mSubmit.onClick.RemoveListener(new UnityAction(this._onSubmitButtonClick));
			}
			this.mSubmit = null;
			this.mContentRoot = null;
			if (null != this.mOpenPriceTable)
			{
				this.mOpenPriceTable.onClick.RemoveListener(new UnityAction(this._onOpenPriceTableButtonClick));
			}
			this.mOpenPriceTable = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mTips = null;
			if (null != this.mAuction)
			{
				this.mAuction.onClick.RemoveListener(new UnityAction(this._onAuctionButtonClick));
			}
			this.mAuction = null;
		}

		// Token: 0x0600DA69 RID: 55913 RVA: 0x0036EC18 File Offset: 0x0036D018
		private void _onQualitySelectDropdownValueChange(int index)
		{
			switch (index)
			{
			case 0:
				this.curSelColor = 0;
				break;
			case 1:
				this.curSelColor = 2;
				break;
			case 2:
				this.curSelColor = 3;
				break;
			case 3:
				this.curSelColor = 5;
				break;
			}
			this.minPrice = 0;
			this.maxPrice = 0;
			this._UpdateExpectPrice();
			this.donateList.Clear();
			this._UpdatePackage();
			this._UpdateWeekCount();
		}

		// Token: 0x0600DA6A RID: 55914 RVA: 0x0036EC9C File Offset: 0x0036D09C
		private void _onSubTypeSelectDropdownValueChange(int index)
		{
			if (index >= this.levelList.Count)
			{
				return;
			}
			this.curSelSubType = index;
			this.minPrice = 0;
			this.maxPrice = 0;
			this._UpdateExpectPrice();
			this.donateList.Clear();
			this._UpdatePackage();
			this._UpdateWeekCount();
		}

		// Token: 0x0600DA6B RID: 55915 RVA: 0x0036ECF0 File Offset: 0x0036D0F0
		private void _onSubmitButtonClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(delegate
			{
				for (int j = 0; j < this.donateList.Count; j++)
				{
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(this.donateList[j]);
					if (item2 != null && item2.Quality >= ItemTable.eColor.PURPLE)
					{
						return true;
					}
				}
				return false;
			}, null))
			{
				return;
			}
			if (this.donateList.Count == 0)
			{
				return;
			}
			string msgContent = string.Empty;
			bool flag = false;
			for (int i = 0; i < this.donateList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.donateList[i]);
				if (item != null)
				{
					if (item.EquipType == EEquipType.ET_REDMARK)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				msgContent = TR.Value("selected_equipment_has_red_equip_desc", "是否确认捐献?");
			}
			else
			{
				msgContent = TR.Value("equip_submit_tip");
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<EquipRecoveryDataManager>.GetInstance()._SubmitEquip(this.donateList);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EquipSubmitScore, this.minPrice, this.maxPrice, null, null);
			}, null, 0f, false);
		}

		// Token: 0x0600DA6C RID: 55916 RVA: 0x0036EDC8 File Offset: 0x0036D1C8
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<EquipDonateFrame>(this, false);
		}

		// Token: 0x0600DA6D RID: 55917 RVA: 0x0036EDD7 File Offset: 0x0036D1D7
		private void _onOpenPriceTableButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<EquipPriceFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DA6E RID: 55918 RVA: 0x0036EDEB File Offset: 0x0036D1EB
		private void _onAuctionButtonClick()
		{
			this.frameMgr.OpenFrame<AuctionNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04008069 RID: 32873
		private int curSelSubType;

		// Token: 0x0400806A RID: 32874
		private int curSelColor;

		// Token: 0x0400806B RID: 32875
		private int minPrice;

		// Token: 0x0400806C RID: 32876
		private int maxPrice;

		// Token: 0x0400806D RID: 32877
		private List<ulong> donateList = new List<ulong>();

		// Token: 0x0400806E RID: 32878
		private List<ulong> displayList = new List<ulong>();

		// Token: 0x0400806F RID: 32879
		private List<int> levelList = new List<int>();

		// Token: 0x04008070 RID: 32880
		private Dropdown mQualitySelect;

		// Token: 0x04008071 RID: 32881
		private Dropdown mSubTypeSelect;

		// Token: 0x04008072 RID: 32882
		private ComUIListScript mContent;

		// Token: 0x04008073 RID: 32883
		private ComUIListElementScript mRecord;

		// Token: 0x04008074 RID: 32884
		private Text mHaveScore;

		// Token: 0x04008075 RID: 32885
		private Text mExpectScore;

		// Token: 0x04008076 RID: 32886
		private Text mDonateCount;

		// Token: 0x04008077 RID: 32887
		private Button mSubmit;

		// Token: 0x04008078 RID: 32888
		private GameObject mContentRoot;

		// Token: 0x04008079 RID: 32889
		private Button mOpenPriceTable;

		// Token: 0x0400807A RID: 32890
		private Button mClose;

		// Token: 0x0400807B RID: 32891
		private Text mTips;

		// Token: 0x0400807C RID: 32892
		private Button mAuction;
	}
}
