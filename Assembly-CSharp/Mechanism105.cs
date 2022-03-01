using System;

// Token: 0x0200427B RID: 17019
internal class Mechanism105 : BeMechanism
{
	// Token: 0x060178CD RID: 96461 RVA: 0x0073F4BE File Offset: 0x0073D8BE
	public Mechanism105(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060178CE RID: 96462 RVA: 0x0073F4C8 File Offset: 0x0073D8C8
	public override void OnInit()
	{
		this.effectIdArray = new int[this.data.ValueA.Length];
		for (int i = 0; i < this.data.ValueA.Length; i++)
		{
			this.effectIdArray[i] = TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true);
		}
		this.buffinfoIdArray = new int[this.data.ValueB.Length];
		for (int j = 0; j < this.data.ValueB.Length; j++)
		{
			this.buffinfoIdArray[j] = TableManager.GetValueFromUnionCell(this.data.ValueB[j], this.level, true);
		}
		this.addLevel = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.parentMechanism = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x060178CF RID: 96463 RVA: 0x0073F5F1 File Offset: 0x0073D9F1
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBuffLevel, delegate(object[] args)
		{
			BeActor beActor = (BeActor)args[3];
			if (this.parentMechanism != 0 && beActor.GetMechanism(this.parentMechanism) == null)
			{
				return;
			}
			int value = (int)args[0];
			int value2 = (int)args[1];
			if (Array.IndexOf<int>(this.effectIdArray, value) != -1 || Array.IndexOf<int>(this.buffinfoIdArray, value2) != -1)
			{
				int[] array = (int[])args[2];
				array[0] += this.addLevel;
			}
		});
	}

	// Token: 0x04010EBF RID: 69311
	private int[] effectIdArray;

	// Token: 0x04010EC0 RID: 69312
	private int[] buffinfoIdArray;

	// Token: 0x04010EC1 RID: 69313
	private int addLevel;

	// Token: 0x04010EC2 RID: 69314
	private int parentMechanism;
}
