using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A9C RID: 6812
	public class AdjectiveSkillItemRoot : MonoBehaviour
	{
		// Token: 0x06010B9D RID: 68509 RVA: 0x004BE3E4 File Offset: 0x004BC7E4
		public void InitSkillRoot(int level, List<PassiveSkillData> skillList)
		{
			this.Lv.text = string.Format("Lv.{0}", level);
			this.LockLv.text = string.Format("Lv.{0}解锁", level);
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= level)
			{
				this.Lv.CustomActive(true);
				this.LockLv.CustomActive(false);
			}
			else
			{
				this.Lv.CustomActive(false);
				this.LockLv.CustomActive(true);
			}
			for (int i = 0; i < skillList.Count; i++)
			{
				if (i > this.SkillItem.Length)
				{
					Logger.LogErrorFormat("技能表里配置当前等级{0}的辅助技能长度大于预制体里配置的技能数量", new object[0]);
					break;
				}
				this.SkillItem[i].InitItem(skillList[i]);
			}
		}

		// Token: 0x0400AB03 RID: 43779
		[SerializeField]
		private Text Lv;

		// Token: 0x0400AB04 RID: 43780
		[SerializeField]
		private Text LockLv;

		// Token: 0x0400AB05 RID: 43781
		[SerializeField]
		private AdjectiveSkillItem[] SkillItem;
	}
}
