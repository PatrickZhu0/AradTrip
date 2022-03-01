using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E6E RID: 3694
	internal class ComBlueCircle : MonoBehaviour
	{
		// Token: 0x170018F7 RID: 6391
		// (get) Token: 0x0600928D RID: 37517 RVA: 0x001B38E8 File Offset: 0x001B1CE8
		public bool IsShrink
		{
			get
			{
				return this.startShrink;
			}
		}

		// Token: 0x170018F8 RID: 6392
		// (get) Token: 0x0600928E RID: 37518 RVA: 0x001B38F0 File Offset: 0x001B1CF0
		public ComMapScene scene
		{
			get
			{
				return this.m_scene;
			}
		}

		// Token: 0x0600928F RID: 37519 RVA: 0x001B38F8 File Offset: 0x001B1CF8
		public void ResetSource(float sourceRadius, Vector2 srcPos)
		{
			this.m_SrcCenter = srcPos;
			this.m_SrcRadius = sourceRadius;
			this.m_CurCenter = this.m_SrcCenter;
			this.m_CurRadius = this.m_SrcRadius;
		}

		// Token: 0x06009290 RID: 37520 RVA: 0x001B3920 File Offset: 0x001B1D20
		private void Start()
		{
			this.m_Image = base.GetComponent<Image>();
			this.imageTrans = this.m_Image.GetComponent<RectTransform>();
		}

		// Token: 0x06009291 RID: 37521 RVA: 0x001B3940 File Offset: 0x001B1D40
		public void Setup(Vector2 pos, float radius, float elapseTime, float durTime, ComMapScene a_comScene)
		{
			this.m_scene = a_comScene;
			if (durTime != 0f)
			{
				this.m_TargetCenter = pos;
				this.m_SrcCenter = this.m_CurCenter;
				this.m_SrcRadius = this.m_CurRadius;
				this.m_TgtRadius = radius;
				this.startShrink = true;
			}
			else
			{
				this.m_SrcCenter = pos;
				this.m_CurCenter = pos;
				this.m_TargetCenter = pos;
				this.m_CurRadius = radius;
				this.m_TgtRadius = radius;
				this.m_SrcRadius = radius;
			}
			this.m_shrinkTime = durTime;
			this.m_durTime = elapseTime;
			base.gameObject.SetActive(true);
			base.gameObject.transform.SetParent(this.m_scene.gameObject.transform, false);
			this.Set();
			if (!this.startShrink)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PoisonNextStage, null, null, null, null);
			}
		}

		// Token: 0x06009292 RID: 37522 RVA: 0x001B3A20 File Offset: 0x001B1E20
		private void Set()
		{
			if (this.imageTrans == null)
			{
				this.m_Image = base.GetComponent<Image>();
				this.imageTrans = this.m_Image.GetComponent<RectTransform>();
			}
			this.imageTrans.anchoredPosition = new Vector2(this.m_CurCenter.x * this.m_scene.XRate, this.m_CurCenter.y * this.m_scene.ZRate);
			this.imageTrans.sizeDelta = new Vector2(this.m_CurRadius * 12.8f, this.m_CurRadius * 10f);
		}

		// Token: 0x06009293 RID: 37523 RVA: 0x001B3AC4 File Offset: 0x001B1EC4
		private void Update()
		{
			if (this.startShrink)
			{
				if (this.m_durTime < this.m_shrinkTime)
				{
					float num = this.m_durTime / this.m_shrinkTime;
					this.m_CurCenter = Vector2.Lerp(this.m_SrcCenter, this.m_TargetCenter, num);
					this.m_CurRadius = Mathf.Lerp(this.m_SrcRadius, this.m_TgtRadius, num);
					this.m_durTime += Time.deltaTime;
				}
				else
				{
					this.startShrink = false;
					this.m_CurCenter = this.m_TargetCenter;
					this.m_CurRadius = this.m_TgtRadius;
					this.m_SrcCenter = this.m_CurCenter;
					this.m_SrcRadius = this.m_CurRadius;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PoisonNextStage, null, null, null, null);
				}
				this.Set();
			}
		}

		// Token: 0x040049BF RID: 18879
		private ComMapScene m_scene;

		// Token: 0x040049C0 RID: 18880
		private Vector2 m_TargetCenter = Vector2.zero;

		// Token: 0x040049C1 RID: 18881
		private Vector2 m_SrcCenter = Vector2.zero;

		// Token: 0x040049C2 RID: 18882
		private Vector2 m_CurCenter = Vector2.zero;

		// Token: 0x040049C3 RID: 18883
		private float m_SrcRadius;

		// Token: 0x040049C4 RID: 18884
		private float m_TgtRadius;

		// Token: 0x040049C5 RID: 18885
		private float m_CurRadius;

		// Token: 0x040049C6 RID: 18886
		private float m_durTime;

		// Token: 0x040049C7 RID: 18887
		private float m_shrinkTime;

		// Token: 0x040049C8 RID: 18888
		private Image m_Image;

		// Token: 0x040049C9 RID: 18889
		private bool startShrink;

		// Token: 0x040049CA RID: 18890
		private RectTransform imageTrans;
	}
}
