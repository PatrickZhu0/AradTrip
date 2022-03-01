using System;
using UnityEngine;

// Token: 0x02000D7C RID: 3452
public class GeShockEffect
{
	// Token: 0x1700189E RID: 6302
	// (get) Token: 0x06008BFE RID: 35838 RVA: 0x0019DB4C File Offset: 0x0019BF4C
	public int Mode
	{
		get
		{
			return this.mode;
		}
	}

	// Token: 0x06008BFF RID: 35839 RVA: 0x0019DB54 File Offset: 0x0019BF54
	public void Init(GameObject obj, int mode)
	{
		this.mode = mode;
		if (obj != null)
		{
			this.node = obj.transform;
		}
	}

	// Token: 0x06008C00 RID: 35840 RVA: 0x0019DB75 File Offset: 0x0019BF75
	public void SetMode(int mode)
	{
		this.mode = mode;
	}

	// Token: 0x06008C01 RID: 35841 RVA: 0x0019DB80 File Offset: 0x0019BF80
	public void Start(float t, float s, float xr, float yr)
	{
		if (this.isRuning)
		{
			return;
		}
		this.isRuning = true;
		this.m_fCurTime = 0f;
		this.totalTime = t;
		this.xRange = xr;
		this.yRange = yr;
		this.speed = s;
		if (this.node != null)
		{
			this.orginalPos = this.node.localPosition;
		}
	}

	// Token: 0x06008C02 RID: 35842 RVA: 0x0019DBEC File Offset: 0x0019BFEC
	public void StartShock(float totalTime, int num, float xRange, float yRange, bool decelebrate, float xReduce, float yReduce, int mode, float radius = 1f)
	{
		if (this.isRuning)
		{
			return;
		}
		this.num = num;
		this.xRange = xRange;
		this.yRange = yRange;
		this.tempXrange = xRange;
		this.tempYrange = yRange;
		this.totalTime = totalTime;
		this.decelebrate = decelebrate;
		this.xReduce = xReduce;
		this.yReduce = yReduce;
		this.isRuning = true;
		this.goTime = 0f;
		this.backTime = 0f;
		this.negGoTime = 0f;
		this.negBackTime = 0f;
		this.m_fCurTime = 0f;
		this.singleTime = totalTime / (float)num;
		this.state = GeShockEffect.State.GO;
		this.radius = radius;
		this.mode = mode;
		if (this.node != null)
		{
			this.orginalPos = this.node.localPosition;
		}
	}

	// Token: 0x06008C03 RID: 35843 RVA: 0x0019DCCC File Offset: 0x0019C0CC
	public void Stop()
	{
		this.isRuning = false;
		this.state = GeShockEffect.State.NONE;
		this.goTime = 0f;
		this.backTime = 0f;
		this.negGoTime = 0f;
		this.negBackTime = 0f;
		this.m_fCurTime = 0f;
		this.tempXrange = this.xRange;
		this.tempYrange = this.yRange;
		this.orginalPos = Vector3.zero;
		if (this.node != null)
		{
			this.node.localPosition = this.orginalPos;
		}
	}

