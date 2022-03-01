using System;
using System.IO;
using System.Runtime.CompilerServices;
using TMEngine.Runtime;
using UnityEngine;

// Token: 0x02000D25 RID: 3365
public class GeAnimFrameBillboard : MonoBehaviour
{
	// Token: 0x0600898B RID: 35211 RVA: 0x0018D310 File Offset: 0x0018B710
	public GeAnimFrameBillboard()
	{
		if (GeAnimFrameBillboard.<>f__mg$cache0 == null)
		{
			GeAnimFrameBillboard.<>f__mg$cache0 = new OnAssetLoadSuccess(GeAnimFrameBillboard._OnLoadAssetSuccess);
		}
		OnAssetLoadSuccess onSuccess = GeAnimFrameBillboard.<>f__mg$cache0;
		if (GeAnimFrameBillboard.<>f__mg$cache1 == null)
		{
			GeAnimFrameBillboard.<>f__mg$cache1 = new OnAssetLoadFailure(GeAnimFrameBillboard._OnLoadAssetFailure);
		}
		this.m_AssetLoadCallbacks = new AssetLoadCallbacks(onSuccess, GeAnimFrameBillboard.<>f__mg$cache1);
		base..ctor();
	}

	// Token: 0x0600898C RID: 35212 RVA: 0x0018D3D0 File Offset: 0x0018B7D0
	private static void _OnLoadAssetSuccess(string assetPath, object asset, int grpID, float duration, object userData)
	{
		if (userData == null)
		{
			return;
		}
		GeAnimFrameBillboard geAnimFrameBillboard = userData as GeAnimFrameBillboard;
		if (null == geAnimFrameBillboard)
		{
			return;
		}
		Texture2D texture2D = asset as Texture2D;
		if (null == texture2D)
		{
			return;
		}
		if (AssetLoader.INVILID_HANDLE != geAnimFrameBillboard.m_AtlasLoadHandle && grpID == (int)geAnimFrameBillboard.m_AtlasLoadHandle)
		{
			geAnimFrameBillboard._OnTextureLoadFinished(texture2D);
			geAnimFrameBillboard.m_AtlasLoadHandle = AssetLoader.INVILID_HANDLE;
			return;
		}
	}

	// Token: 0x0600898D RID: 35213 RVA: 0x0018D43D File Offset: 0x0018B83D
	private static void _OnLoadAssetFailure(string assetPath, AssetLoadErrorCode errorCode, string errorMessage, object userData)
	{
	}

	// Token: 0x1700184F RID: 6223
	// (get) Token: 0x0600898E RID: 35214 RVA: 0x0018D43F File Offset: 0x0018B83F
	// (set) Token: 0x0600898F RID: 35215 RVA: 0x0018D447 File Offset: 0x0018B847
	public int frameRate
	{
		get
		{
			return this.m_FrameRate;
		}
		set
		{
			this.m_FrameRate = value;
		}
	}

	// Token: 0x06008990 RID: 35216 RVA: 0x0018D450 File Offset: 0x0018B850
	private void Start()
	{
	}

	// Token: 0x06008991 RID: 35217 RVA: 0x0018D454 File Offset: 0x0018B854
	public void Init()
	{
		this.m_SpirteRenderer = base.gameObject.GetComponent<SpriteRenderer>();
		this.m_UVScaleOffPropertyID = Shader.PropertyToID("_UVScaleOff");
		this.m_MaterialParams = new MaterialPropertyBlock();
		if (this.m_SpirteRenderer != null)
		{
			this.m_SpirteRenderer.enabled = false;
			if (this.m_SpirteRenderer.sprite != null && this.m_SpirteRenderer.sprite.texture != null)
			{
				this.m_FrameTexSize.Set((float)this.m_SpirteRenderer.sprite.texture.width, (float)this.m_SpirteRenderer.sprite.texture.height);
			}
		}
		this.m_FrameTime = 1f / (float)this.m_FrameRate;
		if (this.m_AtlasLoadHandle == 4294967295U)
		{
			if (EngineConfig.useTMEngine)
			{
				this.m_AtlasLoadHandle = AssetLoader.LoadResAsync(Path.ChangeExtension(this.m_AtlasName, null), typeof(Texture2D), this.m_AssetLoadCallbacks, this, 0U, 0U);
			}
			else
			{
				this.m_AtlasLoadHandle = Singleton<AssetLoader>.instance.LoadResAync(Path.ChangeExtension(this.m_AtlasName, null), typeof(Texture2D), true, 0U, 0U);
			}
		}
		this.Play(true);
	}

