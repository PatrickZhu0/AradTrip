using System;
using UnityEngine;

// Token: 0x02004504 RID: 17668
public class ParabolaBehaviour : TrailBehaviour
{
	// Token: 0x06018957 RID: 100695 RVA: 0x007ADE2C File Offset: 0x007AC22C
	public ParabolaBehaviour()
	{
		this.Type = TrailType.PARABOLA;
		this.totalDist = 0f;
	}

	// Token: 0x06018958 RID: 100696 RVA: 0x007ADE68 File Offset: 0x007AC268
	public override void Init()
	{
		base.Init();
		this.TimeAcc = 0f;
		this.totalDist = Vector3.Distance(this.StartPoint, this.EndPoint);
		this.lastPos = this.StartPoint;
		this.currentPos = this.StartPoint;
		this.velocity = this.StartVelocity.normalized;
	}

	// Token: 0x06018959 RID: 100697 RVA: 0x007ADEC8 File Offset: 0x007AC2C8
	public override void OnTick(int deltaTime)
	{
		if (this.Status == TrailStatus.TRAIL_FLY)
		{
			this.TimeAcc += (float)deltaTime;
			float num = this.TimeAcc * 1f / this.TotalTime;
			this.DistPercent = num;
			num = 0.5f * this.TimeAcc * this.TimeAcc * this.TimeAccerlate / 1000f / 1000f;
			num /= this.totalDist;
			if (num > 1f)
			{
				num = 1f;
			}
			float num2 = num * num;
			float num3 = num2 * num;
			Vector3 currentPos = this.StartPoint * (2f * num3 - 3f * num2 + 1f) + this.EndPoint * (-2f * num3 + 3f * num2) + this.StartVelocity * (num3 - 2f * num2 + num) + this.EndVelocity * (num3 - num2);
			this.lastPos = this.currentPos;
			this.currentPos = currentPos;
			this.velocity = this.currentPos - this.lastPos;
			if (num >= 1f)
			{
				base.Stay();
			}
		}
		else if (this.Status == TrailStatus.TRAIL_STAY)
		{
			this.TimeAcc += (float)deltaTime;
			if (this.TimeAcc > this.StayTime)
			{
				base.End();
			}
		}
	}

	// Token: 0x04011BC6 RID: 72646
	public Vector3 StartVelocity;

	// Token: 0x04011BC7 RID: 72647
	public Vector3 EndVelocity;

	// Token: 0x04011BC8 RID: 72648
	public float TotalTime;

	// Token: 0x04011BC9 RID: 72649
	public float TimeStartTangent = 0.1f;

	// Token: 0x04011BCA RID: 72650
	public float TimeEndTangent = 1f;

	// Token: 0x04011BCB RID: 72651
	public float TimeAccerlate = 0.5f;

	// Token: 0x04011BCC RID: 72652
	private Vector3 lastPos;
}
