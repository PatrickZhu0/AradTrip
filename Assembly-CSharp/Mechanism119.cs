using System;
using System.Collections.Generic;

// Token: 0x020042F3 RID: 17139
internal class Mechanism119 : BeMechanism
{
	// Token: 0x06017B76 RID: 97142 RVA: 0x0074F705 File Offset: 0x0074DB05
	public Mechanism119(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B77 RID: 97143 RVA: 0x0074F728 File Offset: 0x0074DB28
	public override void OnInit()
	{
		this.scaleRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.restoreFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) == 0);
	}

	// Token: 0x06017B78 RID: 97144 RVA: 0x0074F7B0 File Offset: 0x0074DBB0
	public override void OnStart()
	{
		if (this.monsterId == 0)
		{
			this.originalScale = base.owner.GetScale();
			int i = this.originalScale.i * VFactor.NewVFactor(GlobalLogic.VALUE_1000 + this.scaleRate, GlobalLogic.VALUE_1000);
			base.owner.SetScale(i);
		}
		else
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onChangeSummonScale, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.monsterId))
				{
					int[] array = (int[])args[1];
					array[0] += this.scaleRate;
					this.summonList.Add(beActor);
					this.originalScaleList.Add(beActor.GetScale());
				}
			});
		}
	}

	// Token: 0x06017B79 RID: 97145 RVA: 0x0074F838 File Offset: 0x0074DC38
	public override void OnFinish()
	{
		if (this.restoreFlag)
		{
			if (this.monsterId == 0)
			{
				base.owner.SetScale(this.originalScale);
			}
			else
			{
				for (int i = 0; i < this.summonList.Count; i++)
				{
					VInt scale = this.summonList[i].GetScale() - this.scaleRate;
					this.summonList[i].SetScale(scale);
				}
				this.originalScaleList.Clear();
			}
		}
	}

	// Token: 0x040110A4 RID: 69796
	private int scaleRate;

	// Token: 0x040110A5 RID: 69797
	private int monsterId;

	// Token: 0x040110A6 RID: 69798
	private List<BeActor> summonList = new List<BeActor>();

	// Token: 0x040110A7 RID: 69799
	private bool restoreFlag;

	// Token: 0x040110A8 RID: 69800
	private VInt originalScale;

	// Token: 0x040110A9 RID: 69801
	private List<VInt> originalScaleList = new List<VInt>();
}
