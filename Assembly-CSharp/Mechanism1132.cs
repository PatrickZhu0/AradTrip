using System;

// Token: 0x020042B9 RID: 17081
public class Mechanism1132 : BeMechanism
{
	// Token: 0x06017A1F RID: 96799 RVA: 0x00747EFB File Offset: 0x007462FB
	public Mechanism1132(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A20 RID: 96800 RVA: 0x00747F08 File Offset: 0x00746308
	public override void OnInit()
	{
		base.OnInit();
		this._addTimeAcc = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this._addValue = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this._coefficient = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
	}

	// Token: 0x06017A21 RID: 96801 RVA: 0x00747F93 File Offset: 0x00746393
	public override void OnStart()
	{
		base.OnStart();
		this.InitAddValue();
		base.InitTimeAcc(this._addTimeAcc);
	}

	// Token: 0x06017A22 RID: 96802 RVA: 0x00747FAD File Offset: 0x007463AD
	public override void OnUpdateTimeAcc()
	{
		base.OnUpdateTimeAcc();
		this.AddHpValue();
	}

	// Token: 0x06017A23 RID: 96803 RVA: 0x00747FBC File Offset: 0x007463BC
	private void InitAddValue()
	{
		if (base.owner.GetEntityData() == null)
		{
			return;
		}
		VFactor a = VFactor.NewVFactor(base.owner.GetEntityData().battleData.sta, this._coefficient * GlobalLogic.VALUE_1000);
		VFactor f = a + VFactor.one;
		this._addValue *= f;
	}

	// Token: 0x06017A24 RID: 96804 RVA: 0x00748020 File Offset: 0x00746420
	private void AddHpValue()
	{
		if (this._addValue == 0)
		{
			return;
		}
		base.owner.DoHPChange(this._addValue, false);
		if (this._addValue < 0)
		{
			base.owner.TriggerEvent(BeEventType.OnBuffDamage, new object[]
			{
				-this._addValue,
				-1,
				base.owner
			});
		}
	}

	// Token: 0x04010FB5 RID: 69557
	private int _addTimeAcc;

	// Token: 0x04010FB6 RID: 69558
	private int _addValue;

	// Token: 0x04010FB7 RID: 69559
	private int _coefficient;
}
