using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

// Token: 0x02000FD6 RID: 4054
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/Gray")]
public class UIGray : MonoBehaviour
{
	// Token: 0x06009B15 RID: 39701 RVA: 0x001DFB78 File Offset: 0x001DDF78
	private void OnEnable()
	{
		this.images = base.transform.gameObject.GetComponentsInChildren<Image>(true);
		if (this.bEnabled2Text)
		{
			this.texts = base.transform.gameObject.GetComponentsInChildren<Text>(true);
		}
		this.SetGray();
	}

	// Token: 0x06009B16 RID: 39702 RVA: 0x001DFBC4 File Offset: 0x001DDFC4
	public void SetEnable(bool enabled)
	{
		if (enabled)
		{
			this.OnEnable();
		}
		else
		{
			this.Restore();
		}
	}

	// Token: 0x06009B17 RID: 39703 RVA: 0x001DFBDD File Offset: 0x001DDFDD
	public void Refresh()
	{
		if (base.enabled)
		{
			this.OnEnable();
		}
		else
		{
			this.Restore();
		}
	}

	// Token: 0x06009B18 RID: 39704 RVA: 0x001DFBFB File Offset: 0x001DDFFB
	public static void Refresh(UIGray gray)
	{
		if (null == gray)
		{
			return;
		}
		if (gray.enabled)
		{
			gray.OnEnable();
		}
		else
		{
			gray.Restore();
		}
	}

	// Token: 0x06009B19 RID: 39705 RVA: 0x001DFC26 File Offset: 0x001DE026
	private void OnDisable()
	{
		this.Restore();
	}

	// Token: 0x06009B1A RID: 39706 RVA: 0x001DFC30 File Offset: 0x001DE030
	public void SetGray()
	{
		if (this.images != null)
		{
			int i = 0;
			while (i < this.images.Length)
			{
				Image image = this.images[i];
				Texture texture = null;
				if (!(image.material != null))
				{
					goto IL_10A;
				}
				if (!(null != image.material.shader) || (!(image.material.shader.name == this.SHADER_ETC_NAME) && !(image.material.shader.name == this.SHADER_NAME)))
				{
					if (this.backup.ContainsKey(image))
					{
						this.backup[image] = image.material;
					}
					else
					{
						this.backup.Add(image, image.material);
					}
					if (image.material.shader.name == "UI/DefaultETC1-Custom" && image.material.HasProperty(this.m_Property__AlphaTex))
					{
						texture = image.material.GetTexture(this.m_Property__AlphaTex);
						goto IL_10A;
					}
					goto IL_10A;
				}
				IL_1BA:
				i++;
				continue;
				IL_10A:
				Material material;
				if (null != texture)
				{
					material = Singleton<GeMaterialPool>.instance.CreateMaterialInstance(this.SHADER_ETC_NAME);
					material.name = this.SHADER_ETC_NAME;
				}
				else
				{
					material = Singleton<GeMaterialPool>.instance.CreateMaterialInstance(this.SHADER_NAME);
					material.name = this.SHADER_NAME;
				}
				if (material != null)
				{
					material.SetFloat(this.m_Property__GrayScale, this.grayLevel);
					material.SetColor(this.m_Property__Color, new Color(1f, 1f, 1f, this.alpha));
					image.material = material;
					image.canvasRenderer.SetAlphaTexture(texture);
					this.matBackup.Add(material);
					goto IL_1BA;
				}
				goto IL_1BA;
			}
		}
		if (this.texts != null && this.bEnabled2Text)
		{
			for (int j = 0; j < this.texts.Length; j++)
			{
				Text text = this.texts[j];
				if (null != text)
				{
					if (this.Textbackup.ContainsKey(text))
					{
						if (text.color == this.grayFontColor)
						{
							goto IL_2A6;
						}
						this.Textbackup[text] = text.color;
					}
					else
					{
						this.Textbackup.Add(text, text.color);
					}
					text.color = this.grayFontColor;
					Outline component = text.GetComponent<Outline>();
					if (component != null)
					{
						component.enabled = false;
					}
					NicerOutline component2 = text.GetComponent<NicerOutline>();
					if (component2 != null)
					{
						component2.enabled = false;
					}
				}
				IL_2A6:;
			}
		}
	}

