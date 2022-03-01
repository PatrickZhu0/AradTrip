using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F2 RID: 5618
	internal class GuildBattleLoseFrame : ClientFrame
	{
		// Token: 0x0600DC1A RID: 56346 RVA: 0x003792CC File Offset: 0x003776CC
		protected sealed override void _bindExUI()
		{
			this.mPlayerInfo = this.mBind.GetGameObject("PlayerInfo");
			this.mHeadIcon = this.mBind.GetCom<Image>("IconInfo");
			this.mLevelTxt = this.mBind.GetCom<Text>("Level");
			this.mNameTxt = this.mBind.GetCom<Text>("NameText");
			this.mGuildNameTxt = this.mBind.GetCom<Text>("GuildNameText");
			this.mServerNameTxt = this.mBind.GetCom<Text>("ServerNameText");
		}

		// Token: 0x0600DC1B RID: 56347 RVA: 0x0037935D File Offset: 0x0037775D
		protected override void _unbindExUI()
		{
			this.mPlayerInfo = null;
			this.mHeadIcon = null;
			this.mLevelTxt = null;
			this.mNameTxt = null;
			this.mGuildNameTxt = null;
			this.mServerNameTxt = null;
		}

		// Token: 0x0600DC1C RID: 56348 RVA: 0x00379389 File Offset: 0x00377789
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattleLose";
		}

		// Token: 0x0600DC1D RID: 56349 RVA: 0x00379390 File Offset: 0x00377790
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DC1E RID: 56350 RVA: 0x0037939E File Offset: 0x0037779E
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC1F RID: 56351 RVA: 0x003793AC File Offset: 0x003777AC
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DC20 RID: 56352 RVA: 0x003793AE File Offset: 0x003777AE
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DC21 RID: 56353 RVA: 0x003793B0 File Offset: 0x003777B0
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
			if (worldGuildBattleRaceEnd.result == 2)
			{
				this.m_labTitle.text = TR.Value("guild_battle_lose");
				this.m_objTie.SetActive(false);
			}
			else if (worldGuildBattleRaceEnd.result == 4)
			{
				this.m_labTitle.text = TR.Value("guild_battle_lose");
				this.m_objTie.SetActive(true);
			}
			else
			{
				this.m_labTitle.text = TR.Value("guild_battle_result_error");
				this.m_objTie.SetActive(false);
			}
			this._InitExUI();
		}

		// Token: 0x0600DC22 RID: 56354 RVA: 0x003794B8 File Offset: 0x003778B8
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
		}

		// Token: 0x0600DC23 RID: 56355 RVA: 0x00379676 File Offset: 0x00377A76
		private void _ClearUI()
		{
		}

		// Token: 0x0600DC24 RID: 56356 RVA: 0x00379678 File Offset: 0x00377A78
		[UIEventHandle("Quit")]
		private void _OnQuitClicked()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<GuildBattleLoseFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x040081E5 RID: 33253
		[UIControl("MiddleRoot/Score/Total", null, 0)]
		private Text m_labTotalScore;

		// Token: 0x040081E6 RID: 33254
		[UIControl("MiddleRoot/Score/Delta", null, 0)]
		private Text m_labDeltaScore;

		// Token: 0x040081E7 RID: 33255
		[UIControl("Title/BG/Text", null, 0)]
		private Text m_labTitle;

		// Token: 0x040081E8 RID: 33256
		[UIObject("Tie")]
		private GameObject m_objTie;

		// Token: 0x040081E9 RID: 33257
		private GameObject mPlayerInfo;

		// Token: 0x040081EA RID: 33258
		private Image mHeadIcon;

		// Token: 0x040081EB RID: 33259
		private Text mLevelTxt;

		// Token: 0x040081EC RID: 33260
		private Text mNameTxt;

		// Token: 0x040081ED RID: 33261
		private Text mGuildNameTxt;

		// Token: 0x040081EE RID: 33262
		private Text mServerNameTxt;
	}
}
