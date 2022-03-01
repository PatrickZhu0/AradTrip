using System;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x0200129D RID: 4765
	public class MagicCardMergeDataManager : DataManager<MagicCardMergeDataManager>
	{
		// Token: 0x0600B764 RID: 46948 RVA: 0x0029DCED File Offset: 0x0029C0ED
		public override void Initialize()
		{
			this.BindUiEvents();
			this.BindNetEvents();
		}

		// Token: 0x0600B765 RID: 46949 RVA: 0x0029DCFB File Offset: 0x0029C0FB
		public override void Clear()
		{
			this.UnBindUiEvents();
			this.UnBindNetEvents();
			this.ClearData();
		}

		// Token: 0x0600B766 RID: 46950 RVA: 0x0029DD0F File Offset: 0x0029C10F
		private void BindUiEvents()
		{
		}

		// Token: 0x0600B767 RID: 46951 RVA: 0x0029DD11 File Offset: 0x0029C111
		private void UnBindUiEvents()
		{
		}

		// Token: 0x0600B768 RID: 46952 RVA: 0x0029DD13 File Offset: 0x0029C113
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(501058U, new Action<MsgDATA>(this.OnReceiveMagicCardOneKeyMergeRes));
		}

		// Token: 0x0600B769 RID: 46953 RVA: 0x0029DD2B File Offset: 0x0029C12B
		private void UnBindNetEvents()
		{
			NetProcess.AddMsgHandler(501058U, new Action<MsgDATA>(this.OnReceiveMagicCardOneKeyMergeRes));
		}

		// Token: 0x0600B76A RID: 46954 RVA: 0x0029DD43 File Offset: 0x0029C143
		private void ClearData()
		{
			this.IsNotShowMagicCardMergeOwnerDifferentTip = false;
			this.IsNotShowMagicCardMergeLevelTip = false;
			this.OneKeyMergeRes = null;
		}

		// Token: 0x0600B76B RID: 46955 RVA: 0x0029DD5C File Offset: 0x0029C15C
		public void SendMagicCardOneKeyMergeReq()
		{
			SceneMagicCardCompOneKeyReq sceneMagicCardCompOneKeyReq = new SceneMagicCardCompOneKeyReq();
			sceneMagicCardCompOneKeyReq.isCompWhite = ((!this.IsMagicCardOneKeyMergeUseWhiteCard) ? 0 : 1);
			sceneMagicCardCompOneKeyReq.isCompBlue = ((!this.IsMagicCardOneKeyMergeUseBlueCard) ? 0 : 1);
			sceneMagicCardCompOneKeyReq.autoUseGold = ((!this.IsMagicCardOneKeyMergeUserGold) ? 0 : 1);
			sceneMagicCardCompOneKeyReq.compNotBind = ((!this.IsMagicCardOneKeyMergeUseNoBindItem) ? 0 : 1);
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneMagicCardCompOneKeyReq>(ServerType.GATE_SERVER, sceneMagicCardCompOneKeyReq);
			}
		}

		// Token: 0x0600B76C RID: 46956 RVA: 0x0029DDEC File Offset: 0x0029C1EC
		public void OnReceiveMagicCardOneKeyMergeRes(MsgDATA msgData)
		{
			this.OneKeyMergeRes = null;
			SceneMagicCardCompOneKeyRes sceneMagicCardCompOneKeyRes = new SceneMagicCardCompOneKeyRes();
			sceneMagicCardCompOneKeyRes.decode(msgData.bytes);
			if (sceneMagicCardCompOneKeyRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneMagicCardCompOneKeyRes.code, string.Empty);
				return;
			}
			this.OneKeyMergeRes = sceneMagicCardCompOneKeyRes;
			MagicCardMergeUtility.OnOpenMagicCardOneKeyMergeResultFrame();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnOneKeyMergeSuccess, null, null, null, null);
		}

		// Token: 0x0600B76D RID: 46957 RVA: 0x0029DE4D File Offset: 0x0029C24D
		public void ResetOneKeyMergeSetting()
		{
			this.IsMagicCardOneKeyMergeUseWhiteCard = true;
			this.IsMagicCardOneKeyMergeUseBlueCard = false;
			this.IsMagicCardOneKeyMergeUserGold = false;
			this.IsMagicCardOneKeyMergeUseNoBindItem = false;
		}

		// Token: 0x0600B76E RID: 46958 RVA: 0x0029DE6B File Offset: 0x0029C26B
		public void ResetOneKeyMergeRes()
		{
			this.OneKeyMergeRes = null;
		}

		// Token: 0x04006770 RID: 26480
		public bool IsNotShowMagicCardMergeOwnerDifferentTip;

		// Token: 0x04006771 RID: 26481
		public bool IsNotShowMagicCardMergeLevelTip;

		// Token: 0x04006772 RID: 26482
		public bool IsMagicCardOneKeyMergeUseWhiteCard = true;

		// Token: 0x04006773 RID: 26483
		public bool IsMagicCardOneKeyMergeUseBlueCard;

		// Token: 0x04006774 RID: 26484
		public bool IsMagicCardOneKeyMergeUserGold;

		// Token: 0x04006775 RID: 26485
		public bool IsMagicCardOneKeyMergeUseNoBindItem;

		// Token: 0x04006776 RID: 26486
		public SceneMagicCardCompOneKeyRes OneKeyMergeRes;
	}
}
