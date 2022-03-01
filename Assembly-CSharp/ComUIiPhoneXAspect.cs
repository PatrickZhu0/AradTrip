using System;
using System.Collections.Generic;
using DG.Tweening;
using GameClient;
using UnityEngine;

// Token: 0x02000067 RID: 103
[ExecuteInEditMode]
public class ComUIiPhoneXAspect : MonoBehaviour
{
	// Token: 0x06000239 RID: 569 RVA: 0x00011B4A File Offset: 0x0000FF4A
	private void Awake()
	{
		this.mScreenType = CameraAspectAdjust.GetScreenType();
		if (!this.IsFullScreenType())
		{
			return;
		}
		this._init();
		this._updatePositionByLandType();
	}

	// Token: 0x0600023A RID: 570 RVA: 0x00011B6F File Offset: 0x0000FF6F
	private void Start()
	{
	}

	// Token: 0x0600023B RID: 571 RVA: 0x00011B74 File Offset: 0x0000FF74
	private void _init()
	{
		this.mRectTransform = base.GetComponent<RectTransform>();
		this.mDotweenAnimation = base.GetComponent<DOTweenAnimation>();
		if (null != this.mRectTransform)
		{
			this.mOriginLocalPostion = this.mRectTransform.anchoredPosition;
		}
		else
		{
			this.mOriginLocalPostion = base.transform.localPosition;
		}
		this.mScreenOrientation = Screen.orientation;
		this.mIsScreenOrientationDirty = false;
	}

	// Token: 0x0600023C RID: 572 RVA: 0x00011BE8 File Offset: 0x0000FFE8
	private void _updatePositionByLandType()
	{
		if (!this.IsFullScreenType())
		{
			return;
		}
		Vector3 vector = Vector3.zero;
		ScreenOrientation screenOrientation = this.mScreenOrientation;
		if (screenOrientation != 3)
		{
			if (screenOrientation != 4)
			{
				vector = this.mOriginLocalPostion;
			}
			else
			{
				vector = this.mOriginLocalPostion + this.GetLandScreenOffsetByScreenType(this.mScreenOrientation);
			}
		}
		else
		{
			vector = this.mOriginLocalPostion + this.GetLandScreenOffsetByScreenType(this.mScreenOrientation);
		}
		if (null != this.mRectTransform)
		{
			this.mRectTransform.anchoredPosition = vector;
		}
		else
		{
			base.transform.localPosition = vector;
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x00011C9C File Offset: 0x0001009C
	private bool IsInScreen(Vector3 pos)
	{
		return pos.x >= 0f && pos.x <= (float)Screen.width && pos.y >= 0f && pos.y <= (float)Screen.height;
	}

	// Token: 0x0600023E RID: 574 RVA: 0x00011CF4 File Offset: 0x000100F4
	private bool IsDotweenAnimationMoving()
	{
		return this.mDotweenAnimation != null && this.mDotweenAnimation.tween != null && TweenExtensions.IsPlaying(this.mDotweenAnimation.tween);
	}

	// Token: 0x0600023F RID: 575 RVA: 0x00011D38 File Offset: 0x00010138
	private void Update()
	{
		if (!this.IsFullScreenType())
		{
			return;
		}
		if (this.IsDotweenAnimationMoving())
		{
			this.mIsScreenOrientationDirty = true;
		}
		if (this.mScreenOrientation != Screen.orientation || this.mIsScreenOrientationDirty)
		{
			Camera uicamera = Singleton<ClientSystemManager>.GetInstance().UICamera;
			if (uicamera != null)
			{
				Vector3 pos = uicamera.WorldToScreenPoint(base.gameObject.transform.position);
				if (!this.IsInScreen(pos) || this.IsDotweenAnimationMoving())
				{
					return;
				}
			}
			this.mScreenOrientation = Screen.orientation;
			this.mIsScreenOrientationDirty = true;
		}
		if (this.mIsScreenOrientationDirty)
		{
			this._updatePositionByLandType();
			this.mIsScreenOrientationDirty = false;
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x00011DF0 File Offset: 0x000101F0
	private bool IsFullScreenType()
	{
		return this.mScreenType == CameraAspectAdjust.eScreenType.R_BangFullScreen_2240_1080 || this.mScreenType == CameraAspectAdjust.eScreenType.R_BangFullScreen_2244_1080 || this.mScreenType == CameraAspectAdjust.eScreenType.R_BangFullScreen_2280_1080 || this.mScreenType == CameraAspectAdjust.eScreenType.R_BangFullScreen_2208_1080 || this.mScreenType == CameraAspectAdjust.eScreenType.R_16_9_2 || this.mScreenType == CameraAspectAdjust.eScreenType.R_iPhoneX_2436_1125;
	}

	// Token: 0x06000241 RID: 577 RVA: 0x00011E4A File Offset: 0x0001024A
	private bool IsiPhoneXScreenType()
	{
		return this.mScreenType == CameraAspectAdjust.eScreenType.R_iPhoneX_2436_1125;
	}

	// Token: 0x06000242 RID: 578 RVA: 0x00011E5C File Offset: 0x0001025C
	private Vector3 GetLandScreenOffsetByScreenType(ScreenOrientation direction)
	{
		if (this.landScreenOffsetList == null)
		{
			return Vector3.zero;
		}
		for (int i = 0; i < this.landScreenOffsetList.Count; i++)
		{
			CameraAspectAdjust.eScreenType screenType = this.landScreenOffsetList[i].screenType;
			if (screenType == CameraAspectAdjust.eScreenType.R_iPhoneX_2436_1125)
			{
				this.landScreenOffsetList[i].bangOffset = Vector3.zero;
				if (direction == 3)
				{
					return this.landScreenOffsetList[i].landLeftOffset + this.landScreenOffsetList[i].bangOffset;
				}
				if (direction == 4)
				{
					return this.landScreenOffsetList[i].landRightOffset + this.landScreenOffsetList[i].bangOffset;
				}
			}
		}
		return Vector3.zero;
	}

	// Token: 0x04000231 RID: 561
	[Header("左横屏-iPhoneX配置刘海的偏移值")]
	public Vector3 landLeftOffset;

	// Token: 0x04000232 RID: 562
	[Header("右横屏-iPhoneX配置刘海的偏移值")]
	public Vector3 landRightOffset;

	// Token: 0x04000233 RID: 563
	[Header("不同分辨率配置刘海偏移的参数")]
	public List<BangFullScreenParam> landScreenOffsetList = new List<BangFullScreenParam>();

	// Token: 0x04000234 RID: 564
	public ScreenOrientation mScreenOrientation;

	// Token: 0x04000235 RID: 565
	private Vector3 mOriginLocalPostion = Vector3.zero;

	// Token: 0x04000236 RID: 566
	private bool mIsScreenOrientationDirty;

	// Token: 0x04000237 RID: 567
	private RectTransform mRectTransform;

	// Token: 0x04000238 RID: 568
	private DOTweenAnimation mDotweenAnimation;

	// Token: 0x04000239 RID: 569
	private CameraAspectAdjust.eScreenType mScreenType;
}
