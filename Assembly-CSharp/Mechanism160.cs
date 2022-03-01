using System;
using System.Collections.Generic;

// Token: 0x02004329 RID: 17193
public class Mechanism160 : BeMechanism
{
	// Token: 0x06017C9B RID: 97435 RVA: 0x0075829E File Offset: 0x0075669E
	public Mechanism160(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C9C RID: 97436 RVA: 0x007582C0 File Offset: 0x007566C0
	public override void OnInit()
	{
		this.monsterCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.useSkillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Length; i++)
		{
			this.skillIDs.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
	}

	// Token: 0x06017C9D RID: 97437 RVA: 0x0075836B File Offset: 0x0075676B
	public override void OnStart()
	{
	}

	// Token: 0x06017C9E RID: 97438 RVA: 0x00758370 File Offset: 0x00756770
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.bValid)
		{
			return;
		}
		if (base.owner == null)
		{
			return;
		}
		this.durTime += deltaTime;
		int num = 0;
		List<BeEntity> entities = base.owner.CurrentBeScene.GetEntities();
		for (int i = 0; i < entities.Count; i++)
		{
			BeActor beActor = entities[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && beActor.IsMonster() && !beActor.IsSkillMonster())
			{
				num++;
			}
		}
		if (num < this.monsterCount)
		{
			this.bValid = true;
			BeSkill skill = base.owner.GetSkill(this.useSkillID);
			if (skill != null)
			{
				int leftInitCd = skill.LeftInitCd;
				skill.AccTimeCD(leftInitCd);
				base.owner.UseSkill(this.useSkillID, true);
				for (int j = 0; j < this.skillIDs.Count; j++)
				{
					BeSkill skill2 = base.owner.GetSkill(this.skillIDs[j]);
					if (skill2 != null)
					{
						int cdtimeAcc = skill2.CDTimeAcc;
						if (cdtimeAcc > 0 && leftInitCd > 0)
						{
							skill2.AccTimeCD(leftInitCd);
						}
					}
				}
			}
		}
	}

	// Token: 0x040111CA RID: 70090
	private int monsterCount;

	// Token: 0x040111CB RID: 70091
	private int useSkillID;

	// Token: 0x040111CC RID: 70092
	private List<int> skillIDs = new List<int>();

	// Token: 0x040111CD RID: 70093
	private int durTime;

	// Token: 0x040111CE RID: 70094
	private int interval = 200;

	// Token: 0x040111CF RID: 70095
	private bool bValid;
}
