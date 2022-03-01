using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D79 RID: 3449
public class GeRenderTextureManager : Singleton<GeRenderTextureManager>
{
	// Token: 0x06008BF6 RID: 35830 RVA: 0x0019D7B4 File Offset: 0x0019BBB4
	public override void Init()
	{
		this.m_RootNode = GameObject.Find(this.ROOT_NODE_NAME);
		this.m_CreateRoot = (null == this.m_RootNode);
		if (this.m_CreateRoot)
		{
			this.m_CreateRoot = true;
			this.m_RootNode = new GameObject(this.ROOT_NODE_NAME);
			if (null == this.m_RootNode)
			{
				Logger.LogError("Render texture manager init has failed, can not find root node");
			}
		}
		Object.DontDestroyOnLoad(this.m_RootNode);
		this.m_DefaultRendTex = new GeRenderTexture();
		if (this.m_DefaultRendTex != null)
		{
			if (this.m_DefaultRendTex.Init("NULL", this.m_RootNode, 0, 4, 4))
			{
				this.m_DefaultRendTex.AddRef();
				Camera camera = this.m_DefaultRendTex.GetCamera();
				if (null != camera)
				{
					camera.cullingMask = 0;
					camera.enabled = false;
				}
			}
			else
			{
				Logger.LogError("Init default render texture has failed!");
				this.m_DefaultRendTex = null;
			}
		}
		else
		{
			Logger.LogError("New render texture has failed!");
		}
	}

	// Token: 0x06008BF7 RID: 35831 RVA: 0x0019D8B8 File Offset: 0x0019BCB8
	public override void UnInit()
	{
		this._ClearAll();
		if (this.m_DefaultRendTex != null)
		{
			this.m_DefaultRendTex.Deinit();
			this.m_DefaultRendTex = null;
		}
		if (this.m_CreateRoot && null != this.m_RootNode)
		{
			Object.Destroy(this.m_RootNode);
		}
		this.m_RootNode = null;
	}

	// Token: 0x06008BF8 RID: 35832 RVA: 0x0019D918 File Offset: 0x0019BD18
	public IGeRenderTexture FindRenderTextureByName(string name)
	{
		GeRenderTexture result = null;
		if (this.m_RendTexNameTable.TryGetValue(name, out result))
		{
			return result;
		}
		return this.m_DefaultRendTex;
	}

	// Token: 0x06008BF9 RID: 35833 RVA: 0x0019D944 File Offset: 0x0019BD44
	public IGeRenderTexture CreateRenderTexture(string name, int masklayer, int width, int height)
	{
		if (string.IsNullOrEmpty(name))
		{
			Logger.LogError("Texture name can not be null!");
			return null;
		}
		GeRenderTexture geRenderTexture = null;
		if (!this.m_RendTexNameTable.TryGetValue(name, out geRenderTexture))
		{
			geRenderTexture = new GeRenderTexture();
			if (geRenderTexture != null)
			{
				if (geRenderTexture.Init(name, this.m_RootNode, masklayer, width, height))
				{
					geRenderTexture.AddRef();
					this.m_RendTexNameTable.Add(name, geRenderTexture);
					return geRenderTexture;
				}
				Logger.LogErrorFormat("Init render texture named {0} with parameters[w:{1} h:{2} layer:{3}] has failed!", new object[]
				{
					name,
					width,
					height,
					geRenderTexture.GetMaskLayer()
				});
				geRenderTexture = null;
			}
			else
			{
				Logger.LogError("New render texture has failed!");
			}
			return null;
		}
		RenderTexture renderTexture = geRenderTexture.GetRenderTexture();
		if (renderTexture.width != width || renderTexture.height != height || geRenderTexture.GetMaskLayer() != masklayer)
		{
			Logger.LogErrorFormat("There is already exist a render texture named {0} with different parameters[w:{1} h:{2} layer:{3}]", new object[]
			{
				name,
				renderTexture.width,
				renderTexture.height,
				geRenderTexture.GetMaskLayer()
			});
			return null;
		}
		geRenderTexture.AddRef();
		return geRenderTexture;
	}

	// Token: 0x06008BFA RID: 35834 RVA: 0x0019DA70 File Offset: 0x0019BE70
	public void DestroyRenderTexture(IGeRenderTexture rendTex)
	{
		if (rendTex == this.m_DefaultRendTex)
		{
			return;
		}
		GeRenderTexture geRenderTexture = rendTex as GeRenderTexture;
		if (geRenderTexture != null)
		{
			geRenderTexture.Release();
			if (geRenderTexture.refCount == 0)
			{
				geRenderTexture.Deinit();
				this.m_RendTexNameTable.Remove(geRenderTexture.name);
			}
		}
	}

	// Token: 0x06008BFB RID: 35835 RVA: 0x0019DAC0 File Offset: 0x0019BEC0
	protected void _ClearAll()
	{
		foreach (KeyValuePair<string, GeRenderTexture> keyValuePair in this.m_RendTexNameTable)
		{
			GeRenderTexture value = keyValuePair.Value;
			if (value.refCount != 0)
			{
			}
			value.Deinit();
		}
		this.m_RendTexNameTable.Clear();
	}

	// Token: 0x04004522 RID: 17698
	protected readonly string ROOT_NODE_NAME = "Environment";

	// Token: 0x04004523 RID: 17699
	public Dictionary<string, GeRenderTexture> m_RendTexNameTable = new Dictionary<string, GeRenderTexture>();

	// Token: 0x04004524 RID: 17700
	public GameObject m_RootNode;

	// Token: 0x04004525 RID: 17701
	public bool m_CreateRoot;

	// Token: 0x04004526 RID: 17702
	protected GeRenderTexture m_DefaultRendTex;
}
