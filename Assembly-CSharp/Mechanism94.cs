using System;

// Token: 0x02004420 RID: 17440
public class Mechanism94 : BeMechanism
{
	// Token: 0x06018390 RID: 99216 RVA: 0x0078B36B File Offset: 0x0078976B
	public Mechanism94(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018391 RID: 99217 RVA: 0x0078B378 File Offset: 0x00789778
	public override void OnInit()
	{
		this.wearSlotType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.buffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06018392 RID: 99218 RVA: 0x0078B3D5 File Offset: 0x007897D5
	public override void OnStart()
	{
		base.OnStart();
		this.CheckEquipStrength();
		this.handleA = base.owner.RegisterEvent(BeEventType.OnChangeWeaponEnd, delegate(object[] args)
		{
			this.CheckEquipStrength();
		});
	}

	// Token: 0x06018393 RID: 99219 RVA: 0x0078B404 File Offset: 0x00789804
	private void CheckEquipStrength()
	{
		BeBuff beBuff = base.owner.buffController.HasBuffByID(this.buffId);
		if (beBuff != null)
		{
			base.owner.buffController.RemoveBuff(beBuff);
		}
		int equipsStrengthBySlot = BeUtility.GetEquipsStrengthBySlot(base.owner, this.wearSlotType);
		if (equipsStrengthBySlot > 0)
		{
			base.owner.buffController.TryAddBuff(this.buffId, int.MaxValue, equipsStrengthBySlot);
		}
	}

	// Token: 0x06018394 RID: 99220 RVA: 0x0078B475 File Offset: 0x00789875
	protected void RemoveBuff()
	{
		base.owner.buffController.RemoveBuff(this.buffId, 0, 0);
	}

	// Token: 0x06018395 RID: 99221 RVA: 0x0078B48F File Offset: 0x0078988F
	public override void OnFinish()
	{
		this.RemoveBuff();
	}

	// Token: 0x040117C7 RID: 71623
	protected int wearSlotType;

	// Token: 0x040117C8 RID: 71624
	protected int buffId;
}
