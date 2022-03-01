using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F6 RID: 6646
	internal class ComFriendBackBuffBonusInfo : MonoBehaviour
	{
		// Token: 0x060104DF RID: 66783 RVA: 0x00491FC0 File Offset: 0x004903C0
		public void OnItemVisible(BackBuffBonusInfo backBuffBonusInfo)
		{
			if (backBuffBonusInfo == null)
			{
				return;
			}
			if (this.buffIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.buffIcon, backBuffBonusInfo.IconPath, true);
			}
			if (this.buffDes != null)
			{
				this.buffDes.text = backBuffBonusInfo.Name;
			}
		}

		// Token: 0x0400A510 RID: 42256
		public Image buffIcon;

		// Token: 0x0400A511 RID: 42257
		public Text buffDes;
	}
}
