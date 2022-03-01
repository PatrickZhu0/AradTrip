using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x0200435D RID: 17245
public class Mechanism2038 : BeMechanism
{
	// Token: 0x06017E0E RID: 97806 RVA: 0x0076238F File Offset: 0x0076078F
	public Mechanism2038(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017E0F RID: 97807 RVA: 0x007623A4 File Offset: 0x007607A4
	public override void OnInit()
	{
		base.OnInit();
		this.buffIDs = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.buffIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.monsterIDs = new int[this.data.ValueB.Length];
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.monsterIDs[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017E10 RID: 97808 RVA: 0x007624AB File Offset: 0x007608AB
	public override void OnStart()
	{
		this.monsterList.Clear();
		base.OnStart();
		this.AddBuffToMonster();
		this.handleA = base.owner.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			for (int i = 0; i < this.monsterList.Count; i++)
			{
				for (int j = 0; j < this.buffIDs.Length; j++)
				{
					this.monsterList[i].buffController.RemoveBuff(this.buffIDs[j], 0, 0);
				}
			}
		});
	}

	// Token: 0x06017E11 RID: 97809 RVA: 0x007624E4 File Offset: 0x007608E4
	private int GetSkillLevel()
	{
		BeActor beActor = base.owner.GetOwner() as BeActor;
		BeSkill skill = beActor.GetSkill(this.skillID);
		if (skill != null)
		{
			return skill.level;
		}
		return 0;
	}

	// Token: 0x06017E12 RID: 97810 RVA: 0x00762520 File Offset: 0x00760920
	private void AddBuffToMonster()
	{
		BeActor beActor = base.owner.GetOwner() as BeActor;
		if (beActor != null)
		{
			this.handleB = beActor.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor2 = args[0] as BeActor;
				if (beActor2 != null && Array.IndexOf<int>(this.monsterIDs, beActor2.GetEntityData().monsterID) != -1)
				{
					this.monsterList.Add(beActor2);
					for (int l = 0; l < this.buffIDs.Length; l++)
					{
						beActor2.buffController.TryAddBuff(this.buffIDs[l], -1, this.GetSkillLevel());
					}
				}
			});
		}
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterIDs[i], false);
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].GetOwner() == beActor)
				{
					this.monsterList.Add(list[j]);
					for (int k = 0; k < this.buffIDs.Length; k++)
					{
						list[j].buffController.TryAddBuff(this.buffIDs[k], -1, this.GetSkillLevel());
					}
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x040112F6 RID: 70390
	private int skillID;

	// Token: 0x040112F7 RID: 70391
	private int[] buffIDs;

	// Token: 0x040112F8 RID: 70392
	private int[] monsterIDs;

	// Token: 0x040112F9 RID: 70393
	private int skillLevel;

	// Token: 0x040112FA RID: 70394
	private List<BeActor> monsterList = new List<BeActor>();
}
