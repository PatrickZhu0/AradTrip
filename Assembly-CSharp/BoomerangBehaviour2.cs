using System;
using GameClient;

// Token: 0x02004240 RID: 16960
public sealed class BoomerangBehaviour2 : LinearLogicTrial
{
	// Token: 0x06017781 RID: 96129 RVA: 0x00737406 File Offset: 0x00735806
	public BoomerangBehaviour2()
	{
		this.state = BoomerangBehaviour2.Phase.GO;
	}

	// Token: 0x06017782 RID: 96130 RVA: 0x00737420 File Offset: 0x00735820
	public override void Init()
	{
		this.end = false;
		this.InitStat(BoomerangBehaviour2.Phase.GO);
	}

	// Token: 0x06017783 RID: 96131 RVA: 0x00737430 File Offset: 0x00735830
	public void InitStat(BoomerangBehaviour2.Phase state)
	{
		this.state = state;
		if (state == BoomerangBehaviour2.Phase.GO)
		{
			this.currentPos = this.StartPoint;
			this.MoveDir = (this.EndPoint - this.StartPoint).NormalizeTo(10000);
			this.MoveDir.z = 0;
			this.MoveDir = this.MoveDir.NormalizeTo(10000);
		}
		else if (state == BoomerangBehaviour2.Phase.STAY)
		{
			this.timeAcc = 0;
		}
		else if (state == BoomerangBehaviour2.Phase.BACK)
		{
			this.StartPoint = this.EndPoint;
			if (this.target != null)
			{
				this.EndPoint = this.target.GetPosition();
			}
			this.currentPos = this.StartPoint;
			this.MoveDir = (this.EndPoint - this.StartPoint).NormalizeTo(10000);
			this.MoveDir.z = 0;
			this.MoveDir = this.MoveDir.NormalizeTo(10000);
		}
	}

	// Token: 0x06017784 RID: 96132 RVA: 0x00737538 File Offset: 0x00735938
	public override void OnTick(int deltaTime)
	{
		if (this.state == BoomerangBehaviour2.Phase.GO)
		{
			this.TimeAcc += deltaTime;
			VInt3 rhs = this.MoveDir * (VFactor.NewVFactor((long)deltaTime, 1000L) * this.MoveSpeed.factor);
			this.currentPos += rhs;
			if (this.ReachEndPoint())
			{
				this.InitStat(BoomerangBehaviour2.Phase.STAY);
			}
		}
		else if (this.state == BoomerangBehaviour2.Phase.STAY)
		{
			this.timeAcc += deltaTime;
			if (this.timeAcc >= this.stayDuration)
			{
				this.InitStat(BoomerangBehaviour2.Phase.BACK);
			}
		}
		else if (this.state == BoomerangBehaviour2.Phase.BACK)
		{
			this.TimeAcc += deltaTime;
			VInt3 rhs2 = this.MoveDir * (VFactor.NewVFactor((long)deltaTime, 1000L) * this.MoveSpeed.factor);
			this.currentPos += rhs2;
			if (this.target != null && this.target.CurrentBeBattle != null && this.target.CurrentBeBattle.FunctionIsOpen((BattleFlagType)(-2147483648)))
			{
				if (this.ReachTargetActorPos() && !this.end)
				{
					this.end = true;
					if (this.target != null)
					{
						this.target.TriggerEvent(BeEventType.onBoomerangHit, new object[]
						{
							this.owner
						});
					}
				}
			}
			else if (this.target != null && this.target.CurrentBeScene != null && this.ReachTargetActorPos() && !this.end && this.target.CurrentBeScene.IsInLogicScene(this.owner.GetPosition()))
			{
				this.end = true;
				this.target.TriggerEvent(BeEventType.onBoomerangHit, new object[]
				{
					this.owner
				});
			}
		}
	}

	// Token: 0x06017785 RID: 96133 RVA: 0x00737730 File Offset: 0x00735B30
	public bool ReachEndPoint()
	{
		int magnitude = (this.currentPos - this.EndPoint).magnitude;
		return magnitude < new VInt(0.2f);
	}

	// Token: 0x06017786 RID: 96134 RVA: 0x0073776C File Offset: 0x00735B6C
	public bool ReachTargetActorPos()
	{
		return Math.Abs(this.target.GetPosition().x - this.currentPos.x) < new VInt(0.2f);
	}

	// Token: 0x04010DC0 RID: 69056
	private BoomerangBehaviour2.Phase state;

	// Token: 0x04010DC1 RID: 69057
	private int timeAcc;

	// Token: 0x04010DC2 RID: 69058
	public int stayDuration = 2000;

	// Token: 0x04010DC3 RID: 69059
	public int userData;

	// Token: 0x04010DC4 RID: 69060
	private bool end;

	// Token: 0x04010DC5 RID: 69061
	public BeActor target;

	// Token: 0x04010DC6 RID: 69062
	public BeProjectile owner;

	// Token: 0x02004241 RID: 16961
	public enum Phase
	{
		// Token: 0x04010DC8 RID: 69064
		GO,
		// Token: 0x04010DC9 RID: 69065
		STAY,
		// Token: 0x04010DCA RID: 69066
		BACK,
		// Token: 0x04010DCB RID: 69067
		END
	}
}
