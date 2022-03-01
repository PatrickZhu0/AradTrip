using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F29 RID: 3881
public class ComTipInfoUnit : MonoBehaviour
{
	// Token: 0x06009765 RID: 38757 RVA: 0x001D005D File Offset: 0x001CE45D
	public void SetSprite(Sprite sprite)
	{
		this.mIcon.sprite = sprite;
	}

	// Token: 0x06009766 RID: 38758 RVA: 0x001D006B File Offset: 0x001CE46B
	public void SetBgActive(bool isActive)
	{
		if (this.mBg)
		{
			this.mBg.enabled = isActive;
		}
	}

	// Token: 0x06009767 RID: 38759 RVA: 0x001D0089 File Offset: 0x001CE489
	public void SetData(BuffTable buffData)
	{
		this.mData = buffData;
		this._updateData();
		this.mText.text = this.mString.ToString().TrimEnd(new char[0]);
	}

	// Token: 0x06009768 RID: 38760 RVA: 0x001D00BC File Offset: 0x001CE4BC
	private int _getCellValue(Type type, string filed)
	{
		try
		{
			PropertyInfo property = type.GetProperty(filed, BindingFlags.Instance | BindingFlags.Public);
			object value = property.GetValue(this.mData, null);
			if (value is UnionCell)
			{
				UnionCell unionCell = value as UnionCell;
				if (unionCell != null)
				{
					return TableManager.GetValueFromUnionCell(unionCell, 1, true);
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

	// Token: 0x06009769 RID: 38761 RVA: 0x001D0144 File Offset: 0x001CE544
	private int _getFinalValue(BuffDrugConfigInfoTable.eValueType type, int val)
	{
		if (type != BuffDrugConfigInfoTable.eValueType.Rate1000)
		{
			return val;
		}
		return val / 10;
	}

	// Token: 0x0600976A RID: 38762 RVA: 0x001D0158 File Offset: 0x001CE558
	private void _updateData()
	{
		if (this.mData == null)
		{
			return;
		}
		List<string> list = new List<string>();
		BuffType type = (BuffType)this.mData.Type;
		Type type2 = this.mData.GetType();
		MyExtensionMethods.Clear(this.mString);
		Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<BuffDrugConfigInfoTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			BuffDrugConfigInfoTable buffDrugConfigInfoTable = keyValuePair.Value as BuffDrugConfigInfoTable;
			if (buffDrugConfigInfoTable != null)
			{
				int val = this._getCellValue(type2, buffDrugConfigInfoTable.Filed);
				int num = this._getFinalValue(buffDrugConfigInfoTable.ValueType, val);
				if (num > 0)
				{
					this.mString.Append(string.Format(TR.Value("battle_buff_" + buffDrugConfigInfoTable.Filed) + "\n", num));
				}
			}
		}
	}

	// Token: 0x04004E14 RID: 19988
	public Image mIcon;

	// Token: 0x04004E15 RID: 19989
	public Text mText;

	// Token: 0x04004E16 RID: 19990
	public Image mBg;

	// Token: 0x04004E17 RID: 19991
	private StringBuilder mString = StringBuilderCache.Acquire(2000);

	// Token: 0x04004E18 RID: 19992
	private BuffTable mData;

	// Token: 0x04004E19 RID: 19993
	private const string kKeyPrefix = "battle_buff_";
}
