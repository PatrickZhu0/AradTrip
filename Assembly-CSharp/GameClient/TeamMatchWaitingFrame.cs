using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C17 RID: 7191
	internal class TeamMatchWaitingFrame : ClientFrame
	{
		// Token: 0x060119E7 RID: 72167 RVA: 0x00525E2C File Offset: 0x0052422C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMatchWaitingFrame";
		}

		// Token: 0x060119E8 RID: 72168 RVA: 0x00525E33 File Offset: 0x00524233
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as TeamMatchWaitingData);
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x060119E9 RID: 72169 RVA: 0x00525E52 File Offset: 0x00524252
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x060119EA RID: 72170 RVA: 0x00525E5A File Offset: 0x0052425A
		private void _Clear()
		{
			this.data.Clear();
			this.fAddUpTime = 0f;
			this.UnBindUIEvent();
		}

		// Token: 0x060119EB RID: 72171 RVA: 0x00525E78 File Offset: 0x00524278
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamJoinSuccess));
		}

		// Token: 0x060119EC RID: 72172 RVA: 0x00525EB0 File Offset: 0x005242B0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamJoinSuccess));
		}

		// Token: 0x060119ED RID: 72173 RVA: 0x00525EE8 File Offset: 0x005242E8
		[UIEventHandle("middle/btCancel")]
		private void OnCancel()
		{
			WorldTeamMatchCancelReq cmd = new WorldTeamMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			this.frameMgr.CloseFrame<TeamMatchWaitingFrame>(this, false);
		}

		// Token: 0x060119EE RID: 72174 RVA: 0x00525F18 File Offset: 0x00524318
		private void InitInterface()
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.data.TeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.data.matchState == MatchState.TeamJoin)
			{
				this.state.text = "组队中...";
			}
			else if (this.data.matchState == MatchState.TeamMatch)
			{
				this.state.text = "匹配中...";
			}
			this.targetDungeon.text = tableItem.Name;
		}

		// Token: 0x060119EF RID: 72175 RVA: 0x00525FA4 File Offset: 0x005243A4
		private void OnAddMemberSuccess(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<TeamMatchWaitingFrame>(this, false);
		}

		// Token: 0x060119F0 RID: 72176 RVA: 0x00525FB3 File Offset: 0x005243B3
		private void OnTeamJoinSuccess(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<TeamMatchWaitingFrame>(this, false);
		}

		// Token: 0x060119F1 RID: 72177 RVA: 0x00525FC2 File Offset: 0x005243C2
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060119F2 RID: 72178 RVA: 0x00525FC5 File Offset: 0x005243C5
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fAddUpTime += timeElapsed;
			this.timer.text = Function.GetLastsTimeStr((double)this.fAddUpTime);
		}

		// Token: 0x0400B784 RID: 46980
		private TeamMatchWaitingData data = new TeamMatchWaitingData();

		// Token: 0x0400B785 RID: 46981
		private float fAddUpTime;

		// Token: 0x0400B786 RID: 46982
		[UIControl("middle/state", null, 0)]
		private Text state;

		// Token: 0x0400B787 RID: 46983
		[UIControl("middle/timer", null, 0)]
		private Text timer;

		// Token: 0x0400B788 RID: 46984
		[UIControl("middle/Text/targetDungeon", null, 0)]
		private Text targetDungeon;
	}
}
