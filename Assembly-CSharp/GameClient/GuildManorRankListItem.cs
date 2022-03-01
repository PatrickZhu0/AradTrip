using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001633 RID: 5683
	internal class GuildManorRankListItem : ComUIListTemplateItem
	{
		// Token: 0x0600DF49 RID: 57161 RVA: 0x0038F7F8 File Offset: 0x0038DBF8
		public static int GetTitleIDByRank(int rank)
		{
			int result = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildBattleScoreRankRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildBattleScoreRankRewardTable guildBattleScoreRankRewardTable = keyValuePair.Value as GuildBattleScoreRankRewardTable;
					if (guildBattleScoreRankRewardTable != null)
					{
						if (guildBattleScoreRankRewardTable.ID == rank)
						{
							return guildBattleScoreRankRewardTable.TitleId;
						}
						if (guildBattleScoreRankRewardTable.ID > rank)
						{
							result = guildBattleScoreRankRewardTable.TitleId;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600DF4A RID: 57162 RVA: 0x0038F880 File Offset: 0x0038DC80
		private void SetTitleIcon(int titleID)
		{
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(titleID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.imgTitle.SafeSetImage(tableItem.path, false);
		}

		// Token: 0x0600DF4B RID: 57163 RVA: 0x0038F8BC File Offset: 0x0038DCBC
		private void SetTitleInfo(int titleID)
		{
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(titleID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.Style == 1)
			{
				this.txtTitle.SafeSetText(tableItem.name);
				this.txtTitle.CustomActive(true);
				this.imgTitle.CustomActive(false);
			}
			else if (tableItem.Style == 2)
			{
				this.imgTitle.SafeSetImage(tableItem.path, false);
				if (this.imgTitle != null)
				{
					this.imgTitle.SetNativeSize();
				}
				this.txtTitle.CustomActive(false);
				this.imgTitle.CustomActive(true);
			}
		}

		// Token: 0x0600DF4C RID: 57164 RVA: 0x0038F974 File Offset: 0x0038DD74
		private void SetTitleText(int titleID)
		{
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(titleID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.txtTitle.SafeSetText(tableItem.name);
		}

		// Token: 0x0600DF4D RID: 57165 RVA: 0x0038F9B0 File Offset: 0x0038DDB0
		public override void SetUp(object data)
		{
			GuildBattleTerrScoreRank guildBattleTerrScoreRank = data as GuildBattleTerrScoreRank;
			if (guildBattleTerrScoreRank == null)
			{
				return;
			}
			this.txtRank.SafeSetText(guildBattleTerrScoreRank.ranking.ToString());
			this.guildName.SafeSetText(guildBattleTerrScoreRank.name);
			this.score.SafeSetText(guildBattleTerrScoreRank.score.ToString());
			if (string.IsNullOrEmpty(guildBattleTerrScoreRank.name))
			{
				this.guildName.SafeSetText(TR.Value("guild_battle_title_empty"));
			}
			if (guildBattleTerrScoreRank.score == 0U)
			{
				this.score.SafeSetText(TR.Value("guild_battle_title_empty"));
			}
			int titleIDByRank = GuildManorRankListItem.GetTitleIDByRank((int)guildBattleTerrScoreRank.ranking);
			this.SetTitleInfo(titleIDByRank);
			if (titleIDByRank == 0)
			{
				this.txtTitle.SafeSetText(TR.Value("guild_battle_no_title"));
				this.txtTitle.CustomActive(true);
				this.imgTitle.CustomActive(false);
			}
			if (guildBattleTerrScoreRank.ranking == 0)
			{
				this.txtRank.SafeSetText(TR.Value("guild_battle_not_in_rank"));
				this.guildName.SafeSetText(DataManager<GuildDataManager>.GetInstance().GetMyGuildName());
				this.score.SafeSetText("0");
				this.txtTitle.SafeSetText(TR.Value("guild_battle_no_title"));
				this.txtTitle.CustomActive(true);
				this.imgTitle.CustomActive(false);
			}
			Color color = this.normal;
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && guildBattleTerrScoreRank.id == DataManager<GuildDataManager>.GetInstance().myGuild.uGUID)
			{
				color = this.guildColor;
			}
			this.txtRank.SafeSetColor(color);
			this.guildName.SafeSetColor(color);
			this.score.SafeSetColor(color);
			this.txtTitle.SafeSetColor(color);
		}

		// Token: 0x04008494 RID: 33940
		[SerializeField]
		private Image imgRank;

		// Token: 0x04008495 RID: 33941
		[SerializeField]
		private Text txtRank;

		// Token: 0x04008496 RID: 33942
		[SerializeField]
		private Text guildName;

		// Token: 0x04008497 RID: 33943
		[SerializeField]
		private Text score;

		// Token: 0x04008498 RID: 33944
		[SerializeField]
		private Image imgTitle;

		// Token: 0x04008499 RID: 33945
		[SerializeField]
		private Text txtTitle;

		// Token: 0x0400849A RID: 33946
		[SerializeField]
		private Color normal;

		// Token: 0x0400849B RID: 33947
		[SerializeField]
		private Color guildColor;

		// Token: 0x0400849C RID: 33948
		private static Dictionary<GuildManorRankListItem.RankInfo, int> rank2TitleID = new Dictionary<GuildManorRankListItem.RankInfo, int>();

		// Token: 0x02001634 RID: 5684
		private class RankInfo
		{
			// Token: 0x0600DF50 RID: 57168 RVA: 0x0038FB8C File Offset: 0x0038DF8C
			public override bool Equals(object obj)
			{
				GuildManorRankListItem.RankInfo rankInfo = obj as GuildManorRankListItem.RankInfo;
				return rankInfo != null && this.min == rankInfo.min && this.max == rankInfo.max;
			}

			// Token: 0x0600DF51 RID: 57169 RVA: 0x0038FBCA File Offset: 0x0038DFCA
			public override int GetHashCode()
			{
				return this.min.GetHashCode() + this.max.GetHashCode();
			}

			// Token: 0x0400849D RID: 33949
			public int min;

			// Token: 0x0400849E RID: 33950
			public int max;
		}
	}
}
