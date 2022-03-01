using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000053 RID: 83
	public class ComScrollNumber : MonoBehaviour
	{
		// Token: 0x060001EB RID: 491 RVA: 0x000105B8 File Offset: 0x0000E9B8
		private void Start()
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x000105BA File Offset: 0x0000E9BA
		public void Trigger(int iEndIndex)
		{
			if (this.m_start)
			{
				return;
			}
			this.m_start = true;
			this.m_endIndex = iEndIndex;
			this.m_position = 0f;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000105E1 File Offset: 0x0000E9E1
		public void Run(int iStart, int iEnd)
		{
			if (this.m_start)
			{
				return;
			}
			this.SetPositionImmediately(iStart);
			this.Trigger(iEnd);
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00010600 File Offset: 0x0000EA00
		public void SetPositionImmediately(int iIndex)
		{
			if (this.m_Indexs.Count < this.m_Imgs.Length)
			{
				this.m_Indexs.Clear();
				for (int i = 0; i < this.m_Imgs.Length; i++)
				{
					this.m_Indexs.Add(i);
				}
			}
			int num = this.m_Indexs.Count;
			while (this.m_Indexs[0] != iIndex && num > 0)
			{
				int item = this.m_Indexs[0];
				this.m_Indexs.RemoveAt(0);
				this.m_Indexs.Add(item);
				num--;
			}
			this.m_position = 0f;
			this._updatePosition();
		}

		// Token: 0x060001EF RID: 495 RVA: 0x000106BC File Offset: 0x0000EABC
		private void _updatePosition()
		{
			for (int i = 0; i < this.m_Indexs.Count; i++)
			{
				this.m_rects[this.m_Indexs[i]].anchoredPosition = new Vector2(this.m_rects[this.m_Indexs[i]].anchoredPosition.x, this.m_position + this.m_positions[i].y);
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x0001073C File Offset: 0x0000EB3C
		private void Update()
		{
			if (this.m_start)
			{
				this.m_position += this.m_fSpeed * Time.deltaTime;
				this._updatePosition();
				while (this.m_Indexs[0] != this.m_endIndex && this.m_position >= this.m_rects[0].sizeDelta.y)
				{
					this.m_position -= this.m_rects[0].sizeDelta.y;
					int item = this.m_Indexs[0];
					this.m_Indexs.RemoveAt(0);
					this.m_Indexs.Add(item);
				}
				if (this.m_Indexs[0] == this.m_endIndex)
				{
					this.m_position = 0f;
					this._updatePosition();
					if (this.onActionEnd != null)
					{
						this.onActionEnd.Invoke();
					}
					this.m_start = false;
				}
			}
			else
			{
				this._updatePosition();
			}
		}

		// Token: 0x040001E2 RID: 482
		public RectTransform[] m_rects = new RectTransform[10];

		// Token: 0x040001E3 RID: 483
		public Image[] m_Imgs = new Image[10];

		// Token: 0x040001E4 RID: 484
		public Vector3[] m_positions = new Vector3[10];

		// Token: 0x040001E5 RID: 485
		public float m_fSpeed = 124f;

		// Token: 0x040001E6 RID: 486
		public UnityEvent onActionEnd;

		// Token: 0x040001E7 RID: 487
		private List<int> m_Indexs = new List<int>();

		// Token: 0x040001E8 RID: 488
		private float m_position;

		// Token: 0x040001E9 RID: 489
		private bool m_start;

		// Token: 0x040001EA RID: 490
		private int m_endIndex = 9;
	}
}
