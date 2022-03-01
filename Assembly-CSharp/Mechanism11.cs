using System;
using System.Collections.Generic;

// Token: 0x020042A3 RID: 17059
public class Mechanism11 : BeMechanism
{
	// Token: 0x060179A3 RID: 96675 RVA: 0x00745404 File Offset: 0x00743804
	public Mechanism11(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060179A4 RID: 96676 RVA: 0x00745430 File Offset: 0x00743830
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], 1, true);
		this.monsterSkill = TableManager.GetValueFromUnionCell(this.data.ValueB[0], 1, true);
		this.setNeedDead = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], 1, true) == 1);
	}

	// Token: 0x060179A5 RID: 96677 RVA: 0x0074549A File Offset: 0x0074389A
	public override void OnStart()
	{
	}

	// Token: 0x060179A6 RID: 96678 RVA: 0x0074549C File Offset: 0x0074389C
	public override void OnFinish()
	{
		foreach (KeyValuePair<BeActor, BeEventHandle> keyValuePair in this.savedHandles)
		{
			BeEventHandle value = keyValuePair.Value;
			value.Remove();
		}
		this.savedHandles.Clear();
	}

	// Token: 0x060179A7 RID: 96679 RVA: 0x007454E8 File Offset: 0x007438E8
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null && this.savedMonsters == null)
		{
			this.savedMonsters = new List<BeActor>();
			base.owner.CurrentBeScene.FindMonsterByID(this.savedMonsters, this.monsterID, true);
			for (int i = 0; i < this.savedMonsters.Count; i++)
			{
				BeActor monster = this.savedMonsters[i];
				BeEventHandle value = this.savedMonsters[i].RegisterEvent(BeEventType.onDead, delegate(object[] args)
				{
					if (this.owner != null && !this.owner.IsDead())
					{
						int[] array = (int[])args[0];
						array[0] = 1;
						if (this.setNeedDead)
						{
							monster.SetNeedDead(false);
						}
						monster.SetIsDead(false);
						monster.GetEntityData().SetHP(1);
						if (!this.setNeedDead)
						{
							monster.m_pkGeActor.ResetHPBar();
						}
						monster.buffController.TryAddBuff(2, GlobalLogic.VALUE_3000, 1);
						monster.UseSkill(this.monsterSkill, true);
					}
				});
				this.savedHandles.Add(monster, value);
			}
		}
	}

	// Token: 0x04010F64 RID: 69476
	private bool setNeedDead;

	// Token: 0x04010F65 RID: 69477
	private int monsterID = 1010011;

	// Token: 0x04010F66 RID: 69478
	private int monsterSkill = 5000;

	// Token: 0x04010F67 RID: 69479
	private List<BeActor> savedMonsters;

	// Token: 0x04010F68 RID: 69480
	private Dictionary<BeActor, BeEventHandle> savedHandles = new Dictionary<BeActor, BeEventHandle>();
}
