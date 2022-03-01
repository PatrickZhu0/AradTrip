using System;

// Token: 0x02004369 RID: 17257
public class Mechanism2049 : BeMechanism
{
	// Token: 0x06017E63 RID: 97891 RVA: 0x0076511A File Offset: 0x0076351A
	public Mechanism2049(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017E64 RID: 97892 RVA: 0x0076514C File Offset: 0x0076354C
	public override void OnInit()
	{
		this.CREAT_NEXT_INTERVAL = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.BOOM_TIMES = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mBulletId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mBoomId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mHurtId = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x06017E65 RID: 97893 RVA: 0x00765224 File Offset: 0x00763624
	public override void OnStart()
	{
		this.mBoomTimes = this.BOOM_TIMES;
		this.Clear();
		if (base.owner != null)
		{
			this.mOriginFace = base.owner.GetFace();
			if (this.mBulletEvent == null)
			{
				this.mBulletEvent = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args1)
				{
					BeProjectile beProjectile = args1[0] as BeProjectile;
					if (beProjectile != null && beProjectile.m_iResID == this.mBulletId && this.mBulletHitEvent == null)
					{
						this.mBulletHitEvent = beProjectile.RegisterEvent(BeEventType.onHitOther, delegate(object[] args2)
						{
							this.mTargetPos = (VInt3)args2[3];
							if (!this.creatFlag && this.mFirstTarget == null && (int)args2[1] == this.mHurtId)
							{
								this.mFirstTarget = (args2[0] as BeEntity);
								this.creatFlag = true;
							}
						});
					}
				});
			}
		}
	}

	// Token: 0x06017E66 RID: 97894 RVA: 0x0076528C File Offset: 0x0076368C
	public override void OnUpdate(int deltaTime)
	{
		if (this.creatFlag)
		{
			if (this.mBoomTimes <= 0 && base.owner != null && this.attachBuff != null)
			{
				base.owner.buffController.RemoveBuff(this.attachBuff);
			}
			this.timer += deltaTime;
			if (this.timer >= this.CREAT_NEXT_INTERVAL && this.mBoomTimes > 0)
			{
				this.timer = 0;
				this.CreatBoom();
			}
		}
	}

	// Token: 0x06017E67 RID: 97895 RVA: 0x00765314 File Offset: 0x00763714
	private void CreatBoom()
	{
		if (this.mFirstTarget != null && !this.mFirstTarget.IsDeadOrRemoved())
		{
			VInt3 vint = this.mTargetPos;
			vint.x = this.mFirstTarget.GetPosition().x;
			vint.y = this.mFirstTarget.GetPosition().y;
			this.mTargetPos = vint;
		}
		BeEntity beEntity = base.owner.AddEntity(this.mBoomId, this.mTargetPos, 1, 0);
		if (beEntity != null)
		{
			beEntity.SetFace(this.mOriginFace, true, true);
		}
		this.mBoomTimes--;
	}

	// Token: 0x06017E68 RID: 97896 RVA: 0x007653BA File Offset: 0x007637BA
	public override void OnFinish()
	{
		this.Clear();
	}

	// Token: 0x06017E69 RID: 97897 RVA: 0x007653C2 File Offset: 0x007637C2
	private void Clear()
	{
		this.mFirstTarget = null;
		this.mTargetPos = VInt3.zero;
		this.RemoveHandle();
	}

	// Token: 0x06017E6A RID: 97898 RVA: 0x007653DC File Offset: 0x007637DC
	private void RemoveHandle()
	{
		if (this.mBulletEvent != null)
		{
			this.mBulletEvent.Remove();
			this.mBulletEvent = null;
		}
		if (this.mBulletHitEvent != null)
		{
			this.mBulletHitEvent.Remove();
			this.mBulletHitEvent = null;
		}
	}

	// Token: 0x04011334 RID: 70452
	private BeEventHandle mBulletEvent;

	// Token: 0x04011335 RID: 70453
	private BeEventHandle mBulletHitEvent;

	// Token: 0x04011336 RID: 70454
	private BeEntity mFirstTarget;

	// Token: 0x04011337 RID: 70455
	private VInt3 mTargetPos;

	// Token: 0x04011338 RID: 70456
	private int CREAT_NEXT_INTERVAL = 200;

	// Token: 0x04011339 RID: 70457
	private int BOOM_TIMES = 6;

	// Token: 0x0401133A RID: 70458
	private int mBulletId = 63688;

	// Token: 0x0401133B RID: 70459
	private int mBoomId = 63689;

	// Token: 0x0401133C RID: 70460
	private int mHurtId;

	// Token: 0x0401133D RID: 70461
	private int mBoomTimes;

	// Token: 0x0401133E RID: 70462
	private bool mOriginFace;

	// Token: 0x0401133F RID: 70463
	private int timer;

	// Token: 0x04011340 RID: 70464
	private bool creatFlag;
}
