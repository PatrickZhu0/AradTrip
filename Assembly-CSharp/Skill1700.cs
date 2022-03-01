using System;
using GameClient;

// Token: 0x02004466 RID: 17510
public class Skill1700 : BeSkill
{
	// Token: 0x0601854B RID: 99659 RVA: 0x007941AC File Offset: 0x007925AC
	public Skill1700(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601854C RID: 99660 RVA: 0x007941E0 File Offset: 0x007925E0
	public override void OnInit()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			this.runeAttackAddBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true);
			this.runeExplodeAttackAddBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueE[1], base.level, true);
		}
		else
		{
			this.runeAttackAddBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true);
			this.runeExplodeAttackAddBuff = TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true);
		}
		this.runeLifeTimeAdd = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.runeAttackCountAdd = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.runeSizeAdd = new VFactor((long)TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true), (long)GlobalLogic.VALUE_1000);
	}

	// Token: 0x0601854D RID: 99661 RVA: 0x00794303 File Offset: 0x00792703
	public override void OnStart()
	{
		this.runeNum = -1;
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null && (beProjectile.m_iResID == this.guiyinzhuID || beProjectile.m_iResID == this.guiyinzhuBaoZaID))
			{
				if (this.runeNum == -1)
				{
					if (this.runeManager == null)
					{
						this.SetRuneManager();
					}
					int @int = 0;
					if (this.runeManager != null)
					{
						@int = this.runeManager.GetRuneCount();
					}
					@int = base.owner.TriggerEventNew(BeEventType.onCalcRuneAddDamage, new EventParam
					{
						m_Int = this.skillID,
						m_Int2 = @int
					}).m_Int2;
					this.runeNum = @int;
				}
				this.AddRuneBuff(this.runeNum, beProjectile);
				if (beProjectile.m_iResID == this.guiyinzhuID)
				{
					this.runeManager.RemoveRune(true);
					for (int i = 0; i < this.runeNum; i++)
					{
						beProjectile.AddSkillBuff(this.runeAttackAddBuff);
					}
				}
				else
				{
					for (int j = 0; j < this.runeNum; j++)
					{
						beProjectile.AddSkillBuff(this.runeExplodeAttackAddBuff);
					}
				}
			}
		});
	}

	// Token: 0x0601854E RID: 99662 RVA: 0x00794331 File Offset: 0x00792731
	public override void OnCancel()
	{
	}

	// Token: 0x0601854F RID: 99663 RVA: 0x00794333 File Offset: 0x00792733
	public override void OnFinish()
	{
	}

	// Token: 0x06018550 RID: 99664 RVA: 0x00794338 File Offset: 0x00792738
	public override bool CanUseSkill()
	{
		bool flag = false;
		if (this.runeManager == null)
		{
			this.SetRuneManager();
		}
		if (this.runeManager != null)
		{
			flag = (this.runeManager.GetRuneCount() > 0);
		}
		return base.CanUseSkill() && flag;
	}

	// Token: 0x06018551 RID: 99665 RVA: 0x00794384 File Offset: 0x00792784
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		bool flag = false;
		if (this.runeManager != null)
		{
			flag = (this.runeManager.GetRuneCount() > 0);
		}
		if (!flag)
		{
			return BeActor.SkillCannotUseType.NO_KEYING;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x06018552 RID: 99666 RVA: 0x007943BC File Offset: 0x007927BC
	private void SetRuneManager()
	{
		if (this.runeManager != null)
		{
			return;
		}
		if (base.owner != null)
		{
			Skill1710 skill = base.owner.GetSkill(1710) as Skill1710;
			if (skill != null)
			{
				this.runeManager = skill.runeManager;
			}
		}
	}

	// Token: 0x06018553 RID: 99667 RVA: 0x00794408 File Offset: 0x00792808
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x06018554 RID: 99668 RVA: 0x00794428 File Offset: 0x00792828
	private void AddRuneBuff(int count, BeProjectile projectile)
	{
		projectile.m_fLifes += this.runeLifeTimeAdd * count;
		projectile.totoalHitCount += this.runeAttackCountAdd * count;
		projectile.SetScale(projectile.GetScale().i * (VFactor.one + this.runeSizeAdd * 5L));
	}

	// Token: 0x040118EF RID: 71919
	protected BeEventHandle handle;

	// Token: 0x040118F0 RID: 71920
	protected Mechanism22 runeManager;

	// Token: 0x040118F1 RID: 71921
	private int runeAttackAddBuff;

	// Token: 0x040118F2 RID: 71922
	private int runeExplodeAttackAddBuff;

	// Token: 0x040118F3 RID: 71923
	private int runeLifeTimeAdd;

	// Token: 0x040118F4 RID: 71924
	private int runeAttackCountAdd;

	// Token: 0x040118F5 RID: 71925
	private VFactor runeSizeAdd = VFactor.zero;

	// Token: 0x040118F6 RID: 71926
	private int guiyinzhuID = 60011;

	// Token: 0x040118F7 RID: 71927
	private int guiyinzhuBaoZaID = 60012;

	// Token: 0x040118F8 RID: 71928
	private int runeNum = -1;
}
