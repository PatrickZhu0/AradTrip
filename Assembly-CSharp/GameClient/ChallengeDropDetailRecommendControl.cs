using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014C5 RID: 5317
	public class ChallengeDropDetailRecommendControl : MonoBehaviour
	{
		// Token: 0x0600CE1F RID: 52767 RVA: 0x0032C71C File Offset: 0x0032AB1C
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE20 RID: 52768 RVA: 0x0032C724 File Offset: 0x0032AB24
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE21 RID: 52769 RVA: 0x0032C734 File Offset: 0x0032AB34
		private void BindEvents()
		{
			if (this.recommendDropItemList != null)
			{
				this.recommendDropItemList.Initialize();
				ComUIListScript comUIListScript = this.recommendDropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRecommendDropItemVisible));
			}
			if (this.bestDropItemList != null)
			{
				this.bestDropItemList.Initialize();
				ComUIListScript comUIListScript2 = this.bestDropItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBestDropItemVisible));
			}
		}

		// Token: 0x0600CE22 RID: 52770 RVA: 0x0032C7C8 File Offset: 0x0032ABC8
		private void UnBindEvents()
		{
			if (this.recommendDropItemList != null)
			{
				ComUIListScript comUIListScript = this.recommendDropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnRecommendDropItemVisible));
			}
			if (this.bestDropItemList != null)
			{
				ComUIListScript comUIListScript2 = this.bestDropItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnBestDropItemVisible));
			}
		}

		// Token: 0x0600CE23 RID: 52771 RVA: 0x0032C845 File Offset: 0x0032AC45
		private void ClearData()
		{
			this._activityDungeonTable = null;
			this._recommendItemIdList = null;
			this._bestItemIdList = null;
		}

		// Token: 0x0600CE24 RID: 52772 RVA: 0x0032C85C File Offset: 0x0032AC5C
		public void InitRecommendControl(ActivityDungeonTable activityDungeonTable)
		{
			this._activityDungeonTable = activityDungeonTable;
			this.InitContent();
		}

		// Token: 0x0600CE25 RID: 52773 RVA: 0x0032C86B File Offset: 0x0032AC6B
		private void InitContent()
		{
			this.InitDropDetailItemTitle();
			this.InitDropDetailItemList();
		}

		// Token: 0x0600CE26 RID: 52774 RVA: 0x0032C87C File Offset: 0x0032AC7C
		private void InitDropDetailItemTitle()
		{
			if (this.recommendDropItemText != null)
			{
				this.recommendDropItemText.text = ChallengeUtility.GetDropDetailTitleName(ChallengeDropDetailType.RecommendItem);
			}
			if (this.bestDropItemText != null)
			{
				this.bestDropItemText.text = ChallengeUtility.GetDropDetailTitleName(ChallengeDropDetailType.BestItem);
			}
			if (this.otherDropItemText != null)
			{
				this.otherDropItemText.text = ChallengeUtility.GetDropDetailTitleName(ChallengeDropDetailType.OtherDropItem);
			}
		}

		// Token: 0x0600CE27 RID: 52775 RVA: 0x0032C8F0 File Offset: 0x0032ACF0
		private void InitDropDetailItemList()
		{
			if (this._activityDungeonTable == null)
			{
				return;
			}
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			int playerBaseJobTableId = ChallengeUtility.GetPlayerBaseJobTableId();
			if (this._activityDungeonTable.DropShow1 != null)
			{
				this._recommendItemIdList = this._activityDungeonTable.DropShow1.ToList<int>();
				for (int i = this._recommendItemIdList.Count - 1; i >= 0; i--)
				{
					if (!ChallengeUtility.IsRecommendItemByProfession(this._recommendItemIdList[i], jobTableID, playerBaseJobTableId))
					{
						this._recommendItemIdList.RemoveAt(i);
					}
				}
				if (this.recommendDropItemList != null)
				{
					if (this._recommendItemIdList == null || this._recommendItemIdList.Count <= 0)
					{
						this.recommendDropItemList.SetElementAmount(0);
					}
					else if (this._recommendItemIdList.Count > 6)
					{
						this.recommendDropItemList.SetElementAmount(6);
					}
					else
					{
						this.recommendDropItemList.SetElementAmount(this._recommendItemIdList.Count);
					}
				}
			}
			if (this._activityDungeonTable.DropShow2 != null)
			{
				this._bestItemIdList = this._activityDungeonTable.DropShow2.ToList<int>();
				for (int j = this._bestItemIdList.Count - 1; j >= 0; j--)
				{
					if (!ChallengeUtility.IsRecommendItemByProfession(this._bestItemIdList[j], jobTableID, playerBaseJobTableId))
					{
						this._bestItemIdList.RemoveAt(j);
					}
				}
				if (this.bestDropItemList != null)
				{
					if (this._bestItemIdList == null || this._bestItemIdList.Count <= 0)
					{
						this.bestDropItemList.SetElementAmount(0);
					}
					else if (this._bestItemIdList.Count > 6)
					{
						this.bestDropItemList.SetElementAmount(6);
					}
					else
					{
						this.bestDropItemList.SetElementAmount(this._bestItemIdList.Count);
					}
				}
			}
		}

		// Token: 0x0600CE28 RID: 52776 RVA: 0x0032CAD8 File Offset: 0x0032AED8
		private void OnRecommendDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.recommendDropItemList == null)
			{
				return;
			}
			if (this._recommendItemIdList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._recommendItemIdList.Count)
			{
				return;
			}
			int num = this._recommendItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, 0);
			}
		}

		// Token: 0x0600CE29 RID: 52777 RVA: 0x0032CB68 File Offset: 0x0032AF68
		private void OnBestDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.bestDropItemList == null)
			{
				return;
			}
			if (this._bestItemIdList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._bestItemIdList.Count)
			{
				return;
			}
			int num = this._bestItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, 0);
			}
		}

		// Token: 0x04007858 RID: 30808
		private ActivityDungeonTable _activityDungeonTable;

		// Token: 0x04007859 RID: 30809
		private List<int> _recommendItemIdList;

		// Token: 0x0400785A RID: 30810
		private List<int> _bestItemIdList;

		// Token: 0x0400785B RID: 30811
		[Space(10f)]
		[Header("ItemListName")]
		[Space(10f)]
		[SerializeField]
		private Text recommendDropItemText;

		// Token: 0x0400785C RID: 30812
		[SerializeField]
		private Text bestDropItemText;

		// Token: 0x0400785D RID: 30813
		[SerializeField]
		private Text otherDropItemText;

		// Token: 0x0400785E RID: 30814
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScript recommendDropItemList;

		// Token: 0x0400785F RID: 30815
		[SerializeField]
		private ComUIListScript bestDropItemList;
	}
}
