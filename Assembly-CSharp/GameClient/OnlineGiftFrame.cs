using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001765 RID: 5989
	internal class OnlineGiftFrame : ClientFrame
	{
		// Token: 0x0600EC5F RID: 60511 RVA: 0x003F10BA File Offset: 0x003EF4BA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/OnlineGift";
		}

		// Token: 0x0600EC60 RID: 60512 RVA: 0x003F10C1 File Offset: 0x003EF4C1
		protected override void _OnOpenFrame()
		{
			this.ClearMyList();
			this.SortMyList();
			this._updateButtonStatus();
			this._updateElementData();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EC61 RID: 60513 RVA: 0x003F1101 File Offset: 0x003EF501
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EC62 RID: 60514 RVA: 0x003F112F File Offset: 0x003EF52F
		private void ClearData()
		{
			this.ItemdataList.Clear();
			this.MyActivityList.Clear();
		}

		// Token: 0x0600EC63 RID: 60515 RVA: 0x003F1147 File Offset: 0x003EF547
		private void SortMyList()
		{
			this.MyActivityList.Sort(delegate(ActiveManager.ActivityData x, ActiveManager.ActivityData y)
			{
				string s = string.Empty;
				string s2 = string.Empty;
				s = x.activeItem.Param0;
				s2 = y.activeItem.Param0;
				int num;
				int.TryParse(s, out num);
				int value;
				int.TryParse(s2, out value);
				int result;
				if (num.CompareTo(value) < 0)
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

		// Token: 0x0600EC64 RID: 60516 RVA: 0x003F1174 File Offset: 0x003EF574
		private void ClearMyList()
		{
			this.MyActivityList.Clear();
			for (int i = 0; i < 7; i++)
			{
				this.MyActivityList.Add(this.activeData.akChildItems[i]);
			}
		}

		// Token: 0x0600EC65 RID: 60517 RVA: 0x003F11BC File Offset: 0x003EF5BC
		private void _isAccomplish(int index)
		{
			this.ElementAccomplish[index].gameObject.CustomActive(true);
			this.ElementReceiveGray[index].enabled = true;
			this.ElementUnicomplete[index].gameObject.CustomActive(false);
			this.ElementReceiveText[index].text = "已领取";
		}

		// Token: 0x0600EC66 RID: 60518 RVA: 0x003F1210 File Offset: 0x003EF610
		private void _isReceive(int index)
		{
			this.ElementAccomplish[index].gameObject.CustomActive(false);
			this.ElementReceiveGray[index].enabled = false;
			this.ElementUnicomplete[index].gameObject.CustomActive(false);
			this.ElementReceiveText[index].text = "可领取";
		}

		// Token: 0x0600EC67 RID: 60519 RVA: 0x003F1263 File Offset: 0x003EF663
		private void _isUncomplete(int index)
		{
			this.ElementAccomplish[index].gameObject.CustomActive(false);
			this.ElementReceiveGray[index].enabled = true;
			this.ElementUnicomplete[index].gameObject.CustomActive(true);
		}

		// Token: 0x0600EC68 RID: 60520 RVA: 0x003F1299 File Offset: 0x003EF699
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.ClearMyList();
			this.SortMyList();
			this._updateButtonStatus();
		}

		// Token: 0x0600EC69 RID: 60521 RVA: 0x003F12B0 File Offset: 0x003EF6B0
		private void _updateButtonStatus()
		{
			for (int i = 0; i < 7; i++)
			{
				if (this.MyActivityList[i].status == 5)
				{
					this.ElementAccomplish[i].gameObject.CustomActive(true);
					this.ElementReceiveGray[i].enabled = true;
					this.ElementUnicomplete[i].gameObject.CustomActive(false);
					this.ElementReceiveText[i].text = "已领取";
				}
				else if (this.MyActivityList[i].status == 2)
				{
					this.ElementAccomplish[i].gameObject.CustomActive(false);
					this.ElementReceiveGray[i].enabled = false;
					this.ElementUnicomplete[i].gameObject.CustomActive(false);
					this.ElementReceiveText[i].text = "可领取";
				}
				else if (this.MyActivityList[i].status == 1)
				{
					this.ElementAccomplish[i].gameObject.CustomActive(false);
					this.ElementReceiveGray[i].enabled = true;
					this.ElementUnicomplete[i].gameObject.CustomActive(true);
				}
			}
		}

		// Token: 0x0600EC6A RID: 60522 RVA: 0x003F13E0 File Offset: 0x003EF7E0
		private void _updateElementData()
		{
			if (this.activeData == null)
			{
				Logger.LogErrorFormat("activeData is null from 5000", new object[0]);
			}
			for (int i = 0; i < 7; i++)
			{
				this.ElementTimeLimit[i].text = string.Format("{0}分钟", this.MyActivityList[i].activeItem.Param0);
				this.ItemdataList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.MyActivityList[i].ID);
				if (this.ItemdataList == null)
				{
					Logger.LogErrorFormat("ItemdataList is null from OnlineGiftFrane", new object[0]);
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[0].ID, 100, 0);
				if (itemData == null)
				{
					Logger.LogErrorFormat("ItemData is null", new object[0]);
				}
				if (itemData != null)
				{
					itemData.Count = this.ItemdataList[0].Num;
					itemData.EquipType = (EEquipType)this.ItemdataList[0].EquipType;
					itemData.StrengthenLevel = this.ItemdataList[0].StrengthenLevel;
					ComItem comItem = base.CreateComItem(this.ElementIcon[i].gameObject);
					if (comItem == null)
					{
						Logger.LogErrorFormat("comitem is null", new object[0]);
					}
					int index = i;
					this.ElementReceive[i].onClick.RemoveAllListeners();
					this.ElementReceive[index].onClick.AddListener(delegate()
					{
						DataManager<ActiveManager>.GetInstance().SendSubmitActivity(this.GetActiveID(index), 0U);
					});
					comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowItemDetailData(index);
					});
					this.ElementText[i].text = itemData.Name;
				}
			}
		}

		// Token: 0x0600EC6B RID: 60523 RVA: 0x003F15A4 File Offset: 0x003EF9A4
		private int GetActiveID(int index)
		{
			return this.ActiveTableID[index];
		}

		// Token: 0x0600EC6C RID: 60524 RVA: 0x003F15B0 File Offset: 0x003EF9B0
		private void OnShowItemDetailData(int iIndex)
		{
			if (iIndex < 0 || iIndex >= 7)
			{
				Logger.LogErrorFormat("iIndex out of range", new object[0]);
				return;
			}
			this.ItemdataList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.MyActivityList[iIndex].ID);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.ItemdataList[0].ID, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemDerailData is null", new object[0]);
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600EC6D RID: 60525 RVA: 0x003F1640 File Offset: 0x003EFA40
		protected override void _bindExUI()
		{
			this.mCloseframe = this.mBind.GetCom<Button>("closeframe");
			this.mCloseframe.onClick.AddListener(new UnityAction(this._onCloseframeButtonClick));
			this.mReceive0 = this.mBind.GetCom<Button>("receive0");
			this.mReceive0.onClick.AddListener(new UnityAction(this._onReceive0ButtonClick));
		}

		// Token: 0x0600EC6E RID: 60526 RVA: 0x003F16B4 File Offset: 0x003EFAB4
		protected override void _unbindExUI()
		{
			this.mCloseframe.onClick.RemoveListener(new UnityAction(this._onCloseframeButtonClick));
			this.mCloseframe = null;
			this.mReceive0.onClick.RemoveListener(new UnityAction(this._onReceive0ButtonClick));
			this.mReceive0 = null;
		}

		// Token: 0x0600EC6F RID: 60527 RVA: 0x003F1707 File Offset: 0x003EFB07
		private void _onCloseframeButtonClick()
		{
			this.frameMgr.CloseFrame<OnlineGiftFrame>(this, false);
		}

		// Token: 0x0600EC70 RID: 60528 RVA: 0x003F1716 File Offset: 0x003EFB16
		private void _onReceive0ButtonClick()
		{
		}

		// Token: 0x04008FB5 RID: 36789
		private List<ActiveManager.ActivityData> MyActivityList = new List<ActiveManager.ActivityData>();

		// Token: 0x04008FB6 RID: 36790
		private const int ElementSum = 7;

		// Token: 0x04008FB7 RID: 36791
		private List<AwardItemData> ItemdataList;

		// Token: 0x04008FB8 RID: 36792
		private ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(5000);

		// Token: 0x04008FB9 RID: 36793
		private int[] ActiveTableID = new int[]
		{
			2202,
			2203,
			2204,
			2205,
			2206,
			2207,
			2208
		};

		// Token: 0x04008FBA RID: 36794
		[UIControl("Middle/Element{0}", typeof(RectTransform), 0)]
		private RectTransform[] ElementPos = new RectTransform[7];

		// Token: 0x04008FBB RID: 36795
		[UIControl("Middle/Element{0}/Text", typeof(Text), 0)]
		private Text[] ElementText = new Text[7];

		// Token: 0x04008FBC RID: 36796
		[UIControl("Middle/Element{0}/ItemIcon", typeof(Image), 0)]
		private Image[] ElementIcon = new Image[7];

		// Token: 0x04008FBD RID: 36797
		[UIControl("Middle/Element{0}/accomplish", typeof(RectTransform), 0)]
		private RectTransform[] ElementAccomplish = new RectTransform[7];

		// Token: 0x04008FBE RID: 36798
		[UIControl("Middle/Element{0}/receive", typeof(Button), 0)]
		private Button[] ElementReceive = new Button[7];

		// Token: 0x04008FBF RID: 36799
		[UIControl("Middle/Element{0}/uncomplete", typeof(RectTransform), 0)]
		private RectTransform[] ElementUnicomplete = new RectTransform[7];

		// Token: 0x04008FC0 RID: 36800
		[UIControl("Middle/Element{0}/receive", typeof(UIGray), 0)]
		private UIGray[] ElementReceiveGray = new UIGray[7];

		// Token: 0x04008FC1 RID: 36801
		[UIControl("Middle/Element{0}/receive/Text", typeof(Text), 0)]
		private Text[] ElementReceiveText = new Text[7];

		// Token: 0x04008FC2 RID: 36802
		[UIControl("Middle/Element{0}/uncomplete/Text", typeof(Text), 0)]
		private Text[] ElementTimeLimit = new Text[7];

		// Token: 0x04008FC3 RID: 36803
		private Button mCloseframe;

		// Token: 0x04008FC4 RID: 36804
		private Button mReceive0;
	}
}
