using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AB1 RID: 6833
	public class SkillTreeFrame : ClientFrame
	{
		// Token: 0x06010C3B RID: 68667 RVA: 0x004C3880 File Offset: 0x004C1C80
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError("SkillTreeFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x06010C3C RID: 68668 RVA: 0x004C38D0 File Offset: 0x004C1CD0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/SkillTreeFrame";
		}

		// Token: 0x06010C3D RID: 68669 RVA: 0x004C38D8 File Offset: 0x004C1CD8
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				if ((SkillLeftType)this.userData == SkillLeftType.PVP)
				{
					this.CurSelMainTab = SkillLeftType.PVP;
					this.CurSelFightType = FightTypeLabel.PVP;
					DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_PVP;
				}
				else
				{
					this.CurSelMainTab = SkillLeftType.PVE;
					this.CurSelFightType = FightTypeLabel.PVE;
					DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_PVE;
				}
			}
			else
			{
				this.CurSelMainTab = SkillLeftType.PVE;
				this.CurSelFightType = FightTypeLabel.PVE;
				DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_PVE;
			}
			this.InitInterface();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
			this.UpdateMainTab();
			this._InitSkillPage();
		}

		// Token: 0x06010C3E RID: 68670 RVA: 0x004C3984 File Offset: 0x004C1D84
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdjectiveSkillFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillBattleSettingFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobMovieFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobSelectPreviewFrame>(null, false);
			DataManager<SkillDataManager>.GetInstance().LastSeeSkillLv = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SkillLvUpNoticeUpdate, null, null, null, null);
		}

		// Token: 0x06010C3F RID: 68671 RVA: 0x004C3A10 File Offset: 0x004C1E10
		private void ClearData()
		{
			this.totalsp = 0U;
			this.pvpTotalsp = 0U;
			this.totalgold = 0UL;
			SkillTreeFrame.CurSelSkillTreeBtnIdx = -1;
			SkillTreeFrame.bIsApplySkillState = true;
			SkillTreeFrame.CurSelSkillTreeID = 0;
			this.CurSelSkillLv = 0;
			SkillPlanFrame.CurSelSolution = 1;
			this.CurSelFightType = FightTypeLabel.PVE;
			this.IsOpenSkillPlanPVE = false;
			this.IsOpenSkillPlanPVP = false;
			this.UniqueSkillobj = null;
			SkillPlanFrame.OriginalSkillBar.Clear();
			SkillPlanFrame.skillBarDirty.Clear();
			SkillPlanFrame.OriginalSkillBar2.Clear();
			SkillPlanFrame.skillBarDirty2.Clear();
			SkillTreeFrame.ChangedSkills.Clear();
			SkillTreeFrame.ChangedSkills2.Clear();
			SkillTreeFrame.pvpChangedSkills.Clear();
			SkillTreeFrame.pvpChangedSkills2.Clear();
			this.AddSkillInfo.Clear();
			this.pvpAddSkillInfo.Clear();
			SkillTreeFrame.skillPos.Clear();
			this.skillPosPanelIndexList.Clear();
			Object.Destroy(this.SkillTreeElementTemplate);
			this.SkillTreeElementTemplate = null;
			this._isSendChangedChangedSkillPageMsg = true;
			this.mPveSkillPage1State = false;
			this.mPveSkillPage2State = false;
			this.mPvpSkillPage1State = false;
			this.mPvpSkillPage2State = false;
		}

		// Token: 0x06010C40 RID: 68672 RVA: 0x004C3B20 File Offset: 0x004C1F20
		[UIEventHandle("Title/Close")]
		private void OnClose()
		{
			bool flag = true;
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(4, string.Empty, string.Empty);
			if (tableItem != null)
			{
				flag = tableItem.Open;
			}
			if (flag)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
				if (clientSystemTown != null && DataManager<SkillDataManager>.GetInstance().IsShowSkillCanLevelUpTip())
				{
					this.OnCloseSkillFrameByShowTips();
				}
				else
				{
					this._CloseFrame();
				}
			}
			else
			{
				this._CloseFrame();
			}
		}

		// Token: 0x06010C41 RID: 68673 RVA: 0x004C3B9C File Offset: 0x004C1F9C
		private void _CloseFrame()
		{
			this.ClearData();
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Skill);
			ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
			if (clientSystemTownFrame != null)
			{
				clientSystemTownFrame.SetJoystickAfterSetting();
			}
			this.frameMgr.CloseFrame<SkillTreeFrame>(this, false);
		}

		// Token: 0x06010C42 RID: 68674 RVA: 0x004C3BF4 File Offset: 0x004C1FF4
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this.OnSkillBarChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillSolutionChanged, new ClientEventSystem.UIEventHandler(this.OnSkillSolutionChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SpChanged, new ClientEventSystem.UIEventHandler(this.OnSpChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillListChanged, new ClientEventSystem.UIEventHandler(this.OnSkillListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillPlanClose, new ClientEventSystem.UIEventHandler(this.OnSkillPlanClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuankaFrameOpen, new ClientEventSystem.UIEventHandler(this.OnGuankaFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuySkillPage2Sucess, new ClientEventSystem.UIEventHandler(this._OnBuySkillPage2Sucess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectSkillPage, new ClientEventSystem.UIEventHandler(this._OnSelectSkillPage));
		}

		// Token: 0x06010C43 RID: 68675 RVA: 0x004C3CD8 File Offset: 0x004C20D8
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillBarChanged, new ClientEventSystem.UIEventHandler(this.OnSkillBarChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillSolutionChanged, new ClientEventSystem.UIEventHandler(this.OnSkillSolutionChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SpChanged, new ClientEventSystem.UIEventHandler(this.OnSpChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillListChanged, new ClientEventSystem.UIEventHandler(this.OnSkillListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillPlanClose, new ClientEventSystem.UIEventHandler(this.OnSkillPlanClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuankaFrameOpen, new ClientEventSystem.UIEventHandler(this.OnGuankaFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuySkillPage2Sucess, new ClientEventSystem.UIEventHandler(this._OnBuySkillPage2Sucess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectSkillPage, new ClientEventSystem.UIEventHandler(this._OnSelectSkillPage));
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					componentInChildren.SkillToggle.onValueChanged.RemoveAllListeners();
				}
			}
		}

		// Token: 0x06010C44 RID: 68676 RVA: 0x004C3E07 File Offset: 0x004C2207
		private void OnSkillBarChanged(UIEvent uiEvent)
		{
			SkillPlanFrame.UpdateSkillBar();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateCurUseSkillBar, null, null, null, null);
			}
			this.UpdateLeftInterface(false);
			this.UpdateRightInterface();
		}

		// Token: 0x06010C45 RID: 68677 RVA: 0x004C3E3E File Offset: 0x004C223E
		private void OnSkillSolutionChanged(UIEvent uiEvent)
		{
			this.UpdateLeftInterface(false);
		}

		// Token: 0x06010C46 RID: 68678 RVA: 0x004C3E48 File Offset: 0x004C2248
		private void OnSpChanged(UIEvent uiEvent)
		{
			this.totalsp = DataManager<PlayerBaseData>.GetInstance().SP;
			this.totalsp2 = DataManager<PlayerBaseData>.GetInstance().SP2;
			this.pvpTotalsp = DataManager<PlayerBaseData>.GetInstance().pvpSP;
			this.pvpTotalsp2 = DataManager<PlayerBaseData>.GetInstance().pvpSP2;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.Totalsp.text = this.totalsp.ToString();
				}
				else
				{
					this.Totalsp.text = this.totalsp2.ToString();
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				this.Totalsp.text = this.pvpTotalsp.ToString();
			}
			else
			{
				this.Totalsp.text = this.pvpTotalsp2.ToString();
			}
			this.UpdateSkillLvUp();
			this.FreshBtnLvAndNeddSp();
		}

		// Token: 0x06010C47 RID: 68679 RVA: 0x004C3F50 File Offset: 0x004C2350
		private void OnSkillListChanged(UIEvent uiEvent)
		{
			int addLevel = this.GetAddLevel((int)SkillTreeFrame.CurSelSkillTreeID);
			ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[SkillTreeFrame.CurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			if (addLevel > 0)
			{
				componentInChildren.SkillAddlevel.text = string.Format("(+{0})", addLevel);
			}
			else
			{
				componentInChildren.SkillAddlevel.text = string.Empty;
			}
			this.UpdateSkillAddedLv();
			bool isPvp = !DataManager<SkillDataManager>.GetInstance().isPve();
			if (DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(isPvp, SkillSystemSourceType.None).Count == 0 && this._isClickInitSkillBar)
			{
				this.UpdateLeftInterface(false);
			}
			this._isClickInitSkillBar = false;
		}

		// Token: 0x06010C48 RID: 68680 RVA: 0x004C3FF8 File Offset: 0x004C23F8
		private void OnSkillPlanClose(UIEvent uiEvent)
		{
			DOTweenAnimation[] components = this.mPlanTips.GetComponents<DOTweenAnimation>();
			DOTweenAnimation[] components2 = this.mPlanTipsText.GetComponents<DOTweenAnimation>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].DORestart(false);
				components2[i].DORestart(false);
			}
			this.mPlanTipsText.text = TR.Value("skill point03");
			this.UpdatePlanIsFull();
		}

		// Token: 0x06010C49 RID: 68681 RVA: 0x004C405E File Offset: 0x004C245E
		private void OnGuankaFrameOpen(UIEvent uiEvent)
		{
			this.frameMgr.CloseFrame<SkillTreeFrame>(this, false);
		}

		// Token: 0x06010C4A RID: 68682 RVA: 0x004C4070 File Offset: 0x004C2470
		private void _OnBuySkillPage2Sucess(UIEvent uiEvent)
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Buy_SKill2Config_Sucess_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			if (this.CurSelFightType == FightTypeLabel.PVE)
			{
				DataManager<SkillDataManager>.GetInstance().CurPVESKillPage = EPVESkillPage.Page2;
				this.mPVEToggle2.isOn = true;
			}
			else if (this.CurSelFightType == FightTypeLabel.PVP)
			{
				DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage = EPVPSkillPage.Page2;
				this.mPVPToggle2.isOn = true;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
			{
				this.mLevelDown.CustomActive(true);
				this.mLevelUp.CustomActive(true);
				this.mMaxRoot.CustomActive(true);
				this.mSkillPlanText.text = "技能配置";
				this.UpdateSkillInitConfigRoot(false);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
			}
			DataManager<SkillDataManager>.GetInstance().PVPSkillPage2IsUnlock = true;
			DataManager<SkillDataManager>.GetInstance().PVESkillPage2IsUnlock = true;
			this.mPVPLockBtn.CustomActive(false);
			this.mPVELockBtn.CustomActive(false);
		}

		// Token: 0x06010C4B RID: 68683 RVA: 0x004C415D File Offset: 0x004C255D
		private void _OnSelectSkillPage(UIEvent uiEvent)
		{
			this._OnFreshAllSkillFrame();
		}

		// Token: 0x06010C4C RID: 68684 RVA: 0x004C4168 File Offset: 0x004C2568
		[UIEventHandle("left/tabroot/Tab{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 4)]
		private void OnSwitchMainTab(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
				this.mLevelDown.CustomActive(true);
				this.mLevelUp.CustomActive(true);
				this.mSkillPlanText.text = "技能配置";
				this.UpdateSkillInitConfigRoot(false);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(typeof(AdjectiveSkillFrame)))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AdjectiveSkillFrame>(null, false);
			}
			if (iIndex != 1)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobMovieFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobSelectPreviewFrame>(null, false);
			}
			if (iIndex != 3)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillBattleSettingFrame>(null, false);
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mChangeJobTips.gameObject.CustomActive(iIndex == 0 && tableItem.JobType == 0);
			}
			this.mActiveSkillRoot.CustomActive(iIndex == 0 || iIndex == 2);
			this.mRightRoot.CustomActive(false);
			if (iIndex == 0 || iIndex == 2)
			{
				this.mPlanTipsText.text = TR.Value("skill point03");
				if (iIndex == 0)
				{
					DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_PVE;
					this.CurSelFightType = FightTypeLabel.PVE;
					if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
					{
						this.Totalsp.text = this.totalsp.ToString();
						this.scrollRect.normalizedPosition = this.mPveSrowViewPos1;
					}
					else
					{
						this.Totalsp.text = this.totalsp2.ToString();
						this.scrollRect.normalizedPosition = this.mPveSrowViewPos2;
					}
				}
				else
				{
					DataManager<SkillDataManager>.GetInstance().CurSkillConfigType = SkillConfigType.SKILL_CONFIG_PVP;
					this.CurSelFightType = FightTypeLabel.PVP;
					if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
					{
						this.Totalsp.text = this.pvpTotalsp.ToString();
						this.scrollRect.normalizedPosition = this.mPvpSrowViewPos1;
					}
					else
					{
						this.Totalsp.text = this.pvpTotalsp2.ToString();
						this.scrollRect.normalizedPosition = this.mPvpSrowViewPos2;
					}
				}
				this.UpdatePlanIsFull();
				this.UpdateLeftInterface(false);
				this.UpdateRightInterface();
				if ((this.IsOpenSkillPlanPVE && iIndex == 0) || (this.IsOpenSkillPlanPVP && iIndex == 2))
				{
					this.mPlanTips.gameObject.CustomActive(false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillPlanFrame>(FrameLayer.Middle, null, string.Empty);
					this.mLevelDown.CustomActive(false);
					this.mLevelUp.CustomActive(false);
					this.mMaxRoot.CustomActive(false);
					this.mSkillPlanText.text = "返回";
					this.UpdateSkillInitConfigRoot(true);
				}
			}
			if (iIndex == 1)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChangeJobSelectPreviewFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (iIndex == 3)
			{
				this.mChangeJobTips.gameObject.CustomActive(false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillBattleSettingFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (iIndex == 2)
			{
				this._HideOrShowPVPOrPVEConfig(false);
			}
			else if (iIndex == 0)
			{
				this._HideOrShowPVPOrPVEConfig(true);
			}
		}

		// Token: 0x06010C4D RID: 68685 RVA: 0x004C44C4 File Offset: 0x004C28C4
		private void OnChooseSkill(int iIndex, bool value)
		{
			if (!value || iIndex < 0)
			{
				return;
			}
			SkillTreeFrame.CurSelSkillTreeBtnIdx = iIndex;
			this.UpdateRightInterface();
			if (SkillPlanFrame.bIsAddSkillBarState)
			{
			}
			SkillTreeFrame.bIsApplySkillState = true;
			this.mSkillDesScrollRect.verticalNormalizedPosition = 1f;
			this.mLeftSkillDesScrollRect.verticalNormalizedPosition = 1f;
			this.mRightSkillDesScrollRect.verticalNormalizedPosition = 1f;
		}

		// Token: 0x06010C4E RID: 68686 RVA: 0x004C4530 File Offset: 0x004C2930
		private void OnbtSave()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				if (SkillTreeFrame.ChangedSkills.Count > 0)
				{
					this.SendSkillChanged(SkillConfigType.SKILL_CONFIG_PVE);
				}
				if (SkillTreeFrame.pvpChangedSkills.Count > 0)
				{
					this.SendSkillChanged(SkillConfigType.SKILL_CONFIG_PVP);
				}
				if (SkillTreeFrame.ChangedSkills2.Count > 0)
				{
					this.SendSkillChanged(SkillConfigType.SKILL_CONFIG_PVE);
				}
				if (SkillTreeFrame.pvpChangedSkills2.Count > 0)
				{
					this.SendSkillChanged(SkillConfigType.SKILL_CONFIG_PVP);
				}
			}
		}

		// Token: 0x06010C4F RID: 68687 RVA: 0x004C45B0 File Offset: 0x004C29B0
		private void SendSkillChanged(SkillConfigType skillType)
		{
			NetManager netManager = NetManager.Instance();
			ChangeSkill[] array;
			if (skillType == SkillConfigType.SKILL_CONFIG_PVE)
			{
				array = SkillTreeFrame.CalSkillChange();
			}
			else
			{
				array = SkillTreeFrame.pvpCalSkillChange();
			}
			if (array.Length > 0)
			{
				netManager.SendCommand<SceneChangeSkillsReq>(ServerType.GATE_SERVER, new SceneChangeSkillsReq
				{
					skills = array,
					configType = (byte)skillType
				});
			}
			if (skillType == SkillConfigType.SKILL_CONFIG_PVE)
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					SkillTreeFrame.ChangedSkills.Clear();
				}
				else
				{
					SkillTreeFrame.ChangedSkills2.Clear();
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				SkillTreeFrame.pvpChangedSkills.Clear();
			}
			else
			{
				SkillTreeFrame.pvpChangedSkills2.Clear();
			}
		}

		// Token: 0x06010C50 RID: 68688 RVA: 0x004C4660 File Offset: 0x004C2A60
		[MessageHandle(500702U, false, 0)]
		private void OnSaveSkillChangeRet(MsgDATA msg)
		{
			SceneChangeSkillsRes sceneChangeSkillsRes = new SceneChangeSkillsRes();
			sceneChangeSkillsRes.decode(msg.bytes);
			if (sceneChangeSkillsRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneChangeSkillsRes.result, string.Empty);
			}
		}

		// Token: 0x06010C51 RID: 68689 RVA: 0x004C469F File Offset: 0x004C2A9F
		private void updateSkillTree(SkillConfigType skillType)
		{
		}

		// Token: 0x06010C52 RID: 68690 RVA: 0x004C46A4 File Offset: 0x004C2AA4
		private void InitInterface()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.JobType == 0)
			{
				this.mPassiveSkillRootObj.CustomActive(false);
				this.mChangeJobPreview.CustomActive(true);
				this.mChangeJobTips.gameObject.CustomActive(true);
			}
			else
			{
				this.mPassiveSkillRootObj.CustomActive(true);
				this.mChangeJobPreview.CustomActive(false);
				this.mChangeJobTips.gameObject.CustomActive(false);
			}
			this.totalsp = DataManager<PlayerBaseData>.GetInstance().SP;
			this.totalsp2 = DataManager<PlayerBaseData>.GetInstance().SP2;
			this.pvpTotalsp = DataManager<PlayerBaseData>.GetInstance().pvpSP;
			this.pvpTotalsp2 = DataManager<PlayerBaseData>.GetInstance().pvpSP2;
			this.totalgold = DataManager<PlayerBaseData>.GetInstance().Gold;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.Totalsp.text = this.totalsp.ToString();
				}
				else
				{
					this.Totalsp.text = this.totalsp2.ToString();
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				this.Totalsp.text = this.pvpTotalsp.ToString();
			}
			else
			{
				this.Totalsp.text = this.pvpTotalsp2.ToString();
			}
			UIGray uigray = this.mLevelUp.gameObject.AddComponent<UIGray>();
			uigray.bEnabled2Text = false;
			uigray.enabled = false;
			UIGray uigray2 = this.mLevelDown.gameObject.AddComponent<UIGray>();
			uigray2.bEnabled2Text = false;
			uigray2.enabled = false;
			this.InitSkillData();
			this.CreateSkillTreePreFerb();
			this.UpdateCurSelSkillIndex(SkillTreeFrame.skillPos, DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill);
			this.InitDragBackBind();
			this.UpdateIsUniteDeployInit();
			this.SetTryOpenPVPSkillTree();
			this._InitUnlockSkillConfig2NeedParams();
			this._InitScrollPos();
		}

		// Token: 0x06010C53 RID: 68691 RVA: 0x004C48B4 File Offset: 0x004C2CB4
		private void CreateSkillTreePreFerb()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.UniqueSkillobj = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.UniqueSkillPath, true, 0U);
			if (this.UniqueSkillobj == null)
			{
				Logger.LogError("can't create obj in SkillTreeFrame");
				return;
			}
			this.UniqueSkillobj.transform.SetParent(this.mActiveSkillRoot.transform, false);
			this.SkillTreeScrollView = Utility.FindGameObject(this.frame, this.LeftRootPath, true);
			if (this.SkillTreeScrollView == null)
			{
				return;
			}
			this.scrollRect = this.SkillTreeScrollView.GetComponent<ScrollRect>();
			if (this.scrollRect == null)
			{
				return;
			}
			this.scrollRect.onValueChanged.RemoveAllListeners();
			this.scrollRect.onValueChanged.AddListener(new UnityAction<Vector2>(this._OnScrolRectValueChanged));
			this.uniqueContent = Utility.FindGameObject(this.frame, this.LeftRootPath + "/Viewport/Content", true);
			if (this.uniqueContent == null)
			{
				return;
			}
			RectTransform[] componentsInChildren = this.UniqueSkillobj.GetComponentsInChildren<RectTransform>();
			SkillTreeFrame.uniqueSkillTransform = new List<string>();
			int num = 1;
			int num2 = 1;
			SkillTreeFrame.skillPos.Clear();
			this.skillPosPanelIndexList.Clear();
			this.SkillTreeElementTemplate = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.SkillTreeElementPath, true, 0U);
			this.SkillTreeElementTemplate.name = this.SkillTreeElementTemplate.name.Replace("(Clone)", string.Empty);
			int i = 0;
			while (i < componentsInChildren.Length)
			{
				if (!(componentsInChildren[i].name == string.Format("ActiveSkillPanel{0}", num)))
				{
					goto IL_1E4;
				}
				if (num <= tableItem.MaxSkillPanelIndex)
				{
					num++;
					goto IL_1E4;
				}
				componentsInChildren[i].gameObject.CustomActive(false);
				num++;
				IL_24E:
				i++;
				continue;
				IL_1E4:
				if (componentsInChildren[i].name == string.Format("Pos{0}", num2))
				{
					componentsInChildren[i].gameObject.CustomActive(false);
					SkillTreeFrame.uniqueSkillTransform.Add(componentsInChildren[i].name);
					SkillTreeFrame.skillPos.Add(componentsInChildren[i].gameObject);
					this.skillPosPanelIndexList.Add(num - 1);
					num2++;
					goto IL_24E;
				}
				goto IL_24E;
			}
		}

		// Token: 0x06010C54 RID: 68692 RVA: 0x004C4B20 File Offset: 0x004C2F20
		private void _OnScrolRectValueChanged(Vector2 v)
		{
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.mPveSrowViewPos1 = v;
				}
				else
				{
					this.mPveSrowViewPos2 = v;
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				this.mPvpSrowViewPos1 = v;
			}
			else
			{
				this.mPvpSrowViewPos2 = v;
			}
		}

		// Token: 0x06010C55 RID: 68693 RVA: 0x004C4B88 File Offset: 0x004C2F88
		private void InitSkillData()
		{
			int num = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			if (num > playerMaxLv)
			{
				num = playerMaxLv;
				Logger.LogError(string.Format("[ExpTable] can't find ID : [{0}], and use max level = lv60", DataManager<PlayerBaseData>.GetInstance().Level));
			}
			ExpTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ExpTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("[ExpTable] can't find ID : [{0}]", num));
				return;
			}
			SkillPlanFrame.UnLockSkillBarNum = tableItem.SkillNum;
			if (num >= DataManager<SkillDataManager>.GetInstance().UnLockTaskLvl && !DataManager<SkillDataManager>.GetInstance().IsFinishUnlockTask)
			{
				SkillPlanFrame.UnLockSkillBarNum--;
			}
			SkillPlanFrame.UpdateSkillBar();
		}

		// Token: 0x06010C56 RID: 68694 RVA: 0x004C4C44 File Offset: 0x004C3044
		private void UpdateCurSelSkillIndex(List<GameObject> skillPos, Dictionary<int, int> ButtonBindSkill)
		{
			SkillTreeFrame.CurSelSkillTreeBtnIdx = -1;
			SkillTreeFrame.CurSelSkillTreeID = 0;
			this.CurSelSkillLv = 0;
			for (int i = 0; i < skillPos.Count; i++)
			{
				ComSkillTreeEle componentInChildren = skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					if (componentInChildren.SkillToggle.isOn)
					{
						int num = -1;
						if (ButtonBindSkill.TryGetValue(i + 1, out num))
						{
							SkillTreeFrame.CurSelSkillTreeBtnIdx = i;
							SkillTreeFrame.CurSelSkillTreeID = (ushort)num;
							this.CurSelSkillLv = SkillTreeFrame.CalFinalShowLv((ushort)num);
							return;
						}
					}
				}
			}
		}

		// Token: 0x06010C57 RID: 68695 RVA: 0x004C4CD8 File Offset: 0x004C30D8
		private void UpdateLeftInterface(bool IsInit)
		{
			List<ItemProperty> equipedEquipments = DataManager<PlayerBaseData>.GetInstance().GetEquipedEquipments();
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				this.AddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(true, equipedEquipments, SkillSystemSourceType.None);
			}
			else
			{
				this.pvpAddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, equipedEquipments, SkillSystemSourceType.None);
			}
			base.StartCoroutine(this.UpdateSkillTree(DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill, IsInit));
		}

		// Token: 0x06010C58 RID: 68696 RVA: 0x004C4D42 File Offset: 0x004C3142
		private void UpdateRightInterface()
		{
			this.UpdateSelSkillInfoNew(DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill);
		}

		// Token: 0x06010C59 RID: 68697 RVA: 0x004C4D54 File Offset: 0x004C3154
		private void InitDragBind()
		{
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				int index = i;
				ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[index].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					Drag_Me component = componentInChildren.SkillIcon.GetComponent<Drag_Me>();
					Drag_Me drag_Me = component;
					if (SkillTreeFrame.<>f__mg$cache0 == null)
					{
						SkillTreeFrame.<>f__mg$cache0 = new Drag_Me.OnResDrag(SkillPlanFrame.DealDrag);
					}
					drag_Me.ResponseDrag = SkillTreeFrame.<>f__mg$cache0;
				}
			}
		}

		// Token: 0x06010C5A RID: 68698 RVA: 0x004C4DD0 File Offset: 0x004C31D0
		private void InitDragBackBind()
		{
			Drop_Me component = this.back.GetComponent<Drop_Me>();
			Drop_Me drop_Me = component;
			if (SkillTreeFrame.<>f__mg$cache1 == null)
			{
				SkillTreeFrame.<>f__mg$cache1 = new Drop_Me.OnResDrop(SkillPlanFrame.DealDrop);
			}
			drop_Me.ResponseDrop = SkillTreeFrame.<>f__mg$cache1;
			component.SetHighLight(false);
			component.SetAutoReplace(false);
			Drop_Me component2 = this.mActiveSkillRoot.GetComponent<Drop_Me>();
			Drop_Me drop_Me2 = component2;
			if (SkillTreeFrame.<>f__mg$cache2 == null)
			{
				SkillTreeFrame.<>f__mg$cache2 = new Drop_Me.OnResDrop(SkillPlanFrame.DealDrop);
			}
			drop_Me2.ResponseDrop = SkillTreeFrame.<>f__mg$cache2;
			component2.SetHighLight(false);
			component2.SetAutoReplace(false);
		}

		// Token: 0x06010C5B RID: 68699 RVA: 0x004C4E58 File Offset: 0x004C3258
		private void UpdateChangedSkill(bool bIsUp)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillTreeFrame.CurSelSkillTreeID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", SkillTreeFrame.CurSelSkillTreeID));
				return;
			}
			if (SkillTreeFrame.CurSelSkillTreeBtnIdx < 0)
			{
				Logger.LogError("当前选择技能按钮索引小于0");
				return;
			}
			this.UpdateLvChangedSkillInfo(tableItem, bIsUp);
		}

		// Token: 0x06010C5C RID: 68700 RVA: 0x004C4EC0 File Offset: 0x004C32C0
		private ComSkillTreeEle CreateComSkillTreeEle(GameObject rootGameObject, int skillIndex, int panelIndex)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.SkillTreeElementTemplate);
			if (gameObject == null)
			{
				return null;
			}
			Utility.AttachTo(gameObject, rootGameObject, false);
			ComSkillTreeEle componentInChildren = gameObject.GetComponentInChildren<ComSkillTreeEle>();
			if (componentInChildren == null)
			{
				return null;
			}
			if (rootGameObject.transform.parent != null)
			{
				RectTransform component = rootGameObject.transform.parent.GetComponent<RectTransform>();
				if (component != null)
				{
					componentInChildren.mrt = component;
				}
			}
			componentInChildren.iPanelIndex = panelIndex;
			componentInChildren.SkillToggle.group = this.UniqueSkillobj.GetComponentInChildren<ToggleGroup>();
			componentInChildren.SkillToggle.onValueChanged.RemoveAllListeners();
			componentInChildren.SkillToggle.onValueChanged.AddListener(delegate(bool value)
			{
				this.OnChooseSkill(skillIndex, value);
			});
			if (skillIndex == 5)
			{
				componentInChildren.SkillToggle.isOn = true;
			}
			return componentInChildren;
		}

		// Token: 0x06010C5D RID: 68701 RVA: 0x004C4FB4 File Offset: 0x004C33B4
		private IEnumerator UpdateSkillTree(Dictionary<int, int> ButtonBindSkill, bool IsInit)
		{
			yield return null;
			List<int> AlreadyShowNewOpenSkill = new List<int>();
			List<int> NewOpenSkillList = new List<int>();
			ComSkillTreeEle lastSkill = null;
			Dictionary<int, ComSkillTreeEle> skillTreeEleDic = new Dictionary<int, ComSkillTreeEle>();
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				ComSkillTreeEle comSkillTreeEle = SkillTreeFrame.skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (comSkillTreeEle == null)
				{
					comSkillTreeEle = this.CreateComSkillTreeEle(SkillTreeFrame.skillPos[i], i, this.skillPosPanelIndexList[i]);
				}
				if (!(comSkillTreeEle == null))
				{
					comSkillTreeEle.SkillAddlevel.text = string.Empty;
					int num = -1;
					if (!ButtonBindSkill.TryGetValue(i + 1, out num) || num == -1)
					{
						SkillTreeFrame.skillPos[i].gameObject.CustomActive(false);
					}
					else
					{
						SkillTreeFrame.skillPos[i].gameObject.CustomActive(true);
						SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
						byte b = SkillTreeFrame.CalFinalShowLv((ushort)num);
						bool bIsNewOpen = false;
						if ((int)b >= tableItem.TopLevelLimit)
						{
							comSkillTreeEle.SkillNames.color = Color.white;
							comSkillTreeEle.Skilllevel.text = "Lv." + tableItem.TopLevelLimit.ToString() + "/" + tableItem.TopLevelLimit.ToString();
							skillTreeEleDic.Add(num, comSkillTreeEle);
							lastSkill = comSkillTreeEle;
						}
						else
						{
							if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit && tableItem.IsPreJob == 0)
							{
								comSkillTreeEle.Skilllevel.text = "Lv.0/" + tableItem.TopLevelLimit.ToString();
								comSkillTreeEle.Skilllevel.color = Color.gray;
								comSkillTreeEle.SkillNames.color = Color.gray;
							}
							else
							{
								if (b <= 0)
								{
									comSkillTreeEle.Skilllevel.text = "Lv.0/" + tableItem.TopLevelLimit.ToString();
									comSkillTreeEle.Skilllevel.color = Color.gray;
									if (lastSkill == null)
									{
									}
								}
								else
								{
									comSkillTreeEle.Skilllevel.text = "Lv." + b.ToString() + "/" + tableItem.TopLevelLimit.ToString();
									comSkillTreeEle.Skilllevel.color = Color.white;
									skillTreeEleDic.Add(num, comSkillTreeEle);
									lastSkill = comSkillTreeEle;
								}
								comSkillTreeEle.SkillNames.color = Color.white;
								NewOpenSkillList = DataManager<SkillDataManager>.GetInstance().NewOpenUniSkillList;
								for (int j = 0; j < NewOpenSkillList.Count; j++)
								{
									if (num == NewOpenSkillList[j])
									{
										this.PlayNewSkillEffect(ref comSkillTreeEle.SkillIcon);
										if (!DataManager<SkillDataManager>.GetInstance().IsEquipSkill(num))
										{
											comSkillTreeEle.NewIcon.gameObject.CustomActive(true);
										}
										else
										{
											comSkillTreeEle.NewIcon.gameObject.CustomActive(false);
										}
										AlreadyShowNewOpenSkill.Add(num);
										bIsNewOpen = true;
										break;
									}
								}
							}
							comSkillTreeEle.Skilllevel.gameObject.CustomActive(true);
						}
						this.UpdateShowLvUpImage(comSkillTreeEle, (ushort)num, b, false, bIsNewOpen);
						if (i < 5)
						{
							comSkillTreeEle.SkillNames.text = tableItem.Name;
							comSkillTreeEle.Skilllevel.text = string.Empty;
						}
						else
						{
							comSkillTreeEle.SkillNames.text = string.Empty;
						}
						this.ClearSkillLvUpEffect(comSkillTreeEle, i);
						this.ClearSkillLvDownEffect(comSkillTreeEle, i);
						if (tableItem.Icon != "-")
						{
							ETCImageLoader.LoadSprite(ref comSkillTreeEle.SkillIcon, tableItem.Icon, true);
							comSkillTreeEle.SkillIcon.GetComponent<UIGray>().ResetMaterial();
							if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit && tableItem.IsPreJob == 0)
							{
								this.UpdatePvpForbid(ref comSkillTreeEle, num, true);
							}
							else if (DataManager<SkillDataManager>.GetInstance().CanLvUpByCurRoleLv(tableItem, b))
							{
								if (b <= 0)
								{
									this.UpdatePvpForbid(ref comSkillTreeEle, num, true);
								}
								else
								{
									this.UpdatePvpForbid(ref comSkillTreeEle, num, false);
								}
							}
							else
							{
								this.UpdatePvpForbid(ref comSkillTreeEle, num, false);
							}
							comSkillTreeEle.SkillIcon.gameObject.CustomActive(true);
						}
						else
						{
							comSkillTreeEle.SkillIcon.gameObject.CustomActive(false);
						}
						if (SkillTreeFrame.CheckAllocate(num))
						{
							comSkillTreeEle.SkillAllocate.gameObject.CustomActive(true);
						}
						else
						{
							comSkillTreeEle.SkillAllocate.gameObject.CustomActive(false);
						}
						if (tableItem.SkillCategory == 4)
						{
							if (DataManager<PlayerBaseData>.GetInstance().AwakeState <= 0)
							{
								comSkillTreeEle.AwakeText.text = "完成觉醒任务后解锁";
								comSkillTreeEle.AwakeText.gameObject.CustomActive(true);
							}
							else
							{
								comSkillTreeEle.AwakeText.gameObject.CustomActive(false);
								if (tableItem.SkillType == SkillTable.eSkillType.ACTIVE && DataManager<SkillDataManager>.GetInstance().isPve())
								{
									bool flag = b <= 0;
									if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
									{
										DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray = flag;
									}
									else if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page2)
									{
										DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray2 = flag;
									}
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePassiveSkillGray, null, null, null, null);
								}
							}
						}
					}
				}
			}
			yield return null;
			foreach (KeyValuePair<int, ComSkillTreeEle> keyValuePair in skillTreeEleDic)
			{
				int addLevel = this.GetAddLevel(keyValuePair.Key);
				if (addLevel > 0)
				{
					Dictionary<int, ComSkillTreeEle>.Enumerator curItemIter;
					KeyValuePair<int, ComSkillTreeEle> keyValuePair2 = curItemIter.Current;
					keyValuePair2.Value.SkillAddlevel.text = string.Format("(+{0})", addLevel);
				}
				else
				{
					Dictionary<int, ComSkillTreeEle>.Enumerator curItemIter;
					KeyValuePair<int, ComSkillTreeEle> keyValuePair3 = curItemIter.Current;
					keyValuePair3.Value.SkillAddlevel.text = string.Empty;
				}
			}
			yield return null;
			skillTreeEleDic.Clear();
			DataManager<SkillDataManager>.GetInstance().UpdateLockSkillList(AlreadyShowNewOpenSkill);
			if (!(lastSkill != null) || IsInit)
			{
			}
			this.InitDragBind();
			yield break;
		}

		// Token: 0x06010C5E RID: 68702 RVA: 0x004C4FE0 File Offset: 0x004C33E0
		private void UpdateSelSkillInfoNew(Dictionary<int, int> ButtonBindSkill)
		{
			SkillTreeFrame.CurSelSkillTreeID = 0;
			this.CurSelSkillLv = 0;
			if (SkillTreeFrame.CurSelSkillTreeBtnIdx < 0 || SkillTreeFrame.CurSelSkillTreeBtnIdx >= SkillTreeFrame.skillPos.Count)
			{
				return;
			}
			int num = -1;
			if (!ButtonBindSkill.TryGetValue(SkillTreeFrame.CurSelSkillTreeBtnIdx + 1, out num) || num == -1)
			{
				return;
			}
			ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[SkillTreeFrame.CurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			if (componentInChildren == null)
			{
				return;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", num));
				return;
			}
			this.mRightRoot.CustomActive(true);
			SkillTreeFrame.CurSelSkillTreeID = (ushort)num;
			this.CurSelSkillLv = SkillTreeFrame.CalFinalShowLv((ushort)num);
			ETCImageLoader.LoadSprite(ref this.mRightSkillIcon, tableItem.Icon, true);
			this.mRightSkillName.text = tableItem.Name;
			int addLevel = this.GetAddLevel((int)SkillTreeFrame.CurSelSkillTreeID);
			this.mRightAddLevel.text = string.Empty;
			if (addLevel > 0)
			{
				this.mRightAddLevel.text = string.Format("(+{0})", addLevel);
			}
			else
			{
				this.mRightAddLevel.text = string.Empty;
			}
			this.UpdateRightLevel(SkillTreeFrame.skillPos, tableItem, addLevel);
			this.UpdateSkillAttribute(tableItem);
			this.UpdateDescription(tableItem);
			this.UpdateSkillCDText((ushort)num, tableItem, this.CurSelSkillLv);
			this.UpdateSkillConsumeMP(tableItem, this.CurSelSkillLv);
			this.UpdateLvProperty(tableItem, this.CurSelSkillLv, this.CurSelFightType);
			this.UpdateNeedSp(tableItem);
			this.UpdateLvUpDownBtnState(componentInChildren, SkillTreeFrame.CurSelSkillTreeID, this.CurSelSkillLv, false);
			this.UpdateLimitLv(tableItem);
		}

		// Token: 0x06010C5F RID: 68703 RVA: 0x004C5190 File Offset: 0x004C3590
		private void UpdateLvChangedSkillInfo(SkillTable skilldata, bool bIsUp)
		{
			byte b = 0;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					if (SkillTreeFrame.ChangedSkills.TryGetValue(SkillTreeFrame.CurSelSkillTreeID, out b))
					{
						SkillTreeFrame.ChangedSkills.Remove(SkillTreeFrame.CurSelSkillTreeID);
					}
				}
				else if (SkillTreeFrame.ChangedSkills2.TryGetValue(SkillTreeFrame.CurSelSkillTreeID, out b))
				{
					SkillTreeFrame.ChangedSkills2.Remove(SkillTreeFrame.CurSelSkillTreeID);
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				if (SkillTreeFrame.pvpChangedSkills.TryGetValue(SkillTreeFrame.CurSelSkillTreeID, out b))
				{
					SkillTreeFrame.pvpChangedSkills.Remove(SkillTreeFrame.CurSelSkillTreeID);
				}
			}
			else if (SkillTreeFrame.pvpChangedSkills2.TryGetValue(SkillTreeFrame.CurSelSkillTreeID, out b))
			{
				SkillTreeFrame.pvpChangedSkills2.Remove(SkillTreeFrame.CurSelSkillTreeID);
			}
			if (bIsUp)
			{
				b += 1;
				if (DataManager<SkillDataManager>.GetInstance().isPve())
				{
					if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
					{
						this.totalsp -= (uint)((ushort)skilldata.LearnSPCost);
					}
					else
					{
						this.totalsp2 -= (uint)((ushort)skilldata.LearnSPCost);
					}
				}
				else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					this.pvpTotalsp -= (uint)((ushort)skilldata.LearnSPCost);
				}
				else
				{
					this.pvpTotalsp2 -= (uint)((ushort)skilldata.LearnSPCost);
				}
			}
			else
			{
				b -= 1;
				if (DataManager<SkillDataManager>.GetInstance().isPve())
				{
					if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
					{
						this.totalsp += (uint)((ushort)skilldata.LearnSPCost);
					}
					else
					{
						this.totalsp2 += (uint)((ushort)skilldata.LearnSPCost);
					}
				}
				else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					this.pvpTotalsp += (uint)((ushort)skilldata.LearnSPCost);
				}
				else
				{
					this.pvpTotalsp2 += (uint)((ushort)skilldata.LearnSPCost);
				}
			}
			if (b != 0)
			{
				if (DataManager<SkillDataManager>.GetInstance().isPve())
				{
					if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
					{
						SkillTreeFrame.ChangedSkills.Add(SkillTreeFrame.CurSelSkillTreeID, b);
					}
					else
					{
						SkillTreeFrame.ChangedSkills2.Add(SkillTreeFrame.CurSelSkillTreeID, b);
					}
				}
				else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
				{
					SkillTreeFrame.pvpChangedSkills.Add(SkillTreeFrame.CurSelSkillTreeID, b);
				}
				else
				{
					SkillTreeFrame.pvpChangedSkills2.Add(SkillTreeFrame.CurSelSkillTreeID, b);
				}
			}
			int addLevel = this.GetAddLevel((int)SkillTreeFrame.CurSelSkillTreeID);
			ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[SkillTreeFrame.CurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			this.UpdateLvProperty(skilldata, this.CurSelSkillLv, this.CurSelFightType);
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.Totalsp.text = this.totalsp.ToString();
				}
				else
				{
					this.Totalsp.text = this.totalsp2.ToString();
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				this.Totalsp.text = this.pvpTotalsp.ToString();
			}
			else
			{
				this.Totalsp.text = this.pvpTotalsp2.ToString();
			}
			if (skilldata.SkillType == SkillTable.eSkillType.ACTIVE && skilldata.SkillCategory == 4 && DataManager<SkillDataManager>.GetInstance().isPve())
			{
				bool flag = this.CurSelSkillLv <= 0;
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray = flag;
				}
				else if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page2)
				{
					DataManager<SkillDataManager>.GetInstance().ActiveAwakeSkillIsGray2 = flag;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePassiveSkillGray, null, null, null, null);
			}
			if ((int)this.CurSelSkillLv >= skilldata.TopLevelLimit)
			{
				componentInChildren.Skilllevel.text = "Lv." + skilldata.TopLevelLimit.ToString() + "/" + skilldata.TopLevelLimit.ToString();
				componentInChildren.Skilllevel.color = Color.white;
				componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(false);
			}
			else if ((int)DataManager<PlayerBaseData>.GetInstance().Level < skilldata.LevelLimit && skilldata.IsPreJob == 0)
			{
				componentInChildren.Skilllevel.text = "Lv.0/" + skilldata.TopLevelLimit.ToString();
				componentInChildren.Skilllevel.color = Color.gray;
				componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(true);
			}
			else
			{
				if (this.CurSelSkillLv <= 0)
				{
					componentInChildren.Skilllevel.text = "Lv.0/" + skilldata.TopLevelLimit.ToString();
					componentInChildren.Skilllevel.color = Color.gray;
					componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(true);
				}
				else
				{
					componentInChildren.Skilllevel.text = "Lv." + this.CurSelSkillLv.ToString() + "/" + skilldata.TopLevelLimit.ToString();
					componentInChildren.Skilllevel.color = Color.white;
					componentInChildren.SkillIcon.GetComponent<UIGray>().SetEnable(false);
				}
				if (bIsUp)
				{
					this.PlaySkillLvUpEffect(ref componentInChildren);
				}
				else
				{
					this.PlaySkillLvDownEffect(ref componentInChildren);
				}
			}
			if (SkillTreeFrame.CurSelSkillTreeBtnIdx < 5)
			{
				componentInChildren.Skilllevel.gameObject.CustomActive(false);
			}
			this.UpdateSkillLvUp();
			this.UpdateLvUpDownBtnState(componentInChildren, SkillTreeFrame.CurSelSkillTreeID, this.CurSelSkillLv, false);
			this.UpdateRightLevel(SkillTreeFrame.skillPos, skilldata, addLevel);
			this.UpdateNeedSp(skilldata);
			this.UpdateSkillConsumeMP(skilldata, this.CurSelSkillLv);
			this.UpdateSkillCDText((ushort)skilldata.ID, skilldata, this.CurSelSkillLv);
			if (bIsUp && this.CurSelSkillLv == 1 && skilldata.SkillType == SkillTable.eSkillType.ACTIVE)
			{
				DOTweenAnimation[] components = this.mPlanTips.GetComponents<DOTweenAnimation>();
				DOTweenAnimation[] components2 = this.mPlanTipsText.GetComponents<DOTweenAnimation>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].DORestart(false);
					components2[i].DORestart(false);
				}
				this.mPlanTipsText.text = TR.Value("skill point01");
				this.mPlanTips.CustomActive(true);
			}
			else
			{
				this.mPlanTips.CustomActive(false);
			}
		}

		// Token: 0x06010C60 RID: 68704 RVA: 0x004C584C File Offset: 0x004C3C4C
		private void UpdateRightLevel(List<GameObject> skillPos, SkillTable skilldata, int AddedLv)
		{
			if (skilldata == null)
			{
				return;
			}
			this.mRightSkillLevel.text = string.Format("Lv.{0}", this.CurSelSkillLv);
			float num = (float)TableManager.GetValueFromUnionCell(skilldata.RefreshTime, (int)this.CurSelSkillLv + AddedLv, true) / 1000f;
			if ((int)this.CurSelSkillLv >= skilldata.TopLevelLimit)
			{
				this.mLevelMaxImage.CustomActive(true);
				this.mLevelLimitDes.CustomActive(true);
				this.mNeedLevel.CustomActive(false);
				this.mNeedSP.CustomActive(false);
			}
			else
			{
				this.mLevelMaxImage.CustomActive(false);
				this.mLevelLimitDes.CustomActive(false);
				this.mNeedLevel.CustomActive(true);
				this.mNeedSP.CustomActive(true);
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < skilldata.LevelLimit && skilldata.IsPreJob == 0)
				{
					this.mNeedLevel.text = string.Format("{0}级开放", skilldata.LevelLimit);
					this.mNeedLevel.color = Color.red;
				}
				else
				{
					int skillNextOpenNeedRoleLv = DataManager<SkillDataManager>.GetInstance().GetSkillNextOpenNeedRoleLv(skilldata, (int)this.CurSelSkillLv);
					this.mNeedLevel.text = string.Format("等级需求:{0}", skillNextOpenNeedRoleLv);
					if (skillNextOpenNeedRoleLv > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						this.mNeedLevel.color = Color.red;
					}
					else
					{
						this.mNeedLevel.color = Color.white;
					}
				}
			}
		}

		// Token: 0x06010C61 RID: 68705 RVA: 0x004C59CC File Offset: 0x004C3DCC
		private void UpdateSkillAttribute(SkillTable skillData)
		{
			for (int i = 0; i < this.attributeTypeGo.Length; i++)
			{
				this.attributeTypeGo[i].gameObject.CustomActive(false);
			}
			if (skillData == null)
			{
				return;
			}
			if (skillData.SkillEffect == null)
			{
				return;
			}
			for (int j = 0; j < skillData.SkillEffect.Count; j++)
			{
				if (j < 6)
				{
					string skillTypeText = this.getSkillTypeText((byte)skillData.SkillEffect[j]);
					if (!(skillTypeText == string.Empty))
					{
						this.attributeTypeText[j].text = skillTypeText;
						this.attributeTypeGo[j].gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x06010C62 RID: 68706 RVA: 0x004C5A8C File Offset: 0x004C3E8C
		private void UpdateNeedSp(SkillTable skillData)
		{
			int num;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					num = (int)this.totalsp;
				}
				else
				{
					num = (int)this.totalsp2;
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				num = (int)this.pvpTotalsp;
			}
			else
			{
				num = (int)this.pvpTotalsp2;
			}
			this.mNeedSP.text = string.Format("消耗技能点:{0}", skillData.LearnSPCost.ToString());
			if (num < skillData.LearnSPCost)
			{
				this.mNeedSP.color = Color.red;
			}
			else
			{
				this.mNeedSP.color = Color.white;
			}
		}

		// Token: 0x06010C63 RID: 68707 RVA: 0x004C5B4C File Offset: 0x004C3F4C
		public static void UpdateSelSkillAllocate(int SkillID)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					int num = -1;
					if (!dictionary.TryGetValue(i + 1, out num))
					{
						componentInChildren.SkillAllocate.gameObject.CustomActive(false);
					}
					else if (num == SkillID)
					{
						if (SkillTreeFrame.CheckAllocate(num))
						{
							componentInChildren.SkillAllocate.gameObject.CustomActive(true);
						}
						else
						{
							componentInChildren.SkillAllocate.gameObject.CustomActive(false);
						}
					}
				}
			}
		}

		// Token: 0x06010C64 RID: 68708 RVA: 0x004C5C10 File Offset: 0x004C4010
		private void UpdateSkillLvUp()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					int num = -1;
					if (!dictionary.TryGetValue(i + 1, out num))
					{
						componentInChildren.SkillLvUp.gameObject.CustomActive(false);
					}
					else
					{
						byte skillLv;
						if (i == SkillTreeFrame.CurSelSkillTreeBtnIdx)
						{
							skillLv = this.CurSelSkillLv;
						}
						else
						{
							skillLv = SkillTreeFrame.CalFinalShowLv((ushort)num);
						}
						this.UpdateShowLvUpImage(componentInChildren, (ushort)num, skillLv, false, false);
					}
				}
			}
		}

		// Token: 0x06010C65 RID: 68709 RVA: 0x004C5CC4 File Offset: 0x004C40C4
		private void UpdateSkillAddedLv()
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			dictionary = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			this.AddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(true, null, SkillSystemSourceType.None);
			this.pvpAddSkillInfo = DataManager<SkillDataManager>.GetInstance().GetSkillLevelAddInfo(false, null, SkillSystemSourceType.None);
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[i].GetComponentInChildren<ComSkillTreeEle>();
				if (!(componentInChildren == null))
				{
					int num = -1;
					if (!dictionary.TryGetValue(i + 1, out num))
					{
						componentInChildren.SkillLvUp.gameObject.CustomActive(false);
					}
					else
					{
						int addLevel = this.GetAddLevel(num);
						if (addLevel > 0)
						{
							componentInChildren.SkillAddlevel.text = string.Format("(+{0})", addLevel);
						}
						else
						{
							componentInChildren.SkillAddlevel.text = string.Empty;
						}
						if (num == (int)SkillTreeFrame.CurSelSkillTreeID)
						{
							if (addLevel > 0)
							{
								this.mRightAddLevel.text = string.Format("(+{0})", addLevel);
							}
							else
							{
								this.mRightAddLevel.text = string.Empty;
							}
						}
					}
				}
			}
		}

		// Token: 0x06010C66 RID: 68710 RVA: 0x004C5DF4 File Offset: 0x004C41F4
		private void UpdateShowLvUpImage(ComSkillTreeEle comele, ushort SkillID, byte SkillLv, bool ShowNotify = true, bool bIsNewOpen = false)
		{
			if (this.CheckLvUp(SkillID, SkillLv, false))
			{
				comele.CanLearn.gameObject.CustomActive(false);
				if (SkillLv > 0)
				{
					comele.SkillLvUp.gameObject.CustomActive(true);
					comele.redpoint.gameObject.CustomActive(false);
				}
				else
				{
					comele.SkillLvUp.gameObject.CustomActive(false);
					comele.redpoint.gameObject.CustomActive(true);
					if (!bIsNewOpen)
					{
						comele.CanLearn.gameObject.CustomActive(true);
					}
				}
			}
			else
			{
				comele.SkillLvUp.gameObject.CustomActive(false);
				comele.redpoint.gameObject.CustomActive(false);
				comele.CanLearn.gameObject.CustomActive(false);
			}
			if (!bIsNewOpen)
			{
				comele.NewIcon.gameObject.CustomActive(false);
			}
		}

		// Token: 0x06010C67 RID: 68711 RVA: 0x004C5ED8 File Offset: 0x004C42D8
		private void UpdateLvUpDownBtnState(ComSkillTreeEle comele, ushort SkillID, byte SkillLv, bool ShowNotify = true)
		{
			if (this.CheckLvUp(SkillID, SkillLv, false))
			{
				this.mLevelUp.gameObject.GetComponent<UIGray>().enabled = false;
				this.mLevelUp.enabled = true;
			}
			else
			{
				this.mLevelUp.gameObject.GetComponent<UIGray>().enabled = true;
				this.mLevelUp.enabled = false;
			}
			if (this.CheckLvDown(SkillID, SkillLv, false))
			{
				this.mLevelDown.gameObject.GetComponent<UIGray>().enabled = false;
				this.mLevelDown.enabled = true;
			}
			else
			{
				this.mLevelDown.gameObject.GetComponent<UIGray>().enabled = true;
				this.mLevelDown.enabled = false;
			}
		}

		// Token: 0x06010C68 RID: 68712 RVA: 0x004C5F93 File Offset: 0x004C4393
		private void UpdateLimitLv(SkillTable skillData)
		{
			this.mLevelLimitDes.text = string.Format(TR.Value("skill_max_des"), skillData.TopLevelLimit, skillData.TopLevel);
		}

		// Token: 0x06010C69 RID: 68713 RVA: 0x004C5FC5 File Offset: 0x004C43C5
		private void UpdateDescription(SkillTable skillData)
		{
			this.mRightSkillDes.text = DataManager<SkillDataManager>.GetInstance().GetSkillDescription(skillData);
			this.mRightSkillType.text = DataManager<SkillDataManager>.GetInstance().GetSkillType(skillData);
		}

		// Token: 0x06010C6A RID: 68714 RVA: 0x004C5FF4 File Offset: 0x004C43F4
		private void UpdateSkillCDText(ushort skillID, SkillTable skillData, byte CurSkillLevel)
		{
			SkillLevelAddInfo skillLevelAddInfo = new SkillLevelAddInfo();
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				skillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetAddedSkillInfo((int)skillID, this.AddSkillInfo);
			}
			else
			{
				skillLevelAddInfo = DataManager<SkillDataManager>.GetInstance().GetAddedSkillInfo((int)skillID, this.pvpAddSkillInfo);
			}
			float num;
			float num2;
			if (skillLevelAddInfo == null)
			{
				if (CurSkillLevel > 0)
				{
					num = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTime, (int)CurSkillLevel, true) / 1000f;
					num2 = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTimePVP, (int)CurSkillLevel, true) / 1000f;
				}
				else
				{
					num = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTime, 1, true) / 1000f;
					num2 = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTimePVP, 1, true) / 1000f;
				}
			}
			else if ((int)CurSkillLevel + skillLevelAddInfo.totalAddLevel > 0)
			{
				num = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTime, (int)CurSkillLevel + skillLevelAddInfo.totalAddLevel, true) / 1000f;
				num2 = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTimePVP, (int)CurSkillLevel + skillLevelAddInfo.totalAddLevel, true) / 1000f;
			}
			else
			{
				num = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTime, 1, true) / 1000f;
				num2 = (float)TableManager.GetValueFromUnionCell(skillData.RefreshTimePVP, 1, true) / 1000f;
			}
			if (this.isUniteDeploy)
			{
				this.mRightSkillCD.text = string.Format("{0}S", num);
				this.mPvpSkillCDNum.text = string.Format(TR.Value("skill_pvpCD_des"), num2);
				if (num == num2)
				{
					this.mPvpSkillCD.CustomActive(false);
				}
				else
				{
					this.mPvpSkillCD.CustomActive(true);
				}
			}
			else
			{
				this.mPvpSkillCDNum.text = string.Empty;
				if (DataManager<SkillDataManager>.GetInstance().isPve())
				{
					this.mRightSkillCD.text = string.Format("{0}S", num);
				}
				else
				{
					this.mRightSkillCD.text = string.Format("{0}S", num2);
				}
			}
		}

		// Token: 0x06010C6B RID: 68715 RVA: 0x004C61E8 File Offset: 0x004C45E8
		private void UpdateSkillConsumeMP(SkillTable skillData, byte CurSkillLevel)
		{
			byte level = 1;
			if (CurSkillLevel >= 1)
			{
				level = CurSkillLevel;
			}
			float num = (float)TableManager.GetValueFromUnionCell(skillData.MPCost, (int)level, false);
			this.mRightSkillConsumeMP.text = string.Format("{0}", num);
			float num2 = (float)TableManager.GetValueFromUnionCell(skillData.CrystalCost, (int)level, false);
			if (num2 > 0f)
			{
				this.mRightSkillConsumeThing.CustomActive(true);
				this.mRightSkillConsumeThing.text = string.Format("{0}个", num2);
			}
			else
			{
				this.mRightSkillConsumeThing.CustomActive(false);
			}
		}

		// Token: 0x06010C6C RID: 68716 RVA: 0x004C627C File Offset: 0x004C467C
		private void UpdateLvProperty(SkillTable skilldata, byte NeedShowSkillLv, FightTypeLabel TypeLabel = FightTypeLabel.PVE)
		{
			byte b = this.CalAlreadyLearnLv((ushort)skilldata.ID);
			if (NeedShowSkillLv < 0)
			{
				NeedShowSkillLv = 0;
			}
			int addLevel = this.GetAddLevel(skilldata.ID);
			string arg = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(skilldata.ID, (byte)((int)b + addLevel), (byte)((int)NeedShowSkillLv + addLevel), TypeLabel);
			this.mLeftSkillAttribute.text = string.Format(TR.Value("CurLvSkillDes"), arg);
			arg = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(skilldata.ID, (byte)((int)b + addLevel), (byte)((int)NeedShowSkillLv + addLevel + 1), TypeLabel);
			this.mRightSkillAttribute.text = string.Format(TR.Value("NextLvSkillDes"), arg);
		}

		// Token: 0x06010C6D RID: 68717 RVA: 0x004C631C File Offset: 0x004C471C
		private void UpdatePlanIsFull()
		{
			SkillConfigType skillType;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				skillType = SkillConfigType.SKILL_CONFIG_PVE;
			}
			else
			{
				skillType = SkillConfigType.SKILL_CONFIG_PVP;
			}
			if (!DataManager<SkillDataManager>.GetInstance().IsSkillBarFull(skillType))
			{
				this.mPlanTips.CustomActive(true);
			}
			else
			{
				this.mPlanTips.CustomActive(false);
			}
		}

		// Token: 0x06010C6E RID: 68718 RVA: 0x004C6370 File Offset: 0x004C4770
		private bool CheckLvUp(ushort SkillID, byte SkillLv, bool ShowNotify = true)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit)
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1008, string.Empty);
				}
				return false;
			}
			if (!DataManager<SkillDataManager>.GetInstance().CanLvUpByCurRoleLv(tableItem, SkillLv))
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1006, string.Empty);
				}
				return false;
			}
			if (SkillLv >= (byte)tableItem.TopLevelLimit)
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1016, string.Empty);
				}
				return false;
			}
			if (SkillLv == 0 && tableItem.PreSkills.Count > 0 && tableItem.PreSkills[0] > 0 && !this.CheckPreSkills(tableItem, ShowNotify))
			{
				return false;
			}
			uint num;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					num = this.totalsp;
				}
				else
				{
					num = this.totalsp2;
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				num = this.pvpTotalsp;
			}
			else
			{
				num = this.pvpTotalsp2;
			}
			if ((ulong)num < (ulong)((long)tableItem.LearnSPCost))
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1005, string.Empty);
				}
				return false;
			}
			return tableItem.SkillCategory != 4 || DataManager<PlayerBaseData>.GetInstance().AwakeState > 0;
		}

		// Token: 0x06010C6F RID: 68719 RVA: 0x004C64E8 File Offset: 0x004C48E8
		private bool CheckLvDown(ushort SkillID, byte SkillLv, bool ShowNotify = true)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			int num = 0;
			if (DataManager<SkillDataManager>.GetInstance().CheckInitSkills((int)SkillID) || tableItem.IsPreJob == 1)
			{
				num = 1;
			}
			if ((int)SkillLv <= num)
			{
				if (ShowNotify)
				{
					SystemNotifyManager.SystemNotify(1017, string.Empty);
				}
				return false;
			}
			List<Skillbar> list = new List<Skillbar>();
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					list = SkillPlanFrame.skillBarDirty;
				}
				else
				{
					list = SkillPlanFrame.skillBarDirty2;
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				list = SkillPlanFrame.pvpSkillBarDirty;
			}
			else
			{
				list = SkillPlanFrame.pvpSkillBarDirty2;
			}
			for (int i = 0; i < list.Count; i++)
			{
				Skillbar skillbar = list[i];
				for (int j = 0; j < skillbar.grids.Count; j++)
				{
					if (skillbar.grids[j].id == SkillID && SkillLv <= 1)
					{
						if (ShowNotify)
						{
							SystemNotifyManager.SystemNotify(1018, string.Empty);
						}
						return false;
					}
				}
			}
			return tableItem.PostSkills.Count <= 0 || tableItem.PostSkills[0] <= 0 || this.CheckPostSkills(SkillLv, tableItem, ShowNotify);
		}

		// Token: 0x06010C70 RID: 68720 RVA: 0x004C6660 File Offset: 0x004C4A60
		private byte CalAlreadyLearnLv(ushort SkillID)
		{
			byte result = 0;
			Skill[] array = DataManager<SkillDataManager>.GetInstance().GetCurSkillList(!DataManager<SkillDataManager>.GetInstance().isPve(), SkillSystemSourceType.None).ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id == SkillID)
				{
					result = array[i].level;
					break;
				}
			}
			return result;
		}

		// Token: 0x06010C71 RID: 68721 RVA: 0x004C66C0 File Offset: 0x004C4AC0
		public static byte CalFinalShowLv(ushort SkillID)
		{
			byte result = 0;
			byte b = 0;
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)SkillID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", SkillID));
				return result;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.LevelLimit && tableItem.IsPreJob == 0)
			{
				return result;
			}
			Skill[] array = DataManager<SkillDataManager>.GetInstance().GetCurSkillList(!DataManager<SkillDataManager>.GetInstance().isPve(), SkillSystemSourceType.None).ToArray();
			bool flag;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					flag = SkillTreeFrame.ChangedSkills.TryGetValue(SkillID, out b);
				}
				else
				{
					flag = SkillTreeFrame.ChangedSkills2.TryGetValue(SkillID, out b);
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				flag = SkillTreeFrame.pvpChangedSkills.TryGetValue(SkillID, out b);
			}
			else
			{
				flag = SkillTreeFrame.pvpChangedSkills2.TryGetValue(SkillID, out b);
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].id == SkillID)
				{
					if (flag)
					{
						byte b2 = 0;
						bool flag2 = DataManager<SkillDataManager>.GetInstance().CheckInitSkills((int)SkillTreeFrame.CurSelSkillTreeID);
						if (flag2)
						{
							b2 = 1;
						}
						if ((int)((sbyte)array[i].level) + (int)((sbyte)b) > (int)b2)
						{
							result = (byte)((int)((sbyte)array[i].level) + (int)((sbyte)b));
						}
						else
						{
							result = b2;
						}
					}
					else
					{
						result = array[i].level;
					}
					return result;
				}
			}
			if (b > 0)
			{
				result = b;
			}
			return result;
		}

		// Token: 0x06010C72 RID: 68722 RVA: 0x004C6854 File Offset: 0x004C4C54
		private bool CheckPreSkills(SkillTable skillData, bool ShowNotify)
		{
			if (skillData.PreSkills.Count != skillData.PreSkillsLevel.Count)
			{
				Logger.LogError(string.Format("技能表 {0} 的前置技能与等级数组长度不等，请检查表格", skillData.ID));
				return false;
			}
			for (int i = 0; i < skillData.PreSkills.Count; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillData.PreSkills[i], string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillData.PreSkills[i]));
					return false;
				}
				if (SkillTreeFrame.CalFinalShowLv((ushort)skillData.PreSkills[i]) < (byte)skillData.PreSkillsLevel[i])
				{
					object[] args = new object[]
					{
						tableItem.Name,
						skillData.PreSkillsLevel[i]
					};
					if (ShowNotify)
					{
						SystemNotifyManager.SystemNotify(1019, args);
					}
					return false;
				}
			}
			return true;
		}

		// Token: 0x06010C73 RID: 68723 RVA: 0x004C695C File Offset: 0x004C4D5C
		private bool CheckPostSkills(byte CurSelSkillLv, SkillTable skillData, bool ShowNotify)
		{
			if (skillData.PostSkills.Count != skillData.NeedLevel.Count)
			{
				Logger.LogError(string.Format("技能表 {0} 的后置技能与所需等级数组长度不等，请检查表格", skillData.ID));
				return false;
			}
			for (int i = 0; i < skillData.NeedLevel.Count; i++)
			{
				if ((int)CurSelSkillLv <= skillData.NeedLevel[i])
				{
					SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillData.PostSkills[i], string.Empty, string.Empty);
					if (tableItem == null)
					{
						Logger.LogError(string.Format("技能表没有ID为 {0} 的条目", skillData.PostSkills[i]));
						return false;
					}
					int num = 0;
					bool flag = DataManager<SkillDataManager>.GetInstance().CheckInitSkills(tableItem.ID);
					if (flag)
					{
						num = 1;
					}
					if ((int)SkillTreeFrame.CalFinalShowLv((ushort)skillData.PostSkills[i]) > num)
					{
						object[] args = new object[]
						{
							tableItem.Name
						};
						if (ShowNotify)
						{
							SystemNotifyManager.SystemNotify(1020, args);
						}
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06010C74 RID: 68724 RVA: 0x004C6A78 File Offset: 0x004C4E78
		private static bool CheckAllocate(int SkillID)
		{
			List<SkillBarGrid> curSelSkillBar = SkillPlanFrame.GetCurSelSkillBar();
			if (curSelSkillBar == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation("Current Choose Skill Solution is null", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			for (int i = 0; i < curSelSkillBar.Count; i++)
			{
				if (SkillID == (int)curSelSkillBar[i].id)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010C75 RID: 68725 RVA: 0x004C6ACC File Offset: 0x004C4ECC
		public static ChangeSkill[] CalSkillChange()
		{
			Dictionary<ushort, byte> dictionary = new Dictionary<ushort, byte>();
			if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
			{
				dictionary = SkillTreeFrame.ChangedSkills;
			}
			else
			{
				dictionary = SkillTreeFrame.ChangedSkills2;
			}
			ChangeSkill[] array = new ChangeSkill[dictionary.Count];
			int num = 0;
			foreach (ushort num2 in dictionary.Keys)
			{
				array[num] = new ChangeSkill
				{
					id = num2,
					dif = dictionary[num2]
				};
				num++;
			}
			return array;
		}

		// Token: 0x06010C76 RID: 68726 RVA: 0x004C6B80 File Offset: 0x004C4F80
		public static ChangeSkill[] pvpCalSkillChange()
		{
			Dictionary<ushort, byte> dictionary = new Dictionary<ushort, byte>();
			if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				dictionary = SkillTreeFrame.pvpChangedSkills;
			}
			else
			{
				dictionary = SkillTreeFrame.pvpChangedSkills2;
			}
			ChangeSkill[] array = new ChangeSkill[dictionary.Count];
			int num = 0;
			foreach (ushort num2 in dictionary.Keys)
			{
				array[num] = new ChangeSkill
				{
					id = num2,
					dif = dictionary[num2]
				};
				num++;
			}
			return array;
		}

		// Token: 0x06010C77 RID: 68727 RVA: 0x004C6C34 File Offset: 0x004C5034
		private void PlayNewSkillEffect(ref Image SkillIcon)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.NewSkillEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x06010C78 RID: 68728 RVA: 0x004C6C74 File Offset: 0x004C5074
		private void PlaySkillLvUpEffect(ref ComSkillTreeEle comele)
		{
			string path = string.Empty;
			path = this.LeftRootPath + string.Format(this.EffectLvUpRootPath, comele.iPanelIndex, SkillTreeFrame.CurSelSkillTreeBtnIdx + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.SkillLvUpEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, comele.SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x06010C79 RID: 68729 RVA: 0x004C6D10 File Offset: 0x004C5110
		private void PlaySkillLvDownEffect(ref ComSkillTreeEle comele)
		{
			string path = string.Empty;
			path = this.LeftRootPath + string.Format(this.EffectLvDownRootPath, comele.iPanelIndex, SkillTreeFrame.CurSelSkillTreeBtnIdx + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.SkillLvDownEffectPath, true, 0U);
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, comele.SkillIcon.gameObject, false);
				this.InitMaskEx();
			}
		}

		// Token: 0x06010C7A RID: 68730 RVA: 0x004C6DAC File Offset: 0x004C51AC
		private void ClearNewSkillEffect()
		{
			string path = string.Empty;
			for (int i = 0; i < SkillTreeFrame.skillPos.Count; i++)
			{
				path = this.LeftRootPath + string.Format(this.EffectNewSkillRootPath, i + 1);
				GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
			}
		}

		// Token: 0x06010C7B RID: 68731 RVA: 0x004C6E1C File Offset: 0x004C521C
		private void ClearSkillLvUpEffect(ComSkillTreeEle comele, int iIndex)
		{
			string path = string.Empty;
			path = this.LeftRootPath + string.Format(this.EffectLvUpRootPath, comele.iPanelIndex, iIndex + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x06010C7C RID: 68732 RVA: 0x004C6E7C File Offset: 0x004C527C
		private void ClearSkillLvDownEffect(ComSkillTreeEle comele, int iIndex)
		{
			string path = string.Empty;
			path = this.LeftRootPath + string.Format(this.EffectLvDownRootPath, comele.iPanelIndex, iIndex + 1);
			GameObject gameObject = Utility.FindGameObject(this.frame, path, false);
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x06010C7D RID: 68733 RVA: 0x004C6EDC File Offset: 0x004C52DC
		private void CalScrollViewPos(ComSkillTreeEle SkillToggle)
		{
			if (SkillToggle.mrt == null || SkillToggle.mrt.gameObject == null)
			{
				return;
			}
			GameObject gameObject = SkillToggle.mrt.gameObject;
			GameObject gameObject2 = gameObject;
			float num = Mathf.Abs(gameObject2.GetComponent<RectTransform>().offsetMin.y);
			float y = this.uniqueContent.GetComponent<RectTransform>().offsetMax.y;
			float y2 = this.uniqueContent.GetComponent<RectTransform>().offsetMin.y;
			float num2 = Math.Abs(y2 - y);
			if (num2 != 0f)
			{
				float num3 = 1f - (num + 236f - this.fViewPortPos) / (num2 - this.fViewPortPos);
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.JobType > 0 && Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.ChangeJobSkillGuide))
				{
					num3 = 1f - (num + 40f - this.fViewPortPos) / (num2 - this.fViewPortPos);
				}
				if (num3 < 0f)
				{
					num3 = 0f;
				}
				if (num3 > 1f)
				{
					num3 = 1f;
				}
				this.SkillTreeScrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = num3;
			}
		}

		// Token: 0x06010C7E RID: 68734 RVA: 0x004C7044 File Offset: 0x004C5444
		private void InitMaskEx()
		{
			MaskEx componentInChildren = this.UniqueSkillobj.gameObject.GetComponentInChildren<MaskEx>();
			if (componentInChildren != null)
			{
				componentInChildren.Init();
			}
		}

		// Token: 0x06010C7F RID: 68735 RVA: 0x004C7074 File Offset: 0x004C5474
		private void UpdateMainTab()
		{
			for (int i = 0; i < this.MainTabToggle.Length; i++)
			{
				this.MainTabToggle[i].isOn = false;
				if (i == (int)this.CurSelMainTab)
				{
					this.MainTabToggle[i].isOn = true;
				}
			}
		}

		// Token: 0x06010C80 RID: 68736 RVA: 0x004C70C4 File Offset: 0x004C54C4
		private void SetTryOpenPVPSkillTree()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(7, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				this.MainTabToggle[2].CustomActive(false);
			}
			else
			{
				this.MainTabToggle[2].CustomActive(true);
			}
		}

		// Token: 0x06010C81 RID: 68737 RVA: 0x004C7124 File Offset: 0x004C5524
		private void UpdateIsUniteDeployInit()
		{
			this.MainTabToggle[(int)((byte)this.CurSelMainTab)].isOn = true;
			this.MainTabToggle[2].CustomActive(true);
		}

		// Token: 0x06010C82 RID: 68738 RVA: 0x004C7148 File Offset: 0x004C5548
		private string getSkillTypeText(byte effectIndex)
		{
			string result = string.Empty;
			switch (effectIndex)
			{
			case 1:
				result = TR.Value("skill_start");
				break;
			case 2:
				result = TR.Value("skill_continuous");
				break;
			case 3:
				result = TR.Value("skill_hurt");
				break;
			case 4:
				result = TR.Value("displacement_skilll");
				break;
			case 5:
				result = TR.Value("control_skill");
				break;
			case 6:
				result = TR.Value("grab_skill");
				break;
			case 7:
				result = TR.Value("defense_skill");
				break;
			case 8:
				result = TR.Value("assistant_skill");
				break;
			case 9:
				result = TR.Value("physical_skill");
				break;
			case 10:
				result = TR.Value("magic_skill");
				break;
			case 11:
				result = TR.Value("near_skill");
				break;
			case 12:
				result = TR.Value("far_skill");
				break;
			}
			return result;
		}

		// Token: 0x06010C83 RID: 68739 RVA: 0x004C725C File Offset: 0x004C565C
		[MessageHandle(501222U, false, 0)]
		private void OnSceneSetPvpSkillConfigRes(MsgDATA data)
		{
			SceneSetPvpSkillConfigRes sceneSetPvpSkillConfigRes = new SceneSetPvpSkillConfigRes();
			sceneSetPvpSkillConfigRes.decode(data.bytes);
			if (sceneSetPvpSkillConfigRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneSetPvpSkillConfigRes.result, string.Empty);
			}
		}

		// Token: 0x06010C84 RID: 68740 RVA: 0x004C729C File Offset: 0x004C569C
		private int GetAddLevel(int skillTreeID)
		{
			int addedSkillLevel;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				addedSkillLevel = DataManager<SkillDataManager>.GetInstance().GetAddedSkillLevel(skillTreeID, this.AddSkillInfo);
			}
			else
			{
				addedSkillLevel = DataManager<SkillDataManager>.GetInstance().GetAddedSkillLevel(skillTreeID, this.pvpAddSkillInfo);
			}
			return addedSkillLevel;
		}

		// Token: 0x06010C85 RID: 68741 RVA: 0x004C72E4 File Offset: 0x004C56E4
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, int skillID, bool isEnableIcon)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(skillID, string.Empty, string.Empty);
			if (comele == null || tableItem == null)
			{
				return;
			}
			this.UpdatePvpForbid(ref comele, tableItem, isEnableIcon);
		}

		// Token: 0x06010C86 RID: 68742 RVA: 0x004C7324 File Offset: 0x004C5724
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, SkillTable skillData, bool isEnableIcon)
		{
			if (comele == null || skillData == null)
			{
				return;
			}
			if (DataManager<SkillDataManager>.GetInstance().CurSkillConfigType == SkillConfigType.SKILL_CONFIG_PVP)
			{
				bool flag = skillData.CanUseInPVP == 3;
				if (flag)
				{
					comele.PvPForbidImg.CustomActive(true);
					comele.SkillInfoGo.CustomActive(false);
					comele.SkillIcon.GetComponent<UIGray>().enabled = isEnableIcon;
					comele.SkillIcon.GetComponent<UIGray>().SetEnable(isEnableIcon);
				}
				else
				{
					this.UpdatePvpForbid(ref comele, isEnableIcon);
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurSkillConfigType == SkillConfigType.SKILL_CONFIG_PVE)
			{
				this.UpdatePvpForbid(ref comele, isEnableIcon);
			}
		}

		// Token: 0x06010C87 RID: 68743 RVA: 0x004C73D9 File Offset: 0x004C57D9
		private void UpdatePvpForbid(ref ComSkillTreeEle comele, bool isEnableIcon)
		{
			comele.SkillInfoGo.CustomActive(true);
			comele.PvPForbidImg.CustomActive(false);
			comele.SkillIcon.GetComponent<UIGray>().enabled = isEnableIcon;
			comele.SkillIcon.GetComponent<UIGray>().SetEnable(isEnableIcon);
		}

		// Token: 0x06010C88 RID: 68744 RVA: 0x004C7419 File Offset: 0x004C5819
		private void ConserveSkillPlan(bool needConserve)
		{
		}

		// Token: 0x06010C89 RID: 68745 RVA: 0x004C741C File Offset: 0x004C581C
		protected override void _bindExUI()
		{
			this.mPlanTips = this.mBind.GetGameObject("PlanTips");
			this.mPlanTipsText = this.mBind.GetCom<Text>("PlanTipsText");
			this.mChangeJobTips = this.mBind.GetCom<Text>("ChangeJobTips");
			this.mChangeJobPreview = this.mBind.GetGameObject("ChangeJobPreview");
			this.mPassiveSkillRootObj = this.mBind.GetGameObject("PassiveSkillRootObj");
			this.mActiveSkillRoot = this.mBind.GetGameObject("ActiveSkillRoot");
			this.mRightRoot = this.mBind.GetGameObject("RightRoot");
			this.mRightSkillIcon = this.mBind.GetCom<Image>("rightSkillIcon");
			this.mRightSkillName = this.mBind.GetCom<Text>("rightSkillName");
			this.mRightSkillLevel = this.mBind.GetCom<Text>("rightSkillLevel");
			this.mRightSkillType = this.mBind.GetCom<Text>("rightSkillType");
			this.mRightSkillCD = this.mBind.GetCom<Text>("rightSkillCD");
			this.mRightSkillConsumeMP = this.mBind.GetCom<Text>("rightSkillConsumeMP");
			this.mRightSkillConsumeThing = this.mBind.GetCom<Text>("rightSkillConsumeThing");
			this.mRightSkillDes = this.mBind.GetCom<Text>("rightSkillDes");
			this.mLeftSkillAttribute = this.mBind.GetCom<Text>("leftSkillAttribute");
			this.mRightSkillAttribute = this.mBind.GetCom<Text>("rightSkillAttribute");
			this.mLevelLimitDes = this.mBind.GetCom<Text>("levelLimitDes");
			this.mNeedSP = this.mBind.GetCom<Text>("needSP");
			this.mNeedLevel = this.mBind.GetCom<Text>("needLevel");
			this.mLevelDown = this.mBind.GetCom<Button>("levelDown");
			if (null != this.mLevelDown)
			{
				this.mLevelDown.onClick.AddListener(new UnityAction(this._onLevelDownButtonClick));
			}
			this.mLevelUp = this.mBind.GetCom<Button>("levelUp");
			if (null != this.mLevelUp)
			{
				this.mLevelUp.onClick.AddListener(new UnityAction(this._onLevelUpButtonClick));
			}
			this.mLevelMaxImage = this.mBind.GetGameObject("levelMaxImage");
			this.mOpenSkillPlan = this.mBind.GetCom<Button>("openSkillPlan");
			if (null != this.mOpenSkillPlan)
			{
				this.mOpenSkillPlan.onClick.AddListener(new UnityAction(this._onOpenSkillPlanButtonClick));
			}
			this.mRightAddLevel = this.mBind.GetCom<Text>("rightAddLevel");
			this.mSkillPlanText = this.mBind.GetCom<Text>("skillPlanText");
			this.mSkillDesScrollRect = this.mBind.GetCom<ScrollRect>("skillDesScrollRect");
			this.mLeftSkillDesScrollRect = this.mBind.GetCom<ScrollRect>("leftSkillDesScrollRect");
			this.mRightSkillDesScrollRect = this.mBind.GetCom<ScrollRect>("rightSkillDesScrollRect");
			this.mAddSp = this.mBind.GetCom<Button>("addSp");
			if (null != this.mAddSp)
			{
				this.mAddSp.onClick.AddListener(new UnityAction(this._onAddSpButtonClick));
			}
			this.mMaxRoot = this.mBind.GetGameObject("maxRoot");
			this.mPveToggleDes = this.mBind.GetCom<Text>("PveToggleDes");
			this.mPvpSkillCD = this.mBind.GetGameObject("pvpSkillCD");
			this.mPvpSkillCDNum = this.mBind.GetCom<Text>("pvpSkillCDNum");
			this.mSkillInitConfigRoot = this.mBind.GetGameObject("skillInitConfigRoot");
			this.mSkillInitButton = this.mBind.GetCom<Button>("skillInitButton");
			if (this.mSkillInitButton != null)
			{
				this.mSkillInitButton.onClick.RemoveAllListeners();
				this.mSkillInitButton.onClick.AddListener(new UnityAction(this.OnSkillInitButtonClicked));
			}
			this.mSkillConfigButton = this.mBind.GetCom<Button>("skillConfigButton");
			if (this.mSkillConfigButton != null)
			{
				this.mSkillConfigButton.onClick.RemoveAllListeners();
				this.mSkillConfigButton.onClick.AddListener(new UnityAction(this.OnSkillConfigButtonClicked));
			}
			this.mPassiveSkillBtn = this.mBind.GetCom<Button>("PassiveBtn");
			if (this.mPassiveSkillBtn != null)
			{
				this.mPassiveSkillBtn.onClick.AddListener(new UnityAction(this.OnPassiveSkillBtnClick));
			}
			this.mPVEConfigGo = this.mBind.GetGameObject("PVESkillConfig");
			this.mPVEToggle1 = this.mBind.GetCom<Toggle>("PVESkillToggle1");
			this.mPVEToggle1.SafeSetOnValueChangedListener(new UnityAction<bool>(this._OnPVEToggle1Changed));
			this.mPVEToggle2 = this.mBind.GetCom<Toggle>("PVESkillToggle2");
			this.mPVEToggle2.SafeSetOnValueChangedListener(new UnityAction<bool>(this._OnPVEToggle2Changed));
			this.mPVELockBtn = this.mBind.GetCom<Button>("PVESkillLockBtn");
			this.mPVELockBtn.SafeAddOnClickListener(new UnityAction(this._OnPVELockBtnClick));
			this.mPVETipBtn1 = this.mBind.GetCom<Button>("PVETipBtn1");
			this.mPVETipBtn1.SafeAddOnClickListener(new UnityAction(this._OnPVETipBtn1Click));
			this.mPVETipBtn2 = this.mBind.GetCom<Button>("PVETipBtn2");
			this.mPVETipBtn2.SafeAddOnClickListener(new UnityAction(this._OnPVETipBtn2Click));
			this.mPVPConfigGo = this.mBind.GetGameObject("PVPSkillConfig");
			this.mPVPToggle1 = this.mBind.GetCom<Toggle>("PVPSkilToggle1");
			this.mPVPToggle1.SafeSetOnValueChangedListener(new UnityAction<bool>(this._OnPVPToggle1Changed));
			this.mPVPToggle2 = this.mBind.GetCom<Toggle>("PVPSkilToggle2");
			this.mPVPToggle2.SafeSetOnValueChangedListener(new UnityAction<bool>(this._OnPVPToggle2Changed));
			this.mPVPLockBtn = this.mBind.GetCom<Button>("PVPSkillLockBtn");
			this.mPVPLockBtn.SafeAddOnClickListener(new UnityAction(this._OnPVPLockBtnClick));
			this.mPVPTipBtn1 = this.mBind.GetCom<Button>("PVPTipBtn1");
			this.mPVPTipBtn1.SafeAddOnClickListener(new UnityAction(this._OnPVPTipBtn1Click));
			this.mPVPTipBtn2 = this.mBind.GetCom<Button>("PVPTipBtn2");
			this.mPVPTipBtn2.SafeAddOnClickListener(new UnityAction(this._OnPVPTipBtn2Click));
			this.mPVESkillPage1TxtColor = this.mBind.GetCom<ComSetTextColor>("PVESkillPage1TxtColor");
			this.mPVESkillPage2TxtColor = this.mBind.GetCom<ComSetTextColor>("PVESkillPage2TxtColor");
			this.mPVPSkillPage1TxtColor = this.mBind.GetCom<ComSetTextColor>("PVPSkillPage1TxtColor");
			this.mPVPSkillPage2TxtColor = this.mBind.GetCom<ComSetTextColor>("PVPSkillPage2TxtColor");
		}

		// Token: 0x06010C8A RID: 68746 RVA: 0x004C7B10 File Offset: 0x004C5F10
		protected override void _unbindExUI()
		{
			this.mPlanTips = null;
			this.mPlanTipsText = null;
			this.mChangeJobTips = null;
			this.mChangeJobPreview = null;
			this.mPassiveSkillRootObj = null;
			this.mActiveSkillRoot = null;
			this.mRightRoot = null;
			this.mRightSkillIcon = null;
			this.mRightSkillName = null;
			this.mRightSkillLevel = null;
			this.mRightSkillType = null;
			this.mRightSkillCD = null;
			this.mRightSkillConsumeMP = null;
			this.mRightSkillConsumeThing = null;
			this.mRightSkillDes = null;
			this.mLeftSkillAttribute = null;
			this.mRightSkillAttribute = null;
			this.mLevelLimitDes = null;
			this.mNeedSP = null;
			this.mNeedLevel = null;
			if (null != this.mLevelDown)
			{
				this.mLevelDown.onClick.RemoveListener(new UnityAction(this._onLevelDownButtonClick));
			}
			this.mLevelDown = null;
			if (null != this.mLevelUp)
			{
				this.mLevelUp.onClick.RemoveListener(new UnityAction(this._onLevelUpButtonClick));
			}
			this.mLevelUp = null;
			this.mLevelMaxImage = null;
			if (null != this.mOpenSkillPlan)
			{
				this.mOpenSkillPlan.onClick.RemoveListener(new UnityAction(this._onOpenSkillPlanButtonClick));
			}
			this.mOpenSkillPlan = null;
			this.mRightAddLevel = null;
			this.mSkillPlanText = null;
			this.mSkillDesScrollRect = null;
			this.mLeftSkillDesScrollRect = null;
			this.mRightSkillDesScrollRect = null;
			this.mAddSp = null;
			this.mMaxRoot = null;
			this.mPveToggleDes = null;
			this.mPvpSkillCD = null;
			this.mPvpSkillCDNum = null;
			if (this.mSkillInitButton != null)
			{
				this.mSkillInitButton.onClick.RemoveAllListeners();
				this.mSkillInitButton = null;
			}
			if (this.mSkillConfigButton != null)
			{
				this.mSkillConfigButton.onClick.RemoveAllListeners();
				this.mSkillConfigButton = null;
			}
			this.mSkillInitConfigRoot = null;
			if (this.mPassiveSkillBtn != null)
			{
				this.mPassiveSkillBtn.onClick.RemoveListener(new UnityAction(this.OnPassiveSkillBtnClick));
				this.mPassiveSkillBtn = null;
			}
			this.mPVEConfigGo = null;
			this.mPVEToggle1 = null;
			this.mPVEToggle2 = null;
			this.mPVELockBtn = null;
			this.mPVPConfigGo = null;
			this.mPVPToggle1 = null;
			this.mPVPToggle2 = null;
			this.mPVPLockBtn = null;
			this.mPVETipBtn1.SafeRemoveOnClickListener(new UnityAction(this._OnPVETipBtn1Click));
			this.mPVETipBtn1 = null;
			this.mPVETipBtn2.SafeRemoveOnClickListener(new UnityAction(this._OnPVETipBtn2Click));
			this.mPVETipBtn2 = null;
			this.mPVPTipBtn1.SafeRemoveOnClickListener(new UnityAction(this._OnPVPTipBtn1Click));
			this.mPVPTipBtn1 = null;
			this.mPVPTipBtn2.SafeRemoveOnClickListener(new UnityAction(this._OnPVPTipBtn2Click));
			this.mPVPTipBtn2 = null;
			this.mPVESkillPage1TxtColor = null;
			this.mPVESkillPage2TxtColor = null;
			this.mPVPSkillPage1TxtColor = null;
			this.mPVPSkillPage2TxtColor = null;
		}

		// Token: 0x06010C8B RID: 68747 RVA: 0x004C7DEC File Offset: 0x004C61EC
		private void _onLevelDownButtonClick()
		{
			if (!this.CheckLvDown(SkillTreeFrame.CurSelSkillTreeID, this.CurSelSkillLv, true))
			{
				return;
			}
			this.CurSelSkillLv -= 1;
			this.UpdateChangedSkill(false);
			this.OnbtSave();
			Singleton<GameStatisticManager>.GetInstance().DoStatSkillPanel(StatSkillPanelType.SKILL_LEVEL_DOWN, (int)SkillTreeFrame.CurSelSkillTreeID, (int)this.CurSelSkillLv, 0);
		}

		// Token: 0x06010C8C RID: 68748 RVA: 0x004C7E44 File Offset: 0x004C6244
		private void _onLevelUpButtonClick()
		{
			if (!this.CheckLvUp(SkillTreeFrame.CurSelSkillTreeID, this.CurSelSkillLv, true))
			{
				return;
			}
			this.CurSelSkillLv += 1;
			this.UpdateChangedSkill(true);
			this.OnbtSave();
			Singleton<GameStatisticManager>.GetInstance().DoStatSkillPanel(StatSkillPanelType.SKILL_LEVEL_UP, (int)SkillTreeFrame.CurSelSkillTreeID, (int)this.CurSelSkillLv, 0);
		}

		// Token: 0x06010C8D RID: 68749 RVA: 0x004C7E9C File Offset: 0x004C629C
		private void _onOpenSkillPlanButtonClick()
		{
			if (this.CurSelFightType == FightTypeLabel.PVE)
			{
				if (!this.IsOpenSkillPlanPVE)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
					}
					this.mPlanTips.gameObject.CustomActive(false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillPlanFrame>(FrameLayer.Middle, null, string.Empty);
					this.mLevelDown.CustomActive(false);
					this.mLevelUp.CustomActive(false);
					this.mMaxRoot.CustomActive(false);
					this.mSkillPlanText.text = "返回";
					this.UpdateSkillInitConfigRoot(true);
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
					this.mLevelDown.CustomActive(true);
					this.mLevelUp.CustomActive(true);
					this.mMaxRoot.CustomActive(true);
					this.mSkillPlanText.text = "技能配置";
					this.UpdateSkillInitConfigRoot(false);
				}
				this.IsOpenSkillPlanPVE = !this.IsOpenSkillPlanPVE;
			}
			else if (this.CurSelFightType == FightTypeLabel.PVP)
			{
				if (!this.IsOpenSkillPlanPVP)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
					}
					this.mPlanTips.gameObject.CustomActive(false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillPlanFrame>(FrameLayer.Middle, null, string.Empty);
					this.mLevelDown.CustomActive(false);
					this.mLevelUp.CustomActive(false);
					this.mMaxRoot.CustomActive(false);
					this.mSkillPlanText.text = "返回";
					this.UpdateSkillInitConfigRoot(true);
				}
				else
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<SkillPlanFrame>(null, false);
					this.mLevelDown.CustomActive(true);
					this.mLevelUp.CustomActive(true);
					this.mMaxRoot.CustomActive(true);
					this.mSkillPlanText.text = "技能配置";
					this.UpdateSkillInitConfigRoot(false);
				}
				this.IsOpenSkillPlanPVP = !this.IsOpenSkillPlanPVP;
			}
		}

		// Token: 0x06010C8E RID: 68750 RVA: 0x004C8085 File Offset: 0x004C6485
		private void _onAddSpButtonClick()
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("skill_add_sp_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x06010C8F RID: 68751 RVA: 0x004C8098 File Offset: 0x004C6498
		private void OnPassiveSkillBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjectiveSkillFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010C90 RID: 68752 RVA: 0x004C80AC File Offset: 0x004C64AC
		private void _OnPVPLockBtnClick()
		{
			if (!PlayerBaseData.IsJobChanged())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("CnaNotBugSkillPage_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("Unlock_SkillConfig2_Content"), this.mCostItemName, this.mUnlockSkillConfig2CostNum),
				IsShowNotify = false,
				LeftButtonText = TR.Value("Unlock_SkillConfig2_Cancel"),
				RightButtonText = TR.Value("Unlock_SkillConfig2_OK"),
				OnRightButtonClickCallBack = delegate()
				{
					this.OnPVPOrPVESureClick(true);
				}
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06010C91 RID: 68753 RVA: 0x004C8142 File Offset: 0x004C6542
		private void _OnPVPTipBtn2Click()
		{
			if (this.mPVPToggle2 != null && this.mPVPToggle2.isOn)
			{
				return;
			}
			this.ShowExchangeSkillPageTip(1, delegate
			{
				if (this.mPVPToggle2 != null)
				{
					this.mPVPToggle2.isOn = true;
				}
			});
		}

		// Token: 0x06010C92 RID: 68754 RVA: 0x004C8179 File Offset: 0x004C6579
		private void _OnPVPTipBtn1Click()
		{
			if (this.mPVPToggle1 != null && this.mPVPToggle1.isOn)
			{
				return;
			}
			this.ShowExchangeSkillPageTip(2, delegate
			{
				if (this.mPVPToggle1 != null)
				{
					this.mPVPToggle1.isOn = true;
				}
			});
		}

		// Token: 0x06010C93 RID: 68755 RVA: 0x004C81B0 File Offset: 0x004C65B0
		private void _OnPVPToggle1Changed(bool isOn)
		{
			if (isOn == this.mPvpSkillPage1State)
			{
				return;
			}
			this.mPvpSkillPage1State = isOn;
			if (isOn && this._isSendChangedChangedSkillPageMsg)
			{
				DataManager<SkillDataManager>.GetInstance().SendChooseSkillPage(SkillConfigType.SKILL_CONFIG_PVP, 0);
				this.scrollRect.normalizedPosition = this.mPvpSrowViewPos1;
				DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage = EPVPSkillPage.Page1;
			}
			if (this.mPVPSkillPage1TxtColor != null)
			{
				if (isOn)
				{
					this.mPVPSkillPage1TxtColor.SetColor(1);
				}
				else
				{
					this.mPVPSkillPage1TxtColor.SetColor(0);
				}
			}
		}

		// Token: 0x06010C94 RID: 68756 RVA: 0x004C8240 File Offset: 0x004C6640
		private void _OnPVPToggle2Changed(bool isOn)
		{
			if (isOn == this.mPvpSkillPage2State)
			{
				return;
			}
			this.mPvpSkillPage2State = isOn;
			if (isOn && this._isSendChangedChangedSkillPageMsg)
			{
				DataManager<SkillDataManager>.GetInstance().SendChooseSkillPage(SkillConfigType.SKILL_CONFIG_PVP, 1);
				this.scrollRect.normalizedPosition = this.mPvpSrowViewPos2;
				DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage = EPVPSkillPage.Page2;
			}
			if (this.mPVPSkillPage2TxtColor != null)
			{
				if (isOn)
				{
					this.mPVPSkillPage2TxtColor.SetColor(1);
				}
				else
				{
					this.mPVPSkillPage2TxtColor.SetColor(0);
				}
			}
		}

		// Token: 0x06010C95 RID: 68757 RVA: 0x004C82D0 File Offset: 0x004C66D0
		private void _OnPVELockBtnClick()
		{
			if (!PlayerBaseData.IsJobChanged())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("CnaNotBugSkillPage_Tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("Unlock_SkillConfig2_Content"), this.mCostItemName, this.mUnlockSkillConfig2CostNum),
				IsShowNotify = false,
				LeftButtonText = TR.Value("Unlock_SkillConfig2_Cancel"),
				RightButtonText = TR.Value("Unlock_SkillConfig2_OK"),
				OnRightButtonClickCallBack = delegate()
				{
					this.OnPVPOrPVESureClick(false);
				}
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06010C96 RID: 68758 RVA: 0x004C8366 File Offset: 0x004C6766
		private void _OnPVETipBtn2Click()
		{
			if (this.mPVEToggle2 != null && this.mPVEToggle2.isOn)
			{
				return;
			}
			this.ShowExchangeSkillPageTip(1, delegate
			{
				if (this.mPVEToggle2 != null)
				{
					this.mPVEToggle2.isOn = true;
				}
			});
		}

		// Token: 0x06010C97 RID: 68759 RVA: 0x004C839D File Offset: 0x004C679D
		private void _OnPVETipBtn1Click()
		{
			if (this.mPVEToggle1 != null && this.mPVEToggle1.isOn)
			{
				return;
			}
			this.ShowExchangeSkillPageTip(2, delegate
			{
				if (this.mPVEToggle1 != null)
				{
					this.mPVEToggle1.isOn = true;
				}
			});
		}

		// Token: 0x06010C98 RID: 68760 RVA: 0x004C83D4 File Offset: 0x004C67D4
		private void _OnPVEToggle1Changed(bool isOn)
		{
			if (isOn == this.mPveSkillPage1State)
			{
				return;
			}
			this.mPveSkillPage1State = isOn;
			if (isOn && this._isSendChangedChangedSkillPageMsg)
			{
				DataManager<SkillDataManager>.GetInstance().SendChooseSkillPage(SkillConfigType.SKILL_CONFIG_PVE, 0);
				this.scrollRect.normalizedPosition = this.mPveSrowViewPos1;
				DataManager<SkillDataManager>.GetInstance().CurPVESKillPage = EPVESkillPage.Page1;
			}
			if (this.mPVESkillPage1TxtColor != null)
			{
				if (isOn)
				{
					this.mPVESkillPage1TxtColor.SetColor(1);
				}
				else
				{
					this.mPVESkillPage1TxtColor.SetColor(0);
				}
			}
		}

		// Token: 0x06010C99 RID: 68761 RVA: 0x004C8464 File Offset: 0x004C6864
		private void _OnPVEToggle2Changed(bool isOn)
		{
			if (isOn == this.mPveSkillPage2State)
			{
				return;
			}
			this.mPveSkillPage2State = isOn;
			if (isOn && this._isSendChangedChangedSkillPageMsg)
			{
				DataManager<SkillDataManager>.GetInstance().SendChooseSkillPage(SkillConfigType.SKILL_CONFIG_PVE, 1);
				this.scrollRect.normalizedPosition = this.mPveSrowViewPos2;
				DataManager<SkillDataManager>.GetInstance().CurPVESKillPage = EPVESkillPage.Page2;
			}
			if (this.mPVESkillPage2TxtColor != null)
			{
				if (isOn)
				{
					this.mPVESkillPage2TxtColor.SetColor(1);
				}
				else
				{
					this.mPVESkillPage2TxtColor.SetColor(0);
				}
			}
		}

		// Token: 0x06010C9A RID: 68762 RVA: 0x004C84F4 File Offset: 0x004C68F4
		private void OnPVPOrPVESureClick(bool isPvp)
		{
			if (this.mOwnNum < this.mUnlockSkillConfig2CostNum)
			{
				ItemComeLink.OnLink(this.mUnlockSkillConfig2CostID, 0, true, null, false, false, false, null, string.Empty);
			}
			else if (!isPvp)
			{
				DataManager<SkillDataManager>.GetInstance().SendBuySkillPageReq(DataManager<SkillDataManager>.GetInstance().CurSkillConfigType, 1);
			}
			else
			{
				DataManager<SkillDataManager>.GetInstance().SendBuySkillPageReq(DataManager<SkillDataManager>.GetInstance().CurSkillConfigType, 1);
			}
		}

		// Token: 0x06010C9B RID: 68763 RVA: 0x004C8564 File Offset: 0x004C6964
		private void ShowExchangeSkillPageTip(int curPageCount, Action okAction)
		{
			CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData = new CommonMsgBoxOkCancelNewParamData();
			if (curPageCount == 1)
			{
				commonMsgBoxOkCancelNewParamData.ContentLabel = string.Format(TR.Value("SkillPageExchange_Tip_Content"), new object[0]);
			}
			else
			{
				commonMsgBoxOkCancelNewParamData.ContentLabel = string.Format(TR.Value("SkillPageExchange_Tip_Content2"), new object[0]);
			}
			commonMsgBoxOkCancelNewParamData.IsShowNotify = false;
			commonMsgBoxOkCancelNewParamData.LeftButtonText = TR.Value("SkillPageExchange_Tip_Cancel");
			commonMsgBoxOkCancelNewParamData.RightButtonText = TR.Value("SkillPageExchange_Tip_OK");
			commonMsgBoxOkCancelNewParamData.OnRightButtonClickCallBack = okAction;
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(commonMsgBoxOkCancelNewParamData);
		}

		// Token: 0x06010C9C RID: 68764 RVA: 0x004C85F0 File Offset: 0x004C69F0
		private void UpdateSkillInitConfigRoot(bool flag)
		{
			if (this.mSkillInitConfigRoot != null)
			{
				this.mSkillInitConfigRoot.gameObject.CustomActive(flag);
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(555, string.Empty, string.Empty);
				int value = tableItem.Value;
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= value)
				{
					this.mSkillConfigButton.CustomActive(true);
					this.mSkillInitButton.CustomActive(true);
				}
				else
				{
					this.mSkillConfigButton.CustomActive(false);
					this.mSkillInitButton.CustomActive(false);
				}
			}
		}

		// Token: 0x06010C9D RID: 68765 RVA: 0x004C8688 File Offset: 0x004C6A88
		private void OnSkillInitButtonClicked()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_initialize_config"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("skill_new_enter_skill_cancel"),
				RightButtonText = TR.Value("skill_new_enter_skill_sure"),
				OnRightButtonClickCallBack = new Action(this.EquipInitSkillConfig)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06010C9E RID: 68766 RVA: 0x004C86EC File Offset: 0x004C6AEC
		private void EquipInitSkillConfig()
		{
			SkillConfigType skillConfigType = this.GetSkillConfigType();
			DataManager<SkillDataManager>.GetInstance().OnSendSceneInitSkillsReq(skillConfigType);
			this._isClickInitSkillBar = true;
		}

		// Token: 0x06010C9F RID: 68767 RVA: 0x004C8714 File Offset: 0x004C6B14
		private void OnSkillConfigButtonClicked()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_recommend_config_make_sure"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("skill_new_enter_skill_cancel"),
				RightButtonText = TR.Value("skill_new_enter_skill_sure"),
				OnRightButtonClickCallBack = new Action(this.EquipRecommendSkillConfig)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06010CA0 RID: 68768 RVA: 0x004C8778 File Offset: 0x004C6B78
		private void EquipRecommendSkillConfig()
		{
			SkillConfigType skillConfigType = this.GetSkillConfigType();
			DataManager<SkillDataManager>.GetInstance().OnSendSceneRecommendSkillsReq(skillConfigType);
		}

		// Token: 0x06010CA1 RID: 68769 RVA: 0x004C8797 File Offset: 0x004C6B97
		private SkillConfigType GetSkillConfigType()
		{
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				return SkillConfigType.SKILL_CONFIG_PVE;
			}
			return SkillConfigType.SKILL_CONFIG_PVP;
		}

		// Token: 0x06010CA2 RID: 68770 RVA: 0x004C87AC File Offset: 0x004C6BAC
		private byte GetSkillPage()
		{
			byte result;
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				result = (byte)DataManager<SkillDataManager>.GetInstance().CurPVESKillPage;
			}
			else
			{
				result = (byte)DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage;
			}
			return result;
		}

		// Token: 0x06010CA3 RID: 68771 RVA: 0x004C87E8 File Offset: 0x004C6BE8
		private void OnCloseSkillFrameByShowTips()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("skill_new_skill_can_upgrade"),
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnCommonToggleClickCallBack),
				LeftButtonText = TR.Value("skill_new_enter_skill_cancel"),
				RightButtonText = TR.Value("skill_new_enter_skill_quit"),
				OnRightButtonClickCallBack = new Action(this.OnCloseSkillFrame)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x06010CA4 RID: 68772 RVA: 0x004C885E File Offset: 0x004C6C5E
		private void OnCommonToggleClickCallBack(bool value)
		{
			DataManager<SkillDataManager>.GetInstance().IsNotShowSkillLevelUpTip = value;
		}

		// Token: 0x06010CA5 RID: 68773 RVA: 0x004C886B File Offset: 0x004C6C6B
		private void OnCloseSkillFrame()
		{
			this._CloseFrame();
		}

		// Token: 0x06010CA6 RID: 68774 RVA: 0x004C8874 File Offset: 0x004C6C74
		private void FreshBtnLvAndNeddSp()
		{
			int num = -1;
			Dictionary<int, int> uniqueButtonBindSkill = DataManager<SkillDataManager>.GetInstance().UniqueButtonBindSkill;
			if (uniqueButtonBindSkill == null)
			{
				return;
			}
			if (!uniqueButtonBindSkill.TryGetValue(SkillTreeFrame.CurSelSkillTreeBtnIdx + 1, out num) || num == -1)
			{
				return;
			}
			ComSkillTreeEle componentInChildren = SkillTreeFrame.skillPos[SkillTreeFrame.CurSelSkillTreeBtnIdx].GetComponentInChildren<ComSkillTreeEle>();
			if (componentInChildren == null)
			{
				return;
			}
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(num, string.Empty, string.Empty);
			this.UpdateNeedSp(tableItem);
			this.UpdateLvUpDownBtnState(null, SkillTreeFrame.CurSelSkillTreeID, this.CurSelSkillLv, false);
		}

		// Token: 0x06010CA7 RID: 68775 RVA: 0x004C8904 File Offset: 0x004C6D04
		private void _InitUnlockSkillConfig2NeedParams()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(629, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(630, string.Empty, string.Empty);
			if (tableItem != null && tableItem2 != null)
			{
				this.mUnlockSkillConfig2CostNum = tableItem.Value;
				this.mUnlockSkillConfig2CostID = tableItem2.Value;
				this.mOwnNum = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(this.mUnlockSkillConfig2CostID);
				ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mUnlockSkillConfig2CostID, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					this.mCostItemName = tableItem3.Name;
				}
			}
		}

		// Token: 0x06010CA8 RID: 68776 RVA: 0x004C89AC File Offset: 0x004C6DAC
		private void _HideOrShowPVPOrPVEConfig(bool isShowPvE)
		{
			this.mPVEConfigGo.CustomActive(isShowPvE);
			this.mPVPConfigGo.CustomActive(!isShowPvE);
		}

		// Token: 0x06010CA9 RID: 68777 RVA: 0x004C89CC File Offset: 0x004C6DCC
		private void _InitScrollPos()
		{
			this.mPveSrowViewPos1 = new Vector2(0.8f, 1f);
			this.mPveSrowViewPos2 = new Vector2(0.8f, 1f);
			this.mPvpSrowViewPos1 = new Vector2(0.8f, 1f);
			this.mPvpSrowViewPos2 = new Vector2(0.8f, 1f);
		}

		// Token: 0x06010CAA RID: 68778 RVA: 0x004C8A30 File Offset: 0x004C6E30
		private void _InitSkillPage()
		{
			this._isSendChangedChangedSkillPageMsg = false;
			bool isShowPvE = DataManager<SkillDataManager>.GetInstance().isPve();
			this._HideOrShowPVPOrPVEConfig(isShowPvE);
			this.mPVPToggle1.isOn = (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1);
			this.mPVPToggle2.isOn = (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page2);
			this.mPVEToggle1.isOn = (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1);
			this.mPVEToggle2.isOn = (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page2);
			if (this.mPVPToggle1.isOn)
			{
				this.mPVPSkillPage1TxtColor.SetColor(1);
				this.mPVPSkillPage2TxtColor.SetColor(0);
				this.mPvpSkillPage1State = true;
			}
			else
			{
				this.mPVPSkillPage2TxtColor.SetColor(1);
				this.mPVPSkillPage1TxtColor.SetColor(0);
				this.mPvpSkillPage2State = true;
			}
			if (this.mPVEToggle1.isOn)
			{
				this.mPVESkillPage1TxtColor.SetColor(1);
				this.mPVESkillPage2TxtColor.SetColor(0);
				this.mPveSkillPage1State = true;
			}
			else
			{
				this.mPVESkillPage2TxtColor.SetColor(1);
				this.mPVESkillPage1TxtColor.SetColor(0);
				this.mPveSkillPage2State = true;
			}
			this.mPVELockBtn.CustomActive(!DataManager<SkillDataManager>.GetInstance().PVESkillPage2IsUnlock);
			this.mPVPLockBtn.CustomActive(!DataManager<SkillDataManager>.GetInstance().PVPSkillPage2IsUnlock);
			this._isSendChangedChangedSkillPageMsg = true;
			if (DataManager<SkillDataManager>.GetInstance().IsJumpPVESkillPageExchangeTip)
			{
				this.mPVETipBtn1.CustomActive(false);
				this.mPVETipBtn2.CustomActive(false);
			}
			if (DataManager<SkillDataManager>.GetInstance().IsJumpPVPSkillPageExchangeTip)
			{
				this.mPVPTipBtn1.CustomActive(false);
				this.mPVPTipBtn2.CustomActive(false);
			}
		}

		// Token: 0x06010CAB RID: 68779 RVA: 0x004C8BE4 File Offset: 0x004C6FE4
		private void _OnFreshAllSkillFrame()
		{
			if (DataManager<SkillDataManager>.GetInstance().isPve())
			{
				if (DataManager<SkillDataManager>.GetInstance().CurPVESKillPage == EPVESkillPage.Page1)
				{
					this.Totalsp.text = this.totalsp.ToString();
				}
				else
				{
					this.Totalsp.text = this.totalsp2.ToString();
				}
			}
			else if (DataManager<SkillDataManager>.GetInstance().CurPVPSKillPage == EPVPSkillPage.Page1)
			{
				this.Totalsp.text = this.pvpTotalsp.ToString();
			}
			else
			{
				this.Totalsp.text = this.pvpTotalsp2.ToString();
			}
			this.UpdateLeftInterface(false);
			this.UpdateRightInterface();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SkillPlanFrame>(null))
			{
				SkillPlanFrame.UpdateSkillBar();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateCurUseSkillBar, null, null, null, null);
			}
			else
			{
				this.UpdatePlanIsFull();
			}
		}

		// Token: 0x0400ABA5 RID: 43941
		private string SkillTreeElementPath = "UIFlatten/Prefabs/Skill/SkillTreeElement";

		// Token: 0x0400ABA6 RID: 43942
		private string UniqueSkillPath = "UIFlatten/Prefabs/Skill/JobSkillTree";

		// Token: 0x0400ABA7 RID: 43943
		private string NewSkillEffectPath = "Effects/Scene_effects/EffectUI/EffUI_newskill";

		// Token: 0x0400ABA8 RID: 43944
		private string SkillLvUpEffectPath = "Effects/Scene_effects/EffectUI/EffUI_jinengshengji_guo";

		// Token: 0x0400ABA9 RID: 43945
		private string SkillLvDownEffectPath = "Effects/Scene_effects/EffectUI/EffUI_jinengjiangji_guo";

		// Token: 0x0400ABAA RID: 43946
		private string LeftRootPath = "left/root/JobSkillTree(Clone)/ScrollView";

		// Token: 0x0400ABAB RID: 43947
		private string EffectNewSkillRootPath = "/Viewport/Content/Pos{0}/SkillTreeElement(Clone)/icon/SkillIcon/EffUI_newskill(Clone)";

		// Token: 0x0400ABAC RID: 43948
		private string EffectLvUpRootPath = "/Viewport/Content/ActiveSkillPanel{0}/Pos{1}/SkillTreeElement(Clone)/icon/SkillIcon/EffUI_jinengshengji_guo(Clone)";

		// Token: 0x0400ABAD RID: 43949
		private string EffectLvDownRootPath = "/Viewport/Content/ActiveSkillPanel{0}/Pos{1}/SkillTreeElement(Clone)/icon/SkillIcon/EffUI_jinengjiangji_guo(Clone)";

		// Token: 0x0400ABAE RID: 43950
		private const int TabNum = 2;

		// Token: 0x0400ABAF RID: 43951
		private float fViewPortPos = 952.7f;

		// Token: 0x0400ABB0 RID: 43952
		private static int SkillTypeNum = 2;

		// Token: 0x0400ABB1 RID: 43953
		private uint totalsp;

		// Token: 0x0400ABB2 RID: 43954
		private uint totalsp2;

		// Token: 0x0400ABB3 RID: 43955
		private uint pvpTotalsp;

		// Token: 0x0400ABB4 RID: 43956
		private uint pvpTotalsp2;

		// Token: 0x0400ABB5 RID: 43957
		private ulong totalgold;

		// Token: 0x0400ABB6 RID: 43958
		private GameObject UniqueSkillobj;

		// Token: 0x0400ABB7 RID: 43959
		public static int CurSelSkillTreeBtnIdx = -1;

		// Token: 0x0400ABB8 RID: 43960
		public static bool bIsApplySkillState = true;

		// Token: 0x0400ABB9 RID: 43961
		private static ushort CurSelSkillTreeID = 0;

		// Token: 0x0400ABBA RID: 43962
		private byte CurSelSkillLv;

		// Token: 0x0400ABBB RID: 43963
		private FightTypeLabel CurSelFightType;

		// Token: 0x0400ABBC RID: 43964
		private SkillLeftType CurSelMainTab;

		// Token: 0x0400ABBD RID: 43965
		private bool IsOpenSkillPlanPVE;

		// Token: 0x0400ABBE RID: 43966
		private bool IsOpenSkillPlanPVP;

		// Token: 0x0400ABBF RID: 43967
		private bool isUniteDeploy;

		// Token: 0x0400ABC0 RID: 43968
		private bool needPvpTips;

		// Token: 0x0400ABC1 RID: 43969
		protected GameObject uniqueContent;

		// Token: 0x0400ABC2 RID: 43970
		protected GameObject SkillTreeScrollView;

		// Token: 0x0400ABC3 RID: 43971
		protected ScrollRect scrollRect;

		// Token: 0x0400ABC4 RID: 43972
		protected static List<GameObject> skillPos = new List<GameObject>();

		// Token: 0x0400ABC5 RID: 43973
		protected List<int> skillPosPanelIndexList = new List<int>();

		// Token: 0x0400ABC6 RID: 43974
		protected GameObject SkillTreeElementTemplate;

		// Token: 0x0400ABC7 RID: 43975
		public static List<string> uniqueSkillTransform;

		// Token: 0x0400ABC8 RID: 43976
		public static Dictionary<ushort, byte> ChangedSkills = new Dictionary<ushort, byte>();

		// Token: 0x0400ABC9 RID: 43977
		public static Dictionary<ushort, byte> ChangedSkills2 = new Dictionary<ushort, byte>();

		// Token: 0x0400ABCA RID: 43978
		public static Dictionary<ushort, byte> pvpChangedSkills = new Dictionary<ushort, byte>();

		// Token: 0x0400ABCB RID: 43979
		public static Dictionary<ushort, byte> pvpChangedSkills2 = new Dictionary<ushort, byte>();

		// Token: 0x0400ABCC RID: 43980
		public Dictionary<int, SkillLevelAddInfo> AddSkillInfo = new Dictionary<int, SkillLevelAddInfo>();

		// Token: 0x0400ABCD RID: 43981
		public Dictionary<int, SkillLevelAddInfo> pvpAddSkillInfo = new Dictionary<int, SkillLevelAddInfo>();

		// Token: 0x0400ABCE RID: 43982
		private int mUnlockSkillConfig2CostNum = 1;

		// Token: 0x0400ABCF RID: 43983
		private int mUnlockSkillConfig2CostID = 330000250;

		// Token: 0x0400ABD0 RID: 43984
		private string mCostItemName = string.Empty;

		// Token: 0x0400ABD1 RID: 43985
		private int mOwnNum;

		// Token: 0x0400ABD2 RID: 43986
		private Vector2 mPveSrowViewPos1 = Vector2.zero;

		// Token: 0x0400ABD3 RID: 43987
		private Vector2 mPveSrowViewPos2 = Vector2.zero;

		// Token: 0x0400ABD4 RID: 43988
		private Vector2 mPvpSrowViewPos1 = Vector2.zero;

		// Token: 0x0400ABD5 RID: 43989
		private Vector2 mPvpSrowViewPos2 = Vector2.zero;

		// Token: 0x0400ABD6 RID: 43990
		private bool _isSendChangedChangedSkillPageMsg = true;

		// Token: 0x0400ABD7 RID: 43991
		private bool _isClickInitSkillBar;

		// Token: 0x0400ABD8 RID: 43992
		private ComSetTextColor mPVESkillPage1TxtColor;

		// Token: 0x0400ABD9 RID: 43993
		private ComSetTextColor mPVESkillPage2TxtColor;

		// Token: 0x0400ABDA RID: 43994
		private ComSetTextColor mPVPSkillPage1TxtColor;

		// Token: 0x0400ABDB RID: 43995
		private ComSetTextColor mPVPSkillPage2TxtColor;

		// Token: 0x0400ABDC RID: 43996
		private bool mPveSkillPage1State;

		// Token: 0x0400ABDD RID: 43997
		private bool mPveSkillPage2State;

		// Token: 0x0400ABDE RID: 43998
		private bool mPvpSkillPage1State;

		// Token: 0x0400ABDF RID: 43999
		private bool mPvpSkillPage2State;

		// Token: 0x0400ABE0 RID: 44000
		[UIControl("back", null, 0)]
		private Image back;

		// Token: 0x0400ABE1 RID: 44001
		[UIControl("Title/SpBack/SpName/sp", null, 0)]
		protected Text Totalsp;

		// Token: 0x0400ABE2 RID: 44002
		[UIControl("left/tabroot/Tab{0}", typeof(Toggle), 1)]
		private Toggle[] MainTabToggle = new Toggle[4];

		// Token: 0x0400ABE3 RID: 44003
		[UIControl("rightNew/Title/attribute/Type{0}/Text", typeof(Text), 0)]
		private Text[] attributeTypeText = new Text[6];

		// Token: 0x0400ABE4 RID: 44004
		[UIControl("rightNew/Title/attribute/Type{0}", typeof(RectTransform), 0)]
		private RectTransform[] attributeTypeGo = new RectTransform[6];

		// Token: 0x0400ABE5 RID: 44005
		private GameObject mPlanTips;

		// Token: 0x0400ABE6 RID: 44006
		private Text mPlanTipsText;

		// Token: 0x0400ABE7 RID: 44007
		private Text mChangeJobTips;

		// Token: 0x0400ABE8 RID: 44008
		private GameObject mChangeJobPreview;

		// Token: 0x0400ABE9 RID: 44009
		private GameObject mPassiveSkillRootObj;

		// Token: 0x0400ABEA RID: 44010
		private GameObject mActiveSkillRoot;

		// Token: 0x0400ABEB RID: 44011
		private GameObject mRightRoot;

		// Token: 0x0400ABEC RID: 44012
		private Image mRightSkillIcon;

		// Token: 0x0400ABED RID: 44013
		private Text mRightSkillName;

		// Token: 0x0400ABEE RID: 44014
		private Text mRightSkillLevel;

		// Token: 0x0400ABEF RID: 44015
		private Text mRightSkillType;

		// Token: 0x0400ABF0 RID: 44016
		private Text mRightSkillCD;

		// Token: 0x0400ABF1 RID: 44017
		private Text mRightSkillConsumeMP;

		// Token: 0x0400ABF2 RID: 44018
		private Text mRightSkillConsumeThing;

		// Token: 0x0400ABF3 RID: 44019
		private Text mRightSkillDes;

		// Token: 0x0400ABF4 RID: 44020
		private Text mLeftSkillAttribute;

		// Token: 0x0400ABF5 RID: 44021
		private Text mRightSkillAttribute;

		// Token: 0x0400ABF6 RID: 44022
		private Text mLevelLimitDes;

		// Token: 0x0400ABF7 RID: 44023
		private Text mNeedSP;

		// Token: 0x0400ABF8 RID: 44024
		private Text mNeedLevel;

		// Token: 0x0400ABF9 RID: 44025
		private Button mLevelDown;

		// Token: 0x0400ABFA RID: 44026
		private Button mLevelUp;

		// Token: 0x0400ABFB RID: 44027
		private GameObject mLevelMaxImage;

		// Token: 0x0400ABFC RID: 44028
		private Button mOpenSkillPlan;

		// Token: 0x0400ABFD RID: 44029
		private Text mRightAddLevel;

		// Token: 0x0400ABFE RID: 44030
		private Text mSkillPlanText;

		// Token: 0x0400ABFF RID: 44031
		private ScrollRect mSkillDesScrollRect;

		// Token: 0x0400AC00 RID: 44032
		private ScrollRect mLeftSkillDesScrollRect;

		// Token: 0x0400AC01 RID: 44033
		private ScrollRect mRightSkillDesScrollRect;

		// Token: 0x0400AC02 RID: 44034
		private Button mAddSp;

		// Token: 0x0400AC03 RID: 44035
		private GameObject mMaxRoot;

		// Token: 0x0400AC04 RID: 44036
		private Text mPveToggleDes;

		// Token: 0x0400AC05 RID: 44037
		private GameObject mPvpSkillCD;

		// Token: 0x0400AC06 RID: 44038
		private Text mPvpSkillCDNum;

		// Token: 0x0400AC07 RID: 44039
		private GameObject mSkillInitConfigRoot;

		// Token: 0x0400AC08 RID: 44040
		private Button mSkillInitButton;

		// Token: 0x0400AC09 RID: 44041
		private Button mSkillConfigButton;

		// Token: 0x0400AC0A RID: 44042
		private Button mPassiveSkillBtn;

		// Token: 0x0400AC0B RID: 44043
		private GameObject mPVEConfigGo;

		// Token: 0x0400AC0C RID: 44044
		private Toggle mPVEToggle1;

		// Token: 0x0400AC0D RID: 44045
		private Toggle mPVEToggle2;

		// Token: 0x0400AC0E RID: 44046
		private Button mPVELockBtn;

		// Token: 0x0400AC0F RID: 44047
		private Button mPVETipBtn1;

		// Token: 0x0400AC10 RID: 44048
		private Button mPVETipBtn2;

		// Token: 0x0400AC11 RID: 44049
		private GameObject mPVPConfigGo;

		// Token: 0x0400AC12 RID: 44050
		private Toggle mPVPToggle1;

		// Token: 0x0400AC13 RID: 44051
		private Toggle mPVPToggle2;

		// Token: 0x0400AC14 RID: 44052
		private Button mPVPLockBtn;

		// Token: 0x0400AC15 RID: 44053
		private Button mPVPTipBtn1;

		// Token: 0x0400AC16 RID: 44054
		private Button mPVPTipBtn2;

		// Token: 0x0400AC17 RID: 44055
		[CompilerGenerated]
		private static Drag_Me.OnResDrag <>f__mg$cache0;

		// Token: 0x0400AC18 RID: 44056
		[CompilerGenerated]
		private static Drop_Me.OnResDrop <>f__mg$cache1;

		// Token: 0x0400AC19 RID: 44057
		[CompilerGenerated]
		private static Drop_Me.OnResDrop <>f__mg$cache2;
	}
}
