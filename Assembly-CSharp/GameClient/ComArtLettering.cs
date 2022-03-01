using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200142A RID: 5162
	public class ComArtLettering : MonoBehaviour
	{
		// Token: 0x0600C83B RID: 51259 RVA: 0x00308E24 File Offset: 0x00307224
		public void SetNum(int num)
		{
			if (string.IsNullOrEmpty(this.M_ArtTexturePath))
			{
				Logger.LogError("Please Fix ,ComArtLettering : M_ArtTexturePath is null or empty");
				return;
			}
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
				if (!ETCImageLoader.LoadSprite(ref this.rmbImgs[j], string.Format(this.M_ArtTexturePath, num5), true))
				{
					Logger.LogErrorFormat("Can not load Asset res {0} failed", new object[]
					{
						string.Format(this.M_ArtTexturePath, num5)
					});
				}
				else
				{
					this.rmbImgs[j].CustomActive(true);
				}
			}
		}

		// Token: 0x0600C83C RID: 51260 RVA: 0x00308F94 File Offset: 0x00307394
		public void SetNum(string numStr)
		{
			if (string.IsNullOrEmpty(this.M_ArtTexturePath))
			{
				Logger.LogError("Please Fix ,ComArtLettering : M_ArtTexturePath is null or empty");
				return;
			}
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
				if (!ETCImageLoader.LoadSprite(ref this.rmbImgs[j], string.Format(this.M_ArtTexturePath, num4), true))
				{
					Logger.LogErrorFormat("Can not load Asset res {0} failed", new object[]
					{
						string.Format(this.M_ArtTexturePath, num4)
					});
				}
				else
				{
					this.rmbImgs[j].CustomActive(true);
				}
			}
		}

		// Token: 0x04007350 RID: 29520
		[Header("选择一张合图并确认该合图中有连续后缀名的美术字图片路径，序号用{0}替代")]
		[SerializeField]
		private string M_ArtTexturePath;

		// Token: 0x04007351 RID: 29521
		[Space(10f)]
		[Header("目前只支持五位数 0 ~  99999 ")]
		[SerializeField]
		private Image[] rmbImgs;
	}
}
