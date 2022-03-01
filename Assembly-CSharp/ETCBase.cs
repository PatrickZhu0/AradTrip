using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200493D RID: 18749
[Serializable]
public abstract class ETCBase : MonoBehaviour
{
	// Token: 0x170022BC RID: 8892
	// (get) Token: 0x0601AF50 RID: 110416 RVA: 0x0084AC5D File Offset: 0x0084905D
	// (set) Token: 0x0601AF51 RID: 110417 RVA: 0x0084AC65 File Offset: 0x00849065
	public ETCBase.RectAnchor anchor
	{
		get
		{
			return this._anchor;
		}
		set
		{
			if (value != this._anchor)
			{
				this._anchor = value;
				this.SetAnchorPosition();
			}
		}
	}

	// Token: 0x170022BD RID: 8893
	// (get) Token: 0x0601AF52 RID: 110418 RVA: 0x0084AC80 File Offset: 0x00849080
	// (set) Token: 0x0601AF53 RID: 110419 RVA: 0x0084AC88 File Offset: 0x00849088
	public Vector2 anchorOffet
	{
		get
		{
			return this._anchorOffet;
		}
		set
		{
			if (value != this._anchorOffet)
			{
				this._anchorOffet = value;
				this.SetAnchorPosition();
			}
		}
	}

	// Token: 0x170022BE RID: 8894
	// (get) Token: 0x0601AF54 RID: 110420 RVA: 0x0084ACA8 File Offset: 0x008490A8
	// (set) Token: 0x0601AF55 RID: 110421 RVA: 0x0084ACB0 File Offset: 0x008490B0
	public bool visible
	{
		get
		{
			return this._visible;
		}
		set
		{
			if (value != this._visible)
			{
				this._visible = value;
				this.SetVisible(true);
			}
		}
	}

	// Token: 0x170022BF RID: 8895
	// (get) Token: 0x0601AF56 RID: 110422 RVA: 0x0084ACCC File Offset: 0x008490CC
	// (set) Token: 0x0601AF57 RID: 110423 RVA: 0x0084ACD4 File Offset: 0x008490D4
	public bool activated
	{
		get
		{
			return this._activated;
		}
		set
		{
			if (value != this._activated)
			{
				this._activated = value;
				this.SetActivated();
			}
		}
	}

	// Token: 0x0601AF58 RID: 110424 RVA: 0x0084ACF0 File Offset: 0x008490F0
	protected virtual void Awake()
	{
		this.cachedRectTransform = (base.transform as RectTransform);
		this.cachedRootCanvas = base.gameObject.GetComponentInParent<Canvas>();
		if (this.cachedRootCanvas != null)
		{
			this.cachedCamera = this.cachedRootCanvas.worldCamera;
		}
		if (!this.allowSimulationStandalone)
		{
			this.enableKeySimulation = false;
		}
		this.visibleAtStart = this._visible;
		this.activatedAtStart = this._activated;
		if (!this.isUnregisterAtDisable)
		{
			ETCInput.instance.RegisterControl(this);
		}
	}

	// Token: 0x0601AF59 RID: 110425 RVA: 0x0084AD84 File Offset: 0x00849184
	public virtual void Start()
	{
		if (this.enableCamera && this.autoLinkTagCam)
		{
			this.cameraTransform = null;
			GameObject gameObject = GameObject.FindGameObjectWithTag(this.autoCamTag);
			if (gameObject)
			{
				this.cameraTransform = gameObject.transform;
			}
		}
	}

	// Token: 0x0601AF5A RID: 110426 RVA: 0x0084ADD1 File Offset: 0x008491D1
	public virtual void OnEnable()
	{
		if (this.isUnregisterAtDisable)
		{
			ETCInput.instance.RegisterControl(this);
		}
		this.visible = this.visibleAtStart;
		this.activated = this.activatedAtStart;
	}

	// Token: 0x0601AF5B RID: 110427 RVA: 0x0084AE04 File Offset: 0x00849204
	private void OnDisable()
	{
		if (ETCInput._instance && this.isUnregisterAtDisable)
		{
			ETCInput.instance.UnRegisterControl(this);
		}
		this.visibleAtStart = this._visible;
		this.activated = this._activated;
		this.visible = false;
		this.activated = false;
	}

	// Token: 0x0601AF5C RID: 110428 RVA: 0x0084AE5C File Offset: 0x0084925C
	public virtual void OnDestroy()
	{
		if (ETCInput._instance)
		{
			ETCInput.instance.UnRegisterControl(this);
		}
	}

