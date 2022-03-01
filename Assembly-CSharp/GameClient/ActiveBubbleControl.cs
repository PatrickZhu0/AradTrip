using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200192B RID: 6443
	public class ActiveBubbleControl : MonoBehaviour
	{
		// Token: 0x0600FAA3 RID: 64163 RVA: 0x0044A720 File Offset: 0x00448B20
		private void Start()
		{
			this.anim1 = this.tipsRoot.GetComponents<DOTweenAnimation>();
			this.anim2 = this.tipDesc.GetComponents<DOTweenAnimation>();
		}

		// Token: 0x0600FAA4 RID: 64164 RVA: 0x0044A744 File Offset: 0x00448B44
		public GameObject TipsRoot()
		{
			return this.tipsRoot;
		}

		// Token: 0x0600FAA5 RID: 64165 RVA: 0x0044A74C File Offset: 0x00448B4C
		private void OnDestroy()
		{
			this.StopAnimCoroutine();
		}

		// Token: 0x0600FAA6 RID: 64166 RVA: 0x0044A754 File Offset: 0x00448B54
		public void SetUp(string tip)
		{
			if (this.tipDesc != null)
			{
				this.tipDesc.text = tip;
			}
			this.StopAnimCoroutine();
			this.coroutine = base.StartCoroutine(this.PlayAnim());
		}

		// Token: 0x0600FAA7 RID: 64167 RVA: 0x0044A78B File Offset: 0x00448B8B
		private void StopAnimCoroutine()
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
				this.coroutine = null;
			}
		}

		// Token: 0x0600FAA8 RID: 64168 RVA: 0x0044A7AC File Offset: 0x00448BAC
		private IEnumerator PlayAnim()
		{
			if (this.anim1 != null && this.anim2 != null && this.anim1.Length == this.anim2.Length)
			{
				for (int i = 0; i < this.anim1.Length; i++)
				{
					this.anim1[i].DORestart(false);
					this.anim2[i].DORestart(false);
				}
			}
			this.tipsRoot.CustomActive(true);
			yield return Yielders.GetWaitForSeconds(this.time);
			this.tipsRoot.CustomActive(false);
			yield break;
		}

		// Token: 0x04009C98 RID: 40088
		[SerializeField]
		private GameObject tipsRoot;

		// Token: 0x04009C99 RID: 40089
		[SerializeField]
		private Text tipDesc;

		// Token: 0x04009C9A RID: 40090
		[Header("持续多长时间关闭tips")]
		[SerializeField]
		private float time = 3f;

		// Token: 0x04009C9B RID: 40091
		private DOTweenAnimation[] anim1;

		// Token: 0x04009C9C RID: 40092
		private DOTweenAnimation[] anim2;

		// Token: 0x04009C9D RID: 40093
		private Coroutine coroutine;
	}
}
