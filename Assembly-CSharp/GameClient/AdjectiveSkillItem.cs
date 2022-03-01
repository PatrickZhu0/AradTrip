using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A9B RID: 6811
	public class AdjectiveSkillItem : MonoBehaviour
	{
		// Token: 0x06010B9B RID: 68507 RVA: 0x004BE2A0 File Offset: 0x004BC6A0
		public void InitItem(PassiveSkillData passiveSkillData)
		{
			SkillTable skillData = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>(passiveSkillData.skillid, string.Empty, string.Empty);
			if (skillData == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<SkillDescriptionTable>(passiveSkillData.skillid, string.Empty, string.Empty) == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.mIcon, skillData.Icon, true);
			ETCImageLoader.LoadSprite(ref this.mSmallIcon, skillData.SmallIcon, true);
			this.mSkillBtn.onClick.RemoveAllListeners();
			this.mSkillBtn.onClick.AddListener(delegate()
			{
				AdjectiveSkillTipsData adjectiveSkillTipsData = new AdjectiveSkillTipsData();
				adjectiveSkillTipsData.Name = skillData.Name;
				adjectiveSkillTipsData.Des = DataManager<SkillDataManager>.GetInstance().UpdateSkillDescription(passiveSkillData.skillid, 1, 1, FightTypeLabel.PVE);
				adjectiveSkillTipsData.vec = Input.mousePosition;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AdjectiveSkillTipsFrame>(FrameLayer.Middle, adjectiveSkillTipsData, string.Empty);
			});
		}

		// Token: 0x0400AB00 RID: 43776
		[SerializeField]
		private Image mIcon;

		// Token: 0x0400AB01 RID: 43777
		[SerializeField]
		private Image mSmallIcon;

		// Token: 0x0400AB02 RID: 43778
		[SerializeField]
		private Button mSkillBtn;
	}
}
