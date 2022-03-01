using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004487 RID: 17543
public class Skill2105 : BeSkill
{
	// Token: 0x0601862E RID: 99886 RVA: 0x00799574 File Offset: 0x00797974
	public Skill2105(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601862F RID: 99887 RVA: 0x00799580 File Offset: 0x00797980
	public override void OnInit()
	{
		this.range = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
		this.effectIDCaster = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.effectIDEnemy = TableManager.GetValueFromUnionCell(this.skillData.ValueC[1], base.level, true);
	}

	// Token: 0x06018630 RID: 99888 RVA: 0x00799600 File Offset: 0x00797A00
	public override void OnPostInit()
	{
		this.removeNum = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x06018631 RID: 99889 RVA: 0x00799628 File Offset: 0x00797A28
	public override void OnFinish()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, this.range, false, null);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			beActor.buffController.DispelBuff(BuffWorkType.GAINBUFF, this.removeNum);
			base.AddBuff(beActor, this.effectIDEnemy);
			base.AddBuff(base.owner, this.effectIDCaster);
			beActor.m_pkGeActor.CreateEffect("Effects/Hero_Mage/Qusanmofa/Prefab/Eff_Qusan_hit_guo", "[actor]Orign", 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04011994 RID: 72084
	private VInt range;

	// Token: 0x04011995 RID: 72085
	private int removeNum;

	// Token: 0x04011996 RID: 72086
	private int effectIDCaster;

	// Token: 0x04011997 RID: 72087
	private int effectIDEnemy;
}
