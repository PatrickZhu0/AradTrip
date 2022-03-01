using System;
using System.Collections.Generic;

// Token: 0x0200016E RID: 366
public class InputButtonSliderMode
{
	// Token: 0x06000A96 RID: 2710 RVA: 0x000368E0 File Offset: 0x00034CE0
	public void AddComboSkill(CombineSkillUnit[] comboList)
	{
		if (comboList == null)
		{
			return;
		}
		Queue<CombineSkillUnit> queue = new Queue<CombineSkillUnit>();
		for (int i = 0; i < comboList.Length; i++)
		{
			if (comboList[i] != null)
			{
				queue.Enqueue(comboList[i]);
			}
		}
		this.queue.Enqueue(queue);
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x0003692C File Offset: 0x00034D2C
	public void Update(int delta)
	{
		while (this.queue.Count > 0)
		{
			if (this.lastSkillList == null)
			{
				this.lastSkillList = this.queue.Dequeue();
			}
			while (this.lastSkillList != null && this.lastSkillList.Count > 0)
			{
				if (this.lastSkillUnit == null)
				{
					this.lastSkillUnit = this.lastSkillList.Dequeue();
				}
				this.lastSkillUnit.time -= delta;
				if (this.lastSkillUnit.time <= 0)
				{
					int slot = this.lastSkillUnit.slot;
					this.lastSkillList = null;
				}
			}
		}
	}

	// Token: 0x040007B2 RID: 1970
	private Queue<Queue<CombineSkillUnit>> queue = new Queue<Queue<CombineSkillUnit>>();

	// Token: 0x040007B3 RID: 1971
	private Queue<CombineSkillUnit> lastSkillList;

	// Token: 0x040007B4 RID: 1972
	private CombineSkillUnit lastSkillUnit;
}
