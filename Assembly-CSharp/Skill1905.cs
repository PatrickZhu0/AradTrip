using System;

// Token: 0x02004473 RID: 17523
public class Skill1905 : BeSkill
{
	// Token: 0x060185D2 RID: 99794 RVA: 0x007973D6 File Offset: 0x007957D6
	public Skill1905(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185D3 RID: 99795 RVA: 0x007973E0 File Offset: 0x007957E0
	public override void OnPostInit()
	{
		this.RemoveHandle();
		this.handle = base.owner.RegisterEvent(BeEventType.ConfigCommand, delegate(object[] args)
		{
			if (base.owner.GetEntityData() != null && base.owner.GetEntityData().professtion == 11 && base.owner.attackReplaceLigui && !BattleMain.IsModePvP(base.owner.battleType))
			{
				base.owner.GetEntityData().normalAttackID = 1901;
			}
		});
	}

	// Token: 0x060185D4 RID: 99796 RVA: 0x00797407 File Offset: 0x00795807
	private void RemoveHandle()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011969 RID: 72041
	private BeEventHandle handle;
}
