using System;
using System.Collections.Generic;

// Token: 0x02004323 RID: 17187
public class Mechanism151 : BeMechanism
{
	// Token: 0x06017C7F RID: 97407 RVA: 0x007577DE File Offset: 0x00755BDE
	public Mechanism151(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C80 RID: 97408 RVA: 0x007577F4 File Offset: 0x00755BF4
	public override void OnInit()
	{
		base.OnInit();
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.hurtIDList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.ownerBuffInfoID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.targetBuffInfoId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017C81 RID: 97409 RVA: 0x007578CD File Offset: 0x00755CCD
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
		{
			if (base.owner.buffController.HasBuffByID(this.buffID) != null)
			{
				BeActor beActor = args[0] as BeActor;
				int item = (int)args[2];
				if (beActor != null && this.hurtIDList.Contains(item))
				{
					if (this.ownerBuffInfoID != 0)
					{
						base.owner.buffController.TryAddBuffInfo(this.ownerBuffInfoID, base.owner, this.level);
					}
					if (this.targetBuffInfoId != 0)
					{
						beActor.buffController.TryAddBuffInfo(this.targetBuffInfoId, base.owner, this.level);
					}
				}
			}
		});
	}

	// Token: 0x040111B0 RID: 70064
	private int buffID;

	// Token: 0x040111B1 RID: 70065
	private List<int> hurtIDList = new List<int>();

	// Token: 0x040111B2 RID: 70066
	private int ownerBuffInfoID;

	// Token: 0x040111B3 RID: 70067
	private int targetBuffInfoId;
}
