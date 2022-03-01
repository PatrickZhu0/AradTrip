using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001668 RID: 5736
	public class MediumGuildDungeon : MonoBehaviour
	{
		// Token: 0x0600E19D RID: 57757 RVA: 0x0039E490 File Offset: 0x0039C890
		private void Start()
		{
			this.imgVerifyBloodInitWidth = 0f;
			if (this.btnBk != null)
			{
				this.btnBk.onClick.RemoveAllListeners();
				this.btnBk.onClick.AddListener(delegate()
				{
					GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
					if (guildDungeonActivityData != null && guildDungeonActivityData.mediumDungeonDamgeInfos != null)
					{
						for (int i = 0; i < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; i++)
						{
							if (guildDungeonActivityData.mediumDungeonDamgeInfos[i].nDungeonID == this.nDungeonID && guildDungeonActivityData.mediumDungeonDamgeInfos[i].nOddHp == 0UL)
							{
								SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonMonsterHaveKilledCanNotEnter"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
								return;
							}
						}
					}
					ChapterBaseFrame.sDungeonID = (int)this.nDungeonID;
					Singleton<ClientSystemManager>.instance.OpenFrame<GuildDungeonCityInfoFrame>(FrameLayer.Middle, null, string.Empty);
				});
			}
			this.btnHowToPlay.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonHowToPlayFrame>(FrameLayer.Middle, this.nDungeonID, string.Empty);
			});
			if (this.imgVerifyBlood != null)
			{
				this.imgVerifyBloodInitWidth = this.imgVerifyBlood.rectTransform.sizeDelta.x;
			}
		}

		// Token: 0x0600E19E RID: 57758 RVA: 0x0039E52B File Offset: 0x0039C92B
		private void Update()
		{
		}

		// Token: 0x0600E19F RID: 57759 RVA: 0x0039E52D File Offset: 0x0039C92D
		private string GetColorString(string text, string color)
		{
			return TR.Value("common_color_text", "#" + color, text);
		}

		// Token: 0x0600E1A0 RID: 57760 RVA: 0x0039E548 File Offset: 0x0039C948
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
			if (this.txtDungeonLv != null)
			{
				this.txtDungeonLv.text = "Lv. " + DataManager<GuildDataManager>.GetInstance().GetGuildDungeonLv((uint)mediumDungeonDamageInfo.nDungeonID).ToString();
			}
			if (this.txtKillHpInfo != null)
			{
				this.txtKillHpInfo.text = string.Format("{0} / {1}", this.GetColorString(mediumDungeonDamageInfo.nOddHp.ToString(), "dc5d5dFF"), mediumDungeonDamageInfo.nMaxHp);
			}
			if (this.sldProcess != null && mediumDungeonDamageInfo.nMaxHp > 0UL)
			{
				this.sldProcess.value = mediumDungeonDamageInfo.nOddHp / mediumDungeonDamageInfo.nMaxHp;
			}
			if (this.imgIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.imgIcon, DataManager<GuildDataManager>.GetInstance().GetGuildDungeonIconPath((uint)this.nDungeonID), true);
			}
			if (this.imgKilled != null)
			{
				this.imgKilled.CustomActive(mediumDungeonDamageInfo.nOddHp == 0UL);
			}
			if (this.imgVerifyBlood != null && mediumDungeonDamageInfo.nMaxHp > 0UL)
			{
				this.imgVerifyBlood.CustomActive(true);
				Vector2 sizeDelta = this.imgVerifyBlood.rectTransform.sizeDelta;
				sizeDelta.x = this.imgVerifyBloodInitWidth * (mediumDungeonDamageInfo.nVerifyBlood / mediumDungeonDamageInfo.nMaxHp);
				this.imgVerifyBlood.rectTransform.sizeDelta = sizeDelta;
			}
			if (this.imgIcon != null && mediumDungeonDamageInfo.nOddHp == 0UL)
			{
				UIGray uigray = this.imgIcon.gameObject.SafeAddComponent(false);
				if (null != uigray)
				{
					uigray.enabled = true;
					uigray.SetEnable(true);
				}
			}
		}

		// Token: 0x04008654 RID: 34388
		[SerializeField]
		private Text txtBossName;

		// Token: 0x04008655 RID: 34389
		[SerializeField]
		private Text txtDungeonLv;

		// Token: 0x04008656 RID: 34390
		[SerializeField]
		private Text txtKillHpInfo;

		// Token: 0x04008657 RID: 34391
		[SerializeField]
		private Slider sldProcess;

		// Token: 0x04008658 RID: 34392
		[SerializeField]
		private Button btnBk;

		// Token: 0x04008659 RID: 34393
		[SerializeField]
		private Image imgIcon;

		// Token: 0x0400865A RID: 34394
		[SerializeField]
		private Text txtCurHp;

		// Token: 0x0400865B RID: 34395
		[SerializeField]
		private Text txtMaxHp;

		// Token: 0x0400865C RID: 34396
		[SerializeField]
		private Image imgKilled;

		// Token: 0x0400865D RID: 34397
		[SerializeField]
		private Button btnHowToPlay;

		// Token: 0x0400865E RID: 34398
		[SerializeField]
		private Image imgVerifyBlood;

		// Token: 0x0400865F RID: 34399
		private ulong nDungeonID;

		// Token: 0x04008660 RID: 34400
		private float imgVerifyBloodInitWidth;
	}
}
