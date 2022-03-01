using System;
using System.Collections;

namespace GameClient
{
	// Token: 0x0200129A RID: 4762
	public class ItemSourceInfoTableManager : DataManager<ItemSourceInfoTableManager>
	{
		// Token: 0x0600B745 RID: 46917 RVA: 0x0029CF91 File Offset: 0x0029B391
		public override void Clear()
		{
			this.mItemSourceInfoTable = null;
		}

		// Token: 0x0600B746 RID: 46918 RVA: 0x0029CF9C File Offset: 0x0029B39C
		public override void Initialize()
		{
			this.mItemSourceInfoTable = (Singleton<AssetLoader>.instance.LoadRes(ItemSourceInfoTableManager.kItemSourceInfoTablePath, typeof(ItemSourceInfoTable), true, 0U).obj as ItemSourceInfoTable);
			if (null == this.mItemSourceInfoTable)
			{
				Logger.LogErrorFormat("[itemsourceinfotable] 加载 {0} 失败", new object[]
				{
					ItemSourceInfoTableManager.kItemSourceInfoTablePath
				});
				return;
			}
		}

		// Token: 0x0600B747 RID: 46919 RVA: 0x0029CFFE File Offset: 0x0029B3FE
		public string GetSourceInfoName(ISourceInfo info)
		{
			return ItemSourceInfoUtility.GetLinkName(this.mItemSourceInfoTable, info);
		}

		// Token: 0x0600B748 RID: 46920 RVA: 0x0029D00C File Offset: 0x0029B40C
		public string GetSourceInfoLink(ISourceInfo info)
		{
			return ItemSourceInfoUtility.GetLinkInfo(this.mItemSourceInfoTable, info);
		}

		// Token: 0x0600B749 RID: 46921 RVA: 0x0029D01C File Offset: 0x0029B41C
		public int GetItemBaseScore(int itemId)
		{
			if (null == this.mItemSourceInfoTable || this.mItemSourceInfoTable.scores == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mItemSourceInfoTable.scores.Length; i++)
			{
				if (this.mItemSourceInfoTable.scores[i].itemID == itemId)
				{
					return this.mItemSourceInfoTable.scores[i].score;
				}
			}
			return 0;
		}

		// Token: 0x0600B74A RID: 46922 RVA: 0x0029D098 File Offset: 0x0029B498
		public bool IsContainSourceInfoExceptAuction(int itemId)
		{
			if (null == this.mItemSourceInfoTable)
			{
				return false;
			}
			SourceInfo[] array = null;
			for (int i = 0; i < this.mItemSourceInfoTable.sources.Length; i++)
			{
				if (this.mItemSourceInfoTable.sources[i].itemID == itemId)
				{
					array = this.mItemSourceInfoTable.sources[i].sources;
					break;
				}
			}
			return array != null && array.Length != 0 && (array.Length != 1 || array[0].type != eItemSourceType.eAuction);
		}

		// Token: 0x0600B74B RID: 46923 RVA: 0x0029D138 File Offset: 0x0029B538
		public IEnumerator GetSourceInfos(int itemId)
		{
			if (null == this.mItemSourceInfoTable)
			{
				yield break;
			}
			SourceInfo[] allSourceInfos = null;
			for (int j = 0; j < this.mItemSourceInfoTable.sources.Length; j++)
			{
				if (this.mItemSourceInfoTable.sources[j].itemID == itemId)
				{
					allSourceInfos = this.mItemSourceInfoTable.sources[j].sources;
					break;
				}
			}
			if (allSourceInfos == null)
			{
				yield break;
			}
			bool hasGotDungeon = false;
			int i = 0;
			while (i < allSourceInfos.Length)
			{
				if (allSourceInfos[i].type != eItemSourceType.eDungeon)
				{
					goto IL_102;
				}
				if (!hasGotDungeon)
				{
					hasGotDungeon = true;
					goto IL_102;
				}
				IL_129:
				i++;
				continue;
				IL_102:
				yield return allSourceInfos[i];
				goto IL_129;
			}
			yield break;
		}

		// Token: 0x0600B74C RID: 46924 RVA: 0x0029D15C File Offset: 0x0029B55C
		private SourceInfo[] _binarySearch(int itemId)
		{
			int i = 0;
			int num = this.mItemSourceInfoTable.sources.Length - 1;
			while (i < num)
			{
				int num2 = (i + num) / 2;
				int itemID = this.mItemSourceInfoTable.sources[num2].itemID;
				if (itemID == itemId)
				{
					break;
				}
				if (itemID > itemId)
				{
					num = itemID - 1;
				}
				else
				{
					i = itemID + 1;
				}
			}
			return null;
		}

		// Token: 0x04006769 RID: 26473
		public static string kItemSourceInfoTablePath = "Data/ItemSourceInfoTable/ItemSourceInfoTable.asset";

		// Token: 0x0400676A RID: 26474
		private ItemSourceInfoTable mItemSourceInfoTable;
	}
}
