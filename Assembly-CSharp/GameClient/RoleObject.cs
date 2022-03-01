using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200116D RID: 4461
	internal class RoleObject : CachedSelectedObject<RoleData, RoleObject>
	{
		// Token: 0x0600AA6B RID: 43627 RVA: 0x00245918 File Offset: 0x00243D18
		public override void Initialize()
		{
			this.Name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
			this.Lv = Utility.FindComponent<Text>(this.goLocal, "Horizen/Lv", true);
			this.Job = Utility.FindComponent<Text>(this.goLocal, "Horizen/Job", true);
			this.AvatarRender = Utility.FindComponent<GeAvatarRendererEx>(this.goLocal, "AvatarRenderer", true);
			this.rawImage = Utility.FindComponent<RawImage>(this.goLocal, "AvatarRenderer", true);
			this.objImgSelect = Utility.FindThatChild("select", this.goLocal, false);
			this.objImgDisSelect = Utility.FindThatChild("disSelect", this.goLocal, false);
			this.objBookingActivities = Utility.FindGameObject(this.goLocal, "BookingActivities", true);
			this.mOldPlayer = Utility.FindGameObject(this.goLocal, "OldPlayer", true);
			this.likeBtn = Utility.FindComponent<Button>(this.goLocal, "Like", true);
			this.likeIcon = Utility.FindComponent<Image>(this.goLocal, "Like/Icon", true);
			if (this.likeBtn != null)
			{
				this.likeBtn.CustomActive(false);
				this.likeBtn.onClick.RemoveAllListeners();
				this.likeBtn.onClick.AddListener(new UnityAction(this.OnLikeBtnClick));
			}
			this.objImgSelect.CustomActive(false);
			this.objImgDisSelect.CustomActive(true);
			if (this.goLocal)
			{
				this.mRoleField = this.goLocal.GetComponent<ComSelectRoleField>();
			}
			this.SetTxtColor(true);
			this.playQueueIdle = false;
			this.preferenccePath = TR.Value("select_role_preference_path");
			this.unPreferenccePath = TR.Value("select_role_un_preference_path");
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(706, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_iTotalPreferenceRoleCount = tableItem.Value;
			}
		}

		// Token: 0x0600AA6C RID: 43628 RVA: 0x00245B00 File Offset: 0x00243F00
		public override void UnInitialize()
		{
			this.rawImage = null;
			this.effectSelected = null;
			if (this.AvatarRender != null)
			{
				this.AvatarRender.ClearAvatar();
				this.AvatarRender = null;
			}
			this.Job = null;
			this.Lv = null;
			this.Name = null;
			this.playQueueIdle = false;
			this.mRoleField = null;
		}

		// Token: 0x0600AA6D RID: 43629 RVA: 0x00245B64 File Offset: 0x00243F64
		private void OnLikeBtnClick()
		{
			base.OnSelected();
			if (base.Value != null && base.Value.roleInfo != null)
			{
				if (base.Value.roleInfo.addPreferencesTime <= 0U && PlayerUtility.GetPreferenceCountInAccount() >= this.m_iTotalPreferenceRoleCount)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("select_role_set_preference_full"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (base.Value.roleInfo.addPreferencesTime > 0U)
				{
					if (!DataManager<PlayerBaseData>.GetInstance().bIsCancelPreferenceRole)
					{
						string content = TR.Value("select_role_cancel_preference");
						Utility.CommonPopupWindow(content, new OnCommonMsgBoxToggleClick(this.OnCancelPreferenceToggleClick), new Action(this.OnGateSetRolePreferencesReq));
						return;
					}
				}
				else if (!DataManager<PlayerBaseData>.GetInstance().bIsSetPreferenceRole)
				{
					string content2 = TR.Value("select_role_set_preference", this.m_iTotalPreferenceRoleCount, PlayerUtility.GetPreferenceCountInAccount());
					Utility.CommonPopupWindow(content2, new OnCommonMsgBoxToggleClick(this.OnSetPreferenceToggleClick), new Action(this.OnGateSetRolePreferencesReq));
					return;
				}
				this.OnGateSetRolePreferencesReq();
			}
		}

		// Token: 0x0600AA6E RID: 43630 RVA: 0x00245C72 File Offset: 0x00244072
		private void OnCancelPreferenceToggleClick(bool value)
		{
			DataManager<PlayerBaseData>.GetInstance().bIsCancelPreferenceRole = value;
		}

		// Token: 0x0600AA6F RID: 43631 RVA: 0x00245C7F File Offset: 0x0024407F
		private void OnSetPreferenceToggleClick(bool value)
		{
			DataManager<PlayerBaseData>.GetInstance().bIsSetPreferenceRole = value;
		}

		// Token: 0x0600AA70 RID: 43632 RVA: 0x00245C8C File Offset: 0x0024408C
		private void OnGateSetRolePreferencesReq()
		{
			if (base.Value != null && base.Value.roleInfo != null)
			{
				GateSetRolePreferencesReq gateSetRolePreferencesReq = new GateSetRolePreferencesReq();
				gateSetRolePreferencesReq.roleId = base.Value.roleInfo.roleId;
				if (base.Value.roleInfo.addPreferencesTime > 0U)
				{
					gateSetRolePreferencesReq.preferencesFlag = 1;
				}
				else
				{
					gateSetRolePreferencesReq.preferencesFlag = 0;
				}
				NetManager.Instance().SendCommand<GateSetRolePreferencesReq>(ServerType.GATE_SERVER, gateSetRolePreferencesReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait<GateSetRolePreferencesRet>(delegate(GateSetRolePreferencesRet msgRet)
				{
					if (msgRet.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					}
					else if (base.Value.roleInfo != null && base.Value.roleInfo.roleId == msgRet.roleId)
					{
						base.Value.roleInfo.addPreferencesTime = msgRet.addPreferencesTime;
						base.Value.roleInfo.delPreferencesTime = msgRet.delPreferencesTime;
						this.RefreshLikeInfo();
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshRolePreferenceCount, null, null, null, null);
					}
				}, true, 15f, null);
			}
		}

		// Token: 0x0600AA71 RID: 43633 RVA: 0x00245D24 File Offset: 0x00244124
		public override void OnUpdate()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)base.Value.roleInfo.occupation, string.Empty, string.Empty);
			if (base.Value == null || tableItem == null)
			{
				this._DisableAvatar();
			}
			else
			{
				this._CreateRoleActor(this.AvatarRender, tableItem.Mode);
				this.rawImage.enabled = true;
				this.Job.text = tableItem.Name;
				this.Lv.text = "Lv." + base.Value.roleInfo.level;
				this.Name.text = base.Value.roleInfo.name;
				if (base.Value.roleInfo.isVeteranReturn > 0 && this.mOldPlayer != null)
				{
					this.mOldPlayer.CustomActive(true);
				}
				else
				{
					this.mOldPlayer.CustomActive(false);
				}
				this.objBookingActivities.CustomActive(ClientApplication.playerinfo.GetRoleHasApponintmentOccu(base.Value.roleInfo));
				this.RefreshLikeInfo();
			}
		}

		// Token: 0x0600AA72 RID: 43634 RVA: 0x00245E50 File Offset: 0x00244250
		private void RefreshLikeInfo()
		{
			if (base.Value != null && base.Value.roleInfo != null)
			{
				if (base.Value.roleInfo.addPreferencesTime > 0U)
				{
					if (this.likeBtn != null)
					{
						this.likeBtn.CustomActive(true);
					}
					if (this.likeIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.likeIcon, this.preferenccePath, true);
					}
				}
				else
				{
					if (this.likeIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.likeIcon, this.unPreferenccePath, true);
					}
					if (CachedSelectedObject<RoleData, RoleObject>.Selected != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value != null && CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo != null)
					{
						if (CachedSelectedObject<RoleData, RoleObject>.Selected.Value.roleInfo.roleId == base.Value.roleInfo.roleId)
						{
							if (this.likeBtn != null)
							{
								this.likeBtn.CustomActive(true);
							}
						}
						else if (this.likeBtn != null)
						{
							this.likeBtn.CustomActive(false);
						}
					}
				}
			}
		}

		// Token: 0x0600AA73 RID: 43635 RVA: 0x00245F90 File Offset: 0x00244390
		public override void OnDisplayChanged(bool bShow)
		{
			if (this.effectSelected != null)
			{
				this.effectSelected.SetVisible(bShow);
				this.effectSelected2.SetVisible(!bShow);
				this.objImgDisSelect.CustomActive(!bShow);
				this.objImgSelect.CustomActive(bShow);
				this.SetTxtColor(!bShow);
			}
			if (this.AvatarRender != null)
			{
				if (bShow)
				{
					this.ChangeAction(this.AvatarRender, RoleObject.m_ActionTable[1]);
					this.playQueueIdle = true;
				}
				else
				{
					this.playQueueIdle = false;
					this.ChangeAction(this.AvatarRender, RoleObject.m_ActionTable[0]);
				}
			}
			if (this.likeBtn != null)
			{
				if (bShow)
				{
					this.likeBtn.CustomActive(true);
				}
				else if (base.Value != null && base.Value.roleInfo != null)
				{
					if (base.Value.roleInfo.addPreferencesTime > 0U)
					{
						this.likeBtn.CustomActive(true);
					}
					else
					{
						this.likeBtn.CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600AA74 RID: 43636 RVA: 0x002460B0 File Offset: 0x002444B0
		public override void OnFrameUpdate()
		{
			if (this.AvatarRender != null && this.AvatarRender.IsCurActionEnd() && this.playQueueIdle)
			{
				this.playQueueIdle = false;
				this.ChangeAction(this.AvatarRender, RoleObject.m_ActionTable[0]);
			}
		}

		// Token: 0x0600AA75 RID: 43637 RVA: 0x00246104 File Offset: 0x00244504
		public void ChangeAction(GeAvatarRendererEx avatar, string actionName)
		{
			if (avatar == null)
			{
				return;
			}
			bool loop = false;
			if (actionName.ToLower().Contains("idle"))
			{
				loop = true;
			}
			avatar.ChangeAction(actionName, 1f, loop);
		}

		// Token: 0x0600AA76 RID: 43638 RVA: 0x00246144 File Offset: 0x00244544
		public void SetTxtColor(bool isGray = true)
		{
			if (isGray)
			{
				this.Name.color = Color.gray;
				this.Lv.color = Color.gray;
				this.Job.color = Color.gray;
			}
			else
			{
				this.Name.color = Color.white;
				this.Lv.color = Color.white;
				this.Job.color = Color.white;
			}
		}

		// Token: 0x0600AA77 RID: 43639 RVA: 0x002461BC File Offset: 0x002445BC
		public RoleSelectFieldState GetCurrRoleFieldState()
		{
			if (this.mRoleField != null)
			{
				return this.mRoleField.GetRoleSelectFieldState();
			}
			return RoleSelectFieldState.Default;
		}

		// Token: 0x0600AA78 RID: 43640 RVA: 0x002461DC File Offset: 0x002445DC
		private void _DisableAvatar()
		{
			this.AvatarRender.ClearAvatar();
			this.rawImage.enabled = false;
			if (this.effectSelected != null)
			{
				this.effectSelected.SetVisible(false);
			}
			if (this.likeBtn != null)
			{
				this.likeBtn.CustomActive(false);
			}
		}

		// Token: 0x0600AA79 RID: 43641 RVA: 0x00246234 File Offset: 0x00244634
		private void _LoadActorLight(bool createRole)
		{
			if (null != this.SceneLightRoot)
			{
				Object.Destroy(this.SceneLightRoot);
			}
			if (createRole)
			{
				this.SceneLightRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("Scene/Start/Perfab/Light_chuangjue", true, 0U);
			}
			else
			{
				this.SceneLightRoot = Singleton<AssetLoader>.instance.LoadResAsGameObject("Scene/Start/Perfab/Light_xuanjue", true, 0U);
			}
		}

		// Token: 0x0600AA7A RID: 43642 RVA: 0x00246298 File Offset: 0x00244698
		private void _CreateRoleActor(GeAvatarRendererEx actor, int iModeId)
		{
			if (actor == null)
			{
				Logger.LogErrorFormat("actor is null!", new object[0]);
				return;
			}
			ResTable tableItem = Singleton<TableManager>.instance.GetTableItem<ResTable>(iModeId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("角色模型无法找到 ProtoTable.ResTable ID = [{0}]", new object[]
				{
					iModeId
				});
				return;
			}
			actor.LoadAvatar(tableItem.ModelPath, -1);
			this._LoadEquipments(actor);
			this.ChangeAction(actor, RoleObject.m_ActionTable[0]);
			this.effectSelected = this.AvatarRender.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			this.effectSelected2 = this.AvatarRender.AttachAvatar("DisSelect", "Effects/Scene_effects/EffectUI/EffUI_chuangjue_fazhen_JS_jingtai", "[actor]Orign", false, true, false, 0f);
			this.effectSelected.SetVisible(false);
			this.effectSelected2.SetVisible(true);
		}

		// Token: 0x0600AA7B RID: 43643 RVA: 0x00246384 File Offset: 0x00244784
		private void _LoadEquipments(GeAvatarRendererEx actor)
		{
			DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(actor, base.Value.roleInfo.avatar.equipItemIds, (int)base.Value.roleInfo.occupation, (int)base.Value.roleInfo.avatar.weaponStrengthen, null, false, base.Value.roleInfo.avatar.isShoWeapon, false);
		}

		// Token: 0x04005F85 RID: 24453
		protected static readonly string[] m_ActionTable = new string[]
		{
			"Anim_Show_Idle",
			"Anim_Show_Idle_special01",
			"Anim_Show_Idle_special02"
		};

		// Token: 0x04005F86 RID: 24454
		private string preferenccePath = string.Empty;

		// Token: 0x04005F87 RID: 24455
		private string unPreferenccePath = string.Empty;

		// Token: 0x04005F88 RID: 24456
		private int m_iTotalPreferenceRoleCount;

		// Token: 0x04005F89 RID: 24457
		private Text Name;

		// Token: 0x04005F8A RID: 24458
		private Text Lv;

		// Token: 0x04005F8B RID: 24459
		private Text Job;

		// Token: 0x04005F8C RID: 24460
		private GeAvatarRendererEx AvatarRender;

		// Token: 0x04005F8D RID: 24461
		private GeAttach effectSelected;

		// Token: 0x04005F8E RID: 24462
		private GeAttach effectSelected2;

		// Token: 0x04005F8F RID: 24463
		private RawImage rawImage;

		// Token: 0x04005F90 RID: 24464
		private GameObject SceneLightRoot;

		// Token: 0x04005F91 RID: 24465
		private bool playQueueIdle;

		// Token: 0x04005F92 RID: 24466
		private GameObject objImgSelect;

		// Token: 0x04005F93 RID: 24467
		private GameObject objImgDisSelect;

		// Token: 0x04005F94 RID: 24468
		private GameObject objBookingActivities;

		// Token: 0x04005F95 RID: 24469
		private GameObject mOldPlayer;

		// Token: 0x04005F96 RID: 24470
		private Button likeBtn;

		// Token: 0x04005F97 RID: 24471
		private Image likeIcon;

		// Token: 0x04005F98 RID: 24472
		private ComSelectRoleField mRoleField;
	}
}
