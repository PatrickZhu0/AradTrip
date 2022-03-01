using System;

// Token: 0x02004117 RID: 16663
public class BeAIAttackCommand : BeAICommand
{
	// Token: 0x06016AFC RID: 92924 RVA: 0x006E0A26 File Offset: 0x006DEE26
	public BeAIAttackCommand(BeEntity e) : base(e, "AIAttackCommand")
	{
		this.cmdType = AI_COMMAND.ATTACK;
	}

	// Token: 0x06016AFD RID: 92925 RVA: 0x006E0A3B File Offset: 0x006DEE3B
	public void Init()
	{
	}

	// Token: 0x06016AFE RID: 92926 RVA: 0x006E0A40 File Offset: 0x006DEE40
	public override void OnExecute()
	{
		if (this.entity != null)
		{
			int normalAttackID = this.entity.GetEntityData().normalAttackID;
			BeActor beActor = this.entity as BeActor;
			if (beActor != null && beActor.CanUseSkill(normalAttackID))
			{
				BeStateData rkStateData = new BeStateData(14, normalAttackID);
				this.entity.Locomote(rkStateData, false);
			}
		}
	}
}
