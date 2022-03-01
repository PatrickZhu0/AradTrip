using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B26 RID: 6950
	internal class ComScreenShake : MonoBehaviour
	{
		// Token: 0x06011127 RID: 69927 RVA: 0x004E4D6A File Offset: 0x004E316A
		public void Shake()
		{
			this.isshakeCamera = true;
			this.shakeTime = this.len;
		}

		// Token: 0x06011128 RID: 69928 RVA: 0x004E4D80 File Offset: 0x004E3180
		private void Start()
		{
			if (this.cam == null)
			{
				GameObject gameObject = GameObject.Find("UIRoot/UICamera");
				if (null != gameObject)
				{
					this.cam = gameObject.GetComponent<Camera>();
				}
			}
		}

		// Token: 0x06011129 RID: 69929 RVA: 0x004E4DC4 File Offset: 0x004E31C4
		private void Update()
		{
			if (Input.GetKeyDown(107))
			{
				this.isshakeCamera = !this.isshakeCamera;
			}
			if (this.isshakeCamera && null != this.cam && this.shakeTime > 0f)
			{
				this.shakeTime -= Time.deltaTime;
				if (this.shakeTime <= 0f)
				{
					this.cam.rect = new Rect(0f, 0f, 1f, 1f);
					this.isshakeCamera = false;
					this.shakeTime = this.len;
					this.frameTime = 0.03f;
				}
				else
				{
					this.frameTime += Time.deltaTime;
					if ((double)this.frameTime > 1.0 / (double)this.fps)
					{
						this.frameTime = 0f;
						float num = 1f + this.shakeDelta * Random.value;
						this.cam.rect = new Rect(0f, 0f, num, num);
					}
				}
			}
		}

		// Token: 0x0400AFE4 RID: 45028
		public float len = 1f;

		// Token: 0x0400AFE5 RID: 45029
		private float shakeTime = 1f;

		// Token: 0x0400AFE6 RID: 45030
		public float fps = 20f;

		// Token: 0x0400AFE7 RID: 45031
		public float frameTime;

		// Token: 0x0400AFE8 RID: 45032
		public float shakeDelta = 0.005f;

		// Token: 0x0400AFE9 RID: 45033
		public Camera cam;

		// Token: 0x0400AFEA RID: 45034
		public bool isshakeCamera;
	}
}
