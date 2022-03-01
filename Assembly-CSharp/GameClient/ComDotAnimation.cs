using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000024 RID: 36
	public class ComDotAnimation : MonoBehaviour
	{
		// Token: 0x060000DD RID: 221 RVA: 0x00009AF7 File Offset: 0x00007EF7
		private void Start()
		{
			this.Play();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00009B00 File Offset: 0x00007F00
		public void Play()
		{
			this.iIndex = 0;
			this.frameTotal = 0;
			this.MaxFrame = IntMath.Max(this.MaxFrame, 1);
			this.curFrequency = 0;
			this.frameInterval = this._GetFrameInterval();
			this.bStart = true;
			this.goCurrent.CustomActive(false);
			this.goCurrent = null;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x00009B5C File Offset: 0x00007F5C
		private int _GetFrameInterval()
		{
			float num = this.curve.Evaluate((float)this.curFrequency * 1f / (float)this.frequencySession);
			this.frameInterval = Mathf.FloorToInt(num * (float)this.MaxFrame);
			this.frameInterval = IntMath.Max(this.frameInterval, 1);
			return this.frameInterval;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00009BB8 File Offset: 0x00007FB8
		private void Update()
		{
			if (!this.bStart)
			{
				return;
			}
			if (this.frameTotal == 0)
			{
				this._PlayNext();
				this.curFrequency++;
				this.frameInterval = this._GetFrameInterval();
				if (this.curFrequency >= this.frequencySession)
				{
					this.bStart = false;
				}
			}
			this.frameTotal = (this.frameTotal + 1) % this.frameInterval;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00009C2C File Offset: 0x0000802C
		private void _PlayNext()
		{
			if (this.children == null)
			{
				return;
			}
			this.goCurrent.CustomActive(false);
			this.goCurrent = this.children[this.iIndex];
			this.goCurrent.CustomActive(true);
			this.iIndex = (1 + this.iIndex) % this.children.Count;
		}

		// Token: 0x040000B9 RID: 185
		public AnimationCurve curve;

		// Token: 0x040000BA RID: 186
		public int frequencySession;

		// Token: 0x040000BB RID: 187
		public int MaxFrame;

		// Token: 0x040000BC RID: 188
		private int frameInterval = 1;

		// Token: 0x040000BD RID: 189
		private int iIndex;

		// Token: 0x040000BE RID: 190
		private int frameTotal;

		// Token: 0x040000BF RID: 191
		private int curFrequency;

		// Token: 0x040000C0 RID: 192
		public List<GameObject> children;

		// Token: 0x040000C1 RID: 193
		private GameObject goCurrent;

		// Token: 0x040000C2 RID: 194
		private bool bStart;
	}
}
