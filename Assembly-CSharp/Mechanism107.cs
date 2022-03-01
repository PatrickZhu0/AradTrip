using System;

// Token: 0x02004290 RID: 17040
internal class Mechanism107 : BeMechanism
{
	// Token: 0x06017938 RID: 96568 RVA: 0x0074202A File Offset: 0x0074042A
	public Mechanism107(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017939 RID: 96569 RVA: 0x00742034 File Offset: 0x00740434
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
		this.buffAttackRate = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.parentMechanism = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x0601793A RID: 96570 RVA: 0x0074215D File Offset: 0x0074055D
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeBuffAttack, delegate(object[] args)
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
				array[0] += this.buffAttackRate;
			}
		});
	}

	// Token: 0x04010F12 RID: 69394
	private int[] effectIdArray;

	// Token: 0x04010F13 RID: 69395
	private int[] buffinfoIdArray;

	// Token: 0x04010F14 RID: 69396
	private int buffAttackRate;

	// Token: 0x04010F15 RID: 69397
	private int parentMechanism;
}
