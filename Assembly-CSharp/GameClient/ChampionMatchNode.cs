using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200107B RID: 4219
	internal class ChampionMatchNode
	{
		// Token: 0x06009F72 RID: 40818 RVA: 0x001FE83F File Offset: 0x001FCC3F
		public ChampionMatchNode(Text name, Image icon, Image bg, Transform wenhao)
		{
			this.name = name;
			this.icon = icon;
			this.bg = bg;
			this.wenhao = wenhao;
		}

		// Token: 0x06009F73 RID: 40819 RVA: 0x001FE864 File Offset: 0x001FCC64
		public void SetName(string strName)
		{
			if (this.name != null)
			{
				this.name.text = strName;
			}
		}

		// Token: 0x06009F74 RID: 40820 RVA: 0x001FE883 File Offset: 0x001FCC83
		public void SetNameColor(Color color)
		{
			if (this.name != null)
			{
				this.name.color = color;
			}
		}

		// Token: 0x06009F75 RID: 40821 RVA: 0x001FE8A4 File Offset: 0x001FCCA4
		public void SetIcon(string path)
		{
			if (this.icon != null)
			{
				if (path != null && path != string.Empty)
				{
					ETCImageLoader.LoadSprite(ref this.icon, path, true);
				}
				else
				{
					Logger.LogError("Icon 地址为空！！！！！");
				}
			}
		}

		// Token: 0x06009F76 RID: 40822 RVA: 0x001FE8F8 File Offset: 0x001FCCF8
		public void SetActive(bool active)
		{
			if (this.name != null)
			{
				this.name.gameObject.SetActive(active);
			}
			if (this.wenhao != null)
			{
				this.wenhao.gameObject.SetActive(!active);
			}
			if (this.icon != null)
			{
				this.icon.gameObject.SetActive(active);
			}
		}

		// Token: 0x06009F77 RID: 40823 RVA: 0x001FE970 File Offset: 0x001FCD70
		public void SetLose()
		{
			if (this.bg != null)
			{
				ETCImageLoader.LoadSprite(ref this.bg, "UI/Image/Packed/p_UI_Icon_skillIcon.png:UI_Zhandou_Mingzi_Di_Huang", true);
				this.name.color = new Color32(154, 154, 154, byte.MaxValue);
			}
		}

		// Token: 0x040057E8 RID: 22504
		public Text name;

		// Token: 0x040057E9 RID: 22505
		public Image icon;

		// Token: 0x040057EA RID: 22506
		public Image bg;

		// Token: 0x040057EB RID: 22507
		public Transform wenhao;
	}
}
