using System;
using GameClient;

// Token: 0x02004469 RID: 17513
public class Skill1707 : BeSkill
{
	// Token: 0x06018563 RID: 99683 RVA: 0x00794916 File Offset: 0x00792D16
	public Skill1707(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018564 RID: 99684 RVA: 0x00794920 File Offset: 0x00792D20
	public sealed override void OnInit()
	{
		this.addBuffs = null;
		this.addBuffs = new int[this.skillData.ValueA.Count];
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			this.addBuffs[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
		}
		this.projectileIDs = null;
		this.projectileIDs = new int[this.skillData.ValueB.Count];
		for (int j = 0; j < this.skillData.ValueB.Count; j++)
		{
			this.projectileIDs[j] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true);
		}
	}

	// Token: 0x06018565 RID: 99685 RVA: 0x007949FD File Offset: 0x00792DFD
	public sealed override void OnStart()
	{
		this.RemoveHandler();
		this.handle = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			if (beProjectile != null && this.IsTargetProjectile(beProjectile.m_iResID))
			{
				Skill1710 skill = base.owner.GetSkill(1710) as Skill1710;
				if (skill != null)
				{
					int num = skill.GetRuneCount();
					num = base.owner.TriggerEventNew(BeEventType.onCalcRuneAddDamage, new EventParam
					{
						m_Int = this.skillID,
						m_Int2 = num
					}).m_Int2;
					if (num > 0)
					{
						beProjectile.AddSkillBuff(this.addBuffs[num - 1]);
					}
				}
			}
		});
	}

	// Token: 0x06018566 RID: 99686 RVA: 0x00794A24 File Offset: 0x00792E24
	public sealed override void OnCancel()
	{
		this.RemoveHandler();
	}

	// Token: 0x06018567 RID: 99687 RVA: 0x00794A2C File Offset: 0x00792E2C
	public sealed override void OnFinish()
	{
		this.RemoveHandler();
	}

	// Token: 0x06018568 RID: 99688 RVA: 0x00794A34 File Offset: 0x00792E34
	protected bool IsTargetProjectile(int pid)
	{
		if (this.projectileIDs == null)
		{
			return false;
		}
		for (int i = 0; i < this.projectileIDs.Length; i++)
		{
			if (this.projectileIDs[i] == pid)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018569 RID: 99689 RVA: 0x00794A78 File Offset: 0x00792E78
	protected void RemoveHandler()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011900 RID: 71936
	protected BeEventHandle handle;

	// Token: 0x04011901 RID: 71937
	protected int[] addBuffs;

	// Token: 0x04011902 RID: 71938
	protected int[] projectileIDs;
}
