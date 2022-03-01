using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020044D8 RID: 17624
public class Skill5077 : BeSkill
{
	// Token: 0x06018885 RID: 100485 RVA: 0x007A8961 File Offset: 0x007A6D61
	public Skill5077(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018886 RID: 100486 RVA: 0x007A896C File Offset: 0x007A6D6C
	public override void OnInit()
	{
		if (this.skillData != null)
		{
			this.conductMonsterID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
			this.conductSkillID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
			this.delayTime = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		}
	}

	// Token: 0x06018887 RID: 100487 RVA: 0x007A89ED File Offset: 0x007A6DED
	public override void OnStart()
	{
		this.delayTimeAcc = 0;
		this.startCheck = true;
	}

	// Token: 0x06018888 RID: 100488 RVA: 0x007A89FD File Offset: 0x007A6DFD
	public override void OnUpdate(int iDeltime)
	{
		if (this.startCheck)
		{
			this.delayTimeAcc += iDeltime;
			if (this.delayTimeAcc > this.delayTime)
			{
				this.startCheck = false;
				this.DoWork();
			}
		}
	}

	// Token: 0x06018889 RID: 100489 RVA: 0x007A8A38 File Offset: 0x007A6E38
	private void DoWork()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindMonsterByID(list, this.conductMonsterID, true);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (list[i] != null && (!beActor.IsInPassiveState() || beActor.IsCastingSkill()))
			{
				BeSkill skill = list[i].GetSkill(this.conductSkillID);
				if (skill != null)
				{
					skill.ResetCoolDown();
					list[i].UseSkill(this.conductSkillID, true);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011B24 RID: 72484
	private int conductMonsterID;

	// Token: 0x04011B25 RID: 72485
	private int conductSkillID;

	// Token: 0x04011B26 RID: 72486
	private int delayTime;

	// Token: 0x04011B27 RID: 72487
	private int delayTimeAcc;

	// Token: 0x04011B28 RID: 72488
	private bool startCheck;
}
