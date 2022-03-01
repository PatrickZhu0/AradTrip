using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001172 RID: 4466
	public class SelectRoleFrame : ClientFrame
	{
		// Token: 0x0600AAC5 RID: 43717 RVA: 0x00248053 File Offset: 0x00246453
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelecteRoleNew/SelectRoleFrame";
		}

		// Token: 0x0600AAC6 RID: 43718 RVA: 0x0024805C File Offset: 0x0024645C
		protected sealed override void _bindExUI()
		{
			this.mRoleRecovery = this.mBind.GetCom<Button>("rolerecovery");
			this.mStartbutton = this.mBind.GetCom<Button>("startbutton");
			this.mBackbutton = this.mBind.GetCom<Button>("backbutton");
			this.mCreatebutton = this.mBind.GetCom<Button>("createbutton");
			this.mDeletebutton = this.mBind.GetCom<Button>("deleteRole");
			this.mBookingActivities = this.mBind.GetGameObject("BookingActivities");
			this.mAdventureTeamInfoRoot = this.mBind.GetGameObject("AdventureTeamInfoRoot");
			this.mAdventureTeamInfo = this.mBind.GetCom<ComAdventureTeamBriefInfo>("AdventureTeamInfo");
		}

		// Token: 0x0600AAC7 RID: 43719 RVA: 0x00248119 File Offset: 0x00246519
		protected sealed override void _unbindExUI()
		{
			this.mRoleRecovery = null;
			this.mClosebutton = null;
			this.mStartbutton = null;
			this.mCreatebutton = null;
			this.mDeletebutton = null;
			this.mBookingActivities = null;
			this.mAdventureTeamInfoRoot = null;
			this.mAdventureTeamInfo = null;
		}

		// Token: 0x0600AAC8 RID: 43720 RVA: 0x00248154 File Offset: 0x00246554
		protected sealed override void _OnOpenFrame()
		{
			this.mBookingActivities.CustomActive(ClientApplication.playerinfo.GetHasApponintmentActiviti());
			ClientSystemLogin.mSwitchRole = false;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateRole));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._OnRecoveryUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleDeleteOk, new ClientEventSystem.UIEventHandler(this._OnDeleteRoleOk));
			this._init();
			this.m_kRoleFunctionBinder.install(this, this.frame);
			ulong roleId = this.m_kRoleFunctionBinder.SetTheLatestLoginRoleAsDefault();
			this.m_kRoleFunctionBinder.refresh();
			this.m_kRoleFunctionBinder.OnRoleSelected(roleId);
			this._TryOpenCreateActorFrame();
			this._TryOpenOldPlayerFrame();
			this._InitAdventureTeamInfo();
			DataManager<BaseWebViewManager>.GetInstance().ShowConvertAccountTips();
		}

		// Token: 0x0600AAC9 RID: 43721 RVA: 0x00248224 File Offset: 0x00246624
		private void _init()
		{
			this.mStartbutton.onClick.AddListener(new UnityAction(this._onStartButton));
			this.mRoleRecovery.onClick.AddListener(new UnityAction(this._onClickRecovery));
			this.mBackbutton.onClick.AddListener(new UnityAction(this._onCloseButton));
			this.mCreatebutton.onClick.AddListener(new UnityAction(this._onCreateButton));
			this.mDeletebutton.onClick.AddListener(new UnityAction(this._onDeleteButton));
		}

		// Token: 0x0600AACA RID: 43722 RVA: 0x002482C0 File Offset: 0x002466C0
		private void _uninit()
		{
			this.mStartbutton.onClick.RemoveListener(new UnityAction(this._onStartButton));
			this.mRoleRecovery.onClick.RemoveListener(new UnityAction(this._onClickRecovery));
			this.mBackbutton.onClick.RemoveListener(new UnityAction(this._onCloseButton));
			this.mCreatebutton.onClick.RemoveListener(new UnityAction(this._onCreateButton));
			this.mDeletebutton.onClick.RemoveListener(new UnityAction(this._onDeleteButton));
		}

		// Token: 0x0600AACB RID: 43723 RVA: 0x0024835C File Offset: 0x0024675C
		protected sealed override void _OnCloseFrame()
		{
			this._uninit();
			if (this.m_kDeleteRoleConfirmFrame != null)
			{
				this.m_kDeleteRoleConfirmFrame.Close(true);
				this.m_kDeleteRoleConfirmFrame = null;
			}
			if (this.m_kRoleRecoveryFrame != null)
			{
				this.m_kRoleRecoveryFrame.Close(true);
				this.m_kRoleRecoveryFrame = null;
			}
			this.m_kRoleFunctionBinder.uninstall();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleInfoUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateRole));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleRecoveryUpdate, new ClientEventSystem.UIEventHandler(this._OnRecoveryUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleDeleteOk, new ClientEventSystem.UIEventHandler(this._OnDeleteRoleOk));
			MonoSingleton<AudioManager>.instance.StopAll(AudioType.AudioStream);
			MonoSingleton<AudioManager>.instance.StopAll(AudioType.AudioEffect);
			MonoSingleton<AudioManager>.instance.StopAll(AudioType.AudioVoice);
			ClientSystemLogin clientSystemLogin = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemLogin;
			if (clientSystemLogin != null)
			{
				clientSystemLogin.OnReturnToLogin();
			}
			this._ClearNewUnlockRoleField();
		}

		// Token: 0x0600AACC RID: 43724 RVA: 0x0024844A File Offset: 0x0024684A
		private void _OnUpdateRole(UIEvent uiEvent)
		{
			this.m_kRoleFunctionBinder.refresh();
			this._TryOpenCreateActorFrame();
		}

		// Token: 0x0600AACD RID: 43725 RVA: 0x0024845D File Offset: 0x0024685D
		private void _TryOpenCreateActorFrame()
		{
			if (this.m_kRoleFunctionBinder.IsEmpty())
			{
				this._onCreateButton();
			}
		}

		// Token: 0x0600AACE RID: 43726 RVA: 0x00248478 File Offset: 0x00246878
		private void _OnRecoveryUpdate(UIEvent uiEvent)
		{
			ulong roleId = (ulong)uiEvent.Param1;
			this.m_kRoleFunctionBinder.MoveToPageByRoleId(roleId);
			this.m_kRoleFunctionBinder.refresh();
			this.m_kRoleFunctionBinder.OnRoleSelected(roleId);
		}

		// Token: 0x0600AACF RID: 43727 RVA: 0x002484B4 File Offset: 0x002468B4
		private void _OnDeleteRoleOk(UIEvent uiEvent)
		{
			ulong roleId = this.m_kRoleFunctionBinder.SetTheLatestLoginRoleAsDefault();
			this.m_kRoleFunctionBinder.refresh();
			this.m_kRoleFunctionBinder.OnRoleSelected(roleId);
		}

		// Token: 0x0600AAD0 RID: 43728 RVA: 0x002484E4 File Offset: 0x002468E4
		public void OnDragSelectRole(float delta, bool selectRole = true)
		{
		}

		// Token: 0x0600AAD1 RID: 43729 RVA: 0x002484E6 File Offset: 0x002468E6
		public void SetSelectedID(int idx)
		{
		}

		// Token: 0x0600AAD2 RID: 43730 RVA: 0x002484E8 File Offset: 0x002468E8
		private void OnRoleSelected(RoleInfo roleInfo)
		{
			if (this.m_kCurrentRoleInfo != null)
			{
			}
		}

		// Token: 0x0600AAD3 RID: 43731 RVA: 0x002484F5 File Offset: 0x002468F5
		private void _onCloseButton()
		{
			ClientApplication.DisconnectGateServerAtLogin();
			this.frameMgr.CloseFrame<SelectRoleFrame>(this, false);
		}

		// Token: 0x0600AAD4 RID: 43732 RVA: 0x0024850C File Offset: 0x0024690C
		private int HistoryDeletedRoleCounts()
		{
			RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
			int num = 0;
			for (int i = 0; i < roleinfo.Length; i++)
			{
				if (RecoveryRoleCachedObject.OnFilter(roleinfo[i]))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600AAD5 RID: 43733 RVA: 0x0024854C File Offset: 0x0024694C
		private void _onDeleteButton()
		{
			if (this.HistoryDeletedRoleCounts() >= 3)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("delete_role_fulls_hint"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null)
			{
				if ((CachedSelectedObject<RoleData, RoleObject>.Selected as RoleObject).GetCurrRoleFieldState() == RoleSelectFieldState.LockHasRole)
				{
					string msgContent = TR.Value("select_role_delete_used_lock_field_tip");
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						this._TryOpenDeleteRoleConfirmFrame();
					}, null, 0f, false);
				}
				else
				{
					this._TryOpenDeleteRoleConfirmFrame();
				}
			}
		}

		// Token: 0x0600AAD6 RID: 43734 RVA: 0x002485D4 File Offset: 0x002469D4
		private void _TryOpenDeleteRoleConfirmFrame()
		{
			if (this.m_kDeleteRoleConfirmFrame != null)
			{
				this.m_kDeleteRoleConfirmFrame.Close(true);
				this.m_kDeleteRoleConfirmFrame = null;
			}
			this.m_kDeleteRoleConfirmFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<DeleteRoleConfirmFrame>(Utility.FindChild(this.frame, "ChildRoot"), CachedSelectedObject<RoleData, RoleObject>.Selected.Value, string.Empty);
		}

		// Token: 0x0600AAD7 RID: 43735 RVA: 0x0024862E File Offset: 0x00246A2E
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600AAD8 RID: 43736 RVA: 0x00248631 File Offset: 0x00246A31
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.m_kRoleFunctionBinder != null)
			{
				this.m_kRoleFunctionBinder.OnUpdate();
			}
		}

		// Token: 0x0600AAD9 RID: 43737 RVA: 0x00248649 File Offset: 0x00246A49
		private void _onCreateButton()
		{
			if (RecoveryRoleCachedObject.HasOwnedRoles >= RecoveryRoleCachedObject.EnabledRoleField)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("create_roles_full"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			ClientFrame.OpenTargetFrame<CreateActorFrame>(FrameLayer.Middle, null);
		}

		// Token: 0x0600AADA RID: 43738 RVA: 0x00248673 File Offset: 0x00246A73
		private void _TryOpenOldPlayerFrame()
		{
			if (ClientApplication.veteranReturn > 0U && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<OldPlayerFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<OldPlayerFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600AADB RID: 43739 RVA: 0x002486A4 File Offset: 0x00246AA4
		private void _onClickRecovery()
		{
			if (this.m_kRoleRecoveryFrame != null)
			{
				this.m_kRoleRecoveryFrame.Close(true);
				this.m_kRoleRecoveryFrame = null;
			}
			this.m_kRoleRecoveryFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<RoleRecoveryFrame>(Utility.FindChild(this.frame, "ChildRoot"), null, string.Empty);
		}

		// Token: 0x0600AADC RID: 43740 RVA: 0x002486F8 File Offset: 0x00246AF8
		private void _onStartButton()
		{
			int num = -1;
			if (CachedSelectedObject<RoleData, RoleObject>.Selected != null)
			{
				RoleInfo[] roleinfo = ClientApplication.playerinfo.roleinfo;
				for (int i = 0; i < roleinfo.Length; i++)
				{
					if (roleinfo[i].roleId == CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId)
					{
						num = i;
						break;
					}
				}
			}
			if (num != -1)
			{
				ClientApplication.playerinfo.curSelectedRoleIdx = num;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(ClientSystemLogin.StartEnterGame());
			}
			else
			{
				RoleInfo[] roleinfo2 = ClientApplication.playerinfo.roleinfo;
				if (roleinfo2.Length <= 0)
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("请先创建角色!", null, string.Empty, false);
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("请先选择一个角色!", null, string.Empty, false);
				}
			}
		}

		// Token: 0x0600AADD RID: 43741 RVA: 0x002487BC File Offset: 0x00246BBC
		private void _InitAdventureTeamInfo()
		{
			bool flag = false;
			if (ClientApplication.playerinfo != null && ClientApplication.playerinfo.adventureTeamInfo != null)
			{
				flag = !string.IsNullOrEmpty(ClientApplication.playerinfo.adventureTeamInfo.adventureTeamName);
				this.mAdventureTeamInfoRoot.CustomActive(flag);
			}
			if (this.mAdventureTeamInfo != null && flag)
			{
				this.mAdventureTeamInfo.RefreshView();
			}
		}

		// Token: 0x0600AADE RID: 43742 RVA: 0x0024882A File Offset: 0x00246C2A
		private void _ClearNewUnlockRoleField()
		{
			ClientApplication.playerinfo.newUnLockExtendRoleFieldNum = 0U;
		}

		// Token: 0x04005FBA RID: 24506
		private const int kMaxRoleCount = 3;

		// Token: 0x04005FBB RID: 24507
		private const string kRoleUnitPath = "UIFlatten/Prefabs/SelectRole/SelectRoleSlot";

		// Token: 0x04005FBC RID: 24508
		private Button mClosebutton;

		// Token: 0x04005FBD RID: 24509
		private Button mStartbutton;

		// Token: 0x04005FBE RID: 24510
		private Text mStarttext;

		// Token: 0x04005FBF RID: 24511
		private Button mBackbutton;

		// Token: 0x04005FC0 RID: 24512
		private Button mCreatebutton;

		// Token: 0x04005FC1 RID: 24513
		private GameObject mRoleroot;

		// Token: 0x04005FC2 RID: 24514
		private ToggleGroup mToggleroot;

		// Token: 0x04005FC3 RID: 24515
		private Button mDeletebutton;

		// Token: 0x04005FC4 RID: 24516
		private Button mRoleRecovery;

		// Token: 0x04005FC5 RID: 24517
		private GameObject mBookingActivities;

		// Token: 0x04005FC6 RID: 24518
		private GameObject mAdventureTeamInfoRoot;

		// Token: 0x04005FC7 RID: 24519
		private ComAdventureTeamBriefInfo mAdventureTeamInfo;

		// Token: 0x04005FC8 RID: 24520
		protected GeAvatarRendererEx m_kAvatarRender;

		// Token: 0x04005FC9 RID: 24521
		protected RoleInfo m_kCurrentRoleInfo;

		// Token: 0x04005FCA RID: 24522
		private RoleFunctionBinder m_kRoleFunctionBinder = new RoleFunctionBinder();

		// Token: 0x04005FCB RID: 24523
		private IClientFrame m_kDeleteRoleConfirmFrame;

		// Token: 0x04005FCC RID: 24524
		private IClientFrame m_kRoleRecoveryFrame;
	}
}
