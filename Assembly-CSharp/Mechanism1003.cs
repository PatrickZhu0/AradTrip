using System;
using System.Collections.Generic;

// Token: 0x0200424B RID: 16971
public class Mechanism1003 : BeMechanism
{
	// Token: 0x060177B6 RID: 96182 RVA: 0x00738973 File Offset: 0x00736D73
	public Mechanism1003(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177B7 RID: 96183 RVA: 0x007389A0 File Offset: 0x00736DA0
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.effectIdList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.xForce = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.xForceRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.xForceFloating = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.xForceFloatingRate = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x060177B8 RID: 96184 RVA: 0x00738A9B File Offset: 0x00736E9B
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[0];
			int item = (int)args[1];
			if (beActor != null && !this.targetList.Contains(beActor.GetPID()) && this.effectIdList.Contains(item))
			{
				this.targetList.Add(beActor.GetPID());
				BeEventHandle item2 = beActor.RegisterEvent(BeEventType.onChangeXRate, delegate(object[] args1)
				{
					int item4 = (int)args1[0];
					if (this.effectIdList.Contains(item4))
					{
						int[] array = (int[])args1[1];
						array[0] += this.xForce;
						array[1] += this.xForceRate;
					}
				});
				this.handleList.Add(item2);
				BeEventHandle item3 = beActor.RegisterEvent(BeEventType.onChangeFloatXForce, delegate(object[] args2)
				{
					int item4 = (int)args2[0];
					if (this.effectIdList.Contains(item4))
					{
						int[] array = (int[])args2[1];
						array[0] += this.xForceFloating;
						array[1] += this.xForceFloatingRate;
					}
				});
				this.handleList.Add(item3);
			}
		});
	}

	// Token: 0x060177B9 RID: 96185 RVA: 0x00738ABC File Offset: 0x00736EBC
	public override void OnFinish()
	{
		this.targetList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x060177BA RID: 96186 RVA: 0x00738AD0 File Offset: 0x00736ED0
	protected void RemoveHandle()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			this.handleList[i].Remove();
			this.handleList[i] = null;
		}
		this.handleList.Clear();
	}

	// Token: 0x04010DF6 RID: 69110
	protected List<int> effectIdList = new List<int>();

	// Token: 0x04010DF7 RID: 69111
	protected int xForce;

	// Token: 0x04010DF8 RID: 69112
	protected int xForceRate;

	// Token: 0x04010DF9 RID: 69113
	protected int xForceFloating;

	// Token: 0x04010DFA RID: 69114
	protected int xForceFloatingRate;

	// Token: 0x04010DFB RID: 69115
	protected List<int> targetList = new List<int>();

	// Token: 0x04010DFC RID: 69116
	protected List<BeEventHandle> handleList = new List<BeEventHandle>();
}
