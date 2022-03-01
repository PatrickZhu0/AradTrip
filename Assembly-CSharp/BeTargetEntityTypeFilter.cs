using System;
using System.Collections.Generic;

// Token: 0x0200418E RID: 16782
public class BeTargetEntityTypeFilter : IEntityFilter
{
	// Token: 0x0601706A RID: 94314 RVA: 0x0071070C File Offset: 0x0070EB0C
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		if (target == null)
		{
			return false;
		}
		if (this.targetEntityType != BeAIManager.TargetEntityType.DEFAULT)
		{
			if (this.targetEntityType == BeAIManager.TargetEntityType.PLAYER)
			{
				if (target.CurrentBeBattle == null || target.CurrentBeBattle.dungeonPlayerManager == null || target.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers() == null)
				{
					return false;
				}
				List<BattlePlayer> allPlayers = target.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
				for (int i = 0; i < allPlayers.Count; i++)
				{
					if (allPlayers[i].playerActor != null)
					{
						if (allPlayers[i].playerActor.GetPID() == target.GetPID())
						{
							return true;
						}
					}
				}
			}
			else if (this.targetEntityType == BeAIManager.TargetEntityType.MONSTER)
			{
				if (this.isBoss)
				{
					return beActor.IsMonster() && beActor.IsBoss();
				}
				return beActor.IsMonster();
			}
			else if (this.targetEntityType == BeAIManager.TargetEntityType.SUMMON)
			{
				return beActor.GetEntityData().isSummonMonster;
			}
			return false;
		}
		if (this.isBoss)
		{
			return beActor.IsMonster() && beActor.IsBoss();
		}
		return beActor.IsMonster() && beActor.attribute.autoFightNeedAttackFirst;
	}

	// Token: 0x0601706B RID: 94315 RVA: 0x00710858 File Offset: 0x0070EC58
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x0401094C RID: 67916
	public BeAIManager.TargetEntityType targetEntityType;

	// Token: 0x0401094D RID: 67917
	public bool isBoss;
}
