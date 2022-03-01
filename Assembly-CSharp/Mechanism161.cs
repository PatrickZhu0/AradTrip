using System;
using System.Collections.Generic;

// Token: 0x0200432A RID: 17194
public class Mechanism161 : BeMechanism
{
	// Token: 0x06017C9F RID: 97439 RVA: 0x007584C1 File Offset: 0x007568C1
	public Mechanism161(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017CA0 RID: 97440 RVA: 0x007584EC File Offset: 0x007568EC
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.innerRanges.Add(VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true), GlobalLogic.VALUE_1000));
		}
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.outerRanges.Add(VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true), GlobalLogic.VALUE_1000));
		}
		for (int k = 0; k < this.data.ValueC.Length; k++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[k], this.level, true);
			this.damageFactors.Add(new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_1000));
		}
	}

	// Token: 0x06017CA1 RID: 97441 RVA: 0x00758605 File Offset: 0x00756A05
	public override void OnStart()
	{
		if (base.owner == null)
		{
			return;
		}
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args)
		{
			int[] array = args[0] as int[];
			BeActor beActor = args[1] as BeActor;
			if (beActor == null)
			{
				return;
			}
			int magnitude = (beActor.GetPosition2() - base.owner.GetPosition2()).magnitude;
			for (int i = 0; i < this.innerRanges.Count; i++)
			{
				VInt b = this.innerRanges[i];
				if (i >= this.outerRanges.Count)
				{
					Logger.LogErrorFormat("mechanismID {0} out range is not right number {1}", new object[]
					{
						this.mechianismID,
						this.outerRanges.Count
					});
					break;
				}
				VInt b2 = this.outerRanges[i];
				if (i >= this.damageFactors.Count)
				{
					Logger.LogErrorFormat("mechanismID {0} vFactor is not  right number {1}", new object[]
					{
						this.mechianismID,
						this.damageFactors.Count
					});
					break;
				}
				if (magnitude >= b && magnitude <= b2)
				{
					array[0] = array[0] * (VFactor.one + this.damageFactors[i]);
					return;
				}
			}
		});
	}

	// Token: 0x040111D0 RID: 70096
	private List<VInt> innerRanges = new List<VInt>();

	// Token: 0x040111D1 RID: 70097
	private List<VInt> outerRanges = new List<VInt>();

	// Token: 0x040111D2 RID: 70098
	private List<VFactor> damageFactors = new List<VFactor>();
}
