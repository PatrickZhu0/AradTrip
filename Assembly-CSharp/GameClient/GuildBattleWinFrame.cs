using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F7 RID: 5623
	internal class GuildBattleWinFrame : ClientFrame
	{
		// Token: 0x0600DC60 RID: 56416 RVA: 0x0037A620 File Offset: 0x00378A20
		protected sealed override void _bindExUI()
		{
			this.mPlayerInfo = this.mBind.GetGameObject("PlayerInfo");
			this.mHeadIcon = this.mBind.GetCom<Image>("IconInfo");
			this.mLevelTxt = this.mBind.GetCom<Text>("Level");
			this.mNameTxt = this.mBind.GetCom<Text>("NameText");
			this.mGuildNameTxt = this.mBind.GetCom<Text>("GuildNameText");
			this.mServerNameTxt = this.mBind.GetCom<Text>("ServerNameText");
			this.mMiddleRootLayout = this.mBind.GetCom<VerticalLayoutGroup>("MiddleRoot");
		}

		// Token: 0x0600DC61 RID: 56417 RVA: 0x0037A6C7 File Offset: 0x00378AC7
		protected override void _unbindExUI()
		{
			this.mPlayerInfo = null;
			this.mHeadIcon = null;
			this.mLevelTxt = null;
			this.mNameTxt = null;
			this.mGuildNameTxt = null;
			this.mServerNameTxt = null;
			this.mMiddleRootLayout = null;
		}

		// Token: 0x0600DC62 RID: 56418 RVA: 0x0037A6FA File Offset: 0x00378AFA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattleWin";
		}

		// Token: 0x0600DC63 RID: 56419 RVA: 0x0037A701 File Offset: 0x00378B01
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DC64 RID: 56420 RVA: 0x0037A70F File Offset: 0x00378B0F
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC65 RID: 56421 RVA: 0x0037A71D File Offset: 0x00378B1D
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DC66 RID: 56422 RVA: 0x0037A71F File Offset: 0x00378B1F
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DC67 RID: 56423 RVA: 0x0037A724 File Offset: 0x00378B24
		private void _InitUI()
		{
			WorldGuildBattleRaceEnd worldGuildBattleRaceEnd = this.userData as WorldGuildBattleRaceEnd;
			if (this.m_labTotalScore != null)
			{
				this.m_labTotalScore.text = worldGuildBattleRaceEnd.newScore.ToString();
			}
			if (this.m_labDeltaScore != null)
			{
				this.m_labDeltaScore.text = (worldGuildBattleRaceEnd.newScore - worldGuildBattleRaceEnd.oldScore).ToString();
			}
			this._InitExUI();
		}

		// Token: 0x0600DC68 RID: 56424 RVA: 0x0037A7A8 File Offset: 0x00378BA8
		private void _InitExUI()
		{
			if (!DataManager<GuildDataManager>.GetInstance().CurTargetCrossManorIDIsYGWZ())
			{
				return;
			}
			if (ClientApplication.playerinfo == null)
			{
				return;
			}
			if (ClientApplication.racePlayerInfo == null)
			{
				return;
			}
			RacePlayerInfo racePlayerInfo = null;
			for (int i = 0; i < ClientApplication.racePlayerInfo.Length; i++)
			{
				if (ClientApplication.racePlayerInfo[i] != null && ClientApplication.racePlayerInfo[i].accid != ClientApplication.playerinfo.accid)
				{
					racePlayerInfo = ClientApplication.racePlayerInfo[i];
				}
			}
			if (racePlayerInfo == null)
			{
				return;
			}
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)racePlayerInfo.occupation, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.mHeadIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mHeadIcon, path, true);
			}
			if (this.mLevelTxt != null)
			{
				this.mLevelTxt.text = racePlayerInfo.level.ToString();
			}
			if (this.mNameTxt != null)
			{
				this.mNameTxt.text = racePlayerInfo.name;
			}
			if (this.mGuildNameTxt != null && !string.IsNullOrEmpty(racePlayerInfo.guildName))
			{
				this.mGuildNameTxt.text = racePlayerInfo.guildName + "公会";
			}
			if (this.mServerNameTxt != null)
			{
				this.mServerNameTxt.text = racePlayerInfo.serverName;
			}
			if (this.mPlayerInfo != null)
			{
				this.mPlayerInfo.CustomActive(true);
			}
			if (this.mMiddleRootLayout != null)
			{
				this.mMiddleRootLayout.enabled = true;
			}
		}

		// Token: 0x0600DC69 RID: 56425 RVA: 0x0037A983 File Offset: 0x00378D83
		private void _ClearUI()
		{
		}

		// Token: 0x0600DC6A RID: 56426 RVA: 0x0037A985 File Offset: 0x00378D85
		[UIEventHandle("Quit")]
		private void _OnQuitClicked()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<GuildBattleWinFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04008205 RID: 33285
		[UIControl("MiddleRoot/Score/Total", null, 0)]
		private Text m_labTotalScore;

		// Token: 0x04008206 RID: 33286
		[UIControl("MiddleRoot/Score/Delta", null, 0)]
		private Text m_labDeltaScore;

		// Token: 0x04008207 RID: 33287
		private GameObject mPlayerInfo;

		// Token: 0x04008208 RID: 33288
		private Image mHeadIcon;

		// Token: 0x04008209 RID: 33289
		private Text mLevelTxt;

		// Token: 0x0400820A RID: 33290
		private Text mNameTxt;

		// Token: 0x0400820B RID: 33291
		private Text mGuildNameTxt;

		// Token: 0x0400820C RID: 33292
		private Text mServerNameTxt;

		// Token: 0x0400820D RID: 33293
		private VerticalLayoutGroup mMiddleRootLayout;
	}
}
