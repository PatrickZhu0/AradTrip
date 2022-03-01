using System;
using UnityEngine;

// Token: 0x02000CC1 RID: 3265
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraAspectAdjust : MonoBehaviour
{
	// Token: 0x06008675 RID: 34421 RVA: 0x00177B67 File Offset: 0x00175F67
	public static void MarkDirty()
	{
		CameraAspectAdjust.mDirtyPublicCount += 1U;
	}

	// Token: 0x06008676 RID: 34422 RVA: 0x00177B75 File Offset: 0x00175F75
	public static int GetScreenHeight()
	{
		return CameraAspectAdjust.mScreenHeight;
	}

	// Token: 0x06008677 RID: 34423 RVA: 0x00177B7C File Offset: 0x00175F7C
	public static int GetScreenWeight()
	{
		return CameraAspectAdjust.mScreenWidth;
	}

	// Token: 0x06008678 RID: 34424 RVA: 0x00177B83 File Offset: 0x00175F83
	public static CameraAspectAdjust.eScreenType GetScreenType()
	{
		return CameraAspectAdjust.mScreenType;
	}

	// Token: 0x06008679 RID: 34425 RVA: 0x00177B8A File Offset: 0x00175F8A
	private void Start()
	{
		this.mCameraObj = base.GetComponent<Camera>();
		this._TryGetDeviceModelName();
		this._onUpdate();
	}

	// Token: 0x0600867A RID: 34426 RVA: 0x00177BA4 File Offset: 0x00175FA4
	private void _onUpdate()
	{
		if ((null != this.mCameraObj && CameraAspectAdjust.mScreenHeight != this.mCameraObj.pixelHeight) || CameraAspectAdjust.mScreenWidth != this.mCameraObj.pixelWidth)
		{
			CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.None;
			Debug.LogFormat("sw {0}, sh{1}, {2}", new object[]
			{
				Screen.width,
				Screen.height,
				base.gameObject.name
			});
			Debug.LogFormat("cw {0}, ch{1}, {2}", new object[]
			{
				this.mCameraObj.pixelWidth,
				this.mCameraObj.pixelHeight,
				base.gameObject.name
			});
			if (Screen.width == Screen.height * 2)
			{
				Rect rect = this.mCameraObj.rect;
				rect.xMin = 0f;
				rect.xMax = 1f;
				rect.yMin = 0f;
				rect.yMax = 1f;
				this.mCameraObj.rect = rect;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_2_1;
			}
			else if (Screen.width * 18 == Screen.height * 37)
			{
				Rect rect2 = this.mCameraObj.rect;
				rect2.xMin = 0f;
				rect2.xMax = 1f;
				rect2.yMin = 0f;
				rect2.yMax = 1f;
				this.mCameraObj.rect = rect2;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_18_5_9;
			}
			else if (Screen.width * 9 == Screen.height * 21)
			{
				Rect rect3 = this.mCameraObj.rect;
				rect3.xMin = 0f;
				rect3.xMax = 1f;
				rect3.yMin = 0f;
				rect3.yMax = 1f;
				this.mCameraObj.rect = rect3;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_21_9;
			}
			else if (Screen.width * 1125 == Screen.height * 2436)
			{
				Rect rect4 = this.mCameraObj.rect;
				rect4.xMin = 0f;
				rect4.xMax = 1f;
				rect4.yMin = 0f;
				rect4.yMax = 1f;
				this.mCameraObj.rect = rect4;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_iPhoneX_2436_1125;
			}
			else if (Screen.width * 27 == Screen.height * 56)
			{
				Rect rect5 = this.mCameraObj.rect;
				rect5.xMin = 0f;
				rect5.xMax = 1f;
				rect5.yMin = 0f;
				rect5.yMax = 1f;
				this.mCameraObj.rect = rect5;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_BangFullScreen_2240_1080;
			}
			else if (Screen.width * 90 == Screen.height * 187)
			{
				Rect rect6 = this.mCameraObj.rect;
				rect6.xMin = 0f;
				rect6.xMax = 1f;
				rect6.yMin = 0f;
				rect6.yMax = 1f;
				this.mCameraObj.rect = rect6;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_BangFullScreen_2244_1080;
			}
			else if (Screen.width * 9 == Screen.height * 19)
			{
				Rect rect7 = this.mCameraObj.rect;
				rect7.xMin = 0f;
				rect7.xMax = 1f;
				rect7.yMin = 0f;
				rect7.yMax = 1f;
				this.mCameraObj.rect = rect7;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_BangFullScreen_2280_1080;
			}
			else if (Screen.width * 45 == Screen.height * 92)
			{
				Rect rect8 = this.mCameraObj.rect;
				rect8.xMin = 0f;
				rect8.xMax = 1f;
				rect8.yMin = 0f;
				rect8.yMax = 1f;
				this.mCameraObj.rect = rect8;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_BangFullScreen_2208_1080;
			}
			else if (Screen.width * 9 > 16 * Screen.height)
			{
				Rect rect9 = this.mCameraObj.rect;
				rect9.xMin = 0f;
				rect9.xMax = 1f;
				rect9.yMin = 0f;
				rect9.yMax = 1f;
				if (this.simulator == CameraAspectAdjust.SimulatorType.NOT_DEFINE)
				{
					this.simulator = ((!Singleton<PluginManager>.instance.IsSimulator()) ? CameraAspectAdjust.SimulatorType.DEVICE : CameraAspectAdjust.SimulatorType.SIMULATOR);
				}
				float num = 2.2f;
				if (this.simulator == CameraAspectAdjust.SimulatorType.SIMULATOR && (float)Screen.width / (float)Screen.height > num)
				{
					float num2 = num * (float)Screen.height;
					rect9.height = 1f;
					rect9.width = num2 / (float)Screen.width;
					rect9.y = 0f;
					rect9.x = ((float)Screen.width - num2) / (float)Screen.width / 2f;
				}
				this.mCameraObj.rect = rect9;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_16_9_2;
			}
			else
			{
				int num3 = (int)((float)Screen.width / 1.7777778f + 0.5f);
				float num4 = ((float)Screen.height - (float)num3) / (float)Screen.height / 2f;
				Rect rect10 = this.mCameraObj.rect;
				rect10.xMin = 0f;
				rect10.xMax = 1f;
				rect10.yMin = num4 - this.mOffsetAdjust / (float)Screen.height;
				rect10.yMax = 1f - num4 + this.mOffsetAdjust / (float)Screen.height;
				this.mCameraObj.rect = rect10;
				CameraAspectAdjust.mScreenHeight = this.mCameraObj.pixelHeight;
				CameraAspectAdjust.mScreenWidth = this.mCameraObj.pixelWidth;
				CameraAspectAdjust.mScreenType = CameraAspectAdjust.eScreenType.R_16_9;
			}
		}
	}

	// Token: 0x0600867B RID: 34427 RVA: 0x0017829F File Offset: 0x0017669F
	private void Update()
	{
		if (this.mDirtyCount != CameraAspectAdjust.mDirtyPublicCount)
		{
			this._onUpdate();
			this.mDirtyCount = CameraAspectAdjust.mDirtyPublicCount;
		}
	}

	// Token: 0x0600867C RID: 34428 RVA: 0x001782C4 File Offset: 0x001766C4
	private void _TryGetDeviceModelName()
	{
		this.sdkDeviceModelName = "DEFAULT";
		try
		{
			string deviceModel = SystemInfo.deviceModel;
			if (!string.IsNullOrEmpty(deviceModel))
			{
				string[] array = deviceModel.Split(new char[]
				{
					' '
				});
				if (array != null && array.Length > 0 && !string.IsNullOrEmpty(array[0]))
				{
					this.sdkDeviceModelName = array[0].ToUpper();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("[SDKInterface] try get device model name failed , device model is {0}, error is {1}", new object[]
			{
				SystemInfo.deviceModel,
				ex.ToString()
			});
			this.sdkDeviceModelName = "DEFAULT";
		}
	}

	// Token: 0x0400405C RID: 16476
	private Camera mCameraObj;

	// Token: 0x0400405D RID: 16477
	public float mOffsetAdjust;

	// Token: 0x0400405E RID: 16478
	private static int mScreenHeight;

	// Token: 0x0400405F RID: 16479
	private static int mScreenWidth;

	// Token: 0x04004060 RID: 16480
	private string sdkDeviceModelName = "DEFAULT";

	// Token: 0x04004061 RID: 16481
	private static CameraAspectAdjust.eScreenType mScreenType;

	// Token: 0x04004062 RID: 16482
	private const float kScreen16_9Rate = 1.7777778f;

	// Token: 0x04004063 RID: 16483
	private const float kScreen9_16Rate = 0.5625f;

	// Token: 0x04004064 RID: 16484
	private const float kDelta = 0.5f;

	// Token: 0x04004065 RID: 16485
	private uint mDirtyCount;

	// Token: 0x04004066 RID: 16486
	private static uint mDirtyPublicCount;

	// Token: 0x04004067 RID: 16487
	private CameraAspectAdjust.SimulatorType simulator;

	// Token: 0x02000CC2 RID: 3266
	public enum eScreenType
	{
		// Token: 0x04004069 RID: 16489
		None,
		// Token: 0x0400406A RID: 16490
		R_16_9,
		// Token: 0x0400406B RID: 16491
		R_2_1,
		// Token: 0x0400406C RID: 16492
		R_18_5_9,
		// Token: 0x0400406D RID: 16493
		R_21_9,
		// Token: 0x0400406E RID: 16494
		R_iPhoneX_2436_1125,
		// Token: 0x0400406F RID: 16495
		R_BangFullScreen_2280_1080,
		// Token: 0x04004070 RID: 16496
		R_BangFullScreen_2240_1080,
		// Token: 0x04004071 RID: 16497
		R_BangFullScreen_2244_1080,
		// Token: 0x04004072 RID: 16498
		R_BangFullScreen_2208_1080,
		// Token: 0x04004073 RID: 16499
		R_16_9_2,
		// Token: 0x04004074 RID: 16500
		R_Other
	}

	// Token: 0x02000CC3 RID: 3267
	private enum SimulatorType
	{
		// Token: 0x04004076 RID: 16502
		NOT_DEFINE,
		// Token: 0x04004077 RID: 16503
		DEVICE,
		// Token: 0x04004078 RID: 16504
		SIMULATOR
	}
}
