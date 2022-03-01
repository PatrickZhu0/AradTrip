using System;
using System.Collections.Generic;

// Token: 0x02004187 RID: 16775
public class BeSummonMonsterIdFilter : IEntityFilter
{
	// Token: 0x06017054 RID: 94292 RVA: 0x007104FC File Offset: 0x0070E8FC
	public bool isFit(BeEntity monster)
	{
		if (this.ownerId == 0 || this.summonMonsterId == null || monster == null)
		{
			return false;
		}
		BeEntity topOwner = monster.GetTopOwner(monster);
		if (topOwner != null && topOwner.GetPID() == this.ownerId)
		{
			List<int>.Enumerator enumerator = this.summonMonsterId.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (monster.GetEntityData().MonsterIDEqual(enumerator.Current))
				{
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x06017055 RID: 94293 RVA: 0x0071057F File Offset: 0x0070E97F
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x04010944 RID: 67908
	public List<int> summonMonsterId;

	// Token: 0x04010945 RID: 67909
	public int ownerId;
}