	// Token: 0x0601AF5D RID: 110429 RVA: 0x0084AE78 File Offset: 0x00849278
	public virtual void OnTransformParentChanged()
	{
		this.cachedRootCanvas = base.transform.parent.GetComponentInParent<Canvas>();
		if (this.cachedRootCanvas != null)
		{
			this.cachedCamera = this.cachedRootCanvas.worldCamera;
		}
	}

	// Token: 0x0601AF5E RID: 110430 RVA: 0x0084AEB2 File Offset: 0x008492B2
	public virtual void Update()
	{
		if (!this.useFixedUpdate)
		{
			this.UpdateVirtualControl1();
		}
	}

	// Token: 0x0601AF5F RID: 110431 RVA: 0x0084AEC5 File Offset: 0x008492C5
	public virtual void FixedUpdate()
	{
		if (this.useFixedUpdate)
		{
			this.UpdateVirtualControl1();
		}
	}

	// Token: 0x0601AF60 RID: 110432 RVA: 0x0084AED8 File Offset: 0x008492D8
	public virtual void LateUpdate()
	{
		if (this.enableCamera)
		{
			if (this.autoLinkTagCam && this.cameraTransform == null)
			{
				GameObject gameObject = GameObject.FindGameObjectWithTag(this.autoCamTag);
				if (gameObject)
				{
					this.cameraTransform = gameObject.transform;
				}
			}
			ETCBase.CameraMode cameraMode = this.cameraMode;
			if (cameraMode != ETCBase.CameraMode.Follow)
			{
				if (cameraMode == ETCBase.CameraMode.SmoothFollow)
				{
					this.CameraSmoothFollow();
				}
			}
			else
			{
				this.CameraFollow();
			}
		}
		this.UpdateVirtualControl2();
	}

	// Token: 0x0601AF61 RID: 110433 RVA: 0x0084AF64 File Offset: 0x00849364
	protected virtual void UpdateControlState()
	{
	}

	// Token: 0x0601AF62 RID: 110434 RVA: 0x0084AF66 File Offset: 0x00849366
	protected virtual void SetVisible(bool forceUnvisible = true)
	{
	}

	// Token: 0x0601AF63 RID: 110435 RVA: 0x0084AF68 File Offset: 0x00849368
	protected virtual void SetActivated()
	{
	}

