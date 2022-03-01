using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

// Token: 0x02000E4B RID: 3659
public class LoadingResourceManager
{
	// Token: 0x170018ED RID: 6381
	// (get) Token: 0x060091A6 RID: 37286 RVA: 0x001AF964 File Offset: 0x001ADD64
	public static List<LoadingResourcesTable> CityLoading
	{
		get
		{
			return LoadingResourceManager.m_CityLoading;
		}
	}

	// Token: 0x170018EE RID: 6382
	// (get) Token: 0x060091A7 RID: 37287 RVA: 0x001AF96B File Offset: 0x001ADD6B
	public static List<LoadingResourcesTable> DugeonLoading
	{
		get
		{
			return LoadingResourceManager.m_DugeonLoading;
		}
	}

	// Token: 0x060091A8 RID: 37288 RVA: 0x001AF974 File Offset: 0x001ADD74
	public static void InitLoadingResource()
	{
		LoadingResourceManager.DeinitLoadingResource();
		Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<LoadingResourcesTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			if (keyValuePair.Value is LoadingResourcesTable)
			{
				LoadingResourcesTable loadingResourcesTable = keyValuePair.Value as LoadingResourcesTable;
				if (loadingResourcesTable.Type == LoadingResourcesTable.eType.AT_EQUIP)
				{
					LoadingResourceManager.m_CityLoading.Add(loadingResourcesTable);
				}
				else if (loadingResourcesTable.Type == LoadingResourcesTable.eType.AT_DEFENCE)
				{
					LoadingResourceManager.DugeonLoading.Add(loadingResourcesTable);
				}
			}
		}
	}

	// Token: 0x060091A9 RID: 37289 RVA: 0x001AFA28 File Offset: 0x001ADE28
	public static void DeinitLoadingResource()
	{
		LoadingResourceManager.m_CityLoading.Clear();
		LoadingResourceManager.m_DugeonLoading.Clear();
	}

	// Token: 0x060091AA RID: 37290 RVA: 0x001AFA40 File Offset: 0x001ADE40
	public static string GetRandomCityLoadingRes()
	{
		int count = LoadingResourceManager.CityLoading.Count;
		int num = Random.Range(0, count);
		if (num < 0 || num >= count)
		{
			return null;
		}
		string resources = LoadingResourceManager.CityLoading[num].Resources;
		if (resources.Length <= 1)
		{
			return null;
		}
		return resources;
	}

	// Token: 0x060091AB RID: 37291 RVA: 0x001AFA90 File Offset: 0x001ADE90
	public static string GetRandomDugeonLoadingRes()
	{
		int count = LoadingResourceManager.DugeonLoading.Count;
		int num = Random.Range(0, count);
		if (num < 0 || num >= count)
		{
			return null;
		}
		string resources = LoadingResourceManager.DugeonLoading[num].Resources;
		if (resources.Length <= 1)
		{
			return null;
		}
		return resources;
	}

	// Token: 0x040048D3 RID: 18643
	private static List<LoadingResourcesTable> m_CityLoading = new List<LoadingResourcesTable>();

	// Token: 0x040048D4 RID: 18644
	private static List<LoadingResourcesTable> m_DugeonLoading = new List<LoadingResourcesTable>();
}
