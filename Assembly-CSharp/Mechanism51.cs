using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043F2 RID: 17394
public class Mechanism51 : BeMechanism
{
	// Token: 0x06018245 RID: 98885 RVA: 0x00782107 File Offset: 0x00780507
	public Mechanism51(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018246 RID: 98886 RVA: 0x00782114 File Offset: 0x00780514
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skill1 = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.skill2 = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.skillList = new List<int>();
		this.skillList.Add(this.skill2);
		base.owner.aiManager.SetSkillsEnable(this.skillList, false);
	}

	// Token: 0x06018247 RID: 98887 RVA: 0x007821CC File Offset: 0x007805CC
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null && this.monster == null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
			if (list.Count > 0)
			{
				this.monster = list[0];
				base.owner.aiManager.SetSkillsEnable(this.skillList, true);
				this.monster.RegisterEvent(BeEventType.onStateChange, delegate(object[] args)
				{
					if (base.owner.IsDead())
					{
						return;
					}
					ActionState actionState = (ActionState)args[0];
					if (actionState == ActionState.AS_CASTSKILL && this.monster.m_iCurSkillID == this.skill1)
					{
						base.owner.aiManager.SetSkillsEnable(this.skillList, false);
					}
					else if (actionState != ActionState.AS_DEAD)
					{
						base.owner.aiManager.SetSkillsEnable(this.skillList, true);
					}
				});
			}
			else
			{
				base.owner.aiManager.SetSkillsEnable(this.skillList, false);
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x04011699 RID: 71321
	private int monsterID;

	// Token: 0x0401169A RID: 71322
	private int skill1;

	// Token: 0x0401169B RID: 71323
	private int skill2;

	// Token: 0x0401169C RID: 71324
	private List<int> skillList;

	// Token: 0x0401169D RID: 71325
	private BeActor monster;
}
