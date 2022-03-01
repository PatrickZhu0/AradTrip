using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001609 RID: 5641
	public class GuildDungeonAuctionAwardShowFrame : ClientFrame
	{
		// Token: 0x0600DD03 RID: 56579 RVA: 0x0037EF77 File Offset: 0x0037D377
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonAuctionAwardShow";
		}

		// Token: 0x0600DD04 RID: 56580 RVA: 0x0037EF7E File Offset: 0x0037D37E
		protected override void _OnOpenFrame()
		{
			this.awardItemDataList = null;
			this.InitAwardItems();
			this.UpdateAwardItems();
			this.BindUIEvent();
		}

		// Token: 0x0600DD05 RID: 56581 RVA: 0x0037EF99 File Offset: 0x0037D399
		protected override void _OnCloseFrame()
		{
			this.awardItemDataList = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DD06 RID: 56582 RVA: 0x0037EFA8 File Offset: 0x0037D3A8
		protected override void _bindExUI()
		{
			this.awardItems = this.mBind.GetCom<ComUIListScript>("awardItems");
		}

		// Token: 0x0600DD07 RID: 56583 RVA: 0x0037EFC0 File Offset: 0x0037D3C0
		protected override void _unbindExUI()
		{
			this.awardItems = null;
		}

		// Token: 0x0600DD08 RID: 56584 RVA: 0x0037EFC9 File Offset: 0x0037D3C9
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DD09 RID: 56585 RVA: 0x0037EFCB File Offset: 0x0037D3CB
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600DD0A RID: 56586 RVA: 0x0037EFD0 File Offset: 0x0037D3D0
		private void InitAwardItems()
		{
			if (this.awardItems == null)
			{
				return;
			}
			this.awardItems.Initialize();
			this.awardItems.onBindItem = delegate(GameObject go)
			{
				PayRewardItem result = null;
				if (go)
				{
					result = go.GetComponent<PayRewardItem>();
				}
				return result;
			};
			this.awardItems.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && this.awardItemDataList != null && index < this.awardItemDataList.Count)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.awardItemDataList[index].ID, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("GuildDungeonAuctionAwardShowFrame Can not find item id in item table!!! Please Check item data id {0} !!!", new object[]
						{
							this.awardItemDataList[index].ID
						});
						return;
					}
					itemData.Count = this.awardItemDataList[index].Num;
					PayRewardItem payRewardItem = var1.gameObjectBindScript as PayRewardItem;
					if (payRewardItem != null)
					{
						payRewardItem.Initialize(this, itemData, true, false);
						payRewardItem.RefreshView(true, true);
					}
				}
			};
		}

		// Token: 0x0600DD0B RID: 56587 RVA: 0x0037F03C File Offset: 0x0037D43C
		private void CalAwardItemList()
		{
			this.awardItemDataList = new List<AwardItemData>();
			if (this.awardItemDataList == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildDungeonRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildDungeonRewardTable guildDungeonRewardTable = keyValuePair.Value as GuildDungeonRewardTable;
					if (guildDungeonRewardTable != null)
					{
						if (guildDungeonRewardTable.rewardType == 14)
						{
							for (int i = 0; i < guildDungeonRewardTable.rewardShowLength; i++)
							{
								string text = guildDungeonRewardTable.rewardShowArray(i);
								string[] array = text.Split(new char[]
								{
									'_'
								});
								if (array.Length >= 2)
								{
									AwardItemData awardItemData = new AwardItemData();
									int.TryParse(array[0], out awardItemData.ID);
									int.TryParse(array[1], out awardItemData.Num);
									this.awardItemDataList.Add(awardItemData);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600DD0C RID: 56588 RVA: 0x0037F134 File Offset: 0x0037D534
		private void UpdateAwardItems()
		{
			if (this.awardItems == null)
			{
				return;
			}
			this.CalAwardItemList();
			if (this.awardItemDataList != null)
			{
				this.awardItems.SetElementAmount(this.awardItemDataList.Count);
			}
		}

		// Token: 0x0400828F RID: 33423
		private List<AwardItemData> awardItemDataList;

		// Token: 0x04008290 RID: 33424
		private ComUIListScript awardItems;
	}
}
