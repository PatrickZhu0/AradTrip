using System;
using UnityEngine;

// Token: 0x02000D78 RID: 3448
public class GeRenderTexture : IGeRenderTexture
{
	// Token: 0x1700189C RID: 6300
	// (get) Token: 0x06008BEA RID: 35818 RVA: 0x0019D30F File Offset: 0x0019B70F
	public int refCount
	{
		get
		{
			return this.m_RefCnt;
		}
	}

	// Token: 0x1700189D RID: 6301
	// (get) Token: 0x06008BEB RID: 35819 RVA: 0x0019D317 File Offset: 0x0019B717
	public string name
	{
		get
		{
			return this.m_RendTexName;
		}
	}

	// Token: 0x06008BEC RID: 35820 RVA: 0x0019D320 File Offset: 0x0019B720
	public bool Init(string name, GameObject attachRoot, int masklayer, int width, int height)
	{
		if (null != attachRoot)
		{
			this.m_RendTexRoot = new GameObject(name);
			if (null != this.m_RendTexRoot)
			{
				this.m_RendTexRoot.transform.SetParent(attachRoot.transform);
				Vector3 position = this.m_RendTexRoot.transform.position;
				position.y += 1f;
				this.m_RendTexRoot.transform.position = position;
				this.m_RendTexCamera = this.m_RendTexRoot.AddComponent<Camera>();
				if (null != this.m_RendTexCamera)
				{
					Vector3 eulerAngles = default(Vector3);
					eulerAngles.x = 25f;
					eulerAngles.y = 0f;
					eulerAngles.z = 0f;
					this.m_RendTexCamera.transform.eulerAngles = eulerAngles;
					Vector3 position2 = this.m_RendTexCamera.transform.position;
					position2.z -= 0.5f;
					this.m_RendTexCamera.transform.position = position2;
					this.m_RendTexCamera.clearFlags = 2;
					Color black = Color.black;
					black.a = 0f;
					this.m_RendTexCamera.backgroundColor = black;
					this.m_RendTexCamera.cullingMask = 1 << masklayer;
					this.m_RendTexCamera.orthographic = true;
					this.m_RendTexCamera.orthographicSize = 1.9f;
					this.m_RendTexCamera.depth = 0f;
					this.m_RendTexCamera.nearClipPlane = -5f;
					this.m_RendTexCamera.farClipPlane = 5f;
					GameObject gameObject = new GameObject("Directional Light");
					if (null != gameObject)
					{
						gameObject.transform.SetParent(this.m_RendTexRoot.transform, false);
						this.m_RendTexLight = gameObject.AddComponent<Light>();
						if (null != this.m_RendTexLight)
						{
							if (null != Global.Settings)
							{
								this.m_RendTexLight.transform.eulerAngles = Global.Settings.avatarLightDir;
							}
							this.m_RendTexLight.type = 1;
							this.m_RendTexLight.cullingMask = masklayer;
							this.m_RendTexLight.color = Color.white;
							this.m_RendTexLight.intensity = 0.5f;
							this.m_RendTexLight.shadows = 0;
							this.m_RendTexLight.renderMode = 0;
							this.m_RendModelRoot = new GameObject("Model Root");
							if (null != this.m_RendModelRoot)
							{
								this.m_RendModelRoot.transform.SetParent(this.m_RendTexRoot.transform, false);
								this.m_RenderTexture = RenderTexture.GetTemporary(width, height, 16, 0);
								if (null != this.m_RenderTexture)
								{
									this.m_RenderTexture.wrapMode = 1;
									this.m_RenderTexture.filterMode = 1;
									this.m_RendTexName = name;
									this.m_MaskLayer = masklayer;
									this.m_RendTexCamera.targetTexture = this.m_RenderTexture;
									return true;
								}
								Logger.LogErrorFormat("Create temporary render texture with w:{0} h:{1} fmt:{2} depth:{3} has failed!", new object[]
								{
									width,
									height,
									0.ToString(),
									16
								});
							}
							else
							{
								Logger.LogError("Create model root node has failed!");
							}
						}
						else
						{
							Logger.LogError("Add light component has failed!");
						}
					}
					else
					{
						Logger.LogError("Create light root node has failed!");
					}
				}
				else
				{
					Logger.LogError("Add camera component has failed!");
				}
				Object.Destroy(this.m_RendTexRoot);
				this.m_RendTexLight = null;
				this.m_RendTexCamera = null;
				this.m_RendModelRoot = null;
				this.m_RendTexRoot = null;
			}
			else
			{
				Logger.LogError("Allocate game object has failed!");
			}
		}
		else
		{
			Logger.LogError("Attach root can not be null!");
		}
		return false;
	}

	// Token: 0x06008BED RID: 35821 RVA: 0x0019D6E4 File Offset: 0x0019BAE4
	public void Deinit()
	{
		if (null != this.m_RenderTexture)
		{
			RenderTexture.ReleaseTemporary(this.m_RenderTexture);
			this.m_RenderTexture = null;
		}
		if (null != this.m_RendTexRoot)
		{
			Object.Destroy(this.m_RendTexRoot);
			this.m_RendTexRoot = null;
			this.m_RendTexCamera = null;
			this.m_RendModelRoot = null;
			this.m_RendTexLight = null;
		}
	}

	// Token: 0x06008BEE RID: 35822 RVA: 0x0019D74C File Offset: 0x0019BB4C
	public void AddRef()
	{
		this.m_RefCnt++;
	}

	// Token: 0x06008BEF RID: 35823 RVA: 0x0019D75C File Offset: 0x0019BB5C
	public void Release()
	{
		this.m_RefCnt--;
	}

	// Token: 0x06008BF0 RID: 35824 RVA: 0x0019D76C File Offset: 0x0019BB6C
	public GameObject GetModelRoot()
	{
		return this.m_RendModelRoot;
	}

	// Token: 0x06008BF1 RID: 35825 RVA: 0x0019D774 File Offset: 0x0019BB74
	public Camera GetCamera()
	{
		return this.m_RendTexCamera;
	}

	// Token: 0x06008BF2 RID: 35826 RVA: 0x0019D77C File Offset: 0x0019BB7C
	public Light GetLight()
	{
		return this.m_RendTexLight;
	}

	// Token: 0x06008BF3 RID: 35827 RVA: 0x0019D784 File Offset: 0x0019BB84
	public RenderTexture GetRenderTexture()
	{
		return this.m_RenderTexture;
	}

	// Token: 0x06008BF4 RID: 35828 RVA: 0x0019D78C File Offset: 0x0019BB8C
	public int GetMaskLayer()
	{
		return this.m_MaskLayer;
	}

	// Token: 0x0400451A RID: 17690
	protected GameObject m_RendTexRoot;

	// Token: 0x0400451B RID: 17691
	protected Camera m_RendTexCamera;

	// Token: 0x0400451C RID: 17692
	protected GameObject m_RendModelRoot;

	// Token: 0x0400451D RID: 17693
	protected Light m_RendTexLight;

	// Token: 0x0400451E RID: 17694
	protected string m_RendTexName;

	// Token: 0x0400451F RID: 17695
	protected RenderTexture m_RenderTexture;

	// Token: 0x04004520 RID: 17696
	protected int m_MaskLayer;

	// Token: 0x04004521 RID: 17697
	protected int m_RefCnt;
}
