using System;
using System.Collections.Generic;

// Token: 0x02004273 RID: 17011
public class Mechanism1040 : BeMechanism
{
	// Token: 0x060178A9 RID: 96425 RVA: 0x0073E51C File Offset: 0x0073C91C
	public Mechanism1040(int id, int level) : base(id, level)
	{
	}

	// Token: 0x060178AA RID: 96426 RVA: 0x0073E554 File Offset: 0x0073C954
	public override void OnInit()
	{
		this.monsterIds.Clear();
		this.aLivemonsterCounts.Clear();
		this.buffIds.Clear();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
				this.monsterIds.Add(valueFromUnionCell);
				this.aLivemonsterCounts.Add(valueFromUnionCell, new List<int>());
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			for (int j = 0; j < this.data.ValueB.Count; j++)
			{
				this.buffIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true));
			}
		}
	}

	// Token: 0x060178AB RID: 96427 RVA: 0x0073E65D File Offset: 0x0073CA5D
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.onSummonMonster));
	}

	// Token: 0x060178AC RID: 96428 RVA: 0x0073E684 File Offset: 0x0073CA84
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.monsterDeadHandles.Count; i++)
		{
			this.monsterDeadHandles[i].Remove();
		}
		this.monsterDeadHandles.Clear();
		if (base.owner == null || base.owner.IsDead())
		{
			return;
		}
		foreach (int buffID in this.buffIds)
		{
			base.owner.buffController.RemoveBuff(buffID, 0, 0);
		}
	}

	// Token: 0x060178AD RID: 96429 RVA: 0x0073E724 File Offset: 0x0073CB24
	private void onSummonMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.monsterIds.Count; i++)
		{
			if (beActor.GetEntityData().MonsterIDEqual(this.monsterIds[i]))
			{
				if (this.aLivemonsterCounts.ContainsKey(this.monsterIds[i]) && !this.aLivemonsterCounts[this.monsterIds[i]].Contains(beActor.GetPID()))
				{
					this.aLivemonsterCounts[this.monsterIds[i]].Add(beActor.GetPID());
				}
				this.monsterDeadHandles.Add(beActor.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.onMonsterDead)));
				break;
			}
		}
	}

	// Token: 0x060178AE RID: 96430 RVA: 0x0073E804 File Offset: 0x0073CC04
	private void onMonsterDead(object[] args)
	{
		if (args == null || args.Length < 3)
		{
			return;
		}
		BeActor monster = args[2] as BeActor;
		if (monster != null && base.owner != null && base.owner.buffController != null)
		{
			for (int i = 0; i < this.monsterIds.Count; i++)
			{
				if (monster.GetEntityData().MonsterIDEqual(this.monsterIds[i]) && this.aLivemonsterCounts.ContainsKey(this.monsterIds[i]))
				{
					int num = this.aLivemonsterCounts[this.monsterIds[i]].FindIndex((int x) => x == monster.GetPID());
					if (num >= 0)
					{
						this.aLivemonsterCounts[this.monsterIds[i]].RemoveAt(num);
						if (this.aLivemonsterCounts[this.monsterIds[i]].Count <= 0 && i < this.buffIds.Count)
						{
							base.owner.buffController.RemoveBuff(this.buffIds[i], 0, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x04010EA8 RID: 69288
	private Dictionary<int, List<int>> aLivemonsterCounts = new Dictionary<int, List<int>>();

	// Token: 0x04010EA9 RID: 69289
	private List<int> monsterIds = new List<int>();

	// Token: 0x04010EAA RID: 69290
	private List<int> buffIds = new List<int>();

	// Token: 0x04010EAB RID: 69291
	private List<BeEventHandle> monsterDeadHandles = new List<BeEventHandle>();
}
