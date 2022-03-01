using System;
using System.Collections.Generic;

// Token: 0x020044F4 RID: 17652
public class Skill5686 : BeSkill
{
	// Token: 0x06018905 RID: 100613 RVA: 0x007ABE5C File Offset: 0x007AA25C
	public Skill5686(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018906 RID: 100614 RVA: 0x007ABE83 File Offset: 0x007AA283
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && this._canUseSkill();
	}

	// Token: 0x06018907 RID: 100615 RVA: 0x007ABE9C File Offset: 0x007AA29C
	private bool _canUseSkill()
	{
		int num = 0;
		base.owner.CurrentBeScene.FindMonsterByID(this.list, this.monsterID, true);
		num += this.list.Count;
		return num < this.maxCnt;
	}

	// Token: 0x04011B8F RID: 72591
	protected int monsterID = 30300011;

	// Token: 0x04011B90 RID: 72592
	private List<BeActor> list = new List<BeActor>();

	// Token: 0x04011B91 RID: 72593
	private int maxCnt = 3;
}
