using System;

// Token: 0x02004495 RID: 17557
public class Skill2201 : BeSkill
{
	// Token: 0x06018680 RID: 99968 RVA: 0x0079C403 File Offset: 0x0079A803
	public Skill2201(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018681 RID: 99969 RVA: 0x0079C424 File Offset: 0x0079A824
	public override void OnPostInit()
	{
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
				if (valueFromUnionCell != 0)
				{
					BeSkill skill = base.owner.GetSkill(valueFromUnionCell);
					if (skill != null)
					{
						skill.walk = true;
						skill.walkSpeed = this.GetWalkSpeed();
					}
				}
			}
		}
		if (this.skillData.ValueB.Count > 0)
		{
			for (int j = 0; j < this.skillData.ValueB.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true);
				this.m_BuffIdArray[j] = valueFromUnionCell2;
			}
		}
		this.RemoveHandle();
		this.m_OnBeforeHitHandle = base.owner.RegisterEvent(BeEventType.onBeforeOtherHit, delegate(object[] args)
		{
			BeSkill currentSkill = base.owner.GetCurrentSkill();
			if (currentSkill != null && base.owner.sgGetCurrentState() == 14 && currentSkill.GetCurrPhase() == currentSkill.chargeConfig.repeatPhase && currentSkill.walk)
			{
				int buffID;
				if (BattleMain.IsModePvP(base.battleType))
				{
					buffID = this.m_BuffIdArray[1];
				}
				else
				{
					buffID = this.m_BuffIdArray[0];
				}
				base.owner.buffController.TryAddBuff(buffID, 50, base.level);
			}
		});
		this.ReplaceNormalAttackId();
	}

	// Token: 0x06018682 RID: 99970 RVA: 0x0079C540 File Offset: 0x0079A940
	protected void ReplaceNormalAttackId()
	{
		BeSkill skill = base.owner.GetSkill(this.m_ReplaceNormalId);
		if (skill != null)
		{
			base.owner.GetEntityData().normalAttackID = this.m_ReplaceNormalId;
		}
	}

	// Token: 0x06018683 RID: 99971 RVA: 0x0079C57C File Offset: 0x0079A97C
	protected VFactor GetWalkSpeed()
	{
		int valueFromUnionCell;
		if (BattleMain.IsModePvP(base.battleType))
		{
			valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.WalkSpeedPVP, base.level, true);
		}
		else
		{
			valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.WalkSpeed, base.level, true);
		}
		return new VFactor((long)valueFromUnionCell, (long)GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018684 RID: 99972 RVA: 0x0079C5DD File Offset: 0x0079A9DD
	protected void RemoveHandle()
	{
		if (this.m_OnBeforeHitHandle != null)
		{
			this.m_OnBeforeHitHandle.Remove();
			this.m_OnBeforeHitHandle = null;
		}
	}

	// Token: 0x040119CF RID: 72143
	protected int[] m_BuffIdArray = new int[2];

	// Token: 0x040119D0 RID: 72144
	protected BeEventHandle m_OnBeforeHitHandle;

	// Token: 0x040119D1 RID: 72145
	protected int m_ReplaceNormalId = 20001;
}
