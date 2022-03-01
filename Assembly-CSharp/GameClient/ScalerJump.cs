using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000099 RID: 153
	public class ScalerJump : MonoBehaviour
	{
		// Token: 0x0600032F RID: 815 RVA: 0x00018A38 File Offset: 0x00016E38
		public void StartJumpNormal(int jumpIndex)
		{
			if (this.bStart)
			{
				return;
			}
			this.bStart = true;
			this.bContinue = false;
			this.timeBeg = Time.time;
			base.transform.localScale = Vector3.one;
			this.iStarIndex = 0;
			this.jumpIndex = jumpIndex;
			this.jumpLength = 1;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00018A90 File Offset: 0x00016E90
		public void StartJumpContinue(int jumpIndex, int jumpLength)
		{
			if (this.bStart)
			{
				return;
			}
			this.bStart = true;
			this.bContinue = true;
			this.timeBeg = Time.time;
			base.transform.localScale = Vector3.one;
			this.iStarIndex = 0;
			this.jumpIndex = jumpIndex;
			this.jumpLength = jumpLength;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00018AE7 File Offset: 0x00016EE7
		private void Start()
		{
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00018AEC File Offset: 0x00016EEC
		private void Update()
		{
			if (!this.bStart)
			{
				return;
			}
			ContinueJump continueJump = null;
			if (!this.bContinue)
			{
				continueJump = this.normalJump;
			}
			else if (this.iStarIndex >= 0 && this.iStarIndex < this.continueJump.Length && this.iStarIndex < this.jumpLength)
			{
				continueJump = this.continueJump[this.iStarIndex];
			}
			if (continueJump == null || Time.time >= this.timeBeg + continueJump.length)
			{
				if (continueJump != null && this.bContinue)
				{
					this.timeBeg = Time.time;
					this.iStarIndex++;
				}
				else
				{
					base.transform.localScale = Vector3.one;
					this.bStart = false;
				}
				if (this.onJumpEnd != null && continueJump != null)
				{
					if (this.bContinue)
					{
						this.onJumpEnd(this.jumpIndex + this.iStarIndex);
					}
					else
					{
						this.onJumpEnd(this.jumpIndex);
					}
				}
			}
			else
			{
				float num = (Time.time - this.timeBeg) / continueJump.length;
				num = Mathf.Clamp01(num);
				base.transform.localScale = continueJump.curve.Evaluate(num) * continueJump.fMax * Vector3.one;
			}
		}

		// Token: 0x04000325 RID: 805
		public ContinueJump normalJump = new ContinueJump();

		// Token: 0x04000326 RID: 806
		public ContinueJump[] continueJump = new ContinueJump[0];

		// Token: 0x04000327 RID: 807
		public ScalerJump.OnJumpEnd onJumpEnd;

		// Token: 0x04000328 RID: 808
		private bool bStart;

		// Token: 0x04000329 RID: 809
		private bool bContinue;

		// Token: 0x0400032A RID: 810
		private float timeBeg;

		// Token: 0x0400032B RID: 811
		private int iStarIndex;

		// Token: 0x0400032C RID: 812
		private int jumpIndex;

		// Token: 0x0400032D RID: 813
		private int jumpLength = 1;

		// Token: 0x0200009A RID: 154
		// (Invoke) Token: 0x06000334 RID: 820
		public delegate void OnJumpEnd(int iIndex);
	}
}
