using System;
using System.Collections.Generic;
using ProtoTable;

// Token: 0x020044BB RID: 17595
public class Skill3107 : BeSkill
{
	// Token: 0x060187A2 RID: 100258 RVA: 0x007A4065 File Offset: 0x007A2465
	public Skill3107(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187A3 RID: 100259 RVA: 0x007A407C File Offset: 0x007A247C
	public override void OnInit()
	{
		this.m_SkillBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.m_PveBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.m_PvpBuffId = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
	}

	// Token: 0x060187A4 RID: 100260 RVA: 0x007A40F2 File Offset: 0x007A24F2
	public override void OnPostInit()
	{
		this.m_OwnerRebornHandle = base.owner.RegisterEvent(BeEventType.onReborn, delegate(object[] arg)
		{
			this.OwnerReborn();
		});
		this.AddBuff();
		this.AddSkillBuff();
	}

	// Token: 0x060187A5 RID: 100261 RVA: 0x007A4120 File Offset: 0x007A2520
	protected void OwnerReborn()
	{
		if (base.owner.buffController.HasBuffByID(this.m_BuffId) != null)
		{
			base.owner.buffController.RemoveBuff(this.m_BuffId, 0, 0);
		}
		base.owner.buffController.TryAddBuff(this.m_BuffId, -1, 1);
	}

	// Token: 0x060187A6 RID: 100262 RVA: 0x007A417C File Offset: 0x007A257C
	protected void AddBuff()
	{
		int buffID;
		if (!BattleMain.IsModePvP(base.battleType))
		{
			buffID = this.m_PveBuffId;
		}
		else
		{
			buffID = this.m_PvpBuffId;
		}
		base.owner.buffController.RemoveBuff(this.m_SkillBuffId, 0, 0);
		base.owner.buffController.RemoveBuff(buffID, 0, 0);
		base.owner.buffController.TryAddBuff(this.m_SkillBuffId, -1, base.level);
		base.owner.buffController.TryAddBuff(buffID, -1, base.level);
	}

	// Token: 0x060187A7 RID: 100263 RVA: 0x007A4210 File Offset: 0x007A2610
	protected void AddSkillBuff()
	{
		IList<UnionCell> list;
		if (!BattleMain.IsModePvP(base.battleType))
		{
			list = this.skillData.ValueD;
		}
		else
		{
			list = this.skillData.ValueE;
		}
		for (int i = 0; i < list.Count; i++)
		{
			int fixInitValue = list[i].fixInitValue;
			int fixLevelGrow = list[i].fixLevelGrow;
			int level = base.level;
			base.owner.buffController.RemoveBuff(fixLevelGrow, 0, 0);
			base.owner.buffController.AddBuffForSkill(fixLevelGrow, level, -1, new List<int>
			{
				fixInitValue
			});
		}
	}

	// Token: 0x04011A98 RID: 72344
	protected int m_SkillBuffId;

	// Token: 0x04011A99 RID: 72345
	protected int m_PveBuffId;

	// Token: 0x04011A9A RID: 72346
	protected int m_PvpBuffId;

	// Token: 0x04011A9B RID: 72347
	protected int m_BuffId = 180050;

	// Token: 0x04011A9C RID: 72348
	protected BeEventHandle m_OwnerRebornHandle;
}
