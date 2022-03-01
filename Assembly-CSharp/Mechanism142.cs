using System;

// Token: 0x02004316 RID: 17174
public class Mechanism142 : BeMechanism
{
	// Token: 0x06017C4A RID: 97354 RVA: 0x00756053 File Offset: 0x00754453
	public Mechanism142(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C4B RID: 97355 RVA: 0x0075606C File Offset: 0x0075446C
	public override void OnInit()
	{
		base.OnInit();
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.removeBuffId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017C4C RID: 97356 RVA: 0x007560D9 File Offset: 0x007544D9
	public override void OnStart()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onChangeClickForce, delegate(object[] args)
		{
			VInt[] array = (VInt[])args[0];
			array[0] = this.speed;
			base.owner.buffController.RemoveBuff(this.removeBuffId, 0, 0);
		});
	}

	// Token: 0x04011179 RID: 70009
	protected VInt speed = 10;

	// Token: 0x0401117A RID: 70010
	protected int removeBuffId;
}
