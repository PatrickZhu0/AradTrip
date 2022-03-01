using System;
using System.Collections.Generic;

// Token: 0x0200431A RID: 17178
public class Mechanism145 : BeMechanism
{
	// Token: 0x06017C57 RID: 97367 RVA: 0x007568CC File Offset: 0x00754CCC
	public Mechanism145(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C58 RID: 97368 RVA: 0x007568EC File Offset: 0x00754CEC
	public override void OnInit()
	{
		this.maxMonsterCount = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.minMonsterCount = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		for (int i = 0; i < this.data.ValueC.Length; i++)
		{
			this.buffInfoIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[i], this.level, true));
		}
	}

	// Token: 0x06017C59 RID: 97369 RVA: 0x00756997 File Offset: 0x00754D97
	public override void OnStart()
	{
		this.durTime = 0;
		this.mLastStat = Mechanism145.BUFF_STAT.NONE;
	}

	// Token: 0x06017C5A RID: 97370 RVA: 0x007569A8 File Offset: 0x00754DA8
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (base.owner == null)
		{
			return;
		}
		this.durTime += deltaTime;
		if (this.durTime < this.interval)
		{
			return;
		}
		this.durTime -= this.interval;
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
		Mechanism145.BUFF_STAT buff_STAT = Mechanism145.BUFF_STAT.NONE;
		if (num >= this.maxMonsterCount)
		{
			buff_STAT = Mechanism145.BUFF_STAT.ADD;
		}
		else if (num <= this.minMonsterCount)
		{
			buff_STAT = Mechanism145.BUFF_STAT.REMOVE;
		}
		if (this.mLastStat == buff_STAT)
		{
			return;
		}
		this.mLastStat = buff_STAT;
		if (this.mLastStat == Mechanism145.BUFF_STAT.ADD)
		{
			for (int j = 0; j < this.buffInfoIds.Count; j++)
			{
				base.owner.buffController.AddTriggerBuff(this.buffInfoIds[j], 0);
			}
		}
		else if (this.mLastStat == Mechanism145.BUFF_STAT.REMOVE)
		{
			for (int k = 0; k < this.buffInfoIds.Count; k++)
			{
				base.owner.buffController.RemoveBuffByBuffInfoID(this.buffInfoIds[k]);
			}
		}
	}

	// Token: 0x04011189 RID: 70025
	private int maxMonsterCount;

	// Token: 0x0401118A RID: 70026
	private int minMonsterCount;

	// Token: 0x0401118B RID: 70027
	private List<int> buffInfoIds = new List<int>();

	// Token: 0x0401118C RID: 70028
	private int durTime;

	// Token: 0x0401118D RID: 70029
	private int interval = 500;

	// Token: 0x0401118E RID: 70030
	private Mechanism145.BUFF_STAT mLastStat;

	// Token: 0x0200431B RID: 17179
	private enum BUFF_STAT
	{
		// Token: 0x04011190 RID: 70032
		NONE,
		// Token: 0x04011191 RID: 70033
		ADD,
		// Token: 0x04011192 RID: 70034
		REMOVE
	}
}
