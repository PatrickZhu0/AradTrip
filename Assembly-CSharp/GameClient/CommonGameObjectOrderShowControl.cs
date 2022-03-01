using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EEC RID: 3820
	public class CommonGameObjectOrderShowControl : MonoBehaviour
	{
		// Token: 0x0600959B RID: 38299 RVA: 0x001C3DED File Offset: 0x001C21ED
		private void OnDestroy()
		{
			this._orderShowFinishAction = null;
			base.StopAllCoroutines();
		}

		// Token: 0x0600959C RID: 38300 RVA: 0x001C3DFC File Offset: 0x001C21FC
		public void Init(Action orderShowFinishAction)
		{
			base.StopAllCoroutines();
			if (this.goList == null)
			{
				return;
			}
			int count = this.goList.Count;
			if (count <= 0)
			{
				return;
			}
			if (this.totalShowTime <= 0f)
			{
				return;
			}
			this._intervalTime = this.totalShowTime / (float)count;
			this._orderShowFinishAction = orderShowFinishAction;
			this._orderIndex = 0;
			this.ResetGameObject();
			this.DoGameObjectOrderShow();
		}

		// Token: 0x0600959D RID: 38301 RVA: 0x001C3E69 File Offset: 0x001C2269
		private void DoGameObjectOrderShow()
		{
			base.InvokeRepeating("OnDoGameObjectOrderShow", 0f, this._intervalTime);
		}

		// Token: 0x0600959E RID: 38302 RVA: 0x001C3E84 File Offset: 0x001C2284
		public void OnDoGameObjectOrderShow()
		{
			if (this._orderIndex < this.goList.Count)
			{
				CommonUtility.UpdateGameObjectVisible(this.goList[this._orderIndex], true);
			}
			this._orderIndex++;
			if (this._orderIndex >= this.goList.Count)
			{
				this.FinishGameObjectOrderShow();
				if (this._orderShowFinishAction != null)
				{
					this._orderShowFinishAction();
				}
			}
		}

		// Token: 0x0600959F RID: 38303 RVA: 0x001C3EFE File Offset: 0x001C22FE
		public void FinishGameObjectOrderShow()
		{
			base.CancelInvoke("OnDoGameObjectOrderShow");
		}

		// Token: 0x060095A0 RID: 38304 RVA: 0x001C3F0C File Offset: 0x001C230C
		private void ResetGameObject()
		{
			for (int i = 0; i < this.goList.Count; i++)
			{
				CommonUtility.UpdateGameObjectVisible(this.goList[i], false);
			}
		}

		// Token: 0x04004C8D RID: 19597
		private float _intervalTime = 0.3f;

		// Token: 0x04004C8E RID: 19598
		private int _orderIndex;

		// Token: 0x04004C8F RID: 19599
		private Action _orderShowFinishAction;

		// Token: 0x04004C90 RID: 19600
		[SerializeField]
		private float totalShowTime = 1f;

		// Token: 0x04004C91 RID: 19601
		[SerializeField]
		private List<GameObject> goList = new List<GameObject>();
	}
}
