using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014BC RID: 5308
	public class ChallengeChapterMoneyControl : MonoBehaviour
	{
		// Token: 0x0600CDD4 RID: 52692 RVA: 0x0032B4C1 File Offset: 0x003298C1
		private void Awake()
		{
		}

		// Token: 0x0600CDD5 RID: 52693 RVA: 0x0032B4C3 File Offset: 0x003298C3
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CDD6 RID: 52694 RVA: 0x0032B4CB File Offset: 0x003298CB
		private void ClearData()
		{
			this._dungeonTable = null;
		}

		// Token: 0x0600CDD7 RID: 52695 RVA: 0x0032B4D4 File Offset: 0x003298D4
		public void InitMoneyControl(DungeonTable dungeonTable)
		{
			this._dungeonTable = dungeonTable;
			if (this._dungeonTable == null)
			{
				return;
			}
			this.InitChapterMoney();
		}

		// Token: 0x0600CDD8 RID: 52696 RVA: 0x0032B4F0 File Offset: 0x003298F0
		private void InitChapterMoney()
		{
			DungeonTable.eSubType subType = this._dungeonTable.SubType;
			switch (subType)
			{
			case DungeonTable.eSubType.S_LIMIT_TIME_HELL:
				break;
			case DungeonTable.eSubType.S_WEEK_HELL:
			case DungeonTable.eSubType.S_WEEK_HELL_ENTRY:
				this.SetWeekHellMoneyInfo();
				return;
			default:
				switch (subType)
				{
				case DungeonTable.eSubType.S_HELL:
				case DungeonTable.eSubType.S_HELL_ENTRY:
					break;
				default:
					if (subType == DungeonTable.eSubType.S_YUANGU)
					{
						this.SetMoneyInfo(DataManager<ChallengeDataManager>.GetInstance().BindAncientTicket, DataManager<ChallengeDataManager>.GetInstance().AncientTicket);
						return;
					}
					if (subType != DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
					{
						return;
					}
					break;
				}
				break;
			case DungeonTable.eSubType.S_WEEK_HELL_PER:
				this.SetMoneyInfo(0, 0);
				return;
			}
			this.SetMoneyInfo(DataManager<ChallengeDataManager>.GetInstance().BindDeepTicket, DataManager<ChallengeDataManager>.GetInstance().DeepTicket);
		}

		// Token: 0x0600CDD9 RID: 52697 RVA: 0x0032B5A4 File Offset: 0x003299A4
		private void SetMoneyInfo(int bindTicketId, int ticketId)
		{
			if (this.bindTicketConsume != null)
			{
				if (bindTicketId <= 0)
				{
					this.bindTicketConsume.gameObject.CustomActive(false);
				}
				else
				{
					this.bindTicketConsume.gameObject.CustomActive(true);
					this.bindTicketConsume.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, bindTicketId);
				}
			}
			if (this.ticketConsume != null)
			{
				if (ticketId <= 0)
				{
					this.ticketConsume.gameObject.CustomActive(false);
				}
				else
				{
					this.ticketConsume.gameObject.CustomActive(true);
					this.ticketConsume.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, ticketId);
				}
			}
		}

		// Token: 0x0600CDDA RID: 52698 RVA: 0x0032B64C File Offset: 0x00329A4C
		private void SetWeekHellMoneyInfo()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(DataManager<ChallengeDataManager>.GetInstance().BindTeamTicket, false);
			if (ownedItemCount <= 0)
			{
				this.SetMoneyInfo(0, DataManager<ChallengeDataManager>.GetInstance().TeamTicket);
			}
			else
			{
				this.SetMoneyInfo(DataManager<ChallengeDataManager>.GetInstance().BindTeamTicket, DataManager<ChallengeDataManager>.GetInstance().TeamTicket);
			}
		}

		// Token: 0x04007829 RID: 30761
		private DungeonTable _dungeonTable;

		// Token: 0x0400782A RID: 30762
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private ComCommonConsume bindTicketConsume;

		// Token: 0x0400782B RID: 30763
		[SerializeField]
		private ComCommonConsume ticketConsume;
	}
}
