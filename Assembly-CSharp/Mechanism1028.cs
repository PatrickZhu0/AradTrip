using System;

// Token: 0x02004264 RID: 16996
public class Mechanism1028 : BeMechanism
{
	// Token: 0x06017847 RID: 96327 RVA: 0x0073C2D7 File Offset: 0x0073A6D7
	public Mechanism1028(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017848 RID: 96328 RVA: 0x0073C2E4 File Offset: 0x0073A6E4
	public override void OnInit()
	{
		base.OnInit();
		this.xReboundFlag = (TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) != 0);
		this.yReboundFlag = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) != 0);
		this.zSpeedReverseFlag = (TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) != 0);
	}

	// Token: 0x06017849 RID: 96329 RVA: 0x0073C393 File Offset: 0x0073A793
	public override void OnStart()
	{
		base.OnStart();
		this.RegisterTouchBoundary();
	}

	// Token: 0x0601784A RID: 96330 RVA: 0x0073C3A1 File Offset: 0x0073A7A1
	private void RegisterTouchBoundary()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onXInBlock, delegate(object[] args)
		{
			this.XRebound();
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onYInBlock, delegate(object[] args)
		{
			this.YRebound();
		});
	}

	// Token: 0x0601784B RID: 96331 RVA: 0x0073C3E4 File Offset: 0x0073A7E4
	private void XRebound()
	{
		if (!this.xReboundFlag)
		{
			return;
		}
		base.owner.SetMoveSpeedX(-base.owner.moveXSpeed);
		if (this.zSpeedReverseFlag)
		{
			base.owner.SetMoveSpeedZ(-base.owner.moveZSpeed);
		}
	}

	// Token: 0x0601784C RID: 96332 RVA: 0x0073C440 File Offset: 0x0073A840
	private void YRebound()
	{
		if (!this.yReboundFlag)
		{
			return;
		}
		base.owner.SetMoveSpeedY(-base.owner.moveYSpeed);
		if (this.zSpeedReverseFlag)
		{
			base.owner.SetMoveSpeedZ(-base.owner.moveZSpeed);
		}
	}

	// Token: 0x04010E63 RID: 69219
	private bool xReboundFlag;

	// Token: 0x04010E64 RID: 69220
	private bool yReboundFlag;

	// Token: 0x04010E65 RID: 69221
	private bool zSpeedReverseFlag;
}
