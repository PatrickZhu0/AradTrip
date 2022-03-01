using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200102B RID: 4139
	public class NewbieGuideFinalSkillTipsFrame : ClientFrame
	{
		// Token: 0x06009CA1 RID: 40097 RVA: 0x001E9967 File Offset: 0x001E7D67
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideUseSkill";
		}

		// Token: 0x06009CA2 RID: 40098 RVA: 0x001E996E File Offset: 0x001E7D6E
		[UIEventHandle("Skill")]
		private void _onClose()
		{
			this.frameMgr.CloseFrame<NewbieGuideFinalSkillTipsFrame>(this, false);
		}

		// Token: 0x06009CA3 RID: 40099 RVA: 0x001E9980 File Offset: 0x001E7D80
		public void SetSkill(int skill)
		{
			SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skill, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.Icon, true);
			}
		}

		// Token: 0x040055F8 RID: 22008
		[UIControl("Skill/FgImage", typeof(Image), 0)]
		private Image mIcon;
	}
}
