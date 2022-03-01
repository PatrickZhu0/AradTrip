using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014C4 RID: 5316
	public class ChallengeDropDetailItem : MonoBehaviour
	{
		// Token: 0x0600CE14 RID: 52756 RVA: 0x0032C49D File Offset: 0x0032A89D
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CE15 RID: 52757 RVA: 0x0032C4A5 File Offset: 0x0032A8A5
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CE16 RID: 52758 RVA: 0x0032C4B4 File Offset: 0x0032A8B4
		private void BindEvents()
		{
			if (this.dropItemList != null)
			{
				this.dropItemList.Initialize();
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
		}

		// Token: 0x0600CE17 RID: 52759 RVA: 0x0032C504 File Offset: 0x0032A904
		private void UnBindEvents()
		{
			if (this.dropItemList != null)
			{
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
		}

		// Token: 0x0600CE18 RID: 52760 RVA: 0x0032C53E File Offset: 0x0032A93E
		private void ClearData()
		{
			this._dungeonTable = null;
			this._dungeonId = 0;
			this._dropDetailItemList = null;
			this._dropDetailType = ChallengeDropDetailType.None;
		}

		// Token: 0x0600CE19 RID: 52761 RVA: 0x0032C55C File Offset: 0x0032A95C
		public void InitItem(int dungeonId, ChallengeDropDetailType dropDetailType)
		{
			this._dungeonId = dungeonId;
			this._dropDetailType = dropDetailType;
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._dungeonId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("DungeonTable is null and dungeonId is {0}", new object[]
				{
					this._dungeonId
				});
				return;
			}
			if (dropDetailType == ChallengeDropDetailType.None)
			{
				Logger.LogErrorFormat("DropDetailType is None ", new object[0]);
				return;
			}
			this.InitContent();
		}

		// Token: 0x0600CE1A RID: 52762 RVA: 0x0032C5DE File Offset: 0x0032A9DE
		private void InitContent()
		{
			this.InitDropDetailItemTitle();
			this.InitDropDetailItemList();
		}

		// Token: 0x0600CE1B RID: 52763 RVA: 0x0032C5EC File Offset: 0x0032A9EC
		private void InitDropDetailItemTitle()
		{
			string dropDetailTitleName = ChallengeUtility.GetDropDetailTitleName(this._dropDetailType);
			if (this.detailNameText != null)
			{
				this.detailNameText.text = dropDetailTitleName;
			}
		}

		// Token: 0x0600CE1C RID: 52764 RVA: 0x0032C624 File Offset: 0x0032AA24
		private void InitDropDetailItemList()
		{
			this._dropDetailItemList = this._dungeonTable.DropItems.ToList<int>();
			int elementAmount = 0;
			if (this._dropDetailItemList != null)
			{
				elementAmount = this._dropDetailItemList.Count;
			}
			if (this.dropItemList != null)
			{
				this.dropItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600CE1D RID: 52765 RVA: 0x0032C680 File Offset: 0x0032AA80
		private void OnDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._dropDetailItemList == null)
			{
				return;
			}
			if (this.dropItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dropDetailItemList.Count)
			{
				return;
			}
			int num = this._dropDetailItemList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, this._dungeonId);
			}
		}

		// Token: 0x04007852 RID: 30802
		private int _dungeonId;

		// Token: 0x04007853 RID: 30803
		private DungeonTable _dungeonTable;

		// Token: 0x04007854 RID: 30804
		private ChallengeDropDetailType _dropDetailType;

		// Token: 0x04007855 RID: 30805
		private List<int> _dropDetailItemList;

		// Token: 0x04007856 RID: 30806
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private Text detailNameText;

		// Token: 0x04007857 RID: 30807
		[SerializeField]
		private ComUIListScript dropItemList;
	}
}
