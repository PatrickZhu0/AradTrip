using System;

// Token: 0x02004461 RID: 17505
public class Skill1615 : BeSkill
{
	// Token: 0x0601851F RID: 99615 RVA: 0x00792F84 File Offset: 0x00791384
	public Skill1615(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018520 RID: 99616 RVA: 0x00792FB4 File Offset: 0x007913B4
	public override void OnInit()
	{
		this.startPercent = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueA[1], base.level, true));
		this.InitValue();
	}

	// Token: 0x06018521 RID: 99617 RVA: 0x0079301C File Offset: 0x0079141C
	public override void OnPostInit()
	{
		this.InitValue();
		this.entityData = base.owner.GetEntityData();
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			this.DoWork();
		});
		this.m_RebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, new BeEventHandle.Del(this.OnRebornHandle));
	}

	// Token: 0x06018522 RID: 99618 RVA: 0x00793084 File Offset: 0x00791484
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
		if (this.m_RebornHandle != null)
		{
			this.m_RebornHandle.Remove();
			this.m_RebornHandle = null;
		}
	}

	// Token: 0x06018523 RID: 99619 RVA: 0x007930C0 File Offset: 0x007914C0
	private void InitValue()
	{
		this.avoidanceInitValue = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueD[1], base.level, true));
		this.avoidanceLevelValue = ((!BattleMain.IsModePvP(base.owner.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueG[0], base.level, true));
		this.powerInitValue = ((!BattleMain.IsModePvP(base.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueB[1], base.level, true));
		this.powerLevelValue = ((!BattleMain.IsModePvP(base.owner.battleType)) ? TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true) : TableManager.GetValueFromUnionCell(this.skillData.ValueF[0], base.level, true));
		if (base.owner != null && base.owner.buffController.HasBuffByID(1400325) != null)
		{
			this.startPercent = 50;
		}
	}

	// Token: 0x06018524 RID: 99620 RVA: 0x00793258 File Offset: 0x00791658
	protected void OnRebornHandle(object[] args)
	{
		this.Restore();
	}

	// Token: 0x06018525 RID: 99621 RVA: 0x00793260 File Offset: 0x00791660
	private void DoWork()
	{
		int integer = (base.owner.GetEntityData().GetHPRate() * 100L).integer;
		if (integer > this.startPercent)
		{
			this.Restore();
			return;
		}
		if (integer != this.savedPercent)
		{
			this.Restore();
			this.savedPercent = integer;
			this.SetValue(integer);
		}
	}

	// Token: 0x06018526 RID: 99622 RVA: 0x007932C4 File Offset: 0x007916C4
	private void Restore()
	{
		if (this.entityData == null)
		{
			return;
		}
		if (this.savedPower > 0)
		{
			this.entityData.SetAttributeValue(AttributeType.baseAtk, -this.savedPower, true);
			this.savedPower = 0;
		}
		if (this.savedAvoidance > 0)
		{
			this.entityData.SetAttributeValue(AttributeType.dodge, -this.savedAvoidance, true);
			this.savedAvoidance = 0;
		}
		this.savedPercent = 0;
	}

	// Token: 0x06018527 RID: 99623 RVA: 0x00793334 File Offset: 0x00791734
	private void SetValue(int percent)
	{
		int num = this.powerInitValue + (this.startPercent - percent) * this.powerLevelValue;
		int num2 = this.avoidanceInitValue + (this.startPercent - percent) * this.avoidanceLevelValue;
		this.savedPower = num;
		this.entityData.SetAttributeValue(AttributeType.baseAtk, this.savedPower, true);
		this.savedAvoidance = num2;
		this.entityData.SetAttributeValue(AttributeType.dodge, this.savedAvoidance, true);
	}

	// Token: 0x06018528 RID: 99624 RVA: 0x007933A5 File Offset: 0x007917A5
	public override void OnCancel()
	{
		base.OnCancel();
		this.Restore();
	}

	// Token: 0x040118CA RID: 71882
	private int startPercent = 40;

	// Token: 0x040118CB RID: 71883
	private int powerInitValue = 10;

	// Token: 0x040118CC RID: 71884
	private int powerLevelValue = 1;

	// Token: 0x040118CD RID: 71885
	private int avoidanceInitValue = 10;

	// Token: 0x040118CE RID: 71886
	private int avoidanceLevelValue = 1;

	// Token: 0x040118CF RID: 71887
	private int savedPercent;

	// Token: 0x040118D0 RID: 71888
	private int savedPower;

	// Token: 0x040118D1 RID: 71889
	private int savedAvoidance;

	// Token: 0x040118D2 RID: 71890
	private BeEntityData entityData;

	// Token: 0x040118D3 RID: 71891
	private BeEventHandle handle;

	// Token: 0x040118D4 RID: 71892
	private BeEventHandle m_RebornHandle;
}
