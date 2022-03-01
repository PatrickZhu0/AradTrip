using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200175F RID: 5983
	internal class LevelGiftFrame : ClientFrame
	{
		// Token: 0x0600EC0D RID: 60429 RVA: 0x003EEBCC File Offset: 0x003ECFCC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/LevelGift";
		}

		// Token: 0x0600EC0E RID: 60430 RVA: 0x003EEBD4 File Offset: 0x003ECFD4
		protected override void _OnOpenFrame()
		{
			this.initdata();
			this.ClearMyList();
			this.SortMyList();
			this.LogErrorData();
			this._SelectToggle();
			this._RegistenUIEvent();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EC0F RID: 60431 RVA: 0x003EEC2B File Offset: 0x003ED02B
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this._UnRegistenUIEvent();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EC10 RID: 60432 RVA: 0x003EEC5F File Offset: 0x003ED05F
		private void _RegistenUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LeftSlip, new ClientEventSystem.UIEventHandler(this._LeftSlip));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RightSlip, new ClientEventSystem.UIEventHandler(this._RightSlip));
		}

		// Token: 0x0600EC11 RID: 60433 RVA: 0x003EEC97 File Offset: 0x003ED097
		private void _UnRegistenUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LeftSlip, new ClientEventSystem.UIEventHandler(this._LeftSlip));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RightSlip, new ClientEventSystem.UIEventHandler(this._RightSlip));
		}

		// Token: 0x0600EC12 RID: 60434 RVA: 0x003EECCF File Offset: 0x003ED0CF
		private void _LeftSlip(UIEvent uiEvent)
		{
			this._onPreviousButtonClick();
		}

		// Token: 0x0600EC13 RID: 60435 RVA: 0x003EECD7 File Offset: 0x003ED0D7
		private void _RightSlip(UIEvent uiEvent)
		{
			this._onNextButtonClick();
		}

		// Token: 0x0600EC14 RID: 60436 RVA: 0x003EECDF File Offset: 0x003ED0DF
		private void initdata()
		{
			if (this.activeData != null)
			{
				this.ElementSum = this.activeData.akChildItems.Count;
			}
			this.FirstPosIndex = 0;
			this.NowToggleIndex = 0;
			this.isSort = true;
		}

		// Token: 0x0600EC15 RID: 60437 RVA: 0x003EED18 File Offset: 0x003ED118
		private void ClearMyList()
		{
			this.MyActivityList.Clear();
			for (int i = 0; i < this.ElementSum; i++)
			{
				this.MyActivityList.Add(this.activeData.akChildItems[i]);
			}
		}

		// Token: 0x0600EC16 RID: 60438 RVA: 0x003EED63 File Offset: 0x003ED163
		private void SortMyList()
		{
			this.MyActivityList.Sort(delegate(ActiveManager.ActivityData x, ActiveManager.ActivityData y)
			{
				int result;
				if (x.activeItem.LevelLimit.CompareTo(y.activeItem.LevelLimit) < 0)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
				return result;
			});
		}

		// Token: 0x0600EC17 RID: 60439 RVA: 0x003EED90 File Offset: 0x003ED190
		private void LogErrorData()
		{
			for (int i = 0; i < this.MyActivityList.Count; i++)
			{
				if (this.MyActivityList[i].activeItem.LevelLimit <= (int)DataManager<PlayerBaseData>.GetInstance().Level && this.MyActivityList[i].status == 1)
				{
					Logger.LogErrorFormat("1--- levelLimit = {0},peopleLevel = {1},activeItemID = {2}", new object[]
					{
						this.MyActivityList[i].activeItem.LevelLimit,
						DataManager<PlayerBaseData>.GetInstance().Level,
						this.MyActivityList[i].activeItem.ID
					});
				}
				if (this.MyActivityList[i].activeItem.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level && this.MyActivityList[i].status != 1)
				{
					Logger.LogErrorFormat("2--- levelLimit = {0},peopleLevel = {1},activeState = {2},activeItemID = {3}", new object[]
					{
						this.MyActivityList[i].activeItem.LevelLimit,
						DataManager<PlayerBaseData>.GetInstance().Level,
						this.MyActivityList[i].status,
						this.MyActivityList[i].activeItem.ID
					});
				}
			}
		}

		// Token: 0x0600EC18 RID: 60440 RVA: 0x003EEF08 File Offset: 0x003ED308
		private void _SelectToggle()
		{
			bool flag = false;
			for (int i = 0; i < this.ElementSum; i++)
			{
				if (this.MyActivityList[i].status == 2)
				{
					this._updateElementData(i / 4 * 4);
					this.toggle[i / 4].isOn = true;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < this.ElementSum; j++)
				{
					if (this.MyActivityList[j].activeItem.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						this._updateElementData(j / 4 * 4);
						this.toggle[j / 4].isOn = true;
						break;
					}
				}
			}
		}

		// Token: 0x0600EC19 RID: 60441 RVA: 0x003EEFC9 File Offset: 0x003ED3C9
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.ClearMyList();
			this.SortMyList();
			this.LogErrorData();
			this._updateBtStatus();
		}

		// Token: 0x0600EC1A RID: 60442 RVA: 0x003EEFE3 File Offset: 0x003ED3E3
		private void ClearData()
		{
			if (this.ItemdataList != null)
			{
				this.ItemdataList.Clear();
			}
			if (this.MyActivityList != null)
			{
				this.MyActivityList.Clear();
			}
		}

		// Token: 0x0600EC1B RID: 60443 RVA: 0x003EF014 File Offset: 0x003ED414
		private void _updateBtStatus()
		{
			for (int i = this.FirstPosIndex; i < this.FirstPosIndex + 4; i++)
			{
				if (this.MyActivityList[i].status == 5)
				{
					this.comlevelele[i - this.FirstPosIndex].Accomplish.CustomActive(true);
					this.comlevelele[i - this.FirstPosIndex].ReceiveGray.enabled = true;
					this.comlevelele[i - this.FirstPosIndex].Uncomplete.CustomActive(false);
					this.comlevelele[i - this.FirstPosIndex].ReceiveText.text = "已领取";
				}
				else if (this.MyActivityList[i].status == 2)
				{
					this.comlevelele[i - this.FirstPosIndex].Accomplish.CustomActive(false);
					this.comlevelele[i - this.FirstPosIndex].ReceiveGray.enabled = false;
					this.comlevelele[i - this.FirstPosIndex].Uncomplete.CustomActive(false);
					this.comlevelele[i - this.FirstPosIndex].ReceiveText.text = "可领取";
				}
				else if (this.MyActivityList[i].status == 1)
				{
					this.comlevelele[i - this.FirstPosIndex].Accomplish.CustomActive(false);
					this.comlevelele[i - this.FirstPosIndex].ReceiveGray.enabled = true;
					this.comlevelele[i - this.FirstPosIndex].Uncomplete.CustomActive(true);
				}
			}
		}

		// Token: 0x0600EC1C RID: 60444 RVA: 0x003EF1B4 File Offset: 0x003ED5B4
		private void _updateElementData(int index)
		{
			if (index < 0)
			{
				index = 0;
			}
			if (index > 14)
			{
				index = 14;
			}
			this.FirstPosIndex = index;
			for (int i = 0; i < 4; i++)
			{
				int index_i = this.FirstPosIndex + i;
				int tableID = this.MyActivityList[index_i].ID;
				this.ItemdataList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.MyActivityList[this.FirstPosIndex + i].ID);
				if (this.ItemdataList == null)
				{
					Logger.LogErrorFormat("ItemdataList is null", new object[0]);
					return;
				}
				ComItem comItem = null;
				this._updateBtStatus();
				this.comlevelele[i].LevelLimit.text = string.Format("{0}级可领取", this.MyActivityList[this.FirstPosIndex + i].activeItem.LevelLimit);
				this.comlevelele[i].LevelTitle.text = string.Format("{0}级礼包", this.MyActivityList[this.FirstPosIndex + i].activeItem.LevelLimit);
				this.comlevelele[i].icon0.gameObject.CustomActive(false);
				this.comlevelele[i].text0.gameObject.CustomActive(false);
				this.comlevelele[i].icon1.gameObject.CustomActive(false);
				this.comlevelele[i].text1.gameObject.CustomActive(false);
				this.comlevelele[i].icon2.gameObject.CustomActive(false);
				this.comlevelele[i].text2.gameObject.CustomActive(false);
				for (int j = 0; j < this.ItemdataList.Count; j++)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[j].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("ItemData is null", new object[0]);
						return;
					}
					itemData.Count = this.ItemdataList[j].Num;
					itemData.EquipType = (EEquipType)this.ItemdataList[j].EquipType;
					itemData.StrengthenLevel = this.ItemdataList[j].StrengthenLevel;
					if (j == 0)
					{
						comItem = this.comlevelele[i].icon0.gameObject.GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							comItem = base.CreateComItem(this.comlevelele[i].icon0.gameObject);
						}
						this.comlevelele[i].icon0.gameObject.CustomActive(true);
						this.comlevelele[i].text0.text = itemData.Name;
						this.comlevelele[i].text0.gameObject.CustomActive(true);
					}
					else if (j == 1)
					{
						comItem = this.comlevelele[i].icon1.gameObject.GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							comItem = base.CreateComItem(this.comlevelele[i].icon1.gameObject);
						}
						this.comlevelele[i].icon1.gameObject.CustomActive(true);
						this.comlevelele[i].text1.text = itemData.Name;
						this.comlevelele[i].text1.gameObject.CustomActive(true);
					}
					else if (j == 2)
					{
						comItem = this.comlevelele[i].icon2.gameObject.GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							comItem = base.CreateComItem(this.comlevelele[i].icon2.gameObject);
						}
						this.comlevelele[i].icon2.gameObject.CustomActive(true);
						this.comlevelele[i].text2.text = itemData.Name;
						this.comlevelele[i].text2.gameObject.CustomActive(true);
					}
					if (comItem == null)
					{
						Logger.LogErrorFormat("comitem is null", new object[0]);
						return;
					}
					int index_j = j;
					comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowItemDetailData(index_i, index_j);
					});
					comItem.labLevel.fontSize = 30;
				}
				this.comlevelele[i].Receive.onClick.RemoveAllListeners();
				this.comlevelele[i].Receive.onClick.AddListener(delegate()
				{
					DataManager<ActiveManager>.GetInstance().SendSubmitActivity(tableID, 0U);
				});
			}
		}

		// Token: 0x0600EC1D RID: 60445 RVA: 0x003EF658 File Offset: 0x003EDA58
		private void OnShowItemDetailData(int iIndex, int jIndex)
		{
			if (iIndex < 0 || iIndex >= this.ElementSum)
			{
				Logger.LogErrorFormat("iIndex out of range", new object[0]);
				return;
			}
			this.ItemdataList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.MyActivityList[iIndex].ID);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[jIndex].ID, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemDerailData is null", new object[0]);
				return;
			}
			itemData.Count = this.ItemdataList[jIndex].Num;
			itemData.EquipType = (EEquipType)this.ItemdataList[jIndex].EquipType;
			itemData.StrengthenLevel = this.ItemdataList[jIndex].StrengthenLevel;
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600EC1E RID: 60446 RVA: 0x003EF730 File Offset: 0x003EDB30
		protected override void _bindExUI()
		{
			this.mCloseframe = this.mBind.GetCom<Button>("closeframe");
			this.mCloseframe.onClick.AddListener(new UnityAction(this._onCloseframeButtonClick));
			this.mContent = this.mBind.GetGameObject("Content");
			this.mpos0 = this.mBind.GetGameObject("pos0");
			this.mpos1 = this.mBind.GetGameObject("pos1");
			this.mpos2 = this.mBind.GetGameObject("pos2");
			this.mpos3 = this.mBind.GetGameObject("pos3");
			this.mNext = this.mBind.GetCom<Button>("next");
			this.mNext.onClick.AddListener(new UnityAction(this._onNextButtonClick));
			this.mPrevious = this.mBind.GetCom<Button>("previous");
			this.mPrevious.onClick.AddListener(new UnityAction(this._onPreviousButtonClick));
			this.mToggle0 = this.mBind.GetCom<Toggle>("toggle0");
			this.mToggle0.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle0ToggleValueChange));
			this.mToggle1 = this.mBind.GetCom<Toggle>("toggle1");
			this.mToggle1.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle1ToggleValueChange));
			this.mToggle2 = this.mBind.GetCom<Toggle>("toggle2");
			this.mToggle2.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle2ToggleValueChange));
			this.mToggle3 = this.mBind.GetCom<Toggle>("toggle3");
			this.mToggle3.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle3ToggleValueChange));
			this.mToggle4 = this.mBind.GetCom<Toggle>("toggle4");
			this.mToggle4.onValueChanged.AddListener(new UnityAction<bool>(this._onToggle4ToggleValueChange));
		}

		// Token: 0x0600EC1F RID: 60447 RVA: 0x003EF93C File Offset: 0x003EDD3C
		protected override void _unbindExUI()
		{
			this.mCloseframe.onClick.RemoveListener(new UnityAction(this._onCloseframeButtonClick));
			this.mCloseframe = null;
			this.mContent = null;
			this.mpos0 = null;
			this.mpos1 = null;
			this.mpos2 = null;
			this.mpos3 = null;
			this.mNext.onClick.RemoveListener(new UnityAction(this._onNextButtonClick));
			this.mNext = null;
			this.mPrevious.onClick.RemoveListener(new UnityAction(this._onPreviousButtonClick));
			this.mPrevious = null;
			this.mToggle0.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle0ToggleValueChange));
			this.mToggle0 = null;
			this.mToggle1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle1ToggleValueChange));
			this.mToggle1 = null;
			this.mToggle2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle2ToggleValueChange));
			this.mToggle2 = null;
			this.mToggle3.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle3ToggleValueChange));
			this.mToggle3 = null;
			this.mToggle4.onValueChanged.RemoveListener(new UnityAction<bool>(this._onToggle4ToggleValueChange));
			this.mToggle4 = null;
		}

		// Token: 0x0600EC20 RID: 60448 RVA: 0x003EFA84 File Offset: 0x003EDE84
		private void _onCloseframeButtonClick()
		{
			this.frameMgr.CloseFrame<LevelGiftFrame>(this, false);
		}

		// Token: 0x0600EC21 RID: 60449 RVA: 0x003EFA93 File Offset: 0x003EDE93
		private void _onNextButtonClick()
		{
			if (this.NowToggleIndex + 1 < 5)
			{
				this.NowToggleIndex++;
				this.toggle[this.NowToggleIndex].isOn = true;
			}
		}

		// Token: 0x0600EC22 RID: 60450 RVA: 0x003EFAC4 File Offset: 0x003EDEC4
		private void _onPreviousButtonClick()
		{
			if (this.NowToggleIndex - 1 >= 0)
			{
				this.NowToggleIndex--;
				this.toggle[this.NowToggleIndex].isOn = true;
			}
		}

		// Token: 0x0600EC23 RID: 60451 RVA: 0x003EFAF5 File Offset: 0x003EDEF5
		private void _onToggle0ToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.isSort = true;
				this._updateElementData(0);
				this.NowToggleIndex = 0;
			}
		}

		// Token: 0x0600EC24 RID: 60452 RVA: 0x003EFB12 File Offset: 0x003EDF12
		private void _onToggle1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				if (this.isSort)
				{
					this._updateElementData(4);
				}
				else
				{
					this._updateElementData(1);
				}
				this.NowToggleIndex = 1;
			}
		}

		// Token: 0x0600EC25 RID: 60453 RVA: 0x003EFB3F File Offset: 0x003EDF3F
		private void _onToggle2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				if (this.isSort)
				{
					this._updateElementData(8);
				}
				else
				{
					this._updateElementData(5);
				}
				this.NowToggleIndex = 2;
			}
		}

		// Token: 0x0600EC26 RID: 60454 RVA: 0x003EFB6C File Offset: 0x003EDF6C
		private void _onToggle3ToggleValueChange(bool changed)
		{
			if (changed)
			{
				if (this.isSort)
				{
					this._updateElementData(12);
				}
				else
				{
					this._updateElementData(9);
				}
				this.NowToggleIndex = 3;
			}
		}

		// Token: 0x0600EC27 RID: 60455 RVA: 0x003EFB9B File Offset: 0x003EDF9B
		private void _onToggle4ToggleValueChange(bool changed)
		{
			if (changed)
			{
				this.isSort = false;
				this._updateElementData(16);
				this.NowToggleIndex = 4;
			}
		}

		// Token: 0x04008F62 RID: 36706
		private string GiftElementPath = "UIFlatten/Prefabs/MainFrameTown/LevelGiftElement";

		// Token: 0x04008F63 RID: 36707
		private GameObject LevelGiftElement;

		// Token: 0x04008F64 RID: 36708
		private int ElementSum = 17;

		// Token: 0x04008F65 RID: 36709
		private int FirstPosIndex;

		// Token: 0x04008F66 RID: 36710
		private int NowToggleIndex;

		// Token: 0x04008F67 RID: 36711
		private bool isSort = true;

		// Token: 0x04008F68 RID: 36712
		private List<ActiveManager.ActivityData> MyActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x04008F69 RID: 36713
		private List<AwardItemData> ItemdataList = new List<AwardItemData>();

		// Token: 0x04008F6A RID: 36714
		private ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(4000);

		// Token: 0x04008F6B RID: 36715
		[UIControl("Middle/pos{0}", typeof(RectTransform), 0)]
		private RectTransform[] ElementPos = new RectTransform[4];

		// Token: 0x04008F6C RID: 36716
		[UIControl("Middle/pos{0}/LevelGiftElement", typeof(ComLevelGiftEle), 0)]
		private ComLevelGiftEle[] comlevelele = new ComLevelGiftEle[4];

		// Token: 0x04008F6D RID: 36717
		[UIControl("Middle/tabs/Toggle{0}", typeof(Toggle), 0)]
		private Toggle[] toggle = new Toggle[5];

		// Token: 0x04008F6E RID: 36718
		private Button mCloseframe;

		// Token: 0x04008F6F RID: 36719
		private GameObject mContent;

		// Token: 0x04008F70 RID: 36720
		private GameObject mpos0;

		// Token: 0x04008F71 RID: 36721
		private GameObject mpos1;

		// Token: 0x04008F72 RID: 36722
		private GameObject mpos2;

		// Token: 0x04008F73 RID: 36723
		private GameObject mpos3;

		// Token: 0x04008F74 RID: 36724
		private Button mNext;

		// Token: 0x04008F75 RID: 36725
		private Button mPrevious;

		// Token: 0x04008F76 RID: 36726
		private Toggle mToggle0;

		// Token: 0x04008F77 RID: 36727
		private Toggle mToggle1;

		// Token: 0x04008F78 RID: 36728
		private Toggle mToggle2;

		// Token: 0x04008F79 RID: 36729
		private Toggle mToggle3;

		// Token: 0x04008F7A RID: 36730
		private Toggle mToggle4;
	}
}
