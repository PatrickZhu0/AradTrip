using System;
using UnityEngine;

// Token: 0x02000D8B RID: 3467
public class GeCamera
{
	// Token: 0x06008C70 RID: 35952 RVA: 0x001A0164 File Offset: 0x0019E564
	public void InitCamera(float orthographicSize, float nearPlane, float farPlane, bool usePersp)
	{
		if (null == this.m_CameraNode)
		{
			this.m_CameraNode = Utility.FindGameObject("Environment/FollowPlayer/Main Camera", true);
			if (this.m_CameraNode)
			{
				this.m_Camera = this.m_CameraNode.GetComponent<Camera>();
				if (!this.m_CameraNode.GetComponent<OnNpcHit>())
				{
					this.m_CameraNode.AddComponent<OnNpcHit>();
				}
			}
			if (Mathf.Abs(this.m_Camera.transform.localPosition.x + this.m_Camera.transform.localPosition.y + this.m_Camera.transform.localPosition.z) > 0.001f)
			{
				this.m_Camera.transform.localPosition = Vector3.zero;
			}
		}
		if (this.m_CameraController == null)
		{
			this.m_CameraController = Utility.FindComponent<GeCameraControllerScroll>("Environment/FollowPlayer", true);
			if (!this.m_CameraController.Init(this))
			{
				Logger.LogError("Init camera controller has failed!");
			}
		}
		this.m_OrthographicSize = MonoSingleton<LeanTween>.instance.cameraOrthoSize;
		this.m_NearPlane = nearPlane;
		this.m_FarPlane = farPlane;
		usePersp = false;
		if (usePersp)
		{
			this.m_Camera.fieldOfView = 10f;
			this.m_Camera.orthographic = false;
			this.m_Camera.orthographicSize = this.m_OrthographicSize;
			this.m_Camera.nearClipPlane = this.m_NearPlane;
			this.m_Camera.farClipPlane = this.m_FarPlane;
		}
		else
		{
			float orthographicSize2 = this.m_OrthographicSize;
			this.m_Camera.orthographicSize = orthographicSize2;
			this.m_Camera.orthographic = true;
			this.m_Camera.nearClipPlane = this.m_NearPlane;
			this.m_Camera.farClipPlane = this.m_FarPlane;
		}
		this.m_ShockEffect.Init(this.m_CameraNode, 2);
	}

	// Token: 0x06008C71 RID: 35953 RVA: 0x001A034F File Offset: 0x0019E74F
	public void Update(int deltaTime)
	{
		if (this.m_ShockEffect != null)
		{
			this.m_ShockEffect.Update((float)deltaTime / 1000f);
		}
		if (this.shockTime > 0)
		{
			this.shockTime -= deltaTime;
		}
	}

	// Token: 0x06008C72 RID: 35954 RVA: 0x001A0389 File Offset: 0x0019E789
	public void PlayShockEffect(float fTime, float fSpeed, float fXRange, float fYRange, int mode = -1, bool openShock = true)
	{
		if (!openShock)
		{
			return;
		}
		if (mode != -1)
		{
			this.m_ShockEffect.SetMode(mode);
		}
		this.m_ShockEffect.Start(fTime, fSpeed, fXRange, fYRange);
	}

	// Token: 0x06008C73 RID: 35955 RVA: 0x001A03B8 File Offset: 0x0019E7B8
	public void PlayShockEffect(float totalTime, int num, float xRange, float yRange, bool decelebrate, float xReduce, float yReduce, int mode, float radius = 1f, bool openShock = true)
	{
		if (!openShock)
		{
			return;
		}
		this.m_ShockEffect.StartShock(totalTime, num, xRange, yRange, decelebrate, xReduce, yReduce, mode, radius);
	}

	// Token: 0x06008C74 RID: 35956 RVA: 0x001A03E7 File Offset: 0x0019E7E7
	public void PlayShockEffect(ShockData shockData)
	{
		this.PlayShockEffect(shockData.time, shockData.speed, shockData.xrange, shockData.yrange, 2, true);
	}

