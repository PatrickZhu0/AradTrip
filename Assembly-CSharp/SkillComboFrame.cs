using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x020010D9 RID: 4313
public class SkillComboFrame : ClientFrame
{
	// Token: 0x0600A33B RID: 41787 RVA: 0x002161F5 File Offset: 0x002145F5
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/SkillComboFrame";
	}

	// Token: 0x0600A33C RID: 41788 RVA: 0x002161FC File Offset: 0x002145FC
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
	}

	// Token: 0x0600A33D RID: 41789 RVA: 0x00216204 File Offset: 0x00214604
	protected override void _bindExUI()
	{
		base._bindExUI();
		this.skillComboItem = this.mBind.GetGameObject("skillComboItem");
		this.skillComboContainer = this.mBind.GetGameObject("skillComboItemContainer");
	}

	// Token: 0x0600A33E RID: 41790 RVA: 0x00216238 File Offset: 0x00214638
	protected override void _OnCloseFrame()
	{
		base._OnCloseFrame();
		this.DestroySkillComboItem();
	}

	// Token: 0x0600A33F RID: 41791 RVA: 0x00216246 File Offset: 0x00214646
	protected override void _unbindExUI()
	{
		base._unbindExUI();
	}

	// Token: 0x0600A340 RID: 41792 RVA: 0x00216250 File Offset: 0x00214650
	public void InitSkillComboUI(int jobID, int roomID, bool showArrow = true)
	{
		if (BattleMain.instance == null)
		{
			return;
		}
		this.DestroySkillComboItem();
		TrainingSkillComboBattle trainingSkillComboBattle = BattleMain.instance.GetBattle() as TrainingSkillComboBattle;
		if (trainingSkillComboBattle == null || trainingSkillComboBattle.teachData == null)
		{
			return;
		}
		this.tabelList = trainingSkillComboBattle.teachData.datas;
		if (this.tabelList == null)
		{
			return;
		}
		for (int i = 0; i < this.tabelList.Length; i++)
		{
			ComboData comboData = this.tabelList[i];
			if (comboData != null && comboData.showUI != 0)
			{
				if (!(this.skillComboItem == null))
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.skillComboItem);
					if (!(gameObject == null))
					{
						gameObject.SetActive(true);
						Utility.AttachTo(gameObject, this.skillComboContainer, false);
						SkillComboItem component = gameObject.GetComponent<SkillComboItem>();
						if (component != null)
						{
							component.InitItem(comboData.skillGroupID, comboData.skillID, string.Empty, (float)comboData.waitInputTime, comboData.sourceID, comboData.phase, showArrow);
							this.comboItemList.Add(component);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600A341 RID: 41793 RVA: 0x00216380 File Offset: 0x00214780
	private void DestroySkillComboItem()
	{
		for (int i = 0; i < this.comboItemList.Count; i++)
		{
			Object.Destroy(this.comboItemList[i].gameObject);
		}
		this.comboItemList.Clear();
	}

	// Token: 0x0600A342 RID: 41794 RVA: 0x002163CA File Offset: 0x002147CA
	public SkillComboItem GetShowItem(int index)
	{
		if (index >= this.comboItemList.Count)
		{
			return null;
		}
		return this.comboItemList[index];
	}

	// Token: 0x0600A343 RID: 41795 RVA: 0x002163EB File Offset: 0x002147EB
	public List<SkillComboItem> GetComboItemList()
	{
		return this.comboItemList;
	}

	// Token: 0x0600A344 RID: 41796 RVA: 0x002163F4 File Offset: 0x002147F4
	public void ShowComboItemEffect(int id)
	{
		for (int i = 0; i < this.comboItemList.Count; i++)
		{
			if (this.comboItemList[i].groupID == id)
			{
				this.comboItemList[i].ShowEffect();
			}
		}
	}

	// Token: 0x04005B00 RID: 23296
	private ComboData[] tabelList;

	// Token: 0x04005B01 RID: 23297
	private GameObject skillComboItem;

	// Token: 0x04005B02 RID: 23298
	public GameObject skillComboContainer;

	// Token: 0x04005B03 RID: 23299
	private List<SkillComboItem> comboItemList = new List<SkillComboItem>();
}
