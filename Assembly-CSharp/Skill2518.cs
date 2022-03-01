using System;
using System.Collections.Generic;

// Token: 0x020044A6 RID: 17574
public class Skill2518 : Skill2522
{
	// Token: 0x06018733 RID: 100147 RVA: 0x007A0F70 File Offset: 0x0079F370
	public Skill2518(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018734 RID: 100148 RVA: 0x007A0FC4 File Offset: 0x0079F3C4
	protected override void OnSkillCurFrame(object[] args)
	{
		int item = 0;
		if (int.TryParse((string)args[0], out item))
		{
			if (this.curFrameFlagList.Contains(item) && this.leftBulletNum > 0)
			{
				this.leftBulletNum--;
				this.SetSilverBulletCount();
			}
		}
		else
		{
			Logger.LogError(string.Format("tryParse failed {0} skillId {1}", args[0], this.skillID));
		}
	}

	// Token: 0x06018735 RID: 100149 RVA: 0x007A103C File Offset: 0x0079F43C
	protected override void OnAfterFinalDamageNew(object[] args)
	{
		int item = (int)args[2];
		BeActor beActor = (BeActor)args[1];
		if (this.effectIdList.Contains(item) && beActor != null && this.leftBulletNum > 0)
		{
			base.owner.DoAttackTo(beActor, this.attachEffectId, false, true);
		}
	}

	// Token: 0x04011A3A RID: 72250
	private List<int> effectIdList = new List<int>(new int[]
	{
		25180,
		25181
	});

	// Token: 0x04011A3B RID: 72251
	private List<int> curFrameFlagList = new List<int>(new int[]
	{
		251801,
		2518001,
		2518101,
		2518201,
		2518401
	});
}
