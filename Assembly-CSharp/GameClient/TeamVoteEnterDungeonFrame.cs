using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C23 RID: 7203
	internal class TeamVoteEnterDungeonFrame : ClientFrame
	{
		// Token: 0x06011AB1 RID: 72369 RVA: 0x0052D15F File Offset: 0x0052B55F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamVoteEnterDungeonFrame";
		}

		// Token: 0x06011AB2 RID: 72370 RVA: 0x0052D168 File Offset: 0x0052B568
		protected override void _OnOpenFrame()
		{
			this.bFlag = false;
			this.iDungeonID = (int)this.userData;
			this.InitInterface();
			this.BindUIEvent();
			if (Global.Settings.IsTestTeam())
			{
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(2000, delegate
				{
					this.OnAgree();
				}, 0, 0, false);
			}
		}

		// Token: 0x06011AB3 RID: 72371 RVA: 0x0052D1CC File Offset: 0x0052B5CC
		protected override void _OnCloseFrame()
		{
			this.bFlag = false;
			this.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x06011AB4 RID: 72372 RVA: 0x0052D1E1 File Offset: 0x0052B5E1
		private new void Clear()
		{
			this.MaxWaitTime = 10f;
			this.fAddUpTime = 0f;
			this.Process.value = 0f;
			this.iDungeonID = 0;
			this.AgreeAddTime = 0f;
		}

		// Token: 0x06011AB5 RID: 72373 RVA: 0x0052D21B File Offset: 0x0052B61B
		private void BindUIEvent()
		{
		}

		// Token: 0x06011AB6 RID: 72374 RVA: 0x0052D21D File Offset: 0x0052B61D
		private void UnBindUIEvent()
		{
		}

		// Token: 0x06011AB7 RID: 72375 RVA: 0x0052D220 File Offset: 0x0052B620
		private void _OnReject()
		{
			if (this.bFlag)
			{
				return;
			}
			this.bFlag = true;
			this.bUpdate = false;
			WorldTeamReportVoteChoice worldTeamReportVoteChoice = new WorldTeamReportVoteChoice();
			worldTeamReportVoteChoice.agree = 0;
			this.RejectText.text = string.Format("拒绝", new object[0]);
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamReportVoteChoice>(ServerType.GATE_SERVER, worldTeamReportVoteChoice);
			this.frameMgr.CloseFrame<TeamVoteEnterDungeonFrame>(this, false);
		}

		// Token: 0x06011AB8 RID: 72376 RVA: 0x0052D28B File Offset: 0x0052B68B
		[UIEventHandle("middle/reject")]
		private void OnReject()
		{
			this._OnReject();
			DataManager<TeamDataManager>.GetInstance().IsAutoAgree = false;
		}

		// Token: 0x06011AB9 RID: 72377 RVA: 0x0052D2A0 File Offset: 0x0052B6A0
		[UIEventHandle("middle/agree")]
		private void OnAgree()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.GetTownSceneSwitchState())
			{
				this._OnReject();
				return;
			}
			if (this.bFlag)
			{
				return;
			}
			this.bFlag = true;
			this.bUpdate = false;
			WorldTeamReportVoteChoice worldTeamReportVoteChoice = new WorldTeamReportVoteChoice();
			worldTeamReportVoteChoice.agree = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamReportVoteChoice>(ServerType.GATE_SERVER, worldTeamReportVoteChoice);
			this.btAgree.GetComponent<UIGray>().enabled = true;
			this.btAgree.interactable = false;
			this.btReject.GetComponent<UIGray>().enabled = true;
			this.btReject.interactable = false;
			this.AgreeText.text = string.Format("同意", new object[0]);
			this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_AGREE_HOLDMAX;
			this.TimeRemain = 15f;
			this.fAddUpTime = 0f;
			this.AgreeAddTime = 0f;
		}

		// Token: 0x06011ABA RID: 72378 RVA: 0x0052D388 File Offset: 0x0052B788
		private void InitInterface()
		{
			UIGray uigray = this.btAgree.gameObject.AddComponent<UIGray>();
			uigray.enabled = false;
			UIGray uigray2 = this.btReject.gameObject.AddComponent<UIGray>();
			uigray2.enabled = false;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.iDungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				this.btReject.gameObject.SetActive(false);
				this.btAgree.gameObject.SetActive(false);
				this.mTeamLeaderTips.SetActive(true);
			}
			else
			{
				this.btReject.gameObject.SetActive(true);
				this.btAgree.gameObject.SetActive(true);
				this.mTeamLeaderTips.SetActive(false);
			}
			for (int i = 0; i < 3; i++)
			{
				UIGray uigray3 = this.members[i].gameObject.AddComponent<UIGray>();
				uigray3.enabled = true;
			}
			this.DungeonName.text = tableItem.Name;
			if (this.txtTeamTargetInfo != null)
			{
				if (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL || tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
				{
					this.txtTeamTargetInfo.text = string.Format("{0}({1})", tableItem.Name, DataManager<TeamDataManager>.GetInstance().GeDungeontHardName(3));
				}
				else
				{
					this.txtTeamTargetInfo.text = string.Format("{0}({1})", tableItem.Name, DataManager<TeamDataManager>.GetInstance().GeDungeontHardName((byte)tableItem.Hard));
				}
			}
			if (this.togAutoAgree != null)
			{
				this.togAutoAgree.isOn = DataManager<TeamDataManager>.GetInstance().IsAutoAgree;
			}
			if (this.togAutoAgree != null)
			{
				this.togAutoAgree.CustomActive(!DataManager<TeamDataManager>.GetInstance().IsTeamLeader());
			}
			this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_REJECT;
			this.TimeRemain = 10f;
			this.fAddUpTime = 0f;
			if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMLEADER;
				this.TimeRemain = 10f;
			}
			else if (DataManager<TeamDataManager>.GetInstance().IsAutoAgree)
			{
				this.MaxWaitTime = 3f;
				if (this._isSystemInLoading())
				{
					this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE_WAITLOADING;
					this.TimeRemain = 10f;
				}
				else
				{
					this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE;
					this.TimeRemain = 3f;
				}
			}
			this.bUpdate = true;
			this.UpdateInterface();
		}

		// Token: 0x06011ABB RID: 72379 RVA: 0x0052D620 File Offset: 0x0052BA20
		private void UpdateInterface()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				if (i < myTeam.members.Length && myTeam.members[i].id != 0UL)
				{
					UIGray component = this.members[i].gameObject.GetComponent<UIGray>();
					component.enabled = false;
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)myTeam.members[i].occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ETCImageLoader.LoadSprite(ref this.icons[i], tableItem.JobHalfBody, true);
						this.Lvs[i].text = string.Format("Lv.{0}", myTeam.members[i].level);
						this.Names[i].text = myTeam.members[i].name;
						this.Occus[i].text = tableItem.Name;
						if (myTeam.members[i].id == myTeam.leaderInfo.id)
						{
							UIGray component2 = this.members[i].gameObject.GetComponent<UIGray>();
							component2.enabled = false;
						}
						else
						{
							UIGray component3 = this.members[i].gameObject.GetComponent<UIGray>();
							component3.enabled = true;
						}
						this.members[i].gameObject.SetActive(true);
					}
				}
				else
				{
					this.members[i].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06011ABC RID: 72380 RVA: 0x0052D7B0 File Offset: 0x0052BBB0
		public void UpdateMemVoteState(WorldTeamVoteChoiceNotify NotifyData)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				if (myTeam.members[i].id == NotifyData.roleId && NotifyData.roleId != 0UL)
				{
					if (NotifyData.agree == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(string.Format(TR.Value("rejectEnterDungeon"), myTeam.members[i].name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						UIGray component = this.members[i].gameObject.GetComponent<UIGray>();
						component.enabled = false;
					}
					break;
				}
			}
			if (NotifyData.agree == 0)
			{
				this.frameMgr.CloseFrame<TeamVoteEnterDungeonFrame>(this, false);
			}
		}

		// Token: 0x06011ABD RID: 72381 RVA: 0x0052D877 File Offset: 0x0052BC77
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06011ABE RID: 72382 RVA: 0x0052D87A File Offset: 0x0052BC7A
		protected bool _isSystemInLoading()
		{
			return Singleton<ClientSystemManager>.instance.isSwitchSystemLoading && Singleton<ClientSystemManager>.instance.TargetSystem != null;
		}

		// Token: 0x06011ABF RID: 72383 RVA: 0x0052D89E File Offset: 0x0052BC9E
		protected void ResetTimeRemain(float time)
		{
			this.TimeRemain = time;
			this.fAddUpTime = 0f;
		}

		// Token: 0x06011AC0 RID: 72384 RVA: 0x0052D8B4 File Offset: 0x0052BCB4
		protected override void _OnUpdate(float timeElapsed)
		{
			this.Process.value += this.fSpeed;
			if (this.Process.value >= 1f && !DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				if (DataManager<TeamDataManager>.GetInstance().IsAutoAgree)
				{
					this.OnAgree();
				}
				else
				{
					this.OnReject();
				}
				return;
			}
			if (!this.bUpdate)
			{
				if (this.mUpdateMode == TeamVoteEnterDungeonFrame.UpdateMode.AUTO_AGREE_HOLDMAX)
				{
					this.AgreeAddTime += timeElapsed;
					if (this.AgreeAddTime > 15f)
					{
						this.frameMgr.CloseFrame<TeamVoteEnterDungeonFrame>(this, false);
					}
				}
				return;
			}
			this.fAddUpTime += timeElapsed;
			if (this.fAddUpTime > 1f)
			{
				this.TimeRemain -= 1f;
				this.MaxWaitTime -= 1f;
				this.fAddUpTime = 0f;
			}
			switch (this.mUpdateMode)
			{
			case TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_REJECT:
			{
				int num = (int)this.TimeRemain;
				if (num >= 0)
				{
					this.RejectText.text = string.Format("拒绝({0}s)", num);
					this.AgreeText.text = string.Format("同意", new object[0]);
				}
				if (this.TimeRemain < 0.05f)
				{
					this._OnReject();
				}
				break;
			}
			case TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE:
			{
				int num2 = (int)this.TimeRemain;
				if (num2 >= 0)
				{
					this.RejectText.text = string.Format("拒绝", new object[0]);
					this.AgreeText.text = string.Format("同意({0}s)", num2);
				}
				if (this.TimeRemain < 0.05f)
				{
					this.OnAgree();
				}
				break;
			}
			case TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE_WAITLOADING:
				if (this.TimeRemain < 0.05f)
				{
					this._OnReject();
				}
				if (!this._isSystemInLoading())
				{
					this.TimeRemain = 3f;
					this.fAddUpTime = 0f;
					this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE;
				}
				break;
			case TeamVoteEnterDungeonFrame.UpdateMode.AUTO_AGREE_HOLDMAX:
				if (this.TimeRemain < 0.05f)
				{
					this.frameMgr.CloseFrame<TeamVoteEnterDungeonFrame>(this, false);
				}
				break;
			}
		}

		// Token: 0x06011AC1 RID: 72385 RVA: 0x0052DB00 File Offset: 0x0052BF00
		protected override void _bindExUI()
		{
			this.mTeamLeaderTips = this.mBind.GetGameObject("teamLeaderTips");
			this.txtTeamTargetInfo = this.mBind.GetCom<Text>("txtTeamTargetInfo");
			this.togAutoAgree = this.mBind.GetCom<Toggle>("togAutoAgree");
			if (this.togAutoAgree != null)
			{
				this.togAutoAgree.onValueChanged.RemoveAllListeners();
				this.togAutoAgree.onValueChanged.AddListener(delegate(bool bIsOn)
				{
					if (!bIsOn && DataManager<TeamDataManager>.GetInstance().IsAutoAgree)
					{
						this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_REJECT;
						this.TimeRemain = 10f;
						this.fAddUpTime = 0f;
						if (this.MaxWaitTime > 0f)
						{
							this.fAddUpTime = 0f;
							this.MaxWaitTime = 10f;
						}
						this.RejectText.text = string.Format("拒绝", new object[0]);
						this.AgreeText.text = string.Format("同意", new object[0]);
					}
					else if (bIsOn && !DataManager<TeamDataManager>.GetInstance().IsAutoAgree)
					{
						this.mUpdateMode = TeamVoteEnterDungeonFrame.UpdateMode.AUTO_TEAMMETE_AGREE;
						this.TimeRemain = 3f;
						this.fAddUpTime = 0f;
						if (this.MaxWaitTime > 0f)
						{
							this.fAddUpTime = 0f;
							this.MaxWaitTime = 3f;
						}
						this.RejectText.text = string.Format("拒绝", new object[0]);
						this.AgreeText.text = string.Format("同意", new object[0]);
					}
					DataManager<TeamDataManager>.GetInstance().IsAutoAgree = bIsOn;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamInfoUpdateSuccess, null, null, null, null);
				});
			}
		}

		// Token: 0x06011AC2 RID: 72386 RVA: 0x0052DB8C File Offset: 0x0052BF8C
		protected override void _unbindExUI()
		{
			this.mTeamLeaderTips = null;
			this.txtTeamTargetInfo = null;
			this.togAutoAgree = null;
		}

		// Token: 0x0400B81D RID: 47133
		private const int MemberNum = 3;

		// Token: 0x0400B81E RID: 47134
		private float MaxWaitTime = 10f;

		// Token: 0x0400B81F RID: 47135
		private float fAddUpTime;

		// Token: 0x0400B820 RID: 47136
		private float fSpeed = 0.00225f;

		// Token: 0x0400B821 RID: 47137
		private const float AgreeTime = 3f;

		// Token: 0x0400B822 RID: 47138
		private const float RejectTime = 10f;

		// Token: 0x0400B823 RID: 47139
		private const float HoldMaxTime = 15f;

		// Token: 0x0400B824 RID: 47140
		private float MaxWaitTime2 = 10f;

		// Token: 0x0400B825 RID: 47141
		private float TimeRemain;

		// Token: 0x0400B826 RID: 47142
		private bool bFlag;

		// Token: 0x0400B827 RID: 47143
		private bool bUpdate = true;

		// Token: 0x0400B828 RID: 47144
		private bool bWaitAutoAgree;

		// Token: 0x0400B829 RID: 47145
		private int iDungeonID;

		// Token: 0x0400B82A RID: 47146
		private float AgreeAddTime;

		// Token: 0x0400B82B RID: 47147
		private TeamVoteEnterDungeonFrame.UpdateMode mUpdateMode;

		// Token: 0x0400B82C RID: 47148
		[UIControl("middle/DungeonName", null, 0)]
		private Text DungeonName;

		// Token: 0x0400B82D RID: 47149
		[UIControl("middle/memberroot/mem{0}", typeof(Image), 1)]
		private Image[] members = new Image[3];

		// Token: 0x0400B82E RID: 47150
		[UIControl("middle/memberroot/mem{0}/Mask/OccuHead", typeof(Image), 1)]
		private Image[] icons = new Image[3];

		// Token: 0x0400B82F RID: 47151
		[UIControl("middle/memberroot/mem{0}/Lv", typeof(Text), 1)]
		private Text[] Lvs = new Text[3];

		// Token: 0x0400B830 RID: 47152
		[UIControl("middle/memberroot/mem{0}/nameback/Name", typeof(Text), 1)]
		private Text[] Names = new Text[3];

		// Token: 0x0400B831 RID: 47153
		[UIControl("middle/memberroot/mem{0}/nameback/Occu", typeof(Text), 1)]
		private Text[] Occus = new Text[3];

		// Token: 0x0400B832 RID: 47154
		[UIControl("middle/reject", null, 0)]
		private Button btReject;

		// Token: 0x0400B833 RID: 47155
		[UIControl("middle/reject/Text", null, 0)]
		private Text RejectText;

		// Token: 0x0400B834 RID: 47156
		[UIControl("middle/agree/Text", null, 0)]
		private Text AgreeText;

		// Token: 0x0400B835 RID: 47157
		[UIControl("middle/agree", null, 0)]
		private Button btAgree;

		// Token: 0x0400B836 RID: 47158
		[UIControl("middle/process", typeof(Slider), 0)]
		private Slider Process;

		// Token: 0x0400B837 RID: 47159
		private GameObject mTeamLeaderTips;

		// Token: 0x0400B838 RID: 47160
		private Text txtTeamTargetInfo;

		// Token: 0x0400B839 RID: 47161
		private Toggle togAutoAgree;

		// Token: 0x02001C24 RID: 7204
		private enum UpdateMode
		{
			// Token: 0x0400B83B RID: 47163
			AUTO_TEAMMETE_REJECT,
			// Token: 0x0400B83C RID: 47164
			AUTO_TEAMMETE_AGREE,
			// Token: 0x0400B83D RID: 47165
			AUTO_TEAMMETE_AGREE_WAITLOADING,
			// Token: 0x0400B83E RID: 47166
			AUTO_TEAMLEADER,
			// Token: 0x0400B83F RID: 47167
			AUTO_AGREE_HOLDMAX
		}
	}
}
