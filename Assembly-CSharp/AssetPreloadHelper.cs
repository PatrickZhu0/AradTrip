using System;
using System.Collections;
using System.Text;
using GameClient;
using ProtoTable;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020000C2 RID: 194
public class AssetPreloadHelper
{
	// Token: 0x06000429 RID: 1065 RVA: 0x0001DC14 File Offset: 0x0001C014
	public static void PreloadSkillDataRes()
	{
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				for (int i = 0; i < tableItem2.ActionConfigPath.Count; i++)
				{
					string text = tableItem2.ActionConfigPath[i];
					if (!string.IsNullOrEmpty(text))
					{
						string path = text + "/FileList";
						AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, true, 0U);
						if (assetInst != null)
						{
							Object obj = assetInst.obj;
							if (!(null == obj))
							{
								string @string = Encoding.Default.GetString((obj as TextAsset).bytes);
								ArrayList arrayList = MiniJSON.jsonDecode(@string) as ArrayList;
								for (int j = 0; j < arrayList.Count; j++)
								{
									AssetInst assetInst2 = Singleton<AssetLoader>.instance.LoadRes(text + "/" + arrayList[j], true, 0U);
									DSkillData dskillData = assetInst2.obj as DSkillData;
									if (!(null == dskillData))
									{
										MonoSingleton<CResPreloader>.instance.AddRes(dskillData.goHitEffectAsset.m_AssetPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
										for (int k = 0; k < dskillData.effectFrames.Length; k++)
										{
											MonoSingleton<CResPreloader>.instance.AddRes(dskillData.effectFrames[k].effectAsset.m_AssetPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
										}
										for (int l = 0; l < dskillData.entityFrames.Length; l++)
										{
											MonoSingleton<CResPreloader>.instance.AddRes(dskillData.entityFrames[l].entityAsset.m_AssetPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
