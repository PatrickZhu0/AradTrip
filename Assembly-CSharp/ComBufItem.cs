using System;
using System.Collections.Generic;
using System.Reflection;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E6F RID: 3695
public class ComBufItem : MonoBehaviour
{
	// Token: 0x06009295 RID: 37525 RVA: 0x001B3B9A File Offset: 0x001B1F9A
	private void Start()
	{
	}

	// Token: 0x06009296 RID: 37526 RVA: 0x001B3B9C File Offset: 0x001B1F9C
	private void Update()
	{
	}

	// Token: 0x06009297 RID: 37527 RVA: 0x001B3BA0 File Offset: 0x001B1FA0
	public void SetBufData(int bufID, int bufLv = 1)
	{
		this.id = bufID;
		this.lv = bufLv;
		BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(bufID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		this.bufName.SafeSetText(tableItem.Name);
		this.bufIcon.SafeSetImage(tableItem.Icon, false);
		this.bufAttrs.SafeSetText(tableItem.Description);
	}

	// Token: 0x06009298 RID: 37528 RVA: 0x001B3C0C File Offset: 0x001B200C
	public int GetBufID()
	{
		return this.id;
	}

	// Token: 0x06009299 RID: 37529 RVA: 0x001B3C14 File Offset: 0x001B2014
	public int GetBufLv()
	{
		return this.lv;
	}

	// Token: 0x0600929A RID: 37530 RVA: 0x001B3C1C File Offset: 0x001B201C
	private static int _getCellValue(Type type, string filed, BuffTable buf, int lv)
	{
		try
		{
			PropertyInfo property = type.GetProperty(filed, BindingFlags.Instance | BindingFlags.Public);
			object value = property.GetValue(buf, null);
			if (value is UnionCell)
			{
				UnionCell unionCell = value as UnionCell;
				if (unionCell != null)
				{
					return TableManager.GetValueFromUnionCell(unionCell, lv, true);
				}
			}
			else if (value is int)
			{
				return (int)value;
			}
		}
		catch
		{
		}
		return -1;
	}

	// Token: 0x0600929B RID: 37531 RVA: 0x001B3C9C File Offset: 0x001B209C
	private static int _getFinalValue(BuffDrugConfigInfoTable.eValueType type, int val)
	{
		if (type != BuffDrugConfigInfoTable.eValueType.Rate1000)
		{
			return val;
		}
		return val / 10;
	}

	// Token: 0x0600929C RID: 37532 RVA: 0x001B3CB0 File Offset: 0x001B20B0
	public static string GetBuffAddUpInfo(int iBufID, int iBufLv)
	{
		string text = string.Empty;
		BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(iBufID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		BuffType type = (BuffType)tableItem.Type;
		Type type2 = tableItem.GetType();
		Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<BuffDrugConfigInfoTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			BuffDrugConfigInfoTable buffDrugConfigInfoTable = keyValuePair.Value as BuffDrugConfigInfoTable;
			if (buffDrugConfigInfoTable != null)
			{
				int val = ComBufItem._getCellValue(type2, buffDrugConfigInfoTable.Filed, tableItem, iBufLv);
				int num = ComBufItem._getFinalValue(buffDrugConfigInfoTable.ValueType, val);
				if (num > 0)
				{
					text += string.Format(TR.Value(buffDrugConfigInfoTable.Filed), num);
					text += "  ";
				}
			}
		}
		return text;
	}

	// Token: 0x040049CB RID: 18891
	[SerializeField]
	private Text bufName;

	// Token: 0x040049CC RID: 18892
	[SerializeField]
	private Image bufIcon;

	// Token: 0x040049CD RID: 18893
	[SerializeField]
	private Text bufAttrs;

	// Token: 0x040049CE RID: 18894
	private int id;

	// Token: 0x040049CF RID: 18895
	private int lv;
}
