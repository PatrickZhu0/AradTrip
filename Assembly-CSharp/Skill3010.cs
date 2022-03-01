using System;
using ProtoTable;

// Token: 0x020044B6 RID: 17590
public class Skill3010 : BeSkill
{
	// Token: 0x0601877F RID: 100223 RVA: 0x007A38B6 File Offset: 0x007A1CB6
	public Skill3010(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018780 RID: 100224 RVA: 0x007A38D6 File Offset: 0x007A1CD6
	public override void OnStart()
	{
		this.m_XuNianPaoHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.m_XuNianPaoPhaseId)
			{
				BeSkill skill = base.owner.GetSkill(this.m_XuNianPaoId);
				if (skill != null)
				{
					if (BattleMain.IsChijiNeedReplaceSkillId(skill.skillID, base.battleType))
					{
						ChijiSkillMapTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChijiSkillMapTable>(skill.skillID, string.Empty, string.Empty);
						base.SetChargeCdTime(TableManager.GetValueFromUnionCell(tableItem.RefreshTimePVP, base.level, true));
					}
					else if (!BattleMain.IsModePvP(base.battleType))
					{
						base.SetChargeCdTime(TableManager.GetValueFromUnionCell(skill.skillData.RefreshTime, base.level, true));
					}
					else
					{
						base.SetChargeCdTime(TableManager.GetValueFromUnionCell(skill.skillData.RefreshTimePVP, base.level, true));
					}
				}
			}
		});
	}

	// Token: 0x06018781 RID: 100225 RVA: 0x007A38F7 File Offset: 0x007A1CF7
	public override void OnCancel()
	{
		base.OnCancel();
		this.RemoveBuff();
	}

	// Token: 0x06018782 RID: 100226 RVA: 0x007A3905 File Offset: 0x007A1D05
	private void RemoveBuff()
	{
		base.owner.buffController.RemoveBuff(1, 0, 0);
	}

	// Token: 0x06018783 RID: 100227 RVA: 0x007A391A File Offset: 0x007A1D1A
	public override void OnFinish()
	{
		this.RemoveBuff();
		if (this.m_XuNianPaoHandle != null)
		{
			this.m_XuNianPaoHandle.Remove();
		}
	}

	// Token: 0x04011A88 RID: 72328
	protected int m_XuNianPaoPhaseId = 301012;

	// Token: 0x04011A89 RID: 72329
	protected int m_XuNianPaoId = 3111;

	// Token: 0x04011A8A RID: 72330
	private BeEventHandle m_XuNianPaoHandle;
}
