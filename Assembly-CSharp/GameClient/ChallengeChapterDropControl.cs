using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014B4 RID: 5300
	public class ChallengeChapterDropControl : MonoBehaviour
	{
		// Token: 0x0600CD7A RID: 52602 RVA: 0x00328C95 File Offset: 0x00327095
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CD7B RID: 52603 RVA: 0x00328C9D File Offset: 0x0032709D
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CD7C RID: 52604 RVA: 0x00328CAC File Offset: 0x003270AC
		private void BindEvents()
		{
			if (this.dropItemList != null)
			{
				this.dropItemList.Initialize();
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
			if (this.dropDetailButton != null)
			{
				this.dropDetailButton.onClick.RemoveAllListeners();
				this.dropDetailButton.onClick.AddListener(new UnityAction(this.OnDropDetailButton));
			}
		}

		// Token: 0x0600CD7D RID: 52605 RVA: 0x00328D3C File Offset: 0x0032713C
		private void UnBindEvents()
		{
			if (this.dropItemList != null)
			{
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
			if (this.dropDetailButton != null)
			{
				this.dropDetailButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CD7E RID: 52606 RVA: 0x00328DA2 File Offset: 0x003271A2
		private void ClearData()
		{
			this._chapterId = 0;
			this._mapItemId = 0;
			this._dropItemIdList = null;
		}

		// Token: 0x0600CD7F RID: 52607 RVA: 0x00328DBC File Offset: 0x003271BC
		public void InitDropControl(int chapterId, int mapItemId)
		{
			this._chapterId = chapterId;
			this._mapItemId = mapItemId;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._chapterId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DungeonTable is null and chapter id is {0}", new object[]
				{
					this._chapterId
				});
				return;
			}
			if (tableItem.DropItems == null || tableItem.DropItems.Count <= 0)
			{
				if (this.dropItemList != null)
				{
					this.dropItemList.SetElementAmount(0);
				}
				return;
			}
			this._dropItemIdList = tableItem.DropItems.ToList<int>();
			if (this.dropItemList != null)
			{
				this.dropItemList.SetElementAmount(this._dropItemIdList.Count);
			}
			if (this.specialDropTitleLabel != null)
			{
				if (DungeonUtility.IsWeekHellEntryDungeon(this._chapterId) || DungeonUtility.IsWeekHellPreDungeon(this._chapterId))
				{
					this.specialDropTitleLabel.text = TR.Value("challenge_chapter_week_activity_drop");
					this.specialDropTitleLabel.gameObject.CustomActive(true);
				}
				else
				{
					this.specialDropTitleLabel.gameObject.CustomActive(false);
				}
			}
			this.UpdateDropDetailButton();
		}

		// Token: 0x0600CD80 RID: 52608 RVA: 0x00328EFC File Offset: 0x003272FC
		private void UpdateDropDetailButton()
		{
			if (this.dropDetailButton != null)
			{
				if (DungeonUtility.IsWeekHellPreDungeon(this._chapterId))
				{
					this.dropDetailButton.gameObject.CustomActive(false);
				}
				else
				{
					this.dropDetailButton.gameObject.CustomActive(true);
				}
			}
		}

		// Token: 0x0600CD81 RID: 52609 RVA: 0x00328F54 File Offset: 0x00327354
		private void OnDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._dropItemIdList == null)
			{
				return;
			}
			if (this.dropItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dropItemIdList.Count)
			{
				return;
			}
			int num = this._dropItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, this._chapterId);
			}
		}

		// Token: 0x0600CD82 RID: 52610 RVA: 0x00328FE8 File Offset: 0x003273E8
		private void OnDropDetailButton()
		{
			ChallengeUtility.OnOpenChallengeDropDetailFrame(this._mapItemId);
		}

		// Token: 0x040077D9 RID: 30681
		private int _chapterId;

		// Token: 0x040077DA RID: 30682
		private int _mapItemId;

		// Token: 0x040077DB RID: 30683
		private List<int> _dropItemIdList;

		// Token: 0x040077DC RID: 30684
		[SerializeField]
		private ComUIListScript dropItemList;

		// Token: 0x040077DD RID: 30685
		[SerializeField]
		private Button dropDetailButton;

		// Token: 0x040077DE RID: 30686
		[SerializeField]
		private Text specialDropTitleLabel;
	}
}
