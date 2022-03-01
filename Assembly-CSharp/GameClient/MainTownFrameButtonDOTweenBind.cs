using System;
using DG.Tweening;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001762 RID: 5986
	public class MainTownFrameButtonDOTweenBind : MonoBehaviour
	{
		// Token: 0x0600EC3A RID: 60474 RVA: 0x003F0585 File Offset: 0x003EE985
		private void Awake()
		{
			if (this.parentDOTweenAnim != null && this.doTweeningDelayTime < this.parentDOTweenAnim.duration)
			{
				this.doTweeningDelayTime = this.parentDOTweenAnim.duration;
			}
		}

		// Token: 0x04008F91 RID: 36753
		[Header("主界面 - 按钮 - 当按钮在动画状态下 - 需要等待动画播完的时间")]
		public float doTweeningDelayTime;

		// Token: 0x04008F92 RID: 36754
		[Space(10f)]
		[Header("按钮父节点绑定的DOTweenAnim")]
		[SerializeField]
		private DOTweenAnimation parentDOTweenAnim;
	}
}
