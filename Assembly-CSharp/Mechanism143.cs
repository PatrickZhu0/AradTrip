using System;

// Token: 0x02004317 RID: 17175
public class Mechanism143 : BeMechanism
{
	// Token: 0x06017C4E RID: 97358 RVA: 0x0075613C File Offset: 0x0075453C
	public Mechanism143(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C4F RID: 97359 RVA: 0x00756146 File Offset: 0x00754546
	public override void OnInit()
	{
		this.damageValue = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x06017C50 RID: 97360 RVA: 0x00756170 File Offset: 0x00754570
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeHurtValue, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			array[0] = this.damageValue;
		});
	}

	// Token: 0x0401117B RID: 70011
	public int damageValue;
}
