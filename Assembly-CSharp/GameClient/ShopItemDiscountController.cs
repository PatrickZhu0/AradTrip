using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A70 RID: 6768
	public class ShopItemDiscountController : MonoBehaviour
	{
		// Token: 0x060109E7 RID: 68071 RVA: 0x004B354C File Offset: 0x004B194C
		public void InitShopItemDiscount(int discountValue)
		{
			CommonUtility.UpdateGameObjectVisible(this.normalDiscountRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.specialDiscountRoot, false);
			int num = discountValue / 10;
			int num2 = discountValue % 10;
			if (num2 == 0)
			{
				CommonUtility.UpdateGameObjectVisible(this.normalDiscountRoot, true);
				string path = string.Format("UI/Image/Packed/p_UI_Rongyu.png:UI_Rongyu_Zhekou_0{0}", num);
				ETCImageLoader.LoadSprite(ref this.normalDiscountNumberImage, path, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.specialDiscountRoot, true);
				string path2 = string.Format("UI/Image/Packed/p_UI_Rongyu.png:UI_Rongyu_Zhekou_0{0}", num);
				ETCImageLoader.LoadSprite(ref this.specialDiscountFirstNumberImage, path2, true);
				string path3 = string.Format("UI/Image/Packed/p_UI_Rongyu.png:UI_Rongyu_Zhekou_0{0}", num2);
				ETCImageLoader.LoadSprite(ref this.specialDiscountSecondNumberImage, path3, true);
			}
		}

		// Token: 0x0400A997 RID: 43415
		[Space(10f)]
		[Header("NormalDiscount")]
		[Space(10f)]
		[SerializeField]
		private GameObject normalDiscountRoot;

		// Token: 0x0400A998 RID: 43416
		[SerializeField]
		private Image normalDiscountNumberImage;

		// Token: 0x0400A999 RID: 43417
		[Space(10f)]
		[Header("SpecialDiscount")]
		[Space(10f)]
		[SerializeField]
		private GameObject specialDiscountRoot;

		// Token: 0x0400A99A RID: 43418
		[SerializeField]
		private Image specialDiscountFirstNumberImage;

		// Token: 0x0400A99B RID: 43419
		[SerializeField]
		private Image specialDiscountSecondNumberImage;

		// Token: 0x0400A99C RID: 43420
		private const string imagePath = "UI/Image/Packed/p_UI_Rongyu.png:UI_Rongyu_Zhekou_0{0}";
	}
}
