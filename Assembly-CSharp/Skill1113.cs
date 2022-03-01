using System;

// Token: 0x0200443B RID: 17467
public class Skill1113 : BeSkill
{
	// Token: 0x06018410 RID: 99344 RVA: 0x0078D664 File Offset: 0x0078BA64
	public Skill1113(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.skillPhases = new int[]
		{
			0,
			11131,
			11133
		};
		this.entityIDs = new int[]
		{
			60260,
			60261,
			60262
		};
	}

	// Token: 0x06018411 RID: 99345 RVA: 0x0078D6B8 File Offset: 0x0078BAB8
	public override void OnInit()
	{
	}

	// Token: 0x06018412 RID: 99346 RVA: 0x0078D6BA File Offset: 0x0078BABA
	public override void OnStart()
	{
		this.RemoveHandle();
		this.phase = 0;
		this.projectileCount = 0;
		this.handle = base.owner.RegisterEvent(BeEventType.onBoomerangHit, delegate(object[] args)
		{
			if (base.owner.IsDead())
			{
				return;
			}
			if (this.phase >= 2)
			{
				this.RemoveHandle();
				return;
			}
			BeProjectile beProjectile = args[0] as BeProjectile;
			this.savedProjectisles[this.projectileCount++] = beProjectile;
			if (this.projectileCount >= 2)
			{
				this.phase++;
				if (this.CanLaunchBoomerang(this.skillPhases[this.phase]))
				{
					for (int i = 0; i < this.savedProjectisles.Length; i++)
					{
						if (this.savedProjectisles[i] != null)
						{
							this.savedProjectisles[i].DoDie();
						}
					}
					this.projectileCount = 0;
					base.owner.UseSkill(this.skillPhases[this.phase], true);
				}
				else
				{
					this.projectileCount = 0;
					this.RemoveHandle();
				}
				return;
			}
		});
	}

	// Token: 0x06018413 RID: 99347 RVA: 0x0078D6EF File Offset: 0x0078BAEF
	public override void OnFinish()
	{
	}

	// Token: 0x06018414 RID: 99348 RVA: 0x0078D6F1 File Offset: 0x0078BAF1
	public override void OnCancel()
	{
	}

	// Token: 0x06018415 RID: 99349 RVA: 0x0078D6F4 File Offset: 0x0078BAF4
	protected int GetEntityPhaseID(int id)
	{
		for (int i = 0; i < this.entityIDs.Length; i++)
		{
			if (id == this.entityIDs[i])
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06018416 RID: 99350 RVA: 0x0078D72B File Offset: 0x0078BB2B
	protected bool CanLaunchBoomerang(int skillID)
	{
		return base.owner.CanUseSkill(skillID);
	}

	// Token: 0x06018417 RID: 99351 RVA: 0x0078D739 File Offset: 0x0078BB39
	protected void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011809 RID: 71689
	protected BeEventHandle handle;

	// Token: 0x0401180A RID: 71690
	protected int phase;

	// Token: 0x0401180B RID: 71691
	protected int[] skillPhases;

	// Token: 0x0401180C RID: 71692
	protected int[] entityIDs;

	// Token: 0x0401180D RID: 71693
	protected BeProjectile[] savedProjectisles = new BeProjectile[2];

	// Token: 0x0401180E RID: 71694
	protected int projectileCount;
}
