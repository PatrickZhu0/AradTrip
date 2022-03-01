using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200112D RID: 4397
	public class PlayerItemFrame : ClientFrame
	{
		// Token: 0x0600A721 RID: 42785 RVA: 0x0022D726 File Offset: 0x0022BB26
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/PlayerItemFrame";
		}

		// Token: 0x0600A722 RID: 42786 RVA: 0x0022D730 File Offset: 0x0022BB30
		protected override void _OnOpenFrame()
		{
			ChijiOtherPlayerItems otherPlayerItems = DataManager<ChijiDataManager>.GetInstance().OtherPlayerItems;
			if (otherPlayerItems != null && otherPlayerItems.detailItems != null)
			{
				this.detailItems = otherPlayerItems.detailItems;
			}
			this._InitPlayerItemScrollListBind();
			this.RefreshPlayerItemListCount();
			this._SetTitleName();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PickUpLoserItem, new ClientEventSystem.UIEventHandler(this._OnPickUpLoserItem));
		}

		// Token: 0x0600A723 RID: 42787 RVA: 0x0022D792 File Offset: 0x0022BB92
		protected override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x0600A724 RID: 42788 RVA: 0x0022D79A File Offset: 0x0022BB9A
		private void _ClearData()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PickUpLoserItem, new ClientEventSystem.UIEventHandler(this._OnPickUpLoserItem));
			if (this.detailItems != null)
			{
				this.detailItems.Clear();
			}
		}

		// Token: 0x0600A725 RID: 42789 RVA: 0x0022D7D0 File Offset: 0x0022BBD0
		private void _OnPickUpLoserItem(UIEvent uiEvent)
		{
			ulong num = (ulong)uiEvent.Param1;
			for (int i = 0; i < this.detailItems.Count; i++)
			{
				if (num == this.detailItems[i].guid)
				{
					this.detailItems.RemoveAt(i);
					break;
				}
			}
			this.RefreshPlayerItemListCount();
		}

		// Token: 0x0600A726 RID: 42790 RVA: 0x0022D834 File Offset: 0x0022BC34
		private void _InitPlayerItemScrollListBind()
		{
			this.mPlayerItemsScrollView.Initialize();
			this.mPlayerItemsScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateItemScrollListBind(item);
				}
			};
			this.mPlayerItemsScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("item");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x0600A727 RID: 42791 RVA: 0x0022D88C File Offset: 0x0022BC8C
		private void _UpdateItemScrollListBind(ComUIListElementScript item)
		{
			ChijiOtherPlayerItems otherPlayerItems = DataManager<ChijiDataManager>.GetInstance().OtherPlayerItems;
			if (otherPlayerItems == null)
			{
				return;
			}
			if (this.detailItems == null || item.m_index < 0 || item.m_index >= this.detailItems.Count)
			{
				return;
			}
			OtherPlayerDetailItem otherPlayerDetailItem = this.detailItems[item.m_index];
			if (otherPlayerDetailItem == null)
			{
				return;
			}
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("name");
			Image com2 = component.GetCom<Image>("icon");
			Button com3 = component.GetCom<Button>("item");
			Image com4 = component.GetCom<Image>("itemBg");
			Text com5 = component.GetCom<Text>("num");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)otherPlayerDetailItem.itemTypeId, 100, 0);
			if (com != null && itemData != null)
			{
				com.text = itemData.GetColorName(string.Empty, false);
			}
			if (com2 != null && itemData != null)
			{
				ETCImageLoader.LoadSprite(ref com2, itemData.Icon, true);
			}
			if (com4 != null && itemData != null)
			{
				ETCImageLoader.LoadSprite(ref com4, itemData.GetQualityInfo().Background, true);
			}
			if (com5 != null)
			{
				if (otherPlayerDetailItem.num > 0U)
				{
					com5.text = otherPlayerDetailItem.num.ToString();
					com5.gameObject.CustomActive(true);
				}
				else
				{
					com5.gameObject.CustomActive(false);
				}
			}
			if (com3 != null)
			{
				com3.onClick.RemoveAllListeners();
				ulong playerid = otherPlayerItems.playerID;
				ulong guid = otherPlayerDetailItem.guid;
				com3.onClick.AddListener(delegate()
				{
					this._OnClickPlayerItem(guid, playerid);
				});
			}
		}

		// Token: 0x0600A728 RID: 42792 RVA: 0x0022DA74 File Offset: 0x0022BE74
		public void RefreshPlayerItemListCount()
		{
			if (this.mPlayerItemsScrollView == null)
			{
				return;
			}
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
			{
				return;
			}
			if (this.detailItems != null)
			{
				this.mPlayerItemsScrollView.SetElementAmount(this.detailItems.Count);
			}
		}

		// Token: 0x0600A729 RID: 42793 RVA: 0x0022DACC File Offset: 0x0022BECC
		private void _SetTitleName()
		{
			ChijiOtherPlayerItems otherPlayerItems = DataManager<ChijiDataManager>.GetInstance().OtherPlayerItems;
			JoinPlayerInfo joinPlayerInfo = null;
			if (DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList != null)
			{
				for (int i = 0; i < DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList.Count; i++)
				{
					JoinPlayerInfo joinPlayerInfo2 = DataManager<ChijiDataManager>.GetInstance().JoinPlayerInfoList[i];
					if (joinPlayerInfo2.playerId == otherPlayerItems.playerID)
					{
						joinPlayerInfo = joinPlayerInfo2;
						break;
					}
				}
			}
			if (this.mTitleName != null && joinPlayerInfo != null)
			{
				this.mTitleName.text = string.Format("{0}的物品", joinPlayerInfo.playerName);
			}
		}

		// Token: 0x0600A72A RID: 42794 RVA: 0x0022DB78 File Offset: 0x0022BF78
		private void _OnClickPlayerItem(ulong guid, ulong playerid)
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
			{
				Logger.LogError("Current System is not GameBattle!!!");
				return;
			}
			DataManager<ChijiDataManager>.GetInstance().SendPickUpOtherPlayerItems(guid, playerid);
		}

		// Token: 0x0600A72B RID: 42795 RVA: 0x0022DBB4 File Offset: 0x0022BFB4
		protected override void _bindExUI()
		{
			this.mPlayerItemsScrollView = this.mBind.GetCom<ComUIListScript>("PlayerItemsScrollView");
			this.mAllPickUpItem = this.mBind.GetCom<Button>("AllPickUpItem");
			if (null != this.mAllPickUpItem)
			{
				this.mAllPickUpItem.onClick.AddListener(new UnityAction(this._onAllPickUpItemButtonClick));
			}
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mTitleName = this.mBind.GetCom<Text>("title");
		}

		// Token: 0x0600A72C RID: 42796 RVA: 0x0022DC74 File Offset: 0x0022C074
		protected override void _unbindExUI()
		{
			this.mPlayerItemsScrollView = null;
			if (null != this.mAllPickUpItem)
			{
				this.mAllPickUpItem.onClick.RemoveListener(new UnityAction(this._onAllPickUpItemButtonClick));
			}
			this.mAllPickUpItem = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mTitleName = null;
		}

		// Token: 0x0600A72D RID: 42797 RVA: 0x0022DCF0 File Offset: 0x0022C0F0
		private void _onAllPickUpItemButtonClick()
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle))
			{
				return;
			}
			ChijiOtherPlayerItems otherPlayerItems = DataManager<ChijiDataManager>.GetInstance().OtherPlayerItems;
			if (otherPlayerItems != null && this.detailItems != null)
			{
				for (int i = 0; i < this.detailItems.Count; i++)
				{
					DataManager<ChijiDataManager>.GetInstance().SendPickUpOtherPlayerItems(this.detailItems[i].guid, otherPlayerItems.playerID);
				}
			}
			this._onCloseButtonClick();
		}

		// Token: 0x0600A72E RID: 42798 RVA: 0x0022DD73 File Offset: 0x0022C173
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<PlayerItemFrame>(this, false);
		}

		// Token: 0x04005D85 RID: 23941
		private List<OtherPlayerDetailItem> detailItems = new List<OtherPlayerDetailItem>();

		// Token: 0x04005D86 RID: 23942
		private ComUIListScript mPlayerItemsScrollView;

		// Token: 0x04005D87 RID: 23943
		private Button mAllPickUpItem;

		// Token: 0x04005D88 RID: 23944
		private Button mClose;

		// Token: 0x04005D89 RID: 23945
		private Text mTitleName;
	}
}
