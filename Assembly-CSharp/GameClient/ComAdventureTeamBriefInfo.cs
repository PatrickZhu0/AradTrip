using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001429 RID: 5161
	public class ComAdventureTeamBriefInfo : MonoBehaviour
	{
		// Token: 0x0600C833 RID: 51251 RVA: 0x00308D81 File Offset: 0x00307181
		private void Awake()
		{
			this._InitTR();
		}

		// Token: 0x0600C834 RID: 51252 RVA: 0x00308D89 File Offset: 0x00307189
		private void OnDestroy()
		{
			this._ClearView();
		}

		// Token: 0x0600C835 RID: 51253 RVA: 0x00308D91 File Offset: 0x00307191
		private void _InitTR()
		{
			this.tr_adventure_team_nameinfo = TR.Value("adventure_team_role_select_nameinfo");
		}

		// Token: 0x0600C836 RID: 51254 RVA: 0x00308DA3 File Offset: 0x003071A3
		private void _SetName(string name)
		{
			if (this.mNameText)
			{
				this.mNameText.text = string.Format(this.tr_adventure_team_nameinfo, name);
			}
		}

		// Token: 0x0600C837 RID: 51255 RVA: 0x00308DCC File Offset: 0x003071CC
		private void _SetLevel(int level)
		{
			if (this.mLevelText)
			{
				this.mLevelText.SetNum(level);
			}
		}

		// Token: 0x0600C838 RID: 51256 RVA: 0x00308DEA File Offset: 0x003071EA
		private void _ClearView()
		{
			this.tr_adventure_team_nameinfo = string.Empty;
		}

		// Token: 0x0600C839 RID: 51257 RVA: 0x00308DF7 File Offset: 0x003071F7
		public void RefreshView()
		{
			this._SetName(DataManager<AdventureTeamDataManager>.GetInstance().GetColorAdventureTeamName());
			this._SetLevel(DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamLevel());
		}

		// Token: 0x0400734D RID: 29517
		private string tr_adventure_team_nameinfo = string.Empty;

		// Token: 0x0400734E RID: 29518
		[SerializeField]
		private ComArtLettering mLevelText;

		// Token: 0x0400734F RID: 29519
		[SerializeField]
		private Text mNameText;
	}
}
