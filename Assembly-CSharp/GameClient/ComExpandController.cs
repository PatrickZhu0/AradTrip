using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001756 RID: 5974
	internal class ComExpandController : MonoBehaviour
	{
		// Token: 0x0600EBD5 RID: 60373 RVA: 0x003EDA94 File Offset: 0x003EBE94
		private void OnDestroy()
		{
			this.ChildrenExpandList = null;
			this.BackImg = null;
			this.ExpandRoot = null;
			this.ParentIcon = null;
			this.ParticalEffect = null;
			this.SecendChildrenExpandList = null;
		}

		// Token: 0x0600EBD6 RID: 60374 RVA: 0x003EDAC0 File Offset: 0x003EBEC0
		private void Start()
		{
			if (!this.CanGoOn())
			{
				return;
			}
			this.bExpanding = false;
			this.UpdateExpand(this.bExpanding);
		}

		// Token: 0x0600EBD7 RID: 60375 RVA: 0x003EDAE4 File Offset: 0x003EBEE4
		private bool IsTwoLine()
		{
			int num = 0;
			for (int i = 0; i < this.SecendChildrenExpandList.Count; i++)
			{
				RectTransform rectTransform = this.SecendChildrenExpandList[i];
				if (rectTransform.gameObject.activeSelf)
				{
					num++;
				}
			}
			return num > 0;
		}

		// Token: 0x0600EBD8 RID: 60376 RVA: 0x003EDB40 File Offset: 0x003EBF40
		public void UpdateExpand(bool bExpand)
		{
			if (!this.CanGoOn())
			{
				return;
			}
			this.bExpanding = bExpand;
			if (this.bExpanding)
			{
				this.ExpandRoot.SetActive(true);
			}
			if (this.IsTwoLine())
			{
				this.PlayeDoTween(this.ChildrenExpandList, this.FirstExpandPos);
				this.PlayeDoTween(this.SecendChildrenExpandList, this.SecendExpandPos);
			}
			else
			{
				this.PlayeDoTween(this.ChildrenExpandList, this.MiddelExpandPos);
			}
			if (this.bExpanding)
			{
				this.ParticalEffect.SetActive(true);
			}
			else
			{
				this.ParticalEffect.SetActive(false);
			}
		}

		// Token: 0x0600EBD9 RID: 60377 RVA: 0x003EDBE8 File Offset: 0x003EBFE8
		private void PlayeDoTween(List<RectTransform> ChildrenExpandList, Vector3 FirstExpandPos)
		{
			int num = 0;
			for (int i = 0; i < ChildrenExpandList.Count; i++)
			{
				RectTransform child = ChildrenExpandList[i];
				if (child.gameObject.activeSelf)
				{
					num++;
					Vector3 vector = default(Vector3);
					if (this.bExpanding)
					{
						vector.x = FirstExpandPos.x - this.PosSpacing * (float)(num - 1);
					}
					else
					{
						vector.x = 0f;
					}
					vector.y = FirstExpandPos.y;
					float num2 = this.FirstDotweenDuraton + this.DurationSpacing * (float)(num - 1);
					Tweener tweener = DOTween.To(() => child.localPosition, delegate(Vector3 r)
					{
						child.localPosition = r;
					}, vector, num2);
					TweenSettingsExtensions.SetEase<Tweener>(tweener, 1);
					TweenSettingsExtensions.OnComplete<Tweener>(tweener, new TweenCallback(this._OnDotweenComplete));
				}
			}
		}

		// Token: 0x0600EBDA RID: 60378 RVA: 0x003EDCE5 File Offset: 0x003EC0E5
		private void _OnDotweenComplete()
		{
			if (!this.bExpanding)
			{
				this.ExpandRoot.SetActive(false);
			}
		}

		// Token: 0x0600EBDB RID: 60379 RVA: 0x003EDD00 File Offset: 0x003EC100
		private bool CanGoOn()
		{
			return this.ChildrenExpandList != null && !(this.BackImg == null) && !(this.ExpandRoot == null) && !(this.ParentIcon == null) && !(this.ParticalEffect == null) && !(this.NormalStateIconPath == string.Empty) && !(this.ExpandStateIconPath == string.Empty);
		}

		// Token: 0x0600EBDC RID: 60380 RVA: 0x003EDD89 File Offset: 0x003EC189
		private void Update()
		{
		}

		// Token: 0x04008F0C RID: 36620
		public List<RectTransform> ChildrenExpandList;

		// Token: 0x04008F0D RID: 36621
		public List<RectTransform> SecendChildrenExpandList;

		// Token: 0x04008F0E RID: 36622
		public Vector3 FirstExpandPos;

		// Token: 0x04008F0F RID: 36623
		public Vector3 SecendExpandPos;

		// Token: 0x04008F10 RID: 36624
		public Vector3 MiddelExpandPos;

		// Token: 0x04008F11 RID: 36625
		public float PosSpacing;

		// Token: 0x04008F12 RID: 36626
		public float FirstDotweenDuraton;

		// Token: 0x04008F13 RID: 36627
		public float DurationSpacing;

		// Token: 0x04008F14 RID: 36628
		public RectTransform BackImg;

		// Token: 0x04008F15 RID: 36629
		public GameObject ExpandRoot;

		// Token: 0x04008F16 RID: 36630
		public Image ParentIcon;

		// Token: 0x04008F17 RID: 36631
		public GameObject ParticalEffect;

		// Token: 0x04008F18 RID: 36632
		public string NormalStateIconPath = string.Empty;

		// Token: 0x04008F19 RID: 36633
		public string ExpandStateIconPath = string.Empty;

		// Token: 0x04008F1A RID: 36634
		public bool bExpanding;
	}
}