	// Token: 0x06008C04 RID: 35844 RVA: 0x0019DD64 File Offset: 0x0019C164
	public void Update(float deltaTime)
	{
		if (this.node == null)
		{
			return;
		}
		if (!this.isRuning)
		{
			return;
		}
		if (Mathf.Approximately(this.totalTime, 0f))
		{
			this.Stop();
			return;
		}
		if (this.m_fCurTime >= this.totalTime)
		{
			this.Stop();
			return;
		}
		this.m_fCurTime += deltaTime;
		if (this.mode == 0)
		{
			float num = this.m_fCurTime * this.speed;
			float num2 = Mathf.Sin(num) * this.xRange;
			float num3 = Mathf.Cos(num) * this.yRange;
			this.node.localPosition = new Vector3(num2, num3, 0f);
		}
		else if (this.mode == 2)
		{
			float num4 = this.totalTime / 2f;
			float num5;
			if (this.m_fCurTime <= num4)
			{
				num5 = (num4 - this.m_fCurTime) / num4;
				num5 = 1f - num5;
			}
			else
			{
				num5 = (this.totalTime - this.m_fCurTime) / num4;
			}
			float num6 = num5 * this.xRange;
			float num7 = num5 * this.yRange;
			this.node.localPosition = new Vector3(num6, num7, 0f);
		}
		else if (this.mode == 1)
		{
			float num8 = this.m_fCurTime / this.totalTime;
			float num9 = num8 * this.xRange;
			float num10 = num8 * this.yRange;
			this.node.localPosition = new Vector3(num9, num10, 0f);
		}
		if (this.mode == 3)
		{
			if (this.state == GeShockEffect.State.GO)
			{
				this.goTime += deltaTime;
				float num11 = this.goTime / this.singleTime;
				float num12 = num11 * this.tempXrange;
				float num13 = num11 * this.tempYrange;
				if (this.goTime >= this.singleTime)
				{
					this.goTime = 0f;
					this.state = GeShockEffect.State.BACK;
				}
				this.node.localPosition = new Vector3(num12, num13, 0f);
			}
			else if (this.state == GeShockEffect.State.BACK)
			{
				this.backTime += deltaTime;
				float num14 = this.backTime / this.singleTime;
				num14 = 1f - num14;
				float num15 = num14 * this.tempXrange;
				float num16 = num14 * this.tempYrange;
				if (this.backTime >= this.singleTime)
				{
					this.backTime = 0f;
					this.state = GeShockEffect.State.GO;
					if (this.decelebrate)
					{
						if (this.tempXrange >= this.xReduce)
						{
							this.tempXrange -= this.xReduce;
						}
						if (this.tempYrange >= this.yReduce)
						{
							this.tempYrange -= this.yReduce;
						}
					}
				}
				this.node.localPosition = new Vector3(num15, num16, 0f);
			}
		}
		else if (this.mode == 4)
		{
			if (this.state == GeShockEffect.State.GO)
			{
				this.goTime += deltaTime;
				float num17 = this.goTime / this.singleTime;
				float num18 = num17 * this.tempXrange;
				float num19 = num17 * this.tempYrange;
				if (this.goTime >= this.singleTime)
				{
					this.goTime = 0f;
					this.state = GeShockEffect.State.BACK;
				}
				this.node.localPosition = new Vector3(num18, num19, 0f);
			}
			else if (this.state == GeShockEffect.State.BACK)
			{
				this.backTime += deltaTime;
				float num20 = this.backTime / this.singleTime;
				num20 = 1f - num20;
				float num21 = num20 * this.tempXrange;
				float num22 = num20 * this.tempYrange;
				if (this.backTime >= this.singleTime)
				{
					this.state = GeShockEffect.State.NEG_GO;
					this.backTime = 0f;
				}
				this.node.localPosition = new Vector3(num21, num22, 0f);
			}
			else if (this.state == GeShockEffect.State.NEG_GO)
			{
				this.negGoTime += deltaTime;
				float num23 = this.negGoTime / this.singleTime;
				float num24 = num23 * this.tempXrange;
				float num25 = num23 * this.tempYrange;
				if (this.negGoTime >= this.singleTime)
				{
					this.negGoTime = 0f;
					this.state = GeShockEffect.State.NEG_BACK;
				}
				this.node.localPosition = new Vector3(-num24, -num25, 0f);
			}
			else if (this.state == GeShockEffect.State.NEG_BACK)
			{
				this.negBackTime += deltaTime;
				float num26 = this.negBackTime / this.singleTime;
				num26 = 1f - num26;
				float num27 = num26 * this.tempXrange;
				float num28 = num26 * this.tempYrange;
				if (this.negBackTime >= this.singleTime)
				{
					this.negBackTime = 0f;
					this.state = GeShockEffect.State.GO;
					if (this.decelebrate)
					{
						if (this.tempXrange >= this.xReduce)
						{
							this.tempXrange -= this.xReduce;
						}
						if (this.tempYrange >= this.yReduce)
						{
							this.tempYrange -= this.yReduce;
						}
					}
				}
				this.node.localPosition = new Vector3(-num27, -num28, 0f);
			}
		}
		else if (this.mode == 5)
		{
			if (this.decelebrate)
			{
				this.radius = Mathf.Lerp(this.radius, 0f, this.m_fCurTime / this.totalTime);
			}
			Vector2 vector = Random.insideUnitCircle * this.radius;
			this.node.localPosition = new Vector3(vector.x, vector.y, 0f);
		}
	}

	// Token: 0x0400452F RID: 17711
	private int num;

	// Token: 0x04004530 RID: 17712
	private float xRange;

	// Token: 0x04004531 RID: 17713
	private float yRange;

	// Token: 0x04004532 RID: 17714
	private float totalTime;

	// Token: 0x04004533 RID: 17715
	private int mode;

	// Token: 0x04004534 RID: 17716
	private bool isRuning;

	// Token: 0x04004535 RID: 17717
	private bool decelebrate;

	// Token: 0x04004536 RID: 17718
	private Vector3 orginalPos;

	// Token: 0x04004537 RID: 17719
	private Transform node;

	// Token: 0x04004538 RID: 17720
	private float m_fCurTime;

	// Token: 0x04004539 RID: 17721
	private float singleTime;

	// Token: 0x0400453A RID: 17722
	private GeShockEffect.State state = GeShockEffect.State.NONE;

	// Token: 0x0400453B RID: 17723
	private float goTime;

	// Token: 0x0400453C RID: 17724
	private float backTime;

	// Token: 0x0400453D RID: 17725
	private float negGoTime;

	// Token: 0x0400453E RID: 17726
	private float negBackTime;

	// Token: 0x0400453F RID: 17727
	private float tempXrange;

	// Token: 0x04004540 RID: 17728
	private float tempYrange;

	// Token: 0x04004541 RID: 17729
	private float xReduce;

	// Token: 0x04004542 RID: 17730
	private float yReduce;

	// Token: 0x04004543 RID: 17731
	private float speed;

	// Token: 0x04004544 RID: 17732
	private float radius;

	// Token: 0x02000D7D RID: 3453
	private enum State
	{
		// Token: 0x04004546 RID: 17734
		GO,
		// Token: 0x04004547 RID: 17735
		BACK,
		// Token: 0x04004548 RID: 17736
		NEG_GO,
		// Token: 0x04004549 RID: 17737
		NEG_BACK,
		// Token: 0x0400454A RID: 17738
		NONE
	}
}