	// Token: 0x06008992 RID: 35218 RVA: 0x0018D59C File Offset: 0x0018B99C
	private void Update()
	{
		if (this.m_IsPuased)
		{
			return;
		}
		if (!EngineConfig.useTMEngine && this.m_AtlasLoadHandle != 4294967295U && Singleton<AssetLoader>.instance.IsRequestDone(this.m_AtlasLoadHandle))
		{
			Texture2D texture = Singleton<AssetLoader>.instance.Extract(this.m_AtlasLoadHandle).obj as Texture2D;
			this._OnTextureLoadFinished(texture);
			this.m_AtlasLoadHandle = uint.MaxValue;
		}
		this.m_CurTime += Time.deltaTime;
		if (this.m_CurTime > this.m_FrameTime)
		{
			this.m_CurTime -= this.m_FrameTime;
			this.m_CurFrame++;
			if (this.m_CurFrame >= this.m_FrameCount)
			{
				this.m_CurFrame = 0;
			}
			if (this.m_SpirteRenderer != null && this.m_SpirteRenderer.enabled)
			{
				this.m_UVScaleOff.z = (float)(this.m_CurFrame % this.m_FrameColumn) * this.m_FrameTexSize.x / this.m_AtlasSize.x;
				this.m_UVScaleOff.w = 1f - (float)(this.m_CurFrame / this.m_FrameColumn + 1) * this.m_FrameTexSize.y / this.m_AtlasSize.y;
				if (this.m_MaterialParams != null)
				{
					this.m_MaterialParams.SetVector(this.m_UVScaleOffPropertyID, this.m_UVScaleOff);
					this.m_SpirteRenderer.SetPropertyBlock(this.m_MaterialParams);
				}
			}
		}
	}

	// Token: 0x06008993 RID: 35219 RVA: 0x0018D724 File Offset: 0x0018BB24
	public void SetVisible(bool isVisible)
	{
		if (null != this.m_SpirteRenderer)
		{
			Color color = this.m_SpirteRenderer.color;
			color.a = (float)((!isVisible) ? 0 : 1);
			this.m_SpirteRenderer.color = color;
		}
	}

	// Token: 0x06008994 RID: 35220 RVA: 0x0018D76F File Offset: 0x0018BB6F
	public void SetPause(bool pause)
	{
		this.m_IsPuased = pause;
	}

	// Token: 0x06008995 RID: 35221 RVA: 0x0018D778 File Offset: 0x0018BB78
	public float GetTimeLength()
	{
		return this.m_FrameTime * (float)this.m_FrameCount;
	}

	// Token: 0x06008996 RID: 35222 RVA: 0x0018D788 File Offset: 0x0018BB88
	public void Play(bool isReset)
	{
		this.m_IsPuased = false;
		if (isReset)
		{
			this.m_CurFrame = 0;
			this.m_CurTime = 0f;
		}
	}

	// Token: 0x06008997 RID: 35223 RVA: 0x0018D7A9 File Offset: 0x0018BBA9
	private void OnDestroy()
	{
		if (EngineConfig.useTMEngine && this.m_AtlasLoadHandle != 4294967295U)
		{
			Singleton<AssetLoader>.instance.AbortRequest(this.m_AtlasLoadHandle);
		}
	}

