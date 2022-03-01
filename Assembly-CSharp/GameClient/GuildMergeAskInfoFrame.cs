using System;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001636 RID: 5686
	public class GuildMergeAskInfoFrame : ClientFrame
	{
		// Token: 0x0600DF5D RID: 57181 RVA: 0x0038FE86 File Offset: 0x0038E286
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMergeAskInfoFrame";
		}

		// Token: 0x0600DF5E RID: 57182 RVA: 0x0038FE90 File Offset: 0x0038E290
		protected override void _bindExUI()
		{
			this.mGuildNameTxt = this.mBind.GetCom<Text>("GuildNameTxt");
			this.mGuildLeaderTxt = this.mBind.GetCom<Text>("GuildLeaderTxt");
			this.mGuildGrandTxt = this.mBind.GetCom<Text>("GuildGrandTxt");
			this.mGuildCountTxt = this.mBind.GetCom<Text>("GuildMembersTxt");
			this.mCloseBtn = this.mBind.GetCom<Button>("CloseBtn");
			this.mCancleAgreeBtn = this.mBind.GetCom<Button>("CancelAgreeBtn");
			this.mAgreeBtn = this.mBind.GetCom<Button>("AgreeBtn");
			this.mConnectLeaderBtn = this.mBind.GetCom<Button>("ConnactLeaderBtn");
			this.mRefuseBtn = this.mBind.GetCom<Button>("RefuseBtn");
			this.mCloseBtn.SafeAddOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mCancleAgreeBtn.SafeAddOnClickListener(new UnityAction(this.OnCancleAgreeBtnClick));
			this.mAgreeBtn.SafeAddOnClickListener(new UnityAction(this.OnAgreeBtnClick));
			this.mConnectLeaderBtn.SafeAddOnClickListener(new UnityAction(this.OnConncetLeaderBtnClick));
			this.mRefuseBtn.SafeAddOnClickListener(new UnityAction(this.OnRefuseBtnClick));
		}

		// Token: 0x0600DF5F RID: 57183 RVA: 0x0038FFD8 File Offset: 0x0038E3D8
		protected override void _unbindExUI()
		{
			this.mGuildNameTxt = null;
			this.mGuildLeaderTxt = null;
			this.mGuildGrandTxt = null;
			this.mGuildCountTxt = null;
			this.mCloseBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mCancleAgreeBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCancleAgreeBtnClick));
			this.mAgreeBtn.SafeRemoveOnClickListener(new UnityAction(this.OnAgreeBtnClick));
			this.mConnectLeaderBtn.SafeRemoveOnClickListener(new UnityAction(this.OnConncetLeaderBtnClick));
			this.mRefuseBtn.SafeRemoveOnClickListener(new UnityAction(this.OnRefuseBtnClick));
			this.mCloseBtn = null;
			this.mCancleAgreeBtn = null;
			this.mAgreeBtn = null;
			this.mConnectLeaderBtn = null;
			this.mRefuseBtn = null;
		}

		// Token: 0x0600DF60 RID: 57184 RVA: 0x00390098 File Offset: 0x0038E498
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.userData != null)
			{
				this.mGuildEntry = (GuildEntry)this.userData;
				this.SetData(this.mGuildEntry);
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AgreeMerger, new ClientEventSystem.UIEventHandler(this._OnAgreeMerger));
		}

		// Token: 0x0600DF61 RID: 57185 RVA: 0x003900EE File Offset: 0x0038E4EE
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AgreeMerger, new ClientEventSystem.UIEventHandler(this._OnAgreeMerger));
		}

		// Token: 0x0600DF62 RID: 57186 RVA: 0x00390114 File Offset: 0x0038E514
		private void SetData(GuildEntry guildEntry)
		{
			if (guildEntry != null)
			{
				this.mGuildNameTxt.SafeSetText(guildEntry.name);
				this.mGuildLeaderTxt.SafeSetText(guildEntry.leaderName);
				this.mGuildGrandTxt.SafeSetText(guildEntry.level.ToString());
				int memberNum = (int)guildEntry.memberNum;
				int memberNum2 = Singleton<TableManager>.GetInstance().GetTableItem<GuildTable>((int)guildEntry.level, string.Empty, string.Empty).MemberNum;
				this.mGuildCountTxt.SafeSetText(string.Format("{0}/{1}", memberNum, memberNum2));
				this.SetBtnActive(guildEntry.isRequested != 0);
			}
		}

		// Token: 0x0600DF63 RID: 57187 RVA: 0x003901BF File Offset: 0x0038E5BF
		private void SetBtnActive(bool isHaveAgreed)
		{
			this.mRefuseBtn.CustomActive(!isHaveAgreed);
			this.mAgreeBtn.CustomActive(!isHaveAgreed);
			this.mCancleAgreeBtn.CustomActive(isHaveAgreed);
		}

		// Token: 0x0600DF64 RID: 57188 RVA: 0x003901EC File Offset: 0x0038E5EC
		private void OnConncetLeaderBtnClick()
		{
			if (this.mGuildEntry != null)
			{
				RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.mGuildEntry.leaderId);
				if (relationByRoleID != null)
				{
					AuctionNewUtility.OpenChatFrame(relationByRoleID);
					return;
				}
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOnShelfItemOwnerInfo(this.mGuildEntry.leaderId);
			}
		}

		// Token: 0x0600DF65 RID: 57189 RVA: 0x0039023C File Offset: 0x0038E63C
		private void OnAgreeBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("guildmerge_agree_content"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("guildmerge_agree_no"),
				RightButtonText = TR.Value("guildmerge_agree_ok"),
				OnRightButtonClickCallBack = new Action(this.OnAgree)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600DF66 RID: 57190 RVA: 0x003902A0 File Offset: 0x0038E6A0
		private void OnAgree()
		{
			if (this.mGuildEntry == null)
			{
				return;
			}
			DataManager<GuildDataManager>.GetInstance().AcceptOrRefuseOrCancelMergeRequest(0, this.mGuildEntry.id);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMergeAskInfoFrame>(null, false);
		}

		// Token: 0x0600DF67 RID: 57191 RVA: 0x003902D0 File Offset: 0x0038E6D0
		private void OnRefuseBtnClick()
		{
			if (this.mGuildEntry == null)
			{
				return;
			}
			DataManager<GuildDataManager>.GetInstance().AcceptOrRefuseOrCancelMergeRequest(1, this.mGuildEntry.id);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMergeAskInfoFrame>(null, false);
		}

		// Token: 0x0600DF68 RID: 57192 RVA: 0x00390300 File Offset: 0x0038E700
		private void OnCancleAgreeBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("guildmerge_cancelAgree_content"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("guildmerge_cancelAgree_no"),
				RightButtonText = TR.Value("guildmerge_cancelAgree_ok"),
				OnRightButtonClickCallBack = new Action(this.OnCancelAgree)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600DF69 RID: 57193 RVA: 0x00390364 File Offset: 0x0038E764
		private void OnCancelAgree()
		{
			if (this.mGuildEntry == null)
			{
				return;
			}
			DataManager<GuildDataManager>.GetInstance().AcceptOrRefuseOrCancelMergeRequest(2, this.mGuildEntry.id);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMergeAskInfoFrame>(null, false);
		}

		// Token: 0x0600DF6A RID: 57194 RVA: 0x00390394 File Offset: 0x0038E794
		private void OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMergeAskInfoFrame>(null, false);
		}

		// Token: 0x0600DF6B RID: 57195 RVA: 0x003903A2 File Offset: 0x0038E7A2
		private void _OnAgreeMerger(UIEvent uiEvent)
		{
			this.SetBtnActive(true);
		}

		// Token: 0x040084A3 RID: 33955
		private Button mCloseBtn;

		// Token: 0x040084A4 RID: 33956
		private Button mRefuseBtn;

		// Token: 0x040084A5 RID: 33957
		private Button mCancleAgreeBtn;

		// Token: 0x040084A6 RID: 33958
		private Button mAgreeBtn;

		// Token: 0x040084A7 RID: 33959
		private Button mConnectLeaderBtn;

		// Token: 0x040084A8 RID: 33960
		private Text mGuildNameTxt;

		// Token: 0x040084A9 RID: 33961
		private Text mGuildLeaderTxt;

		// Token: 0x040084AA RID: 33962
		private Text mGuildGrandTxt;

		// Token: 0x040084AB RID: 33963
		private Text mGuildCountTxt;

		// Token: 0x040084AC RID: 33964
		private GuildEntry mGuildEntry;
	}
}
