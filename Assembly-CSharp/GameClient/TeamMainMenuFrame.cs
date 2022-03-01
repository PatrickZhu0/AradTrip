using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C13 RID: 7187
	internal class TeamMainMenuFrame : ClientFrame
	{
		// Token: 0x060119C2 RID: 72130 RVA: 0x00525335 File Offset: 0x00523735
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMainMenu";
		}

		// Token: 0x060119C3 RID: 72131 RVA: 0x0052533C File Offset: 0x0052373C
		protected override void _OnOpenFrame()
		{
			this.bRequestGuildDungeonTeamList = false;
			this.requestListObj = new object();
			this._Initialize();
			this._BindUIEvent();
			this._RequestGuildDungeonTeamList();
		}

		// Token: 0x060119C4 RID: 72132 RVA: 0x00525362 File Offset: 0x00523762
		protected override void _OnCloseFrame()
		{
			this.bRequestGuildDungeonTeamList = false;
			InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
			this.requestListObj = null;
			this._Clear();
		}

		// Token: 0x060119C5 RID: 72133 RVA: 0x00525383 File Offset: 0x00523783
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060119C6 RID: 72134 RVA: 0x00525388 File Offset: 0x00523788
		protected override void _bindExUI()
		{
			this.guildDungeonTeams = this.mBind.GetGameObject("guildDungeonTeams");
			this.teamListParent = this.mBind.GetGameObject("teamListParent");
			this.teamItemTemplate = this.mBind.GetGameObject("teamItemTemplate");
			this.joinTips = this.mBind.GetCom<Text>("joinTips");
		}

		// Token: 0x060119C7 RID: 72135 RVA: 0x005253ED File Offset: 0x005237ED
		protected override void _unbindExUI()
		{
			this.guildDungeonTeams = null;
			this.teamListParent = null;
			this.teamItemTemplate = null;
			this.joinTips = null;
		}

		// Token: 0x060119C8 RID: 72136 RVA: 0x0052540C File Offset: 0x0052380C
		protected override void _OnUpdate(float timeElapsed)
		{
			this.m_btTeamList.CustomActive(Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildArenaFrame>(null));
			if (GuildDataManager.IsGuildDungeonMapScence() || GuildDataManager.IsInGuildAreanScence())
			{
				this.guildDungeonTeams.CustomActive(true);
				this.joinTips.CustomActive(false);
				if (!this.bRequestGuildDungeonTeamList)
				{
					this.bRequestGuildDungeonTeamList = true;
					InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
					InvokeMethod.InvokeInterval(this.requestListObj, 0f, 5f, float.MaxValue, null, new UnityAction(this._RequestGuildDungeonTeamList), null);
				}
			}
			else
			{
				this.guildDungeonTeams.CustomActive(false);
				this.joinTips.CustomActive(true);
				this.bRequestGuildDungeonTeamList = false;
				InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
			}
		}

		// Token: 0x060119C9 RID: 72137 RVA: 0x005254CF File Offset: 0x005238CF
		private void _RequestGuildDungeonTeamList()
		{
			DataManager<TeamDataManager>.GetInstance().RequestTeamListForTeamMainUI(0, DataManager<TeamDataManager>.GetInstance().nTeamGuildDungeonID);
		}

		// Token: 0x060119CA RID: 72138 RVA: 0x005254E6 File Offset: 0x005238E6
		private void _Clear()
		{
			this._UnBindUIEvent();
		}

		// Token: 0x060119CB RID: 72139 RVA: 0x005254F0 File Offset: 0x005238F0
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnQuitSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamListRequestSuccessForTeamMainUI, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
		}

		// Token: 0x060119CC RID: 72140 RVA: 0x00525550 File Offset: 0x00523950
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this._OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this._OnQuitSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamListRequestSuccessForTeamMainUI, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
		}

		// Token: 0x060119CD RID: 72141 RVA: 0x005255AE File Offset: 0x005239AE
		private void _OnCreateTeamSuccess(UIEvent uiEvent)
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060119CE RID: 72142 RVA: 0x005255C2 File Offset: 0x005239C2
		private void _OnQuitSuccess(UIEvent uiEvent)
		{
			this._SetupFuncBtns();
		}

		// Token: 0x060119CF RID: 72143 RVA: 0x005255CA File Offset: 0x005239CA
		private void OnTeamListRequestSuccess(UIEvent uiEvent)
		{
			this._UpdateGuildDungeonTeamList();
		}

		// Token: 0x060119D0 RID: 72144 RVA: 0x005255D4 File Offset: 0x005239D4
		[UIEventHandle("Content/funcs/CreateTeam/Button")]
		private void _OnCreateTeamClicked()
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(30, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SystemNotify(1300031, string.Empty);
				return;
			}
			if (GuildDataManager.IsInGuildAreanScence())
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
				return;
			}
			TeamCreateInfo createInfo = DataManager<TeamDataManager>.GetInstance().CreateInfo;
			createInfo.Debug();
			createInfo.Reset();
			DataManager<TeamDataManager>.GetInstance().CreateTeam(1U);
		}

		// Token: 0x060119D1 RID: 72145 RVA: 0x00525663 File Offset: 0x00523A63
		[UIEventHandle("Content/funcs/MyTeam/Button")]
		private void _OnMyTeamClicked()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060119D2 RID: 72146 RVA: 0x00525677 File Offset: 0x00523A77
		[UIEventHandle("Content/funcs/TeamList/Button")]
		private void _OnTeamListClicked()
		{
			ActiveManager.OnTeamListClicked(string.Empty);
		}

		// Token: 0x060119D3 RID: 72147 RVA: 0x00525683 File Offset: 0x00523A83
		[UIEventHandle("btTeamList")]
		private void _OnClickTeamList()
		{
			ActiveManager.OnTeamListClicked(string.Empty);
		}

		// Token: 0x060119D4 RID: 72148 RVA: 0x0052568F File Offset: 0x00523A8F
		private void _Initialize()
		{
			this._SetupFuncBtns();
		}

		// Token: 0x060119D5 RID: 72149 RVA: 0x00525698 File Offset: 0x00523A98
		private void _SetupFuncBtns()
		{
			bool flag = DataManager<TeamDataManager>.GetInstance().HasTeam();
			Utility.FindGameObject(this.m_content, "funcs/CreateTeam", true).SetActive(!flag);
			Utility.FindGameObject(this.m_content, "funcs/MyTeam", true).SetActive(flag);
		}

		// Token: 0x060119D6 RID: 72150 RVA: 0x005256E4 File Offset: 0x00523AE4
		private void _SetupFramePosition(Vector2 pos)
		{
			RectTransform component = this.frame.GetComponent<RectTransform>();
			RectTransform component2 = this.m_content.GetComponent<RectTransform>();
			LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
			float num = 0f;
			float num2 = component.rect.size.x - component2.rect.size.x;
			float num3 = component2.rect.size.y - component.rect.size.y;
			float num4 = 0f;
			Vector2 anchoredPosition;
			bool flag = RectTransformUtility.ScreenPointToLocalPointInRectangle(component, pos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref anchoredPosition);
			if (flag)
			{
				if (anchoredPosition.x < num)
				{
					anchoredPosition.x = num;
				}
				else if (anchoredPosition.x > num2)
				{
					anchoredPosition.x -= component2.rect.size.x;
				}
				if (anchoredPosition.y < num3)
				{
					anchoredPosition.y += component2.rect.size.y;
				}
				else if (anchoredPosition.y > num4)
				{
					anchoredPosition.y = num4;
				}
				component2.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x060119D7 RID: 72151 RVA: 0x00525844 File Offset: 0x00523C44
		private void _UpdateGuildDungeonTeamList()
		{
			if (this.guildDungeonTeams == null)
			{
				return;
			}
			if (!this.guildDungeonTeams.activeInHierarchy)
			{
				return;
			}
			if (this.teamListParent != null && this.teamItemTemplate != null)
			{
				List<Team> teamListForTeamMainUI = DataManager<TeamDataManager>.GetInstance().GetTeamListForTeamMainUI();
				int num = 0;
				for (int i = 0; i < this.teamListParent.transform.childCount; i++)
				{
					GameObject gameObject = this.teamListParent.transform.GetChild(i).gameObject;
					Object.Destroy(gameObject);
				}
				int num2 = 0;
				while (num2 < teamListForTeamMainUI.Count && num < 10)
				{
					Team team = teamListForTeamMainUI[num2];
					if (team != null)
					{
						if (team.currentMemberCount < team.maxMemberCount)
						{
							GameObject gameObject2 = Object.Instantiate<GameObject>(this.teamItemTemplate.gameObject);
							Utility.AttachTo(gameObject2, this.teamListParent, false);
							gameObject2.CustomActive(true);
							ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
							if (component != null)
							{
								StaticUtility.SafeSetText(component, "leader", team.leaderInfo.name);
								StaticUtility.SafeSetText(component, "count", string.Format("{0}/{1}", team.currentMemberCount, team.maxMemberCount));
								StaticUtility.SafeSetText(component, "target", TeamDataManager.GetTeamDungeonName(team.teamDungeonID));
								ulong iTeamID = teamListForTeamMainUI[num2].leaderInfo.id;
								StaticUtility.SafeSetBtnCallBack(component, "join", delegate
								{
									this.OnClickJoinTeam(iTeamID);
								});
							}
							num++;
						}
					}
					num2++;
				}
			}
		}

		// Token: 0x060119D8 RID: 72152 RVA: 0x00525A14 File Offset: 0x00523E14
		private void OnClickJoinTeam(ulong iTeamID)
		{
			int num = -1;
			List<Team> teamListForTeamMainUI = DataManager<TeamDataManager>.GetInstance().GetTeamListForTeamMainUI();
			for (int i = 0; i < teamListForTeamMainUI.Count; i++)
			{
				if (iTeamID == teamListForTeamMainUI[i].leaderInfo.id)
				{
					num = i;
					break;
				}
			}
			if (num < 0 || teamListForTeamMainUI == null || num >= teamListForTeamMainUI.Count)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_already_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num2 = -1;
			Team team = teamListForTeamMainUI[num];
			if (!Utility.CheckTeamCondition((int)team.teamDungeonID, ref num2))
			{
				if (num2 != -1)
				{
					SystemNotifyManager.SystemNotify(num2, string.Empty);
				}
				return;
			}
			if (teamListForTeamMainUI[num].currentMemberCount >= teamListForTeamMainUI[num].maxMemberCount)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("队伍人数已满", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDataManager>.GetInstance().JoinTeam(teamListForTeamMainUI[num].leaderInfo.id);
		}

		// Token: 0x0400B766 RID: 46950
		private const int maxListCount = 10;

		// Token: 0x0400B767 RID: 46951
		private object requestListObj;

		// Token: 0x0400B768 RID: 46952
		private bool bRequestGuildDungeonTeamList;

		// Token: 0x0400B769 RID: 46953
		private const float fRequestInterval = 5f;

		// Token: 0x0400B76A RID: 46954
		private GameObject guildDungeonTeams;

		// Token: 0x0400B76B RID: 46955
		private GameObject teamListParent;

		// Token: 0x0400B76C RID: 46956
		private GameObject teamItemTemplate;

		// Token: 0x0400B76D RID: 46957
		private Text joinTips;

		// Token: 0x0400B76E RID: 46958
		[UIControl("Content/funcs/CreateTeam/Button", null, 0)]
		private Button m_funCreateTeam;

		// Token: 0x0400B76F RID: 46959
		[UIControl("Content/funcs/MyTeam/Button", null, 0)]
		private Button m_funMyTeam;

		// Token: 0x0400B770 RID: 46960
		[UIControl("Content/funcs/TeamList/Button", null, 0)]
		private Button m_funTeamList;

		// Token: 0x0400B771 RID: 46961
		[UIObject("Content")]
		private GameObject m_content;

		// Token: 0x0400B772 RID: 46962
		[UIObject("btTeamList")]
		private GameObject m_btTeamList;
	}
}
