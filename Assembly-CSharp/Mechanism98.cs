using System;

// Token: 0x02004423 RID: 17443
public class Mechanism98 : BeMechanism
{
	// Token: 0x060183A6 RID: 99238 RVA: 0x0078B7DC File Offset: 0x00789BDC
	public Mechanism98(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060183A7 RID: 99239 RVA: 0x0078B7E6 File Offset: 0x00789BE6
	public override void OnInit()
	{
		base.OnInit();
		this.speed = new VRate(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true));
	}

	// Token: 0x060183A8 RID: 99240 RVA: 0x0078B81C File Offset: 0x00789C1C
	public override void OnStart()
	{
		base.OnStart();
		base.owner.aiManager.StopCurrentCommand();
		base.owner.aiManager.Stop();
		base.owner.ResetMoveCmd();
		this.target = base.owner.CurrentBeScene.FindNearestRangeTarget(base.owner.GetPosition(), base.owner, new VInt(int.MaxValue), null);
	}

	// Token: 0x060183A9 RID: 99241 RVA: 0x0078B88C File Offset: 0x00789C8C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.target != null)
		{
			VInt3 position = this.target.GetPosition();
			VInt3 position2 = base.owner.GetPosition();
			VInt3 vint = position - position2;
			if (vint.magnitude < 500)
			{
				return;
			}
			VInt3 rkPos = position2 + vint.NormalizeTo(10000) * this.speed.f;
			base.owner.SetPosition(rkPos, true, true, false);
		}
	}

	// Token: 0x060183AA RID: 99242 RVA: 0x0078B90F File Offset: 0x00789D0F
	public override void OnFinish()
	{
		base.OnFinish();
		this.target = null;
	}

	// Token: 0x040117D2 RID: 71634
	private BeActor target;

	// Token: 0x040117D3 RID: 71635
	private VRate speed;
}
