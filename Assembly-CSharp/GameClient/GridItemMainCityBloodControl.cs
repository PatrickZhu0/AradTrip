using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C69 RID: 7273
	public class GridItemMainCityBloodControl : MonoBehaviour
	{
		// Token: 0x06011DE0 RID: 73184 RVA: 0x0053AEA0 File Offset: 0x005392A0
		private void OnDestroy()
		{
			this._leftBloodNumber = 0U;
			this._totalBloodNumber = 0;
		}

		// Token: 0x06011DE1 RID: 73185 RVA: 0x0053AEB0 File Offset: 0x005392B0
		public void InitTotalBloodNumber(int totalBloodNumber)
		{
			if (this.bloodTemplate == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.bloodTemplate, false);
			if (this.bloodParentRoot == null)
			{
				return;
			}
			this._bloodIntervalWith = this.bloodInterval + this.bloodItemWidth;
			this._totalBloodNumber = totalBloodNumber;
			if (this._totalBloodNumber <= 0)
			{
				this._totalBloodNumber = 4;
			}
			float num = this.bloodEdge * 2f + (float)totalBloodNumber * this.bloodItemWidth + (float)(this._totalBloodNumber - 1) * this.bloodInterval;
			RectTransform rectTransform = this.bloodParentRoot.transform as RectTransform;
			if (rectTransform != null)
			{
				rectTransform.sizeDelta = new Vector2(num, rectTransform.sizeDelta.y);
			}
			if (this.bloodList == null)
			{
				this.bloodList = new List<GameObject>();
			}
			this.bloodList.Clear();
			float num3;
			if (totalBloodNumber % 2 == 0)
			{
				int num2 = totalBloodNumber / 2;
				num3 = -(this._bloodIntervalWith / 2f + (float)(num2 - 1) * this._bloodIntervalWith);
			}
			else
			{
				int num4 = totalBloodNumber / 2;
				num3 = -((float)num4 * this._bloodIntervalWith);
			}
			for (int i = 0; i < totalBloodNumber; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.bloodTemplate);
				if (gameObject != null)
				{
					CommonUtility.UpdateGameObjectVisible(gameObject, true);
					gameObject.transform.SetParent(this.bloodParentRoot.transform, false);
					gameObject.transform.name = gameObject.transform.name + "_" + (i + 1);
					Vector3 localPosition = gameObject.transform.localPosition;
					float num5 = num3 + (float)i * this._bloodIntervalWith;
					gameObject.transform.localPosition = new Vector3(num5, localPosition.y, localPosition.z);
					this.bloodList.Add(gameObject);
				}
			}
		}

		// Token: 0x06011DE2 RID: 73186 RVA: 0x0053B0A4 File Offset: 0x005394A4
		public void UpdateBloodControl(uint leftBloodNumber)
		{
			this._leftBloodNumber = leftBloodNumber;
			int count = this.bloodList.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = this.bloodList[i];
				if (!(gameObject == null))
				{
					if ((long)i < (long)((ulong)this._leftBloodNumber))
					{
						CommonUtility.UpdateGameObjectVisible(gameObject, true);
					}
					else
					{
						CommonUtility.UpdateGameObjectVisible(gameObject, false);
					}
				}
			}
		}

		// Token: 0x0400BA28 RID: 47656
		[Space(15f)]
		[Header("Data")]
		[Space(10f)]
		[SerializeField]
		private float bloodEdge = 3f;

		// Token: 0x0400BA29 RID: 47657
		[SerializeField]
		private float bloodInterval = 1f;

		// Token: 0x0400BA2A RID: 47658
		[SerializeField]
		private float bloodItemWidth = 20f;

		// Token: 0x0400BA2B RID: 47659
		[Space(15f)]
		[Header("Blood")]
		[Space(10f)]
		[SerializeField]
		private GameObject bloodTemplate;

		// Token: 0x0400BA2C RID: 47660
		[SerializeField]
		private GameObject bloodParentRoot;

		// Token: 0x0400BA2D RID: 47661
		[SerializeField]
		private List<GameObject> bloodList = new List<GameObject>();

		// Token: 0x0400BA2E RID: 47662
		private int _totalBloodNumber;

		// Token: 0x0400BA2F RID: 47663
		private uint _leftBloodNumber;

		// Token: 0x0400BA30 RID: 47664
		private float _bloodIntervalWith;
	}
}
