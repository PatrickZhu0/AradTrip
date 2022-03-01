using System;
using System.Collections;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EEE RID: 3822
	public class CommonGameObjectVisibleControl : MonoBehaviour
	{
		// Token: 0x060095A9 RID: 38313 RVA: 0x001C4004 File Offset: 0x001C2404
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060095AA RID: 38314 RVA: 0x001C400C File Offset: 0x001C240C
		private void OnDestroy()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060095AB RID: 38315 RVA: 0x001C4014 File Offset: 0x001C2414
		public void SetVisibleTime(float showTime)
		{
			this.visibleTime = showTime;
		}

		// Token: 0x060095AC RID: 38316 RVA: 0x001C401D File Offset: 0x001C241D
		public void SetVisibleControl()
		{
			if (this.visibleTime <= 0f)
			{
				return;
			}
			base.StopAllCoroutines();
			this._intervalTime = this.visibleTime;
			base.StartCoroutine(this.StartCountDown());
		}

		// Token: 0x060095AD RID: 38317 RVA: 0x001C4050 File Offset: 0x001C2450
		private IEnumerator StartCountDown()
		{
			while (this._intervalTime > 0f)
			{
				this._intervalTime -= 0.5f;
				yield return new WaitForSeconds(0.5f);
			}
			this._intervalTime = 0f;
			base.transform.gameObject.CustomActive(false);
			yield break;
		}

		// Token: 0x04004C96 RID: 19606
		private float _intervalTime;

		// Token: 0x04004C97 RID: 19607
		[SerializeField]
		private float visibleTime = 2f;
	}
}
