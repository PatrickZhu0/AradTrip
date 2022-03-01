using System;
using System.Collections.Generic;

// Token: 0x0200424F RID: 16975
public class Mechanism1009 : BeMechanism
{
	// Token: 0x060177C7 RID: 96199 RVA: 0x0073902E File Offset: 0x0073742E
	public Mechanism1009(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177C8 RID: 96200 RVA: 0x00739044 File Offset: 0x00737444
	public override void OnInit()
	{
		base.OnInit();
		this.effectId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			for (int i = 0; i < this.data.ValueB.Count; i++)
			{
				this.buffInfoIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			this.isPlayer = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.addToOwner = (TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true) != 0);
		}
	}

	// Token: 0x060177C9 RID: 96201 RVA: 0x00739177 File Offset: 0x00737577
	public override void OnStart()
	{
		base.OnStart();
		base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor actor = (BeActor)args[0];
			int num = (int)args[1];
			if (num != this.effectId)
			{
				return;
			}
			if (this.CheckTargetCondition(actor))
			{
				this.AddBuffInfo();
			}
		});
	}

	// Token: 0x060177CA RID: 96202 RVA: 0x00739199 File Offset: 0x00737599
	private bool CheckTargetCondition(BeActor actor)
	{
		return actor != null && (!this.isPlayer || actor.isMainActor);
	}

	// Token: 0x060177CB RID: 96203 RVA: 0x007391B8 File Offset: 0x007375B8
	private void AddBuffInfo()
	{
		if (this.buffInfoIdList.Count <= 0)
		{
			return;
		}
		BeActor beActor = (BeActor)base.owner.GetOwner();
		BeActor beActor2 = base.owner;
		if (this.addToOwner && beActor != null)
		{
			beActor2 = beActor;
		}
		for (int i = 0; i < this.buffInfoIdList.Count; i++)
		{
			beActor2.buffController.TryAddBuff(this.buffInfoIdList[i], null, false, null, 0);
		}
	}

	// Token: 0x04010E08 RID: 69128
	private int effectId;

	// Token: 0x04010E09 RID: 69129
	private List<int> buffInfoIdList = new List<int>();

	// Token: 0x04010E0A RID: 69130
	private bool isPlayer;

	// Token: 0x04010E0B RID: 69131
	private bool addToOwner;
}
