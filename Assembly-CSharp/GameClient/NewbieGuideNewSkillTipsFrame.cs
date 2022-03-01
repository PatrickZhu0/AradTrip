using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200102A RID: 4138
	public class NewbieGuideNewSkillTipsFrame : ClientFrame
	{
		// Token: 0x06009C9E RID: 40094 RVA: 0x001E98EB File Offset: 0x001E7CEB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideAddSkill2";
		}

		// Token: 0x06009C9F RID: 40095 RVA: 0x001E98F4 File Offset: 0x001E7CF4
		public void SetSkill(int[] skill)
		{
			for (int i = 0; i < skill.Length; i++)
			{
				SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skill[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.mFiledNameList[i], tableItem.Icon, true);
					this.mTexts[i].text = tableItem.Name;
				}
			}
		}

		// Token: 0x040055F6 RID: 22006
		[UIControl("Skill{0}/FgImage", typeof(Image), 1)]
		private Image[] mFiledNameList = new Image[2];

		// Token: 0x040055F7 RID: 22007
		[UIControl("Skill{0}/SkillName", typeof(Text), 1)]
		private Text[] mTexts = new Text[2];
	}
}
