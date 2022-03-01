using System;
using System.Collections.Generic;

// Token: 0x02004195 RID: 16789
public class GetMosterByIDListFilter : IEntityFilter
{
	// Token: 0x06017081 RID: 94337 RVA: 0x00710BC8 File Offset: 0x0070EFC8
	public bool isFit(BeEntity monster)
	{
		if (this.monsterIdList == null || this.monsterIdList.Count == 0 || monster == null)
		{
			return false;
		}
		List<int>.Enumerator enumerator = this.monsterIdList.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (monster.GetEntityData().MonsterIDEqual(enumerator.Current))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017082 RID: 94338 RVA: 0x00710C2F File Offset: 0x0070F02F
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x0401095B RID: 67931
	public List<int> monsterIdList;
}
