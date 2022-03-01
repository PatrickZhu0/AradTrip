using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020011F9 RID: 4601
	public class ChallengeDataManager : DataManager<ChallengeDataManager>
	{
		// Token: 0x0600B142 RID: 45378 RVA: 0x00272A5D File Offset: 0x00270E5D
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600B143 RID: 45379 RVA: 0x00272A65 File Offset: 0x00270E65
		private void BindNetEvents()
		{
		}

		// Token: 0x0600B144 RID: 45380 RVA: 0x00272A67 File Offset: 0x00270E67
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
		}

		// Token: 0x0600B145 RID: 45381 RVA: 0x00272A75 File Offset: 0x00270E75
		private void UnBindNetEvents()
		{
		}

		// Token: 0x0600B146 RID: 45382 RVA: 0x00272A77 File Offset: 0x00270E77
		public void ClearData()
		{
			this._dropDetailTypeList = null;
			this._challengeDungeonRewardDataModelList = null;
		}

		// Token: 0x0600B147 RID: 45383 RVA: 0x00272A88 File Offset: 0x00270E88
		public ChallengeDungeonRewardDataModel GetChallengeDungeonRewardDataByDungeonId(int dungeonId)
		{
			if (this._challengeDungeonRewardDataModelList == null || this._challengeDungeonRewardDataModelList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < this._challengeDungeonRewardDataModelList.Count; i++)
			{
				ChallengeDungeonRewardDataModel challengeDungeonRewardDataModel = this._challengeDungeonRewardDataModelList[i];
				if (challengeDungeonRewardDataModel != null && challengeDungeonRewardDataModel.DungeonId == dungeonId)
				{
					return challengeDungeonRewardDataModel;
				}
			}
			return null;
		}

		// Token: 0x0600B148 RID: 45384 RVA: 0x00272AF4 File Offset: 0x00270EF4
		public List<ChallengeDropDetailType> GetDropDetailTypeList()
		{
			if (this._dropDetailTypeList == null)
			{
				this._dropDetailTypeList = new List<ChallengeDropDetailType>
				{
					ChallengeDropDetailType.RecommendItem,
					ChallengeDropDetailType.BestItem,
					ChallengeDropDetailType.OtherDropItem
				};
			}
			return this._dropDetailTypeList;
		}

		// Token: 0x0400631B RID: 25371
		public int BindDeepTicket = 200000002;

		// Token: 0x0400631C RID: 25372
		public int DeepTicket = 200000004;

		// Token: 0x0400631D RID: 25373
		public int BindAncientTicket = 200000001;

		// Token: 0x0400631E RID: 25374
		public int AncientTicket = 200000003;

		// Token: 0x0400631F RID: 25375
		public int BindTeamTicket = 330000203;

		// Token: 0x04006320 RID: 25376
		public int TeamTicket = 330000202;

		// Token: 0x04006321 RID: 25377
		public readonly int DeepMapId = 6028;

		// Token: 0x04006322 RID: 25378
		public readonly int AncientMapId = 6029;

		// Token: 0x04006323 RID: 25379
		public readonly int ChallengeOpenLevel = 30;

		// Token: 0x04006324 RID: 25380
		public readonly int ChallengeChapterHelpId = 10000;

		// Token: 0x04006325 RID: 25381
		public readonly int ChallengeWeekHellEntryDungeonId = 800000;

		// Token: 0x04006326 RID: 25382
		private List<ChallengeDropDetailType> _dropDetailTypeList;

		// Token: 0x04006327 RID: 25383
		private List<ChallengeDungeonRewardDataModel> _challengeDungeonRewardDataModelList;
	}
}
