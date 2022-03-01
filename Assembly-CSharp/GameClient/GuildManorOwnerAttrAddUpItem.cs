using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001630 RID: 5680
	internal class GuildManorOwnerAttrAddUpItem : ComUIListTemplateItem
	{
		// Token: 0x0600DF1B RID: 57115 RVA: 0x0038EED9 File Offset: 0x0038D2D9
		private void Start()
		{
			this.SetUp(this.skillID);
		}

		// Token: 0x0600DF1C RID: 57116 RVA: 0x0038EEEC File Offset: 0x0038D2EC
		private void OnDestroy()
		{
		}

		// Token: 0x0600DF1D RID: 57117 RVA: 0x0038EEF0 File Offset: 0x0038D2F0
		public override void SetUp(object data)
		{
			int num = (int)data;
			this.attrs.SafeSetText(this.CalcSkillAttrDesc(num));
		}

		// Token: 0x0600DF1E RID: 57118 RVA: 0x0038EF18 File Offset: 0x0038D318
		private string CalcSkillAttrDesc(int skillID)
		{
			List<string> skillDesList = DataManager<SkillDataManager>.GetInstance().GetSkillDesList(skillID, 1, FightTypeLabel.PVE);
			string text = string.Empty;
			for (int i = 0; i < skillDesList.Count; i++)
			{
				string[] array = skillDesList[i].Split(new char[]
				{
					':'
				});
				if (array.Length >= 2)
				{
					string arg = array[0];
					string text2 = array[1];
					int num = 0;
					int.TryParse(text2, out num);
					if (num != 0)
					{
						text += string.Format("{0}+{1}", arg, text2);
						text += "  ";
					}
				}
			}
			return text;
		}

		// Token: 0x04008476 RID: 33910
		[SerializeField]
		private int skillID;

		// Token: 0x04008477 RID: 33911
		[SerializeField]
		private Text attrs;
	}
}
