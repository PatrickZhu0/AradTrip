using System;
using UnityEngine;

// Token: 0x02004502 RID: 17666
public class BoomerangBehaviour : TrailBehaviour
{
	// Token: 0x06018951 RID: 100689 RVA: 0x007ADB61 File Offset: 0x007ABF61
	public BoomerangBehaviour()
	{
		this.Type = TrailType.BOOMRANGE;
		this.state = BoomerangBehaviour.Phase.GO;
	}

	// Token: 0x06018952 RID: 100690 RVA: 0x007ADB82 File Offset: 0x007ABF82
	public override void Init()
	{
		base.Init();
		this.end = false;
		this.InitStat(BoomerangBehaviour.Phase.GO);
	}

	// Token: 0x06018953 RID: 100691 RVA: 0x007ADB98 File Offset: 0x007ABF98
	public void InitStat(BoomerangBehaviour.Phase state)
	{
		this.state = state;
		if (state == BoomerangBehaviour.Phase.GO)
		{
			this.totalDist = (this.StartPoint - this.EndPoint).magnitude;
			this.currentPos = this.StartPoint;
			this.velocity = (this.EndPoint - this.StartPoint).normalized;
			this.velocity.y = 0f;
		}
		else if (state == BoomerangBehaviour.Phase.STAY)
		{
			this.timeAcc = 0;
		}
		else if (state == BoomerangBehaviour.Phase.BACK)
		{
			this.StartPoint = this.EndPoint;
			this.EndPoint = this.target.GetGePosition();
			this.currentPos = this.StartPoint;
			this.velocity = (this.EndPoint - this.StartPoint).normalized;
			this.velocity.y = 0f;
			base.SetTotalDist(100f);
		}
	}

	// Token: 0x06018954 RID: 100692 RVA: 0x007ADC90 File Offset: 0x007AC090
	public override void OnTick(int deltaTime)
	{
		if (this.state == BoomerangBehaviour.Phase.GO)
		{
			this.TimeAcc += (float)deltaTime;
			Vector3 vector = base.GetMoveDir() * this.MoveSpeed * (float)deltaTime / 1000f;
			this.currentPos += vector;
			if (this.ReachEndPoint())
			{
				this.InitStat(BoomerangBehaviour.Phase.STAY);
			}
		}
		else if (this.state == BoomerangBehaviour.Phase.STAY)
		{
			this.timeAcc += deltaTime;
			if (this.timeAcc >= this.stayDuration)
			{
				this.InitStat(BoomerangBehaviour.Phase.BACK);
			}
		}
		else if (this.state == BoomerangBehaviour.Phase.BACK)
		{
			this.TimeAcc += (float)deltaTime;
			Vector3 vector2 = base.GetMoveDir() * this.MoveSpeed * (float)deltaTime / 1000f;
			this.currentPos += vector2;
			if (this.ReachTargetActorPos() && !this.end)
			{
				this.end = true;
				this.target.TriggerEvent(BeEventType.onBoomerangHit, new object[]
				{
					this.owner
				});
			}
		}
	}

	// Token: 0x06018955 RID: 100693 RVA: 0x007ADDC4 File Offset: 0x007AC1C4
	public bool ReachEndPoint()
	{
		return (this.currentPos - this.EndPoint).magnitude < 0.2f;
	}

	// Token: 0x06018956 RID: 100694 RVA: 0x007ADDF4 File Offset: 0x007AC1F4
	public bool ReachTargetActorPos()
	{
		return Mathf.Abs(this.target.GetGePosition().x - this.currentPos.x) < 0.2f;
	}

	// Token: 0x04011BBC RID: 72636
	private BoomerangBehaviour.Phase state;

	// Token: 0x04011BBD RID: 72637
	private int timeAcc;

	// Token: 0x04011BBE RID: 72638
	public int stayDuration = 2000;

	// Token: 0x04011BBF RID: 72639
	public int userData;

	// Token: 0x04011BC0 RID: 72640
	private bool end;

	// Token: 0x02004503 RID: 17667
	public enum Phase
	{
		// Token: 0x04011BC2 RID: 72642
		GO,
		// Token: 0x04011BC3 RID: 72643
		STAY,
		// Token: 0x04011BC4 RID: 72644
		BACK,
		// Token: 0x04011BC5 RID: 72645
		END
	}
}
