using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001962 RID: 6498
	public class VipPrivilegeItem : MonoBehaviour
	{
		// Token: 0x0600FCB0 RID: 64688 RVA: 0x004582B2 File Offset: 0x004566B2
		public void InitItem(string itemImagePath, string itemContentStr)
		{
			if (this.itemImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemImage, itemImagePath, true);
			}
			if (this.itemContentLabel != null)
			{
				this.itemContentLabel.text = itemContentStr;
			}
		}

		// Token: 0x04009E7E RID: 40574
		[Space(10f)]
		[Header("PrivilegeItem")]
		[Space(5f)]
		[SerializeField]
		private Image itemImage;

		// Token: 0x04009E7F RID: 40575
		[SerializeField]
		private Text itemContentLabel;
	}
}
