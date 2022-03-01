using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EED RID: 3821
	public class CommonGameObjectTwinkleControl : MonoBehaviour
	{
		// Token: 0x060095A2 RID: 38306 RVA: 0x001C3F5A File Offset: 0x001C235A
		private void OnDisable()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060095A3 RID: 38307 RVA: 0x001C3F62 File Offset: 0x001C2362
		private void OnDestroy()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060095A4 RID: 38308 RVA: 0x001C3F6A File Offset: 0x001C236A
		public void DoTwinkleAction()
		{
			base.StopAllCoroutines();
			this.isShowFirst = true;
			this.UpdateGameObject(this.isShowFirst);
			base.InvokeRepeating("OnDoTwinkleAction", 0f, this.intervalTime);
		}

		// Token: 0x060095A5 RID: 38309 RVA: 0x001C3F9B File Offset: 0x001C239B
		public void ResetTwinkleAction()
		{
			base.CancelInvoke("OnDoTwinkleAction");
		}

		// Token: 0x060095A6 RID: 38310 RVA: 0x001C3FA8 File Offset: 0x001C23A8
		private void OnDoTwinkleAction()
		{
			if (this.isShowFirst)
			{
				this.isShowFirst = false;
			}
			else
			{
				this.isShowFirst = true;
			}
			this.UpdateGameObject(this.isShowFirst);
		}

		// Token: 0x060095A7 RID: 38311 RVA: 0x001C3FD4 File Offset: 0x001C23D4
		private void UpdateGameObject(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.firstGameObject, flag);
			CommonUtility.UpdateGameObjectVisible(this.secondGameObject, !flag);
		}

		// Token: 0x04004C92 RID: 19602
		private bool isShowFirst;

		// Token: 0x04004C93 RID: 19603
		[SerializeField]
		private float intervalTime = 0.5f;

		// Token: 0x04004C94 RID: 19604
		[SerializeField]
		private GameObject firstGameObject;

		// Token: 0x04004C95 RID: 19605
		[SerializeField]
		private GameObject secondGameObject;
	}
}
