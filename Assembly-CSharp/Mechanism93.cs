using System;
using System.Collections.Generic;

// Token: 0x0200441F RID: 17439
public class Mechanism93 : BeMechanism
{
	// Token: 0x06018387 RID: 99207 RVA: 0x0078B056 File Offset: 0x00789456
	public Mechanism93(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018388 RID: 99208 RVA: 0x0078B088 File Offset: 0x00789488
	public override void OnInit()
	{
		this.buffAttachType = (BuffAttachType)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Count; i++)
		{
			this.effectOrBuffIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		this.attachRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06018389 RID: 99209 RVA: 0x0078B134 File Offset: 0x00789534
	public override void OnStart()
	{
		if (this.buffAttachType == BuffAttachType.EFFECTTABLE)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBuffAttackRate, delegate(object[] args)
			{
				BuffAttachType buffAttachType = (BuffAttachType)args[0];
				int item = (int)args[1];
				if (buffAttachType == this.buffAttachType && this.effectOrBuffIdList.Contains(item))
				{
					int[] curRateArray = (int[])args[2];
					this.ChangeBuffAttachRate(curRateArray);
				}
			});
		}
		else if (this.buffAttachType == BuffAttachType.BUFFINFO)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onBeforeHit, delegate(object[] args)
			{
				BeActor beActor = (BeActor)args[0];
				if (beActor != null && !this.targetList.Contains(beActor.GetPID()))
				{
					BeEventHandle item = beActor.RegisterEvent(BeEventType.onChangeBuffAttackRate, delegate(object[] args1)
					{
						BuffAttachType buffAttachType = (BuffAttachType)args1[0];
						int item2 = (int)args1[1];
						BeActor beActor2 = (BeActor)args1[3];
						if (buffAttachType == this.buffAttachType && this.effectOrBuffIdList.Contains(item2) && base.owner.GetPID() == beActor2.GetPID())
						{
							int[] curRateArray = (int[])args1[2];
							this.ChangeBuffAttachRate(curRateArray);
						}
					});
					this.targetList.Add(beActor.GetPID());
					this.handleList.Add(item);
				}
			});
		}
	}

	// Token: 0x0601838A RID: 99210 RVA: 0x0078B1A0 File Offset: 0x007895A0
	protected void ChangeBuffAttachRate(int[] curRateArray)
	{
		int num = curRateArray[0] + this.attachRate;
		num = ((num <= 1000) ? num : 1000);
		num = ((num >= 0) ? num : 0);
		curRateArray[0] = num;
	}

	// Token: 0x0601838B RID: 99211 RVA: 0x0078B1E2 File Offset: 0x007895E2
	public override void OnFinish()
	{
		this.targetList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x0601838C RID: 99212 RVA: 0x0078B1F8 File Offset: 0x007895F8
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x040117C2 RID: 71618
	protected BuffAttachType buffAttachType = BuffAttachType.NONE;

	// Token: 0x040117C3 RID: 71619
	protected List<int> effectOrBuffIdList = new List<int>();

	// Token: 0x040117C4 RID: 71620
	protected int attachRate;

	// Token: 0x040117C5 RID: 71621
	protected List<int> targetList = new List<int>();

	// Token: 0x040117C6 RID: 71622
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
