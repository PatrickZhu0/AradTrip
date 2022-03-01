using System;

// Token: 0x02004463 RID: 17507
public class Skill1617 : BeSkill
{
	// Token: 0x0601852F RID: 99631 RVA: 0x00793755 File Offset: 0x00791B55
	public Skill1617(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018530 RID: 99632 RVA: 0x00793760 File Offset: 0x00791B60
	public override void OnInit()
	{
		this.weaponType = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.buffID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
	}

	// Token: 0x06018531 RID: 99633 RVA: 0x007937B3 File Offset: 0x00791BB3
	public override void OnPostInit()
	{
		this.DoEffect();
	}

	// Token: 0x06018532 RID: 99634 RVA: 0x007937BB File Offset: 0x00791BBB
	public override void OnWeaponChange()
	{
		this.OnPostInit();
	}

	// Token: 0x06018533 RID: 99635 RVA: 0x007937C4 File Offset: 0x00791BC4
	private void DoEffect()
	{
		if (base.owner != null && this.buffID != 0)
		{
			base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		}
		if (base.owner != null && this.buffID > 0 && base.owner.GetWeaponType() == this.weaponType)
		{
			base.owner.buffController.TryAddBuff(this.buffID, int.MaxValue, base.level);
		}
	}

	// Token: 0x040118DD RID: 71901
	private int buffID;

	// Token: 0x040118DE RID: 71902
	private int weaponType;
}
