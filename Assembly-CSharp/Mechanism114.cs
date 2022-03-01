using System;

// Token: 0x020042BE RID: 17086
internal class Mechanism114 : BeMechanism
{
	// Token: 0x06017A42 RID: 96834 RVA: 0x00748ADA File Offset: 0x00746EDA
	public Mechanism114(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A43 RID: 96835 RVA: 0x00748AE4 File Offset: 0x00746EE4
	public override void OnInit()
	{
		this.buffinfoIdArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.buffinfoIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.rangeRadiusRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.targetRadiusRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.monsterId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x06017A44 RID: 96836 RVA: 0x00748BD0 File Offset: 0x00746FD0
	public override void OnStart()
	{
		if (this.monsterId == 0)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBuffRangeRadius, delegate(object[] args)
			{
				int value = (int)args[0];
				if (Array.IndexOf<int>(this.buffinfoIdArray, value) != -1)
				{
					int[] array = (int[])args[1];
					array[0] += this.rangeRadiusRate;
				}
			});
			this.handleB = base.owner.RegisterEvent(BeEventType.onChangeBuffTargetRadius, delegate(object[] args)
			{
				int value = (int)args[0];
				if (Array.IndexOf<int>(this.buffinfoIdArray, value) != -1)
				{
					int[] array = (int[])args[1];
					array[0] += this.targetRadiusRate;
				}
			});
		}
		else
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetEntityData().MonsterIDEqual(this.monsterId))
				{
					beActor.RegisterEvent(BeEventType.onChangeBuffRangeRadius, delegate(object[] args1)
					{
						int value = (int)args1[0];
						if (Array.IndexOf<int>(this.buffinfoIdArray, value) != -1)
						{
							int[] array = (int[])args1[1];
							array[0] += this.rangeRadiusRate;
						}
					});
					beActor.RegisterEvent(BeEventType.onChangeBuffTargetRadius, delegate(object[] args2)
					{
						int value = (int)args2[0];
						if (Array.IndexOf<int>(this.buffinfoIdArray, value) != -1)
						{
							int[] array = (int[])args2[1];
							array[0] += this.targetRadiusRate;
						}
					});
				}
			});
		}
	}

	// Token: 0x04010FCB RID: 69579
	private int[] buffinfoIdArray;

	// Token: 0x04010FCC RID: 69580
	private int targetRadiusRate;

	// Token: 0x04010FCD RID: 69581
	private int rangeRadiusRate;

	// Token: 0x04010FCE RID: 69582
	private int monsterId;
}
