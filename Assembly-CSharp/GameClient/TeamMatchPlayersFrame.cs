using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C14 RID: 7188
	internal class TeamMatchPlayersFrame : ClientFrame
	{
		// Token: 0x060119DA RID: 72154 RVA: 0x00525BA0 File Offset: 0x00523FA0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMatchPlayersFrame";
		}

		// Token: 0x060119DB RID: 72155 RVA: 0x00525BA7 File Offset: 0x00523FA7
		protected override void _OnOpenFrame()
		{
			this.resultData = (this.userData as WorldTeamMatchResultNotify);
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x060119DC RID: 72156 RVA: 0x00525BC6 File Offset: 0x00523FC6
		protected override void _OnCloseFrame()
		{
			this.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x060119DD RID: 72157 RVA: 0x00525BD4 File Offset: 0x00523FD4
		private new void Clear()
		{
			this.resultData = new WorldTeamMatchResultNotify();
			this.dungeonName = string.Empty;
			this.MaxWaitTime = 15f;
			this.fAddUpTime = 0f;
		}

		// Token: 0x060119DE RID: 72158 RVA: 0x00525C02 File Offset: 0x00524002
		private void BindUIEvent()
		{
		}

		// Token: 0x060119DF RID: 72159 RVA: 0x00525C04 File Offset: 0x00524004
		private void UnBindUIEvent()
		{
		}

		// Token: 0x060119E0 RID: 72160 RVA: 0x00525C08 File Offset: 0x00524008
		[UIEventHandle("middle/cancel")]
		private void OnCancel()
		{
			WorldTeamMatchCancelReq cmd = new WorldTeamMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			this.frameMgr.CloseFrame<TeamMatchPlayersFrame>(this, false);
		}

		// Token: 0x060119E1 RID: 72161 RVA: 0x00525C38 File Offset: 0x00524038
		private void InitInterface()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>((int)this.resultData.dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.dungeonName = tableItem.Name;
			for (int i = 0; i < 3; i++)
			{
				if (i < this.resultData.players.Length && this.resultData.players[i].id != 0UL)
				{
					JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.resultData.players[i].occu, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ETCImageLoader.LoadSprite(ref this.icons[i], tableItem2.JobHalfBody, true);
						this.Lvs[i].text = string.Format("Lv.{0}", this.resultData.players[i].level);
						this.Names[i].text = this.resultData.players[i].name;
						this.Occus[i].text = tableItem2.Name;
						this.members[i].gameObject.SetActive(true);
					}
				}
				else
				{
					this.members[i].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x060119E2 RID: 72162 RVA: 0x00525D8C File Offset: 0x0052418C
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060119E3 RID: 72163 RVA: 0x00525D90 File Offset: 0x00524190
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fAddUpTime += timeElapsed;
			if (this.fAddUpTime > 1f)
			{
				this.MaxWaitTime -= 1f;
				this.fAddUpTime = 0f;
				int num = (int)this.MaxWaitTime;
				this.DungeonName.text = string.Format("{0}秒后进入{1}", num, this.dungeonName);
			}
		}

		// Token: 0x0400B773 RID: 46963
		private const int MemberNum = 3;

		// Token: 0x0400B774 RID: 46964
		private string dungeonName = string.Empty;

		// Token: 0x0400B775 RID: 46965
		private float MaxWaitTime = 5f;

		// Token: 0x0400B776 RID: 46966
		private float fAddUpTime;

		// Token: 0x0400B777 RID: 46967
		private WorldTeamMatchResultNotify resultData = new WorldTeamMatchResultNotify();

		// Token: 0x0400B778 RID: 46968
		[UIControl("middle/title/text", null, 0)]
		private Text DungeonName;

		// Token: 0x0400B779 RID: 46969
		[UIControl("middle/memberroot/mem{0}", typeof(Image), 1)]
		private Image[] members = new Image[3];

		// Token: 0x0400B77A RID: 46970
		[UIControl("middle/memberroot/mem{0}/Mask/OccuHead", typeof(Image), 1)]
		private Image[] icons = new Image[3];

		// Token: 0x0400B77B RID: 46971
		[UIControl("middle/memberroot/mem{0}/Lv", typeof(Text), 1)]
		private Text[] Lvs = new Text[3];

		// Token: 0x0400B77C RID: 46972
		[UIControl("middle/memberroot/mem{0}/nameback/Name", typeof(Text), 1)]
		private Text[] Names = new Text[3];

		// Token: 0x0400B77D RID: 46973
		[UIControl("middle/memberroot/mem{0}/nameback/Occu", typeof(Text), 1)]
		private Text[] Occus = new Text[3];
	}
}
