using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02000256 RID: 598
public class ItemSearchEngine : Singleton<ItemSearchEngine>
{
	// Token: 0x06001376 RID: 4982 RVA: 0x000688CC File Offset: 0x00066CCC
	public sealed override void Init()
	{
		this.itemSearchCache = (Singleton<AssetLoader>.instance.LoadRes("Data/CommonData/ItemSearchEngine", typeof(ItemSearchCache), false, 0U).obj as ItemSearchCache);
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x000688FC File Offset: 0x00066CFC
	public List<ItemTable> FindItemListByName(string name)
	{
		List<int> list = new List<int>();
		char[] array = name.ToCharArray();
		ItemSearchEngine.ItemSearchComparser comparer = new ItemSearchEngine.ItemSearchComparser();
		List<ItemSearchItem> itemCaches = this.itemSearchCache.itemCaches;
		foreach (char key in array)
		{
			ItemSearchItem item = new ItemSearchItem
			{
				key = key
			};
			int num = itemCaches.BinarySearch(item, comparer);
			if (num >= 0 && num < itemCaches.Count)
			{
				List<int> tableList = itemCaches[num].tableList;
				if (list.Count == 0)
				{
					list = tableList.ToList<int>();
				}
				else
				{
					this._CountIntersection(ref list, tableList);
				}
			}
		}
		List<ItemTable> list2 = new List<ItemTable>();
		Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ItemTable>();
		for (int j = 0; j < list.Count; j++)
		{
			int key2 = list[j];
			object obj = null;
			if (table.TryGetValue(key2, out obj))
			{
				ItemTable itemTable = obj as ItemTable;
				if (itemTable != null)
				{
					list2.Add(itemTable);
				}
			}
		}
		return list2;
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x00068A16 File Offset: 0x00066E16
	private void _CountIntersection(ref List<int> a, List<int> b)
	{
		if (a == null || b == null)
		{
			return;
		}
		a = a.Intersect(b).ToList<int>();
	}

	// Token: 0x04000D3C RID: 3388
	private const string ItemSearchPath = "Data/CommonData/ItemSearchEngine";

	// Token: 0x04000D3D RID: 3389
	private ItemSearchCache itemSearchCache;

	// Token: 0x02000257 RID: 599
	public class ItemSearchComparser : IComparer<ItemSearchItem>
	{
		// Token: 0x0600137A RID: 4986 RVA: 0x00068A3D File Offset: 0x00066E3D
		public int Compare(ItemSearchItem a, ItemSearchItem b)
		{
			if (a.key == b.key)
			{
				return 0;
			}
			if (a.key > b.key)
			{
				return 1;
			}
			return -1;
		}
	}
}
