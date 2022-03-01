using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004509 RID: 17673
public class TrailManagerImp
{
	// Token: 0x06018972 RID: 100722 RVA: 0x007AE04E File Offset: 0x007AC44E
	private bool CheckCanRemove(TrailBehaviour trail)
	{
		return trail.IsDead();
	}

	// Token: 0x06018973 RID: 100723 RVA: 0x007AE058 File Offset: 0x007AC458
	public void Update(int delta)
	{
		if (this.isDirty)
		{
			this._RemoveTrail();
		}
		this.timeAcc += delta;
		if (this.timeAcc >= this.interval)
		{
			this.timeAcc -= this.interval;
			for (int i = 0; i < this.trails.Count; i++)
			{
				TrailBehaviour trailBehaviour = this.trails[i];
				if (!this.CheckCanRemove(trailBehaviour))
				{
					trailBehaviour.Tick(this.interval);
				}
				else
				{
					this.isDirty = true;
				}
			}
			return;
		}
	}

	// Token: 0x06018974 RID: 100724 RVA: 0x007AE0FB File Offset: 0x007AC4FB
	private void _RemoveTrail()
	{
		this.trails.RemoveAll(new Predicate<TrailBehaviour>(this.CheckCanRemove));
		this.isDirty = false;
	}

	// Token: 0x06018975 RID: 100725 RVA: 0x007AE11C File Offset: 0x007AC51C
	public ParabolaBehaviour AddParabolaTrail(Vector3 startPos, BeActor target, Vector3 startVel, Vector3 endVel, string effectPath = null)
	{
		ParabolaBehaviour parabolaBehaviour = new ParabolaBehaviour();
		parabolaBehaviour.StartVelocity = startVel;
		parabolaBehaviour.EndVelocity = endVel;
		parabolaBehaviour.TotalTime = 2000f;
		parabolaBehaviour.TimeAccerlate = 100f;
		parabolaBehaviour.StartPoint = startPos;
		parabolaBehaviour.EndPoint = target.GetGePosition();
		parabolaBehaviour.Start();
		parabolaBehaviour.SetTotalDist(100f);
		parabolaBehaviour.target = target;
		if (target != null)
		{
			parabolaBehaviour.SetTarget(target);
		}
		if (effectPath != null)
		{
			parabolaBehaviour.SetEffect(effectPath);
		}
		this.trails.Add(parabolaBehaviour);
		return parabolaBehaviour;
	}

	// Token: 0x04011BE9 RID: 72681
	private List<TrailBehaviour> trails = new List<TrailBehaviour>();

	// Token: 0x04011BEA RID: 72682
	private bool pause;

	// Token: 0x04011BEB RID: 72683
	private int timeAcc;

	// Token: 0x04011BEC RID: 72684
	private int interval = 64;

	// Token: 0x04011BED RID: 72685
	private bool isDirty;
}
