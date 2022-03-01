using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C01 RID: 7169
	public class TeamBeInvitedFrame : ClientFrame
	{
		// Token: 0x0601190B RID: 71947 RVA: 0x0051D56B File Offset: 0x0051B96B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamBeInvitedFrame";
		}

		// Token: 0x0601190C RID: 71948 RVA: 0x0051D574 File Offset: 0x0051B974
		protected override void _OnOpenFrame()
		{
			this.fFrameOpenTime = Time.realtimeSinceStartup;
			this.BindUIEvent();
			this.teamBeInvteInfo = null;
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (inviteTeamList != null && inviteTeamList.Count > 0)
			{
				this.teamBeInvteInfo = inviteTeamList[0];
			}
			this.bTryOpenNewInvite = false;
			this.UpadateInviteInfo();
			InvokeMethod.InvokeInterval(this, 0f, 1f, 30f, delegate
			{
				this.hangUpText.SafeSetText(TR.Value("hang_up_tick", 30));
			}, delegate
			{
				int num = 30 - Utility.ceil(Time.realtimeSinceStartup - this.fFrameOpenTime);
				num = Math.Max(num, 0);
				this.hangUpText.SafeSetText(TR.Value("hang_up_tick", num));
			}, delegate
			{
				this.OnHangUp();
			});
		}

		// Token: 0x0601190D RID: 71949 RVA: 0x0051D60C File Offset: 0x0051BA0C
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
			this.teamBeInvteInfo = null;
			this.UnBindUIEvent();
			if (this.bTryOpenNewInvite && Time.realtimeSinceStartup - this.fFrameOpenTime <= 25f)
			{
				base.StopCoroutine(this.OpenNewTeamBeInviteFrame());
				base.StartCoroutine(this.OpenNewTeamBeInviteFrame());
			}
			this.fFrameOpenTime = 0f;
			this.bTryOpenNewInvite = false;
		}

		// Token: 0x0601190E RID: 71950 RVA: 0x0051D678 File Offset: 0x0051BA78
		protected override void _bindExUI()
		{
			this.BtnClose = this.mBind.GetCom<Button>("BtnClose");
			this.BtnClose.SafeAddOnClickListener(delegate
			{
				this.OnHangUp();
			});
			this.Icon = this.mBind.GetCom<Image>("Icon");
			this.Name = this.mBind.GetCom<Text>("Name");
			this.Level = this.mBind.GetCom<Text>("Level");
			this.Target = this.mBind.GetCom<Text>("Target");
			this.reject = this.mBind.GetCom<Button>("reject");
			this.reject.SafeAddOnClickListener(delegate
			{
				this.OnReject();
				this.bTryOpenNewInvite = true;
				this.frameMgr.CloseFrame<TeamBeInvitedFrame>(this, false);
			});
			this.hangUp = this.mBind.GetCom<Button>("hangUp");
			this.hangUp.SafeAddOnClickListener(delegate
			{
				this.OnHangUp();
			});
			this.agree = this.mBind.GetCom<Button>("agree");
			this.agree.SafeAddOnClickListener(delegate
			{
				this.OnAgree();
				this.frameMgr.CloseFrame<TeamBeInvitedFrame>(this, false);
				this.bTryOpenNewInvite = false;
			});
			this.hangUpText = this.mBind.GetCom<Text>("hangUpText");
			this.animation1 = this.mBind.GetCom<DOTweenAnimation>("animation1");
			this.animation2 = this.mBind.GetCom<DOTweenAnimation>("animation2");
			this.mReplaceHeadPortraitFrame = this.mBind.GetCom<ReplaceHeadPortraitFrame>("PictureFrame");
			this.returnPlayer = this.mBind.GetGameObject("returnPlayer");
			this.myFriend = this.mBind.GetGameObject("myFriend");
			this.myGuild = this.mBind.GetGameObject("myGuild");
		}

		// Token: 0x0601190F RID: 71951 RVA: 0x0051D82C File Offset: 0x0051BC2C
		protected override void _unbindExUI()
		{
			this.BtnClose = null;
			this.Icon = null;
			this.Name = null;
			this.Level = null;
			this.Target = null;
			this.reject = null;
			this.hangUp = null;
			this.agree = null;
			this.hangUpText = null;
			this.animation1 = null;
			this.animation2 = null;
			this.mReplaceHeadPortraitFrame = null;
			this.returnPlayer = null;
			this.myFriend = null;
			this.myGuild = null;
		}

		// Token: 0x06011910 RID: 71952 RVA: 0x0051D8A2 File Offset: 0x0051BCA2
		private void BindUIEvent()
		{
		}

		// Token: 0x06011911 RID: 71953 RVA: 0x0051D8A4 File Offset: 0x0051BCA4
		private void UnBindUIEvent()
		{
		}

		// Token: 0x06011912 RID: 71954 RVA: 0x0051D8A8 File Offset: 0x0051BCA8
		private void UpadateInviteInfo()
		{
			if (this.teamBeInvteInfo == null)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.teamBeInvteInfo.baseinfo.masterInfo.occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.Icon.SafeSetImage(tableItem2.IconPath, false);
				}
			}
			this.Name.SafeSetText(this.teamBeInvteInfo.baseinfo.masterInfo.name);
			this.Level.SafeSetText(string.Format("Lv{0}", this.teamBeInvteInfo.baseinfo.masterInfo.level));
			TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.teamBeInvteInfo.baseinfo.target, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.Target.SafeSetText(TR.Value("other_player_invite_you", tableItem3.Name));
			}
			if (this.mReplaceHeadPortraitFrame != null && this.teamBeInvteInfo.baseinfo != null && this.teamBeInvteInfo.baseinfo.masterInfo != null && this.teamBeInvteInfo.baseinfo.masterInfo.playerLabelInfo != null)
			{
				if (this.teamBeInvteInfo.baseinfo.masterInfo.playerLabelInfo.headFrame != 0U)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)this.teamBeInvteInfo.baseinfo.masterInfo.playerLabelInfo.headFrame);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
			this.returnPlayer.CustomActive(this.teamBeInvteInfo.baseinfo.masterInfo.playerLabelInfo.returnStatus == 1);
			RelationData relationData = null;
			bool bActive = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(this.teamBeInvteInfo.baseinfo.masterInfo.id, ref relationData);
			this.myFriend.CustomActive(bActive);
			this.myGuild.CustomActive(DataManager<GuildDataManager>.GetInstance().IsSameGuild(this.teamBeInvteInfo.baseinfo.masterInfo.playerLabelInfo.guildId));
		}

		// Token: 0x06011913 RID: 71955 RVA: 0x0051DAEC File Offset: 0x0051BEEC
		private IEnumerator OpenNewTeamBeInviteFrame()
		{
			yield return new WaitForEndOfFrame();
			yield return new WaitForEndOfFrame();
			List<NewTeamInviteList> InviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (InviteTeamList != null && InviteTeamList.Count > 0)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamBeInvitedFrame>(FrameLayer.Middle, null, string.Empty);
			}
			yield return 0;
			yield break;
		}

		// Token: 0x06011914 RID: 71956 RVA: 0x0051DB00 File Offset: 0x0051BF00
		private void OnHangUp()
		{
			try
			{
				GameObject teamInvitedBtn = ComTalk.ms_comTalk.GetTeamInvitedBtn();
				if (teamInvitedBtn == null || !teamInvitedBtn.activeInHierarchy)
				{
					this.frameMgr.CloseFrame<TeamBeInvitedFrame>(this, false);
					this.bTryOpenNewInvite = false;
					return;
				}
				this.animation1.endValueV3 = new Vector3(teamInvitedBtn.transform.position.x, teamInvitedBtn.transform.position.y);
				this.animation1.tween = TweenSettingsExtensions.SetDelay<Tweener>(ShortcutExtensions.DOMove(this.animation1.transform, this.animation1.endValueV3, this.animation1.duration, false), this.animation1.delay);
				if (this.animation1.onComplete == null)
				{
					this.animation1.onComplete = new UnityEvent();
				}
				this.animation1.hasOnComplete = true;
				this.animation1.onComplete.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<TeamBeInvitedFrame>(this, false);
					this.bTryOpenNewInvite = false;
				});
				this.animation1.DOPlay();
				this.animation2.DOPlay();
			}
			catch (Exception ex)
			{
				this.frameMgr.CloseFrame<TeamBeInvitedFrame>(this, false);
				this.bTryOpenNewInvite = false;
			}
		}

		// Token: 0x06011915 RID: 71957 RVA: 0x0051DC5C File Offset: 0x0051C05C
		private void OnReject()
		{
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (inviteTeamList == null || inviteTeamList.Count == 0)
			{
				return;
			}
			if (this.teamBeInvteInfo == null)
			{
				return;
			}
			int inviteIndex = this.GetInviteIndex(this.teamBeInvteInfo);
			if (inviteIndex < 0 || inviteIndex >= inviteTeamList.Count)
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, new SceneReply
			{
				result = 0,
				type = 1,
				requester = (ulong)this.teamBeInvteInfo.baseinfo.teamId
			});
			inviteTeamList.RemoveAt(inviteIndex);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
		}

		// Token: 0x06011916 RID: 71958 RVA: 0x0051DD08 File Offset: 0x0051C108
		private void OnAgree()
		{
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (inviteTeamList == null || inviteTeamList.Count == 0)
			{
				return;
			}
			if (this.teamBeInvteInfo == null)
			{
				return;
			}
			int inviteIndex = this.GetInviteIndex(this.teamBeInvteInfo);
			if (inviteIndex < 0 || inviteIndex >= inviteTeamList.Count)
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, new SceneReply
			{
				result = 1,
				type = 1,
				requester = (ulong)this.teamBeInvteInfo.baseinfo.teamId
			});
			inviteTeamList.RemoveAt(inviteIndex);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
		}

		// Token: 0x06011917 RID: 71959 RVA: 0x0051DDB4 File Offset: 0x0051C1B4
		private int GetInviteIndex(NewTeamInviteList info)
		{
			if (info == null)
			{
				return -1;
			}
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			if (inviteTeamList == null)
			{
				return -1;
			}
			for (int i = 0; i < inviteTeamList.Count; i++)
			{
				NewTeamInviteList newTeamInviteList = inviteTeamList[i];
				if (newTeamInviteList.baseinfo.masterInfo.id == info.baseinfo.masterInfo.id && newTeamInviteList.baseinfo.target == info.baseinfo.target)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0400B6BB RID: 46779
		private NewTeamInviteList teamBeInvteInfo;

		// Token: 0x0400B6BC RID: 46780
		private bool bTryOpenNewInvite;

		// Token: 0x0400B6BD RID: 46781
		private const float fMaxTime = 25f;

		// Token: 0x0400B6BE RID: 46782
		private const float fHangUpTimeOut = 30f;

		// Token: 0x0400B6BF RID: 46783
		private float fFrameOpenTime;

		// Token: 0x0400B6C0 RID: 46784
		private Button BtnClose;

		// Token: 0x0400B6C1 RID: 46785
		private Image Icon;

		// Token: 0x0400B6C2 RID: 46786
		private Text Name;

		// Token: 0x0400B6C3 RID: 46787
		private Text Level;

		// Token: 0x0400B6C4 RID: 46788
		private Text Target;

		// Token: 0x0400B6C5 RID: 46789
		private Button reject;

		// Token: 0x0400B6C6 RID: 46790
		private Button hangUp;

		// Token: 0x0400B6C7 RID: 46791
		private Button agree;

		// Token: 0x0400B6C8 RID: 46792
		private Text hangUpText;

		// Token: 0x0400B6C9 RID: 46793
		private DOTweenAnimation animation1;

		// Token: 0x0400B6CA RID: 46794
		private DOTweenAnimation animation2;

		// Token: 0x0400B6CB RID: 46795
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x0400B6CC RID: 46796
		private GameObject returnPlayer;

		// Token: 0x0400B6CD RID: 46797
		private GameObject myFriend;

		// Token: 0x0400B6CE RID: 46798
		private GameObject myGuild;
	}
}
