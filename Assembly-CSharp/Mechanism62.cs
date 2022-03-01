using System;
using System.Collections.Generic;

// Token: 0x020043FE RID: 17406
public class Mechanism62 : BeMechanism
{
	// Token: 0x060182AC RID: 98988 RVA: 0x00784DF3 File Offset: 0x007831F3
	public Mechanism62(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182AD RID: 98989 RVA: 0x00784E2C File Offset: 0x0078322C
	public override void OnInit()
	{
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Length; i++)
			{
				this.m_EntityIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
			}
		}
		if (this.data.ValueB.Count > 0)
		{
			this.m_AddHitCount = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		}
		if (this.data.ValueC.Count > 1)
		{
			this.m_ModelScale[0] = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
			this.m_ModelScale[1] = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		}
		if (this.data.ValueD.Count > 1)
		{
			this.m_ModelZDimScale[0] = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
			this.m_ModelZDimScale[1] = TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.m_AddTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		}
		if (this.data.ValueF.Count > 0)
		{
			this.m_SpeedAddValue = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
		}
		if (this.data.ValueG.Count > 0)
		{
			this.m_SpeedAddRate = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
		}
		if (this.data.ValueH.Count > 1)
		{
			this.m_DistAddRate[0] = TableManager.GetValueFromUnionCell(this.data.ValueH[0], this.level, true);
			this.m_DistAddRate[1] = TableManager.GetValueFromUnionCell(this.data.ValueH[1], this.level, true);
		}
	}

	// Token: 0x060182AE RID: 98990 RVA: 0x007850D4 File Offset: 0x007834D4
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = (BeProjectile)args[0];
			if (beProjectile != null && this.m_EntityIds.Contains(beProjectile.m_iResID))
			{
				if (this.m_AddHitCount != 0)
				{
					int num = beProjectile.totoalHitCount + this.m_AddHitCount;
					if (num <= 0)
					{
						num = 1;
					}
					beProjectile.totoalHitCount = num;
				}
				int num2 = (!BattleMain.IsModePvP(base.battleType)) ? this.m_ModelScale[0] : this.m_ModelScale[1];
				if (num2 != 0)
				{
					this.ChangeModelScale(beProjectile, num2);
				}
				int num3 = (!BattleMain.IsModePvP(base.battleType)) ? this.m_ModelZDimScale[0] : this.m_ModelZDimScale[1];
				if (num3 != 0)
				{
					this.ChangeModelZDimScale(beProjectile, num3);
				}
				VFactor b = new VFactor((long)((!BattleMain.IsModePvP(base.battleType)) ? this.m_DistAddRate[0] : this.m_DistAddRate[1]), (long)GlobalLogic.VALUE_1000);
				beProjectile.distance = beProjectile.distance.i * (VFactor.one + b);
				if (this.m_AddTime != 0)
				{
					int num4 = beProjectile.m_fLifes + this.m_AddTime;
					if (num4 <= 0)
					{
						beProjectile.m_fLifes = 1;
					}
					else
					{
						beProjectile.m_fLifes = num4;
					}
				}
			}
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onChangeProjectileSpeed, delegate(object[] args)
		{
			BeProjectile beProjectile = (BeProjectile)args[0];
			if (beProjectile != null && this.m_EntityIds.Contains(beProjectile.m_iResID) && (this.m_SpeedAddValue != 0 || this.m_SpeedAddRate != 0))
			{
				VInt[] speedArray = (VInt[])args[1];
				this.ChangeProjectileSpeed(speedArray, beProjectile);
			}
		});
	}

	// Token: 0x060182AF RID: 98991 RVA: 0x00785128 File Offset: 0x00783528
	protected void ChangeModelScale(BeProjectile projectile, int scale)
	{
		if (projectile != null && !projectile.IsDead())
		{
			projectile.SetScale(projectile.GetScale().i + scale * 10);
		}
	}

	// Token: 0x060182B0 RID: 98992 RVA: 0x00785164 File Offset: 0x00783564
	protected void ChangeModelZDimScale(BeProjectile projectile, int scale)
	{
		if (projectile != null && !projectile.IsDead())
		{
			projectile.SetZDimScaleFactor(new VFactor((long)(projectile.GetZDimScaleFactor().vint.i + scale * GlobalLogic.VALUE_10), (long)GlobalLogic.VALUE_10000));
		}
	}

	// Token: 0x060182B1 RID: 98993 RVA: 0x007851B4 File Offset: 0x007835B4
	protected void ChangeProjectileSpeed(VInt[] speedArray, BeProjectile projectile)
	{
		if (this.m_SpeedAddValue != 0)
		{
			speedArray[0] += this.m_SpeedAddValue;
		}
		if (this.m_SpeedAddRate != 0)
		{
			VFactor b = new VFactor((long)this.m_SpeedAddRate, (long)GlobalLogic.VALUE_1000);
			speedArray[0] = speedArray[0].i * (VFactor.one + b);
		}
	}

	// Token: 0x04011702 RID: 71426
	protected List<int> m_EntityIds = new List<int>();

	// Token: 0x04011703 RID: 71427
	protected int m_AddHitCount;

	// Token: 0x04011704 RID: 71428
	protected int[] m_ModelScale = new int[2];

	// Token: 0x04011705 RID: 71429
	protected int[] m_ModelZDimScale = new int[2];

	// Token: 0x04011706 RID: 71430
	protected int m_AddTime;

	// Token: 0x04011707 RID: 71431
	protected int m_SpeedAddValue;

	// Token: 0x04011708 RID: 71432
	protected int m_SpeedAddRate;

	// Token: 0x04011709 RID: 71433
	protected int[] m_DistAddRate = new int[2];
}