	// Token: 0x06008998 RID: 35224 RVA: 0x0018D7D4 File Offset: 0x0018BBD4
	private void Preload()
	{
		if (this.m_AtlasLoadHandle == 4294967295U)
		{
			if (EngineConfig.useTMEngine)
			{
				this.m_AtlasLoadHandle = AssetLoader.LoadResAsync(Path.ChangeExtension(this.m_AtlasName, null), typeof(Texture2D), this.m_AssetLoadCallbacks, this, 0U, 0U);
			}
			else
			{
				this.m_AtlasLoadHandle = Singleton<AssetLoader>.instance.LoadResAync(Path.ChangeExtension(this.m_AtlasName, null), typeof(Texture2D), true, 0U, 0U);
			}
		}
	}

	// Token: 0x06008999 RID: 35225 RVA: 0x0018D850 File Offset: 0x0018BC50
	protected void _OnTextureLoadFinished(Texture2D texture)
	{
		if (null == texture)
		{
			return;
		}
		this.m_AtlasTexture = texture;
		if (this.m_AtlasTexture != null && this.m_SpirteRenderer != null && this.m_UVScaleOffPropertyID != -1)
		{
			this.m_SpirteRenderer.enabled = true;
			this.m_AtlasSize.Set((float)this.m_AtlasTexture.width, (float)this.m_AtlasTexture.height);
			this.m_FrameColumn = (int)this.m_AtlasSize.x / (int)this.m_FrameTexSize.x;
			this.m_UVScaleOff.x = this.m_FrameTexSize.x / this.m_AtlasSize.x;
			this.m_UVScaleOff.y = this.m_FrameTexSize.y / this.m_AtlasSize.y;
			if (this.m_MaterialParams != null)
			{
				this.m_MaterialParams.SetTexture("_MainTex", this.m_AtlasTexture);
				this.m_SpirteRenderer.SetPropertyBlock(this.m_MaterialParams);
			}
		}
	}

	// Token: 0x040042FD RID: 17149
	[SerializeField]
	public int m_FrameRate = 10;

	// Token: 0x040042FE RID: 17150
	[SerializeField]
	public string m_AtlasName;

	// Token: 0x040042FF RID: 17151
	[SerializeField]
	public int m_FrameCount;

	// Token: 0x04004300 RID: 17152
	private Texture2D m_AtlasTexture;

	// Token: 0x04004301 RID: 17153
	private uint m_AtlasLoadHandle = uint.MaxValue;

	// Token: 0x04004302 RID: 17154
	private MaterialPropertyBlock m_MaterialParams;

	// Token: 0x04004303 RID: 17155
	private SpriteRenderer m_SpirteRenderer;

	// Token: 0x04004304 RID: 17156
	private int m_UVScaleOffPropertyID = -1;

	// Token: 0x04004305 RID: 17157
	private Vector4 m_UVScaleOff = new Vector4(1f, 1f, 0f, 0f);

	// Token: 0x04004306 RID: 17158
	private Vector2 m_AtlasSize = new Vector2(0f, 0f);

	// Token: 0x04004307 RID: 17159
	private int m_FrameColumn = 1;

	// Token: 0x04004308 RID: 17160
	private Vector2 m_FrameTexSize = new Vector2(256f, 64f);

	// Token: 0x04004309 RID: 17161
	[NonSerialized]
	protected int m_CurFrame;

	// Token: 0x0400430A RID: 17162
	[NonSerialized]
	protected float m_CurTime;

	// Token: 0x0400430B RID: 17163
	[NonSerialized]
	protected float m_FrameTime;

	// Token: 0x0400430C RID: 17164
	[NonSerialized]
	protected bool m_IsPuased;

	// Token: 0x0400430D RID: 17165
	private AssetLoadCallbacks m_AssetLoadCallbacks;

	// Token: 0x0400430E RID: 17166
	[CompilerGenerated]
	private static OnAssetLoadSuccess <>f__mg$cache0;

	// Token: 0x0400430F RID: 17167
	[CompilerGenerated]
	private static OnAssetLoadFailure <>f__mg$cache1;
}
