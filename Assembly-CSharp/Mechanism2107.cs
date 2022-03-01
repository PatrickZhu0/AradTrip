using System;
using System.Collections.Generic;

// Token: 0x020043A2 RID: 17314
public class Mechanism2107 : BeMechanism
{
	// Token: 0x06018022 RID: 98338 RVA: 0x00771868 File Offset: 0x0076FC68
	public Mechanism2107(int id, int level) : base(id, level)
	{
	}

	// Token: 0x06018023 RID: 98339 RVA: 0x0077189C File Offset: 0x0076FC9C
	public override void OnInit()
	{
		this.mBulletResID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mBulletXSpeed = ((valueFromUnionCell <= 0) ? this.mBulletXSpeed : valueFromUnionCell);
		valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mBulletMaxHeight = ((valueFromUnionCell <= 0) ? this.mBulletMaxHeight : (valueFromUnionCell * 1000));
		this.mBulletMinFlyTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mBulletOffsetX = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x06018024 RID: 98340 RVA: 0x007719A0 File Offset: 0x0076FDA0
	public override void OnStart()
	{
		this.mTargets[0] = null;
		this.mTargets[1] = null;
		if (base.owner != null && base.owner.CurrentBeScene != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this._CollectBullet));
		}
	}

	// Token: 0x06018025 RID: 98341 RVA: 0x007719FC File Offset: 0x0076FDFC
	private void _CollectBullet(object[] args)
	{
		if (args.Length == 0)
		{
			return;
		}
		BeProjectile beProjectile = args[0] as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		if (beProjectile.m_iResID != this.mBulletResID)
		{
			return;
		}
		this._DealBulletTargets();
		this._DealBulletSpeed(beProjectile);
	}

	// Token: 0x06018026 RID: 98342 RVA: 0x00771A44 File Offset: 0x0076FE44
	private void _DealBulletSpeed(BeProjectile bullet)
	{
		if (base.owner == null)
		{
			bullet.SetMoveSpeedXLocal(this.mBulletXSpeed * 1000);
			return;
		}
		int num = (bullet.GetPosition().y - base.owner.GetPosition().y <= 0) ? 1 : 0;
		if (this.mTargets[num] == null)
		{
			bullet.SetMoveSpeedXLocal(this.mBulletXSpeed * 1000);
			bullet.SetMoveSpeedZ(this.mBulletXSpeed * 1000);
			bullet.SetMoveSpeedZAcc(this.mBulletXSpeed * 1000);
			return;
		}
		VInt3 position = this.mTargets[num].GetPosition();
		VInt3 position2 = bullet.GetPosition();
		int num2 = Math.Abs(position.x - position2.x);
		if (num2 > this.mBulletOffsetX)
		{
			num2 -= this.mBulletOffsetX;
		}
		int num3 = num2 / this.mBulletXSpeed;
		if (num3 < this.mBulletMinFlyTime)
		{
			num3 = this.mBulletMinFlyTime;
		}
		bullet.SetMoveSpeedXLocal(num2 * 1000 / num3);
		bullet.SetMoveSpeedY((position.y - position2.y) * 1000 / num3);
		int num4 = num3 / 2;
		int num5 = this.mBulletMaxHeight * 1000 / num4 * 1000 / num4 * 2;
		bullet.SetMoveSpeedZ(num5 / 1000 * num4);
		bullet.SetMoveSpeedZAcc(num5);
	}

	// Token: 0x06018027 RID: 98343 RVA: 0x00771BDC File Offset: 0x0076FFDC
	private void _DealBulletTargets()
	{
		for (int i = 0; i < this.mTargets.Length; i++)
		{
			if (this.mTargets[i] != null && (this.mTargets[i].IsDeadOrRemoved() || !this.IsInFrontOfMonster(this.mTargets[i])))
			{
				this.mTargets[i] = null;
			}
		}
		if (this.mTargets[0] != null && this.mTargets[1] != null)
		{
			if (this.mTargets[0].GetPID() != this.mTargets[1].GetPID())
			{
				return;
			}
			this.mTargets[1] = null;
		}
		if (this.mTargets[0] == null)
		{
			this.FindBulletTarget(true);
		}
		if (this.mTargets[1] == null)
		{
			this.FindBulletTarget(false);
		}
		if (this.mTargets[0] != null && this.mTargets[1] == null)
		{
			this.mTargets[1] = this.mTargets[0];
		}
		if (this.mTargets[1] != null && this.mTargets[0] == null)
		{
			this.mTargets[0] = this.mTargets[1];
		}
	}

	// Token: 0x06018028 RID: 98344 RVA: 0x00771D04 File Offset: 0x00770104
	private void FindBulletTarget(bool top)
	{
		if (base.owner == null || base.owner.IsDead())
		{
			return;
		}
		List<BeEntity> entities = base.owner.CurrentBeScene.GetEntities();
		VInt3 position = base.owner.GetPosition();
		for (int i = 0; i < entities.Count; i++)
		{
			BeActor beActor = entities[i] as BeActor;
			if (beActor != null && !beActor.IsDead() && !beActor.IsSkillMonster() && beActor.stateController != null && beActor.stateController.CanBeTargeted())
			{
				if (base.owner != beActor && beActor.m_iCamp != base.owner.m_iCamp)
				{
					if ((!top || this.mTargets[1] == null || this.mTargets[1].GetPID() != beActor.GetPID()) && (top || this.mTargets[0] == null || this.mTargets[0].GetPID() != beActor.GetPID()))
					{
						VInt3 position2 = beActor.GetPosition();
						int num = (!base.owner.GetFace()) ? -1 : 1;
						int num2 = num * (position.x - position2.x);
						int num3 = (!top) ? 1 : 0;
						if (num2 >= 0)
						{
							if (this.mTargets[num3] == null)
							{
								this.mTargets[num3] = beActor;
							}
							else
							{
								int num4 = num * (position.x - this.mTargets[num3].GetPosition().x);
								if (num2 < num4)
								{
									this.mTargets[num3] = beActor;
								}
								else if (num4 == num2)
								{
									if (top && this.mTargets[num3].GetPosition().y < position2.y)
									{
										this.mTargets[num3] = beActor;
									}
									else if (!top && this.mTargets[num3].GetPosition().y > position2.y)
									{
										this.mTargets[num3] = beActor;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06018029 RID: 98345 RVA: 0x00771F48 File Offset: 0x00770348
	private bool IsInFrontOfMonster(BeEntity entity)
	{
		if (base.owner == null)
		{
			return false;
		}
		int num = (!base.owner.GetFace()) ? -1 : 1;
		int num2 = num * (base.owner.GetPosition().x - entity.GetPosition().x);
		return num2 >= 0;
	}

	// Token: 0x040114B3 RID: 70835
	protected int mBulletResID;

	// Token: 0x040114B4 RID: 70836
	protected int mBulletXSpeed = 100;

	// Token: 0x040114B5 RID: 70837
	protected int mBulletMaxHeight = 20000;

	// Token: 0x040114B6 RID: 70838
	protected int mBulletMinFlyTime = 700;

	// Token: 0x040114B7 RID: 70839
	protected BeEntity[] mTargets = new BeEntity[2];

	// Token: 0x040114B8 RID: 70840
	protected int mBulletOffsetX;
}
