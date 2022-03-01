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
	// Token: 0x02001AA9 RID: 6825
	public class SkillBattleSettingFrame : ClientFrame
	{
		// Token: 0x06010BE4 RID: 68580 RVA: 0x004BFD57 File Offset: 0x004BE157
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/BattleSettingFrame";
		}

		// Token: 0x06010BE5 RID: 68581 RVA: 0x004BFD60 File Offset: 0x004BE160
		protected override void _bindExUI()
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
			this.joystick8DirAdjust = this.mBind.GetGameObject("DirAdjustObj");
			this.joystick8DirAdjustSlider = this.mBind.GetCom<Slider>("DirAdjustSlider");
			this.joystick8DirAdjustSlider.onValueChanged.AddListener(new UnityAction<float>(this._onJoystick8DirSliderValueChange));
			this.joystick8DirAdjustRect = this.mBind.GetCom<RectTransform>("Joystick8DirRect");
			this.joystick8DirAdjustAddButton = this.mBind.GetCom<Button>("DirAdjustAddBtn");
			this.joystick8DirAdjustAddButton.onClick.AddListener(new UnityAction(this._onClickJoystick8DirAddBtn));
			this.joystick8DirAdjustSubButton = this.mBind.GetCom<Button>("DirAdjustSubBtn");
			this.joystick8DirAdjustSubButton.onClick.AddListener(new UnityAction(this._onClickJoystick8DirSubBtn));
			this.joystick8DirAdjustText = this.mBind.GetCom<Text>("DirAdjustText");
			this.mRunAttackMode1 = this.mBind.GetCom<Toggle>("runAttackMode1");
			this.mRunAttackMode1.onValueChanged.AddListener(new UnityAction<bool>(this._onRunAttackMode1ToggleValueChange));
			this.mRunAttackMode2 = this.mBind.GetCom<Toggle>("runAttackMode2");
			this.mRunAttackMode2.onValueChanged.AddListener(new UnityAction<bool>(this._onRunAttackMode2ToggleValueChange));
			this.mCameraShock1 = this.mBind.GetCom<Toggle>("openShock");
			this.mCameraShock1.onValueChanged.AddListener(new UnityAction<bool>(this._onCameraShockMode1ToggleValueChange));
			this.mCameraShock2 = this.mBind.GetCom<Toggle>("closeShock");
			this.mCameraShock2.onValueChanged.AddListener(new UnityAction<bool>(this._onCameraShockMode2ToggleValueChange));
			this.mSlideTitle = this.mBind.GetCom<RectTransform>("SlideTitle");
			this.mSlideSetting = this.mBind.GetCom<RectTransform>("SlideSetting");
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
			this.mSkillSlideUIList = this.mBind.GetCom<ComUIListScript>("SkillSlideUIList");
		}

		// Token: 0x06010BE6 RID: 68582 RVA: 0x004C0188 File Offset: 0x004BE588
		protected override void _unbindExUI()
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
			if (this.mCameraShock1 != null)
			{
				this.mCameraShock1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCameraShockMode1ToggleValueChange));
				this.mCameraShock1 = null;
			}
			if (this.mCameraShock2 != null)
			{
				this.mCameraShock2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCameraShockMode2ToggleValueChange));
				this.mCameraShock2 = null;
			}
			this.mSlideTitle = null;
			this.mSlideSetting = null;
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
			this.mSkillSlideUIList.UnInitialize();
			this.mSkillSlideUIList = null;
		}

		// Token: 0x06010BE7 RID: 68583 RVA: 0x004C03E0 File Offset: 0x004BE7E0
		private void _onJoystickMode1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickMode(InputManager.JoystickMode.DYNAMIC);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
			}
		}

		// Token: 0x06010BE8 RID: 68584 RVA: 0x004C03FE File Offset: 0x004BE7FE
		private void _onJoystickMode2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickMode(InputManager.JoystickMode.STATIC);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.STATIC);
			}
		}

		// Token: 0x06010BE9 RID: 68585 RVA: 0x004C041C File Offset: 0x004BE81C
		private void _onJoystickMoreDirToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickDir(InputManager.JoystickDir.MORE_DIR);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
				this.joystick8DirAdjust.SetActive(false);
				Vector2 sizeDelta = this.joystick8DirAdjustRect.sizeDelta;
				sizeDelta.y = 57.2f;
				this.joystick8DirAdjustRect.sizeDelta = sizeDelta;
				this.joystick8DirAdjustSlider.value = 0.5f;
			}
		}

		// Token: 0x06010BEA RID: 68586 RVA: 0x004C0488 File Offset: 0x004BE888
		private void _onJoystick8DirToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetJoystickDir(InputManager.JoystickDir.EIGHT_DIR);
				Singleton<GameStatisticManager>.GetInstance().DoStatJoyStick(InputManager.JoystickMode.DYNAMIC);
				this.joystick8DirAdjustSlider.value = Singleton<SettingManager>.GetInstance().GetJoystickDirAdjust();
				this.joystick8DirAdjust.SetActive(true);
				Vector2 sizeDelta = this.joystick8DirAdjustRect.sizeDelta;
				sizeDelta.y = 130f;
				this.joystick8DirAdjustRect.sizeDelta = sizeDelta;
			}
		}

		// Token: 0x06010BEB RID: 68587 RVA: 0x004C04F6 File Offset: 0x004BE8F6
		private void _onJoystick8DirSliderValueChange(float value)
		{
			Singleton<SettingManager>.GetInstance().SetJoystickDirAdjust(value);
			this.joystick8DirAdjustText.text = this.Joystick8DirSlider2Degree(value) + "°";
		}

		// Token: 0x06010BEC RID: 68588 RVA: 0x004C0524 File Offset: 0x004BE924
		private void _onClickJoystick8DirAddBtn()
		{
			this.ChangeJoystick8Dir(1);
		}

		// Token: 0x06010BED RID: 68589 RVA: 0x004C052D File Offset: 0x004BE92D
		private void _onClickJoystick8DirSubBtn()
		{
			this.ChangeJoystick8Dir(-1);
		}

		// Token: 0x06010BEE RID: 68590 RVA: 0x004C0538 File Offset: 0x004BE938
		private void ChangeJoystick8Dir(int deltaDegree)
		{
			int num = this.Joystick8DirSlider2Degree(this.joystick8DirAdjustSlider.value);
			num += deltaDegree;
			this.joystick8DirAdjustSlider.value = this.Joystick8DirDegree2Slider(num);
		}

		// Token: 0x06010BEF RID: 68591 RVA: 0x004C0570 File Offset: 0x004BE970
		private int Joystick8DirSlider2Degree(float value)
		{
			float num = 17.5f;
			return 10 + Mathf.RoundToInt(value * num * 4f);
		}

		// Token: 0x06010BF0 RID: 68592 RVA: 0x004C0598 File Offset: 0x004BE998
		private float Joystick8DirDegree2Slider(int degree)
		{
			return (float)(degree - 10) / 70f;
		}

		// Token: 0x06010BF1 RID: 68593 RVA: 0x004C05B2 File Offset: 0x004BE9B2
		private void _onRunAttackMode1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetRunAttackMode(InputManager.RunAttackMode.NORMAL);
			}
		}

		// Token: 0x06010BF2 RID: 68594 RVA: 0x004C05C5 File Offset: 0x004BE9C5
		private void _onRunAttackMode2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetRunAttackMode(InputManager.RunAttackMode.QTE);
			}
		}

		// Token: 0x06010BF3 RID: 68595 RVA: 0x004C05D8 File Offset: 0x004BE9D8
		private void _onCameraShockMode1ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetCameraShockMode(InputManager.CameraShockMode.OPEN);
			}
		}

		// Token: 0x06010BF4 RID: 68596 RVA: 0x004C05EB File Offset: 0x004BE9EB
		private void _onCameraShockMode2ToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetCameraShockMode(InputManager.CameraShockMode.CLOSE);
			}
		}

		// Token: 0x06010BF5 RID: 68597 RVA: 0x004C05FE File Offset: 0x004BE9FE
		private void _onSummonDisplayCloseToggleValueChange(bool changed)
		{
		}

		// Token: 0x06010BF6 RID: 68598 RVA: 0x004C0600 File Offset: 0x004BEA00
		private void _onSummonDisplayOpenToggleValueChange(bool changed)
		{
		}

		// Token: 0x06010BF7 RID: 68599 RVA: 0x004C0602 File Offset: 0x004BEA02
		private void _onPaladinAttackCloseToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetPaladinAttack(InputManager.PaladinAttack.CLOSE);
			}
		}

		// Token: 0x06010BF8 RID: 68600 RVA: 0x004C0615 File Offset: 0x004BEA15
		private void _onPaladinAttackOpenToggleValueChange(bool changed)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetPaladinAttack(InputManager.PaladinAttack.OPEN);
			}
		}

		// Token: 0x06010BF9 RID: 68601 RVA: 0x004C0628 File Offset: 0x004BEA28
		private void _onSkillSlideOpenToggleValueChange(bool changed, string skillID)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.SLIDE, skillID);
			}
		}

		// Token: 0x06010BFA RID: 68602 RVA: 0x004C063C File Offset: 0x004BEA3C
		private void _onSkillSlideCloseToggleValueChange(bool changed, string skillID)
		{
			if (changed)
			{
				Singleton<SettingManager>.GetInstance().SetSlideMode(InputManager.SlideSetting.NORMAL, skillID);
			}
		}

		// Token: 0x06010BFB RID: 68603 RVA: 0x004C0650 File Offset: 0x004BEA50
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

		// Token: 0x06010BFC RID: 68604 RVA: 0x004C06A4 File Offset: 0x004BEAA4
		protected void InitJoystickDir()
		{
			this.joystick8Dir.CustomActive(SwitchFunctionUtility.IsOpen(29));
			this.mJoystickMoreDir.isOn = false;
			this.mJoystick8Dir.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetJoystickDir() == InputManager.JoystickDir.MORE_DIR)
			{
				this.mJoystickMoreDir.isOn = true;
				this.joystick8DirAdjust.SetActive(false);
			}
			else
			{
				this.mJoystick8Dir.isOn = true;
				this.joystick8DirAdjust.SetActive(true);
			}
		}

		// Token: 0x06010BFD RID: 68605 RVA: 0x004C0720 File Offset: 0x004BEB20
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

		// Token: 0x06010BFE RID: 68606 RVA: 0x004C0774 File Offset: 0x004BEB74
		protected void InitCameraShockSelect()
		{
			this.mCameraShock1.isOn = false;
			this.mCameraShock2.isOn = false;
			if (Singleton<SettingManager>.GetInstance().GetCameraShockMode() == InputManager.CameraShockMode.OPEN)
			{
				this.mCameraShock1.isOn = true;
			}
			else
			{
				this.mCameraShock2.isOn = true;
			}
		}

		// Token: 0x06010BFF RID: 68607 RVA: 0x004C07C8 File Offset: 0x004BEBC8
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

		// Token: 0x06010C00 RID: 68608 RVA: 0x004C0868 File Offset: 0x004BEC68
		protected void InitSlideSetting()
		{
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			this.mSwitchClientFunctionTableList.Clear();
			this._InitSkillSlideData();
			this._InitSkillSlideUIListBind();
			this.mSkillSlideUIList.SetElementAmount(this.mSwitchClientFunctionTableList.Count);
		}

		// Token: 0x06010C01 RID: 68609 RVA: 0x004C08B0 File Offset: 0x004BECB0
		protected void _InitSkillSlideUIListBind()
		{
			this.mSkillSlideUIList.Initialize();
			this.mSkillSlideUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					this._UpdateCharacterSelectUIListBind(item);
				}
			};
			this.mSkillSlideUIList.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item == null)
				{
					return;
				}
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component != null)
				{
					Toggle com = component.GetCom<Toggle>("OpenToggle");
					if (com != null)
					{
						com.onValueChanged.RemoveAllListeners();
					}
					Toggle com2 = component.GetCom<Toggle>("CloseToggle");
					if (com2 != null)
					{
						com2.onValueChanged.RemoveAllListeners();
					}
				}
			};
		}

		// Token: 0x06010C02 RID: 68610 RVA: 0x004C0908 File Offset: 0x004BED08
		private void _UpdateCharacterSelectUIListBind(ComUIListElementScript item)
		{
			if (item.m_index < 0 || item.m_index >= this.mSwitchClientFunctionTableList.Count)
			{
				return;
			}
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Toggle com = component.GetCom<Toggle>("OpenToggle");
			Toggle com2 = component.GetCom<Toggle>("CloseToggle");
			Text com3 = component.GetCom<Text>("DscText");
			Text com4 = component.GetCom<Text>("NameText");
			Text com5 = component.GetCom<Text>("OpenText");
			SwitchClientFunctionTable tableData = this.mSwitchClientFunctionTableList[item.m_index];
			if (com == null || com2 == null)
			{
				return;
			}
			if (com3 != null)
			{
				com3.text = tableData.DescB;
			}
			if (com4 != null)
			{
				com4.text = tableData.DescA;
			}
			if (com5 != null && !string.IsNullOrEmpty(tableData.DescE))
			{
				com5.text = tableData.DescE;
			}
			int skillId = this.mTableSkillIdDic[tableData.ID][0];
			com.isOn = false;
			com2.isOn = false;
			bool flag2;
			if (this.mIdJsonKeyDic.ContainsKey(tableData.ID))
			{
				string text = this.mIdJsonKeyDic[tableData.ID];
				if (text == "STR_CHASER_SWITCH")
				{
					flag2 = !Singleton<SettingManager>.GetInstance().GetValue(text + DataManager<PlayerBaseData>.GetInstance().RoleID);
				}
				else
				{
					flag2 = !Singleton<SettingManager>.GetInstance().GetValue(text);
				}
			}
			else
			{
				string text = skillId.ToString();
				flag2 = (Singleton<SettingManager>.GetInstance().GetSlideMode(text) == InputManager.SlideSetting.NORMAL);
			}
			if (flag2)
			{
				com2.isOn = true;
			}
			else
			{
				com.isOn = true;
			}
			if (!this.mIdJsonKeyDic.ContainsKey(tableData.ID))
			{
				com.onValueChanged.AddListener(delegate(bool flag)
				{
					this._onSkillSlideOpenToggleValueChange(flag, skillId.ToString());
				});
				com2.onValueChanged.AddListener(delegate(bool flag)
				{
					this._onSkillSlideCloseToggleValueChange(flag, skillId.ToString());
				});
			}
			else
			{
				com.onValueChanged.AddListener(delegate(bool flag)
				{
					if (flag)
					{
						if (this.mIdJsonKeyDic[tableData.ID] == "STR_CHASER_SWITCH")
						{
							Singleton<SettingManager>.GetInstance().SetValue(this.mIdJsonKeyDic[tableData.ID] + DataManager<PlayerBaseData>.GetInstance().RoleID, true);
						}
						else
						{
							Singleton<SettingManager>.GetInstance().SetValue(this.mIdJsonKeyDic[tableData.ID], true);
						}
						this.OnOpenSpecialOption(tableData.ID);
					}
				});
				com2.onValueChanged.AddListener(delegate(bool flag)
				{
					if (flag)
					{
						if (this.mIdJsonKeyDic[tableData.ID] == "STR_CHASER_SWITCH")
						{
							Singleton<SettingManager>.GetInstance().SetValue(this.mIdJsonKeyDic[tableData.ID] + DataManager<PlayerBaseData>.GetInstance().RoleID, false);
						}
						else
						{
							Singleton<SettingManager>.GetInstance().SetValue(this.mIdJsonKeyDic[tableData.ID], false);
						}
						this.OnCloseSpecialOption(tableData.ID);
					}
				});
			}
		}

		// Token: 0x06010C03 RID: 68611 RVA: 0x004C0BA8 File Offset: 0x004BEFA8
		private void OnOpenSpecialOption(int id)
		{
			if (this.mIdJsonKeyDic[id] == "STR_CHASER_SWITCH")
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillChaserSettingFrame>(FrameLayer.High, null, string.Empty);
			}
		}

		// Token: 0x06010C04 RID: 68612 RVA: 0x004C0BD7 File Offset: 0x004BEFD7
		private void OnCloseSpecialOption(int id)
		{
			if (this.mIdJsonKeyDic[id] == "STR_CHASER_SWITCH")
			{
				Singleton<SettingManager>.GetInstance().SetChaserSetting("STR_CHASER_PVE", 0);
				Singleton<SettingManager>.GetInstance().SetChaserSetting("STR_CHASER_PVP", 0);
			}
		}

		// Token: 0x06010C05 RID: 68613 RVA: 0x004C0C14 File Offset: 0x004BF014
		protected void _InitSkillSlideData()
		{
			this.mSwitchClientFunctionTableList.Clear();
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.mTableSkillIdDic)
			{
				bool flag = false;
				for (int i = 0; i < keyValuePair.Value.Count; i++)
				{
					if (this.CanSlideSetting(keyValuePair.Value[i]))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(keyValuePair.Key, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Open)
					{
						this.mSwitchClientFunctionTableList.Add(tableItem);
					}
				}
			}
		}

		// Token: 0x06010C06 RID: 68614 RVA: 0x004C0CF8 File Offset: 0x004BF0F8
		protected override void _OnOpenFrame()
		{
			this.InitDoublePressRun();
			this.InitJoystickSelect();
			this.InitJoystickDir();
			this.InitRunAttackSelect();
			this.InitCameraShockSelect();
			this.InitPaladinAttack();
			this.InitSlideSetting();
		}

		// Token: 0x06010C07 RID: 68615 RVA: 0x004C0D24 File Offset: 0x004BF124
		protected override void _OnCloseFrame()
		{
			PlayerLocalSetting.SaveConfig();
			SceneSetCustomData sceneSetCustomData = new SceneSetCustomData();
			sceneSetCustomData.data = ((!Global.Settings.hasDoubleRun) ? 0U : 1U);
			NetManager.Instance().SendCommand<SceneSetCustomData>(ServerType.GATE_SERVER, sceneSetCustomData);
		}

		// Token: 0x06010C08 RID: 68616 RVA: 0x004C0D68 File Offset: 0x004BF168
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

		// Token: 0x06010C09 RID: 68617 RVA: 0x004C0DE8 File Offset: 0x004BF1E8
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

		// Token: 0x06010C0A RID: 68618 RVA: 0x004C0E68 File Offset: 0x004BF268
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

		// Token: 0x06010C0B RID: 68619 RVA: 0x004C0FA3 File Offset: 0x004BF3A3
		private void SaveDoublePressRun(bool flag)
		{
			Global.Settings.hasDoubleRun = flag;
			PlayerLocalSetting.SetValue("KEY_DOUBLE", flag);
		}

		// Token: 0x06010C0C RID: 68620 RVA: 0x004C0FC0 File Offset: 0x004BF3C0
		public void LoadDoublePressConfig()
		{
			if (PlayerLocalSetting.GetValue("KEY_DOUBLE") != null)
			{
				Global.Settings.hasDoubleRun = (bool)PlayerLocalSetting.GetValue("KEY_DOUBLE");
			}
		}

		// Token: 0x06010C0D RID: 68621 RVA: 0x004C0FEC File Offset: 0x004BF3EC
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

		// Token: 0x06010C0E RID: 68622 RVA: 0x004C1068 File Offset: 0x004BF468
		protected bool CanSlideSetting(int skillId)
		{
			bool result = false;
			SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skillId, string.Empty, string.Empty);
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			if (tableItem == null)
			{
				return result;
			}
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

		// Token: 0x0400AB4C RID: 43852
		private Toggle dragRun;

		// Token: 0x0400AB4D RID: 43853
		private Toggle doubleRun;

		// Token: 0x0400AB4E RID: 43854
		private Image dragCheckImg;

		// Token: 0x0400AB4F RID: 43855
		private Image doubleCheckImg;

		// Token: 0x0400AB50 RID: 43856
		private MediaPlayerCtrl dragRunVideo;

		// Token: 0x0400AB51 RID: 43857
		private MediaPlayerCtrl doubleRunVideo;

		// Token: 0x0400AB52 RID: 43858
		private Toggle mJoystickMode1;

		// Token: 0x0400AB53 RID: 43859
		private Toggle mJoystickMode2;

		// Token: 0x0400AB54 RID: 43860
		private Toggle mJoystickMoreDir;

		// Token: 0x0400AB55 RID: 43861
		private Toggle mJoystick8Dir;

		// Token: 0x0400AB56 RID: 43862
		private GameObject joystick8Dir;

		// Token: 0x0400AB57 RID: 43863
		private GameObject joystick8DirAdjust;

		// Token: 0x0400AB58 RID: 43864
		private Button joystick8DirAdjustAddButton;

		// Token: 0x0400AB59 RID: 43865
		private Button joystick8DirAdjustSubButton;

		// Token: 0x0400AB5A RID: 43866
		private Text joystick8DirAdjustText;

		// Token: 0x0400AB5B RID: 43867
		private Slider joystick8DirAdjustSlider;

		// Token: 0x0400AB5C RID: 43868
		private RectTransform joystick8DirAdjustRect;

		// Token: 0x0400AB5D RID: 43869
		private Toggle mRunAttackMode1;

		// Token: 0x0400AB5E RID: 43870
		private Toggle mRunAttackMode2;

		// Token: 0x0400AB5F RID: 43871
		private Toggle mCameraShock1;

		// Token: 0x0400AB60 RID: 43872
		private Toggle mCameraShock2;

		// Token: 0x0400AB61 RID: 43873
		private RectTransform mSlideTitle;

		// Token: 0x0400AB62 RID: 43874
		private RectTransform mSlideSetting;

		// Token: 0x0400AB63 RID: 43875
		private RectTransform mPaladinAttack;

		// Token: 0x0400AB64 RID: 43876
		private Toggle mPaladinAttackClose;

		// Token: 0x0400AB65 RID: 43877
		private Toggle mPaladinAttackOpen;

		// Token: 0x0400AB66 RID: 43878
		private ComUIListScript mSkillSlideUIList;

		// Token: 0x0400AB67 RID: 43879
		private Dictionary<int, List<int>> mTableSkillIdDic = new Dictionary<int, List<int>>
		{
			{
				17,
				new List<int>
				{
					1204,
					2507
				}
			},
			{
				18,
				new List<int>
				{
					1007,
					2508
				}
			},
			{
				19,
				new List<int>
				{
					2010
				}
			},
			{
				20,
				new List<int>
				{
					1512,
					1716
				}
			},
			{
				36,
				new List<int>
				{
					3600
				}
			},
			{
				37,
				new List<int>
				{
					3608
				}
			},
			{
				54,
				new List<int>
				{
					3713
				}
			},
			{
				48,
				new List<int>
				{
					1216,
					2612
				}
			},
			{
				56,
				new List<int>
				{
					1218
				}
			},
			{
				43,
				new List<int>
				{
					2611
				}
			},
			{
				24,
				new List<int>
				{
					1901
				}
			},
			{
				49,
				new List<int>
				{
					1910
				}
			},
			{
				57,
				new List<int>
				{
					1107,
					2527
				}
			},
			{
				66,
				new List<int>
				{
					2301
				}
			},
			{
				68,
				new List<int>
				{
					2302
				}
			},
			{
				70,
				new List<int>
				{
					1608
				}
			},
			{
				71,
				new List<int>
				{
					1006,
					2515
				}
			},
			{
				72,
				new List<int>
				{
					1104,
					2516
				}
			},
			{
				108,
				new List<int>
				{
					3612
				}
			}
		};

		// Token: 0x0400AB68 RID: 43880
		private Dictionary<int, string> mIdJsonKeyDic = new Dictionary<int, string>
		{
			{
				24,
				"SETTING_LIGUI"
			},
			{
				49,
				"STR_BACKHIT"
			},
			{
				57,
				"STR_AUTOHIT"
			},
			{
				68,
				"STR_CHASER_SWITCH"
			}
		};

		// Token: 0x0400AB69 RID: 43881
		private List<SwitchClientFunctionTable> mSwitchClientFunctionTableList = new List<SwitchClientFunctionTable>();
	}
}
