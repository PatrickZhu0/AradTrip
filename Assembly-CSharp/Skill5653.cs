using System;
using System.Collections.Generic;

// Token: 0x020044E8 RID: 17640
public class Skill5653 : BeSkill
{
	// Token: 0x060188D2 RID: 100562 RVA: 0x007AA9A2 File Offset: 0x007A8DA2
	public Skill5653(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060188D3 RID: 100563 RVA: 0x007AA9CD File Offset: 0x007A8DCD
	public override void OnStart()
	{
		this.isMonsterDead = false;
		this.timer = 0;
	}

	// Token: 0x060188D4 RID: 100564 RVA: 0x007AA9E0 File Offset: 0x007A8DE0
	public override void OnUpdate(int iDeltime)
	{
		if (!this.isMonsterDead)
		{
			if (this.timer >= GlobalLogic.VALUE_1000)
			{
				if (this.monsters.Count <= 0)
				{
					base.owner.CurrentBeScene.FindActorById(this.monsters, this.monsterId);
					if (this.monsters.Count > 0)
					{
						this.monsters[0].RegisterEvent(BeEventType.onDead, delegate(object[] args)
						{
							this.isMonsterDead = true;
						});
					}
				}
				this.timer = 0;
			}
		}
		else if (this.timer >= GlobalLogic.VALUE_3000)
		{
			base.Cancel();
			base.owner.sgSwitchStates(new BeStateData(0, 0));
			base.owner.UseSkill(this.nextSkillId, true);
		}
		this.timer += iDeltime;
	}

	// Token: 0x060188D5 RID: 100565 RVA: 0x007AAABC File Offset: 0x007A8EBC
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && !base.owner.IsDead();
	}

	// Token: 0x060188D6 RID: 100566 RVA: 0x007AAADA File Offset: 0x007A8EDA
	public override void OnFinish()
	{
		this.monsters.Clear();
	}

	// Token: 0x04011B6F RID: 72559
	private int monsterId = 5670021;

	// Token: 0x04011B70 RID: 72560
	private int nextSkillId = 5654;

	// Token: 0x04011B71 RID: 72561
	private List<BeActor> monsters = new List<BeActor>();

	// Token: 0x04011B72 RID: 72562
	private bool isMonsterDead;

	// Token: 0x04011B73 RID: 72563
	private int timer;
}
