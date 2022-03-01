using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EAF RID: 3759
	internal class ComDoTweenHeight : MonoBehaviour
	{
		// Token: 0x0600945F RID: 37983 RVA: 0x001BD008 File Offset: 0x001BB408
		private void Start()
		{
			this.m_rect = base.gameObject.GetComponent<RectTransform>();
			this.m_startHeight = this.m_rect.sizeDelta.y;
			if (this.Arrow != null)
			{
				this.m_imageRect = this.Arrow.GetComponent<RectTransform>();
				this.m_startRot = this.m_imageRect.localEulerAngles.z;
			}
		}

		// Token: 0x06009460 RID: 37984 RVA: 0x001BD07C File Offset: 0x001BB47C
		public void Expand()
		{
			Tweener tweener = DOTween.To(() => this.m_rect.sizeDelta.y, delegate(float data)
			{
				this.m_rect.sizeDelta = new Vector2(this.m_rect.sizeDelta.x, data);
			}, this.TargetHeight, this.ExpandTime);
			TweenSettingsExtensions.SetEase<Tweener>(tweener, this.ExpandCurve);
			if (this.m_imageRect != null)
			{
				ShortcutExtensions.DORotate(this.m_imageRect, new Vector3(0f, 0f, this.TargetRot), this.ExpandTime, 0);
			}
		}

		// Token: 0x06009461 RID: 37985 RVA: 0x001BD0FC File Offset: 0x001BB4FC
		public void Collapse()
		{
			Tweener tweener = DOTween.To(() => this.m_rect.sizeDelta.y, delegate(float data)
			{
				this.m_rect.sizeDelta = new Vector2(this.m_rect.sizeDelta.x, data);
			}, this.m_startHeight, this.CollapseTime);
			TweenSettingsExtensions.SetEase<Tweener>(tweener, this.CollapseCurve);
			if (this.m_imageRect != null)
			{
				ShortcutExtensions.DORotate(this.m_imageRect, new Vector3(0f, 0f, this.m_startRot), this.CollapseTime, 0);
			}
		}

		// Token: 0x04004B22 RID: 19234
		private RectTransform m_rect;

		// Token: 0x04004B23 RID: 19235
		private float m_startHeight;

		// Token: 0x04004B24 RID: 19236
		private RectTransform m_imageRect;

		// Token: 0x04004B25 RID: 19237
		private float m_startRot;

		// Token: 0x04004B26 RID: 19238
		public float TargetHeight = 100f;

		// Token: 0x04004B27 RID: 19239
		public AnimationCurve ExpandCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04004B28 RID: 19240
		public float ExpandTime = 0.3f;

		// Token: 0x04004B29 RID: 19241
		public AnimationCurve CollapseCurve = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(1f, 1f),
			new Keyframe(0f, 0f)
		});

		// Token: 0x04004B2A RID: 19242
		public float CollapseTime = 0.3f;

		// Token: 0x04004B2B RID: 19243
		public Image Arrow;

		// Token: 0x04004B2C RID: 19244
		public float TargetRot;
	}
}
