using System;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02001294 RID: 4756
public class ItemSourceInfoUtility
{
	// Token: 0x0600B72E RID: 46894 RVA: 0x0029CC01 File Offset: 0x0029B001
	public static string GetStringFromTable(ItemSourceInfoTable tb, int index)
	{
		if (null == tb || tb.strTables == null)
		{
			return null;
		}
		if (index < 0 || index >= tb.strTables.Length)
		{
			return null;
		}
		return tb.strTables[index];
	}

	// Token: 0x0600B72F RID: 46895 RVA: 0x0029CC3B File Offset: 0x0029B03B
	public static string GetLinkName(ItemSourceInfoTable tb, ISourceInfo info)
	{
		if (info == null || null == tb)
		{
			return string.Empty;
		}
		return ItemSourceInfoUtility.GetStringFromTable(tb, info.GetNameIndex());
	}

	// Token: 0x0600B730 RID: 46896 RVA: 0x0029CC64 File Offset: 0x0029B064
	public static string GetLinkInfo(ItemSourceInfoTable tb, ISourceInfo info)
	{
		if (info == null || null == tb)
		{
			return string.Empty;
		}
		string stringFromTable = ItemSourceInfoUtility.GetStringFromTable(tb, info.GetParmIndex());
		eItemSourceType type = info.GetType();
		if (type == eItemSourceType.eDungeon)
		{
			return string.Format("<type=mapid value={0}>", info.GetData());
		}
		if (type != eItemSourceType.eDungeonActivity && type != eItemSourceType.eJar && type != eItemSourceType.eAuction && type != eItemSourceType.eLegend && type != eItemSourceType.eShop && type != eItemSourceType.eMall && type != eItemSourceType.eTeamDuplicate && type != eItemSourceType.eArtifact_Tank60)
		{
			return string.Empty;
		}
		return stringFromTable;
	}

	// Token: 0x0600B731 RID: 46897 RVA: 0x0029CD10 File Offset: 0x0029B110
	public static bool IsLinkFunctionOpen(ISourceInfo info)
	{
		FunctionUnLock tableItem = Singleton<TableManager>.instance.GetTableItem<FunctionUnLock>(info.GetOpenFunctionID(), string.Empty, string.Empty);
		int num = 1;
		if (tableItem != null)
		{
			num = Mathf.Max(num, tableItem.FinishLevel);
		}
		if (info.GetType() == eItemSourceType.eJar)
		{
			num = Mathf.Max(num, info.GetData());
		}
		if (info.GetType() == eItemSourceType.eArtifact_Tank60)
		{
			num = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
		}
		int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
		eItemSourceType type = info.GetType();
		if (type != eItemSourceType.eDungeon)
		{
			return (type != eItemSourceType.eDungeonActivity && type != eItemSourceType.eJar && type != eItemSourceType.eAuction && type != eItemSourceType.eLegend && type != eItemSourceType.eShop && type != eItemSourceType.eMall && type != eItemSourceType.eTeamDuplicate && type != eItemSourceType.eArtifact_Tank60) || num <= level;
		}
		return ChapterUtility.GetDungeonCanEnter(info.GetData(), false, false, true);
	}
}
