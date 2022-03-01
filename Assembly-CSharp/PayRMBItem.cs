using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200195B RID: 6491
public class PayRMBItem : MonoBehaviour
{
	// Token: 0x0600FC62 RID: 64610 RVA: 0x00455F84 File Offset: 0x00454384
	public void SetRMBNum(int num)
	{
		int num2 = num;
		int length = Mathf.Abs(num2).ToString().Length;
		if (this.rmbImgs == null)
		{
			Logger.LogError("Try to set rmb image is failed, image component is null");
			return;
		}
		if (length > this.rmbImgs.Length)
		{
			Logger.LogErrorFormat("Please Fix , rmb num count is {0}, rmb image length is {1}", new object[]
			{
				length,
				this.rmbImgs.Length
			});
			return;
		}
		for (int i = length; i < this.rmbImgs.Length; i++)
		{
			this.rmbImgs[i].gameObject.CustomActive(false);
		}
		for (int j = 0; j < length; j++)
		{
			int num3 = length - 1 - j;
			int num4 = (int)Mathf.Pow(10f, (float)num3);
			int num5;
			if (num3 == 0)
			{
				num5 = num2;
			}
			else
			{
				num5 = num2 / num4;
				num2 %= num4;
			}
			ETCImageLoader.LoadSprite(ref this.rmbImgs[j], string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Shouchong_ShuZi_{0}", num5), true);
			this.rmbImgs[j].gameObject.CustomActive(true);
		}
	}

	// Token: 0x0600FC63 RID: 64611 RVA: 0x004560AC File Offset: 0x004544AC
	public void SetRMBNum(string numStr)
	{
		if (string.IsNullOrEmpty(numStr))
		{
			return;
		}
		int num = 0;
		if (!int.TryParse(numStr, out num))
		{
			Logger.LogErrorFormat("Please Fix , rmb string {0} convert to int is error", new object[]
			{
				numStr
			});
			return;
		}
		int length = numStr.ToString().Length;
		if (this.rmbImgs == null)
		{
			Logger.LogError("Try to set rmb image is failed, image component is null");
			return;
		}
		if (length > this.rmbImgs.Length)
		{
			Logger.LogErrorFormat("Please Fix , rmb num count is {0}, rmb image length is {1}", new object[]
			{
				length,
				this.rmbImgs.Length
			});
			return;
		}
		for (int i = length; i < this.rmbImgs.Length; i++)
		{
			this.rmbImgs[i].gameObject.CustomActive(false);
		}
		for (int j = 0; j < length; j++)
		{
			int num2 = length - 1 - j;
			int num3 = (int)Mathf.Pow(10f, (float)num2);
			int num4;
			if (num2 == 0)
			{
				num4 = num;
			}
			else
			{
				num4 = num / num3;
				num %= num3;
			}
			ETCImageLoader.LoadSprite(ref this.rmbImgs[j], string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Shouchong_ShuZi_{0}", num4), true);
			this.rmbImgs[j].gameObject.CustomActive(true);
		}
	}

	// Token: 0x04009E2A RID: 40490
	private const string VIP_PAY_RMB_IMAGE_PATH = "UI/Image/Packed/p_UI_Vip.png:UI_Shouchong_ShuZi_{0}";

	// Token: 0x04009E2B RID: 40491
	[SerializeField]
	private Image[] rmbImgs;
}