	// Token: 0x0601AF64 RID: 110436 RVA: 0x0084AF6C File Offset: 0x0084936C
	public void SetAnchorPosition()
	{
		switch (this._anchor)
		{
		case ETCBase.RectAnchor.BottomLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 0f);
			this.rectTransform().anchorMax = new Vector2(0f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.BottomCenter:
			this.rectTransform().anchorMin = new Vector2(0.5f, 0f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.BottonRight:
			this.rectTransform().anchorMin = new Vector2(1f, 0f);
			this.rectTransform().anchorMax = new Vector2(1f, 0f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, this.rectTransform().sizeDelta.y / 2f + this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.CenterLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.Center:
			this.rectTransform().anchorMin = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.CenterRight:
			this.rectTransform().anchorMin = new Vector2(1f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(1f, 0.5f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopLeft:
			this.rectTransform().anchorMin = new Vector2(0f, 1f);
			this.rectTransform().anchorMax = new Vector2(0f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this.rectTransform().sizeDelta.x / 2f + this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopCenter:
			this.rectTransform().anchorMin = new Vector2(0.5f, 1f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		case ETCBase.RectAnchor.TopRight:
			this.rectTransform().anchorMin = new Vector2(1f, 1f);
			this.rectTransform().anchorMax = new Vector2(1f, 1f);
			this.rectTransform().anchoredPosition = new Vector2(-this.rectTransform().sizeDelta.x / 2f - this._anchorOffet.x, -this.rectTransform().sizeDelta.y / 2f - this._anchorOffet.y);
			break;
		}
	}

	// Token: 0x0601AF65 RID: 110437 RVA: 0x0084B450 File Offset: 0x00849850
	protected GameObject GetFirstUIElement(Vector2 position)
	{
		this.uiEventSystem = EventSystem.current;
		if (!(this.uiEventSystem != null))
		{
			return null;
		}
		this.uiPointerEventData = new PointerEventData(this.uiEventSystem);
		this.uiPointerEventData.position = position;
		this.uiEventSystem.RaycastAll(this.uiPointerEventData, this.uiRaycastResultCache);
		if (this.uiRaycastResultCache.Count > 0)
		{
			return this.uiRaycastResultCache[0].gameObject;
		}
		return null;
	}

	// Token: 0x0601AF66 RID: 110438 RVA: 0x0084B4D8 File Offset: 0x008498D8
	protected void CameraSmoothFollow()
	{
		if (!this.cameraTransform || !this.cameraLookAt)
		{
			return;
		}
		float y = this.cameraLookAt.eulerAngles.y;
		float num = this.cameraLookAt.position.y + this.followHeight;
		float num2 = this.cameraTransform.eulerAngles.y;
		float num3 = this.cameraTransform.position.y;
		num2 = Mathf.LerpAngle(num2, y, this.followRotationDamping * Time.deltaTime);
		num3 = Mathf.Lerp(num3, num, this.followHeightDamping * Time.deltaTime);
		Quaternion quaternion = Quaternion.Euler(0f, num2, 0f);
		Vector3 vector = this.cameraLookAt.position;
		vector -= quaternion * Vector3.forward * this.followDistance;
		vector..ctor(vector.x, num3, vector.z);
		RaycastHit raycastHit;
		if (this.enableWallDetection && Physics.Linecast(new Vector3(this.cameraLookAt.position.x, this.cameraLookAt.position.y + 1f, this.cameraLookAt.position.z), vector, ref raycastHit))
		{
			vector..ctor(raycastHit.point.x, num3, raycastHit.point.z);
		}
		this.cameraTransform.position = vector;
		this.cameraTransform.LookAt(this.cameraLookAt);
	}

	// Token: 0x0601AF67 RID: 110439 RVA: 0x0084B68C File Offset: 0x00849A8C
	protected void CameraFollow()
	{
		if (!this.cameraTransform || !this.cameraLookAt)
		{
			return;
		}
		Vector3 vector = this.followOffset;
		this.cameraTransform.position = this.cameraLookAt.position + vector;
		this.cameraTransform.LookAt(this.cameraLookAt.position);
	}

	// Token: 0x0601AF68 RID: 110440 RVA: 0x0084B6F3 File Offset: 0x00849AF3
	protected void UpdateVirtualControl1()
	{
		this.DoActionBeforeEndOfFrame();
	}

	// Token: 0x0601AF69 RID: 110441 RVA: 0x0084B6FB File Offset: 0x00849AFB
	protected void UpdateVirtualControl2()
	{
		this.UpdateControlState();
	}

	// Token: 0x0601AF6A RID: 110442 RVA: 0x0084B704 File Offset: 0x00849B04
	private IEnumerator UpdateVirtualControl()
	{
		this.DoActionBeforeEndOfFrame();
		yield return Yielders.EndOfFrame;
		yield break;
	}

	// Token: 0x0601AF6B RID: 110443 RVA: 0x0084B71F File Offset: 0x00849B1F
	protected virtual void DoActionBeforeEndOfFrame()
	{
	}

	// Token: 0x04012C8D RID: 76941
	protected RectTransform cachedRectTransform;

	// Token: 0x04012C8E RID: 76942
	protected Canvas cachedRootCanvas;

	// Token: 0x04012C8F RID: 76943
	protected Camera cachedCamera;

	// Token: 0x04012C90 RID: 76944
	public bool isUnregisterAtDisable;

	// Token: 0x04012C91 RID: 76945
	private bool visibleAtStart = true;

	// Token: 0x04012C92 RID: 76946
	private bool activatedAtStart = true;

	// Token: 0x04012C93 RID: 76947
	private bool coroutineStarted;

	// Token: 0x04012C94 RID: 76948
	[SerializeField]
	protected ETCBase.RectAnchor _anchor;

	// Token: 0x04012C95 RID: 76949
	[SerializeField]
	protected Vector2 _anchorOffet;

	// Token: 0x04012C96 RID: 76950
	[SerializeField]
	protected bool _visible;

	// Token: 0x04012C97 RID: 76951
	[SerializeField]
	protected bool _activated;

	// Token: 0x04012C98 RID: 76952
	public bool enableCamera;

	// Token: 0x04012C99 RID: 76953
	public ETCBase.CameraMode cameraMode;

	// Token: 0x04012C9A RID: 76954
	public string camTargetTag = "Player";

	// Token: 0x04012C9B RID: 76955
	public bool autoLinkTagCam = true;

	// Token: 0x04012C9C RID: 76956
	public string autoCamTag = "MainCamera";

	// Token: 0x04012C9D RID: 76957
	public Transform cameraTransform;

	// Token: 0x04012C9E RID: 76958
	public ETCBase.CameraTargetMode cameraTargetMode;

	// Token: 0x04012C9F RID: 76959
	public bool enableWallDetection;

	// Token: 0x04012CA0 RID: 76960
	public LayerMask wallLayer = 0;

	// Token: 0x04012CA1 RID: 76961
	public Transform cameraLookAt;

	// Token: 0x04012CA2 RID: 76962
	protected CharacterController cameraLookAtCC;

	// Token: 0x04012CA3 RID: 76963
	public Vector3 followOffset = new Vector3(0f, 6f, -6f);

	// Token: 0x04012CA4 RID: 76964
	public float followDistance = 10f;

	// Token: 0x04012CA5 RID: 76965
	public float followHeight = 5f;

	// Token: 0x04012CA6 RID: 76966
	public float followRotationDamping = 5f;

	// Token: 0x04012CA7 RID: 76967
	public float followHeightDamping = 5f;

	// Token: 0x04012CA8 RID: 76968
	public int pointId = -1;

	// Token: 0x04012CA9 RID: 76969
	public bool enableKeySimulation;

	// Token: 0x04012CAA RID: 76970
	public bool allowSimulationStandalone;

	// Token: 0x04012CAB RID: 76971
	public bool visibleOnStandalone = true;

	// Token: 0x04012CAC RID: 76972
	public ETCBase.DPadAxis dPadAxisCount;

	// Token: 0x04012CAD RID: 76973
	public bool useFixedUpdate;

	// Token: 0x04012CAE RID: 76974
	private List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();

	// Token: 0x04012CAF RID: 76975
	private PointerEventData uiPointerEventData;

	// Token: 0x04012CB0 RID: 76976
	private EventSystem uiEventSystem;

	// Token: 0x04012CB1 RID: 76977
	public bool isOnDrag;

	// Token: 0x04012CB2 RID: 76978
	public bool isSwipeIn;

	// Token: 0x04012CB3 RID: 76979
	public bool isSwipeOut;

	// Token: 0x04012CB4 RID: 76980
	public bool showPSInspector;

	// Token: 0x04012CB5 RID: 76981
	public bool showSpriteInspector;

	// Token: 0x04012CB6 RID: 76982
	public bool showEventInspector;

	// Token: 0x04012CB7 RID: 76983
	public bool showBehaviourInspector;

	// Token: 0x04012CB8 RID: 76984
	public bool showAxesInspector;

	// Token: 0x04012CB9 RID: 76985
	public bool showTouchEventInspector;

	// Token: 0x04012CBA RID: 76986
	public bool showDownEventInspector;

	// Token: 0x04012CBB RID: 76987
	public bool showPressEventInspector;

	// Token: 0x04012CBC RID: 76988
	public bool showCameraInspector;

	// Token: 0x0200493E RID: 18750
	public enum ControlType
	{
		// Token: 0x04012CBE RID: 76990
		Joystick,
		// Token: 0x04012CBF RID: 76991
		TouchPad,
		// Token: 0x04012CC0 RID: 76992
		DPad,
		// Token: 0x04012CC1 RID: 76993
		Button
	}

	// Token: 0x0200493F RID: 18751
	public enum RectAnchor
	{
		// Token: 0x04012CC3 RID: 76995
		UserDefined,
		// Token: 0x04012CC4 RID: 76996
		BottomLeft,
		// Token: 0x04012CC5 RID: 76997
		BottomCenter,
		// Token: 0x04012CC6 RID: 76998
		BottonRight,
		// Token: 0x04012CC7 RID: 76999
		CenterLeft,
		// Token: 0x04012CC8 RID: 77000
		Center,
		// Token: 0x04012CC9 RID: 77001
		CenterRight,
		// Token: 0x04012CCA RID: 77002
		TopLeft,
		// Token: 0x04012CCB RID: 77003
		TopCenter,
		// Token: 0x04012CCC RID: 77004
		TopRight
	}

	// Token: 0x02004940 RID: 18752
	public enum DPadAxis
	{
		// Token: 0x04012CCE RID: 77006
		Two_Axis,
		// Token: 0x04012CCF RID: 77007
		Four_Axis
	}

	// Token: 0x02004941 RID: 18753
	public enum CameraMode
	{
		// Token: 0x04012CD1 RID: 77009
		Follow,
		// Token: 0x04012CD2 RID: 77010
		SmoothFollow
	}

	// Token: 0x02004942 RID: 18754
	public enum CameraTargetMode
	{
		// Token: 0x04012CD4 RID: 77012
		UserDefined,
		// Token: 0x04012CD5 RID: 77013
		LinkOnTag,
		// Token: 0x04012CD6 RID: 77014
		FromDirectActionAxisX,
		// Token: 0x04012CD7 RID: 77015
		FromDirectActionAxisY
	}
}