	// Token: 0x06008C75 RID: 35957 RVA: 0x001A040D File Offset: 0x0019E80D
	public int GetPlayerShockEffectMode()
	{
		if (this.m_ShockEffect == null)
		{
			return -1;
		}
		return this.m_ShockEffect.Mode;
	}

	// Token: 0x06008C76 RID: 35958 RVA: 0x001A0427 File Offset: 0x0019E827
	public void SetPlayerShockEffectMode(int mode)
	{
		if (this.m_ShockEffect == null)
		{
			return;
		}
		this.m_ShockEffect.SetMode(mode);
	}

	// Token: 0x06008C77 RID: 35959 RVA: 0x001A0441 File Offset: 0x0019E841
	public GeCameraControllerScroll GetController()
	{
		return this.m_CameraController;
	}

	// Token: 0x06008C78 RID: 35960 RVA: 0x001A0449 File Offset: 0x0019E849
	public void SetLookDir(Vector3 orient)
	{
		this.m_CameraNode.transform.localRotation = Quaternion.Euler(orient);
	}

	// Token: 0x06008C79 RID: 35961 RVA: 0x001A0461 File Offset: 0x0019E861
	public Camera GetCamera()
	{
		return this.m_Camera;
	}

	// Token: 0x06008C7A RID: 35962 RVA: 0x001A046C File Offset: 0x0019E86C
	public void SetCameraDesc(GeCameraDesc desc)
	{
		this.m_NearPlane = desc.NearPlane;
		this.m_FarPlane = desc.FarPlane;
		this.m_Camera.fieldOfView = desc.FOV;
		this.m_Camera.orthographic = desc.IsOrthographic;
		if (desc.IsOrthographic)
		{
			this.m_Camera.orthographicSize = desc.OrthographicSize;
		}
		else
		{
			this.m_Camera.fieldOfView = desc.FOV;
		}
		this.m_Camera.nearClipPlane = this.m_NearPlane;
		this.m_Camera.farClipPlane = this.m_FarPlane;
	}

	// Token: 0x06008C7B RID: 35963 RVA: 0x001A0510 File Offset: 0x0019E910
	public GeCameraDesc GetCameraDesc()
	{
		return new GeCameraDesc
		{
			NearPlane = this.m_Camera.nearClipPlane,
			FarPlane = this.m_Camera.farClipPlane,
			FOV = this.m_Camera.fieldOfView,
			OrthographicSize = this.m_Camera.orthographicSize,
			IsOrthographic = this.m_Camera.orthographic
		};
	}

	// Token: 0x06008C7C RID: 35964 RVA: 0x001A0580 File Offset: 0x0019E980
	public int GetCullingMask()
	{
		return this.m_Camera.cullingMask;
	}

	// Token: 0x06008C7D RID: 35965 RVA: 0x001A058D File Offset: 0x0019E98D
	public void SetCullingMask(int mask)
	{
		this.m_Camera.cullingMask = mask;
	}

	// Token: 0x04004573 RID: 17779
	private GameObject m_CameraNode;

	// Token: 0x04004574 RID: 17780
	private Camera m_Camera;

	// Token: 0x04004575 RID: 17781
	private float m_OrthographicSize = 2f;

	// Token: 0x04004576 RID: 17782
	private float m_NearPlane = 0.1f;

	// Token: 0x04004577 RID: 17783
	private float m_FarPlane = 50f;

	// Token: 0x04004578 RID: 17784
	private GeCameraControllerScroll m_CameraController;

	// Token: 0x04004579 RID: 17785
	private GeShockEffect m_ShockEffect = new GeShockEffect();

	// Token: 0x0400457A RID: 17786
	private int _defaultCullingMask;

	// Token: 0x0400457B RID: 17787
	private GeCameraDesc _defaultDesc;

	// Token: 0x0400457C RID: 17788
	private const float stdRatio = 1.7777778f;

	// Token: 0x0400457D RID: 17789
	private float currentRatio;

	// Token: 0x0400457E RID: 17790
	public int shockTime;
}
