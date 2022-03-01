using System;

// Token: 0x0200445D RID: 17501
public class Skill1610 : BeSkill
{
	// Token: 0x06018515 RID: 99605 RVA: 0x00792B5A File Offset: 0x00790F5A
	public Skill1610(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018516 RID: 99606 RVA: 0x00792B64 File Offset: 0x00790F64
	public override void OnPostInit()
	{
		this.DoEffect();
	}

	// Token: 0x06018517 RID: 99607 RVA: 0x00792B6C File Offset: 0x00790F6C
	public override void OnWeaponChange()
	{
		this.OnPostInit();
	}

	// Token: 0x06018518 RID: 99608 RVA: 0x00792B74 File Offset: 0x00790F74
	private void DoEffect()
	{
		if (base.owner == null)
		{
			return;
		}
		if (this.savedBuffID != 0)
		{
			base.owner.buffController.RemoveBuff(this.savedBuffID, 0, 0);
			this.savedBuffID = 0;
		}
		int weaponType = base.owner.GetWeaponType();
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
			int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
			if (valueFromUnionCell == weaponType)
			{
				base.owner.buffController.TryAddBuff(valueFromUnionCell2, int.MaxValue, base.level);
				this.savedBuffID = valueFromUnionCell2;
				break;
			}
		}
	}

	// Token: 0x040118C2 RID: 71874
	private int savedBuffID;
}
