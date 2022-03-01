using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x02004439 RID: 17465
public class Skill1109 : BeSkill
{
	// Token: 0x0601840A RID: 99338 RVA: 0x0078D507 File Offset: 0x0078B907
	public Skill1109(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601840B RID: 99339 RVA: 0x0078D514 File Offset: 0x0078B914
	public override void OnInit()
	{
		this.markProb = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.relatedSkills = BeSkill.GetEffectSkills(this.skillData.ValueB, base.level);
		this.effectIDCaster = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.effectIDTarget = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
	}

	// Token: 0x0601840C RID: 99340 RVA: 0x0078D5A6 File Offset: 0x0078B9A6
	public override void OnPostInit()
	{
		base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor target = args[0] as BeActor;
			int id = (int)args[1];
			EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(id, string.Empty, string.Empty);
			if (tableItem != null && this.relatedSkills.Contains(tableItem.SkillID) && (int)base.FrameRandom.Range1000() <= this.markProb)
			{
				this.DoWork(target);
			}
		});
	}

	// Token: 0x0601840D RID: 99341 RVA: 0x0078D5C2 File Offset: 0x0078B9C2
	private void DoWork(BeActor target)
	{
		if (target != null)
		{
			base.AddBuff(target, this.effectIDTarget);
		}
		if (base.owner != null)
		{
			base.AddBuff(base.owner, this.effectIDCaster);
		}
	}

	// Token: 0x04011805 RID: 71685
	private int markProb;

	// Token: 0x04011806 RID: 71686
	private List<int> relatedSkills;

	// Token: 0x04011807 RID: 71687
	private int effectIDCaster;

	// Token: 0x04011808 RID: 71688
	private int effectIDTarget;
}
