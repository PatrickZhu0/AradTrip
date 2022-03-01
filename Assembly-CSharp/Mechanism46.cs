using System;

// Token: 0x020043ED RID: 17389
public class Mechanism46 : BeMechanism
{
	// Token: 0x0601822B RID: 98859 RVA: 0x00781624 File Offset: 0x0077FA24
	public Mechanism46(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601822C RID: 98860 RVA: 0x00781630 File Offset: 0x0077FA30
	public override void OnInit()
	{
		base.OnInit();
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.duration = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x0601822D RID: 98861 RVA: 0x00781693 File Offset: 0x0077FA93
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x0601822E RID: 98862 RVA: 0x0078169B File Offset: 0x0077FA9B
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
	}

	// Token: 0x0601822F RID: 98863 RVA: 0x007816A4 File Offset: 0x0077FAA4
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.OnGrab, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && beActor.buffController.HasBuffByID(this.buffID) == null)
			{
				beActor.buffController.TryAddBuff(this.buffID, this.duration, 1);
			}
		});
	}

	// Token: 0x06018230 RID: 98864 RVA: 0x007816CB File Offset: 0x0077FACB
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04011689 RID: 71305
	private int buffID;

	// Token: 0x0401168A RID: 71306
	private new int duration;
}
