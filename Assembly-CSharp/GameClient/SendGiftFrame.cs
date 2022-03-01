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
	// Token: 0x0200191E RID: 6430
	public class SendGiftFrame : ClientFrame
	{
		// Token: 0x0600FA49 RID: 64073 RVA: 0x0044848E File Offset: 0x0044688E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/SendGiftFrame";
		}

		// Token: 0x0600FA4A RID: 64074 RVA: 0x00448498 File Offset: 0x00446898
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mItemData = (ItemData)this.userData;
			if (this.mItemUIList != null && !this.mItemUIList.IsInitialised())
			{
				this.mItemUIList.Initialize();
				ComUIListScript comUIListScript = this.mItemUIList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiable));
				ComUIListScript comUIListScript2 = this.mItemUIList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnItemVisiable));
				ComUIListScript comUIListScript3 = this.mItemUIList;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnItemRecycle));
			}
			this.mSendBtn.CustomActive(false);
			this.mNoTipCanvas.alpha = 0f;
			NetProcess.AddMsgHandler(609702U, new Action<MsgDATA>(this._OnFriendPresentInfosRet));
			NetProcess.AddMsgHandler(609704U, new Action<MsgDATA>(this._OnSendFriendPresentRet));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateLeftGiftNum));
			if (this.mItemData != null)
			{
				this._ShowLeftGiftNum();
				this._RequestFriendPresentInfosReq(this.mItemData.TableID);
			}
		}

		// Token: 0x0600FA4B RID: 64075 RVA: 0x004485E4 File Offset: 0x004469E4
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mSelectData = null;
			this.mItemData = null;
			this.mDataList.Clear();
			NetProcess.RemoveMsgHandler(609702U, new Action<MsgDATA>(this._OnFriendPresentInfosRet));
			NetProcess.RemoveMsgHandler(609704U, new Action<MsgDATA>(this._OnSendFriendPresentRet));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateLeftGiftNum));
		}

		// Token: 0x0600FA4C RID: 64076 RVA: 0x00448658 File Offset: 0x00446A58
		protected override void _bindExUI()
		{
			this.mItemUIList = this.mBind.GetCom<ComUIListScript>("ItemList");
			this.mSendBtn = this.mBind.GetCom<Button>("SendBtn");
			this.mSendBtn.SafeAddOnClickListener(new UnityAction(this._OnSendBtnClick));
			this.mCloseBtn = this.mBind.GetCom<Button>("btClose");
			this.mCloseBtn.SafeAddOnClickListener(new UnityAction(this._OnCloseBtnClick));
			this.mUIGray = this.mBind.GetCom<UIGray>("SendBtnGray");
			this.mRemainGiftNumTxt = this.mBind.GetCom<Text>("RemianGiftCountTxt");
			this.mNoTipCanvas = this.mBind.GetCom<CanvasGroup>("NoTip");
			this.mBeSendTotalNumTxt = this.mBind.GetCom<Text>("BeSendTotalNumTxt");
		}

		// Token: 0x0600FA4D RID: 64077 RVA: 0x00448730 File Offset: 0x00446B30
		protected override void _unbindExUI()
		{
			this.mItemUIList = null;
			this.mSendBtn.SafeRemoveOnClickListener(new UnityAction(this._OnSendBtnClick));
			this.mSendBtn = null;
			this.mCloseBtn.SafeRemoveOnClickListener(new UnityAction(this._OnCloseBtnClick));
			this.mCloseBtn = null;
			this.mUIGray = null;
			this.mRemainGiftNumTxt = null;
			this.mNoTipCanvas = null;
			this.mBeSendTotalNumTxt = null;
		}

		// Token: 0x0600FA4E RID: 64078 RVA: 0x0044879C File Offset: 0x00446B9C
		private void _OnItemVisiable(ComUIListElementScript item)
		{
			if (item != null && (item.m_index >= 0 & item.m_index < this.mDataList.Count))
			{
				SendGiftItem component = item.GetComponent<SendGiftItem>();
				if (component != null)
				{
					component.SendData(this.mDataList[item.m_index], new Action<FriendPresentInfo>(this._OnSelect), this.mSelectData);
				}
			}
		}

		// Token: 0x0600FA4F RID: 64079 RVA: 0x00448818 File Offset: 0x00446C18
		private void _OnItemRecycle(ComUIListElementScript item)
		{
			if (item != null && (item.m_index >= 0 & item.m_index < this.mDataList.Count))
			{
				SendGiftItem component = item.GetComponent<SendGiftItem>();
				if (component != null)
				{
					component.OnRecycle();
				}
			}
		}

		// Token: 0x0600FA50 RID: 64080 RVA: 0x0044886F File Offset: 0x00446C6F
		private void _OnSelect(FriendPresentInfo data)
		{
			this.mSelectData = data;
		}

		// Token: 0x0600FA51 RID: 64081 RVA: 0x00448878 File Offset: 0x00446C78
		private void _OnSendBtnClick()
		{
			if (this.mItemData == null)
			{
				Logger.LogError("mItemData is null");
				return;
			}
			int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(this.mItemData.TableID);
			if (this.mSelectData == null)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("NoSelected_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (itemCountInPackage <= 0)
			{
				SystemNotifyManager.SystemNotify(2400004, string.Empty);
			}
			else if (this.mSelectData != null)
			{
				this._SendFriendPresentReq(this.mItemData.GUID, this.mSelectData.friendId, (uint)this.mItemData.TableID);
			}
			else
			{
				Logger.LogError(" mSelectData is null");
			}
		}

		// Token: 0x0600FA52 RID: 64082 RVA: 0x00448930 File Offset: 0x00446D30
		private void _OnUpdateLeftGiftNum(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			if (this.mItemData == null)
			{
				Logger.LogError("mItemData is null");
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (num == (uint)this.mItemData.TableID)
			{
				this._ShowLeftGiftNum();
			}
		}

		// Token: 0x0600FA53 RID: 64083 RVA: 0x00448988 File Offset: 0x00446D88
		private void _ShowLeftGiftNum()
		{
			if (this.mItemData != null)
			{
				int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(this.mItemData.TableID);
				this.mRemainGiftNumTxt.SafeSetText(string.Format(TR.Value("LeftGiftItemNum"), itemCountInPackage));
			}
			else
			{
				Logger.LogError("ShowLeftGiftNum mItemData is null");
			}
		}

		// Token: 0x0600FA54 RID: 64084 RVA: 0x004489E8 File Offset: 0x00446DE8
		private void _ShowBeSendNum(int curNum, int limitNum)
		{
			if (curNum > limitNum)
			{
				curNum = limitNum;
				Logger.LogError(string.Format("我被赠送的总数量超过的限制，当前的数量:{0},总的数量:{1}", curNum, limitNum));
			}
			this.mBeSendTotalNumTxt.SafeSetText(string.Format(TR.Value("BeSendTotalNum"), curNum, limitNum));
		}

		// Token: 0x0600FA55 RID: 64085 RVA: 0x00448A40 File Offset: 0x00446E40
		private void _OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SendGiftFrame>(null, false);
		}

		// Token: 0x0600FA56 RID: 64086 RVA: 0x00448A50 File Offset: 0x00446E50
		private int _Sort(FriendPresentInfo x, FriendPresentInfo y)
		{
			if (x.beSendedTimes > y.beSendedTimes)
			{
				return -1;
			}
			if (x.beSendedTimes < y.beSendedTimes)
			{
				return 1;
			}
			if (x.isOnline > y.isOnline)
			{
				return -1;
			}
			if (x.isOnline < y.isOnline)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600FA57 RID: 64087 RVA: 0x00448AAC File Offset: 0x00446EAC
		private void _RequestFriendPresentInfosReq(int itemId)
		{
			WorldGetItemFriendPresentInfosReq worldGetItemFriendPresentInfosReq = new WorldGetItemFriendPresentInfosReq();
			worldGetItemFriendPresentInfosReq.dataId = (uint)itemId;
			NetManager.Instance().SendCommand<WorldGetItemFriendPresentInfosReq>(ServerType.GATE_SERVER, worldGetItemFriendPresentInfosReq);
		}

		// Token: 0x0600FA58 RID: 64088 RVA: 0x00448AD4 File Offset: 0x00446ED4
		private void _SendFriendPresentReq(ulong itemGUID, ulong friendId, uint itemTableId)
		{
			WorldItemFriendPresentReq worldItemFriendPresentReq = new WorldItemFriendPresentReq();
			worldItemFriendPresentReq.itemId = itemGUID;
			worldItemFriendPresentReq.friendId = friendId;
			worldItemFriendPresentReq.itemTypeId = itemTableId;
			NetManager.Instance().SendCommand<WorldItemFriendPresentReq>(ServerType.GATE_SERVER, worldItemFriendPresentReq);
		}

		// Token: 0x0600FA59 RID: 64089 RVA: 0x00448B0C File Offset: 0x00446F0C
		private void _OnFriendPresentInfosRet(MsgDATA msg)
		{
			WorldGetItemFriendPresentInfosRes worldGetItemFriendPresentInfosRes = new WorldGetItemFriendPresentInfosRes();
			worldGetItemFriendPresentInfosRes.decode(msg.bytes);
			if (this.mItemData == null)
			{
				Logger.LogError("mItemData is null");
				return;
			}
			if ((ulong)worldGetItemFriendPresentInfosRes.dataId == (ulong)((long)this.mItemData.TableID))
			{
				for (int i = 0; i < worldGetItemFriendPresentInfosRes.presentInfos.Length; i++)
				{
					FriendPresentInfo item = worldGetItemFriendPresentInfosRes.presentInfos[i];
					this.mDataList.Add(item);
				}
				if (this.mUIGray != null && this.mSendBtn != null)
				{
					this.mUIGray.enabled = (this.mDataList.Count == 0);
					this.mSendBtn.interactable = (this.mDataList.Count != 0);
				}
				this.mSendBtn.CustomActive(true);
				this.mDataList.Sort(new Comparison<FriendPresentInfo>(this._Sort));
				if (this.mItemUIList != null)
				{
					this.mItemUIList.SetElementAmount(this.mDataList.Count);
				}
				this.mNoTipCanvas.alpha = 1f;
				this._ShowBeSendNum((int)worldGetItemFriendPresentInfosRes.recvedTotal, (int)worldGetItemFriendPresentInfosRes.recvedTotalLimit);
			}
		}

		// Token: 0x0600FA5A RID: 64090 RVA: 0x00448C4C File Offset: 0x0044704C
		private void _OnSendFriendPresentRet(MsgDATA msg)
		{
			WorldItemFriendPresentRes worldItemFriendPresentRes = new WorldItemFriendPresentRes();
			worldItemFriendPresentRes.decode(msg.bytes);
			if (this.mItemData != null && (long)this.mItemData.TableID != (long)((ulong)worldItemFriendPresentRes.itemTypeId))
			{
				Logger.LogErrorFormat(string.Format("发送礼物包给好友，服务器返回的id和本地id不一样 本地礼物的id={0},服务器发来的Id={1}", this.mItemData.TableID, worldItemFriendPresentRes.itemTypeId), new object[0]);
				return;
			}
			if (worldItemFriendPresentRes.retCode == 0U)
			{
				for (int i = 0; i < this.mDataList.Count; i++)
				{
					if (this.mDataList[i].friendId == worldItemFriendPresentRes.presentInfos.friendId)
					{
						this.mDataList[i] = worldItemFriendPresentRes.presentInfos;
					}
				}
				if (this.mItemUIList != null)
				{
					this.mItemUIList.UpdateElementAmount(this.mDataList.Count);
				}
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("SendSucess_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				SystemNotifyManager.SystemNotify((int)worldItemFriendPresentRes.retCode, string.Empty);
			}
		}

		// Token: 0x04009C44 RID: 40004
		private ComUIListScript mItemUIList;

		// Token: 0x04009C45 RID: 40005
		private Button mSendBtn;

		// Token: 0x04009C46 RID: 40006
		private Button mCloseBtn;

		// Token: 0x04009C47 RID: 40007
		private UIGray mUIGray;

		// Token: 0x04009C48 RID: 40008
		private Text mRemainGiftNumTxt;

		// Token: 0x04009C49 RID: 40009
		private Text mBeSendTotalNumTxt;

		// Token: 0x04009C4A RID: 40010
		private CanvasGroup mNoTipCanvas;

		// Token: 0x04009C4B RID: 40011
		private ItemData mItemData;

		// Token: 0x04009C4C RID: 40012
		private List<FriendPresentInfo> mDataList = new List<FriendPresentInfo>();

		// Token: 0x04009C4D RID: 40013
		private FriendPresentInfo mSelectData;

		// Token: 0x04009C4E RID: 40014
		private int mBeSengTotalLimitNum;
	}
}
