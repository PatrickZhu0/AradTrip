using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;

// Token: 0x020044C9 RID: 17609
public class Skill3609 : BeSkill
{
	// Token: 0x0601880C RID: 100364 RVA: 0x007A63D8 File Offset: 0x007A47D8
	public Skill3609(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601880D RID: 100365 RVA: 0x007A6454 File Offset: 0x007A4854
	public override void OnInit()
	{
		base.OnInit();
		this.monsterCountLimit[0] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.monsterCountLimit[1] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true);
		this.summonOffset = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true), GlobalLogic.VALUE_1000);
		this.summonDisLimit = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601880E RID: 100366 RVA: 0x007A650B File Offset: 0x007A490B
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.mechanismFrame)
			{
				this.DoSummon();
			}
		});
	}

	// Token: 0x0601880F RID: 100367 RVA: 0x007A652C File Offset: 0x007A492C
	public override bool CanUseSkill()
	{
		BeActor.SkillCannotUseType skillUseType = this.GetSkillUseType();
		return skillUseType == BeActor.SkillCannotUseType.CAN_USE && base.CanUseSkill();
	}

	// Token: 0x06018810 RID: 100368 RVA: 0x007A6550 File Offset: 0x007A4950
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		BeActor.SkillCannotUseType skillUseType = this.GetSkillUseType();
		if (skillUseType != BeActor.SkillCannotUseType.CAN_USE)
		{
			return skillUseType;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018811 RID: 100369 RVA: 0x007A6574 File Offset: 0x007A4974
	protected BeActor.SkillCannotUseType GetSkillUseType()
	{
		BeActor.SkillCannotUseType result = BeActor.SkillCannotUseType.CAN_USE;
		List<BeActor> list = ListPool<BeActor>.Get();
		int mid = (!BattleMain.IsModePvP(base.battleType)) ? this.monsterIdArr[0] : this.monsterIdArr[1];
		base.owner.CurrentBeScene.FindMonsterByIDAndCamp(list, mid, base.owner.GetCamp());
		int num = (!BattleMain.IsModePvP(base.battleType)) ? this.monsterCountLimit[0] : this.monsterCountLimit[1];
		if (list.Count >= num)
		{
			result = BeActor.SkillCannotUseType.MONSTER_COUNT_LIMITM;
		}
		VInt vint = (!base.owner.GetFace()) ? this.summonOffset : (-this.summonOffset);
		VInt3 position = base.owner.GetPosition();
		position.x += vint.i;
		for (int i = 0; i < list.Count; i++)
		{
			int magnitude = (list[i].GetPosition() - position).magnitude;
			if (magnitude <= this.summonDisLimit)
			{
				result = BeActor.SkillCannotUseType.MONSTER_DIS_LIMITM;
				break;
			}
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06018812 RID: 100370 RVA: 0x007A66AC File Offset: 0x007A4AAC
	protected void DoSummon()
	{
		int monsterCountByIdCamp = base.owner.CurrentBeScene.GetMonsterCountByIdCamp(this.mechanismMonsterId, base.owner.GetCamp());
		if (monsterCountByIdCamp < 1)
		{
			base.owner.DoSummon(this.mechanismMonsterId, 1, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
		}
	}

	// Token: 0x04011AD9 RID: 72409
	protected int[] monsterCountLimit = new int[]
	{
		4,
		3
	};

	// Token: 0x04011ADA RID: 72410
	protected VInt summonOffset = 2000;

	// Token: 0x04011ADB RID: 72411
	protected VInt summonDisLimit = 2000;

	// Token: 0x04011ADC RID: 72412
	protected int[] monsterIdArr = new int[]
	{
		93060031,
		93000034
	};

	// Token: 0x04011ADD RID: 72413
	protected int mechanismMonsterId = 93030031;

	// Token: 0x04011ADE RID: 72414
	protected string mechanismFrame = "360901";
}
