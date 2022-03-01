using System;
using System.Collections.Generic;

// Token: 0x02004292 RID: 17042
public class Mechanism1072 : BeMechanism
{
	// Token: 0x06017941 RID: 96577 RVA: 0x00742311 File Offset: 0x00740711
	public Mechanism1072(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017942 RID: 96578 RVA: 0x00742334 File Offset: 0x00740734
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.monsterIdOldList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueB.Count; j++)
		{
			this.monsterIdNewList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
		}
	}

	// Token: 0x06017943 RID: 96579 RVA: 0x007423E3 File Offset: 0x007407E3
	public override void OnStart()
	{
		base.OnStart();
		this.RegisterEvent();
	}

	// Token: 0x06017944 RID: 96580 RVA: 0x007423F4 File Offset: 0x007407F4
	protected void RegisterEvent()
	{
		if (base.owner.GetEntityData().professtion != 33)
		{
			return;
		}
		if (!BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.sceneHandleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onChangeSummonMonsterAttr, new BeEventHandle.Del(this.ChangeSummonMonsterAttr));
	}

	// Token: 0x06017945 RID: 96581 RVA: 0x00742460 File Offset: 0x00740860
	protected void ChangeSummonMonsterAttr(object[] args)
	{
		int[] monsterIdArr = (int[])args[0];
		int num = this.monsterIdOldList.FindIndex((int x) => x == monsterIdArr[0]);
		if (num < 0)
		{
			return;
		}
		monsterIdArr[0] = this.monsterIdNewList[num];
	}

	// Token: 0x04010F17 RID: 69399
	protected List<int> monsterIdOldList = new List<int>();

	// Token: 0x04010F18 RID: 69400
	protected List<int> monsterIdNewList = new List<int>();
}
