using System;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Settings
{
	// Token: 0x02001A18 RID: 6680
	public class BattleRunCtrlSettings : SettingsBindUI
	{
		// Token: 0x06010674 RID: 67188 RVA: 0x0049CB76 File Offset: 0x0049AF76
		public BattleRunCtrlSettings(GameObject root, ClientFrame frame) : base(root, frame)
		{
		}

		// Token: 0x06010675 RID: 67189 RVA: 0x0049CB80 File Offset: 0x0049AF80
		protected override string GetCurrGameObjectPath()
		{
			return "UIRoot/UI2DRoot/Middle/SettingPanel/Panel/Contents/battleCtrl";
		}

		// Token: 0x06010676 RID: 67190 RVA: 0x0049CB88 File Offset: 0x0049AF88
		protected override void InitBind()
		{
			this.dragRun = this.mBind.GetCom<Toggle>("DragRun");
			this.dragRun.onValueChanged.AddListener(new UnityAction<bool>(this.OnDragRunChange));
			this.doubleRun = this.mBind.GetCom<Toggle>("DoubleRun");
			this.doubleRun.onValueChanged.AddListener(new UnityAction<bool>(this.OnDoubleRunChange));
			this.dragCheckImg = this.mBind.GetCom<Image>("DragBgCheckImg");
			this.doubleCheckImg = this.mBind.GetCom<Image>("DoubleBgCheckImh");
			this.dragRunVideo = this.mBind.GetCom<MediaPlayerCtrl>("DragRunVideo");
			this.doubleRunVideo = this.mBind.GetCom<MediaPlayerCtrl>("DoubleRunVideo");
			this.mJoystickMode1 = this.mBind.GetCom<Toggle>("joystickMode1");
			this.mJoystickMode1.onValueChanged.AddListener(new UnityAction<bool>(this._onJoystickMode1ToggleValueChange));
			this.mJoystickMode2 = this.mBind.GetCom<Toggle>("joystickMode2");
			this.mJoystickMode2.onValueChanged.AddListener(new UnityAction<bool>(this._onJoystickMode2ToggleValueChange));
			this.mJoystickMoreDir = this.mBind.GetCom<Toggle>("mJoystickMoreDir");
			this.mJoystickMoreDir.onValueChanged.AddListener(new UnityAction<bool>(this._onJoystickMoreDirToggleValueChange));
			this.mJoystick8Dir = this.mBind.GetCom<Toggle>("mJoystick8Dir");
			this.mJoystick8Dir.onValueChanged.AddListener(new UnityAction<bool>(this._onJoystick8DirToggleValueChange));
			this.joystick8Dir = this.mBind.GetGameObject("joystick8Dir");
			this.mRunAttackMode1 = this.mBind.GetCom<Toggle>("runAttackMode1");
			this.mRunAttackMode1.onValueChanged.AddListener(new UnityAction<bool>(this._onRunAttackMode1ToggleValueChange));
			this.mRunAttackMode2 = this.mBind.GetCom<Toggle>("runAttackMode2");
			this.mRunAttackMode2.onValueChanged.AddListener(new UnityAction<bool>(this._onRunAttackMode2ToggleValueChange));
			this.mGrenadeSlideClose = this.mBind.GetCom<Toggle>("grenadeSlideClose");
			this.mGrenadeSlideClose.onValueChanged.AddListener(new UnityAction<bool>(this._onGrenadeSlideCloseToggleValueChange));
			this.mGrenadeSlideOpen = this.mBind.GetCom<Toggle>("grenadeSlideOpen");
			this.mGrenadeSlideOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onGrenadeSlideOpenToggleValueChange));
			this.mMachineGunSlideClose = this.mBind.GetCom<Toggle>("machineGunSlideClose");
			this.mMachineGunSlideClose.onValueChanged.AddListener(new UnityAction<bool>(this._onMachineGunSlideCloseToggleValueChange));
			this.mMachineGunSlideOpen = this.mBind.GetCom<Toggle>("machineGunSlideOpen");
			this.mMachineGunSlideOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onMachineGunSlideOpenToggleValueChange));
			this.mTanjiSlideClose = this.mBind.GetCom<Toggle>("TanjiSlideClose");
			this.mTanjiSlideClose.onValueChanged.AddListener(new UnityAction<bool>(this._onTanjiSlideCloseToggleValueChange));
			this.mTanjiSlideOpen = this.mBind.GetCom<Toggle>("TanjiSlideOpen");
			this.mTanjiSlideOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onTanjiSlideOpenToggleValueChange));
			this.mBengshanjiClose = this.mBind.GetCom<Toggle>("BengshanjiClose");
			this.mBengshanjiClose.onValueChanged.AddListener(new UnityAction<bool>(this._onBengshanjiCloseToggleValueChange));
			this.mBengshanjiOpen = this.mBind.GetCom<Toggle>("BengshanjiOpen");
			this.mBengshanjiOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onBengshanjiOpenToggleValueChange));
			this.mGrenadeSetting = this.mBind.GetCom<RectTransform>("GrenadeSetting");
			this.mMachineGunSetting = this.mBind.GetCom<RectTransform>("MachineGunSetting");
			this.mTianjiSetting = this.mBind.GetCom<RectTransform>("TianjiSetting");
			this.mBengshanjiSetting = this.mBind.GetCom<RectTransform>("BengshanjiSetting");
			this.mSlideTitle = this.mBind.GetCom<RectTransform>("SlideTitle");
			this.mSlideSetting = this.mBind.GetCom<RectTransform>("SlideSetting");
			this.mGrenadeName = this.mBind.GetCom<Text>("GrenadeName");
			this.mGrenadeDsc = this.mBind.GetCom<Text>("GrenadeDsc");
			this.mMachineGunName = this.mBind.GetCom<Text>("MachineGunName");
			this.mMachineGunDsc = this.mBind.GetCom<Text>("MachineGunDsc");
			this.mTianJiName = this.mBind.GetCom<Text>("TianJiName");
			this.mTianJiDsc = this.mBind.GetCom<Text>("TianJiDsc");
			this.mBengshanjiName = this.mBind.GetCom<Text>("BengshanjiName");
			this.mBengshanjiDsc = this.mBind.GetCom<Text>("BengshanjiDsc");
			this.mLiguiClose = this.mBind.GetCom<Toggle>("LiguiClose");
			this.mLiguiClose.onValueChanged.AddListener(new UnityAction<bool>(this._onLiguiCloseToggleValueChange));
			this.mLiguiOpen = this.mBind.GetCom<Toggle>("LiguiOpen");
			this.mLiguiOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onLiguiOpenToggleValueChange));
			this.mLiguiSetting = this.mBind.GetCom<RectTransform>("LiguiSetting");
			this.mBackHitClose = this.mBind.GetCom<Toggle>("BackHitClose");
			this.mBackHitClose.onValueChanged.AddListener(new UnityAction<bool>(this._onBackHitCloseToggleValueChange));
			this.mBackHitOpen = this.mBind.GetCom<Toggle>("BackHitOpen");
			this.mBackHitOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onBackHitOpenToggleValueChange));
			this.mBackHitSetting = this.mBind.GetCom<RectTransform>("BackHitSetting");
			this.mAutoHitClose = this.mBind.GetCom<Toggle>("AutoHitClose");
			this.mAutoHitClose.onValueChanged.AddListener(new UnityAction<bool>(this._onAutoHitCloseToggleValueChange));
			this.mAutoHitOpen = this.mBind.GetCom<Toggle>("AutoHitOpen");
			this.mAutoHitOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onAutoHitOpenToggleValueChange));
			this.mAutoHitSetting = this.mBind.GetCom<RectTransform>("AutoHitSetting");
			this.mPoMoFuName = this.mBind.GetCom<Text>("PoMoFuName");
			this.mPoMoFuDsc = this.mBind.GetCom<Text>("PoMoFuDsc");
			this.mXingLuoDaName = this.mBind.GetCom<Text>("XingLuoDaName");
			this.mXingLuoDaDsc = this.mBind.GetCom<Text>("XingLuoDaDsc");
			this.mPoMoFuOpen = this.mBind.GetCom<Toggle>("PoMoFuOpen");
			if (null != this.mPoMoFuOpen)
			{
				this.mPoMoFuOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onPoMoFuOpenToggleValueChange));
			}
			this.mPoMoFuClose = this.mBind.GetCom<Toggle>("PoMoFuClose");
			if (null != this.mPoMoFuClose)
			{
				this.mPoMoFuClose.onValueChanged.AddListener(new UnityAction<bool>(this._onPoMoFuCloseToggleValueChange));
			}
			this.mPoMoFuSetting = this.mBind.GetCom<RectTransform>("PoMoFuSetting");
			this.mXingLuoDaOpen = this.mBind.GetCom<Toggle>("XingLuoDaOpen");
			if (null != this.mXingLuoDaOpen)
			{
				this.mXingLuoDaOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onXingLuoDaOpenToggleValueChange));
			}
			this.mXingLuoDaClose = this.mBind.GetCom<Toggle>("XingLuoDaClose");
			if (null != this.mXingLuoDaClose)
			{
				this.mXingLuoDaClose.onValueChanged.AddListener(new UnityAction<bool>(this._onXingLuoDaCloseToggleValueChange));
			}
			this.mXingLuoDaSetting = this.mBind.GetCom<RectTransform>("XingLuoDaSetting");
			this.mPaladinAttack = this.mBind.GetCom<RectTransform>("PaladinAttack");
			this.mPaladinAttackClose = this.mBind.GetCom<Toggle>("PaladinAttackClose");
			if (null != this.mPaladinAttackClose)
			{
				this.mPaladinAttackClose.onValueChanged.AddListener(new UnityAction<bool>(this._onPaladinAttackCloseToggleValueChange));
			}
			this.mPaladinAttackOpen = this.mBind.GetCom<Toggle>("PaladinAttackOpen");
			if (null != this.mPaladinAttackOpen)
			{
				this.mPaladinAttackOpen.onValueChanged.AddListener(new UnityAction<bool>(this._onPaladinAttackOpenToggleValueChange));
			}
		}

		// Token: 0x06010677 RID: 67191 RVA: 0x0049D3F4 File Offset: 0x0049B7F4
		protected override void UnInitBind()
		{
			if (this.dragRun != null)
			{
				this.dragRun.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnDragRunChange));
			}
			this.dragRun = null;
			if (this.doubleRun != null)
			{
				this.doubleRun.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnDoubleRunChange));
			}
			this.doubleRun = null;
			this.dragCheckImg = null;
			this.doubleCheckImg = null;
			this.dragRunVideo = null;
			this.doubleRunVideo = null;
			if (this.mJoystickMode1 != null)
			{
				this.mJoystickMode1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onJoystickMode1ToggleValueChange));
				this.mJoystickMode1 = null;
			}
			if (this.mJoystickMode2 != null)
			{
				this.mJoystickMode2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onJoystickMode2ToggleValueChange));
				this.mJoystickMode2 = null;
			}
			if (this.mRunAttackMode1 != null)
			{
				this.mRunAttackMode1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onRunAttackMode1ToggleValueChange));
				this.mRunAttackMode1 = null;
			}
			if (this.mRunAttackMode2 != null)
			{
				this.mRunAttackMode2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onRunAttackMode2ToggleValueChange));
				this.mRunAttackMode2 = null;
			}
			if (this.mGrenadeSlideClose != null)
			{
				this.mGrenadeSlideClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onGrenadeSlideCloseToggleValueChange));
				this.mGrenadeSlideClose = null;
			}
			if (this.mGrenadeSlideOpen != null)
			{
				this.mGrenadeSlideOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onGrenadeSlideOpenToggleValueChange));
				this.mGrenadeSlideOpen = null;
			}
			if (this.mMachineGunSlideClose != null)
			{
				this.mMachineGunSlideClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onMachineGunSlideCloseToggleValueChange));
				this.mMachineGunSlideClose = null;
			}
			if (this.mMachineGunSlideOpen != null)
			{
				this.mMachineGunSlideOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onMachineGunSlideOpenToggleValueChange));
				this.mMachineGunSlideOpen = null;
			}
			if (this.mTanjiSlideClose != null)
			{
				this.mTanjiSlideClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTanjiSlideCloseToggleValueChange));
				this.mTanjiSlideClose = null;
			}
			if (this.mTanjiSlideOpen != null)
			{
				this.mTanjiSlideOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onTanjiSlideOpenToggleValueChange));
				this.mTanjiSlideOpen = null;
			}
			if (this.mBengshanjiClose != null)
			{
				this.mBengshanjiClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onBengshanjiCloseToggleValueChange));
				this.mBengshanjiClose = null;
			}
			if (this.mBengshanjiOpen != null)
			{
				this.mBengshanjiOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onBengshanjiOpenToggleValueChange));
				this.mBengshanjiOpen = null;
			}
			this.mGrenadeSetting = null;
			this.mMachineGunSetting = null;
			this.mTianjiSetting = null;
			this.mBengshanjiSetting = null;
			this.mSlideTitle = null;
			this.mSlideSetting = null;
			this.mGrenadeName = null;
			this.mGrenadeDsc = null;
			this.mMachineGunName = null;
			this.mMachineGunDsc = null;
			this.mTianJiName = null;
			this.mTianJiDsc = null;
			this.mBengshanjiName = null;
			this.mBengshanjiDsc = null;
			if (this.mLiguiClose != null)
			{
				this.mLiguiClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onLiguiCloseToggleValueChange));
				this.mLiguiClose = null;
			}
			if (this.mLiguiOpen != null)
			{
				this.mLiguiOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onLiguiOpenToggleValueChange));
				this.mLiguiOpen = null;
			}
			this.mLiguiSetting = null;
			this.mPoMoFuName = null;
			this.mPoMoFuDsc = null;
			this.mXingLuoDaName = null;
			this.mXingLuoDaDsc = null;
			if (null != this.mPoMoFuOpen)
			{
				this.mPoMoFuOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPoMoFuOpenToggleValueChange));
			}
			this.mPoMoFuOpen = null;
			if (null != this.mPoMoFuClose)
			{
				this.mPoMoFuClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPoMoFuCloseToggleValueChange));
			}
			this.mPoMoFuClose = null;
			this.mPoMoFuSetting = null;
			if (null != this.mXingLuoDaOpen)
			{
				this.mXingLuoDaOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onXingLuoDaOpenToggleValueChange));
			}
			this.mXingLuoDaOpen = null;
			if (null != this.mXingLuoDaClose)
			{
				this.mXingLuoDaClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onXingLuoDaCloseToggleValueChange));
			}
			this.mXingLuoDaClose = null;
			this.mXingLuoDaSetting = null;
			this.mPaladinAttack = null;
			if (null != this.mPaladinAttackClose)
			{
				this.mPaladinAttackClose.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPaladinAttackCloseToggleValueChange));
			}
			this.mPaladinAttackClose = null;
			if (null != this.mPaladinAttackOpen)
			{
				this.mPaladinAttackOpen.onValueChanged.RemoveListener(new UnityAction<bool>(this._onPaladinAttackOpenToggleValueChange));
			}
			this.mPaladinAttackOpen = null;
		}

		// Token: 0x06010678 RID: 67192 RVA: 0x0049D92F File Offset: 0x0049BD2F
		private void _onJoystickMode1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickMode(InputManager.JoystickMode.DYNAMIC);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
			}
		}

		// Token: 0x06010679 RID: 67193 RVA: 0x0049D94D File Offset: 0x0049BD4D
		private void _onJoystickMode2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickMode(InputManager.JoystickMode.STATIC);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.STATIC);
			}
		}

		// Token: 0x0601067A RID: 67194 RVA: 0x0049D96B File Offset: 0x0049BD6B
		private void _onJoystickMoreDirToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickDir(InputManager.JoystickDir.MORE_DIR);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
			}
		}

		// Token: 0x0601067B RID: 67195 RVA: 0x0049D989 File Offset: 0x0049BD89
		private void _onJoystick8DirToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickDir(InputManager.JoystickDir.EIGHT_DIR);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
			}
		}

		// Token: 0x0601067C RID: 67196 RVA: 0x0049D9A7 File Offset: 0x0049BDA7
		private void _onRunAttackMode1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetRunAttackMode(InputManager.RunAttackMode.NORMAL);
			}
		}

		// Token: 0x0601067D RID: 67197 RVA: 0x0049D9BA File Offset: 0x0049BDBA
		private void _onRunAttackMode2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetRunAttackMode(InputManager.RunAttackMode.QTE);
			}
		}

		// Token: 0x0601067E RID: 67198 RVA: 0x0049D9CD File Offset: 0x0049BDCD
		private void _onSummonDisplayCloseToggleValueChange(bool changed)
		{
		}

		// Token: 0x0601067F RID: 67199 RVA: 0x0049D9CF File Offset: 0x0049BDCF
		private void _onSummonDisplayOpenToggleValueChange(bool changed)
		{
		}

		// Token: 0x06010680 RID: 67200 RVA: 0x0049D9D1 File Offset: 0x0049BDD1
		private void _onGrenadeSlideCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "1204");
			}
		}

		// Token: 0x06010681 RID: 67201 RVA: 0x0049D9E9 File Offset: 0x0049BDE9
		private void _onGrenadeSlideOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "1204");
			}
		}

		// Token: 0x06010682 RID: 67202 RVA: 0x0049DA01 File Offset: 0x0049BE01
		private void _onMachineGunSlideCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "1007");
			}
		}

		// Token: 0x06010683 RID: 67203 RVA: 0x0049DA19 File Offset: 0x0049BE19
		private void _onMachineGunSlideOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "1007");
			}
		}

		// Token: 0x06010684 RID: 67204 RVA: 0x0049DA31 File Offset: 0x0049BE31
		private void _onTanjiSlideCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "2010");
			}
		}

		// Token: 0x06010685 RID: 67205 RVA: 0x0049DA49 File Offset: 0x0049BE49
		private void _onTanjiSlideOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "2010");
			}
		}

		// Token: 0x06010686 RID: 67206 RVA: 0x0049DA61 File Offset: 0x0049BE61
		private void _onBengshanjiCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "1512");
			}
		}

		// Token: 0x06010687 RID: 67207 RVA: 0x0049DA79 File Offset: 0x0049BE79
		private void _onBengshanjiOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "1512");
			}
		}

		// Token: 0x06010688 RID: 67208 RVA: 0x0049DA91 File Offset: 0x0049BE91
		private void _onLiguiCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("SETTING_LIGUI", false);
				Singleton<GameStatisticManager>.GetInstance().DoStatSlideOperation(InfiniteSwordType.Close);
			}
		}

		// Token: 0x06010689 RID: 67209 RVA: 0x0049DAB4 File Offset: 0x0049BEB4
		private void _onLiguiOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("SETTING_LIGUI", true);
				Singleton<GameStatisticManager>.GetInstance().DoStatSlideOperation(InfiniteSwordType.Open);
			}
		}

		// Token: 0x0601068A RID: 67210 RVA: 0x0049DAD7 File Offset: 0x0049BED7
		private void _onBackHitCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("STR_BACKHIT", false);
			}
		}

		// Token: 0x0601068B RID: 67211 RVA: 0x0049DAEF File Offset: 0x0049BEEF
		private void _onBackHitOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("STR_BACKHIT", true);
			}
		}

		// Token: 0x0601068C RID: 67212 RVA: 0x0049DB07 File Offset: 0x0049BF07
		private void _onAutoHitCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("STR_AUTOHIT", false);
			}
		}

		// Token: 0x0601068D RID: 67213 RVA: 0x0049DB1F File Offset: 0x0049BF1F
		private void _onAutoHitOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetValue("STR_AUTOHIT", true);
			}
		}

		// Token: 0x0601068E RID: 67214 RVA: 0x0049DB37 File Offset: 0x0049BF37
		private void _onPoMoFuOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "3600");
			}
		}

		// Token: 0x0601068F RID: 67215 RVA: 0x0049DB4F File Offset: 0x0049BF4F
		private void _onPoMoFuCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "3600");
			}
		}

		// Token: 0x06010690 RID: 67216 RVA: 0x0049DB67 File Offset: 0x0049BF67
		private void _onXingLuoDaOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, "3608");
			}
		}

		// Token: 0x06010691 RID: 67217 RVA: 0x0049DB7F File Offset: 0x0049BF7F
		private void _onXingLuoDaCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, "3608");
			}
		}

		// Token: 0x06010692 RID: 67218 RVA: 0x0049DB97 File Offset: 0x0049BF97
		private void _onPaladinAttackCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetPaladinAttack(InputManager.PaladinAttack.CLOSE);
			}
		}

		// Token: 0x06010693 RID: 67219 RVA: 0x0049DBAA File Offset: 0x0049BFAA
		private void _onPaladinAttackOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetPaladinAttack(InputManager.PaladinAttack.OPEN);
			}
		}

		// Token: 0x06010694 RID: 67220 RVA: 0x0049DBC0 File Offset: 0x0049BFC0
		protected void InitJoystickSelect()
		{
			this.mJoystickMode1.isOn = false;
			this.mJoystickMode2.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetJoystickMode() == InputManager.JoystickMode.DYNAMIC)
			{
				this.mJoystickMode1.isOn = true;
			}
			else
			{
				this.mJoystickMode2.isOn = true;
			}
		}

		// Token: 0x06010695 RID: 67221 RVA: 0x0049DC14 File Offset: 0x0049C014
		protected void InitJoystickDir()
		{
			this.joystick8Dir.CustomActive(SwitchFunctionUtility.IsOpen(29));
			this.mJoystickMoreDir.isOn = false;
			this.mJoystick8Dir.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetJoystickDir() == InputManager.JoystickDir.MORE_DIR)
			{
				this.mJoystickMoreDir.isOn = true;
			}
			else
			{
				this.mJoystick8Dir.isOn = true;
			}
		}

		// Token: 0x06010696 RID: 67222 RVA: 0x0049DC78 File Offset: 0x0049C078
		protected void InitRunAttackSelect()
		{
			this.mRunAttackMode1.isOn = false;
			this.mRunAttackMode2.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetRunAttackMode() == InputManager.RunAttackMode.NORMAL)
			{
				this.mRunAttackMode1.isOn = true;
			}
			else
			{
				this.mRunAttackMode2.isOn = true;
			}
		}

		// Token: 0x06010697 RID: 67223 RVA: 0x0049DCCC File Offset: 0x0049C0CC
		protected void InitPaladinAttack()
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(41, string.Empty, string.Empty);
			bool flag = tableItem != null && tableItem.Open;
			this.mPaladinAttack.gameObject.CustomActive(DataManager<PlayerBaseData>.GetInstance().JobTableID == 61 && flag);
			this.mPaladinAttackClose.isOn = false;
			this.mPaladinAttackOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetPaladinAttack() == InputManager.PaladinAttack.OPEN)
			{
				this.mPaladinAttackOpen.isOn = true;
			}
			else
			{
				this.mPaladinAttackClose.isOn = true;
			}
		}

		// Token: 0x06010698 RID: 67224 RVA: 0x0049DD6C File Offset: 0x0049C16C
		protected void InitSlideSetting()
		{
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(17, string.Empty, string.Empty);
			SwitchClientFunctionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(18, string.Empty, string.Empty);
			SwitchClientFunctionTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(19, string.Empty, string.Empty);
			SwitchClientFunctionTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(20, string.Empty, string.Empty);
			SwitchClientFunctionTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(36, string.Empty, string.Empty);
			SwitchClientFunctionTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(37, string.Empty, string.Empty);
			this.mPoMoFuName.text = tableItem5.DescA;
			this.mPoMoFuDsc.text = tableItem5.DescB;
			this.mXingLuoDaName.text = tableItem6.DescA;
			this.mXingLuoDaDsc.text = tableItem6.DescB;
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			bool open = tableItem4.Open;
			bool flag = (this.CanSlideSetting(1204) || this.CanSlideSetting(2507)) && open;
			if (flag)
			{
				this.InitGrenadeSlideSelect();
			}
			this.mGrenadeSetting.gameObject.CustomActive(flag && open);
			bool open2 = tableItem2.Open;
			bool flag2 = (this.CanSlideSetting(1007) || this.CanSlideSetting(2508)) && open2;
			if (flag2)
			{
				this.InitMachineGunSlideSelect();
			}
			this.mMachineGunSetting.gameObject.CustomActive(flag2 && open2);
			bool open3 = tableItem3.Open;
			bool flag3 = this.CanSlideSetting(2010) && open3;
			if (flag3)
			{
				this.InitTianjiSlideSelect();
			}
			this.mTianjiSetting.gameObject.CustomActive(flag3);
			bool open4 = tableItem4.Open;
			bool flag4 = (this.CanSlideSetting(1512) || this.CanSlideSetting(1716)) && open4;
			if (flag4)
			{
				this.InitBengshanjiSlideSelect();
			}
			this.mBengshanjiSetting.gameObject.CustomActive(flag4);
			bool flag5 = SwitchFunctionUtility.IsOpen(24);
			bool flag6 = this.CanSlideSetting(1901) && flag5;
			if (flag6)
			{
				this.InitLiguiSettingSelect();
			}
			this.mLiguiSetting.gameObject.CustomActive(flag6);
			bool flag7 = SwitchFunctionUtility.IsOpen(51);
			bool flag8 = this.CanSlideSetting(1910) && flag7;
			if (flag8)
			{
				this.InitBackHitSettingSelect();
			}
			this.mBackHitSetting.gameObject.CustomActive(flag8);
			bool flag9 = SwitchFunctionUtility.IsOpen(52);
			bool flag10 = this.CanSlideSetting(1107) || (this.CanSlideSetting(2527) && flag9);
			if (flag10)
			{
				this.InitAutoHitSettingSelect();
			}
			this.mAutoHitSetting.gameObject.CustomActive(flag10);
			bool open5 = tableItem5.Open;
			bool flag11 = this.CanSlideSetting(3600) && open5;
			if (flag11)
			{
				this.InitPoMoFuSlideSelect();
			}
			this.mPoMoFuSetting.gameObject.CustomActive(flag11);
			bool open6 = tableItem6.Open;
			bool flag12 = this.CanSlideSetting(3608) && open6;
			if (flag12)
			{
				this.InitXingLuoDaSlideSelect();
			}
			this.mXingLuoDaSetting.gameObject.CustomActive(flag12);
			this.mSlideTitle.gameObject.CustomActive(flag || flag2 || flag3 || flag4 || flag6 || flag11 || flag12);
		}

		// Token: 0x06010699 RID: 67225 RVA: 0x0049E108 File Offset: 0x0049C508
		protected void InitGrenadeSlideSelect()
		{
			this.mGrenadeSlideClose.isOn = false;
			this.mGrenadeSlideOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("1204") == InputManager.SlideSetting.NORMAL)
			{
				this.mGrenadeSlideClose.isOn = true;
			}
			else
			{
				this.mGrenadeSlideOpen.isOn = true;
			}
		}

		// Token: 0x0601069A RID: 67226 RVA: 0x0049E160 File Offset: 0x0049C560
		protected void InitMachineGunSlideSelect()
		{
			this.mMachineGunSlideClose.isOn = false;
			this.mMachineGunSlideOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("1007") == InputManager.SlideSetting.NORMAL)
			{
				this.mMachineGunSlideClose.isOn = true;
			}
			else
			{
				this.mMachineGunSlideOpen.isOn = true;
			}
		}

		// Token: 0x0601069B RID: 67227 RVA: 0x0049E1B8 File Offset: 0x0049C5B8
		protected void InitTianjiSlideSelect()
		{
			this.mTanjiSlideClose.isOn = false;
			this.mTanjiSlideOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("2010") == InputManager.SlideSetting.NORMAL)
			{
				this.mTanjiSlideClose.isOn = true;
			}
			else
			{
				this.mTanjiSlideOpen.isOn = true;
			}
		}

		// Token: 0x0601069C RID: 67228 RVA: 0x0049E210 File Offset: 0x0049C610
		protected void InitBengshanjiSlideSelect()
		{
			this.mBengshanjiClose.isOn = false;
			this.mBengshanjiOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("1512") == InputManager.SlideSetting.NORMAL)
			{
				this.mBengshanjiClose.isOn = true;
			}
			else
			{
				this.mBengshanjiOpen.isOn = true;
			}
		}

		// Token: 0x0601069D RID: 67229 RVA: 0x0049E268 File Offset: 0x0049C668
		protected void InitPoMoFuSlideSelect()
		{
			this.mPoMoFuClose.isOn = false;
			this.mPoMoFuOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("3600") == InputManager.SlideSetting.NORMAL)
			{
				this.mPoMoFuClose.isOn = true;
			}
			else
			{
				this.mPoMoFuOpen.isOn = true;
			}
		}

		// Token: 0x0601069E RID: 67230 RVA: 0x0049E2C0 File Offset: 0x0049C6C0
		protected void InitXingLuoDaSlideSelect()
		{
			this.mXingLuoDaClose.isOn = false;
			this.mXingLuoDaOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetSlideMode("3608") == InputManager.SlideSetting.NORMAL)
			{
				this.mXingLuoDaClose.isOn = true;
			}
			else
			{
				this.mXingLuoDaOpen.isOn = true;
			}
		}

		// Token: 0x0601069F RID: 67231 RVA: 0x0049E318 File Offset: 0x0049C718
		protected void InitLiguiSettingSelect()
		{
			this.mLiguiClose.isOn = false;
			this.mLiguiOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetValue("SETTING_LIGUI"))
			{
				this.mLiguiOpen.isOn = true;
			}
			else
			{
				this.mLiguiClose.isOn = true;
			}
		}

		// Token: 0x060106A0 RID: 67232 RVA: 0x0049E370 File Offset: 0x0049C770
		protected void InitBackHitSettingSelect()
		{
			this.mBackHitClose.isOn = false;
			this.mBackHitOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetValue("STR_BACKHIT"))
			{
				this.mBackHitOpen.isOn = true;
			}
			else
			{
				this.mBackHitClose.isOn = true;
			}
		}

		// Token: 0x060106A1 RID: 67233 RVA: 0x0049E3C8 File Offset: 0x0049C7C8
		protected void InitAutoHitSettingSelect()
		{
			this.mAutoHitClose.isOn = false;
			this.mAutoHitOpen.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetValue("STR_AUTOHIT"))
			{
				this.mAutoHitOpen.isOn = true;
			}
			else
			{
				this.mAutoHitClose.isOn = true;
			}
		}

		// Token: 0x060106A2 RID: 67234 RVA: 0x0049E41E File Offset: 0x0049C81E
		protected override void OnShowOut()
		{
			this.InitDoublePressRun();
			this.InitJoystickSelect();
			this.InitJoystickDir();
			this.InitRunAttackSelect();
			this.InitPaladinAttack();
			this.InitSlideSetting();
		}

		// Token: 0x060106A3 RID: 67235 RVA: 0x0049E444 File Offset: 0x0049C844
		protected override void OnHideIn()
		{
			PlayerLocalSetting.SaveConfig();
			SceneSetCustomData sceneSetCustomData = new SceneSetCustomData();
			sceneSetCustomData.data = ((!Global.Settings.hasDoubleRun) ? 0U : 1U);
			NetManager.Instance().SendCommand<SceneSetCustomData>(ServerType.GATE_SERVER, sceneSetCustomData);
		}

		// Token: 0x060106A4 RID: 67236 RVA: 0x0049E488 File Offset: 0x0049C888
		private void OnDragRunChange(bool isOn)
		{
			this.SaveDoublePressRun(!isOn);
			if (this.dragCheckImg)
			{
				this.dragCheckImg.gameObject.CustomActive(isOn);
			}
			if (isOn)
			{
				if (this.dragRunVideo)
				{
					this.dragRunVideo.Play();
				}
				if (this.doubleRunVideo)
				{
					this.doubleRunVideo.Stop();
				}
				Singleton<GameStatisticManager>.GetInstance().DoStatRunning(RunningModeType.DragDropMovement);
			}
		}

		// Token: 0x060106A5 RID: 67237 RVA: 0x0049E508 File Offset: 0x0049C908
		private void OnDoubleRunChange(bool isOn)
		{
			this.SaveDoublePressRun(isOn);
			if (this.doubleCheckImg)
			{
				this.doubleCheckImg.gameObject.CustomActive(isOn);
			}
			if (isOn)
			{
				if (this.dragRunVideo)
				{
					this.dragRunVideo.Stop();
				}
				if (this.doubleRunVideo)
				{
					this.doubleRunVideo.Play();
				}
				Singleton<GameStatisticManager>.GetInstance().DoStatRunning(RunningModeType.DoubleClickMovement);
			}
		}

		// Token: 0x060106A6 RID: 67238 RVA: 0x0049E588 File Offset: 0x0049C988
		private void InitDoublePressRun()
		{
			bool flag = false;
			if (PlayerLocalSetting.GetValue("KEY_DOUBLE") != null)
			{
				flag = (bool)PlayerLocalSetting.GetValue("KEY_DOUBLE");
			}
			this.SaveDoublePressRun(flag);
			if (this.dragRun)
			{
				this.dragRun.isOn = !flag;
			}
			if (this.doubleRun)
			{
				this.doubleRun.isOn = flag;
			}
			if (this.doubleCheckImg)
			{
				this.doubleCheckImg.gameObject.CustomActive(flag);
			}
			if (this.dragCheckImg)
			{
				this.dragCheckImg.gameObject.CustomActive(!flag);
			}
			if (this.dragRunVideo)
			{
				this.dragRunVideo.Load("controlMovie/1.mp4");
				this.dragRunVideo.m_bAutoPlay = true;
				this.dragRunVideo.Play();
				this.dragRunVideo.m_bLoop = true;
			}
			if (this.doubleRunVideo)
			{
				this.doubleRunVideo.Load("controlMovie/2.mp4");
				this.doubleRunVideo.m_bAutoPlay = true;
				this.doubleRunVideo.Play();
				this.doubleRunVideo.m_bLoop = true;
			}
		}

		// Token: 0x060106A7 RID: 67239 RVA: 0x0049E6C3 File Offset: 0x0049CAC3
		private void SaveDoublePressRun(bool flag)
		{
			Global.Settings.hasDoubleRun = flag;
			PlayerLocalSetting.SetValue("KEY_DOUBLE", flag);
		}

		// Token: 0x060106A8 RID: 67240 RVA: 0x0049E6E0 File Offset: 0x0049CAE0
		public void LoadDoublePressConfig()
		{
			if (PlayerLocalSetting.GetValue("KEY_DOUBLE") != null)
			{
				Global.Settings.hasDoubleRun = (bool)PlayerLocalSetting.GetValue("KEY_DOUBLE");
			}
		}

		// Token: 0x060106A9 RID: 67241 RVA: 0x0049E70C File Offset: 0x0049CB0C
		public void ReleaseBattleVideos()
		{
			if (this.dragRunVideo && this.dragRunVideo.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.dragRunVideo.Stop();
				this.dragRunVideo.UnLoad();
			}
			if (this.doubleRunVideo && this.doubleRunVideo.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.doubleRunVideo.Stop();
				this.doubleRunVideo.UnLoad();
			}
		}

		// Token: 0x060106AA RID: 67242 RVA: 0x0049E788 File Offset: 0x0049CB88
		protected bool CanSlideSetting(int skillId)
		{
			bool result = false;
			SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skillId, string.Empty, string.Empty);
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			for (int i = 0; i < tableItem.JobID.Count; i++)
			{
				int num = tableItem.JobID[i];
				if (num == jobTableID)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0400A691 RID: 42641
		private Toggle dragRun;

		// Token: 0x0400A692 RID: 42642
		private Toggle doubleRun;

		// Token: 0x0400A693 RID: 42643
		private Image dragCheckImg;

		// Token: 0x0400A694 RID: 42644
		private Image doubleCheckImg;

		// Token: 0x0400A695 RID: 42645
		private MediaPlayerCtrl dragRunVideo;

		// Token: 0x0400A696 RID: 42646
		private MediaPlayerCtrl doubleRunVideo;

		// Token: 0x0400A697 RID: 42647
		private Toggle mJoystickMode1;

		// Token: 0x0400A698 RID: 42648
		private Toggle mJoystickMode2;

		// Token: 0x0400A699 RID: 42649
		private Toggle mJoystickMoreDir;

		// Token: 0x0400A69A RID: 42650
		private Toggle mJoystick8Dir;

		// Token: 0x0400A69B RID: 42651
		private GameObject joystick8Dir;

		// Token: 0x0400A69C RID: 42652
		private Toggle mRunAttackMode1;

		// Token: 0x0400A69D RID: 42653
		private Toggle mRunAttackMode2;

		// Token: 0x0400A69E RID: 42654
		private Toggle mGrenadeSlideClose;

		// Token: 0x0400A69F RID: 42655
		private Toggle mGrenadeSlideOpen;

		// Token: 0x0400A6A0 RID: 42656
		private Toggle mMachineGunSlideClose;

		// Token: 0x0400A6A1 RID: 42657
		private Toggle mMachineGunSlideOpen;

		// Token: 0x0400A6A2 RID: 42658
		private Toggle mTanjiSlideClose;

		// Token: 0x0400A6A3 RID: 42659
		private Toggle mTanjiSlideOpen;

		// Token: 0x0400A6A4 RID: 42660
		private Toggle mBengshanjiClose;

		// Token: 0x0400A6A5 RID: 42661
		private Toggle mBengshanjiOpen;

		// Token: 0x0400A6A6 RID: 42662
		private RectTransform mGrenadeSetting;

		// Token: 0x0400A6A7 RID: 42663
		private RectTransform mMachineGunSetting;

		// Token: 0x0400A6A8 RID: 42664
		private RectTransform mTianjiSetting;

		// Token: 0x0400A6A9 RID: 42665
		private RectTransform mBengshanjiSetting;

		// Token: 0x0400A6AA RID: 42666
		private RectTransform mSlideTitle;

		// Token: 0x0400A6AB RID: 42667
		private RectTransform mSlideSetting;

		// Token: 0x0400A6AC RID: 42668
		private Text mGrenadeName;

		// Token: 0x0400A6AD RID: 42669
		private Text mGrenadeDsc;

		// Token: 0x0400A6AE RID: 42670
		private Text mMachineGunName;

		// Token: 0x0400A6AF RID: 42671
		private Text mMachineGunDsc;

		// Token: 0x0400A6B0 RID: 42672
		private Text mTianJiName;

		// Token: 0x0400A6B1 RID: 42673
		private Text mTianJiDsc;

		// Token: 0x0400A6B2 RID: 42674
		private Text mBengshanjiName;

		// Token: 0x0400A6B3 RID: 42675
		private Text mBengshanjiDsc;

		// Token: 0x0400A6B4 RID: 42676
		private Toggle mLiguiClose;

		// Token: 0x0400A6B5 RID: 42677
		private Toggle mLiguiOpen;

		// Token: 0x0400A6B6 RID: 42678
		private RectTransform mLiguiSetting;

		// Token: 0x0400A6B7 RID: 42679
		private Toggle mBackHitClose;

		// Token: 0x0400A6B8 RID: 42680
		private Toggle mBackHitOpen;

		// Token: 0x0400A6B9 RID: 42681
		private RectTransform mBackHitSetting;

		// Token: 0x0400A6BA RID: 42682
		private Toggle mAutoHitClose;

		// Token: 0x0400A6BB RID: 42683
		private Toggle mAutoHitOpen;

		// Token: 0x0400A6BC RID: 42684
		private RectTransform mAutoHitSetting;

		// Token: 0x0400A6BD RID: 42685
		private Text mPoMoFuName;

		// Token: 0x0400A6BE RID: 42686
		private Text mPoMoFuDsc;

		// Token: 0x0400A6BF RID: 42687
		private Text mXingLuoDaName;

		// Token: 0x0400A6C0 RID: 42688
		private Text mXingLuoDaDsc;

		// Token: 0x0400A6C1 RID: 42689
		private Toggle mPoMoFuOpen;

		// Token: 0x0400A6C2 RID: 42690
		private Toggle mPoMoFuClose;

		// Token: 0x0400A6C3 RID: 42691
		private RectTransform mPoMoFuSetting;

		// Token: 0x0400A6C4 RID: 42692
		private Toggle mXingLuoDaOpen;

		// Token: 0x0400A6C5 RID: 42693
		private Toggle mXingLuoDaClose;

		// Token: 0x0400A6C6 RID: 42694
		private RectTransform mXingLuoDaSetting;

		// Token: 0x0400A6C7 RID: 42695
		private RectTransform mPaladinAttack;

		// Token: 0x0400A6C8 RID: 42696
		private Toggle mPaladinAttackClose;

		// Token: 0x0400A6C9 RID: 42697
		private Toggle mPaladinAttackOpen;
	}
}
