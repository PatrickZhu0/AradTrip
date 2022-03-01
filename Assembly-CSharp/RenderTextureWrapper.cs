using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000D89 RID: 3465
public class RenderTextureWrapper : MonoBehaviour
{
	// Token: 0x06008C61 RID: 35937 RVA: 0x001A004E File Offset: 0x0019E44E
	private void Start()
	{
		this._Binding();
	}

	// Token: 0x06008C62 RID: 35938 RVA: 0x001A0056 File Offset: 0x0019E456
	private void OnEnable()
	{
		this._Binding();
	}

	// Token: 0x06008C63 RID: 35939 RVA: 0x001A005E File Offset: 0x0019E45E
	public void Rebind()
	{
		this._Binding();
	}

	// Token: 0x06008C64 RID: 35940 RVA: 0x001A0068 File Offset: 0x0019E468
	protected void _Binding()
	{
		IGeRenderTexture geRenderTexture = Singleton<GeRenderTextureManager>.instance.FindRenderTextureByName(this.renderTextureName);
		if (geRenderTexture != null)
		{
			RawImage componentInChildren = base.gameObject.transform.GetComponentInChildren<RawImage>();
			if (null != componentInChildren)
			{
				componentInChildren.texture = geRenderTexture.GetRenderTexture();
			}
			else
			{
				Logger.LogErrorFormat("Prefab {0} does not contain an RawImage component!", new object[]
				{
					base.gameObject.name
				});
			}
		}
	}

	// Token: 0x0400456D RID: 17773
	public string renderTextureName = string.Empty;
}
