using System;
using System.Collections.Generic;

// Token: 0x020043A3 RID: 17315
public class Mechanism2108 : BeMechanism
{
	// Token: 0x0601802A RID: 98346 RVA: 0x00771FA6 File Offset: 0x007703A6
	public Mechanism2108(int id, int level) : base(id, level)
	{
	}

	// Token: 0x0601802B RID: 98347 RVA: 0x00771FD8 File Offset: 0x007703D8
	public override void OnInit()
	{
		this.mBulletResID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.mZSpeed = ((valueFromUnionCell != 0) ? valueFromUnionCell : this.mZSpeed);
		this.mBulletMaxNum = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.mDelayTime = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.mDelayAddSpeedTime = TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true);
		this.mAddSpeedMul = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.mEffectBuffID = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		this.mBulletList = new List<Mechanism2108.bullet>(this.mBulletMaxNum);
	}

	// Token: 0x0601802C RID: 98348 RVA: 0x00772121 File Offset: 0x00770521
	public override void OnStart()
	{
		this.mBulletList.Clear();
		if (base.owner != null)
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, new BeEventHandle.Del(this._OnCreateBullet));
		}
	}

	// Token: 0x0601802D RID: 98349 RVA: 0x00772158 File Offset: 0x00770558
	public override void OnUpdate(int deltaTime)
	{
		this.UpdateBulletTime(deltaTime);
	}

	// Token: 0x0601802E RID: 98350 RVA: 0x00772161 File Offset: 0x00770561
	public override void OnFinish()
	{
		this.mBulletList.Clear();
		this.mTarget = null;
	}

	// Token: 0x0601802F RID: 98351 RVA: 0x00772178 File Offset: 0x00770578
	private void UpdateBulletTime(int deltaTime)
	{
		if (this.mBulletList.Count == 0)
		{
			return;
		}
		for (int i = this.mBulletList.Count - 1; i >= 0; i--)
		{
			Mechanism2108.bullet value = this.mBulletList[i];
			value.Time += deltaTime;
			if (value.Time >= this.mDelayTime && value.SetSpeedTimes == 0)
			{
				this._SetBulletSpeed(value.Bullet, 1000);
				value.SetSpeedTimes++;
				this.mBulletList[i] = value;
			}
			else if (value.Time >= this.mDelayAddSpeedTime && value.SetSpeedTimes == 1)
			{
				this._SetBulletSpeed(value.Bullet, this.mAddSpeedMul);
				int index = this.mBulletList.Count - 1;
				Mechanism2108.bullet bullet = this.mBulletList[index];
				this.mBulletList[i] = new Mechanism2108.bullet
				{
					Bullet = bullet.Bullet,
					Time = bullet.Time,
					SetSpeedTimes = bullet.SetSpeedTimes
				};
				this.mBulletList.RemoveAt(index);
			}
			else
			{
				this.mBulletList[i] = value;
			}
		}
	}

	// Token: 0x06018030 RID: 98352 RVA: 0x007722CC File Offset: 0x007706CC
	private void _SetBulletSpeed(BeEntity bullet, int rate = 1000)
	{
		if (bullet == null)
		{
			return;
		}
		bullet.SetMoveSpeedZ(-this.mZSpeed * rate / 1000);
		if (this.mTarget == null || this.mTarget.IsDead())
		{
			this.mTarget = this._FindAttackActor();
		}
		if (this.mTarget != null)
		{
			if (this.effectBuff != null && this.effectBuff.owner != null && this.effectBuff.owner.buffController != null)
			{
				this.effectBuff.owner.buffController.RemoveBuff(this.effectBuff);
			}
			if (this.mTarget.buffController != null)
			{
				this.effectBuff = this.mTarget.buffController.TryAddBuff(this.mEffectBuffID, 1000, this.level, GlobalLogic.VALUE_1000, 0, false, null, 0, 0, base.owner);
			}
			VInt3 position = bullet.GetPosition();
			int num = position.z * 1000 / this.mZSpeed * 1000 / rate;
			num = ((num != 0) ? num : 1);
			VInt3 position2 = this.mTarget.GetPosition();
			bullet.SetMoveSpeedX((position2.x - position.x) * 1000 / num);
			bullet.SetMoveSpeedY((position2.y - position.y) * 1000 / num);
		}
	}

	// Token: 0x06018031 RID: 98353 RVA: 0x00772448 File Offset: 0x00770848
	private void _OnCreateBullet(object[] args)
	{
		if (args == null || args.Length == 0)
		{
			return;
		}
		BeEntity beEntity = args[0] as BeEntity;
		if (beEntity == null || beEntity.m_iResID != this.mBulletResID)
		{
			return;
		}
		this.mBulletList.Add(new Mechanism2108.bullet
		{
			Bullet = beEntity,
			Time = 0
		});
		beEntity.RegisterEvent(BeEventType.onDead, new BeEventHandle.Del(this.OnBulletDead));
	}

	// Token: 0x06018032 RID: 98354 RVA: 0x007724C0 File Offset: 0x007708C0
	private void OnBulletDead(object[] args)
	{
		if (args.Length > 0)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile == null)
			{
				return;
			}
			this.RemoveBulletListByPid(beProjectile.GetPID());
		}
	}

	// Token: 0x06018033 RID: 98355 RVA: 0x007724F4 File Offset: 0x007708F4
	private void RemoveBulletListByPid(int pid)
	{
		for (int i = 0; i < this.mBulletList.Count; i++)
		{
			if (this.mBulletList[i].Bullet != null && this.mBulletList[i].Bullet.GetPID() == pid)
			{
				this.mBulletList.RemoveAt(i);
				break;
			}
		}
	}

	// Token: 0x06018034 RID: 98356 RVA: 0x00772568 File Offset: 0x00770968
	private BeActor _FindAttackActor()
	{
		if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			BeActor beActor = null;
			int num = 0;
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead())
				{
					beActor = allPlayers[i].playerActor;
					num = i + 1;
					break;
				}
			}
			for (int j = num; j < allPlayers.Count; j++)
			{
				BeActor playerActor = allPlayers[j].playerActor;
				if (playerActor != null && !playerActor.IsDead() && playerActor.GetEntityData().GetHPRate() < beActor.GetEntityData().GetHPRate())
				{
					beActor = playerActor;
				}
			}
			return beActor;
		}
		return null;
	}

	// Token: 0x040114B9 RID: 70841
	protected int mBulletResID;

	// Token: 0x040114BA RID: 70842
	protected int mBulletMaxNum;

	// Token: 0x040114BB RID: 70843
	protected int mZSpeed = 100000;

	// Token: 0x040114BC RID: 70844
	protected int mDelayTime = 5000;

	// Token: 0x040114BD RID: 70845
	protected int mDelayAddSpeedTime = 5000;

	// Token: 0x040114BE RID: 70846
	protected int mAddSpeedMul = 2;

	// Token: 0x040114BF RID: 70847
	protected int mEffectBuffID;

	// Token: 0x040114C0 RID: 70848
	private List<Mechanism2108.bullet> mBulletList;

	// Token: 0x040114C1 RID: 70849
	private BeActor mTarget;

	// Token: 0x040114C2 RID: 70850
	private BeBuff effectBuff;

	// Token: 0x020043A4 RID: 17316
	private struct bullet
	{
		// Token: 0x040114C3 RID: 70851
		public BeEntity Bullet;

		// Token: 0x040114C4 RID: 70852
		public int Time;

		// Token: 0x040114C5 RID: 70853
		public int SetSpeedTimes;
	}
}
