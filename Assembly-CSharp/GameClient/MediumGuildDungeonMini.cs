using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001669 RID: 5737
	public class MediumGuildDungeonMini : MonoBehaviour
	{
		// Token: 0x0600E1A4 RID: 57764 RVA: 0x0039E843 File Offset: 0x0039CC43
		private void Start()
		{
		}

		// Token: 0x0600E1A5 RID: 57765 RVA: 0x0039E845 File Offset: 0x0039CC45
		private void Update()
		{
		}

		// Token: 0x0600E1A6 RID: 57766 RVA: 0x0039E847 File Offset: 0x0039CC47
		private string GetColorString(string text, string color)
		{
			return TR.Value("common_color_text", "#" + color, text);
		}

		// Token: 0x0600E1A7 RID: 57767 RVA: 0x0039E860 File Offset: 0x0039CC60
		public void SetUp(object data)
		{
			GuildDataManager.MediumDungeonDamageInfo mediumDungeonDamageInfo = data as GuildDataManager.MediumDungeonDamageInfo;
			if (mediumDungeonDamageInfo == null)
			{
				return;
			}
			this.nDungeonID = mediumDungeonDamageInfo.nDungeonID;
			if (this.txtBossName != null)
			{
				this.txtBossName.text = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonName((uint)mediumDungeonDamageInfo.nDungeonID);
			}
			if (this.txtKillHpInfo != null)
			{
				this.txtKillHpInfo.text = string.Format("{0} / {1}", this.GetColorString(mediumDungeonDamageInfo.nOddHp.ToString(), "ffd689ff"), mediumDungeonDamageInfo.nMaxHp);
			}
			if (this.sldProcess != null && mediumDungeonDamageInfo.nMaxHp > 0UL)
			{
				this.sldProcess.value = mediumDungeonDamageInfo.nOddHp / mediumDungeonDamageInfo.nMaxHp;
			}
			if (this.imgVerifyBlood != null && mediumDungeonDamageInfo.nMaxHp > 0UL)
			{
				this.imgVerifyBlood.fillAmount = mediumDungeonDamageInfo.nVerifyBlood / mediumDungeonDamageInfo.nMaxHp;
			}
			this.icon.SafeSetImage(DataManager<GuildDataManager>.GetInstance().GetGuildDungeonMiniIconPath((uint)mediumDungeonDamageInfo.nDungeonID), false);
		}

		// Token: 0x04008661 RID: 34401
		[SerializeField]
		private Image icon;

		// Token: 0x04008662 RID: 34402
		[SerializeField]
		private Text txtBossName;

		// Token: 0x04008663 RID: 34403
		[SerializeField]
		private Text txtKillHpInfo;

		// Token: 0x04008664 RID: 34404
		[SerializeField]
		private Slider sldProcess;

		// Token: 0x04008665 RID: 34405
		[SerializeField]
		private Image imgKilled;

		// Token: 0x04008666 RID: 34406
		[SerializeField]
		private Image imgVerifyBlood;

		// Token: 0x04008667 RID: 34407
		private ulong nDungeonID;
	}
}
