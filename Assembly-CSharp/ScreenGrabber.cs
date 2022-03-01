using System;
using UnityEngine;

// Token: 0x02000D87 RID: 3463
public class ScreenGrabber : MonoBehaviour
{
	// Token: 0x06008C56 RID: 35926 RVA: 0x0019FE70 File Offset: 0x0019E270
	private void Start()
	{
	}

	// Token: 0x06008C57 RID: 35927 RVA: 0x0019FE72 File Offset: 0x0019E272
	private void Update()
	{
	}

	// Token: 0x06008C58 RID: 35928 RVA: 0x0019FE74 File Offset: 0x0019E274
	private void OnEnable()
	{
	}

	// Token: 0x06008C59 RID: 35929 RVA: 0x0019FE76 File Offset: 0x0019E276
	private void OnDisable()
	{
		if (null != this.m_GrabScreen)
		{
			Object.Destroy(this.m_GrabScreen);
			this.m_GrabScreen = null;
		}
	}

	// Token: 0x06008C5A RID: 35930 RVA: 0x0019FE9B File Offset: 0x0019E29B
	public void Grab(OnGrabScreenFinish cb)
	{
		this.m_Grab = true;
		this.m_GrabCallback = cb;
	}

	// Token: 0x06008C5B RID: 35931 RVA: 0x0019FEAB File Offset: 0x0019E2AB
	private void OnDestroy()
	{
		if (null != this.m_GrabScreen)
		{
			Object.Destroy(this.m_GrabScreen);
			this.m_GrabScreen = null;
		}
		this.m_GrabCallback = null;
	}

	// Token: 0x06008C5C RID: 35932 RVA: 0x0019FED8 File Offset: 0x0019E2D8
	private void _GrabBackBuffer(RenderTexture src)
	{
		if (null != src)
		{
			if (null != this.m_GrabScreen && (this.m_GrabScreen.width != src.width || this.m_GrabScreen.height != src.width))
			{
				Object.Destroy(this.m_GrabScreen);
				this.m_GrabScreen = null;
			}
			if (null == this.m_GrabScreen)
			{
				this.m_GrabScreen = new RenderTexture(src.width, src.width, 0, src.format);
			}
			if (null != this.m_GrabScreen)
			{
				Graphics.Blit(src, this.m_GrabScreen);
			}
		}
	}

	// Token: 0x06008C5D RID: 35933 RVA: 0x0019FF8C File Offset: 0x0019E38C
	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit(src, dst);
		if (this.m_Grab)
		{
			this._GrabBackBuffer(src);
			this.m_Grab = false;
			this.m_GrabCallback(this.m_GrabScreen);
		}
	}

	// Token: 0x0400456A RID: 17770
	public RenderTexture m_GrabScreen;

	// Token: 0x0400456B RID: 17771
	private bool m_Grab;

	// Token: 0x0400456C RID: 17772
	private OnGrabScreenFinish m_GrabCallback;
}