	// Token: 0x06009B1B RID: 39707 RVA: 0x001DFEF8 File Offset: 0x001DE2F8
	public void ResetMaterial()
	{
		if (this.images != null)
		{
			for (int i = 0; i < this.images.Length; i++)
			{
				Image image = this.images[i];
				if (image.material != null)
				{
					if (!(null != image.material.shader) || (!(image.material.shader.name == this.SHADER_ETC_NAME) && !(image.material.shader.name == this.SHADER_NAME)))
					{
						if (this.backup.ContainsKey(image))
						{
							this.backup[image] = image.material;
						}
						else
						{
							this.backup.Add(image, image.material);
						}
						if (image.material.HasProperty(this.m_Property__AlphaTex))
						{
							image.canvasRenderer.SetAlphaTexture(image.material.GetTexture(this.m_Property__AlphaTex));
						}
					}
				}
			}
		}
	}

	// Token: 0x06009B1C RID: 39708 RVA: 0x001E000A File Offset: 0x001DE40A
	public void ResetMaterial(Image image)
	{
		if (image != null && image.material != null)
		{
			this.backup.Remove(image);
			this.backup.Add(image, image.material);
		}
	}

	// Token: 0x06009B1D RID: 39709 RVA: 0x001E0048 File Offset: 0x001DE448
	public void SetImageAlpha(Image srcImage, Image destImage)
	{
		if (null == srcImage)
		{
			return;
		}
		if (this.backup.ContainsKey(srcImage) && this.backup[srcImage].HasProperty(this.m_Property__AlphaTex))
		{
			Texture texture = this.backup[srcImage].GetTexture(this.m_Property__AlphaTex);
			destImage.canvasRenderer.SetAlphaTexture(texture);
		}
	}

	// Token: 0x06009B1E RID: 39710 RVA: 0x001E00B4 File Offset: 0x001DE4B4
	public void Restore()
	{
		if (this.images != null)
		{
			for (int i = 0; i < this.images.Length; i++)
			{
				Image image = this.images[i];
				if (image != null)
				{
					if (this.backup.ContainsKey(image))
					{
						image.material = this.backup[image];
					}
					else if (null != image.material && (image.material.name == "UI/DefaultGray" || image.material.name == "UI/DefaultGrayETC1"))
					{
						image.material = null;
					}
				}
			}
		}
		if (this.texts != null)
		{
			for (int j = 0; j < this.texts.Length; j++)
			{
				Text text = this.texts[j];
				if (text != null)
				{
					if (this.Textbackup.ContainsKey(text))
					{
						text.color = this.Textbackup[text];
					}
					else
					{
						text.color = Color.white;
					}
					Outline component = text.GetComponent<Outline>();
					if (component != null)
					{
						component.enabled = true;
					}
					NicerOutline component2 = text.GetComponent<NicerOutline>();
					if (component2 != null)
					{
						component2.enabled = true;
					}
				}
			}
		}
		int k = 0;
		int count = this.matBackup.Count;
		while (k < count)
		{
			Singleton<GeMaterialPool>.instance.RecycleMaterialInstance(this.matBackup[k].name, this.matBackup[k]);
			k++;
		}
		this.matBackup.Clear();
		this.backup.Clear();
		this.Textbackup.Clear();
	}

	// Token: 0x040054A0 RID: 21664
	public float grayLevel = 1f;

	// Token: 0x040054A1 RID: 21665
	public Color grayFontColor = Color.gray;

	// Token: 0x040054A2 RID: 21666
	public float alpha = 1f;

	// Token: 0x040054A3 RID: 21667
	public bool bEnabled2Text = true;

	// Token: 0x040054A4 RID: 21668
	private readonly string SHADER_NAME = "UI/DefaultGray";

	// Token: 0x040054A5 RID: 21669
	private readonly string SHADER_ETC_NAME = "UI/DefaultGrayETC1";

	// Token: 0x040054A6 RID: 21670
	private Image[] images;

	// Token: 0x040054A7 RID: 21671
	private Dictionary<object, Material> backup = new Dictionary<object, Material>();

	// Token: 0x040054A8 RID: 21672
	private Dictionary<object, Color> Textbackup = new Dictionary<object, Color>();

	// Token: 0x040054A9 RID: 21673
	private List<Material> matBackup = new List<Material>();

	// Token: 0x040054AA RID: 21674
	private Text[] texts;

	// Token: 0x040054AB RID: 21675
	private string m_Property__AlphaTex = "_AlphaTex";

	// Token: 0x040054AC RID: 21676
	private string m_Property__GrayScale = "_GrayScale";

	// Token: 0x040054AD RID: 21677
	private string m_Property__Color = "_Color";
}
