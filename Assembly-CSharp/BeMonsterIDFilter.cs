using System;
using System.Collections.Generic;

// Token: 0x02004189 RID: 16777
public class BeMonsterIDFilter : IEntityFilter
{
	// Token: 0x06017059 RID: 94297 RVA: 0x007105D0 File Offset: 0x0070E9D0
	public BeMonsterIDFilter(List<int> monsterId)
	{
		this._monsterids = monsterId;
	}

	// Token: 0x0601705A RID: 94298 RVA: 0x007105DF File Offset: 0x0070E9DF
	public void Init(List<int> monsterId)
	{
		this._monsterids = monsterId;
	}

	// Token: 0x0601705B RID: 94299 RVA: 0x007105E8 File Offset: 0x0070E9E8
	public bool isFit(BeEntity monster)
	{
		if (monster == null || monster.GetEntityData() == null)
		{
			return false;
		}
		for (int i = 0; i < this._monsterids.Count; i++)
		{
			if (monster.GetEntityData().MonsterIDEqual(this._monsterids[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601705C RID: 94300 RVA: 0x00710643 File Offset: 0x0070EA43
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x04010947 RID: 67911
	private List<int> _monsterids;
}
