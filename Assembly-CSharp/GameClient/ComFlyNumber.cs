using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EEB RID: 3819
	public class ComFlyNumber : MonoBehaviour
	{
		// Token: 0x06009596 RID: 38294 RVA: 0x001C3D43 File Offset: 0x001C2143
		private void _updateNumber(int num)
		{
			if (null != this.mNumber)
			{
				this.mNumber.text = string.Format("{0}", num);
			}
		}

		// Token: 0x06009597 RID: 38295 RVA: 0x001C3D74 File Offset: 0x001C2174
		public void SetNumber(int finalnum)
		{
			Tweener tweener = DOTween.To(() => this.mLastNumber, delegate(int r)
			{
				this._updateNumber(r);
			}, finalnum, this.mTime);
			TweenSettingsExtensions.SetDelay<Tweener>(tweener, this.mDelayTime);
		}

		// Token: 0x04004C89 RID: 19593
		public float mDelayTime;

		// Token: 0x04004C8A RID: 19594
		public float mTime = 0.5f;

		// Token: 0x04004C8B RID: 19595
		public Text mNumber;

		// Token: 0x04004C8C RID: 19596
		private int mLastNumber;
	}
}
