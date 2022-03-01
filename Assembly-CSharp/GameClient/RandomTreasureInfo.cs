using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019D2 RID: 6610
	public class RandomTreasureInfo : MonoBehaviour
	{
		// Token: 0x06010318 RID: 66328 RVA: 0x00484457 File Offset: 0x00482857
		private void Start()
		{
			if (this.mInfoTitleImgBtn)
			{
				this.mInfoTitleImgBtn.onClick.AddListener(new UnityAction(this._OnTitleBtnClick));
			}
		}

		// Token: 0x06010319 RID: 66329 RVA: 0x00484488 File Offset: 0x00482888
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			if (this.mInfoTitleImgBtn)
			{
				this.mInfoTitleImgBtn.onClick.RemoveListener(new UnityAction(this._OnTitleBtnClick));
			}
			this.onTitleBtnClick = null;
		}

		// Token: 0x0601031A RID: 66330 RVA: 0x004844EB File Offset: 0x004828EB
		private void _OnTitleBtnClick()
		{
			if (this.onTitleBtnClick != null)
			{
				this.onTitleBtnClick();
			}
		}

		// Token: 0x0601031B RID: 66331 RVA: 0x00484503 File Offset: 0x00482903
		public void SetInfoContent(string content)
		{
			if (this.mInfoContent)
			{
				this.mInfoContent.text = content;
			}
		}

		// Token: 0x0601031C RID: 66332 RVA: 0x00484521 File Offset: 0x00482921
		public void SetInfoTitleImg(string resPath)
		{
			if (this.mInfoTitleImg && !string.IsNullOrEmpty(resPath))
			{
				ETCImageLoader.LoadSprite(ref this.mInfoTitleImg, resPath, true);
			}
		}

		// Token: 0x0601031D RID: 66333 RVA: 0x0048454C File Offset: 0x0048294C
		public void SetInfoImgWithItem(ItemData itemData)
		{
			if (this.comItem == null && this.mInfoTitleImg)
			{
				this.comItem = ComItemManager.Create(this.mInfoTitleImg.gameObject);
				ComItem comItem = this.comItem;
				if (RandomTreasureInfo.<>f__mg$cache0 == null)
				{
					RandomTreasureInfo.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(itemData, RandomTreasureInfo.<>f__mg$cache0);
			}
		}

		// Token: 0x0400A3BD RID: 41917
		private ComItem comItem;

		// Token: 0x0400A3BE RID: 41918
		public RandomTreasureInfo.TitleBtnClickHandle onTitleBtnClick;

		// Token: 0x0400A3BF RID: 41919
		[SerializeField]
		private Image mInfoTitleImg;

		// Token: 0x0400A3C0 RID: 41920
		[SerializeField]
		private Button mInfoTitleImgBtn;

		// Token: 0x0400A3C1 RID: 41921
		[SerializeField]
		private Text mInfoContent;

		// Token: 0x0400A3C2 RID: 41922
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x020019D3 RID: 6611
		// (Invoke) Token: 0x0601031F RID: 66335
		public delegate void TitleBtnClickHandle();
	}
}
