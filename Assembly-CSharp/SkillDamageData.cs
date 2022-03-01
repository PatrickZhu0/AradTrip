using System;
using System.Collections.Generic;

// Token: 0x020010DE RID: 4318
public struct SkillDamageData
{
	// Token: 0x04005B20 RID: 23328
	public int totalTime;

	// Token: 0x04005B21 RID: 23329
	public string dungeonName;

	// Token: 0x04005B22 RID: 23330
	public List<int> monsterIdList;

	// Token: 0x04005B23 RID: 23331
	public List<string> monsterNameList;

	// Token: 0x04005B24 RID: 23332
	public List<int> origionSkillIdList;

	// Token: 0x04005B25 RID: 23333
	public List<int> origionSkillIdUseCount;

	// Token: 0x04005B26 RID: 23334
	public Dictionary<int, List<DamageData>> skillDamageDic;

	// Token: 0x04005B27 RID: 23335
	public List<MonsterExistTime> monsterExistTimeList;
}
