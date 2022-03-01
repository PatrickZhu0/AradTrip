using System;

namespace HeroInput
{
	// Token: 0x0200016A RID: 362
	public class DragClickSkillItem : ClickSkillBaseItem
	{
		// Token: 0x06000A8C RID: 2700 RVA: 0x000367C1 File Offset: 0x00034BC1
		public override void Update(int deltaTime)
		{
			if (base.isDead)
			{
				return;
			}
			base.Update(deltaTime);
		}
	}
}
