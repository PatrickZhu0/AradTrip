using System;
using System.Collections.Generic;

// Token: 0x0200441A RID: 17434
public class Mechanism89 : BeMechanism
{
	// Token: 0x06018368 RID: 99176 RVA: 0x0078A3D9 File Offset: 0x007887D9
	public Mechanism89(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018369 RID: 99177 RVA: 0x0078A3F0 File Offset: 0x007887F0
	public override void OnInit()
	{
		this.skillIds.Clear();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
			this.skillIds.Add(valueFromUnionCell);
		}
	}

	// Token: 0x0601836A RID: 99178 RVA: 0x0078A458 File Offset: 0x00788858
	public override void OnStart()
	{
		this.handle = base.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] args)
		{
			int item = (int)args[0];
			if (this.skillIds.Contains(item))
			{
				this.SkillStartCoolDown();
			}
		});
	}

	// Token: 0x0601836B RID: 99179 RVA: 0x0078A47C File Offset: 0x0078887C
	private void SkillStartCoolDown()
	{
		for (int i = 0; i < this.skillIds.Count; i++)
		{
			BeSkill skill = base.owner.GetSkill(this.skillIds[i]);
			if (skill != null)
			{
				skill.StartCoolDown();
			}
		}
	}

	// Token: 0x0601836C RID: 99180 RVA: 0x0078A4C9 File Offset: 0x007888C9
	public override void OnFinish()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x040117A7 RID: 71591
	private List<int> skillIds = new List<int>();

	// Token: 0x040117A8 RID: 71592
	private BeEventHandle handle;
}
