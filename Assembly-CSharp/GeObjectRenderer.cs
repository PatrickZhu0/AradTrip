using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000CF8 RID: 3320
[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(CanvasRenderer))]
public class GeObjectRenderer : MonoBehaviour
{
	// Token: 0x060087DC RID: 34780 RVA: 0x0018142C File Offset: 0x0017F82C
	protected void _Init()
	{
		if (null == this.m_AvatarRoot)
		{
			this.m_AvatarRoot = new GameObject("AvatarRender");
		}
		if (this.m_Attachment == null)
		{
			this.m_Attachment = new GeAttachManager();
		}
		if (this.m_TextureWidth < 1)
		{
			this.m_TextureWidth = 1;
		}
		if (this.m_TextureHight < 1)
		{
			this.m_TextureHight = 1;
		}
		if (this.m_RenderTexture == null)
		{
			this.m_RenderTexture = Singleton<GeRenderTextureManager>.instance.CreateRenderTexture(base.gameObject.name + base.gameObject.GetHashCode(), this.m_Layer, this.m_TextureWidth, this.m_TextureHight);
			if (this.m_RenderTexture != null)
			{
				this.m_Light = this.m_RenderTexture.GetLight();
				this.m_Camera = this.m_RenderTexture.GetCamera();
				this.m_Root = this.m_RenderTexture.GetModelRoot();
				if (null != this.m_Camera)
				{
					Camera.onPreRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPreRender, new Camera.CameraCallback(this.AvatarPreRender));
					Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(this.AvatarPostRender));
					RawImage component = base.gameObject.GetComponent<RawImage>();
					if (null != component)
					{
						component.texture = this.m_RenderTexture.GetRenderTexture();
					}
					this._RefreshValues();
					return;
				}
			}
		}
	}

	// Token: 0x060087DD RID: 34781 RVA: 0x001815A8 File Offset: 0x0017F9A8
	protected void _RefreshValues()
	{
		if (null != this.m_Camera)
		{
			this.m_Camera.transform.eulerAngles = this.m_CameraRot;
			this.m_Camera.transform.position = this.m_CameraPos;
			this.m_Camera.orthographic = !this.m_IsPersp;
			this.m_Camera.orthographicSize = this.m_OrthoSize;
			this.m_Camera.fieldOfView = this.m_FOV;
			this.m_Camera.nearClipPlane = this.m_NearPlane;
			this.m_Camera.farClipPlane = this.m_FarPlane;
		}
		if (null != this.m_Light)
		{
			this.m_Light.color = this.m_LightCol;
			this.m_Light.transform.eulerAngles = this.m_LightRot;
		}
	}

	// Token: 0x060087DE RID: 34782 RVA: 0x00181684 File Offset: 0x0017FA84
	protected void _Deinit()
	{
		if (this.m_RenderTexture != null)
		{
			Singleton<GeRenderTextureManager>.instance.DestroyRenderTexture(this.m_RenderTexture);
			this.m_RenderTexture = null;
			this.m_Light = null;
			this.m_Camera = null;
			this.m_Root = null;
		}
		if (this.m_Attachment != null)
		{
			this.m_Attachment.Deinit();
			this.m_Attachment = null;
		}
		if (null != this.m_Object)
		{
			Object.Destroy(this.m_Object);
			this.m_Object = null;
		}
		if (this.m_ObjectWrap != null)
		{
			Object.Destroy(this.m_ObjectWrap);
			this.m_ObjectWrap = null;
		}
		if (this.m_AvatarRoot)
		{
			Object.Destroy(this.m_AvatarRoot);
			this.m_AvatarRoot = null;
		}
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(this.AvatarPreRender));
		Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.AvatarPostRender));
	}

	// Token: 0x060087DF RID: 34783 RVA: 0x00181790 File Offset: 0x0017FB90
	public void LoadObject(string objRes, int layer = -1, string wrapObjectPath = null)
	{
		if (!base.gameObject.activeSelf)
		{
			return;
		}
		if (layer != -1)
		{
			this.m_Layer = layer;
		}
		this._Init();
		if (!string.IsNullOrEmpty(objRes))
		{
			this.m_Object = Singleton<AssetLoader>.instance.LoadResAsGameObject(objRes, true, 0U);
			if (null != this.m_Object)
			{
				Renderer[] componentsInChildren = this.m_Object.GetComponentsInChildren<Renderer>();
				int i = 0;
				int num = componentsInChildren.Length;
				while (i < num)
				{
					if (!(null == componentsInChildren[i]))
					{
						componentsInChildren[i].gameObject.layer = this.m_Layer;
					}
					i++;
				}
				this.m_Attachment.RefreshAttachNode(this.m_Object, false, false);
				Animation component = this.m_Object.GetComponent<Animation>();
				if (component != null)
				{
					component.Stop();
				}
				if (wrapObjectPath != null)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(wrapObjectPath, true, 0U);
					if (gameObject != null)
					{
						Utility.AttachTo(this.m_Object, Utility.FindGameObject(gameObject, "root", false), false);
						this.m_ObjectWrap = gameObject;
					}
				}
				return;
			}
			Logger.LogErrorFormat("Load object resource has failed with resource path {0}!", new object[]
			{
				objRes
			});
		}
	}

	// Token: 0x060087E0 RID: 34784 RVA: 0x001818C7 File Offset: 0x0017FCC7
	public void ClearObject()
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.ClearAll();
		}
		Object.Destroy(this.m_Object);
		this.m_Object = null;
	}

	// Token: 0x060087E1 RID: 34785 RVA: 0x001818F1 File Offset: 0x0017FCF1
	public GeEffectEx CreateEffect(string effectRes, string attachNode, float fTime, EffectTimeType timeType, Vector3 localPos, Quaternion localRot, float initScale = 1f, float fSpeed = 1f, bool isLoop = false)
	{
		return null;
	}

	// Token: 0x060087E2 RID: 34786 RVA: 0x001818F4 File Offset: 0x0017FCF4
	public void OnUpdate(float fDelta)
	{
		this.RotateY(this.m_RotateDegree);
	}

	// Token: 0x060087E3 RID: 34787 RVA: 0x00181904 File Offset: 0x0017FD04
	public void SetLocalScale(float scale)
	{
		if (null == this.m_Object)
		{
			return;
		}
		Vector3 vector = this.m_Object.transform.localScale;
		vector *= scale;
		this.m_Object.transform.localScale = vector;
	}

	// Token: 0x060087E4 RID: 34788 RVA: 0x0018194D File Offset: 0x0017FD4D
	public void SetLocalPosition(Vector3 pos)
	{
		if (null == this.m_Object)
		{
			return;
		}
		this.m_Object.transform.localPosition = pos;
	}

	// Token: 0x060087E5 RID: 34789 RVA: 0x00181974 File Offset: 0x0017FD74
	public void RotateY(float degree)
	{
		Vector3 localEulerAngles = this.m_AvatarRoot.transform.localEulerAngles;
		localEulerAngles.y = degree;
		this.m_AvatarRoot.transform.localEulerAngles = localEulerAngles;
	}

	// Token: 0x060087E6 RID: 34790 RVA: 0x001819AB File Offset: 0x0017FDAB
	public void AvatarPreRender(Camera cam)
	{
		if (cam == this.m_Camera)
		{
			this.m_OriginAmbient = RenderSettings.ambientLight;
			RenderSettings.ambientLight = this.m_AmbientCol;
		}
	}

	// Token: 0x060087E7 RID: 34791 RVA: 0x001819D4 File Offset: 0x0017FDD4
	public void AvatarPostRender(Camera cam)
	{
		if (cam == this.m_Camera)
		{
			RenderSettings.ambientLight = this.m_OriginAmbient;
		}
	}

	// Token: 0x060087E8 RID: 34792 RVA: 0x001819F4 File Offset: 0x0017FDF4
	public void ChangePhase(string phaseEffect, int phaseIdx, bool forceAddtive = false)
	{
		GeAttach geAttach = new GeAttach(this.m_Object);
		if (geAttach != null)
		{
			geAttach.ChangePhase(phaseEffect, phaseIdx, false);
			this.m_Attachment.GetAttachList().Add(geAttach);
		}
	}

	// Token: 0x060087E9 RID: 34793 RVA: 0x00181A2D File Offset: 0x0017FE2D
	private void Start()
	{
	}

	// Token: 0x060087EA RID: 34794 RVA: 0x00181A2F File Offset: 0x0017FE2F
	private void OnDestroy()
	{
		this._Deinit();
	}

	// Token: 0x060087EB RID: 34795 RVA: 0x00181A37 File Offset: 0x0017FE37
	private void OnEnable()
	{
	}

	// Token: 0x060087EC RID: 34796 RVA: 0x00181A39 File Offset: 0x0017FE39
	public void OnValidate()
	{
		this._RefreshValues();
	}

	// Token: 0x040041A0 RID: 16800
	public string m_RenderTexName = "DeftAvatarRend";

	// Token: 0x040041A1 RID: 16801
	public Vector3 m_LightRot = default(Vector3);

	// Token: 0x040041A2 RID: 16802
	public Color m_LightCol = Color.white;

	// Token: 0x040041A3 RID: 16803
	public Color m_AmbientCol = Color.black;

	// Token: 0x040041A4 RID: 16804
	public Color m_OriginAmbient = Color.black;

	// Token: 0x040041A5 RID: 16805
	public float m_OrthoSize = 1.2f;

	// Token: 0x040041A6 RID: 16806
	public Vector3 m_CameraRot = new Vector3(15f, 0f, 0f);

	// Token: 0x040041A7 RID: 16807
	public Vector3 m_CameraPos = new Vector3(0f, 1f, -1f);

	// Token: 0x040041A8 RID: 16808
	public float m_NearPlane = 0.3f;

	// Token: 0x040041A9 RID: 16809
	public float m_FarPlane = 10f;

	// Token: 0x040041AA RID: 16810
	public float m_FOV = 45f;

	// Token: 0x040041AB RID: 16811
	public bool m_IsPersp;

	// Token: 0x040041AC RID: 16812
	public int m_Layer = 30;

	// Token: 0x040041AD RID: 16813
	public int m_TextureWidth = 619;

	// Token: 0x040041AE RID: 16814
	public int m_TextureHight = 817;

	// Token: 0x040041AF RID: 16815
	public float m_RotateDegree = 10f;

	// Token: 0x040041B0 RID: 16816
	public string m_AvatarPath = string.Empty;

	// Token: 0x040041B1 RID: 16817
	public string m_AvatarName = string.Empty;

	// Token: 0x040041B2 RID: 16818
	protected Light m_Light;

	// Token: 0x040041B3 RID: 16819
	protected GameObject m_Root;

	// Token: 0x040041B4 RID: 16820
	protected Camera m_Camera;

	// Token: 0x040041B5 RID: 16821
	protected IGeRenderTexture m_RenderTexture;

	// Token: 0x040041B6 RID: 16822
	protected GameObject m_AvatarRoot;

	// Token: 0x040041B7 RID: 16823
	protected GameObject m_Object;

	// Token: 0x040041B8 RID: 16824
	protected GameObject m_ObjectWrap;

	// Token: 0x040041B9 RID: 16825
	protected GeAttachManager m_Attachment;

	// Token: 0x040041BA RID: 16826
	protected float m_CurRotate;
}
