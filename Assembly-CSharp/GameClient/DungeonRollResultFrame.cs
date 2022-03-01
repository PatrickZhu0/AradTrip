using System;
using System.Collections.Generic;
using Scripts.UI;

namespace GameClient
{
	// Token: 0x020010BA RID: 4282
	public class DungeonRollResultFrame : ClientFrame
	{
		// Token: 0x0600A1AB RID: 41387 RVA: 0x0020E93D File Offset: 0x0020CD3D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Reward/RollItemResultFrame";
		}

		// Token: 0x0600A1AC RID: 41388 RVA: 0x0020E944 File Offset: 0x0020CD44
		protected override void _bindExUI()
		{
			this.mRollItems = this.mBind.GetCom<ComUIListScript>("RollItemList");
		}

		// Token: 0x0600A1AD RID: 41389 RVA: 0x0020E95C File Offset: 0x0020CD5C
		protected override void _unbindExUI()
		{
			this.mRollItems = null;
		}

		// Token: 0x0600A1AE RID: 41390 RVA: 0x0020E965 File Offset: 0x0020CD65
		protected override void _OnCloseFrame()
		{
			if (DataManager<ItemTipManager>.GetInstance() != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600A1AF RID: 41391 RVA: 0x0020E97C File Offset: 0x0020CD7C
		private int SortItemData(BattleDataManager.ResultRollItem a, BattleDataManager.ResultRollItem b)
		{
			if (a == null || b == null || a.item == null || b.item == null)
			{
				return 0;
			}
			if (a.item.Quality > b.item.Quality)
			{
				return 1;
			}
			if (a.item.Quality != b.item.Quality)
			{
				return -1;
			}
			if (a.item.TableID < b.item.TableID)
			{
				return 1;
			}
			if (a.item.TableID > b.item.TableID)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600A1B0 RID: 41392 RVA: 0x0020EA24 File Offset: 0x0020CE24
		protected override void _OnOpenFrame()
		{
			List<BattleDataManager.ResultRollItem> list = this.userData as List<BattleDataManager.ResultRollItem>;
			if (list == null)
			{
				return;
			}
			this.mResultItemList = new List<BattleDataManager.ResultRollItem>();
			for (int i = 0; i < list.Count; i++)
			{
				BattleDataManager.ResultRollItem resultRollItem = list[i];
				if (resultRollItem != null)
				{
					BattleDataManager.ResultRollItem resultRollItem2 = new BattleDataManager.ResultRollItem
					{
						itemData = resultRollItem.itemData,
						item = resultRollItem.item
					};
					this.mResultItemList.Add(resultRollItem2);
					bool flag = true;
					for (int j = 0; j < resultRollItem.playerInfoes.Count; j++)
					{
						if (resultRollItem.playerInfoes[j].opType != 2)
						{
							flag = false;
							resultRollItem2.playerInfoes.Add(resultRollItem.playerInfoes[j]);
						}
					}
					if (flag)
					{
						resultRollItem2.playerInfoes.AddRange(resultRollItem.playerInfoes);
					}
				}
			}
			if (this.mResultItemList != null)
			{
				this.mResultItemList.Sort(new Comparison<BattleDataManager.ResultRollItem>(this.SortItemData));
			}
			this._InitUI();
		}

		// Token: 0x0600A1B1 RID: 41393 RVA: 0x0020EB40 File Offset: 0x0020CF40
		private void OnItemData(ComUIListElementScript item)
		{
			if (this.mResultItemList == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mResultItemList.Count)
			{
				ComRollItemResult component = item.GetComponent<ComRollItemResult>();
				if (component != null)
				{
					BattleDataManager.ResultRollItem resultRollItem = this.mResultItemList[this.mResultItemList.Count - item.m_index - 1];
					if (resultRollItem == null)
					{
						return;
					}
					component.Init(resultRollItem.item, resultRollItem.playerInfoes);
				}
			}
		}

		// Token: 0x0600A1B2 RID: 41394 RVA: 0x0020EBC8 File Offset: 0x0020CFC8
		private void _InitUI()
		{
			if (this.mRollItems == null)
			{
				return;
			}
			this.mRollItems.Initialize();
			this.mRollItems.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this.OnItemData);
			this.mRollItems.SetElementAmount(this.mResultItemList.Count);
		}

		// Token: 0x04005A2F RID: 23087
		private ComUIListScript mRollItems;

		// Token: 0x04005A30 RID: 23088
		private List<BattleDataManager.ResultRollItem> mResultItemList;
	}
}
