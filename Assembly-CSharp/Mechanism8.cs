using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004412 RID: 17426
public class Mechanism8 : BeMechanism
{
	// Token: 0x0601832A RID: 99114 RVA: 0x0078843B File Offset: 0x0078683B
	public Mechanism8(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601832B RID: 99115 RVA: 0x0078844C File Offset: 0x0078684C
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.isEnemy = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) == 0);
		this.registerFlag = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
		this.buffRelateLevel = (TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true) != 0);
	}

	// Token: 0x0601832C RID: 99116 RVA: 0x00788548 File Offset: 0x00786948
	public override void OnStart()
	{
		this.RegisterMonsterSummon();
		if (base.owner != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, this.isEnemy);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null && !beActor.IsDead())
				{
					this.AddBuffInfo(beActor);
					this.UseSkill(beActor);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x0601832D RID: 99117 RVA: 0x007885D4 File Offset: 0x007869D4
	private void RegisterMonsterSummon()
	{
		if (!this.registerFlag)
		{
			return;
		}
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onCreateMonster, new BeEventHandle.Del(this.SummonMonster));
	}

	// Token: 0x0601832E RID: 99118 RVA: 0x0078862C File Offset: 0x00786A2C
	private void SummonMonster(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (!beActor.GetEntityData().MonsterIDEqual(this.monsterID))
		{
			return;
		}
		this.UseSkill(beActor);
		this.AddBuffInfo(beActor);
	}

	// Token: 0x0601832F RID: 99119 RVA: 0x00788670 File Offset: 0x00786A70
	private void UseSkill(BeActor monster)
	{
		if (this.skillID > 0 && (!monster.IsInPassiveState() || monster.IsCastingSkill()))
		{
			BeSkill skill = monster.GetSkill(this.skillID);
			if (skill != null)
			{
				skill.ResetCoolDown();
				monster.UseSkill(this.skillID, true);
			}
		}
	}

	// Token: 0x06018330 RID: 99120 RVA: 0x007886C8 File Offset: 0x00786AC8
	private void AddBuffInfo(BeActor monster)
	{
		if (this.data.ValueC.Count > 0 && TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) > 0)
		{
			for (int i = 0; i < this.data.ValueC.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true);
				if (!this.buffRelateLevel)
				{
					monster.buffController.TryAddBuff(valueFromUnionCell, null, false, null, 0);
				}
				else
				{
					monster.buffController.TryAddBuffInfo(valueFromUnionCell, base.owner, this.level);
				}
			}
		}
	}

	// Token: 0x04011772 RID: 71538
	private int monsterID;

	// Token: 0x04011773 RID: 71539
	private int skillID;

	// Token: 0x04011774 RID: 71540
	private int buffID;

	// Token: 0x04011775 RID: 71541
	private bool registerFlag;

	// Token: 0x04011776 RID: 71542
	private bool isEnemy = true;

	// Token: 0x04011777 RID: 71543
	private bool buffRelateLevel;
}
