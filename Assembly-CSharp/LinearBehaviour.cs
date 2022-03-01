using System;
using UnityEngine;

// Token: 0x02004501 RID: 17665
public class LinearBehaviour : TrailBehaviour
{
	// Token: 0x0601894E RID: 100686 RVA: 0x007ADA87 File Offset: 0x007ABE87
	public LinearBehaviour()
	{
		this.Type = TrailType.LINER;
		this.totalDist = 0f;
	}

	// Token: 0x0601894F RID: 100687 RVA: 0x007ADAA4 File Offset: 0x007ABEA4
	public override void Init()
	{
		base.Init();
		this.totalDist = (this.StartPoint - this.EndPoint).magnitude;
		this.currentPos = this.StartPoint;
		this.velocity = (this.EndPoint - this.StartPoint).normalized;
	}

	// Token: 0x06018950 RID: 100688 RVA: 0x007ADB04 File Offset: 0x007ABF04
	public override void OnTick(int deltaTime)
	{
		if (this.ReachDest)
		{
			return;
		}
		this.TimeAcc += (float)deltaTime;
		Vector3 vector = base.GetMoveDir() * this.MoveSpeed * (float)deltaTime / 1000f;
		this.currentPos += vector;
	}
}
