using System;
using System.Collections.Generic;

// Token: 0x02004284 RID: 17028
internal class Mechanism106 : BeMechanism
{
	// Token: 0x060178FB RID: 96507 RVA: 0x00740957 File Offset: 0x0073ED57
	public Mechanism106(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178FC RID: 96508 RVA: 0x00740978 File Offset: 0x0073ED78
	public override void OnInit()
	{
		this.effectId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.yForce = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.yForceRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.yForceFloating = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.yForceFloatingRate = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060178FD RID: 96509 RVA: 0x00740A4D File Offset: 0x0073EE4D
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			int num = (int)args[1];
			if (beActor != null && !this.targetList.Contains(beActor.GetPID()) && this.effectId == num)
			{
				this.targetList.Add(beActor.GetPID());
				BeEventHandle item = beActor.RegisterEvent(BeEventType.onChangeFloatingRate, delegate(object[] args1)
				{
					int num2 = (int)args1[0];
					if (this.effectId == num2)
					{
						int[] array = (int[])args1[1];
						array[0] += this.yForce;
						array[1] += this.yForceRate;
					}
				});
				this.handleList.Add(item);
				BeEventHandle item2 = beActor.RegisterEvent(BeEventType.onChangeFloatYForce, delegate(object[] args2)
				{
					int num2 = (int)args2[0];
					if (this.effectId == num2)
					{
						int[] array = (int[])args2[1];
						array[0] += this.yForceFloating;
						array[1] += this.yForceFloatingRate;
					}
				});
				this.handleList.Add(item2);
			}
		});
	}

	// Token: 0x060178FE RID: 96510 RVA: 0x00740A6E File Offset: 0x0073EE6E
	public override void OnFinish()
	{
		this.targetList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x060178FF RID: 96511 RVA: 0x00740A84 File Offset: 0x0073EE84
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x04010EE2 RID: 69346
	private int effectId;

	// Token: 0x04010EE3 RID: 69347
	private int yForce;

	// Token: 0x04010EE4 RID: 69348
	private int yForceRate;

	// Token: 0x04010EE5 RID: 69349
	private int yForceFloating;

	// Token: 0x04010EE6 RID: 69350
	private int yForceFloatingRate;

	// Token: 0x04010EE7 RID: 69351
	protected List<int> targetList = new List<int>();

	// Token: 0x04010EE8 RID: 69352
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
