using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004485 RID: 17541
public class Skill2103 : BeSkill
{
	// Token: 0x06018616 RID: 99862 RVA: 0x00798AA5 File Offset: 0x00796EA5
	public Skill2103(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018617 RID: 99863 RVA: 0x00798AC8 File Offset: 0x00796EC8
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.monsterSkillID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x06018618 RID: 99864 RVA: 0x00798B1C File Offset: 0x00796F1C
	private bool IsTargetActionValid(BeActor target)
	{
		if ((target != null && ((target.stateController != null && !target.stateController.CanMove()) || !target.stateController.CanAttack() || target.stateController.WillBeGrab() || target.stateController.IsGraping() || target.stateController.IsBeingGrab())) || target.sgGetCurrentState() == 4)
		{
			return false;
		}
		BeSkill skill = this.summonedMonster.GetSkill(this.monsterSkillID);
		return skill != null && skill.CanUseSkill();
	}

	// Token: 0x06018619 RID: 99865 RVA: 0x00798BB8 File Offset: 0x00796FB8
	public override void OnClickAgain()
	{
		if (this.skillID == 2111 || this.skillID == 2118 || this.skillID == 2103 || this.skillID == 2109)
		{
			bool flag = this.IsTargetActionValid(this.summonedMonster);
			if (this.summonedMonster != null && !this.summonedMonster.IsDead() && flag)
			{
				this.ReleaseSummonSkill(this.summonedMonster);
				this.SetButtonEffect(false);
			}
		}
		else if (this.summonedMonster != null && !this.summonedMonster.IsDead() && this.summonedMonster.CanUseSkill(this.monsterSkillID))
		{
			this.ReleaseSummonSkill(this.summonedMonster);
			this.SetButtonEffect(false);
		}
	}

	// Token: 0x0601861A RID: 99866 RVA: 0x00798C8F File Offset: 0x0079708F
	public override void OnFinish()
	{
		this.GetSummonedMonster();
	}

	// Token: 0x0601861B RID: 99867 RVA: 0x00798C97 File Offset: 0x00797097
	public override void OnCancel()
	{
		this.GetSummonedMonster();
	}

	// Token: 0x0601861C RID: 99868 RVA: 0x00798CA0 File Offset: 0x007970A0
	private void GetSummonedMonster()
	{
		this.summonedMonster = null;
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, false);
		for (int i = 0; i < list.Count; i++)
		{
			if (!list[i].IsDead() && BeUtility.IsMonsterIDEqual(list[i].GetEntityData().monsterID, this.monsterID))
			{
				this.summonedMonster = list[i];
				break;
			}
		}
		ListPool<BeActor>.Release(list);
		if (this.summonedMonster == null)
		{
			this.skillButtonState = BeSkill.SkillState.NORMAL;
		}
		else
		{
			this.summonedMonster.RegisterEvent(BeEventType.onDead, delegate(object[] args)
			{
				this.SetButtonEffect(false);
				this.skillButtonState = BeSkill.SkillState.NORMAL;
				this.summonedMonster = null;
			});
			this.summonedMonster.RegisterEvent(BeEventType.onExecuteAICmd, delegate(object[] args)
			{
				if (this.summonedMonster != null && this.summonedMonster.CanUseSkill(this.monsterSkillID))
				{
					this.SetButtonEffect(true);
				}
			});
		}
	}

	// Token: 0x0601861D RID: 99869 RVA: 0x00798D83 File Offset: 0x00797183
	private void SetButtonEffect(bool open)
	{
		if (base.button != null)
		{
			if (open)
			{
				base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
			}
			else
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
			}
		}
	}

	// Token: 0x0601861E RID: 99870 RVA: 0x00798DBC File Offset: 0x007971BC
	public void ReleaseSummonSkill(BeActor monster)
	{
		if (monster == null)
		{
			return;
		}
		monster.UseSkill(this.monsterSkillID, true);
		VInt3 position = base.owner.GetPosition();
		position.x += ((!base.owner.GetFace()) ? Skill2103.value.i : (-Skill2103.value.i));
		if (monster.CurrentBeScene.IsInBlockPlayer(position))
		{
			position = base.owner.GetPosition();
		}
		monster.SetPosition(position, false, true, false);
		monster.SetFace(base.owner.GetFace(), false, false);
	}

	// Token: 0x0401198A RID: 72074
	private int monsterID = 9060031;

	// Token: 0x0401198B RID: 72075
	private int monsterSkillID = 5353;

	// Token: 0x0401198C RID: 72076
	private BeActor summonedMonster;

	// Token: 0x0401198D RID: 72077
	private static readonly VInt value = new VInt(1.5f);
}
