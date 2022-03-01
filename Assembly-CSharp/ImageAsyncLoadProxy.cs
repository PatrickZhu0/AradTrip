using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000F0 RID: 240
public class ImageAsyncLoadProxy : MonoBehaviour
{
	// Token: 0x060004FB RID: 1275 RVA: 0x00021D8C File Offset: 0x0002018C
	public void LoadResAsync(string res, PostLoadProcess postProcess = null)
	{
		if (this.m_Handle != 4294967295U)
		{
			Singleton<AssetLoader>.instance.AbortRequest(this.m_Handle);
		}
		if (null == this.m_Image)
		{
			this.m_Image = base.gameObject.GetComponent<Image>();
		}
		if (null != this.m_Image)
		{
			if (!base.enabled)
			{
				base.enabled = true;
			}
			this.m_Handle = Singleton<AssetLoader>.instance.LoadResAync(res, typeof(Sprite), true, 0U, 0U);
			this.m_PostProcess = postProcess;
		}
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00021E20 File Offset: 0x00020220
	private void Update()
	{
		if (this.m_Handle != 4294967295U)
		{
			if (this.m_CheckTick < 3U)
			{
				this.m_CheckTick += 1U;
				return;
			}
			this.m_CheckTick = 0U;
			if (Singleton<AssetLoader>.instance.IsRequestDone(this.m_Handle))
			{
				Sprite sprite = Singleton<AssetLoader>.instance.Extract(this.m_Handle).obj as Sprite;
				if (null != this.m_Image)
				{
					this.m_Image.sprite = sprite;
					if (this.m_PostProcess != null)
					{
						this.m_PostProcess(this.m_Image);
					}
				}
				this.m_PostProcess = null;
				this.m_Handle = uint.MaxValue;
			}
		}
		else
		{
			base.enabled = false;
		}
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x00021EDE File Offset: 0x000202DE
	private void OnDestroy()
	{
		if (this.m_Handle != 4294967295U)
		{
			Singleton<AssetLoader>.instance.AbortRequest(this.m_Handle);
			this.m_Handle = uint.MaxValue;
			this.m_PostProcess = null;
		}
		this.m_Image = null;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x00021F14 File Offset: 0x00020314
	public static void AddAsyncLoadResWithGameObject(GameObject go, string res, PostLoadProcess postProcess = null)
	{
		if (null != go)
		{
			ImageAsyncLoadProxy imageAsyncLoadProxy = go.GetComponent<ImageAsyncLoadProxy>();
			if (null == imageAsyncLoadProxy)
			{
				imageAsyncLoadProxy = go.AddComponent<ImageAsyncLoadProxy>();
			}
			if (null != imageAsyncLoadProxy)
			{
				if (null == imageAsyncLoadProxy.m_Image)
				{
					imageAsyncLoadProxy.m_Image = go.GetComponent<Image>();
				}
				imageAsyncLoadProxy.LoadResAsync(res, postProcess);
			}
		}
	}

	// Token: 0x04000481 RID: 1153
	private uint m_Handle = uint.MaxValue;

	// Token: 0x04000482 RID: 1154
	public Image m_Image;

	// Token: 0x04000483 RID: 1155
	private uint m_CheckTick;

	// Token: 0x04000484 RID: 1156
	private PostLoadProcess m_PostProcess;
}
