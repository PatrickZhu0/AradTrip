using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001720 RID: 5920
	internal class LegendTab : CachedSelectedObject<LegendTabData, LegendTab>
	{
		// Token: 0x0600E893 RID: 59539 RVA: 0x003D8350 File Offset: 0x003D6750
		public override void Initialize()
		{
			this.BG = Utility.FindComponent<Image>(this.goLocal, "GrayParent/Image", true);
			this.Title = Utility.FindComponent<Image>(this.goLocal, "GrayParent/Title", true);
			this.goCheckMark = Utility.FindChild(this.goLocal, "GrayParent/CheckMark");
			this.hint = Utility.FindComponent<Text>(this.goLocal, "Hint", true);
			this.comStateController = this.goLocal.GetComponent<StateController>();
		}

		// Token: 0x0600E894 RID: 59540 RVA: 0x003D83C9 File Offset: 0x003D67C9
		public override void UnInitialize()
		{
		}

		// Token: 0x0600E895 RID: 59541 RVA: 0x003D83CC File Offset: 0x003D67CC
		public override void OnUpdate()
		{
			if (base.Value != null && base.Value.mainItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.BG, base.Value.mainItem.Icons[0], true);
				ETCImageLoader.LoadSprite(ref this.Title, base.Value.mainItem.Icons[1], true);
				this.Title.SetNativeSize();
				this.hint.text = TR.Value("legend_series_open_desc", base.Value.mainItem.UnLockLevel);
				this.comStateController.Key = "normal";
				if (null != this.comStateController)
				{
					int legendMainStatus = Utility.GetLegendMainStatus(base.Value.mainItem);
					if (legendMainStatus != 0)
					{
						if (legendMainStatus != 1)
						{
							if (legendMainStatus == 2)
							{
								this.comStateController.Key = "finished";
							}
						}
						else
						{
							this.comStateController.Key = "locked";
						}
					}
					else
					{
						this.comStateController.Key = "normal";
					}
				}
			}
		}

		// Token: 0x0600E896 RID: 59542 RVA: 0x003D84FC File Offset: 0x003D68FC
		public override void OnDisplayChanged(bool bShow)
		{
			this.goCheckMark.CustomActive(bShow);
			if (!bShow)
			{
				this.goLocal.transform.localScale = Vector3.one;
			}
			else
			{
				this.goLocal.transform.localScale = this.hideScale;
			}
		}

		// Token: 0x04008CF8 RID: 36088
		private Image BG;

		// Token: 0x04008CF9 RID: 36089
		private Image Title;

		// Token: 0x04008CFA RID: 36090
		private GameObject goCheckMark;

		// Token: 0x04008CFB RID: 36091
		private Vector3 hideScale = new Vector3(1.03f, 1.03f, 1f);

		// Token: 0x04008CFC RID: 36092
		private Text hint;

		// Token: 0x04008CFD RID: 36093
		private StateController comStateController;
	}
}
