using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200196F RID: 6511
	public class ReplaceHeadPortraitFrame : MonoBehaviour
	{
		// Token: 0x0600FD20 RID: 64800 RVA: 0x0045AD10 File Offset: 0x00459110
		public void ReplacePhotoFrame(int id)
		{
			string headPortraitFramePath = HeadPortraitFrameDataManager.GetHeadPortraitFramePath(id);
			if (headPortraitFramePath == string.Empty)
			{
				return;
			}
			if (this.mImgHeadPortraitFrame != null)
			{
				ETCImageLoader.LoadSprite(ref this.mImgHeadPortraitFrame, headPortraitFramePath, true);
			}
		}

		// Token: 0x04009F04 RID: 40708
		[SerializeField]
		private Image mImgHeadPortraitFrame;
	}
}
