using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012EC RID: 4844
	public class SkillLevelAddInfo
	{
		// Token: 0x0600BBC6 RID: 48070 RVA: 0x002BA0FC File Offset: 0x002B84FC
		public int GetCurrentTotalAddNum()
		{
			int num = 0;
			for (int i = 0; i < this.items.Count; i++)
			{
				num += this.items[i].addLevel;
			}
			return num;
		}

		// Token: 0x0600BBC7 RID: 48071 RVA: 0x002BA13C File Offset: 0x002B853C
		public void DebugPrint(int skillID)
		{
			Logger.LogErrorFormat("技能:{0} 等级总加成:{1}\n", new object[]
			{
				skillID,
				this.totalAddLevel
			});
			for (int i = 0; i < this.items.Count; i++)
			{
				Logger.LogErrorFormat("{0}:{1}", new object[]
				{
					this.items[i].type,
					this.items[i].addLevel
				});
			}
		}

		// Token: 0x040069A5 RID: 27045
		public List<SkillLevelAddItem> items = new List<SkillLevelAddItem>();

		// Token: 0x040069A6 RID: 27046
		public int totalAddLevel;
	}
}
