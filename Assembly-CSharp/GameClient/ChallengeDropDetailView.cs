using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014C6 RID: 5318
	public class ChallengeDropDetailView : MonoBehaviour
	{
		// Token: 0x0600CE2B RID: 52779 RVA: 0x0032CBFF File Offset: 0x0032AFFF
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE2C RID: 52780 RVA: 0x0032CC07 File Offset: 0x0032B007
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE2D RID: 52781 RVA: 0x0032CC18 File Offset: 0x0032B018
		private void BindEvents()
		{
			if (this.otherDropItemList != null)
			{
				this.otherDropItemList.Initialize();
				ComUIListScript comUIListScript = this.otherDropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnOtherDropItemVisible));
			}
		}

		// Token: 0x0600CE2E RID: 52782 RVA: 0x0032CC68 File Offset: 0x0032B068
		private void UnBindEvents()
		{
			if (this.otherDropItemList != null)
			{
				ComUIListScript comUIListScript = this.otherDropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnOtherDropItemVisible));
			}
		}

		// Token: 0x0600CE2F RID: 52783 RVA: 0x0032CCA2 File Offset: 0x0032B0A2
		private void ClearData()
		{
			this._baseDungeonId = 0;
			this._activityDungeonTable = null;
			this._otherDropItemIdList = null;
		}

		// Token: 0x0600CE30 RID: 52784 RVA: 0x0032CCBC File Offset: 0x0032B0BC
		public void InitView(int dungeonId)
		{
			this._baseDungeonId = dungeonId;
			this._activityDungeonTable = ChallengeUtility.GetActivityDungeonTableByDungeonId(this._baseDungeonId);
			if (this._activityDungeonTable == null)
			{
				Logger.LogErrorFormat("ActivityDungeonTable is null", new object[0]);
				return;
			}
			if (this.recommendControl != null)
			{
				this.recommendControl.InitRecommendControl(this._activityDungeonTable);
			}
			this._otherDropItemIdList = this._activityDungeonTable.DropShow3.ToList<int>();
			if (this.otherDropItemList != null)
			{
				if (this._otherDropItemIdList == null || this._otherDropItemIdList.Count <= 0)
				{
					this.otherDropItemList.SetElementAmount(0);
				}
				else
				{
					this.otherDropItemList.SetElementAmount(this._otherDropItemIdList.Count);
				}
			}
		}

		// Token: 0x0600CE31 RID: 52785 RVA: 0x0032CD8C File Offset: 0x0032B18C
		private void OnOtherDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._otherDropItemIdList == null)
			{
				return;
			}
			if (this.otherDropItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._otherDropItemIdList.Count)
			{
				return;
			}
			int num = this._otherDropItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, 0);
			}
		}

		// Token: 0x04007860 RID: 30816
		private int _baseDungeonId;

		// Token: 0x04007861 RID: 30817
		private ActivityDungeonTable _activityDungeonTable;

		// Token: 0x04007862 RID: 30818
		private List<int> _otherDropItemIdList;

		// Token: 0x04007863 RID: 30819
		[SerializeField]
		private ChallengeDropDetailRecommendControl recommendControl;

		// Token: 0x04007864 RID: 30820
		[Space(10f)]
		[Header("OtherDropItem")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScript otherDropItemList;
	}
}
