using System;
using System.Collections.Generic;

// Token: 0x02004341 RID: 17217
public class Mechanism2011 : BeMechanism
{
	// Token: 0x06017D4A RID: 97610 RVA: 0x0075CF1D File Offset: 0x0075B31D
	public Mechanism2011(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D4B RID: 97611 RVA: 0x0075CF40 File Offset: 0x0075B340
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffInfoList[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.buffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017D4C RID: 97612 RVA: 0x0075CFC8 File Offset: 0x0075B3C8
	public override void OnStart()
	{
		base.OnStart();
		base.owner.CurrentBeScene.FindMainActor(this.list);
		if (this.list.Count > 1)
		{
			int num = base.owner.FrameRandom.InRange(0, this.list.Count);
			for (int i = 0; i < this.list.Count; i++)
			{
				if (!this.IsJueXingSkill(this.list[i]) && !this.list[i].isSpecialMonster)
				{
					if (i == num)
					{
						this.list[i].buffController.TryAddBuff(this.buffInfoList[0], null, false, null, 0);
					}
					else
					{
						this.list[i].buffController.TryAddBuff(this.buffInfoList[1], null, false, null, 0);
					}
				}
			}
		}
		else if (this.list.Count == 1)
		{
			if (this.IsJueXingSkill(this.list[0]) || this.list[0].isSpecialMonster)
			{
				return;
			}
			this.list[0].buffController.TryAddBuff(this.buffInfoID, null, false, null, 0);
		}
	}

	// Token: 0x06017D4D RID: 97613 RVA: 0x0075D128 File Offset: 0x0075B528
	private bool IsJueXingSkill(BeActor actor)
	{
		BeSkill curSkill = actor.GetCurSkill();
		return curSkill != null && curSkill.skillData.SkillCategory == 4;
	}

	// Token: 0x06017D4E RID: 97614 RVA: 0x0075D156 File Offset: 0x0075B556
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04011269 RID: 70249
	private List<BeActor> list = new List<BeActor>();

	// Token: 0x0401126A RID: 70250
	private int[] buffInfoList = new int[2];

	// Token: 0x0401126B RID: 70251
	private int buffInfoID;
}
