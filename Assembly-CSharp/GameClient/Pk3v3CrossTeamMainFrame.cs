using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019BB RID: 6587
	internal class Pk3v3CrossTeamMainFrame : ClientFrame
	{
		// Token: 0x06010189 RID: 65929 RVA: 0x00479D7A File Offset: 0x0047817A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossTeamMain";
		}

		// Token: 0x0601018A RID: 65930 RVA: 0x00479D84 File Offset: 0x00478184
		protected override void _OnOpenFrame()
		{
			if (this.btnInvite != null)
			{
				for (int i = 0; i < this.btnInvite.Length; i++)
				{
					Button button = this.btnInvite[i];
					if (button != null)
					{
						button.onClick.RemoveAllListeners();
						button.onClick.AddListener(new UnityAction(this.OnOpenInvite));
					}
				}
			}
			if (this.btnBk != null)
			{
				for (int j = 0; j < this.btnBk.Length; j++)
				{
					Button button2 = this.btnBk[j];
					if (button2 != null)
					{
						button2.onClick.RemoveAllListeners();
						button2.onClick.AddListener(new UnityAction(this.OnOpenInvite));
					}
				}
			}
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0601018B RID: 65931 RVA: 0x00479E53 File Offset: 0x00478253
		protected override void _OnCloseFrame()
		{
			this.Clear();
		}

		// Token: 0x0601018C RID: 65932 RVA: 0x00479E5B File Offset: 0x0047825B
		private new void Clear()
		{
			this.TeamDatas.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x0601018D RID: 65933 RVA: 0x00479E6E File Offset: 0x0047826E
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, new ClientEventSystem.UIEventHandler(this.OnUpdateInterface));
		}

		// Token: 0x0601018E RID: 65934 RVA: 0x00479E8B File Offset: 0x0047828B
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, new ClientEventSystem.UIEventHandler(this.OnUpdateInterface));
		}

		// Token: 0x0601018F RID: 65935 RVA: 0x00479EA8 File Offset: 0x004782A8
		private void SendQuitRoomReq()
		{
			WorldQuitRoomReq cmd = new WorldQuitRoomReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQuitRoomReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06010190 RID: 65936 RVA: 0x00479ECA File Offset: 0x004782CA
		[UIEventHandle("btQuit")]
		private void OnQuit()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.SendQuitRoomReq();
		}

		// Token: 0x06010191 RID: 65937 RVA: 0x00479EF0 File Offset: 0x004782F0
		[UIEventHandle("layout_players/Player{0}/Icon", typeof(Button), typeof(UnityAction<int>), 1, 3)]
		private void OnClickMember(int iIndex)
		{
			if (iIndex < 0)
			{
				return;
			}
			if (this.TeamDatas == null || this.TeamDatas.Count <= 0 || iIndex >= this.TeamDatas.Count)
			{
				return;
			}
			if (this.TeamDatas[iIndex].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			TeamMenuData teamMenuData = new TeamMenuData();
			teamMenuData.index = (byte)iIndex;
			teamMenuData.memberID = this.TeamDatas[iIndex].id;
			teamMenuData.name = this.TeamDatas[iIndex].name;
			teamMenuData.occu = this.TeamDatas[iIndex].occu;
			teamMenuData.level = this.TeamDatas[iIndex].level;
			teamMenuData.Pos = default(Vector3);
			if (this.frameMgr.IsFrameOpen<TeamMemberMenuFrame>(null))
			{
				this.frameMgr.CloseFrame<TeamMemberMenuFrame>(null, false);
			}
			this.frameMgr.OpenFrame<TeamMemberMenuFrame>(FrameLayer.Middle, teamMenuData, string.Empty);
		}

		// Token: 0x06010192 RID: 65938 RVA: 0x00479FFE File Offset: 0x004783FE
		[UIEventHandle("layout_players/Player{0}/btOpenTeamMy", typeof(Button), typeof(UnityAction<int>), 1, 3)]
		private void OnOpenTeamMy(int iIndex)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010193 RID: 65939 RVA: 0x0047A012 File Offset: 0x00478412
		[UIEventHandle("MyTeam")]
		private void OnOpenMyTeam()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010194 RID: 65940 RVA: 0x0047A028 File Offset: 0x00478428
		private void OnOpenInvite()
		{
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			if (myTeam.leaderInfo.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
				if (scoreWarStatus != ScoreWarStatus.SWS_PREPARE && scoreWarStatus != ScoreWarStatus.SWS_BATTLE)
				{
					return;
				}
				Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
				if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamInvitePlayerListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
			}
		}

		// Token: 0x06010195 RID: 65941 RVA: 0x0047A0DF File Offset: 0x004784DF
		private void InitInterface()
		{
			this.UpdateInterface();
		}

		// Token: 0x06010196 RID: 65942 RVA: 0x0047A0E8 File Offset: 0x004784E8
		private void UpdateInterface()
		{
			base.GetFrame().CustomActive(false);
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				return;
			}
			base.GetFrame().CustomActive(true);
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			this.TeamDatas.Clear();
			int num = 0;
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				if (myTeam.members[i].id > 0UL)
				{
					Pk3v3CrossDataManager.TeamMember item = new Pk3v3CrossDataManager.TeamMember();
					item = myTeam.members[i];
					this.TeamDatas.Add(item);
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)myTeam.members[i].occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref this.Icons[num], tableItem2.IconPath, true);
						}
					}
					this.MemberNames[num].text = myTeam.members[i].name;
					this.Levels[num].text = string.Format("Lv.{0}", myTeam.members[i].level);
					if (tableItem != null)
					{
						this.Jobs[num].text = tableItem.Name;
					}
					int playerSeasonLevel = (int)myTeam.members[i].playerSeasonLevel;
					ETCImageLoader.LoadSprite(ref this.mainSeasonLv[i], DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(playerSeasonLevel), true);
					ETCImageLoader.LoadSprite(ref this.subSeasonLv[i], DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(playerSeasonLevel), true);
					if (myTeam.leaderInfo.id == myTeam.members[i].id)
					{
						this.LeaderMarks[num].gameObject.SetActive(true);
					}
					else
					{
						this.LeaderMarks[num].gameObject.SetActive(false);
					}
					this.Players[num].gameObject.SetActive(true);
					num++;
				}
			}
			for (int j = num; j < 3; j++)
			{
				this.Players[j].gameObject.SetActive(false);
			}
			for (int k = 0; k < 3; k++)
			{
				GameObject gameObject = this.mBind.GetGameObject(string.Format("goInvite{0}", k));
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
				}
			}
			for (int l = num; l < 3; l++)
			{
				GameObject gameObject2 = this.mBind.GetGameObject(string.Format("goInvite{0}", l));
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(true);
				}
			}
		}

		// Token: 0x06010197 RID: 65943 RVA: 0x0047A3B7 File Offset: 0x004787B7
		private void OnUpdateInterface(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x06010198 RID: 65944 RVA: 0x0047A3BF File Offset: 0x004787BF
		private void OnAddMemberSuccess(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x06010199 RID: 65945 RVA: 0x0047A3C7 File Offset: 0x004787C7
		private void OnChangeLeaderSuccess(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x0400A273 RID: 41587
		private const int MemberNum = 3;

		// Token: 0x0400A274 RID: 41588
		private List<Pk3v3CrossDataManager.TeamMember> TeamDatas = new List<Pk3v3CrossDataManager.TeamMember>();

		// Token: 0x0400A275 RID: 41589
		[UIControl("layout_players/Player{0}", typeof(Image), 1)]
		protected Image[] Players = new Image[3];

		// Token: 0x0400A276 RID: 41590
		[UIControl("layout_players/Player{0}/Icon", typeof(Image), 1)]
		protected Image[] Icons = new Image[3];

		// Token: 0x0400A277 RID: 41591
		[UIControl("layout_players/Player{0}/Name", typeof(Text), 1)]
		protected Text[] MemberNames = new Text[3];

		// Token: 0x0400A278 RID: 41592
		[UIControl("layout_players/Player{0}/Level", typeof(Text), 1)]
		protected Text[] Levels = new Text[3];

		// Token: 0x0400A279 RID: 41593
		[UIControl("layout_players/Player{0}/LeaderMark", typeof(Image), 1)]
		protected Image[] LeaderMarks = new Image[3];

		// Token: 0x0400A27A RID: 41594
		[UIControl("layout_players/Player{0}/HP/Text", typeof(Text), 1)]
		protected Text[] HPTexts = new Text[3];

		// Token: 0x0400A27B RID: 41595
		[UIControl("layout_players/Player{0}/MP/Text", typeof(Text), 1)]
		protected Text[] MPTexts = new Text[3];

		// Token: 0x0400A27C RID: 41596
		[UIControl("layout_players/Player{0}/Job", typeof(Text), 1)]
		protected Text[] Jobs = new Text[3];

		// Token: 0x0400A27D RID: 41597
		[UIControl("layout_players/Player{0}/PkGroup/Main", typeof(Image), 1)]
		protected Image[] mainSeasonLv = new Image[3];

		// Token: 0x0400A27E RID: 41598
		[UIControl("layout_players/Player{0}/PkGroup/Main/Sub", typeof(Image), 1)]
		protected Image[] subSeasonLv = new Image[3];

		// Token: 0x0400A27F RID: 41599
		[UIControl("layout_players/Invite{0}/btnInvite", typeof(Button), 0)]
		protected Button[] btnInvite = new Button[3];

		// Token: 0x0400A280 RID: 41600
		[UIControl("layout_players/Invite{0}/btnBk", typeof(Button), 0)]
		protected Button[] btnBk = new Button[3];
	}
}
