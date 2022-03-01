using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001364 RID: 4964
	public class FairDuelWaitingRoomFrame : ClientFrame
	{
		// Token: 0x0600C0C1 RID: 49345 RVA: 0x002DAD7F File Offset: 0x002D917F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/FairDuel/FairDuelWaitingRoomFrame";
		}

		// Token: 0x0600C0C2 RID: 49346 RVA: 0x002DAD88 File Offset: 0x002D9188
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.mFairDueliRoomData = (FairDueliRoomData)this.userData;
			}
			if (this.mComTalkParent != null)
			{
				this.mComTalk = ComTalk.Create(this.mComTalkParent);
			}
			DataManager<SkillDataManager>.GetInstance().SendSetSkillConfigReq(0);
			this.BindEvt();
		}

		// Token: 0x0600C0C3 RID: 49347 RVA: 0x002DADE4 File Offset: 0x002D91E4
		protected override void _OnCloseFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			this.ClearData();
			this.UnBind();
		}

		// Token: 0x0600C0C4 RID: 49348 RVA: 0x002DAE30 File Offset: 0x002D9230
		private void BindEvt()
		{
			NetProcess.AddMsgHandler(606702U, new Action<MsgDATA>(this._OnReciveWorldMatchStartResRes));
			NetProcess.AddMsgHandler(606703U, new Action<MsgDATA>(this._OnReciveWorldMatchCancelRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnPkMatchStartSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnPkMatchStartFail));
		}

		// Token: 0x0600C0C5 RID: 49349 RVA: 0x002DAEA0 File Offset: 0x002D92A0
		private void UnBind()
		{
			NetProcess.AddMsgHandler(606702U, new Action<MsgDATA>(this._OnReciveWorldMatchStartResRes));
			NetProcess.AddMsgHandler(606703U, new Action<MsgDATA>(this._OnReciveWorldMatchCancelRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnPkMatchStartSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnPkMatchStartFail));
		}

		// Token: 0x0600C0C6 RID: 49350 RVA: 0x002DAF0F File Offset: 0x002D930F
		private void ClearData()
		{
			if (this.mFairDueliRoomData != null)
			{
				this.mFairDueliRoomData.Clear();
			}
			if (this.mComTalk != null)
			{
				ComTalk.Recycle();
				this.mComTalk = null;
			}
			this.mIsSeeking = false;
		}

		// Token: 0x0600C0C7 RID: 49351 RVA: 0x002DAF4C File Offset: 0x002D934C
		protected override void _bindExUI()
		{
			this.mCloseBtn = this.mBind.GetCom<Button>("btClose");
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			this.mFightBtn = this.mBind.GetCom<Button>("btBegin");
			if (this.mFightBtn != null)
			{
				this.mFightBtn.onClick.AddListener(new UnityAction(this.OnFightBtnClick));
			}
			this.mRuleDetailBtn = this.mBind.GetCom<Button>("RuleBtn");
			if (this.mRuleDetailBtn != null)
			{
				this.mRuleDetailBtn.onClick.AddListener(new UnityAction(this.OnRuleDetailBtnClick));
			}
			this.mComTalkParent = this.mBind.GetGameObject("TalkParent");
			this.mSkillBtn = this.mBind.GetCom<Button>("SkillBtn");
			if (this.mSkillBtn != null)
			{
				this.mSkillBtn.onClick.AddListener(new UnityAction(this.OnSkillBtnClick));
			}
			this.mFriendPkBtn = this.mBind.GetCom<Button>("FriendPKBtn");
			if (this.mFriendPkBtn != null)
			{
				this.mFriendPkBtn.onClick.AddListener(new UnityAction(this.OnFriendPKBtnClick));
			}
			this.mFightBtnTxt = this.mBind.GetCom<Text>("Begintxt");
		}

		// Token: 0x0600C0C8 RID: 49352 RVA: 0x002DB0D4 File Offset: 0x002D94D4
		protected override void _unbindExUI()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
				this.mCloseBtn = null;
			}
			if (this.mFightBtn != null)
			{
				this.mFightBtn.onClick.RemoveListener(new UnityAction(this.OnFightBtnClick));
				this.mFightBtn = null;
			}
			if (this.mRuleDetailBtn != null)
			{
				this.mRuleDetailBtn.onClick.RemoveListener(new UnityAction(this.OnRuleDetailBtnClick));
				this.mRuleDetailBtn = null;
			}
			if (this.mComTalkParent != null)
			{
				this.mComTalkParent = null;
			}
			if (this.mSkillBtn != null)
			{
				this.mSkillBtn.onClick.RemoveListener(new UnityAction(this.OnSkillBtnClick));
				this.mSkillBtn = null;
			}
			if (this.mFriendPkBtn != null)
			{
				this.mFriendPkBtn.onClick.RemoveListener(new UnityAction(this.OnFriendPKBtnClick));
				this.mFriendPkBtn = null;
			}
			if (this.mFightBtnTxt != null)
			{
				this.mFightBtnTxt = null;
			}
		}

		// Token: 0x0600C0C9 RID: 49353 RVA: 0x002DB215 File Offset: 0x002D9615
		private void OnRuleDetailBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelHelpFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C0CA RID: 49354 RVA: 0x002DB22C File Offset: 0x002D962C
		private void OnFightBtnClick()
		{
			if (!DataManager<SkillDataManager>.GetInstance().IsHaveSetFairDueSkillBar)
			{
				CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
				{
					ContentLabel = TR.Value("fairduel_setskillBar_content"),
					IsShowNotify = false,
					LeftButtonText = TR.Value("fairduel_setskillBar_cancel"),
					RightButtonText = TR.Value("fairduel_setskillBar_ok"),
					OnRightButtonClickCallBack = new Action(this.OnOpenFairSkillFrame)
				};
				SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
			}
			else if (!this.mIsSeeking)
			{
				WorldMatchStartReq worldMatchStartReq = new WorldMatchStartReq();
				worldMatchStartReq.type = 13;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldMatchStartReq>(ServerType.GATE_SERVER, worldMatchStartReq);
			}
			else
			{
				WorldMatchCancelReq cmd = new WorldMatchCancelReq();
				NetManager netManager2 = NetManager.Instance();
				netManager2.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600C0CB RID: 49355 RVA: 0x002DB2EA File Offset: 0x002D96EA
		private void OnOpenFairSkillFrame()
		{
			DataManager<SkillDataManager>.GetInstance().SendSetSkillConfigReq(1);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelSkillFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C0CC RID: 49356 RVA: 0x002DB309 File Offset: 0x002D9709
		private void OnFriendPKBtnClick()
		{
			if (this.mIsSeeking)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkFriendsFrame>(FrameLayer.Middle, RequestType.Request_Equal_PK, string.Empty);
		}

		// Token: 0x0600C0CD RID: 49357 RVA: 0x002DB340 File Offset: 0x002D9740
		private void OnCloseBtnClick()
		{
			if (this.mIsSeeking)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not systemTown!!!");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.mFairDueliRoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.mFairDueliRoomData.TargetTownSceneID,
				targetDoorID = 0
			}, false));
			this.frameMgr.CloseFrame<FairDuelWaitingRoomFrame>(this, false);
		}

		// Token: 0x0600C0CE RID: 49358 RVA: 0x002DB3DF File Offset: 0x002D97DF
		private void OnSkillBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FairDuelSkillFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C0CF RID: 49359 RVA: 0x002DB3F4 File Offset: 0x002D97F4
		private void _OnReciveWorldMatchStartResRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldMatchStartRes worldMatchStartRes = new WorldMatchStartRes();
			worldMatchStartRes.decode(data.bytes);
			if (worldMatchStartRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMatchStartRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchStartSuccess, null, null, null, null);
		}

		// Token: 0x0600C0D0 RID: 49360 RVA: 0x002DB45C File Offset: 0x002D985C
		private void _OnReciveWorldMatchCancelRes(MsgDATA data)
		{
			if (data == null)
			{
				return;
			}
			WorldMatchCancelRes worldMatchCancelRes = new WorldMatchCancelRes();
			worldMatchCancelRes.decode(data.bytes);
			if (worldMatchCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMatchCancelRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelSuccess, null, null, null, null);
		}

		// Token: 0x0600C0D1 RID: 49361 RVA: 0x002DB4C4 File Offset: 0x002D98C4
		private void _OnPkMatchStartSuccess(UIEvent uiEvent)
		{
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.TraditionPk;
			this.mIsSeeking = true;
			this.mFightBtnTxt.text = "取消匹配";
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
		}

		// Token: 0x0600C0D2 RID: 49362 RVA: 0x002DB507 File Offset: 0x002D9907
		private void _OnPkMatchStartFail(UIEvent uiEvent)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			this.mIsSeeking = false;
			this.mFightBtnTxt.text = "开始匹配";
		}

		// Token: 0x04006CEA RID: 27882
		private Button mCloseBtn;

		// Token: 0x04006CEB RID: 27883
		private Button mFightBtn;

		// Token: 0x04006CEC RID: 27884
		private Button mRuleDetailBtn;

		// Token: 0x04006CED RID: 27885
		private Button mSkillBtn;

		// Token: 0x04006CEE RID: 27886
		private Button mFriendPkBtn;

		// Token: 0x04006CEF RID: 27887
		private FairDueliRoomData mFairDueliRoomData = new FairDueliRoomData();

		// Token: 0x04006CF0 RID: 27888
		private ComTalk mComTalk;

		// Token: 0x04006CF1 RID: 27889
		private GameObject mComTalkParent;

		// Token: 0x04006CF2 RID: 27890
		private bool mIsSetSkillBar;

		// Token: 0x04006CF3 RID: 27891
		private Text mFightBtnTxt;

		// Token: 0x04006CF4 RID: 27892
		private bool mIsSeeking;
	}
}
