using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x02004269 RID: 17001
public class Mechanism1032 : BeMechanism
{
	// Token: 0x06017870 RID: 96368 RVA: 0x0073D14E File Offset: 0x0073B54E
	public Mechanism1032(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06017871 RID: 96369 RVA: 0x0073D164 File Offset: 0x0073B564
	public override void OnInit()
	{
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffInfoIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.buffInfoIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
	}

	// Token: 0x06017872 RID: 96370 RVA: 0x0073D1ED File Offset: 0x0073B5ED
	public override void OnStart()
	{
		base.OnStart();
		this.CheckMonsterExist();
	}

	// Token: 0x06017873 RID: 96371 RVA: 0x0073D1FC File Offset: 0x0073B5FC
	private void CheckMonsterExist()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, this.monsterId, false);
		if (list.Count > 0)
		{
			base.owner.buffController.TryAddBuff(this.buffInfoIdArr[0], null, false, null, 0);
		}
		else
		{
			base.owner.buffController.TryAddBuff(this.buffInfoIdArr[1], null, false, null, 0);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x04010E7B RID: 69243
	protected int monsterId;

	// Token: 0x04010E7C RID: 69244
	protected int[] buffInfoIdArr = new int[2];
}
