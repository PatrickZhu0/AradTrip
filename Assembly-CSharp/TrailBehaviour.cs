using System;
using UnityEngine;

// Token: 0x02004507 RID: 17671
public class TrailBehaviour
{
	// Token: 0x0601895B RID: 100699 RVA: 0x007AD828 File Offset: 0x007ABC28
	public void SetTarget(BeActor tar)
	{
		this.target = tar;
	}

	// Token: 0x0601895C RID: 100700 RVA: 0x007AD834 File Offset: 0x007ABC34
	public void SetEffect(string effectPath)
	{
		this.effect = BattleMain.instance.Main.currentGeScene.CreateEffect(effectPath, 100000f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false);
	}

	// Token: 0x0601895D RID: 100701 RVA: 0x007AD881 File Offset: 0x007ABC81
	public void SetReachCallBack(TrailBehaviour.Del del)
	{
		this.reachCallBack = del;
	}

	// Token: 0x0601895E RID: 100702 RVA: 0x007AD88A File Offset: 0x007ABC8A
	public Vector3 GetCurrentDir()
	{
		return this.currentDir;
	}

	// Token: 0x0601895F RID: 100703 RVA: 0x007AD892 File Offset: 0x007ABC92
	public Vector3 GetCurrentPos()
	{
		return this.currentPos;
	}

	// Token: 0x06018960 RID: 100704 RVA: 0x007AD89A File Offset: 0x007ABC9A
	public Vector3 GetMoveDir()
	{
		return this.velocity.normalized;
	}

	// Token: 0x06018961 RID: 100705 RVA: 0x007AD8A7 File Offset: 0x007ABCA7
	public Vector3 GetVelocity()
	{
		return this.velocity;
	}

	// Token: 0x06018962 RID: 100706 RVA: 0x007AD8AF File Offset: 0x007ABCAF
	public void SetTotalDist(float dist)
	{
		this.totalDist = dist;
	}

	// Token: 0x06018963 RID: 100707 RVA: 0x007AD8B8 File Offset: 0x007ABCB8
	public void UpdateEndPoint(Vector3 pos, Vector3 renderEndPos)
	{
		if (this.EndPoint != pos)
		{
			this.EndPoint = pos;
			this.totalDist = Vector3.Distance(this.StartPoint, this.EndPoint);
			this.velocity = (this.EndPoint - this.StartPoint).normalized;
		}
	}

	// Token: 0x06018964 RID: 100708 RVA: 0x007AD913 File Offset: 0x007ABD13
	public void Start()
	{
		this.ReachDest = false;
		this.TimeAcc = 0f;
		this.Status = TrailStatus.TRAIL_FLY;
		this.Init();
	}

	// Token: 0x06018965 RID: 100709 RVA: 0x007AD934 File Offset: 0x007ABD34
	public void Stay()
	{
		this.TimeAcc = 0f;
		this.Status = TrailStatus.TRAIL_STAY;
		this.OnStay();
	}

	// Token: 0x06018966 RID: 100710 RVA: 0x007AD950 File Offset: 0x007ABD50
	public void End()
	{
		this.ReachDest = true;
		this.DistPercent = 1f;
		this.Status = TrailStatus.TRAIL_DEATH;
		if (this.effect != null)
		{
			this.effect.Remove();
		}
		if (this.reachCallBack != null)
		{
			this.reachCallBack();
		}
	}

	// Token: 0x06018967 RID: 100711 RVA: 0x007AD9A2 File Offset: 0x007ABDA2
	public bool IsDead()
	{
		return this.Status == TrailStatus.TRAIL_DEATH;
	}

	// Token: 0x06018968 RID: 100712 RVA: 0x007AD9AD File Offset: 0x007ABDAD
	public virtual void Init()
	{
	}

	// Token: 0x06018969 RID: 100713 RVA: 0x007AD9AF File Offset: 0x007ABDAF
	public virtual void OnStay()
	{
	}

	// Token: 0x0601896A RID: 100714 RVA: 0x007AD9B4 File Offset: 0x007ABDB4
	public void Tick(int deltaTime)
	{
		this.OnTick(deltaTime);
		if (this.effect != null)
		{
			this.effect.SetPosition(new Vector3(this.currentPos.x, this.currentPos.y, this.currentPos.z));
		}
		if (this.target != null && this.Type != TrailType.BOOMRANGE)
		{
			this.EndPoint = this.target.GetGePosition() + Global.Settings.offset;
		}
		if (!this.Directional && this.ReachTarget())
		{
			this.End();
		}
	}

	// Token: 0x0601896B RID: 100715 RVA: 0x007ADA58 File Offset: 0x007ABE58
	public bool ReachTarget()
	{
		return (this.currentPos - this.EndPoint).magnitude < 0.2f;
	}

	// Token: 0x0601896C RID: 100716 RVA: 0x007ADA85 File Offset: 0x007ABE85
	public virtual void OnTick(int deltaTime)
	{
	}

	// Token: 0x04011BD6 RID: 72662
	public Vector3 StartPoint = Vector3.zero;

	// Token: 0x04011BD7 RID: 72663
	public Vector3 EndPoint = Vector3.zero;

	// Token: 0x04011BD8 RID: 72664
	protected float TimeAcc;

	// Token: 0x04011BD9 RID: 72665
	public float StayTime;

	// Token: 0x04011BDA RID: 72666
	public float DistPercent;

	// Token: 0x04011BDB RID: 72667
	public float MoveSpeed = 0.1f;

	// Token: 0x04011BDC RID: 72668
	protected float SpeedAcc;

	// Token: 0x04011BDD RID: 72669
	protected bool ReachDest;

	// Token: 0x04011BDE RID: 72670
	protected TrailStatus Status;

	// Token: 0x04011BDF RID: 72671
	public Vector3 currentDir = Vector3.zero;

	// Token: 0x04011BE0 RID: 72672
	public Vector3 currentPos = Vector3.zero;

	// Token: 0x04011BE1 RID: 72673
	public Vector3 velocity = Vector3.zero;

	// Token: 0x04011BE2 RID: 72674
	public float totalDist;

	// Token: 0x04011BE3 RID: 72675
	protected TrailType Type = TrailType.LINER;

	// Token: 0x04011BE4 RID: 72676
	public bool Directional;

	// Token: 0x04011BE5 RID: 72677
	private GeEffectEx effect;

	// Token: 0x04011BE6 RID: 72678
	public BeActor target;

	// Token: 0x04011BE7 RID: 72679
	public TrailBehaviour.Del reachCallBack;

	// Token: 0x04011BE8 RID: 72680
	public BeProjectile owner;

	// Token: 0x02004508 RID: 17672
	// (Invoke) Token: 0x0601896E RID: 100718
	public delegate void Del();
}
