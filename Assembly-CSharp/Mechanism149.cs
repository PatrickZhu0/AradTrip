using System;
using System.Collections.Generic;

// Token: 0x0200431E RID: 17182
public class Mechanism149 : BeMechanism
{
	// Token: 0x06017C62 RID: 97378 RVA: 0x00756CE7 File Offset: 0x007550E7
	public Mechanism149(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C63 RID: 97379 RVA: 0x00756D20 File Offset: 0x00755120
	public override void OnInit()
	{
		base.OnInit();
		this.cd = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueC.Count > 0)
		{
			for (int i = 0; i < this.data.ValueC.Count; i++)
			{
				this.hpList.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
			}
		}
		if (this.data.ValueC.Count > 0)
		{
			for (int j = 0; j < this.data.ValueC.Count; j++)
			{
				this.rateList.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
			}
		}
	}

	// Token: 0x06017C64 RID: 97380 RVA: 0x00756E23 File Offset: 0x00755223
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHitOther, delegate(object[] args)
		{
			if (this.inCD || this.hpList.Count != 4 || this.rateList.Count != 4)
			{
				return;
			}
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.stateController.HasBuffState(BeBuffStateType.BLEEDING))
			{
				VFactor hprate = beActor.GetEntityData().GetHPRate();
				bool flag = false;
				if (hprate <= VFactor.NewVFactor(this.hpList[0], 100))
				{
					if ((int)base.owner.FrameRandom.Range100() <= this.rateList[0])
					{
						flag = true;
					}
				}
				else if (hprate <= VFactor.NewVFactor(this.hpList[1], 100))
				{
					if ((int)base.owner.FrameRandom.Range100() <= this.rateList[1])
					{
						flag = true;
					}
				}
				else if (hprate <= VFactor.NewVFactor(this.hpList[2], 100))
				{
					if ((int)base.owner.FrameRandom.Range100() <= this.rateList[2])
					{
						flag = true;
					}
				}
				else if (hprate <= VFactor.NewVFactor(this.hpList[3], 100) && (int)base.owner.FrameRandom.Range100() <= this.rateList[3])
				{
					flag = true;
				}
				if (flag)
				{
					this.inCD = true;
					base.owner.AddEntity(this.entityID, beActor.GetPosition(), this.level, 1200);
				}
			}
		});
	}

	// Token: 0x06017C65 RID: 97381 RVA: 0x00756E4C File Offset: 0x0075524C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.inCD)
		{
			this.timer += deltaTime;
			if (this.timer >= this.cd)
			{
				this.inCD = false;
				this.timer = 0;
			}
		}
	}

	// Token: 0x04011197 RID: 70039
	private int cd = GlobalLogic.VALUE_10000;

	// Token: 0x04011198 RID: 70040
	private bool inCD;

	// Token: 0x04011199 RID: 70041
	private int entityID = 61001;

	// Token: 0x0401119A RID: 70042
	private List<int> hpList = new List<int>();

	// Token: 0x0401119B RID: 70043
	private List<int> rateList = new List<int>();

	// Token: 0x0401119C RID: 70044
	private int timer;
}
