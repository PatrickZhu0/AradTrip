using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

// Token: 0x02001A9F RID: 6815
public class AdjectiveSkillView : MonoBehaviour
{
	// Token: 0x06010BAC RID: 68524 RVA: 0x004BE85C File Offset: 0x004BCC5C
	public void InitAdjectiveSkill()
	{
		this._InitComUIList();
		List<PassiveSkillData> passiveButtonBindSkill = DataManager<SkillDataManager>.GetInstance().PassiveButtonBindSkill;
		for (int i = 0; i < passiveButtonBindSkill.Count; i++)
		{
			SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(passiveButtonBindSkill[i].skillid, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.adjectSkillDic.ContainsKey(tableItem.LevelLimit))
				{
					this.adjectSkillDic[tableItem.LevelLimit].Add(passiveButtonBindSkill[i]);
				}
				else
				{
					List<PassiveSkillData> list = new List<PassiveSkillData>();
					list.Add(passiveButtonBindSkill[i]);
					this.adjectSkillDic.Add(tableItem.LevelLimit, list);
				}
			}
		}
		this.adjectiveSkillUIList.SetElementAmount(this.adjectSkillDic.Count);
	}

	// Token: 0x06010BAD RID: 68525 RVA: 0x004BE938 File Offset: 0x004BCD38
	private void _InitComUIList()
	{
		this.adjectiveSkillUIList.Initialize();
		this.adjectiveSkillUIList.onItemVisiable = delegate(ComUIListElementScript item)
		{
			if (item.m_index >= 0)
			{
				this._UpdateMissionBind(item);
			}
		};
		this.adjectiveSkillUIList.OnItemRecycle = delegate(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
		};
	}

	// Token: 0x06010BAE RID: 68526 RVA: 0x004BE990 File Offset: 0x004BCD90
	private void _UpdateMissionBind(ComUIListElementScript item)
	{
		AdjectiveSkillItemRoot component = item.GetComponent<AdjectiveSkillItemRoot>();
		if (component == null)
		{
			return;
		}
		int num = -1;
		int num2 = 0;
		foreach (int num3 in this.adjectSkillDic.Keys)
		{
			if (num2 == item.m_index)
			{
				num = num3;
			}
			num2++;
		}
		if (num != -1)
		{
			component.InitSkillRoot(num, this.adjectSkillDic[num]);
		}
	}

	// Token: 0x0400AB0E RID: 43790
	[SerializeField]
	private ComUIListScript adjectiveSkillUIList;

	// Token: 0x0400AB0F RID: 43791
	private Dictionary<int, List<PassiveSkillData>> adjectSkillDic = new Dictionary<int, List<PassiveSkillData>>();
}
