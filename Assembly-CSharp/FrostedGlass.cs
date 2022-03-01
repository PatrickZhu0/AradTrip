using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000D84 RID: 3460
public class FrostedGlass : MonoBehaviour
{
	// Token: 0x06008C46 RID: 35910 RVA: 0x0019FAB5 File Offset: 0x0019DEB5
	private void Start()
	{
	}

	// Token: 0x06008C47 RID: 35911 RVA: 0x0019FAB7 File Offset: 0x0019DEB7
	private void Update()
	{
	}

	// Token: 0x06008C48 RID: 35912 RVA: 0x0019FAB9 File Offset: 0x0019DEB9
	private void OnEnable()
	{
	}

	// Token: 0x06008C49 RID: 35913 RVA: 0x0019FABC File Offset: 0x0019DEBC
	private void _OnGrabScreenFinish(RenderTexture rt)
	{
		if (null != this.m_RawImage)
		{
			if (null != this.m_Grabber)
			{
				this.m_Grabber.enabled = false;
			}
			this._GaussBlur(rt);
			this.m_RawImage.texture = this.m_FrostedGlass;
			this.m_RawImage.color = Color.white;
		}
	}

	// Token: 0x06008C4A RID: 35914 RVA: 0x0019FB20 File Offset: 0x0019DF20
	private void OnDestroy()
	{
		if (null != this.m_GaussianBlurPass)
		{
			Object.Destroy(this.m_GaussianBlurPass);
			this.m_GaussianBlurPass = null;
		}
		if (null != this.m_BrightenPass)
		{
			Object.Destroy(this.m_BrightenPass);
			this.m_BrightenPass = null;
		}
		if (null != this.m_FrostedGlass)
		{
			Object.Destroy(this.m_FrostedGlass);
			this.m_FrostedGlass = null;
		}
	}

	// Token: 0x06008C4B RID: 35915 RVA: 0x0019FB96 File Offset: 0x0019DF96
	private void OnDisable()
	{
	}

	// Token: 0x06008C4C RID: 35916 RVA: 0x0019FB98 File Offset: 0x0019DF98
	private bool _PrepareMaterial()
	{
		if (null == this.m_GaussianBlurPass)
		{
			Shader shader = AssetShaderLoader.Find("HeroGo/UI/GaussianBlur");
			if (null != shader)
			{
				this.m_GaussianBlurPass = new Material(shader);
			}
			if (null == this.m_GaussianBlurPass)
			{
				return false;
			}
		}
		if (null == this.m_BrightenPass)
		{
			Shader shader2 = AssetShaderLoader.Find("HeroGo/UI/Brighten");
			if (null != shader2)
			{
				this.m_BrightenPass = new Material(shader2);
			}
			if (null == this.m_BrightenPass)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06008C4D RID: 35917 RVA: 0x0019FC34 File Offset: 0x0019E034
	private bool _Prepare()
	{
		GameObject gameObject = GameObject.Find("UIRoot/UICamera");
		if (null != gameObject)
		{
			this.m_Grabber = gameObject.GetComponent<ScreenGrabber>();
		}
		this.m_RawImage = base.gameObject.GetComponent<RawImage>();
		return true;
	}

	// Token: 0x06008C4E RID: 35918 RVA: 0x0019FC78 File Offset: 0x0019E078
	private void _GaussBlur(RenderTexture src)
	{
		if (null != src && this._PrepareMaterial())
		{
			int num = src.width;
			int num2 = src.height;
			if (this.m_Scale > 0)
			{
				num >>= this.m_Scale;
				num2 >>= this.m_Scale;
			}
			if (null != this.m_FrostedGlass && (this.m_FrostedGlass.width != num || this.m_FrostedGlass.height != num2))
			{
				Object.Destroy(this.m_FrostedGlass);
				this.m_FrostedGlass = null;
			}
			if (null == this.m_FrostedGlass)
			{
				this.m_FrostedGlass = new RenderTexture(src.width, src.height, 0, src.format);
			}
			if (null != this.m_FrostedGlass)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0, src.format);
				RenderTexture temporary2 = RenderTexture.GetTemporary(num, num2, 0, src.format);
				Graphics.Blit(src, temporary);
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.m_Iteration))
				{
					this.m_GaussianBlurPass.SetVector("_offsets", new Vector4(0f, this.m_BlurRadius, 0f, 0f));
					Graphics.Blit(temporary, temporary2, this.m_GaussianBlurPass);
					this.m_GaussianBlurPass.SetVector("_offsets", new Vector4(this.m_BlurRadius, 0f, 0f, 0f));
					Graphics.Blit(temporary2, temporary, this.m_GaussianBlurPass);
					num3++;
				}
				this.m_BrightenPass.SetFloat("_Brighteness", this.m_Brighteness);
				Graphics.Blit(temporary, this.m_FrostedGlass, this.m_BrightenPass);
				RenderTexture.ReleaseTemporary(temporary);
				RenderTexture.ReleaseTemporary(temporary2);
			}
		}
	}

	// Token: 0x04004560 RID: 17760
	private ScreenGrabber m_Grabber;

	// Token: 0x04004561 RID: 17761
	private RawImage m_RawImage;

	// Token: 0x04004562 RID: 17762
	private int m_Scale = 4;

	// Token: 0x04004563 RID: 17763
	private uint m_Iteration = 4U;

	// Token: 0x04004564 RID: 17764
	private float m_BlurRadius = 1f;

	// Token: 0x04004565 RID: 17765
	private float m_Brighteness = 0.05f;

	// Token: 0x04004566 RID: 17766
	private Material m_GaussianBlurPass;

	// Token: 0x04004567 RID: 17767
	private Material m_BrightenPass;

	// Token: 0x04004568 RID: 17768
	public RenderTexture m_FrostedGlass;

	// Token: 0x04004569 RID: 17769
	private int i;
}
