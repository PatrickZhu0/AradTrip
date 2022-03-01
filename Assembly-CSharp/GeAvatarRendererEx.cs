using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000CEA RID: 3306
[RequireComponent(typeof(RawImage))]
[RequireComponent(typeof(CanvasRenderer))]
public class GeAvatarRendererEx : MonoBehaviour, IDragHandler, IGeAvatarActor, IEventSystemHandler
{
	// Token: 0x0600876C RID: 34668 RVA: 0x0017E358 File Offset: 0x0017C758
	protected void _Init()
	{
		this._Deinit();
		if (null == this.m_AvatarRoot)
		{
			this.m_AvatarRoot = new GameObject("AvatarRender");
		}
		if (this.m_Effect == null)
		{
			this.m_Effect = new GeEffectManager();
		}
		if (this.m_Avatar == null)
		{
			this.m_Avatar = new GeAvatar(false);
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

	// Token: 0x0600876D RID: 34669 RVA: 0x0017E4F0 File Offset: 0x0017C8F0
	private void Update()
	{
		float deltaTime = Time.deltaTime;
		if (this.m_Avatar != null)
		{
			int num = (int)(deltaTime * 1000f);
			if (!this.m_Avatar.IsLoadFinished())
			{
				this.m_NeedInitAfterLoad = true;
				this.m_Avatar.UpdateAsyncLoading();
			}
			else
			{
				if (this.m_NeedInitAfterLoad)
				{
					this._OnAvatarLoaded();
				}
				if (this.m_Effect != null)
				{
					this.m_Effect.Update(num, GeEffectType.EffectMultiple);
					this.m_Effect.Update(num, GeEffectType.EffectUnique);
				}
			}
			this.m_Avatar.Update(num, 2U);
		}
	}

	// Token: 0x0600876E RID: 34670 RVA: 0x0017E584 File Offset: 0x0017C984
	protected void _OnAvatarLoaded()
	{
		GameObject avatarRoot = this.m_Avatar.GetAvatarRoot();
		if (null != avatarRoot)
		{
			avatarRoot.transform.SetParent(this.m_AvatarRoot.transform, false);
			avatarRoot.SetActive(true);
			this.m_Avatar.SetAvatarVisible(true);
			this.m_Avatar.SetAmbientColor(this.m_AmbientCol);
			this.m_NeedInitAfterLoad = false;
		}
	}

	// Token: 0x0600876F RID: 34671 RVA: 0x0017E5EC File Offset: 0x0017C9EC
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

	// Token: 0x06008770 RID: 34672 RVA: 0x0017E6C8 File Offset: 0x0017CAC8
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
		if (this.m_Effect != null)
		{
			this.m_Effect.Deinit();
			this.m_Effect = null;
		}
		if (this.m_Avatar != null)
		{
			GameObject avatarRoot = this.m_Avatar.GetAvatarRoot();
			if (avatarRoot)
			{
				avatarRoot.transform.SetParent(null, true);
			}
			this.m_Avatar.Deinit();
			this.m_Avatar = null;
		}
		if (this.m_AvatarRoot)
		{
			Object.Destroy(this.m_AvatarRoot);
			this.m_AvatarRoot = null;
		}
		if (this.m_ModelDataAsset != null)
		{
			this.m_ModelDataAsset = null;
			this.m_ModelData = null;
		}
		Camera.onPreRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPreRender, new Camera.CameraCallback(this.AvatarPreRender));
		Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(this.AvatarPostRender));
	}

	// Token: 0x06008771 RID: 34673 RVA: 0x0017E7E8 File Offset: 0x0017CBE8
	public void LoadAvatar(string avatarRes, int layer = -1)
	{
		if (null == this.m_AvatarRoot)
		{
			return;
		}
		if (layer != -1)
		{
			this.m_Layer = layer;
		}
		this.ClearAvatar();
		this._Init();
		if (!string.IsNullOrEmpty(avatarRes))
		{
			Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.SceneActor);
			this.m_AvatarPath = avatarRes;
			this.m_AvatarName = Path.GetFileNameWithoutExtension(this.m_AvatarPath);
			this.m_ModelDataAsset = Singleton<AssetLoader>.instance.LoadRes(this.GetModelDataPath(), typeof(ScriptableObject), false, 0U);
			if (this.m_ModelDataAsset != null)
			{
				this.m_ModelData = (this.m_ModelDataAsset.obj as DModelData);
				if (this.m_ModelData)
				{
					if (this.m_Avatar.Init(this.m_ModelData.modelAvatar.m_AssetPath, this.m_Layer, true, false, false))
					{
						this.m_NeedInitAfterLoad = true;
						this._OnAvatarLoaded();
						for (int i = 0; i < this.m_ModelData.partsChunk.Length; i++)
						{
							int partChannel = (int)this.m_ModelData.partsChunk[i].partChannel;
							if (0 <= partChannel && partChannel < GeAvatarRendererEx.avatarChanTbl.Length)
							{
								this.m_Avatar.AddDefaultAvatar(GeAvatarRendererEx.avatarChanTbl[partChannel], this.m_ModelData.partsChunk[i].partAsset);
							}
						}
						this.m_Avatar.ChangeAction("Anim_Show_Idle", 1f, true);
						this.m_Avatar.SetLoadCallback(new OnAvatarLoaded(this.OnLoaded));
						return;
					}
					Logger.LogErrorFormat("Init avatar has failed with resource path {0}", new object[]
					{
						avatarRes
					});
				}
				else
				{
					if (this.m_Avatar.Init(avatarRes, this.m_Layer, true, true, false))
					{
						this.m_Avatar.ChangeLayer(this.m_Layer);
						this.m_Avatar.ChangeAction("Anim_Idle", 1f, true);
						this.m_NeedInitAfterLoad = true;
						return;
					}
					Logger.LogErrorFormat("Init avatar has failed with resource path {0}", new object[]
					{
						avatarRes
					});
				}
			}
		}
	}

	// Token: 0x06008772 RID: 34674 RVA: 0x0017E9FB File Offset: 0x0017CDFB
	public void ClearAvatar()
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.ClearAll();
		}
		Singleton<AssetGabageCollectorHelper>.instance.AddGCPurgeTick(AssetGCTickType.SceneActor);
	}

	// Token: 0x06008773 RID: 34675 RVA: 0x0017EA1E File Offset: 0x0017CE1E
	public string GetModelDataPath()
	{
		return Path.ChangeExtension(this.m_AvatarPath, "asset");
	}

	// Token: 0x06008774 RID: 34676 RVA: 0x0017EA30 File Offset: 0x0017CE30
	public void ChangeAvatar(GeAvatarChannel eChannel, string modulePath, bool isAsync = true, bool highPriority = false)
	{
		DAssetObject asset = new DAssetObject(null, modulePath);
		this.ChangeAvatar(eChannel, asset, isAsync, highPriority);
	}

	// Token: 0x06008775 RID: 34677 RVA: 0x0017EA51 File Offset: 0x0017CE51
	public void ChangeAvatar(GeAvatarChannel eChannel, DAssetObject asset, bool isAsync = true, bool highPriority = false)
	{
		this.m_NeedInitAfterLoad = true;
		if (this.m_Avatar != null)
		{
			this.m_Avatar.ChangeAvatarObject(eChannel, asset, isAsync, highPriority, 0);
		}
	}

	// Token: 0x06008776 RID: 34678 RVA: 0x0017EA76 File Offset: 0x0017CE76
	public void SuitAvatar(bool isAsync = true, bool highPriority = false)
	{
		this.m_NeedInitAfterLoad = true;
		if (this.m_Avatar != null)
		{
			this.m_Avatar.SuitAvatar(isAsync, highPriority, 0);
		}
	}

	// Token: 0x06008777 RID: 34679 RVA: 0x0017EA98 File Offset: 0x0017CE98
	public GeAttach AttachAvatar(string attachmentName, string attachRes, string attachNode, bool needClear = true, bool asyncLoad = true, bool highPriority = false, float fAttHeight = 0f)
	{
		if (needClear && this.m_Avatar != null)
		{
			this.m_Avatar.ClearAttachmentOnNode(attachNode);
		}
		if (this.m_Avatar != null)
		{
			GeAttach geAttach = this.m_Avatar.CreateAttachment(attachmentName, attachRes, attachNode, false, asyncLoad, highPriority);
			if (geAttach != null)
			{
				geAttach.SetLayer(this.m_Layer);
				if (fAttHeight != 0f)
				{
					Vector3 localPosition = geAttach.root.transform.localPosition;
					localPosition.y = fAttHeight;
					geAttach.root.transform.localPosition = localPosition;
				}
			}
			if (attachmentName == "Aureole")
			{
				GeAttach attachment = this.m_Avatar.GetAttachment("halo");
				if (attachment != null && !attachment.NeedDestroy && geAttach != null)
				{
					geAttach.SetVisible(false);
				}
			}
			return geAttach;
		}
		return null;
	}

	// Token: 0x06008778 RID: 34680 RVA: 0x0017EB6D File Offset: 0x0017CF6D
	public void RemoveAttach(GeAttach attachment)
	{
		this.m_Avatar.DestroyAttachment(attachment);
	}

	// Token: 0x06008779 RID: 34681 RVA: 0x0017EB7B File Offset: 0x0017CF7B
	public GeEffectEx CreateEffect(string effectRes, string attachNode, float fTime, EffectTimeType timeType, Vector3 localPos, Quaternion localRot, float initScale = 1f, float fSpeed = 1f, bool isLoop = false)
	{
		return null;
	}

	// Token: 0x0600877A RID: 34682 RVA: 0x0017EB80 File Offset: 0x0017CF80
	public GeEffectEx CreateEffect(string effectPath, float fTime, Vector3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool faceLeft = false)
	{
		DAssetObject effectRes;
		effectRes.m_AssetObj = null;
		effectRes.m_AssetPath = effectPath;
		return this.CreateEffect(effectRes, EffectsFrames.Default, fTime, initPos, initScale, fSpeed, isLoop, faceLeft);
	}

	// Token: 0x0600877B RID: 34683 RVA: 0x0017EBB4 File Offset: 0x0017CFB4
	public GeEffectEx CreateEffect(DAssetObject effectRes, EffectsFrames info, float fTime, Vector3 initPos, float initScale = 1f, float fSpeed = 1f, bool isLoop = false, bool faceLeft = false)
	{
		if (null != effectRes.m_AssetObj || (effectRes.m_AssetPath != null && string.Empty != effectRes.m_AssetPath))
		{
			GeEffectEx geEffectEx = this.m_Effect.AddEffect(effectRes, info, fTime, initPos, null, faceLeft, false);
			if (geEffectEx != null)
			{
				geEffectEx.SetLayer(this.m_Layer);
				bool flag = false;
				if (info.timetype == EffectTimeType.GLOBAL_ANIMATION)
				{
					flag = true;
				}
				else if (geEffectEx.GetDefaultTimeLen() < fTime)
				{
					flag = true;
				}
				geEffectEx.SetSpeed(fSpeed);
				geEffectEx.Play(flag || isLoop);
				return geEffectEx;
			}
		}
		return null;
	}

	// Token: 0x0600877C RID: 34684 RVA: 0x0017EC62 File Offset: 0x0017D062
	public void OnUpdate(float fDelta)
	{
	}

	// Token: 0x0600877D RID: 34685 RVA: 0x0017EC64 File Offset: 0x0017D064
	public GeAttach GetAttachment(string name)
	{
		if (this.m_Avatar == null)
		{
			return null;
		}
		return this.m_Avatar.GetAttachment(name);
	}

	// Token: 0x0600877E RID: 34686 RVA: 0x0017EC7F File Offset: 0x0017D07F
	public void ChangeAction(string actionName, float speed = 1f, bool loop = false)
	{
		if (this.m_Avatar == null)
		{
			return;
		}
		this.m_Avatar.ChangeAction(actionName, speed, loop);
	}

	// Token: 0x0600877F RID: 34687 RVA: 0x0017EC9C File Offset: 0x0017D09C
	public string GetCurActionName()
	{
		if (this.m_Avatar != null)
		{
			return this.m_Avatar.GetCurActionName();
		}
		return string.Empty;
	}

	// Token: 0x06008780 RID: 34688 RVA: 0x0017ECBA File Offset: 0x0017D0BA
	public bool IsCurActionEnd()
	{
		return this.m_Avatar.IsActionFinished();
	}

	// Token: 0x06008781 RID: 34689 RVA: 0x0017ECC8 File Offset: 0x0017D0C8
	public void RotateY(float degree)
	{
		Vector3 localEulerAngles = this.m_AvatarRoot.transform.localEulerAngles;
		localEulerAngles.y = degree;
		this.m_AvatarRoot.transform.localEulerAngles = localEulerAngles;
	}

	// Token: 0x06008782 RID: 34690 RVA: 0x0017ED00 File Offset: 0x0017D100
	public void AvatarPreRender(Camera cam)
	{
		if (cam == this.m_Camera)
		{
			if (this.m_LastAmbient != this.m_AmbientCol)
			{
				this.m_LastAmbient = this.m_AmbientCol;
				if (this.m_Avatar != null)
				{
					this.m_Avatar.SetAmbientColor(this.m_AmbientCol);
				}
			}
			this.m_OriginAmbient = RenderSettings.ambientLight;
			RenderSettings.ambientLight = this.m_AmbientCol;
		}
	}

	// Token: 0x06008783 RID: 34691 RVA: 0x0017ED72 File Offset: 0x0017D172
	public void AvatarPostRender(Camera cam)
	{
		if (cam == this.m_Camera)
		{
			RenderSettings.ambientLight = this.m_OriginAmbient;
		}
	}

	// Token: 0x06008784 RID: 34692 RVA: 0x0017ED90 File Offset: 0x0017D190
	private void Start()
	{
	}

	// Token: 0x06008785 RID: 34693 RVA: 0x0017ED92 File Offset: 0x0017D192
	private void OnDestroy()
	{
		this._Deinit();
	}

	// Token: 0x06008786 RID: 34694 RVA: 0x0017ED9A File Offset: 0x0017D19A
	private void OnEnable()
	{
		this._Init();
	}

	// Token: 0x06008787 RID: 34695 RVA: 0x0017EDA2 File Offset: 0x0017D1A2
	public void OnValidate()
	{
		this._RefreshValues();
	}

	// Token: 0x06008788 RID: 34696 RVA: 0x0017EDAC File Offset: 0x0017D1AC
	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.dragging)
		{
			this.m_CurRotate -= eventData.delta.x * 0.6f;
			this.RotateY(this.m_CurRotate);
		}
	}

	// Token: 0x17001826 RID: 6182
	// (get) Token: 0x06008789 RID: 34697 RVA: 0x0017EDF1 File Offset: 0x0017D1F1
	// (set) Token: 0x0600878A RID: 34698 RVA: 0x0017EE03 File Offset: 0x0017D203
	public Vector3 avatarPos
	{
		get
		{
			return this.m_AvatarRoot.transform.position;
		}
		set
		{
			if (null != this.m_AvatarRoot)
			{
				this.m_AvatarRoot.transform.position = value;
			}
		}
	}

	// Token: 0x17001827 RID: 6183
	// (get) Token: 0x0600878B RID: 34699 RVA: 0x0017EE27 File Offset: 0x0017D227
	// (set) Token: 0x0600878C RID: 34700 RVA: 0x0017EE39 File Offset: 0x0017D239
	public Quaternion avatarRoation
	{
		get
		{
			return this.m_AvatarRoot.transform.rotation;
		}
		set
		{
			if (null != this.m_AvatarRoot)
			{
				this.m_AvatarRoot.transform.rotation = value;
			}
		}
	}

	// Token: 0x17001828 RID: 6184
	// (get) Token: 0x0600878D RID: 34701 RVA: 0x0017EE5D File Offset: 0x0017D25D
	// (set) Token: 0x0600878E RID: 34702 RVA: 0x0017EE6F File Offset: 0x0017D26F
	public Vector3 avatarScale
	{
		get
		{
			return this.m_AvatarRoot.transform.localScale;
		}
		set
		{
			if (null != this.m_AvatarRoot)
			{
				this.m_AvatarRoot.transform.localScale = value;
			}
		}
	}

	// Token: 0x0600878F RID: 34703 RVA: 0x0017EE94 File Offset: 0x0017D294
	public void OnLoaded(GeAvatar avatar)
	{
		GameObject avatarRoot = avatar.GetAvatarRoot();
		if (null != avatarRoot)
		{
			avatarRoot.transform.SetParent(this.m_AvatarRoot.transform, false);
			avatarRoot.SetActive(true);
			avatar.SetAvatarVisible(true);
			avatar.SetAmbientColor(this.m_AmbientCol);
		}
	}

	// Token: 0x04004129 RID: 16681
	public string m_RenderTexName = "DeftAvatarRend";

	// Token: 0x0400412A RID: 16682
	public Vector3 m_LightRot = default(Vector3);

	// Token: 0x0400412B RID: 16683
	public Color m_LightCol = Color.white;

	// Token: 0x0400412C RID: 16684
	public Color m_AmbientCol = Color.black;

	// Token: 0x0400412D RID: 16685
	public Color m_OriginAmbient = Color.black;

	// Token: 0x0400412E RID: 16686
	public float m_OrthoSize = 1.2f;

	// Token: 0x0400412F RID: 16687
	public Vector3 m_CameraRot = new Vector3(0f, 0f, 0f);

	// Token: 0x04004130 RID: 16688
	public Vector3 m_CameraPos = new Vector3(0f, 1f, -1f);

	// Token: 0x04004131 RID: 16689
	public float m_NearPlane = 0.3f;

	// Token: 0x04004132 RID: 16690
	public float m_FarPlane = 10f;

	// Token: 0x04004133 RID: 16691
	public float m_FOV = 45f;

	// Token: 0x04004134 RID: 16692
	public bool m_IsPersp;

	// Token: 0x04004135 RID: 16693
	public int m_Layer = 12;

	// Token: 0x04004136 RID: 16694
	public int m_TextureWidth = 619;

	// Token: 0x04004137 RID: 16695
	public int m_TextureHight = 817;

	// Token: 0x04004138 RID: 16696
	public string m_AvatarPath = string.Empty;

	// Token: 0x04004139 RID: 16697
	public string m_AvatarName = string.Empty;

	// Token: 0x0400413A RID: 16698
	protected Light m_Light;

	// Token: 0x0400413B RID: 16699
	protected GameObject m_Root;

	// Token: 0x0400413C RID: 16700
	protected Camera m_Camera;

	// Token: 0x0400413D RID: 16701
	protected IGeRenderTexture m_RenderTexture;

	// Token: 0x0400413E RID: 16702
	protected GameObject m_AvatarRoot;

	// Token: 0x0400413F RID: 16703
	protected GeAvatar m_Avatar;

	// Token: 0x04004140 RID: 16704
	protected GeEffectManager m_Effect;

	// Token: 0x04004141 RID: 16705
	protected AssetInst m_ModelDataAsset;

	// Token: 0x04004142 RID: 16706
	protected DModelData m_ModelData;

	// Token: 0x04004143 RID: 16707
	protected float m_CurRotate;

	// Token: 0x04004144 RID: 16708
	protected Color m_LastAmbient = Color.black;

	// Token: 0x04004145 RID: 16709
	private bool m_NeedInitAfterLoad;

	// Token: 0x04004146 RID: 16710
	private static readonly GeAvatarChannel[] avatarChanTbl = new GeAvatarChannel[]
	{
		GeAvatarChannel.Head,
		GeAvatarChannel.UpperPart,
		GeAvatarChannel.LowerPart,
		GeAvatarChannel.Bracelet,
		GeAvatarChannel.Headwear,
		GeAvatarChannel.Wings
	};
}
