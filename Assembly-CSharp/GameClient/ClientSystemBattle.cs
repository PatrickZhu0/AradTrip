using System;
using System.Collections;
using System.Collections.Generic;
using ActivityLimitTime;
using behaviac;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x02001070 RID: 4208
	public class ClientSystemBattle : ClientSystem
	{
		// Token: 0x06009E41 RID: 40513 RVA: 0x001F5FC3 File Offset: 0x001F43C3
		protected void InitSwitchEquip()
		{
			if (!this.CanSwitchEquip())
			{
				return;
			}
			this.mSwitchEquips.gameObject.CustomActive(true);
		}

		// Token: 0x06009E42 RID: 40514 RVA: 0x001F5FE2 File Offset: 0x001F43E2
		public void InitSwitchEquipIcon(int index)
		{
			this.ChangeEquipIcon(index);
		}

		// Token: 0x06009E43 RID: 40515 RVA: 0x001F5FEB File Offset: 0x001F43EB
		public void SetSwitchEquipBtnState(bool flag)
		{
			if (!this.CanSwitchEquip())
			{
				return;
			}
			if (this.mSwitchEquips == null)
			{
				return;
			}
			this.mSwitchEquips.gameObject.CustomActive(flag);
		}

		// Token: 0x06009E44 RID: 40516 RVA: 0x001F601C File Offset: 0x001F441C
		private void _onSwitchEquipsBtnButtonClick()
		{
			BeActor localActor = this.GetLocalActor();
			if (localActor == null)
			{
				return;
			}
			if (localActor.IsCastingSkill())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("技能施放动作期间无法切换装备", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TweenSettingsExtensions.OnComplete<Tweener>(ShortcutExtensions.DOScale(this.mSwitchEquipsBtn.transform.parent, 1.3f, 0.1f), delegate()
			{
				ShortcutExtensions.DOScale(this.mSwitchEquipsBtn.transform.parent, 1.2f, 0.1f);
			});
			if (this.mSwitchEquipCD != null && this.mSwitchEquipCD.surplusTime > 0f)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("切换装备冷却中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (localActor.isSpecialMonster)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("当前状态不可切换", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (!this.CanSwitchEquip())
			{
				return;
			}
			this.StartSwitchEquipCD();
			int num = (localActor.GetCurrentSchemeIndex() != 0) ? 0 : 1;
			this.ChangeEquipIcon(num);
			ChangeWeaponCommand changeWeaponCommand = new ChangeWeaponCommand();
			changeWeaponCommand.equipIndex = num + 1;
			FrameSync.instance.FireFrameCommand(changeWeaponCommand, false);
		}

		// Token: 0x06009E45 RID: 40517 RVA: 0x001F6114 File Offset: 0x001F4514
		public void ChangeEquipIcon(int pathIndex)
		{
			if (this.mSwitchEquipIcon == null)
			{
				return;
			}
			string path = this.m_IconPath[pathIndex];
			ETCImageLoader.LoadSprite(ref this.mSwitchEquipIcon, path, true);
		}

		// Token: 0x06009E46 RID: 40518 RVA: 0x001F614C File Offset: 0x001F454C
		protected void StartSwitchEquipCD()
		{
			BeActor localActor = this.GetLocalActor();
			if (localActor == null)
			{
				return;
			}
			float num = 3f;
			float num2 = 0f;
			Mechanism81 mechanism = localActor.GetMechanism(5072) as Mechanism81;
			if (mechanism != null)
			{
				num2 = mechanism.changeWeaponCD.f;
			}
			Mechanism81 mechanism2 = localActor.GetMechanism(158) as Mechanism81;
			if (mechanism2 != null)
			{
				num2 += mechanism2.changeWeaponCD.f;
			}
			if (mechanism != null && this.mSwitchEquipCD != null)
			{
				this.mSwitchEquipCD.StartCD(num * (1f + num2));
			}
			else
			{
				this.mSwitchEquipCD.StartCD(num);
			}
		}

		// Token: 0x06009E47 RID: 40519 RVA: 0x001F61FA File Offset: 0x001F45FA
		public void ResetChangeEquipCD()
		{
			if (this.mSwitchEquipCD == null)
			{
				return;
			}
			this.mSwitchEquipCD.ResetCD();
		}

		// Token: 0x06009E48 RID: 40520 RVA: 0x001F6219 File Offset: 0x001F4619
		protected BeActor GetLocalActor()
		{
			if (BattleMain.instance == null)
			{
				return null;
			}
			if (BattleMain.instance.GetLocalPlayer(0UL) == null)
			{
				return null;
			}
			return BattleMain.instance.GetLocalPlayer(0UL).playerActor;
		}

		// Token: 0x06009E49 RID: 40521 RVA: 0x001F624C File Offset: 0x001F464C
		protected bool CanSwitchEquip()
		{
			if (this.mSwitchEquips == null || Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return false;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer != null && !mainPlayer.isFighting && BattleMain.battleType == BattleType.PVP3V3Battle)
			{
				return false;
			}
			if (BattleMain.IsModePvP(BattleMain.battleType))
			{
				return false;
			}
			if (BattleMain.battleType == BattleType.TrainingSkillCombo)
			{
				return false;
			}
			BeActor localActor = this.GetLocalActor();
			if (localActor == null)
			{
				return false;
			}
			int schemeCount = localActor.GetSchemeCount();
			return schemeCount > 1;
		}

		// Token: 0x06009E4A RID: 40522 RVA: 0x001F62E8 File Offset: 0x001F46E8
		protected sealed override void _bindExUI()
		{
			this.m_countScirpt = this.mBind.GetCom<ComCountScript>("_countScirpt");
			this.mTimerRoot = this.mBind.GetGameObject("timerRoot");
			this.mLeftPKRoot = this.mBind.GetGameObject("leftPKRoot");
			this.mRightPKRoot = this.mBind.GetGameObject("rightPKRoot");
			ClientSystemBattle.mTimerController = this.mBind.GetCom<SimpleTimer>("timerController");
			this.mAutoFightRootObj = this.mBind.GetGameObject("autoFightRootObj");
			this.mChatRoot = this.mBind.GetGameObject("chatRoot");
			this.mProfessionInfo = this.mBind.GetGameObject("ProfessionInfo");
			this.mBossBarRoot = this.mBind.GetGameObject("bossBarRoot");
			ClientSystemBattle.pingText = this.mBind.GetCom<Text>("pingText");
			this.mBtnWatchLeft = this.mBind.GetCom<Button>("btnWatchLeft");
			this.mBtnWatchLeft.onClick.AddListener(new UnityAction(this._onBtnWatchLeftButtonClick));
			this.mBtnWatchLeft.CustomActive(false);
			this.mBtnWatchRight = this.mBind.GetCom<Button>("btnWatchRight");
			this.mBtnWatchRight.onClick.AddListener(new UnityAction(this._onBtnWatchRightButtonClick));
			this.mBtnWatchRight.CustomActive(true);
			this.mPvp3v3Button = this.mBind.GetCom<Button>("pvp3v3Button");
			this.mPvp3v3Button.onClick.AddListener(new UnityAction(this._onPvp3v3ButtonButtonClick));
			this.mPvp3v3RightPendingRoot = this.mBind.GetGameObject("pvp3v3RightPendingRoot");
			this.mPvp3v3LeftPendingRoot = this.mBind.GetGameObject("pvp3v3LeftPendingRoot");
			this.mPvp3v3FightOn = this.mBind.GetGameObject("pvp3v3FightOn");
			this.mPvp3v3FightOff = this.mBind.GetGameObject("pvp3v3FightOff");
			this.mPvp3v3TimeLimitButton = this.mBind.GetCom<ComTimeLimitButton>("pvp3v3TimeLimitButton");
			this.mPvp3v3MicBtn = this.mBind.GetCom<Button>("pvp3v3MicBtn");
			this.mPvp3v3MicBtn.onClick.AddListener(new UnityAction(this._onPvp3v3MicBtnButtonClick));
			this.mPvp3v3MicBtnBg = this.mBind.GetCom<Image>("pvp3v3MicBtnBg");
			this.mPvp3v3MicBtnClose = this.mBind.GetCom<Image>("pvp3v3MicBtnClose");
			this.mPvp3v3PlayerBtn = this.mBind.GetCom<Button>("pvp3v3PlayerBtn");
			this.mPvp3v3PlayerBtn.onClick.AddListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtnBg = this.mBind.GetCom<Image>("pvp3v3PlayerBtnBg");
			this.mPvp3v3PlayerBtnClose = this.mBind.GetCom<Image>("pvp3v3PlayerBtnClose");
			this.mTeamVoiceBtnGo = this.mBind.GetGameObject("teamVoiceBtnGo");
			this.mTeamVoiceBtn = this.mBind.GetCom<VoiceInputBtn>("teamVoiceBtn");
			this.weaponIcon = this.mBind.GetCom<Image>("weaponIcon");
			this.weaponBack = this.mBind.GetCom<Image>("weaponBack");
			this.cdCoolDowm = this.mBind.GetCom<CDCoolDowm>("cdCoolDown");
			this.mBtnChangeWeapon = this.mBind.GetCom<Button>("btnChangeWeapon");
			this.mBtnChangeWeapon.onClick.AddListener(new UnityAction(this._onBtnChangeWeaponButtonClick));
			this.mSwitchEquipIcon = this.mBind.GetCom<Image>("SwitchEquipIcon");
			this.mFightingTimeRoot = this.mBind.GetCom<ComDungeonScore>("FightingTimeRoot");
			this.mVanityBonusBuffConent = this.mBind.GetGameObject("VanityBonusBuffConent");
			this.mVanityBonusBuffIcon = this.mBind.GetCom<Image>("VanityBonusBuffIcon");
			this.mRebornInfoRoot = this.mBind.GetGameObject("RebornInfo");
			this.mSwitchEquips = this.mBind.GetCom<RectTransform>("SwitchEquips");
			this.mSwitchEquipsBtn = this.mBind.GetCom<Button>("SwitchEquipsBtn");
			this.mSwitchEquipsBtn.onClick.AddListener(new UnityAction(this._onSwitchEquipsBtnButtonClick));
			this.mSwitchEquipCD = this.mBind.GetCom<CDCoolDowm>("SwitchEquipCD");
			this.mRebornDesc = this.mBind.GetCom<Text>("RebornDesc");
			this.mVoiceTalkRoots = this.mBind.GetCom<ComVoiceTalkRootGroup>("VoiceTalkRoots");
		}

		// Token: 0x06009E4B RID: 40523 RVA: 0x001F6740 File Offset: 0x001F4B40
		protected sealed override void _unbindExUI()
		{
			ClientSystemBattle.pingText = null;
			this.m_countScirpt = null;
			this.mTimerRoot = null;
			this.mLeftPKRoot = null;
			this.mRightPKRoot = null;
			ClientSystemBattle.mTimerController = null;
			this.mAutoFightRootObj = null;
			this.mChatRoot = null;
			this.mProfessionInfo = null;
			this.mBossBarRoot = null;
			this.mBtnWatchLeft.onClick.RemoveListener(new UnityAction(this._onBtnWatchLeftButtonClick));
			this.mBtnWatchLeft = null;
			this.mBtnWatchRight.onClick.RemoveListener(new UnityAction(this._onBtnWatchRightButtonClick));
			this.mBtnWatchRight = null;
			this.mPvp3v3Button.onClick.RemoveListener(new UnityAction(this._onPvp3v3ButtonButtonClick));
			this.mPvp3v3Button = null;
			this.m_CountDownTimer = null;
			this.mPvp3v3RightPendingRoot = null;
			this.mPvp3v3LeftPendingRoot = null;
			this.mPvp3v3FightOn = null;
			this.mPvp3v3FightOff = null;
			this.mPvp3v3TimeLimitButton = null;
			this.mPvp3v3MicBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3MicBtnButtonClick));
			this.mPvp3v3MicBtn = null;
			this.mPvp3v3MicBtnBg = null;
			this.mPvp3v3MicBtnClose = null;
			this.mPvp3v3PlayerBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtn = null;
			this.mPvp3v3PlayerBtnBg = null;
			this.mPvp3v3PlayerBtnClose = null;
			this.mTeamVoiceBtnGo = null;
			this.mTeamVoiceBtn = null;
			this.mBtnChangeWeapon.onClick.RemoveListener(new UnityAction(this._onBtnChangeWeaponButtonClick));
			this.mBtnChangeWeapon = null;
			this.mSwitchEquipIcon = null;
			this.mFightingTimeRoot = null;
			this.mVanityBonusBuffConent = null;
			this.mVanityBonusBuffIcon = null;
			this.mRebornInfoRoot = null;
			this.mSwitchEquips = null;
			this.mSwitchEquipsBtn.onClick.RemoveListener(new UnityAction(this._onSwitchEquipsBtnButtonClick));
			this.mSwitchEquipsBtn = null;
			this.mSwitchEquipCD = null;
			this.mRebornDesc = null;
			this.mVoiceTalkRoots = null;
		}

		// Token: 0x06009E4C RID: 40524 RVA: 0x001F6919 File Offset: 0x001F4D19
		public void SetRebornDescOpen(bool isActive)
		{
			if (this.mRebornInfoRoot != null)
			{
				this.mRebornInfoRoot.CustomActive(isActive);
			}
		}

		// Token: 0x06009E4D RID: 40525 RVA: 0x001F6938 File Offset: 0x001F4D38
		public void RefreshRebornCount(int leftCount, int maxCount)
		{
			if (this.mRebornDesc != null)
			{
				this.mRebornDesc.text = string.Format("队伍复活次数 : {0}/{1}", leftCount, maxCount);
			}
		}

		// Token: 0x06009E4E RID: 40526 RVA: 0x001F696C File Offset: 0x001F4D6C
		private void _onBtnWatchLeftButtonClick()
		{
			this.mBtnWatchLeft.CustomActive(false);
			this.mBtnWatchRight.CustomActive(true);
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().SwitchWatchPlayer(true);
			}
		}

		// Token: 0x06009E4F RID: 40527 RVA: 0x001F69A0 File Offset: 0x001F4DA0
		private void _onBtnWatchRightButtonClick()
		{
			this.mBtnWatchRight.CustomActive(false);
			this.mBtnWatchLeft.CustomActive(true);
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().SwitchWatchPlayer(false);
			}
		}

		// Token: 0x06009E50 RID: 40528 RVA: 0x001F69D4 File Offset: 0x001F4DD4
		private void _onPvp3v3ButtonButtonClick()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer == null)
			{
				return;
			}
			MatchRoundVote cmd = new MatchRoundVote
			{
				isVote = !mainPlayer.isVote
			};
			FrameSync.instance.FireFrameCommand(cmd, false);
			this._update3v3ApplyFightStatus();
		}

		// Token: 0x06009E51 RID: 40529 RVA: 0x001F6A3C File Offset: 0x001F4E3C
		private void _onPvp3v3MicBtnButtonClick()
		{
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			this.OnVoiceSDKMicClick();
		}

		// Token: 0x06009E52 RID: 40530 RVA: 0x001F6A54 File Offset: 0x001F4E54
		private void _onPvp3v3PlayerBtnButtonClick()
		{
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			this.OnVoiceSDKPlayerClick();
		}

		// Token: 0x06009E53 RID: 40531 RVA: 0x001F6A6C File Offset: 0x001F4E6C
		private void _onBtnChangeWeaponButtonClick()
		{
			try
			{
				if (!Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					TweenSettingsExtensions.OnComplete<Tweener>(ShortcutExtensions.DOScale(this.mBtnChangeWeapon.transform.parent, 1.3f, 0.1f), delegate()
					{
						ShortcutExtensions.DOScale(this.mBtnChangeWeapon.transform.parent, 1.2f, 0.1f);
					});
					BeActor playerActor = BattleMain.instance.GetLocalPlayer(0UL).playerActor;
					if (this.cdCoolDowm != null && this.cdCoolDowm.surplusTime > 0f)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("切换武器冷却中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else if (playerActor != null && playerActor.isSpecialMonster)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("当前状态不可切换", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						if (playerActor.IsCastingSkill())
						{
							BeSkill currentSkill = playerActor.GetCurrentSkill();
							if (currentSkill != null)
							{
								bool flag = true;
								BeActor localActor = this.GetLocalActor();
								if (localActor != null)
								{
									flag = localActor.TriggerEventNew(BeEventType.onCanChangeWeaponButton, new EventParam
									{
										m_Bool = flag
									}).m_Bool;
								}
								if (currentSkill.canSwitchWeapon && flag)
								{
									this.ChangeWeapon(0);
								}
								else
								{
									SystemNotifyManager.SysNotifyFloatingEffect("该技能释放过程中无法更换武器", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
								}
							}
						}
						else
						{
							this.ChangeWeapon(0);
						}
						MonoSingleton<AudioManager>.instance.PlaySound(102);
						Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("BattleChangeWeapon");
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("_onBtnChangeWeaponButtonClick:{0}", new object[]
				{
					ex.Message
				});
			}
		}

		// Token: 0x17001986 RID: 6534
		// (get) Token: 0x06009E54 RID: 40532 RVA: 0x001F6C08 File Offset: 0x001F5008
		public static SimpleTimer TimerController
		{
			get
			{
				return ClientSystemBattle.mTimerController;
			}
		}

		// Token: 0x17001987 RID: 6535
		// (get) Token: 0x06009E55 RID: 40533 RVA: 0x001F6C0F File Offset: 0x001F500F
		public GameObject PlayerSelfInfoRoot
		{
			get
			{
				return this.mPlayerSelfInfo;
			}
		}

		// Token: 0x17001988 RID: 6536
		// (get) Token: 0x06009E56 RID: 40534 RVA: 0x001F6C17 File Offset: 0x001F5017
		public GameObject PlayerOtherInfoRoot
		{
			get
			{
				return this.mPlayerSelfInfo;
			}
		}

		// Token: 0x17001989 RID: 6537
		// (get) Token: 0x06009E57 RID: 40535 RVA: 0x001F6C1F File Offset: 0x001F501F
		public GameObject PlayerPKLeftRoot
		{
			get
			{
				return this.mLeftPKRoot;
			}
		}

		// Token: 0x1700198A RID: 6538
		// (get) Token: 0x06009E58 RID: 40536 RVA: 0x001F6C27 File Offset: 0x001F5027
		public GameObject PlayerPKRightRoot
		{
			get
			{
				return this.mRightPKRoot;
			}
		}

		// Token: 0x1700198B RID: 6539
		// (get) Token: 0x06009E59 RID: 40537 RVA: 0x001F6C2F File Offset: 0x001F502F
		public GameObject MonsterBossRoot
		{
			get
			{
				return this.mBossBarRoot;
			}
		}

		// Token: 0x1700198C RID: 6540
		// (get) Token: 0x06009E5A RID: 40538 RVA: 0x001F6C37 File Offset: 0x001F5037
		public GameObject Pvp3v3LeftHpBarRoot
		{
			get
			{
				return this.mBind.GetGameObject("pvp3v3TestHpLeftBarRoot");
			}
		}

		// Token: 0x1700198D RID: 6541
		// (get) Token: 0x06009E5B RID: 40539 RVA: 0x001F6C49 File Offset: 0x001F5049
		public GameObject Pvp3v3RightHpBarRoot
		{
			get
			{
				return this.mBind.GetGameObject("pvp3v3TestHpRightBarRoot");
			}
		}

		// Token: 0x06009E5C RID: 40540 RVA: 0x001F6C5B File Offset: 0x001F505B
		[UIEventHandle("tmpButton1")]
		private void TmpSetPosition()
		{
		}

		// Token: 0x06009E5D RID: 40541 RVA: 0x001F6C5D File Offset: 0x001F505D
		[UIEventHandle("tmpButton2")]
		private void TmpSetPosition2()
		{
		}

		// Token: 0x06009E5E RID: 40542 RVA: 0x001F6C60 File Offset: 0x001F5060
		private void InitWeaponChange()
		{
			if (this.mBtnChangeWeapon == null || Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer != null)
			{
				if (mainPlayer.playerActor == null)
				{
					return;
				}
				if (mainPlayer.playerActor.GetEntityData().CanChangeWeapon())
				{
					if (BattleMain.battleType == BattleType.PVP3V3Battle)
					{
						this.mBtnChangeWeapon.transform.parent.gameObject.CustomActive(mainPlayer.isFighting);
					}
					else
					{
						this.mBtnChangeWeapon.transform.parent.gameObject.CustomActive(true);
					}
					this.ChangeWeaponIcon(mainPlayer.playerActor.GetEntityData().GetBackupEquipItemID());
				}
			}
		}

		// Token: 0x06009E5F RID: 40543 RVA: 0x001F6D28 File Offset: 0x001F5128
		public void SetWeaponState(bool flag)
		{
			if (this.mBtnChangeWeapon == null || Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			this.SetSwitchEquipBtnState(flag);
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer != null)
			{
				if (mainPlayer.playerActor == null)
				{
					return;
				}
				if (flag)
				{
					if (mainPlayer.playerActor.GetEntityData().CanChangeWeapon())
					{
						if (BattleMain.battleType == BattleType.PVP3V3Battle)
						{
							this.mBtnChangeWeapon.transform.parent.gameObject.CustomActive(mainPlayer.isFighting);
						}
						else
						{
							this.mBtnChangeWeapon.transform.parent.gameObject.CustomActive(true);
						}
					}
				}
				else
				{
					this.mBtnChangeWeapon.transform.parent.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06009E60 RID: 40544 RVA: 0x001F6E08 File Offset: 0x001F5208
		public void ChangeWeaponIcon(int id)
		{
			if (this.mBtnChangeWeapon == null || id == 0)
			{
				return;
			}
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(id, true, true);
			if (itemByTableID == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.weaponBack, itemByTableID.GetQualityInfo().Background, true);
			ETCImageLoader.LoadSprite(ref this.weaponIcon, itemByTableID.Icon, true);
		}

		// Token: 0x06009E61 RID: 40545 RVA: 0x001F6E70 File Offset: 0x001F5270
		public void StartChangeWeaponCD(BeActor actor)
		{
			float switchWeaponTime = Global.Settings.switchWeaponTime;
			float num = 0f;
			Mechanism81 mechanism = actor.GetMechanism(5072) as Mechanism81;
			if (mechanism != null)
			{
				num = mechanism.changeWeaponCD.f;
			}
			Mechanism81 mechanism2 = actor.GetMechanism(158) as Mechanism81;
			if (mechanism2 != null)
			{
				num += mechanism2.changeWeaponCD.f;
			}
			if (mechanism != null && this.cdCoolDowm != null)
			{
				this.cdCoolDowm.StartCD(switchWeaponTime * (1f + num));
			}
			else
			{
				this.cdCoolDowm.StartCD(Global.Settings.switchWeaponTime);
			}
		}

		// Token: 0x06009E62 RID: 40546 RVA: 0x001F6F1C File Offset: 0x001F531C
		private void ChangeWeapon(int index)
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer != null && mainPlayer.playerActor != null)
			{
				this.StartChangeWeaponCD(mainPlayer.playerActor);
				ChangeWeaponCommand changeWeaponCommand = new ChangeWeaponCommand();
				changeWeaponCommand.weaponIndex = index;
				FrameSync.instance.FireFrameCommand(changeWeaponCommand, false);
			}
		}

		// Token: 0x06009E63 RID: 40547 RVA: 0x001F6F6F File Offset: 0x001F536F
		public void ResetChangeWeaponCD()
		{
			this.cdCoolDowm.ResetCD();
		}

		// Token: 0x06009E64 RID: 40548 RVA: 0x001F6F7C File Offset: 0x001F537C
		private void _TryInitTeamDuplicationVoiceTalk()
		{
			if (this.mVoiceTalkRoots != null)
			{
				GameObject talkRootByTalkType = this.mVoiceTalkRoots.GetTalkRootByTalkType(ComVoiceTalk.ComVoiceTalkType.TeamDuplicationMainBuild);
				if (talkRootByTalkType)
				{
					this.tdVoiceTalk = new TeamDuplicationVoiceTalk(talkRootByTalkType);
				}
			}
		}

		// Token: 0x06009E65 RID: 40549 RVA: 0x001F6FBE File Offset: 0x001F53BE
		private void _UnInitTeamDuplicationVoiceTalk()
		{
			if (this.tdVoiceTalk != null)
			{
				this.tdVoiceTalk.UnInit();
			}
		}

		// Token: 0x06009E66 RID: 40550 RVA: 0x001F6FD6 File Offset: 0x001F53D6
		[UIEventHandle("DungeonMap/CountRoot/realMircoBtn")]
		private void RealMircoBtn()
		{
			this.OnVoiceSDKMicClick();
		}

		// Token: 0x06009E67 RID: 40551 RVA: 0x001F6FDE File Offset: 0x001F53DE
		[UIEventHandle("DungeonMap/CountRoot/realPlayerBtn")]
		private void RealPlayerBtn()
		{
			this.OnVoiceSDKPlayerClick();
		}

		// Token: 0x06009E68 RID: 40552 RVA: 0x001F6FE6 File Offset: 0x001F53E6
		private void _TryInitVoiceTalkModule()
		{
			this.InitVoiceSDKBtns();
			if (!Singleton<PluginManager>.instance.OpenTalkRealVocie)
			{
				return;
			}
			this._TryInitTeamDuplicationVoiceTalk();
		}

		// Token: 0x06009E69 RID: 40553 RVA: 0x001F7004 File Offset: 0x001F5404
		private void TryInitVoiceChat(UIEvent uiEvent)
		{
			this.InitVoiceSDKBtns();
			if (!Singleton<PluginManager>.instance.OpenTalkRealVocie)
			{
				return;
			}
			this.InitVoiceModule();
		}

		// Token: 0x06009E6A RID: 40554 RVA: 0x001F7024 File Offset: 0x001F5424
		private void UnInitVoiceModule()
		{
			if (!Singleton<PluginManager>.instance.OpenTalkRealVocie)
			{
				return;
			}
			this._UnInitTeamDuplicationVoiceTalk();
			if (this._isVoiceOpenInTeam() || this._isVoiceOpenIn3v3())
			{
				Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
				Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
				Singleton<SDKVoiceManager>.GetInstance().RecoverGameVolumnInTalkVoice();
				Singleton<SDKVoiceManager>.GetInstance().LeaveAllChannel();
				Singleton<SDKVoiceManager>.GetInstance().RemoveRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
			}
		}

		// Token: 0x06009E6B RID: 40555 RVA: 0x001F70C0 File Offset: 0x001F54C0
		private void InitVoiceModule()
		{
			bool flag = this._isVoiceOpenInTeam();
			if (this.realMircoBtn)
			{
				this.realMircoBtn.CustomActive(flag);
			}
			if (this.realPlayerBtn)
			{
				this.realPlayerBtn.CustomActive(flag);
			}
			bool flag2 = this._isVoiceOpenIn3v3();
			if (this.mPvp3v3MicBtn != null)
			{
				this.mPvp3v3MicBtn.gameObject.CustomActive(flag2);
			}
			if (this.mPvp3v3PlayerBtn != null)
			{
				this.mPvp3v3PlayerBtn.gameObject.CustomActive(flag2);
			}
			if (!flag && !flag2)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().AddRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
			string text = this.TryGetVoiceSDKChannalId();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().JoinChannel(text, DataManager<PlayerBaseData>.GetInstance().RoleID + string.Empty, ClientApplication.playerinfo.openuid + string.Empty, ClientApplication.playerinfo.token + string.Empty);
		}

		// Token: 0x06009E6C RID: 40556 RVA: 0x001F71FC File Offset: 0x001F55FC
		private bool _isVoiceOpenInTeam()
		{
			bool flag = this._isTeamAllPlayerMoreThanOne();
			bool flag2 = BattleMain.IsTeamMode(BattleMain.battleType, BattleMain.mode) && !BattleMain.IsModeTeamDuplication(BattleMain.battleType);
			return (Singleton<PluginManager>.GetInstance().OpenTalkRealInTeam || !flag2) && flag2 && flag;
		}

		// Token: 0x06009E6D RID: 40557 RVA: 0x001F7258 File Offset: 0x001F5658
		private bool _isTeamAllPlayerMoreThanOne()
		{
			return BattleMain.instance != null && BattleMain.instance.GetPlayerManager() != null && BattleMain.instance.GetPlayerManager().GetAllPlayers() != null && BattleMain.instance.GetPlayerManager().GetAllPlayers().Count > 1;
		}

		// Token: 0x06009E6E RID: 40558 RVA: 0x001F72B0 File Offset: 0x001F56B0
		private bool _isVoiceOpenIn3v3()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return false;
			}
			if (BattleMain.instance.GetPlayerManager() == null)
			{
				return false;
			}
			bool flag = BattleMain.instance.GetPlayerManager().GetMainPlayerTeamPlayerCount() > 1;
			bool flag2 = BattleMain.IsModePVP3V3(BattleMain.battleType);
			return (Singleton<PluginManager>.GetInstance().OpenTalkRealIn3v3Pvp || !flag2) && flag && flag2;
		}

		// Token: 0x06009E6F RID: 40559 RVA: 0x001F732C File Offset: 0x001F572C
		private void InitVoiceSDKBtns()
		{
			if (this.realMircoBtn)
			{
				this.realMircoBtn.CustomActive(false);
			}
			if (this.realPlayerBtn)
			{
				this.realPlayerBtn.CustomActive(false);
			}
			if (this.mPvp3v3MicBtn != null)
			{
				this.mPvp3v3MicBtn.gameObject.CustomActive(false);
			}
			if (this.mPvp3v3PlayerBtn != null)
			{
				this.mPvp3v3PlayerBtn.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06009E70 RID: 40560 RVA: 0x001F73B8 File Offset: 0x001F57B8
		private string TryGetVoiceSDKChannalId()
		{
			uint num = 0U;
			if (BattleMain.IsModePVP3V3(BattleMain.battleType))
			{
				if (BattleMain.instance != null)
				{
					num = (uint)BattleMain.instance.GetPlayerManager().GetMainPlayer().teamType;
				}
				else
				{
					Logger.LogError("null == BattleMain.instance!!!!");
				}
			}
			ulong num2 = ClientApplication.playerinfo.session * 10UL + (ulong)num;
			return num2 + string.Empty;
		}

		// Token: 0x06009E71 RID: 40561 RVA: 0x001F7426 File Offset: 0x001F5826
		private void OnJoinChannelSucc()
		{
			Singleton<SDKVoiceManager>.GetInstance().ResetRealTalkVoiceParams();
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().OpenRealPlayer();
		}

		// Token: 0x06009E72 RID: 40562 RVA: 0x001F7446 File Offset: 0x001F5846
		private void OnVoiceSDKMicClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVoiceMic();
		}

		// Token: 0x06009E73 RID: 40563 RVA: 0x001F7472 File Offset: 0x001F5872
		private void OnVoiceSDKPlayerClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVociePlayer();
		}

		// Token: 0x06009E74 RID: 40564 RVA: 0x001F749E File Offset: 0x001F589E
		private void OnVoiceSDKMicOn(bool isOn)
		{
			this.ChangeMicBtnStatus(isOn);
			if (isOn)
			{
				Singleton<SDKVoiceManager>.GetInstance().CutGameVolumnInTalkVoice();
			}
		}

		// Token: 0x06009E75 RID: 40565 RVA: 0x001F74B7 File Offset: 0x001F58B7
		private void OnVoiceSDKPlayerOn(bool isOn)
		{
			this.ChangePlayerBtnStatus(isOn);
		}

		// Token: 0x06009E76 RID: 40566 RVA: 0x001F74C0 File Offset: 0x001F58C0
		private void ChangeMicBtnStatus(bool isMicOn)
		{
			if (this.onOffImage != null)
			{
				this.onOffImage.gameObject.CustomActive(!isMicOn);
			}
			if (BattleMain.IsModePVP3V3(BattleMain.battleType))
			{
				if (this.mPvp3v3MicBtnClose != null)
				{
					this.mPvp3v3MicBtnClose.gameObject.CustomActive(!isMicOn);
				}
				if (this.mPvp3v3MicBtnBg != null)
				{
					this.mPvp3v3MicBtnBg.enabled = isMicOn;
				}
			}
		}

		// Token: 0x06009E77 RID: 40567 RVA: 0x001F7544 File Offset: 0x001F5944
		private void ChangePlayerBtnStatus(bool isPlayerOpen)
		{
			if (this.openCloseImage != null)
			{
				this.openCloseImage.gameObject.CustomActive(!isPlayerOpen);
			}
			if (BattleMain.IsModePVP3V3(BattleMain.battleType))
			{
				if (this.mPvp3v3PlayerBtnClose != null)
				{
					this.mPvp3v3PlayerBtnClose.gameObject.CustomActive(!isPlayerOpen);
				}
				if (this.mPvp3v3PlayerBtnBg != null)
				{
					this.mPvp3v3PlayerBtnBg.enabled = isPlayerOpen;
				}
			}
		}

		// Token: 0x06009E78 RID: 40568 RVA: 0x001F75C8 File Offset: 0x001F59C8
		private void InitTeamChatVoice()
		{
			this.SetVoiceInputBtnShow(false);
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			if (!this.IsInTeamMode())
			{
				return;
			}
			this.SetVoiceInputBtnShow(true);
			this.voiceChatModule = Singleton<SDKVoiceManager>.GetInstance().VoiceChatModule;
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.BindRoot(this.mTeamVoiceBtnGo, VoiceInputType.ComtalkTeam, null);
			}
			if (this.mTeamVoiceBtnGo != null)
			{
				Singleton<ComIntervalGroup>.GetInstance().Register(this, 5, Utility.FindComponent<ComFunctionInterval>(this.mTeamVoiceBtnGo, "VoiceSend", true));
			}
		}

		// Token: 0x06009E79 RID: 40569 RVA: 0x001F765C File Offset: 0x001F5A5C
		private void UnInitTeamChatVoice()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			if (!this.IsInTeamMode())
			{
				return;
			}
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.UnBindRoot(VoiceInputType.ComtalkTeam, this.mTeamVoiceBtn);
			}
			Singleton<ComIntervalGroup>.GetInstance().UnRegister(this);
		}

		// Token: 0x06009E7A RID: 40570 RVA: 0x001F76AD File Offset: 0x001F5AAD
		private void SetVoiceInputBtnShow(bool isShow)
		{
			if (this.mTeamVoiceBtnGo)
			{
				this.mTeamVoiceBtnGo.CustomActive(isShow);
			}
			if (this.mTeamVoiceBtn)
			{
				this.mTeamVoiceBtn.gameObject.CustomActive(isShow);
			}
		}

		// Token: 0x06009E7B RID: 40571 RVA: 0x001F76EC File Offset: 0x001F5AEC
		private bool IsInTeamMode()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			if (BattleMain.instance.GetPlayerManager() == null || BattleMain.instance.GetPlayerManager().GetAllPlayers() == null)
			{
				return false;
			}
			bool flag = BattleMain.instance.GetPlayerManager().GetAllPlayers().Count > 1;
			bool flag2 = BattleMain.IsTeamMode(BattleMain.battleType, BattleMain.mode);
			bool flag3 = BattleMain.IsModePVP3V3(BattleMain.battleType);
			return !flag3 && flag2 && flag;
		}

		// Token: 0x06009E7C RID: 40572 RVA: 0x001F7770 File Offset: 0x001F5B70
		public void ShowLevelTip(int tip)
		{
			this.CloseLevelTip();
			MonsterSpeech tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(tip, string.Empty, string.Empty);
			if (tableItem != null)
			{
				NewbieGuideBattleTipsFrame newbieGuideBattleTipsFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<NewbieGuideBattleTipsFrame>(FrameLayer.Top, null, string.Empty) as NewbieGuideBattleTipsFrame;
				newbieGuideBattleTipsFrame.SetTipsText(tableItem.Speech);
			}
		}

		// Token: 0x06009E7D RID: 40573 RVA: 0x001F77C2 File Offset: 0x001F5BC2
		public void CloseLevelTip()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<NewbieGuideBattleTipsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<NewbieGuideBattleTipsFrame>(null, false);
			}
		}

		// Token: 0x06009E7E RID: 40574 RVA: 0x001F77E0 File Offset: 0x001F5BE0
		public void ShowDigit(bool flag)
		{
			if (this.m_countScirpt != null)
			{
				this.m_countScirpt.Show(flag);
			}
		}

		// Token: 0x06009E7F RID: 40575 RVA: 0x001F77FF File Offset: 0x001F5BFF
		public void SetCountDigit(int second)
		{
			if (this.m_countScirpt != null)
			{
				this.m_countScirpt.SetMTimeImage(second);
			}
		}

		// Token: 0x06009E80 RID: 40576 RVA: 0x001F7820 File Offset: 0x001F5C20
		public void SetAutoFightVisible(bool flag)
		{
			if (this.autoFightEffect != null)
			{
				if (flag && this.autoFight != null && this.autoFight.isOn)
				{
					this.autoFightEffect.CustomActive(flag);
				}
				else
				{
					this.autoFightEffect.CustomActive(flag);
				}
			}
		}

		// Token: 0x06009E81 RID: 40577 RVA: 0x001F7884 File Offset: 0x001F5C84
		public void SetAutoFight(bool auto)
		{
			if (BattleMain.instance != null)
			{
				BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
				if (mainPlayer != null && mainPlayer.playerActor != null)
				{
					AutoFightCommand cmd = new AutoFightCommand
					{
						openAutoFight = auto,
						seat = mainPlayer.playerInfo.seat
					};
					FrameSync.instance.FireFrameCommand(cmd, false);
				}
			}
		}

		// Token: 0x06009E82 RID: 40578 RVA: 0x001F78E8 File Offset: 0x001F5CE8
		public void LoadAutoFightConfig()
		{
			if (!Global.Settings.forceUseAutoFight && !SwitchFunctionUtility.IsOpen(12) && BattleMain.IsModeMultiplayer(BattleMain.mode))
			{
				return;
			}
			if (this.autoFight != null)
			{
				object value = PlayerLocalSetting.GetValue("AutoFight");
				if (value != null)
				{
					this.autoFight.isOn = (bool)value;
					if (this.autoFight.isOn)
					{
						Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(10, delegate
						{
							this.SetAutoFight(false);
							this.StartCheckRestoreAutoFight();
						}, 0, 0, false);
					}
					else
					{
						this.SetAutoFight(false);
					}
				}
			}
		}

		// Token: 0x06009E83 RID: 40579 RVA: 0x001F7990 File Offset: 0x001F5D90
		public void SaveAutoFightConfig(bool flag)
		{
			if (this.autoFight != null)
			{
				PlayerLocalSetting.SetValue("AutoFight", flag);
				PlayerLocalSetting.SaveConfig();
			}
		}

		// Token: 0x06009E84 RID: 40580 RVA: 0x001F79B8 File Offset: 0x001F5DB8
		public bool CanLevelOpenAutoFight()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.AutoFight);
		}

		// Token: 0x06009E85 RID: 40581 RVA: 0x001F79C4 File Offset: 0x001F5DC4
		public bool CanOpenAutoFight()
		{
			if (Global.Settings.forceUseAutoFight)
			{
				return true;
			}
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				return true;
			}
			if (!this.CanLevelOpenAutoFight())
			{
				return false;
			}
			if (!Global.Settings.canUseAutoFightFirstPass)
			{
				return true;
			}
			if (BattleMain.battleType == BattleType.Hell)
			{
				return ChapterUtility.HellIsPass(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId);
			}
			return ChapterUtility.GetDungeonState(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId) == ComChapterDungeonUnit.eState.Passed;
		}

		// Token: 0x06009E86 RID: 40582 RVA: 0x001F7A4C File Offset: 0x001F5E4C
		public bool CanShowOpenAutoFight()
		{
			return Global.Settings.startSystem == EClientSystem.Battle || Global.Settings.forceUseAutoFight || (Singleton<NewbieGuideManager>.GetInstance().GetNextGuide(NewbieGuideTable.eNewbieGuideType.NGT_WEAK) != NewbieGuideTable.eNewbieGuideTask.AutoFightGuide && Global.Settings.canUseAutoFight && ChapterUtility.CanDungeonOpenAutoFight(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId));
		}

		// Token: 0x06009E87 RID: 40583 RVA: 0x001F7AB8 File Offset: 0x001F5EB8
		public void InitAutoFight()
		{
			if (!this.CanShowOpenAutoFight())
			{
				return;
			}
			if (!this.CanOpenAutoFight())
			{
				if (this.autoFight != null)
				{
					this.autoFight.gameObject.CustomActive(true);
					this.autoFight.gameObject.SafeAddComponent(true);
					this.autoFight.onValueChanged.AddListener(delegate(bool choose)
					{
						string msgContent = string.Empty;
						if (!this.CanLevelOpenAutoFight())
						{
							msgContent = string.Format("{0}级开启自动战斗", Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.AutoFight));
						}
						else
						{
							msgContent = string.Format("首次通关后开启自动战斗", new object[0]);
						}
						SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
				}
				return;
			}
			if (this.autoFight != null)
			{
				this.StopCheckRestoreAutoFight();
				this.autoFight.gameObject.CustomActive(true);
				this.autoFight.onValueChanged.AddListener(delegate(bool choose)
				{
					this.StopCheckRestoreAutoFight();
					this.SetAutoFight(choose);
					if (choose)
					{
						if (this.autoFightEffect == null)
						{
							string prefabFullPath = "Effects/Scene_effects/EffectUI/EffUI_Autofight";
							this.autoFightEffect = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.UIPrefab, 0U);
							Utility.AttachTo(this.autoFightEffect, this.autoFight.gameObject, false);
						}
					}
					else
					{
						this.DeinitAutoFight();
					}
					this.SaveAutoFightConfig(choose);
				});
				if (Global.Settings.loadAutoFight)
				{
					this.LoadAutoFightConfig();
				}
				BeActor player = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
				if (player != null)
				{
					player.RegisterEvent(BeEventType.onMoveJoystick, delegate(object[] args)
					{
						if (this.autoFight.isOn)
						{
							this.SetAutoFight(false);
						}
					});
					player.RegisterEvent(BeEventType.onStopMoveJoystick, delegate(object[] args)
					{
						if (this.autoFight.isOn)
						{
							this.StartCheckRestoreAutoFight();
						}
					});
					player.RegisterEvent(BeEventType.onPassedDoor, delegate(object[] args)
					{
						if (this.autoFight.isOn)
						{
							this.StartCheckRestoreAutoFight();
						}
					});
					player.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
					{
						if ((ActionState)args[0] == ActionState.AS_IDLE && !player.IsInMoveDirection() && this.autoFight.isOn && player.pauseAI)
						{
							this.StartCheckRestoreAutoFight();
						}
					});
				}
			}
		}

		// Token: 0x06009E88 RID: 40584 RVA: 0x001F7C1F File Offset: 0x001F601F
		public void DeinitAutoFight()
		{
			if (this.autoFight != null && this.autoFightEffect != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.autoFightEffect);
				this.autoFightEffect = null;
			}
		}

		// Token: 0x06009E89 RID: 40585 RVA: 0x001F7C5A File Offset: 0x001F605A
		public void StartCheckRestoreAutoFight()
		{
			this.checkRestoreAutoFight = true;
			this.autoFightAcc = 0;
		}

		// Token: 0x06009E8A RID: 40586 RVA: 0x001F7C6A File Offset: 0x001F606A
		public void StopCheckRestoreAutoFight()
		{
			if (!this.checkRestoreAutoFight)
			{
				return;
			}
			this.checkRestoreAutoFight = false;
		}

		// Token: 0x06009E8B RID: 40587 RVA: 0x001F7C80 File Offset: 0x001F6080
		public void UpdateCheckRestoreAutoFight(int delta)
		{
			if (this.checkRestoreAutoFight)
			{
				this.autoFightAcc += delta;
				if (this.autoFightAcc >= this.AUTOFIGHT_RESTORE_INTERVAL)
				{
					this.StopCheckRestoreAutoFight();
					if (null == this.autoFight)
					{
						return;
					}
					BattlePlayer battlePlayer = null;
					if (BattleMain.instance != null)
					{
						battlePlayer = BattleMain.instance.GetLocalPlayer(0UL);
					}
					if (battlePlayer == null || battlePlayer.playerActor == null)
					{
						return;
					}
					if (this.autoFight.isOn && !battlePlayer.playerActor.IsInMoveDirection())
					{
						this.SetAutoFight(true);
					}
				}
			}
		}

		// Token: 0x06009E8C RID: 40588 RVA: 0x001F7D24 File Offset: 0x001F6124
		public void InitForTrain()
		{
			this.canTrainReset = true;
			if (this.goTrain != null)
			{
				this.goTrain.CustomActive(true);
			}
			ClientSystemBattle.StartTimer(0);
			if (this.btnTrainReturn != null)
			{
				this.btnTrainReturn.onClick.AddListener(delegate()
				{
					BeUtility.ResetCamera();
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				});
			}
			if (this.btnTrainReset != null)
			{
				this.btnTrainReset.onClick.AddListener(delegate()
				{
					TrainingBatte2 trainingBatte = BattleMain.instance.GetBattle() as TrainingBatte2;
					if (trainingBatte != null)
					{
						if (!this.canTrainReset)
						{
							return;
						}
						if (BattleMain.instance.GetPlayerManager() == null)
						{
							return;
						}
						BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
						if (mainPlayer != null)
						{
							BeActor playerActor = mainPlayer.playerActor;
							BeSkill currentSkill = playerActor.GetCurrentSkill();
							if (currentSkill != null)
							{
								currentSkill.joystickMode = SkillJoystickMode.FREE;
								currentSkill.RemoveJoystickEffect();
								currentSkill.EndJoystick();
								currentSkill.Cancel();
							}
						}
						this.canTrainReset = false;
						trainingBatte.RecreatePlayers();
						if (ClientSystemBattle.mTimerController != null)
						{
							ClientSystemBattle.mTimerController.Reset();
						}
						UIGray gray = this.btnTrainReset.GetComponent<UIGray>();
						if (gray != null)
						{
							gray.enabled = true;
						}
						Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(5000, delegate
						{
							this.canTrainReset = true;
							if (this.btnTrainReset == null)
							{
								return;
							}
							this.btnTrainReset.enabled = true;
							if (gray != null)
							{
								gray.enabled = false;
							}
						}, 0, 0, false);
						BeUtility.ResetCamera();
						this.ResetCombo();
					}
					MonoSingleton<AudioManager>.instance.StopAll(AudioType.AudioEffect);
				});
			}
		}

		// Token: 0x06009E8D RID: 40589 RVA: 0x001F7DC6 File Offset: 0x001F61C6
		protected void ResetCombo()
		{
			if (this.Combo != null)
			{
				this.Combo.StopFeed();
			}
		}

		// Token: 0x06009E8E RID: 40590 RVA: 0x001F7DE4 File Offset: 0x001F61E4
		public void InitForReplay()
		{
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				return;
			}
			if (this.goReplay != null)
			{
				this.goReplay.CustomActive(true);
			}
			if (this.btnReplayReturn != null)
			{
				this.btnReplayReturn.onClick.AddListener(delegate()
				{
					if (Singleton<ReplayServer>.GetInstance().IsLiveShow() && MonoSingleton<NetManager>.instance != null)
					{
						MonoSingleton<NetManager>.instance.Disconnect(ServerType.RELAY_SERVER);
					}
					Singleton<ReplayServer>.GetInstance().Stop(false, "InitForReplay");
					Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				});
			}
			if (this.btnReplaySpeed != null)
			{
				if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
				{
					this.txtSpeedDesc.text = "同步进度";
				}
				else
				{
					this.txtSpeedDesc.text = string.Format("速度×{0}", Singleton<ReplayServer>.GetInstance().timeScaler);
				}
				this.btnReplaySpeed.onClick.AddListener(delegate()
				{
					if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
					{
						Singleton<ReplayServer>.GetInstance().StartPersue();
						this.btnReplaySpeed.gameObject.SetActive(false);
					}
					else
					{
						Singleton<ReplayServer>.GetInstance().ScaleTime();
						this.txtSpeedDesc.text = string.Format("速度×{0}", Singleton<ReplayServer>.GetInstance().timeScaler);
					}
				});
			}
			if (this.btnReplayResume != null && this.btnReplayPause != null)
			{
				if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
				{
					this.btnReplayResume.gameObject.CustomActive(false);
					this.btnReplayPause.gameObject.CustomActive(false);
				}
				else
				{
					this.btnReplayPause.gameObject.CustomActive(true);
				}
				this.btnReplayPause.onClick.AddListener(delegate()
				{
					this.btnReplayResume.gameObject.CustomActive(true);
					this.btnReplayPause.gameObject.CustomActive(false);
					Singleton<ReplayServer>.GetInstance().Pause();
				});
				this.btnReplayResume.onClick.AddListener(delegate()
				{
					this.btnReplayResume.gameObject.CustomActive(false);
					this.btnReplayPause.gameObject.CustomActive(true);
					Singleton<ReplayServer>.GetInstance().Resume();
				});
				this.btnReplayResume.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06009E8F RID: 40591 RVA: 0x001F7F83 File Offset: 0x001F6383
		public void SetReplayVisible(bool flag)
		{
			if (this.goReplay != null)
			{
				this.goReplay.CustomActive(flag);
			}
		}

		// Token: 0x06009E90 RID: 40592 RVA: 0x001F7FA2 File Offset: 0x001F63A2
		public void HideTextRoot()
		{
			if (this.goTextRoot != null)
			{
				this.goTextRoot.CustomActive(false);
			}
		}

		// Token: 0x06009E91 RID: 40593 RVA: 0x001F7FC4 File Offset: 0x001F63C4
		public void HideTimeAndScore()
		{
			if (this.mDungeonScore != null)
			{
				this.mDungeonScore.CustomActive(false);
			}
			this._hiddenTimer();
			if (this.mFightingTimeRoot != null)
			{
				this.mFightingTimeRoot.CustomActive(false);
			}
		}

		// Token: 0x06009E92 RID: 40594 RVA: 0x001F8014 File Offset: 0x001F6414
		public void InitForDeadTower()
		{
			if (this.goTextRoot != null)
			{
				this.goTextRoot.CustomActive(false);
			}
			if (this.textDeadTowerLevel != null)
			{
				this.textDeadTowerLevel.transform.parent.gameObject.SetActive(true);
			}
		}

		// Token: 0x06009E93 RID: 40595 RVA: 0x001F806A File Offset: 0x001F646A
		public void SetFloor(int floor)
		{
			if (this.textDeadTowerLevel != null)
			{
				this.textDeadTowerLevel.text = floor.ToString();
			}
		}

		// Token: 0x06009E94 RID: 40596 RVA: 0x001F8098 File Offset: 0x001F6498
		public void InitForChampionMatch()
		{
			if (this.goTextRoot != null)
			{
				this.goTextRoot.CustomActive(false);
			}
			if (this.textChampionMatch != null)
			{
				this.textChampionMatch.transform.parent.gameObject.SetActive(true);
			}
		}

		// Token: 0x06009E95 RID: 40597 RVA: 0x001F80EE File Offset: 0x001F64EE
		public void SetChampionMatchName(string name)
		{
			if (this.textChampionMatch != null)
			{
				this.textChampionMatch.text = name;
			}
		}

		// Token: 0x06009E96 RID: 40598 RVA: 0x001F810D File Offset: 0x001F650D
		public void SetMuscleShiftActive(bool flag)
		{
			if (this.textMuscleShift != null)
			{
				this.textMuscleShift.transform.parent.gameObject.SetActive(flag);
			}
		}

		// Token: 0x06009E97 RID: 40599 RVA: 0x001F813C File Offset: 0x001F653C
		public void SetMuscleShiftCount(int count)
		{
			if (this.textMuscleShift != null)
			{
				this.textMuscleShift.text = string.Format("X{0}", count);
			}
			if (this.iconMuscleShift != null && this.muscleShiftGray == null)
			{
				this.muscleShiftGray = this.iconMuscleShift.GetComponent<UIGray>();
			}
			if (this.muscleShiftGray != null)
			{
				this.muscleShiftGray.enabled = (count <= 0);
			}
		}

		// Token: 0x06009E98 RID: 40600 RVA: 0x001F81CB File Offset: 0x001F65CB
		public void SetMuscleShiftCD(float per)
		{
			if (this.imageMuscleShift != null)
			{
				this.imageMuscleShift.fillAmount = per;
			}
		}

		// Token: 0x06009E99 RID: 40601 RVA: 0x001F81EA File Offset: 0x001F65EA
		public sealed override string GetMainUIPrefabName()
		{
			return "UIFlatten/Prefabs/BattleUI/ClientSystemBattleMain";
		}

		// Token: 0x06009E9A RID: 40602 RVA: 0x001F81F1 File Offset: 0x001F65F1
		protected sealed override void _OnMainFrameOpen()
		{
		}

		// Token: 0x06009E9B RID: 40603 RVA: 0x001F81F3 File Offset: 0x001F65F3
		protected sealed override void _OnMainFrameBeforeSetActive(bool active)
		{
			if (!active && this.tdVoiceTalk != null)
			{
				this.tdVoiceTalk.HideVoiceTalk();
			}
		}

		// Token: 0x06009E9C RID: 40604 RVA: 0x001F8214 File Offset: 0x001F6614
		private void OpenVanityBuffBonusFrame()
		{
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsYiJieCheckPoint() && DataManager<ActivityManager>.GetInstance().GetVanityBonusActivityIsShow())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<VanityBuffBonusFrame>(FrameLayer.High, DataManager<ActivityManager>.GetInstance().GetVanityBuffBonusModel(), string.Empty);
			}
		}

		// Token: 0x06009E9D RID: 40605 RVA: 0x001F8264 File Offset: 0x001F6664
		private void OpenChaosAdditionFrame()
		{
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsHunDunCheckPoint() && DataManager<ActivityManager>.GetInstance().GetChaosAdditionActivityIsShow())
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<VanityBuffBonusFrame>(FrameLayer.High, DataManager<ActivityManager>.GetInstance().GetVanityBuffBonusModel(), string.Empty);
			}
		}

		// Token: 0x06009E9E RID: 40606 RVA: 0x001F82B4 File Offset: 0x001F66B4
		[UIEventHandle("DungeonMap/CountRoot/Button")]
		private void OnPauseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<PauseFrame>(FrameLayer.Middle, null, string.Empty);
			if (!BattleMain.IsModeMultiplayer(BattleMain.mode))
			{
				BattleMain.instance.GetDungeonManager().PauseFight(true, string.Empty, false);
			}
		}

		// Token: 0x06009E9F RID: 40607 RVA: 0x001F82ED File Offset: 0x001F66ED
		protected sealed override string _GetLevelName()
		{
			return "DnH";
		}

		// Token: 0x06009EA0 RID: 40608 RVA: 0x001F82F4 File Offset: 0x001F66F4
		public void HidePauseButton(bool hide = true)
		{
			if (this.mbuttonObject != null)
			{
				this.mbuttonObject.SetActive(!hide);
			}
		}

		// Token: 0x06009EA1 RID: 40609 RVA: 0x001F8318 File Offset: 0x001F6718
		private void _updateExpBar(bool force)
		{
			if (!force)
			{
				int num = (int)(DataManager<PlayerBaseData>.GetInstance().Exp - this.previousExp);
				this.previousExp = DataManager<PlayerBaseData>.GetInstance().Exp;
				BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
				if (mainPlayer != null)
				{
					BeActor playerActor = mainPlayer.playerActor;
					if (playerActor != null && playerActor.isLocalActor && playerActor.m_pkGeActor != null && num > 0)
					{
						playerActor.m_pkGeActor.CreateHeadText(HitTextType.GET_EXP, num, false, null);
					}
				}
			}
			if (this.mExpBar != null)
			{
				this.mExpBar.SetExp(DataManager<PlayerBaseData>.GetInstance().Exp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			}
		}

		// Token: 0x06009EA2 RID: 40610 RVA: 0x001F83E7 File Offset: 0x001F67E7
		private void _setExpBarVisible(bool visible)
		{
			if (!this.mExpBar.IsNull())
			{
				this.mExpBar.gameObject.SetActive(visible);
			}
		}

		// Token: 0x1700198E RID: 6542
		// (get) Token: 0x06009EA3 RID: 40611 RVA: 0x001F840A File Offset: 0x001F680A
		public ComDungeonMap dungeonMapCom
		{
			get
			{
				return this.mDungeonMapCom;
			}
		}

		// Token: 0x1700198F RID: 6543
		// (get) Token: 0x06009EA4 RID: 40612 RVA: 0x001F8412 File Offset: 0x001F6812
		public ComboCount Combo
		{
			get
			{
				return this.comboCountComp;
			}
		}

		// Token: 0x06009EA5 RID: 40613 RVA: 0x001F841C File Offset: 0x001F681C
		private void _unloadMapUI()
		{
			if (this.mDungeonScore != null)
			{
				Object.Destroy(this.mDungeonScore.gameObject);
				this.mDungeonScore = null;
			}
			if (this.mDungeonMapCom != null)
			{
				Object.Destroy(this.mDungeonMapCom.gameObject);
				this.mDungeonMapCom = null;
			}
			if (this.mFightingTimeRoot != null)
			{
				Object.Destroy(this.mFightingTimeRoot.gameObject);
				this.mFightingTimeRoot = null;
			}
		}

		// Token: 0x06009EA6 RID: 40614 RVA: 0x001F84A4 File Offset: 0x001F68A4
		private void _loadComboUI()
		{
			if (this.objCanvasComboText == null)
			{
				this.objCanvasComboText = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/ComboText", true, 0U);
				Utility.AttachTo(this.objCanvasComboText, Singleton<ClientSystemManager>.instance.BottomLayer, false);
				this.comboCountComp = this.objCanvasComboText.GetComponent<ComboCount>();
			}
		}

		// Token: 0x06009EA7 RID: 40615 RVA: 0x001F8500 File Offset: 0x001F6900
		private void _unloadComboUI()
		{
			if (this.objCanvasComboText != null)
			{
				Object.Destroy(this.objCanvasComboText);
				this.objCanvasComboText = null;
			}
			this.comboCountComp = null;
		}

		// Token: 0x06009EA8 RID: 40616 RVA: 0x001F852C File Offset: 0x001F692C
		public void ShowFlashWhite()
		{
			if (this.objFlashWhite != null)
			{
				Object.Destroy(this.objFlashWhite);
				this.objFlashWhite = null;
			}
			if (this.objFlashWhite == null)
			{
				this.objFlashWhite = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Common/Common_flashWhite", true, 0U);
				Utility.AttachTo(this.objFlashWhite, this._mainFrame, false);
			}
		}

		// Token: 0x06009EA9 RID: 40617 RVA: 0x001F8598 File Offset: 0x001F6998
		private void _DisplayArraw(GameObject go, bool isShow, bool useActive = false)
		{
			if (useActive)
			{
				go.SetActive(isShow);
			}
			else
			{
				if (!go.activeSelf)
				{
					go.SetActive(true);
				}
				RectTransform rectTransform = go.transform as RectTransform;
				rectTransform.localScale = ((!isShow) ? new Vector3(0.01f, 0.01f, 0.01f) : new Vector3(0.8f, 0.8f, 0.8f));
			}
		}

		// Token: 0x06009EAA RID: 40618 RVA: 0x001F8610 File Offset: 0x001F6A10
		public void ShowArrow(bool show = true, float angle = 0f, bool right = true, bool withGo = false)
		{
			if (this.mArrowLeft != null)
			{
				if (withGo)
				{
					this._DisplayArraw(this.mArrowLeftGo, show, false);
					this._DisplayArraw(this.mArrowRightGo, show, false);
				}
				else
				{
					this._DisplayArraw(this.mArrowLeft, show, false);
					this._DisplayArraw(this.mArrowRight, show, false);
				}
				if (show)
				{
					RectTransform rectTransform;
					if (right)
					{
						rectTransform = (this.mArrowRight.transform.transform as RectTransform);
						if (withGo)
						{
							this._DisplayArraw(this.mArrowLeftGo, false, false);
						}
						else
						{
							this._DisplayArraw(this.mArrowLeft, false, false);
						}
					}
					else
					{
						rectTransform = (this.mArrowLeft.transform.transform as RectTransform);
						if (withGo)
						{
							this._DisplayArraw(this.mArrowRightGo, false, false);
						}
						else
						{
							this._DisplayArraw(this.mArrowRight, false, false);
						}
					}
					float num = Mathf.Clamp(angle + 0.17f, 0f, 1f);
					if (right)
					{
						rectTransform.anchorMin = new Vector2(1f, num);
						rectTransform.anchorMax = new Vector2(1f, num);
					}
					else
					{
						rectTransform.anchorMin = new Vector2(0f, num);
						rectTransform.anchorMax = new Vector2(0f, num);
					}
				}
			}
		}

		// Token: 0x06009EAB RID: 40619 RVA: 0x001F8768 File Offset: 0x001F6B68
		private void _loadDebugUI()
		{
			if (this.goDebug == null)
			{
				this.goDebug = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Common/UIInput", true, 0U);
				RectTransform component = this.goDebug.GetComponent<RectTransform>();
				Utility.AttachTo(this.goDebug, Singleton<ClientSystemManager>.instance.BottomLayer, true);
				if (component != null)
				{
					component.SetAsFirstSibling();
				}
			}
		}

		// Token: 0x06009EAC RID: 40620 RVA: 0x001F87D1 File Offset: 0x001F6BD1
		private void _unloadDebugUI()
		{
			if (this.goDebug != null)
			{
				Object.Destroy(this.goDebug);
				this.goDebug = null;
			}
		}

		// Token: 0x06009EAD RID: 40621 RVA: 0x001F87F6 File Offset: 0x001F6BF6
		public void ShowDeadTips(bool isShow)
		{
			if (null != this.mDeadTips)
			{
				this.mDeadTips.CustomActive(isShow);
			}
		}

		// Token: 0x06009EAE RID: 40622 RVA: 0x001F8818 File Offset: 0x001F6C18
		private void _updatePrechangeJobSkillButton()
		{
			if (BattleMain.battleType == BattleType.NewbieGuide)
			{
				return;
			}
			bool bActive = DataManager<PlayerBaseData>.GetInstance().Level > 1;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				if (DataManager<PlayerBaseData>.GetInstance().Level < 15)
				{
					Logger.LogErrorFormat("预先转职职业 {0}", new object[]
					{
						DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID
					});
				}
				return;
			}
			if (InputManager.instance == null)
			{
				Logger.LogErrorFormat("预先转职职业 按钮为空空", new object[0]);
				return;
			}
			ETCButton etcbutton = InputManager.instance.GetETCButton(tableItem.ProJobSkills);
			if (null != etcbutton)
			{
				etcbutton.gameObject.CustomActive(bActive);
			}
		}

		// Token: 0x06009EAF RID: 40623 RVA: 0x001F88DC File Offset: 0x001F6CDC
		private bool _needComboUI()
		{
			if (BattleMain.instance == null)
			{
				return true;
			}
			BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
			return baseBattle == null || baseBattle.dungeonManager == null || baseBattle.dungeonManager.GetDungeonDataManager() == null || baseBattle.dungeonManager.GetDungeonDataManager().table == null || baseBattle.dungeonManager.GetDungeonDataManager().table.ThreeType != DungeonTable.eThreeType.T_RACECAR;
		}

		// Token: 0x06009EB0 RID: 40624 RVA: 0x001F895C File Offset: 0x001F6D5C
		private void _loadBattleUI()
		{
			MonoSingleton<GameFrameWork>.instance.SwithTouchInput(true);
			if (this._needComboUI())
			{
				this._loadComboUI();
			}
			this._loadDebugUI();
			this.ShowDeadTips(false);
			if (Global.Settings.showBattleInfoPanel)
			{
				this.comDebugBattleStatis._loadBattleStatisticsUI();
			}
			if (this.mArrowLeft != null)
			{
				this.mArrowLeft.SetActive(false);
				this.mArrowRight.SetActive(false);
			}
			if (this.mBlindMask != null)
			{
				this.SetBlindMask(false);
			}
			this.previousExp = DataManager<PlayerBaseData>.GetInstance().Exp;
			this.previousLevel = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			this._CheckRedPacketFrame();
			if (this.m_countScirpt != null)
			{
				this.m_countScirpt.StopCount();
			}
		}

		// Token: 0x06009EB1 RID: 40625 RVA: 0x001F8A2F File Offset: 0x001F6E2F
		public void SetBlindMask(bool visible)
		{
			if (this.mBlindMask == null)
			{
				return;
			}
			if (this.mBlindMask.activeSelf != visible)
			{
				this.mBlindMask.SetActive(visible);
			}
		}

		// Token: 0x06009EB2 RID: 40626 RVA: 0x001F8A60 File Offset: 0x001F6E60
		public void SetBlindMaskPosition(Vector2 pos)
		{
			if (this.mBlindMask != null)
			{
				RectTransform rectTransform = this.mBlindMask.transform as RectTransform;
				rectTransform.anchorMin = new Vector2(pos.x / (float)Screen.width, pos.y / (float)Screen.height);
				rectTransform.anchorMax = new Vector2(pos.x / (float)Screen.width, pos.y / (float)Screen.height);
			}
		}

		// Token: 0x06009EB3 RID: 40627 RVA: 0x001F8ADD File Offset: 0x001F6EDD
		private void _unloadBattleUI()
		{
			this._unloadComboUI();
			this._unloadDebugUI();
			MonoSingleton<GameFrameWork>.instance.SwithTouchInput(false);
			this.DeinitAutoFight();
		}

		// Token: 0x06009EB4 RID: 40628 RVA: 0x001F8AFC File Offset: 0x001F6EFC
		public void SetDungeonMapActive(bool active)
		{
			if (this.mDungeonMapCom != null)
			{
				this.mDungeonMapCom.gameObject.SetActive(active);
			}
		}

		// Token: 0x06009EB5 RID: 40629 RVA: 0x001F8B20 File Offset: 0x001F6F20
		public sealed override void GetEnterCoroutine(AddCoroutine enter)
		{
			base.GetEnterCoroutine(enter);
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				if (Global.Settings.isLocalDungeon)
				{
					BattleType battleType = ChapterUtility.GetBattleType(Global.Settings.localDungeonID);
					BattleMain.OpenBattle(battleType, eDungeonMode.Test, Global.Settings.localDungeonID, string.Empty);
				}
				else
				{
					BattleMain.OpenBattle(BattleType.Single, eDungeonMode.None, 0, string.Empty);
					FrameSync.instance.StartSingleFrame();
				}
			}
			enter(new loadingCoroutine(this._3stepStart), string.Empty, 1f);
		}

		// Token: 0x06009EB6 RID: 40630 RVA: 0x001F8BB4 File Offset: 0x001F6FB4
		private void _setRacePlayers(RacePlayerInfo[] players)
		{
			DataManager<BattleDataManager>.GetInstance().PlayerInfo = players;
			ClientApplication.racePlayerInfo = players;
			for (int i = 0; i < ClientApplication.racePlayerInfo.Length; i++)
			{
				RacePlayerInfo racePlayerInfo = ClientApplication.racePlayerInfo[i];
				if (racePlayerInfo.accid == ClientApplication.playerinfo.accid)
				{
					ClientApplication.playerinfo.seat = racePlayerInfo.seat;
				}
			}
		}

		// Token: 0x06009EB7 RID: 40631 RVA: 0x001F8C18 File Offset: 0x001F7018
		private IEnumerator _errorHandle(eEnumError type, string msg)
		{
			Logger.LogErrorFormat("[战斗] {0} {1}", new object[]
			{
				type,
				msg
			});
			base.OnSystemError();
			yield break;
		}

		// Token: 0x06009EB8 RID: 40632 RVA: 0x001F8C44 File Offset: 0x001F7044
		private IEnumerator _3stepStart(IASyncOperation op)
		{
			ThreeStepProcess threeStepProcess = new ThreeStepProcess("BattleStart", Singleton<ClientSystemManager>.instance.enumeratorManager, BattleMain.instance.Start(op), null, null);
			threeStepProcess.SetErrorProcessHandle(new ThreeStepProcess.ErrorProcessHandle(this._errorHandle));
			return threeStepProcess;
		}

		// Token: 0x06009EB9 RID: 40633 RVA: 0x001F8C88 File Offset: 0x001F7088
		public sealed override void OnEnter()
		{
			base.OnEnter();
			if (Global.Settings.debugNewAutofightAI)
			{
				Workspace.Instance.TryInit();
			}
			if (Global.Settings.displayHUD)
			{
				MonoSingleton<HUDInfoViewer>.instance.Init();
			}
			if (this.simpleActionManager != null)
			{
				this.simpleActionManager.Init();
			}
			if (base.state == ClientSystem.eClientSystemState.onError)
			{
				return;
			}
			if (BattleMain.IsTeamMode(BattleMain.battleType, BattleMain.mode))
			{
				ClientSystemBattle.bNeedOpenTeamFrame = true;
			}
			DungeonRebornFrame.isLocal = false;
			this._loadBattleUI();
			this._bindDungeonEvent();
			this._updateExpBar(true);
			if (Global.Settings.startSystem == EClientSystem.Battle)
			{
				DungeonRebornFrame.isLocal = true;
				if (!Global.Settings.isLocalDungeon)
				{
					this._unloadMapUI();
				}
			}
			else if (BattleMain.instance.battleState == BattleState.End && BattleMain.battleType != BattleType.ChijiPVP)
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<PKBattleResultFrame>(FrameLayer.Middle, null, string.Empty);
			}
			this._TryInitVoiceTalkModule();
			this.InitTeamChatVoice();
			this._hiddenFunctionByBattleType(BattleMain.battleType);
			this._setDungeonItem();
			this._bindUIEvent();
			this._bindDungeonScore();
			if (Global.Settings.isDebug && Global.Settings.testPlayerNum > 1)
			{
				for (int i = Global.Settings.testPlayerNum; i > 1; i--)
				{
					if (i == 3)
					{
						this.goTmpBun2.CustomActive(true);
					}
					else if (i == 2)
					{
						this.goTmpBun1.CustomActive(true);
					}
				}
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.RegisterPlayerDead(null);
			}
			if (!Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().SetLastPlaying(false);
			}
			if (BattleMain.instance != null)
			{
				if (BattleMain.IsModePvP(BattleMain.battleType))
				{
					this.SetUI3DRoot(true);
				}
				else
				{
					this.SetUI3DRoot(false);
				}
			}
			this.InitVanityBonusBuff();
			this.InitHunDunBuff();
			this._updatePrechangeJobSkillButton();
			EngineConfig.asyncLoadAnimRuntimeSwitch = true;
			if (BattleMain.battleType == BattleType.ScufflePVP)
			{
				Singleton<GameStatisticManager>.instance.dataStatistics.Init();
			}
			this.InitSwitchEquip();
		}

		// Token: 0x06009EBA RID: 40634 RVA: 0x001F8EB0 File Offset: 0x001F72B0
		public void ShowTraceAnimation()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<MissionDungenFrame>(null))
			{
				IClientFrame frame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(MissionDungenFrame));
				if (frame != null)
				{
					MissionDungenFrame missionFrame = frame as MissionDungenFrame;
					missionFrame.Move(true);
					Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(3000, delegate
					{
						missionFrame.Move(false);
					}, 0, 0, false);
				}
			}
		}

		// Token: 0x06009EBB RID: 40635 RVA: 0x001F8F2C File Offset: 0x001F732C
		public sealed override void OnStart(SystemContent systemContent)
		{
			BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
			if (base.state == ClientSystem.eClientSystemState.onError)
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				Singleton<ClientReconnectManager>.instance.Clear();
			}
			else
			{
				BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
				if (baseBattle != null)
				{
					baseBattle.PostStart();
					this.SetRebornDescOpen(baseBattle.IsRebornCountLimit());
					this.RefreshRebornCount(baseBattle.GetLeftRebornCount(), baseBattle.GetMaxRebornCount());
				}
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(100, delegate
				{
					if (!DataManager<MissionManager>.GetInstance().TryOpenTaskGuideInBattle())
					{
						this.ShowTraceAnimation();
					}
				}, 0, 0, false);
			}
			this._bindGetLocalPlayerHPValueChanged();
			this._bindGetLocalPlayerMPValueChanged();
		}

		// Token: 0x06009EBC RID: 40636 RVA: 0x001F8FD8 File Offset: 0x001F73D8
		private bool _bindGetLocalPlayerHPValueChanged()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			BattlePlayer player = BattleMain.instance.GetLocalPlayer(0UL);
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return false;
			}
			if (player.playerActor == null)
			{
				return false;
			}
			player.playerActor.RegisterEvent(BeEventType.onHPChange, delegate(object[] args3)
			{
				if (player == null)
				{
					return;
				}
				BeActor playerActor = player.playerActor;
				if (null == this.mComDrugTipsBar)
				{
					return;
				}
				if (this.mComDrugTipsBar.gameObject.activeSelf)
				{
					GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.HpChanged, null, null, null, null);
					this.mComDrugTipsBar.UseHpDrug(player.isAutoFight);
				}
			});
			return true;
		}

		// Token: 0x06009EBD RID: 40637 RVA: 0x001F9054 File Offset: 0x001F7454
		private bool _bindGetLocalPlayerMPValueChanged()
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			BattlePlayer player = BattleMain.instance.GetLocalPlayer(0UL);
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return false;
			}
			if (player.playerActor == null)
			{
				return false;
			}
			player.playerActor.RegisterEvent(BeEventType.onMPChange, delegate(object[] args3)
			{
				if (player == null)
				{
					return;
				}
				BeActor playerActor = player.playerActor;
				if (null == this.mComDrugTipsBar)
				{
					return;
				}
				if (this.mComDrugTipsBar.gameObject.activeSelf)
				{
					this.mComDrugTipsBar.UseMPDrug(player.isAutoFight);
				}
			});
			return true;
		}

		// Token: 0x06009EBE RID: 40638 RVA: 0x001F90D0 File Offset: 0x001F74D0
		public sealed override void OnExit()
		{
			this.TriggerBattleExitEvent();
			this.SavePveBattleResult();
			this.simpleActionManager.Deinit();
			this._unloadBattleUI();
			this._unBindUIEvent();
			this._unbindDungeonEvent();
			this._tryPushFrameBeforeBattleMainClose();
			this.mIsInit3v3AllPendingCharactor = false;
			this.UnInitVoiceModule();
			this.UnInitTeamChatVoice();
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemBattle;
			this.SaveSkillDamageData();
			if (BattleMain.instance != null)
			{
				if (clientSystemBattle != null)
				{
					BattleMain.CloseBattle(false);
				}
				else
				{
					BattleMain.CloseBattle(true);
				}
			}
			if (Singleton<ReplayServer>.GetInstance() != null)
			{
				Singleton<ReplayServer>.GetInstance().EndReplay(false, "SystemBattleExit");
			}
			Singleton<ExceptionManager>.GetInstance().PrintLogToFile(true);
			Singleton<ClientSystemManager>.GetInstance().Clear3DUIRoot();
			this.comShowHit.Clear();
			EngineConfig.asyncLoadAnimRuntimeSwitch = false;
			this.CloseChildFrameList();
		}

		// Token: 0x06009EBF RID: 40639 RVA: 0x001F919C File Offset: 0x001F759C
		private void TriggerBattleExitEvent()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager() == null)
			{
				return;
			}
			BeScene beScene = BattleMain.instance.GetDungeonManager().GetBeScene();
			if (beScene == null)
			{
				return;
			}
			beScene.TriggerEventNew(BeEventSceneType.onBattleExit, default(EventParam));
		}

		// Token: 0x06009EC0 RID: 40640 RVA: 0x001F91F0 File Offset: 0x001F75F0
		private void SavePveBattleResult()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
			if (baseBattle == null)
			{
				return;
			}
			PlayerLocalSetting.SetValue("BattleResult", (int)baseBattle.PveBattleResult);
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x06009EC1 RID: 40641 RVA: 0x001F9239 File Offset: 0x001F7639
		private void _hiddenTimer()
		{
			if (null != ClientSystemBattle.mTimerController)
			{
				ClientSystemBattle.mTimerController.SetVisible(false);
			}
		}

		// Token: 0x06009EC2 RID: 40642 RVA: 0x001F9256 File Offset: 0x001F7656
		private void _hiddenDropGold()
		{
			if (null != this.mDungeonMapCom)
			{
				this.mDungeonMapCom.mTextBoxRoot.SetActive(false);
				this.mDungeonMapCom.mTextGoldRoot.SetActive(false);
			}
		}

		// Token: 0x06009EC3 RID: 40643 RVA: 0x001F928C File Offset: 0x001F768C
		private void _hiddenFunctionByBattleType(BattleType type)
		{
			if (this.comShowHit != null)
			{
				this.comShowHit.RefreshGraphicSetting();
			}
			if (!this.mChatRoot.IsNull())
			{
				this.mChatRoot.SetActive(BattleMain.IsTeamMode(BattleMain.battleType, BattleMain.mode));
			}
			Battle3v3Frame battle3v3Frame = BattleUIHelper.GetBattleUIFrame<Battle3v3Frame>() as Battle3v3Frame;
			battle3v3Frame.HiddenPVP3V3Tips();
			if (ClientSystemBattle.pingText != null)
			{
				ClientSystemBattle.pingText.gameObject.CustomActive(false);
			}
			switch (type)
			{
			case BattleType.Single:
				this._hiddenTimer();
				this._setExpBarVisible(false);
				break;
			case BattleType.MutiPlayer:
			case BattleType.GuildPVP:
			case BattleType.MoneyRewardsPVP:
			case BattleType.PVP3V3Battle:
			case BattleType.ScufflePVP:
			case BattleType.ChijiPVP:
				this._setExpBarVisible(false);
				this._unloadMapUI();
				this.HidePauseButton(true);
				this._hiddenDropGold();
				this.InitForReplay();
				if (Global.Settings.forceUseAutoFight)
				{
					this.InitAutoFight();
				}
				break;
			case BattleType.Dungeon:
			case BattleType.Hell:
			case BattleType.YuanGu:
				this._hiddenTimer();
				this.InitAutoFight();
				break;
			case BattleType.DeadTown:
			case BattleType.FinalTestBattle:
				this._hiddenTimer();
				this._hiddenDropGold();
				if (this.mDungeonScore != null)
				{
					this.mDungeonScore.gameObject.CustomActive(false);
				}
				this.InitForDeadTower();
				this.InitAutoFight();
				if (this.mFightingTimeRoot)
				{
					this.mFightingTimeRoot.gameObject.CustomActive(false);
				}
				break;
			case BattleType.Mou:
			case BattleType.North:
			case BattleType.GoldRush:
				this._hiddenTimer();
				if (this.mDungeonScore != null)
				{
					this.mDungeonScore.gameObject.CustomActive(false);
				}
				this.InitAutoFight();
				if (this.mFightingTimeRoot)
				{
					this.mFightingTimeRoot.gameObject.CustomActive(false);
				}
				break;
			case BattleType.NewbieGuide:
			case BattleType.TrainingSkillCombo:
				if (!this.mAutoFightRootObj.IsNull())
				{
					this.mAutoFightRootObj.SetActive(false);
				}
				if (!this.mChatRoot.IsNull())
				{
					this.mChatRoot.SetActive(false);
				}
				this._hiddenDropGold();
				this._hiddenTimer();
				this._setExpBarVisible(false);
				this.HidePauseButton(true);
				if (!this.mComDrugTipsBar.IsNull())
				{
					this.mComDrugTipsBar.SetRootActive(false);
				}
				if (this.mDungeonScore != null)
				{
					this.mDungeonScore.gameObject.SetActive(false);
				}
				if (this.mFightingTimeRoot)
				{
					this.mFightingTimeRoot.gameObject.CustomActive(false);
				}
				break;
			case BattleType.Training:
				this._setExpBarVisible(false);
				this._unloadMapUI();
				this.HidePauseButton(true);
				this._hiddenDropGold();
				this.InitForTrain();
				break;
			case BattleType.ChampionMatch:
				this._hiddenTimer();
				this.InitForChampionMatch();
				this.InitAutoFight();
				break;
			case BattleType.GuildPVE:
				this._hiddenTimer();
				if (BattleMain.instance != null)
				{
					GuildPVEBattle guildPVEBattle = BattleMain.instance.GetBattle() as GuildPVEBattle;
					if (guildPVEBattle != null && guildPVEBattle.ValidTable != null)
					{
						GuildDungeonLvlTable validTable = guildPVEBattle.ValidTable;
						if (validTable.dungeonLvl > 1)
						{
							if (this.mDungeonScore != null)
							{
								this.mDungeonScore.gameObject.CustomActive(false);
							}
							if (this.mFightingTimeRoot)
							{
								this.mFightingTimeRoot.gameObject.CustomActive(false);
							}
						}
					}
				}
				this.InitAutoFight();
				break;
			case BattleType.TrainingPVE:
				this._setExpBarVisible(false);
				this._unloadMapUI();
				this._hiddenDropGold();
				this.InitTrainingPveBattle();
				break;
			case BattleType.RaidPVE:
				this.InitAutoFight();
				this._hiddenTimer();
				if (this.mDungeonScore != null)
				{
					this.mDungeonScore.gameObject.SetActive(false);
				}
				break;
			case BattleType.TreasureMap:
				this._hiddenTimer();
				if (!this.mDungeonScore.IsNull() && !this.mDungeonScore.gameObject.IsNull())
				{
					this.mDungeonScore.gameObject.CustomActive(false);
				}
				this.InitAutoFight();
				if (!this.mFightingTimeRoot.IsNull() && !this.mFightingTimeRoot.gameObject.IsNull())
				{
					this.mFightingTimeRoot.gameObject.CustomActive(false);
				}
				break;
			case BattleType.AnniversaryPVE_III:
				this._hiddenTimer();
				if (this.mDungeonScore != null)
				{
					this.mDungeonScore.gameObject.CustomActive(false);
				}
				if (this.mFightingTimeRoot)
				{
					this.mFightingTimeRoot.gameObject.CustomActive(false);
				}
				this.HidePauseButton(true);
				break;
			}
			this.InitWeaponChange();
			if (null != this.mPvp3v3Button)
			{
				if (!this.mPvp3v3TimeLimitButton.IsNull())
				{
					this.mPvp3v3TimeLimitButton.ResetCount();
				}
				this.mPvp3v3Button.gameObject.CustomActive(BattleMain.IsModePVP3V3(type) && !Singleton<ReplayServer>.instance.IsReplay());
			}
		}

		// Token: 0x06009EC4 RID: 40644 RVA: 0x001F978C File Offset: 0x001F7B8C
		protected void _bindDungeonEvent()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleDoubleBossTips, new ClientEventSystem.UIEventHandler(this._tipDoubleBoss));
			BattleType battleType = BattleMain.battleType;
			switch (battleType)
			{
			case BattleType.ChampionMatch:
			case BattleType.GuildPVE:
			case BattleType.FinalTestBattle:
				break;
			default:
				if (battleType != BattleType.Dungeon && battleType != BattleType.DeadTown && battleType != BattleType.YuanGu && battleType != BattleType.AnniversaryPVE_III)
				{
					goto IL_A1;
				}
				break;
			}
			if (BattleMain.mode != eDungeonMode.Test)
			{
				DataManager<MissionManager>.GetInstance().TriggerDungenBegin();
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRewardFinish, new ClientEventSystem.UIEventHandler(this._chapterFinish));
			}
			IL_A1:
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3StartVoteForFight, new ClientEventSystem.UIEventHandler(this.TryInitVoiceChat));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.onLiveShowPursueModeChange, new ClientEventSystem.UIEventHandler(this._onLiveShowPursueModeChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onPlayerReborn));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._onPlayerReborn));
		}

		// Token: 0x06009EC5 RID: 40645 RVA: 0x001F98A8 File Offset: 0x001F7CA8
		private void _onPlayerReborn(UIEvent ui)
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			IBattle battle = BattleMain.instance.GetBattle();
			if (battle != null && battle.IsRebornCountLimit())
			{
				this.RefreshRebornCount(battle.GetLeftRebornCount(), battle.GetMaxRebornCount());
			}
		}

		// Token: 0x06009EC6 RID: 40646 RVA: 0x001F98EE File Offset: 0x001F7CEE
		private void _onLiveShowPursueModeChange(UIEvent ui)
		{
			if (Singleton<ReplayServer>.GetInstance().IsLiveShow() && !Singleton<ReplayServer>.GetInstance().isInPersueMode)
			{
				this.btnReplaySpeed.gameObject.SetActive(true);
			}
		}

		// Token: 0x06009EC7 RID: 40647 RVA: 0x001F9920 File Offset: 0x001F7D20
		private void _tipDoubleBoss(UIEvent ui)
		{
			int num = (int)ui.Param1;
			int id = (int)ui.Param2;
			CommonTipsDesc tableItem = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				SystemNotifyManager.SysDungeonSkillTip(tableItem.Descs, (float)num / 1000f, false);
			}
		}

		// Token: 0x06009EC8 RID: 40648 RVA: 0x001F9976 File Offset: 0x001F7D76
		private void _chapterFinish(UIEvent uiEvent)
		{
			if (BattleMain.mode != eDungeonMode.Test)
			{
				DataManager<MissionManager>.GetInstance().TriggerDungenEnd();
			}
		}

		// Token: 0x06009EC9 RID: 40649 RVA: 0x001F9990 File Offset: 0x001F7D90
		protected void _unbindDungeonEvent()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleDoubleBossTips, new ClientEventSystem.UIEventHandler(this._tipDoubleBoss));
			BattleType battleType = BattleMain.battleType;
			switch (battleType)
			{
			case BattleType.ChampionMatch:
			case BattleType.GuildPVE:
			case BattleType.FinalTestBattle:
				break;
			default:
				if (battleType != BattleType.Dungeon && battleType != BattleType.DeadTown && battleType != BattleType.YuanGu && battleType != BattleType.AnniversaryPVE_III)
				{
					goto IL_97;
				}
				break;
			}
			if (BattleMain.mode != eDungeonMode.Test)
			{
				UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRewardFinish, new ClientEventSystem.UIEventHandler(this._chapterFinish));
			}
			IL_97:
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.onLiveShowPursueModeChange, new ClientEventSystem.UIEventHandler(this._onLiveShowPursueModeChange));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3StartVoteForFight, new ClientEventSystem.UIEventHandler(this.TryInitVoiceChat));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AddRerbornCount, new ClientEventSystem.UIEventHandler(this._onPlayerReborn));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonRebornSuccess, new ClientEventSystem.UIEventHandler(this._onPlayerReborn));
		}

		// Token: 0x06009ECA RID: 40650 RVA: 0x001F9AA0 File Offset: 0x001F7EA0
		protected void _bindDungeonScore()
		{
			if (null != this.mDungeonScore)
			{
				this.mDungeonScore.Init();
				this.mDungeonScore.infos[0].SetScoreCallback(() => BattleMain.instance.GetDungeonStatistics().HitCountScore());
				this.mDungeonScore.infos[1].SetScoreCallback(() => BattleMain.instance.GetDungeonStatistics().AllFightTimeScore(true));
				this.mDungeonScore.infos[1].SetTimeLimiteCallback(() => BattleMain.instance.GetDungeonStatistics().FightTimeSplit(1));
				this.mDungeonScore.infos[2].SetScoreCallback(() => BattleMain.instance.GetDungeonStatistics().RebornCountScore());
				this.mDungeonScore.infos[0].SetCallback(() => BattleMain.instance.GetDungeonStatistics().AllHitCount());
				this.mDungeonScore.infos[1].SetCallback(() => BattleMain.instance.GetDungeonStatistics().AllFightTime(true));
				this.mDungeonScore.infos[2].SetCallback(() => BattleMain.instance.GetDungeonStatistics().AllRebornCount());
			}
			if (null != this.mDungeonScore)
			{
				this.mDungeonScore.onFadeChanged = delegate(ComDungeonScore.eState State)
				{
					bool flag = State == ComDungeonScore.eState.Open;
					if (this.mFightingTimeRoot)
					{
						this.mFightingTimeRoot.gameObject.CustomActive(!flag);
					}
				};
			}
			if (null != this.mFightingTimeRoot && this.mFightingTimeRoot.infos != null && this.mFightingTimeRoot.infos.Length > 0)
			{
				this.mFightingTimeRoot.infos[0].SetCallback(() => BattleMain.instance.GetDungeonStatistics().AllFightTime(true));
			}
		}

		// Token: 0x06009ECB RID: 40651 RVA: 0x001F9CA0 File Offset: 0x001F80A0
		protected void _bindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._onPkRankChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonScoreChanged, new ClientEventSystem.UIEventHandler(this._onScoreUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonUnlockDiff, new ClientEventSystem.UIEventHandler(this._onDiffHardUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this._OnGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this._OnGuideFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleFrameSyncEnd, new ClientEventSystem.UIEventHandler(this._OnBattleFrameSyncEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3StartRedyFightCount, new ClientEventSystem.UIEventHandler(this._onPK3V3StartRedyFightCount));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3StartRedyFightCount));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3GetRoundEndResult, new ClientEventSystem.UIEventHandler(this._onPK3V3GetRoundEndResult));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VanityBonusAnimationEnd, new ClientEventSystem.UIEventHandler(this.onUpdateVanityBonusIconStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemSwitchFinished));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRollItemEnd, new ClientEventSystem.UIEventHandler(this._OnRollItemEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TreasureMapSizeChange, new ClientEventSystem.UIEventHandler(this._OnTreasureMapSizeChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnHardUltimateStart, new ClientEventSystem.UIEventHandler(this._OnHardUltimateStart));
			this.m_HidePauseBtnHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnHidePauseButton, new UIEventNew.UIEventHandleNew.Function(this._onHidePauseButton));
			this.m_CountDownStartHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnCountDownStart, new UIEventNew.UIEventHandleNew.Function(this._onCountDownStart));
			this.m_CountDownUpdateHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnCountDownUpdate, new UIEventNew.UIEventHandleNew.Function(this._onCountDownUpdate));
		}

		// Token: 0x06009ECC RID: 40652 RVA: 0x001F9EBC File Offset: 0x001F82BC
		protected void _unBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PKRankChanged, new ClientEventSystem.UIEventHandler(this._onPkRankChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonScoreChanged, new ClientEventSystem.UIEventHandler(this._onScoreUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonUnlockDiff, new ClientEventSystem.UIEventHandler(this._onDiffHardUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this._OnGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideFinish, new ClientEventSystem.UIEventHandler(this._OnGuideFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleFrameSyncEnd, new ClientEventSystem.UIEventHandler(this._OnBattleFrameSyncEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3StartRedyFightCount, new ClientEventSystem.UIEventHandler(this._onPK3V3StartRedyFightCount));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3StartRedyFightCount));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3GetRoundEndResult, new ClientEventSystem.UIEventHandler(this._onPK3V3GetRoundEndResult));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VanityBonusAnimationEnd, new ClientEventSystem.UIEventHandler(this.onUpdateVanityBonusIconStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this._OnSystemSwitchFinished));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRollItemEnd, new ClientEventSystem.UIEventHandler(this._OnRollItemEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TreasureMapSizeChange, new ClientEventSystem.UIEventHandler(this._OnTreasureMapSizeChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnHardUltimateStart, new ClientEventSystem.UIEventHandler(this._OnHardUltimateStart));
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_HidePauseBtnHandler);
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_CountDownStartHandler);
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_CountDownUpdateHandler);
			this.m_HidePauseBtnHandler = null;
			this.m_CountDownStartHandler = null;
			this.m_CountDownUpdateHandler = null;
		}

		// Token: 0x06009ECD RID: 40653 RVA: 0x001FA0B8 File Offset: 0x001F84B8
		private ClientSystemBattle.PVP3V3Unit _getPVP3V3Unit(BattlePlayer player)
		{
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return null;
			}
			for (int i = 0; i < this.mPVP3V3Units.Count; i++)
			{
				if (this.mPVP3V3Units[i].seat == player.GetPlayerSeat())
				{
					return this.mPVP3V3Units[i];
				}
			}
			return null;
		}

		// Token: 0x06009ECE RID: 40654 RVA: 0x001FA118 File Offset: 0x001F8518
		private void _onCountDownStart(UIEventNew.UIEventParamNew param)
		{
			if (this.mFightingTimeRoot != null)
			{
				ComCommonBind component = this.mFightingTimeRoot.GetComponent<ComCommonBind>();
				if (component != null)
				{
					this.m_CountDownTimer = component.GetCom<SimpleTimer>("countDownTimer");
					if (this.m_CountDownTimer != null)
					{
						this.m_CountDownTimer.CustomActive(true);
						this.m_CountDownTimer.SetCountdown(param.m_Int);
						this.m_CountDownTimer.StartTimer();
					}
				}
				if (this.mFightingTimeRoot.infos != null && this.mFightingTimeRoot.infos.Length > 0)
				{
					this.mFightingTimeRoot.infos[0].OnCountDownStart();
				}
			}
		}

		// Token: 0x06009ECF RID: 40655 RVA: 0x001FA1CD File Offset: 0x001F85CD
		private void _onCountDownUpdate(UIEventNew.UIEventParamNew param)
		{
			if (this.m_CountDownTimer != null)
			{
				this.m_CountDownTimer.UpdateTimer(param.m_Int);
			}
		}

		// Token: 0x06009ED0 RID: 40656 RVA: 0x001FA1F1 File Offset: 0x001F85F1
		private void _onHidePauseButton(UIEventNew.UIEventParamNew param)
		{
			this.HidePauseButton(param.m_Bool);
		}

		// Token: 0x06009ED1 RID: 40657 RVA: 0x001FA1FF File Offset: 0x001F85FF
		private void _OnHardUltimateStart(UIEvent uiEvent)
		{
			if (this.dungeonMapCom != null)
			{
				this.dungeonMapCom.ShowHellEffect();
			}
		}

		// Token: 0x06009ED2 RID: 40658 RVA: 0x001FA220 File Offset: 0x001F8620
		private ClientSystemBattle.PVP3V3Unit _addPVP3V3Unit(BattlePlayer player)
		{
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/Bars/Charactor/PVP3V3/3v3PendingCharactor", true, 0U);
			if (null == gameObject)
			{
				return null;
			}
			if (player.IsTeamRed())
			{
				Utility.AttachTo(gameObject, this.mPvp3v3LeftPendingRoot, false);
			}
			else
			{
				Utility.AttachTo(gameObject, this.mPvp3v3RightPendingRoot, false);
			}
			ClientSystemBattle.PVP3V3Unit pvp3V3Unit = new ClientSystemBattle.PVP3V3Unit
			{
				seat = player.GetPlayerSeat(),
				com = gameObject.GetComponent<ComPVP3V3PendingCharactor>()
			};
			pvp3V3Unit.com.InitWithSeat(pvp3V3Unit.seat);
			this.mPVP3V3Units.Add(pvp3V3Unit);
			return pvp3V3Unit;
		}

		// Token: 0x06009ED3 RID: 40659 RVA: 0x001FA2C4 File Offset: 0x001F86C4
		private void _clearPVP3V3Units()
		{
			for (int i = 0; i < this.mPVP3V3Units.Count; i++)
			{
				this.mPVP3V3Units[i].seat = byte.MaxValue;
				this.mPVP3V3Units[i].com = null;
			}
			this.mPVP3V3Units.Clear();
		}

		// Token: 0x06009ED4 RID: 40660 RVA: 0x001FA320 File Offset: 0x001F8720
		private void _onPK3V3StartRedyFightCount(UIEvent ui)
		{
			this._update3v3AllPendingCharactor();
			this._update3v3UIVisible();
			this._update3v3ApplyFightStatus();
		}

		// Token: 0x06009ED5 RID: 40661 RVA: 0x001FA334 File Offset: 0x001F8734
		private void _onPK3V3GetRoundEndResult(UIEvent ui)
		{
			if (null != this.mPvp3v3TimeLimitButton)
			{
				this.mPvp3v3TimeLimitButton.ResetCount();
			}
			if (null == this.mPvp3v3Button)
			{
				return;
			}
			this.mPvp3v3Button.gameObject.CustomActive(false);
		}

		// Token: 0x06009ED6 RID: 40662 RVA: 0x001FA380 File Offset: 0x001F8780
		private void onUpdateVanityBonusIconStatus(UIEvent ui)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VanityBuffBonusFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<VanityBuffBonusFrame>(null, false);
			}
			if (this.mVanityBonusBuffConent != null)
			{
				this.mVanityBonusBuffConent.CustomActive(true);
			}
		}

		// Token: 0x06009ED7 RID: 40663 RVA: 0x001FA3BC File Offset: 0x001F87BC
		private void _OnSystemSwitchFinished(UIEvent uiEvent)
		{
			if (DataManager<ChijiDataManager>.GetInstance().GuardForPkEndData && BattleMain.battleType == BattleType.ChijiPVP)
			{
				DataManager<ChijiDataManager>.GetInstance().GuardForPkEndData = false;
				Logger.LogErrorFormat("吃鸡结算异常测试----PKResult = {0},[_OnSystemSwitchFinished]", new object[]
				{
					DataManager<ChijiDataManager>.GetInstance().PkEndData.result
				});
				DataManager<ChijiDataManager>.GetInstance().ResponseBattleEnd();
			}
		}

		// Token: 0x06009ED8 RID: 40664 RVA: 0x001FA420 File Offset: 0x001F8820
		private void _OnRollItemEnd(UIEvent uiEvent)
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<DungeonRollFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<DungeonRollFrame>(null, false);
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonRollResultFrame>(FrameLayer.Middle, uiEvent.Param1, string.Empty);
			}
		}

		// Token: 0x06009ED9 RID: 40665 RVA: 0x001FA458 File Offset: 0x001F8858
		private void _OnTreasureMapSizeChanged(UIEvent uiEvent)
		{
			TreasureDungeonMap.UITreasureEventParam uitreasureEventParam = uiEvent.Param1 as TreasureDungeonMap.UITreasureEventParam;
			if (uitreasureEventParam != null && !this.dungeonMapCom.IsNull())
			{
				this.dungeonMapCom.ResizeMap(uitreasureEventParam.width, uitreasureEventParam.height);
			}
		}

		// Token: 0x06009EDA RID: 40666 RVA: 0x001FA4A0 File Offset: 0x001F88A0
		private void _init3v3AllPendingCharactor()
		{
			if (this.mIsInit3v3AllPendingCharactor)
			{
				return;
			}
			this.mIsInit3v3AllPendingCharactor = true;
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer player = allPlayers[i];
				this._addPVP3V3Unit(player);
			}
		}

		// Token: 0x06009EDB RID: 40667 RVA: 0x001FA4F8 File Offset: 0x001F88F8
		private void _update3v3AllPendingCharactor()
		{
			this._init3v3AllPendingCharactor();
			for (int i = 0; i < this.mPVP3V3Units.Count; i++)
			{
				ClientSystemBattle.PVP3V3Unit pvp3V3Unit = this.mPVP3V3Units[i];
				if (pvp3V3Unit != null && null != pvp3V3Unit.com)
				{
					pvp3V3Unit.com.UpdateInfo();
					BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(pvp3V3Unit.seat);
					if (BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
					{
						pvp3V3Unit.com.gameObject.CustomActive(!playerBySeat.isFighting);
					}
				}
			}
		}

		// Token: 0x06009EDC RID: 40668 RVA: 0x001FA590 File Offset: 0x001F8990
		private void _update3v3ApplyFightStatus()
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				return;
			}
			if (!mainPlayer.hasFighted)
			{
				if (mainPlayer.isVote)
				{
					this.mPvp3v3FightOn.CustomActive(true);
					this.mPvp3v3FightOff.CustomActive(false);
				}
				else
				{
					this.mPvp3v3FightOn.CustomActive(false);
					this.mPvp3v3FightOff.CustomActive(true);
				}
			}
			else
			{
				this._update3v3UIVisible();
			}
		}

		// Token: 0x06009EDD RID: 40669 RVA: 0x001FA610 File Offset: 0x001F8A10
		private void _update3v3UIVisible()
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				return;
			}
			if (null == this.mPvp3v3Button)
			{
				return;
			}
			bool flag = true;
			if (mainPlayer.isFighting)
			{
				flag = false;
			}
			if (mainPlayer.isPassedInRound)
			{
				flag = false;
			}
			this.InitWeaponChange();
			this.mPvp3v3Button.gameObject.CustomActive(flag && !Singleton<ReplayServer>.instance.IsReplay());
		}

		// Token: 0x06009EDE RID: 40670 RVA: 0x001FA694 File Offset: 0x001F8A94
		private void _onDiffHardUpdate(UIEvent ui)
		{
			int id = (int)ui.Param1;
			int diff = (int)ui.Param2;
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				SystemNotifyManager.SystemNotify(6002, new object[]
				{
					tableItem.Name,
					ChapterUtility.GetHardString(diff)
				});
			}
		}

		// Token: 0x06009EDF RID: 40671 RVA: 0x001FA6F8 File Offset: 0x001F8AF8
		private void _onExpChanged(UIEvent uiEvent)
		{
			if (BattleMain.instance != null)
			{
				BattleType battleType = BattleMain.battleType;
				switch (battleType)
				{
				case BattleType.Dungeon:
				case BattleType.DeadTown:
				case BattleType.Mou:
				case BattleType.North:
				case BattleType.Hell:
				case BattleType.YuanGu:
				case BattleType.GoldRush:
				case BattleType.ChampionMatch:
				case BattleType.GuildPVE:
					break;
				default:
					if (battleType != BattleType.AnniversaryPVE_III)
					{
						return;
					}
					break;
				}
				this._updateExpBar(false);
			}
		}

		// Token: 0x06009EE0 RID: 40672 RVA: 0x001FA778 File Offset: 0x001F8B78
		protected void _onLevelChanged(UIEvent uiEvent)
		{
			if (BattleMain.instance != null)
			{
				switch (BattleMain.battleType)
				{
				case BattleType.Dungeon:
				case BattleType.DeadTown:
				case BattleType.Mou:
				case BattleType.North:
				case BattleType.Hell:
				case BattleType.YuanGu:
				case BattleType.GoldRush:
				case BattleType.ChampionMatch:
				case BattleType.GuildPVE:
				case BattleType.FinalTestBattle:
				case BattleType.AnniversaryPVE_III:
				{
					BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
					if (mainPlayer != null && mainPlayer.playerActor != null && mainPlayer.playerActor.m_pkGeActor != null)
					{
						int num = (int)DataManager<PlayerBaseData>.GetInstance().Level - this.previousLevel;
						this.previousLevel = (int)DataManager<PlayerBaseData>.GetInstance().Level;
						LevelChangeCommand cmd = new LevelChangeCommand
						{
							newLevel = (int)DataManager<PlayerBaseData>.GetInstance().Level
						};
						FrameSync.instance.FireFrameCommand(cmd, false);
					}
					break;
				}
				}
			}
			this._updatePrechangeJobSkillButton();
		}

		// Token: 0x06009EE1 RID: 40673 RVA: 0x001FA880 File Offset: 0x001F8C80
		protected void _onPkRankChanged(UIEvent uiEvent)
		{
			if (BattleMain.instance != null)
			{
				BattleType battleType = BattleMain.battleType;
				switch (battleType)
				{
				case BattleType.Dungeon:
				case BattleType.DeadTown:
				case BattleType.Mou:
				case BattleType.North:
					break;
				default:
					switch (battleType)
					{
					case BattleType.ChampionMatch:
					case BattleType.GuildPVE:
					case BattleType.FinalTestBattle:
						break;
					default:
						if (battleType != BattleType.AnniversaryPVE_III)
						{
							return;
						}
						break;
					}
					break;
				}
				BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
				if (mainPlayer != null && mainPlayer.playerActor != null && mainPlayer.playerActor.m_pkGeActor != null)
				{
					mainPlayer.playerActor.m_pkGeActor.UpdatePkRank(DataManager<SeasonDataManager>.GetInstance().seasonLevel, DataManager<SeasonDataManager>.GetInstance().seasonStar);
				}
			}
		}

		// Token: 0x06009EE2 RID: 40674 RVA: 0x001FA940 File Offset: 0x001F8D40
		protected void _OnGuideStart(UIEvent a_event)
		{
			NewbieGuideTable.eNewbieGuideTask eNewbieGuideTask = (NewbieGuideTable.eNewbieGuideTask)a_event.Param1;
			if (eNewbieGuideTask == NewbieGuideTable.eNewbieGuideTask.AutoFightGuide)
			{
				this.autoFight.gameObject.CustomActive(false);
			}
			BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
			if (baseBattle != null)
			{
				BeDungeon dungeon = baseBattle.dungeonManager as BeDungeon;
				if (eNewbieGuideTask == NewbieGuideTable.eNewbieGuideTask.AbyssGuide2 || eNewbieGuideTask == NewbieGuideTable.eNewbieGuideTask.AbyssGuide3)
				{
					Singleton<SkillComboControl>.instance.StartHellGuide(dungeon);
				}
			}
		}

		// Token: 0x06009EE3 RID: 40675 RVA: 0x001FA9B0 File Offset: 0x001F8DB0
		protected void _OnGuideFinish(UIEvent a_event)
		{
			NewbieGuideTable.eNewbieGuideTask eNewbieGuideTask = (NewbieGuideTable.eNewbieGuideTask)a_event.Param1;
			if (eNewbieGuideTask == NewbieGuideTable.eNewbieGuideTask.AutoFightGuide)
			{
				this.InitAutoFight();
			}
		}

		// Token: 0x06009EE4 RID: 40676 RVA: 0x001FA9D7 File Offset: 0x001F8DD7
		private void _OnBattleFrameSyncEnd(UIEvent a_event)
		{
			ClientSystemBattle.StopTimer();
		}

		// Token: 0x06009EE5 RID: 40677 RVA: 0x001FA9E0 File Offset: 0x001F8DE0
		private void _onScoreUpdate(UIEvent uiEvent)
		{
			if (null != this.mDungeonScore && BattleMain.instance != null && BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().GetBeScene() != null && !BattleMain.instance.GetDungeonManager().GetBeScene().IsBossDead())
			{
				DungeonScore score = BattleMain.instance.GetDungeonStatistics().FinalDungeonScore();
				this.mDungeonScore.SetScore(score);
				if (this.mFightingTimeRoot)
				{
					this.mFightingTimeRoot.SetScore(score);
				}
			}
		}

		// Token: 0x06009EE6 RID: 40678 RVA: 0x001FAA7C File Offset: 0x001F8E7C
		public void InitVanityBonusBuff()
		{
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsYiJieCheckPoint() && DataManager<ActivityManager>.GetInstance().GetVanityBonusActivityIsShow())
			{
				for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().buffList.Count; i++)
				{
					int id = DataManager<PlayerBaseData>.GetInstance().buffList[i].id;
					BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(id, string.Empty, string.Empty);
					if (tableItem != null && tableItem.ApplyDungeon.Length > 0)
					{
						int num = 0;
						string[] array = tableItem.ApplyDungeon.Split(new char[]
						{
							'|'
						});
						for (int j = 0; j < array.Length; j++)
						{
							if (int.TryParse(array[j], out num))
							{
								if (num == 17)
								{
									this.mVanityBonusBuffIcon.sprite = (Singleton<AssetLoader>.instance.LoadRes(tableItem.Icon, typeof(Sprite), true, 0U).obj as Sprite);
									Vector3 position = this.mVanityBonusBuffConent.GetComponent<RectTransform>().position;
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VanityBonusBuffPos, position, tableItem, null, null);
									this.mBVanityBonusBuff = true;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06009EE7 RID: 40679 RVA: 0x001FABC8 File Offset: 0x001F8FC8
		public void InitHunDunBuff()
		{
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsHunDunCheckPoint() && DataManager<ActivityManager>.GetInstance().GetChaosAdditionActivityIsShow())
			{
				for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().buffList.Count; i++)
				{
					int id = DataManager<PlayerBaseData>.GetInstance().buffList[i].id;
					BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(id, string.Empty, string.Empty);
					if (tableItem != null && tableItem.ApplyDungeon.Length > 0)
					{
						int num = 0;
						string[] array = tableItem.ApplyDungeon.Split(new char[]
						{
							'|'
						});
						for (int j = 0; j < array.Length; j++)
						{
							if (int.TryParse(array[j], out num) && (num == 20 || num == 23 || num == 22))
							{
								this.mVanityBonusBuffIcon.sprite = (Singleton<AssetLoader>.instance.LoadRes(tableItem.Icon, typeof(Sprite), true, 0U).obj as Sprite);
								Vector3 position = this.mVanityBonusBuffConent.GetComponent<RectTransform>().position;
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VanityBonusBuffPos, position, tableItem, null, null);
								this.mBChaosAdditionBuff = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x06009EE8 RID: 40680 RVA: 0x001FAD20 File Offset: 0x001F9120
		private void _tryPushFrameBeforeBattleMainClose()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.battleType == BattleType.TrainingPVE)
			{
				if (InstituteFrame.IsEnterFromYanWUYuan)
				{
					Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(InstituteFrame), null));
				}
				return;
			}
			int num = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
			num = ChapterUtility.GetOriginDungeonId(num);
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (BattleMain.battleType == BattleType.FinalTestBattle)
				{
					BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
					if (baseBattle != null && baseBattle.PveBattleResult == BattleResult.Fail && DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufID() > 0)
					{
						Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(GetUltimateChallengeBufTipFrame), null));
					}
					Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(UltimateChallengeFrame), null));
				}
				if (!DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					if (tableItem.SubType == DungeonTable.eSubType.S_YUANGU || tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER)
					{
						ChallengeUtility.OnOpenClientFrameStackCmd(num, tableItem);
					}
					else if (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
					{
						Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(FallAbyssFrame), null));
					}
					else if (tableItem.SubType == DungeonTable.eSubType.S_RAID_DUNGEON)
					{
						TeamDuplicationUtility.OnOpenClientFrameStackCmd();
					}
					else if (tableItem.SubType == DungeonTable.eSubType.S_PLAYGAME)
					{
						int num2 = 0;
						if (int.TryParse(TR.Value("activity_zillionaire_game_id"), out num2))
						{
							Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(LimitTimeActivityFrame), num2));
						}
					}
					else if (tableItem.SubType != DungeonTable.eSubType.S_NORMAL && tableItem.SubType != DungeonTable.eSubType.S_WUDAOHUI && tableItem.SubType != DungeonTable.eSubType.S_NEWBIEGUIDE && tableItem.SubType != DungeonTable.eSubType.S_PK && tableItem.SubType != DungeonTable.eSubType.S_COMBOTRAINING && tableItem.SubType != DungeonTable.eSubType.S_CITYMONSTER && tableItem.SubType != DungeonTable.eSubType.S_DEVILDDOM && tableItem.SubType != DungeonTable.eSubType.S_GUILD_DUNGEON && tableItem.SubType != DungeonTable.eSubType.S_RAID_DUNGEON && tableItem.SubType != DungeonTable.eSubType.S_ANNIVERSARY_HARD && tableItem.SubType != DungeonTable.eSubType.S_ANNIVERSARY_NORMAL && tableItem.SubType != DungeonTable.eSubType.S_TREASUREMAP)
					{
						ActiveParams data = new ActiveParams
						{
							param0 = (ulong)((long)num)
						};
						Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(ActivityDungeonFrame), data));
					}
				}
				if (BattleMain.battleType == BattleType.TrainingSkillCombo || BattleMain.battleType == BattleType.Training)
				{
					Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(InstituteFrame), null));
				}
			}
		}

		// Token: 0x06009EE9 RID: 40681 RVA: 0x001FB003 File Offset: 0x001F9403
		protected void _baseUITick(float delta)
		{
			this.mTimeTick += delta;
			if (this.mTimeTick > 0.5f)
			{
				this.mTimeTick -= 0.5f;
				this._onUIUpdate();
			}
		}

		// Token: 0x06009EEA RID: 40682 RVA: 0x001FB03B File Offset: 0x001F943B
		protected void _onUIUpdate()
		{
			this._onScoreUpdate(null);
		}

		// Token: 0x06009EEB RID: 40683 RVA: 0x001FB044 File Offset: 0x001F9444
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			bool flag = false;
			if (BattleMain.instance != null && BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().GetDungeonDataManager() != null)
			{
				flag = true;
			}
			if (this.mBVanityBonusBuff)
			{
				this.timer += timeElapsed;
				if (this.timer >= 0.3f)
				{
					if (flag && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsYiJieCheckPoint())
					{
						this.OpenVanityBuffBonusFrame();
					}
					this.mBVanityBonusBuff = false;
					this.timer = 0f;
				}
			}
			if (this.mBChaosAdditionBuff)
			{
				this.mBChaosAdditionTimer += timeElapsed;
				if (this.mBChaosAdditionTimer >= 0.3f)
				{
					if (flag && BattleMain.instance.GetDungeonManager().GetDungeonDataManager().IsHunDunCheckPoint())
					{
						this.OpenChaosAdditionFrame();
					}
					this.mBChaosAdditionBuff = false;
					this.mBChaosAdditionTimer = 0f;
				}
			}
			int num = (int)(timeElapsed * (float)GlobalLogic.VALUE_1000);
			this._baseUITick(timeElapsed);
			this.comShowHit.Update(num);
			this.UpdateCheckRestoreAutoFight(num);
			this.simpleActionManager.Update(num);
			if (BattleMain.instance != null)
			{
				if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
				{
					Singleton<RecordServer>.GetInstance().Update(num);
				}
				if (Singleton<ReplayServer>.GetInstance().IsReplay())
				{
					Singleton<ReplayServer>.GetInstance().Update(num);
				}
				BattleMain.instance.Update();
				if (BattleMain.IsModeMultiplayer(BattleMain.mode))
				{
					if (Global.Settings.isDebug)
					{
						this._onUpdateRandCount();
					}
					this.UpdateCheckFPS(timeElapsed);
				}
				if (BattleMain.IsShowPing(BattleMain.battleType))
				{
					this._onUpdatePing();
					BattlePlayer localTargetPlayer = BattleMain.instance.GetLocalTargetPlayer();
					if (localTargetPlayer != null && localTargetPlayer.playerActor != null)
					{
						if (BattleMain.IsModePvP(BattleMain.battleType))
						{
							if (!localTargetPlayer.playerActor.stateController.IsInvisible())
							{
								BattleMain.instance.Main.TraceActor(localTargetPlayer.playerActor);
							}
						}
						else
						{
							BattleMain.instance.Main.TraceActor(localTargetPlayer.playerActor);
						}
					}
				}
				else if (BattleMain.battleType == BattleType.ScufflePVP)
				{
					this._onUpdatePing();
				}
			}
		}

		// Token: 0x06009EEC RID: 40684 RVA: 0x001FB284 File Offset: 0x001F9684
		protected void UpdateCheckFPS(float delta)
		{
			this.fpsAcc += delta;
			if (this.fpsAcc >= (float)MonoSingleton<ComponentFPS>.instance.watchFrames)
			{
				this.fpsAcc -= (float)MonoSingleton<ComponentFPS>.instance.watchFrames;
				Singleton<GeGraphicSetting>.instance.CheckBattleFPS();
			}
		}

		// Token: 0x06009EED RID: 40685 RVA: 0x001FB2D8 File Offset: 0x001F96D8
		private void _onUpdatePing()
		{
			float num = Time.realtimeSinceStartup - this.time;
			if (num > 1f)
			{
				int pingToRelayServer = MonoSingleton<NetManager>.instance.GetPingToRelayServer();
				string text = string.Empty;
				string str = string.Empty + pingToRelayServer + "ms";
				if (pingToRelayServer >= 100)
				{
					if (pingToRelayServer < 200)
					{
						text = "<color=yellow>" + str + "</color>";
					}
					else
					{
						text = "<color=red>" + str + "</color>";
					}
				}
				if (ClientSystemBattle.pingText != null)
				{
				}
				if (BattleMain.battleType == BattleType.ScufflePVP)
				{
					Singleton<GameStatisticManager>.instance.dataStatistics.CollectPingStatistic(pingToRelayServer);
					Singleton<GameStatisticManager>.instance.dataStatistics.CollectFpsStatistic(MonoSingleton<ComponentFPS>.instance.GetFPS());
				}
				this.time = Time.realtimeSinceStartup;
			}
		}

		// Token: 0x06009EEE RID: 40686 RVA: 0x001FB3B8 File Offset: 0x001F97B8
		private void _onUpdateRandCount()
		{
			if (ClientSystemBattle.pingText != null && BattleMain.instance.FrameRandom.callNum != this.savedRandCallNum)
			{
				this.savedRandCallNum = BattleMain.instance.FrameRandom.callNum;
				ClientSystemBattle.pingText.CustomActive(true);
				ClientSystemBattle.pingText.text = "Rand CallNum:" + this.savedRandCallNum;
			}
		}

		// Token: 0x06009EEF RID: 40687 RVA: 0x001FB42E File Offset: 0x001F982E
		public void SetTipsPercent(float percent)
		{
			this.mTipsBar.enabled = true;
			this.mTipsBar.fillAmount = percent;
		}

		// Token: 0x06009EF0 RID: 40688 RVA: 0x001FB448 File Offset: 0x001F9848
		public static void StartTimer(int countdown = 0)
		{
			if (ClientSystemBattle.mTimerController != null)
			{
				if (countdown > 0)
				{
					ClientSystemBattle.mTimerController.SetCountdown(countdown);
				}
				ClientSystemBattle.mTimerController.StartTimer();
			}
		}

		// Token: 0x06009EF1 RID: 40689 RVA: 0x001FB476 File Offset: 0x001F9876
		public static void StopTimer()
		{
			if (ClientSystemBattle.mTimerController != null)
			{
				ClientSystemBattle.mTimerController.StopTimer();
			}
		}

		// Token: 0x06009EF2 RID: 40690 RVA: 0x001FB492 File Offset: 0x001F9892
		public static bool IsTimeUp()
		{
			return !(ClientSystemBattle.mTimerController != null) || ClientSystemBattle.mTimerController.IsTimeUp();
		}

		// Token: 0x06009EF3 RID: 40691 RVA: 0x001FB4B0 File Offset: 0x001F98B0
		public static void UpdateTimer(int delta)
		{
			if (ClientSystemBattle.mTimerController != null)
			{
				ClientSystemBattle.mTimerController.UpdateTimer(delta);
			}
		}

		// Token: 0x06009EF4 RID: 40692 RVA: 0x001FB4CD File Offset: 0x001F98CD
		public bool IsDrugVisible()
		{
			return this.mComDrugTipsBar != null && this.mComDrugTipsBar.gameObject != null && this.mComDrugTipsBar.gameObject.activeSelf;
		}

		// Token: 0x06009EF5 RID: 40693 RVA: 0x001FB508 File Offset: 0x001F9908
		public void SetDrugVisible(bool flag)
		{
			if (this.mComDrugTipsBar != null)
			{
				this.mComDrugTipsBar.CustomActive(flag);
			}
		}

		// Token: 0x06009EF6 RID: 40694 RVA: 0x001FB528 File Offset: 0x001F9928
		private void _setDungeonItem()
		{
			if (this.mComDrugTipsBar == null)
			{
				return;
			}
			this.mComDrugTipsBar.Init();
			BattleType battleType = BattleMain.battleType;
			switch (battleType)
			{
			case BattleType.GuildPVP:
			case BattleType.MoneyRewardsPVP:
			case BattleType.PVP3V3Battle:
			case BattleType.ScufflePVP:
			case BattleType.TrainingPVE:
			case BattleType.ChijiPVP:
			case BattleType.FinalTestBattle:
			case BattleType.AnniversaryPVE_III:
				break;
			case BattleType.ChampionMatch:
			case BattleType.GuildPVE:
				goto IL_98;
			default:
				switch (battleType)
				{
				case BattleType.Single:
				case BattleType.MutiPlayer:
				case BattleType.DeadTown:
				case BattleType.Training:
					break;
				case BattleType.Dungeon:
					goto IL_98;
				case BattleType.Mou:
				case BattleType.North:
				case BattleType.NewbieGuide:
					return;
				default:
					return;
				}
				break;
			}
			this.mComDrugTipsBar.SetRootActive(false);
			return;
			IL_98:
			this.mComDrugTipsBar.SetRootActive(Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.BattleDrugs));
		}

		// Token: 0x06009EF7 RID: 40695 RVA: 0x001FB5E4 File Offset: 0x001F99E4
		public void UseDrug()
		{
		}

		// Token: 0x06009EF8 RID: 40696 RVA: 0x001FB5E8 File Offset: 0x001F99E8
		private void RemoveClearTip()
		{
			GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "CommonSysDungeonAnimation2", false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x06009EF9 RID: 40697 RVA: 0x001FB620 File Offset: 0x001F9A20
		public void ShowBossWarning()
		{
			this.RemoveClearTip();
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/TipBossAnimation", true, 0U);
			gameObject.name = "TipBossAnimation";
			AutoCloseBattle component = gameObject.GetComponent<AutoCloseBattle>();
			if (component != null)
			{
				component.SetCloseTime(2f);
			}
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			MonoSingleton<AudioManager>.instance.PlaySound(6);
		}

		// Token: 0x06009EFA RID: 40698 RVA: 0x001FB68C File Offset: 0x001F9A8C
		public void ShowTreasureBossWarning()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/TipBossAnimation", true, 0U);
			gameObject.name = "TipBossAnimation";
			AutoCloseBattle component = gameObject.GetComponent<AutoCloseBattle>();
			if (component != null)
			{
				component.SetCloseTime(2f);
			}
			ComCommonBind component2 = gameObject.GetComponent<ComCommonBind>();
			if (component2 == null)
			{
				return;
			}
			GameObject gameObject2 = component2.GetGameObject("JinGao");
			if (!gameObject2.IsNull())
			{
				gameObject2.CustomActive(false);
			}
			GameObject gameObject3 = component2.GetGameObject("Jingao_add");
			if (!gameObject3.IsNull())
			{
				gameObject3.CustomActive(false);
			}
			GameObject gameObject4 = component2.GetGameObject("Jingao_1");
			if (!gameObject4.IsNull())
			{
				gameObject4.CustomActive(true);
			}
			GameObject gameObject5 = component2.GetGameObject("Jingao_add_1");
			if (!gameObject5.IsNull())
			{
				gameObject5.CustomActive(true);
			}
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			MonoSingleton<AudioManager>.instance.PlaySound(6);
		}

		// Token: 0x06009EFB RID: 40699 RVA: 0x001FB786 File Offset: 0x001F9B86
		public void CloseProfessionFrame()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<BattleProfessionFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<BattleProfessionFrame>(null, false);
			}
		}

		// Token: 0x06009EFC RID: 40700 RVA: 0x001FB7A4 File Offset: 0x001F9BA4
		public void SetSilverBulletNum(int skillId, int num, SpecialBulletType type)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetSilverBulletNum(skillId, num, type);
			}
		}

		// Token: 0x06009EFD RID: 40701 RVA: 0x001FB7C8 File Offset: 0x001F9BC8
		public void SetBuffNum(int num)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetBuffNum(num);
			}
		}

		// Token: 0x06009EFE RID: 40702 RVA: 0x001FB7EC File Offset: 0x001F9BEC
		public void SetComboBuffNum(int num, float progress)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetComboBuffNum(num, progress);
			}
		}

		// Token: 0x06009EFF RID: 40703 RVA: 0x001FB810 File Offset: 0x001F9C10
		public void SetSkillUseCount(int skillId, int num, string path)
		{
			num = ((num >= 0) ? num : 0);
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetSkillUseCount(skillId, num, path);
			}
		}

		// Token: 0x06009F00 RID: 40704 RVA: 0x001FB844 File Offset: 0x001F9C44
		public void SetShengQiBeiDongBuff(int index, int curNum, int maxNum)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetShengQiBeiDongBuff(index, curNum, maxNum);
			}
		}

		// Token: 0x06009F01 RID: 40705 RVA: 0x001FB868 File Offset: 0x001F9C68
		public void InitNvDaQiangEnergyBar(int n)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.InitNvDaQiangEnergyBar(n);
			}
		}

		// Token: 0x06009F02 RID: 40706 RVA: 0x001FB88C File Offset: 0x001F9C8C
		public void SetNvDaQiangEnergyBar(int times)
		{
			BattleProfessionFrame battleProfessionFrame = this.CreateBattleProfessionFrame();
			if (battleProfessionFrame != null)
			{
				battleProfessionFrame.SetNvDaQiangEnergyBar(times);
			}
		}

		// Token: 0x06009F03 RID: 40707 RVA: 0x001FB8B0 File Offset: 0x001F9CB0
		private BattleProfessionFrame CreateBattleProfessionFrame()
		{
			BattleProfessionFrame battleProfessionFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(BattleProfessionFrame)) as BattleProfessionFrame;
			if (battleProfessionFrame == null)
			{
				battleProfessionFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<BattleProfessionFrame>(FrameLayer.Middle, null, string.Empty) as BattleProfessionFrame);
				Utility.AttachTo(battleProfessionFrame.GetFrame(), this.mProfessionInfo, false);
				if (!this.childFrameList.Contains(battleProfessionFrame))
				{
					this.childFrameList.Add(battleProfessionFrame);
				}
			}
			return battleProfessionFrame;
		}

		// Token: 0x06009F04 RID: 40708 RVA: 0x001FB924 File Offset: 0x001F9D24
		public void ShowDamageBar(bool isShow)
		{
			if (this.m_DamageBar == null)
			{
				this.m_DamageBar = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.m_DamageBarPath, true, 0U);
			}
			if (this.m_DamageBar != null && this.mBind != null)
			{
				Utility.AttachTo(this.m_DamageBar, this.mBind.gameObject, false);
				this.m_DamageBar.CustomActive(isShow);
			}
		}

		// Token: 0x06009F05 RID: 40709 RVA: 0x001FB9A0 File Offset: 0x001F9DA0
		public void ChangeDamageData(float current, float max, bool reverse = false)
		{
			if (this.m_DamageBar == null)
			{
				return;
			}
			ComCommonBind component = this.m_DamageBar.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (reverse)
			{
				current = max - current;
			}
			Slider com = component.GetCom<Slider>("Slider");
			if (com != null)
			{
				com.value = current / max;
			}
			string arg = (current / 10000f).ToString("#0.0");
			string arg2 = (max / 10000f).ToString("#0.0");
			string text = string.Format("{0}W/{1}W", arg, arg2);
			Text com2 = component.GetCom<Text>("DamageValue");
			if (com2 != null)
			{
				com2.text = text;
			}
		}

		// Token: 0x06009F06 RID: 40710 RVA: 0x001FBA64 File Offset: 0x001F9E64
		public void ChangeCountDown(int countTime)
		{
			if (this.m_DamageBar == null)
			{
				return;
			}
			ComCommonBind component = this.m_DamageBar.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("CountDown");
			if (com == null)
			{
				return;
			}
			com.text = countTime.ToString();
		}

		// Token: 0x06009F07 RID: 40711 RVA: 0x001FBAC8 File Offset: 0x001F9EC8
		public void PlayCharacterAni(bool faceLeft, string prefabPath, int removeDelay)
		{
			GameObject characterAni = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
			if (characterAni != null)
			{
				Utility.AttachTo(characterAni, Singleton<ClientSystemManager>.instance.GetLayer(FrameLayer.TopMost), false);
				ComCommonBind component = characterAni.GetComponent<ComCommonBind>();
				if (component != null)
				{
					component.GetCom<Image>("Left").CustomActive(!faceLeft);
					component.GetCom<Image>("Right").CustomActive(faceLeft);
				}
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(removeDelay, delegate
				{
					Object.Destroy(characterAni);
				}, 0, 0, false);
			}
		}

		// Token: 0x06009F08 RID: 40712 RVA: 0x001FBB74 File Offset: 0x001F9F74
		protected void SetUI3DRoot(bool isPvp)
		{
			if (Singleton<ClientSystemManager>.GetInstance() != null)
			{
				RectTransform component = Singleton<ClientSystemManager>.GetInstance().Layer3DRoot.GetComponent<RectTransform>();
				Vector3 localPosition = component.localPosition;
				component.localPosition = ((!isPvp) ? new Vector3(localPosition.x, localPosition.y, -1f) : new Vector3(localPosition.x, localPosition.y, -6.5f));
			}
		}

		// Token: 0x06009F09 RID: 40713 RVA: 0x001FBBE3 File Offset: 0x001F9FE3
		public void HideFightingTime()
		{
			if (this.mFightingTimeRoot == null)
			{
				return;
			}
			this.mFightingTimeRoot.CustomActive(false);
		}

		// Token: 0x06009F0A RID: 40714 RVA: 0x001FBC04 File Offset: 0x001FA004
		protected void InitTrainingPveBattle()
		{
			if (BattleMain.instance == null)
			{
				return;
			}
			this._hiddenTimer();
			TrainingPVEBattle trainingPVEBattle = BattleMain.instance.GetBattle() as TrainingPVEBattle;
			if (trainingPVEBattle == null)
			{
				return;
			}
			trainingPVEBattle.Init();
		}

		// Token: 0x06009F0B RID: 40715 RVA: 0x001FBC40 File Offset: 0x001FA040
		protected void SaveSkillDamageData()
		{
			if (BattleMain.instance == null || BattleMain.instance.GetPlayerManager() == null || BattleMain.instance.GetPlayerManager().GetMainPlayer() == null)
			{
				return;
			}
			if (BattleMain.IsModePvP(BattleMain.battleType))
			{
				return;
			}
			BeActor playerActor = BattleMain.instance.GetPlayerManager().GetMainPlayer().playerActor;
			string dungeonName = BeUtility.GetDungeonName();
			if (playerActor == null)
			{
				return;
			}
			if (playerActor.skillDamageManager != null)
			{
				playerActor.skillDamageManager.SaveSkillDamageData(playerActor, dungeonName);
			}
		}

		// Token: 0x06009F0C RID: 40716 RVA: 0x001FBCC8 File Offset: 0x001FA0C8
		private void CloseChildFrameList()
		{
			for (int i = 0; i < this.childFrameList.Count; i++)
			{
				if (this.childFrameList[i] != null)
				{
					this.childFrameList[i].Close(false);
				}
			}
			this.childFrameList.Clear();
		}

		// Token: 0x06009F0D RID: 40717 RVA: 0x001FBD20 File Offset: 0x001FA120
		private void _CheckRedPacketFrame()
		{
			if (BattleMain.IsModePvP(BattleMain.battleType))
			{
				return;
			}
			if (DataManager<RedPackDataManager>.GetInstance() == null)
			{
				return;
			}
			int waitOpenCount = DataManager<RedPackDataManager>.GetInstance().GetWaitOpenCount();
			if (waitOpenCount <= 0)
			{
				return;
			}
			Singleton<ClientSystemManager>.instance.OpenFrame<BattleRedPacketFrame>(FrameLayer.Bottom, null, string.Empty);
		}

		// Token: 0x04005717 RID: 22295
		protected string[] m_IconPath = new string[]
		{
			"UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_Zhandou_Huangzhuang_Text_03",
			"UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_Zhandou_Huangzhuang_Text_01"
		};

		// Token: 0x04005718 RID: 22296
		private ComCountScript m_countScirpt;

		// Token: 0x04005719 RID: 22297
		private GameObject mTimerRoot;

		// Token: 0x0400571A RID: 22298
		private GameObject mLeftPKRoot;

		// Token: 0x0400571B RID: 22299
		private GameObject mRightPKRoot;

		// Token: 0x0400571C RID: 22300
		private static SimpleTimer mTimerController;

		// Token: 0x0400571D RID: 22301
		private GameObject mAutoFightRootObj;

		// Token: 0x0400571E RID: 22302
		private GameObject mChatRoot;

		// Token: 0x0400571F RID: 22303
		private GameObject mProfessionInfo;

		// Token: 0x04005720 RID: 22304
		private GameObject mBossBarRoot;

		// Token: 0x04005721 RID: 22305
		private Button mBtnWatchLeft;

		// Token: 0x04005722 RID: 22306
		private Button mBtnWatchRight;

		// Token: 0x04005723 RID: 22307
		private Button mPvp3v3Button;

		// Token: 0x04005724 RID: 22308
		private GameObject mPvp3v3RightPendingRoot;

		// Token: 0x04005725 RID: 22309
		private GameObject mPvp3v3LeftPendingRoot;

		// Token: 0x04005726 RID: 22310
		private GameObject mPvp3v3FightOn;

		// Token: 0x04005727 RID: 22311
		private GameObject mPvp3v3FightOff;

		// Token: 0x04005728 RID: 22312
		private Button mPvp3v3MicBtn;

		// Token: 0x04005729 RID: 22313
		private Image mPvp3v3MicBtnBg;

		// Token: 0x0400572A RID: 22314
		private Image mPvp3v3MicBtnClose;

		// Token: 0x0400572B RID: 22315
		private Button mPvp3v3PlayerBtn;

		// Token: 0x0400572C RID: 22316
		private Image mPvp3v3PlayerBtnBg;

		// Token: 0x0400572D RID: 22317
		private Image mPvp3v3PlayerBtnClose;

		// Token: 0x0400572E RID: 22318
		private ComTimeLimitButton mPvp3v3TimeLimitButton;

		// Token: 0x0400572F RID: 22319
		private GameObject mTeamVoiceBtnGo;

		// Token: 0x04005730 RID: 22320
		private VoiceInputBtn mTeamVoiceBtn;

		// Token: 0x04005731 RID: 22321
		private Button mBtnChangeWeapon;

		// Token: 0x04005732 RID: 22322
		private Image weaponIcon;

		// Token: 0x04005733 RID: 22323
		private Image weaponBack;

		// Token: 0x04005734 RID: 22324
		private CDCoolDowm cdCoolDowm;

		// Token: 0x04005735 RID: 22325
		private ComDungeonScore mFightingTimeRoot;

		// Token: 0x04005736 RID: 22326
		private GameObject mVanityBonusBuffConent;

		// Token: 0x04005737 RID: 22327
		private Image mVanityBonusBuffIcon;

		// Token: 0x04005738 RID: 22328
		private GameObject mRebornInfoRoot;

		// Token: 0x04005739 RID: 22329
		private Text mRebornDesc;

		// Token: 0x0400573A RID: 22330
		private Text mRobotInfo;

		// Token: 0x0400573B RID: 22331
		private RectTransform mSwitchEquips;

		// Token: 0x0400573C RID: 22332
		private CDCoolDowm mSwitchEquipCD;

		// Token: 0x0400573D RID: 22333
		private Image mSwitchEquipIcon;

		// Token: 0x0400573E RID: 22334
		private Button mSwitchEquipsBtn;

		// Token: 0x0400573F RID: 22335
		private ComVoiceTalkRootGroup mVoiceTalkRoots;

		// Token: 0x04005740 RID: 22336
		private UIEventNew.UIEventHandleNew m_HidePauseBtnHandler;

		// Token: 0x04005741 RID: 22337
		private UIEventNew.UIEventHandleNew m_CountDownStartHandler;

		// Token: 0x04005742 RID: 22338
		private UIEventNew.UIEventHandleNew m_CountDownUpdateHandler;

		// Token: 0x04005743 RID: 22339
		private SimpleTimer m_CountDownTimer;

		// Token: 0x04005744 RID: 22340
		private GameObject mPVPReport;

		// Token: 0x04005745 RID: 22341
		private Button mReportBtn;

		// Token: 0x04005746 RID: 22342
		private static Text pingText;

		// Token: 0x04005747 RID: 22343
		[UIControl("TestInfo", null, 0)]
		private Text testInfo;

		// Token: 0x04005748 RID: 22344
		[UIObject("DungeonMap/CountRoot/Button")]
		private GameObject mbuttonObject;

		// Token: 0x04005749 RID: 22345
		[UIObject("ArrowLeft")]
		private GameObject mArrowLeft;

		// Token: 0x0400574A RID: 22346
		[UIObject("ArrowRight")]
		private GameObject mArrowRight;

		// Token: 0x0400574B RID: 22347
		[UIObject("ArrowLeftGo")]
		private GameObject mArrowLeftGo;

		// Token: 0x0400574C RID: 22348
		[UIObject("ArrowRightGo")]
		private GameObject mArrowRightGo;

		// Token: 0x0400574D RID: 22349
		[UIObject("BlindMask")]
		private GameObject mBlindMask;

		// Token: 0x0400574E RID: 22350
		[UIControl("TipsBar", typeof(Image), 0)]
		private Image mTipsBar;

		// Token: 0x0400574F RID: 22351
		[UIControl("Exp", typeof(ComExpBar), 0)]
		private ComExpBar mExpBar;

		// Token: 0x04005750 RID: 22352
		[UIObject("PlayerInfos")]
		private GameObject mPlayerSelfInfo;

		// Token: 0x04005751 RID: 22353
		[UIControl("DungeonMap/RScore", typeof(ComDungeonScore), 0)]
		private ComDungeonScore mDungeonScore;

		// Token: 0x04005752 RID: 22354
		[UIObject("DungeonMap/TextRoot")]
		private GameObject goTextRoot;

		// Token: 0x04005753 RID: 22355
		[UIControl("DeadTower/Level", typeof(Text), 0)]
		private Text textDeadTowerLevel;

		// Token: 0x04005754 RID: 22356
		[UIControl("ChampionMatch/Name", typeof(Text), 0)]
		private Text textChampionMatch;

		// Token: 0x04005755 RID: 22357
		[UIControl("MuscleShift/Text", typeof(Text), 0)]
		private Text textMuscleShift;

		// Token: 0x04005756 RID: 22358
		[UIControl("MuscleShift/CD", typeof(Image), 0)]
		private Image imageMuscleShift;

		// Token: 0x04005757 RID: 22359
		[UIObject("MuscleShift/Icon")]
		private GameObject iconMuscleShift;

		// Token: 0x04005758 RID: 22360
		[UIControl("AutoFight", typeof(Toggle), 0)]
		private Toggle autoFight;

		// Token: 0x04005759 RID: 22361
		[UIObject("PVPReplay")]
		private GameObject goReplay;

		// Token: 0x0400575A RID: 22362
		[UIControl("PVPReplay/buttonReturn", typeof(Button), 0)]
		private Button btnReplayReturn;

		// Token: 0x0400575B RID: 22363
		[UIControl("PVPReplay/buttonPlaySpeed", typeof(Button), 0)]
		private Button btnReplaySpeed;

		// Token: 0x0400575C RID: 22364
		[UIControl("PVPReplay/buttonPlaySpeed/Text", typeof(Text), 0)]
		private Text txtSpeedDesc;

		// Token: 0x0400575D RID: 22365
		[UIControl("PVPReplay/buttonPause", typeof(Button), 0)]
		private Button btnReplayPause;

		// Token: 0x0400575E RID: 22366
		[UIControl("PVPReplay/buttonResume", typeof(Button), 0)]
		private Button btnReplayResume;

		// Token: 0x0400575F RID: 22367
		[UIObject("PVPTrain")]
		private GameObject goTrain;

		// Token: 0x04005760 RID: 22368
		[UIControl("PVPTrain/buttonReturn", typeof(Button), 0)]
		private Button btnTrainReturn;

		// Token: 0x04005761 RID: 22369
		[UIControl("PVPTrain/buttonReset", typeof(Button), 0)]
		private Button btnTrainReset;

		// Token: 0x04005762 RID: 22370
		[UIObject("tmpButton1")]
		private GameObject goTmpBun1;

		// Token: 0x04005763 RID: 22371
		[UIObject("tmpButton2")]
		private GameObject goTmpBun2;

		// Token: 0x04005764 RID: 22372
		private TeamDuplicationVoiceTalk tdVoiceTalk;

		// Token: 0x04005765 RID: 22373
		[UIObject("DungeonMap/CountRoot/realMircoBtn")]
		private GameObject realMircoBtn;

		// Token: 0x04005766 RID: 22374
		[UIControl("DungeonMap/CountRoot/realMircoBtn/onOffImage", typeof(Image), 0)]
		private Image onOffImage;

		// Token: 0x04005767 RID: 22375
		[UIObject("DungeonMap/CountRoot/realPlayerBtn")]
		private GameObject realPlayerBtn;

		// Token: 0x04005768 RID: 22376
		[UIControl("DungeonMap/CountRoot/realPlayerBtn/openCloseImage", typeof(Image), 0)]
		private Image openCloseImage;

		// Token: 0x04005769 RID: 22377
		private VoiceChatModule voiceChatModule;

		// Token: 0x0400576A RID: 22378
		private bool canTrainReset = true;

		// Token: 0x0400576B RID: 22379
		private GameObject autoFightEffect;

		// Token: 0x0400576C RID: 22380
		private UIGray muscleShiftGray;

		// Token: 0x0400576D RID: 22381
		private ulong previousExp;

		// Token: 0x0400576E RID: 22382
		private int previousLevel;

		// Token: 0x0400576F RID: 22383
		public BeActionManager simpleActionManager = new BeActionManager();

		// Token: 0x04005770 RID: 22384
		public DebugBattleStatisCompnent comDebugBattleStatis = new DebugBattleStatisCompnent();

		// Token: 0x04005771 RID: 22385
		public ShowHitComponent comShowHit = new ShowHitComponent();

		// Token: 0x04005772 RID: 22386
		private List<ClientFrame> childFrameList = new List<ClientFrame>();

		// Token: 0x04005773 RID: 22387
		private int autoFightAcc;

		// Token: 0x04005774 RID: 22388
		private int AUTOFIGHT_RESTORE_INTERVAL = 2000;

		// Token: 0x04005775 RID: 22389
		private bool checkRestoreAutoFight;

		// Token: 0x04005776 RID: 22390
		private bool mBVanityBonusBuff;

		// Token: 0x04005777 RID: 22391
		private bool mBChaosAdditionBuff;

		// Token: 0x04005778 RID: 22392
		private GameObject objCanvasComboText;

		// Token: 0x04005779 RID: 22393
		private ComboCount comboCountComp;

		// Token: 0x0400577A RID: 22394
		[UIControl("DungeonMap", typeof(ComDungeonMap), 0)]
		private ComDungeonMap mDungeonMapCom;

		// Token: 0x0400577B RID: 22395
		private GameObject objFlashWhite;

		// Token: 0x0400577C RID: 22396
		private GameObject goDebug;

		// Token: 0x0400577D RID: 22397
		[UIObject("Canxue")]
		private GameObject mDeadTips;

		// Token: 0x0400577E RID: 22398
		public static bool bNeedOpenTeamFrame;

		// Token: 0x0400577F RID: 22399
		private List<ClientSystemBattle.PVP3V3Unit> mPVP3V3Units = new List<ClientSystemBattle.PVP3V3Unit>();

		// Token: 0x04005780 RID: 22400
		private bool mIsInit3v3AllPendingCharactor;

		// Token: 0x04005781 RID: 22401
		private float mTimeTick;

		// Token: 0x04005782 RID: 22402
		private const float kUITick = 0.5f;

		// Token: 0x04005783 RID: 22403
		private float timer;

		// Token: 0x04005784 RID: 22404
		private float mBChaosAdditionTimer;

		// Token: 0x04005785 RID: 22405
		protected float fpsAcc;

		// Token: 0x04005786 RID: 22406
		protected float time;

		// Token: 0x04005787 RID: 22407
		private uint savedRandCallNum;

		// Token: 0x04005788 RID: 22408
		[UIControl("DungeonDrugTips", typeof(ComDrugTipsBar), 0)]
		private ComDrugTipsBar mComDrugTipsBar;

		// Token: 0x04005789 RID: 22409
		protected string m_DamageBarPath = "UIFlatten/Prefabs/BattleUI/DamageValueBar";

		// Token: 0x0400578A RID: 22410
		protected GameObject m_DamageBar;

		// Token: 0x02001071 RID: 4209
		private class PVP3V3Unit
		{
			// Token: 0x04005796 RID: 22422
			public byte seat;

			// Token: 0x04005797 RID: 22423
			public ComPVP3V3PendingCharactor com;
		}
	}
}
