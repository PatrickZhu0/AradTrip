using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02004960 RID: 18784
[Serializable]
public class ETCJoystick : ETCBase, IPointerEnterHandler, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x0601B00E RID: 110606 RVA: 0x0084EDCC File Offset: 0x0084D1CC
	public ETCJoystick()
	{
		this.joystickType = ETCJoystick.JoystickType.Static;
		this.allowJoystickOverTouchPad = false;
		this.radiusBase = ETCJoystick.RadiusBase.Width;
		this.axisX = new ETCAxis("Horizontal");
		this.axisY = new ETCAxis("Vertical");
		this._visible = true;
		this._activated = true;
		this.joystickArea = ETCJoystick.JoystickArea.FullScreen;
		this.isDynamicActif = false;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
		this.isNoReturnThumb = false;
		this.showPSInspector = false;
		this.showAxesInspector = false;
		this.showEventInspector = false;
		this.showSpriteInspector = false;
	}

	// Token: 0x170022C4 RID: 8900
	// (get) Token: 0x0601B00F RID: 110607 RVA: 0x0084EEBC File Offset: 0x0084D2BC
	// (set) Token: 0x0601B010 RID: 110608 RVA: 0x0084EEC4 File Offset: 0x0084D2C4
	public bool IsNoReturnThumb
	{
		get
		{
			return this.isNoReturnThumb;
		}
		set
		{
			this.isNoReturnThumb = value;
		}
	}

	// Token: 0x170022C5 RID: 8901
	// (get) Token: 0x0601B011 RID: 110609 RVA: 0x0084EECD File Offset: 0x0084D2CD
	// (set) Token: 0x0601B012 RID: 110610 RVA: 0x0084EED5 File Offset: 0x0084D2D5
	public bool IsNoOffsetThumb
	{
		get
		{
			return this.isNoOffsetThumb;
		}
		set
		{
			this.isNoOffsetThumb = value;
		}
	}

	// Token: 0x0601B013 RID: 110611 RVA: 0x0084EEDE File Offset: 0x0084D2DE
	private void ResetJoyStick()
	{
		this.cachedRectTransform.anchoredPosition = this.initJoyPosition;
		this.thumbPosition = Vector2.zero;
	}

	// Token: 0x0601B014 RID: 110612 RVA: 0x0084EEFC File Offset: 0x0084D2FC
	protected override void Awake()
	{
		base.Awake();
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			this.rectTransform().anchorMin = new Vector2(0.5f, 0.5f);
			this.rectTransform().anchorMax = new Vector2(0.5f, 0.5f);
		}
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x0601B015 RID: 110613 RVA: 0x0084EF7C File Offset: 0x0084D37C
	public override void Start()
	{
		this.axisX.InitAxis();
		this.axisY.InitAxis();
		if (this.enableCamera)
		{
			this.InitCameraLookAt();
		}
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.noReturnPosition = this.thumb.position;
		this.pointId = -1;
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
		}
		base.Start();
		if (this.enableCamera && this.cameraMode == ETCBase.CameraMode.SmoothFollow && this.cameraTransform && this.cameraLookAt)
		{
			this.cameraTransform.position = this.cameraLookAt.TransformPoint(new Vector3(0f, this.followHeight, -this.followDistance));
			this.cameraTransform.LookAt(this.cameraLookAt);
		}
		if (this.enableCamera && this.cameraMode == ETCBase.CameraMode.Follow && this.cameraTransform && this.cameraLookAt)
		{
			this.cameraTransform.position = this.cameraLookAt.position + this.followOffset;
			this.cameraTransform.LookAt(this.cameraLookAt.position);
		}
		this.initJoyPosition = this.cachedRectTransform.anchoredPosition;
	}

	// Token: 0x0601B016 RID: 110614 RVA: 0x0084F0E7 File Offset: 0x0084D4E7
	public override void Update()
	{
		base.Update();
	}

	// Token: 0x0601B017 RID: 110615 RVA: 0x0084F0EF File Offset: 0x0084D4EF
	public override void LateUpdate()
	{
		if (this.enableCamera && !this.cameraLookAt)
		{
			this.InitCameraLookAt();
		}
		base.LateUpdate();
	}

	// Token: 0x0601B018 RID: 110616 RVA: 0x0084F118 File Offset: 0x0084D518
	private void InitCameraLookAt()
	{
		if (this.cameraTargetMode == ETCBase.CameraTargetMode.FromDirectActionAxisX)
		{
			this.cameraLookAt = this.axisX.directTransform;
		}
		else if (this.cameraTargetMode == ETCBase.CameraTargetMode.FromDirectActionAxisY)
		{
			this.cameraLookAt = this.axisY.directTransform;
			if (this.isTurnAndMove)
			{
				this.cameraLookAt = this.axisX.directTransform;
			}
		}
		else if (this.cameraTargetMode == ETCBase.CameraTargetMode.LinkOnTag)
		{
			GameObject gameObject = GameObject.FindGameObjectWithTag(this.camTargetTag);
			if (gameObject)
			{
				this.cameraLookAt = gameObject.transform;
			}
		}
		if (this.cameraLookAt)
		{
			this.cameraLookAtCC = this.cameraLookAt.GetComponent<CharacterController>();
		}
	}

	// Token: 0x0601B019 RID: 110617 RVA: 0x0084F1D5 File Offset: 0x0084D5D5
	protected override void UpdateControlState()
	{
		this.UpdateJoystick();
	}

	// Token: 0x0601B01A RID: 110618 RVA: 0x0084F1DD File Offset: 0x0084D5DD
	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	// Token: 0x0601B01B RID: 110619 RVA: 0x0084F1E0 File Offset: 0x0084D5E0
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!this.isDynamicActif && this._activated && this.pointId == -1)
		{
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.isDynamicActif = true;
			this.pointId = eventData.pointerId;
			this.needUpdateDynamic = true;
		}
		this.onTouchStart.Invoke();
		this.pointId = eventData.pointerId;
		this.isOnDrag = true;
		if (this.isNoOffsetThumb)
		{
			this.OnDrag(eventData);
		}
	}

	// Token: 0x0601B01C RID: 110620 RVA: 0x0084F271 File Offset: 0x0084D671
	public void OnBeginDrag(PointerEventData eventData)
	{
	}

	// Token: 0x0601B01D RID: 110621 RVA: 0x0084F273 File Offset: 0x0084D673
	private Vector2 _getThumbScreenPosition()
	{
		if (this.cachedCamera != null)
		{
			return RectTransformUtility.WorldToScreenPoint(this.cachedCamera, this.cachedRectTransform.position);
		}
		return this.cachedRectTransform.position;
	}

	// Token: 0x0601B01E RID: 110622 RVA: 0x0084F2AD File Offset: 0x0084D6AD
	private Vector3 _ScreenToWorldPoint(Vector3 pos)
	{
		if (this.cachedCamera != null)
		{
			return this.cachedCamera.ScreenToWorldPoint(pos);
		}
		return pos;
	}

	// Token: 0x0601B01F RID: 110623 RVA: 0x0084F2D0 File Offset: 0x0084D6D0
	private void UpdateThumb()
	{
		float radius = this.GetRadius();
		this.thumbPosition.x = (float)Mathf.FloorToInt(this.thumbPosition.x);
		this.thumbPosition.y = (float)Mathf.FloorToInt(this.thumbPosition.y);
		if (!this.axisX.enable)
		{
			this.thumbPosition.x = 0f;
		}
		if (!this.axisY.enable)
		{
			this.thumbPosition.y = 0f;
		}
		if (this.thumbPosition.magnitude > radius)
		{
			if (!this.isNoReturnThumb)
			{
				this.thumbPosition = this.thumbPosition.normalized * radius;
			}
			else
			{
				this.thumbPosition = this.thumbPosition.normalized * radius;
			}
		}
		this.thumb.anchoredPosition = this.thumbPosition;
	}

	// Token: 0x0601B020 RID: 110624 RVA: 0x0084F3BC File Offset: 0x0084D7BC
	private void UpdateDirection()
	{
		float num = Mathf.Sqrt(this.thumbPosition.x * this.thumbPosition.x + this.thumbPosition.y * this.thumbPosition.y);
		float num2 = Mathf.Acos(this.thumbPosition.x / num);
		short num3 = (short)(57.29578f * num2);
		if (this.thumbPosition.y < --0f)
		{
			num3 = 360 - num3;
		}
		if (Singleton<SettingManager>.instance.GetJoystickDir() == InputManager.JoystickDir.EIGHT_DIR)
		{
			this.direction.localEulerAngles = new Vector3(0f, 0f, (float)(this.GetDirection((int)(num3 - 90)) * 45));
			this.direction.anchoredPosition = this.GetDirPos((int)num3);
		}
		else
		{
			this.direction.localEulerAngles = new Vector3(0f, 0f, (float)(num3 - 90));
			this.direction.anchoredPosition = this.thumbPosition.normalized * 73f;
		}
	}

	// Token: 0x0601B021 RID: 110625 RVA: 0x0084F4C8 File Offset: 0x0084D8C8
	private int GetDirection(int degree)
	{
		degree = ((degree >= 0) ? degree : (360 + degree));
		return (int)InputManager.GetDir8(degree);
	}

	// Token: 0x0601B022 RID: 110626 RVA: 0x0084F4F4 File Offset: 0x0084D8F4
	private Vector2 GetDirPos(int degree)
	{
		switch (this.GetDirection(degree))
		{
		case 0:
			return new Vector2(73f, 0f);
		case 1:
			return new Vector2(51.6f, 51.6f);
		case 2:
			return new Vector2(0f, 73f);
		case 3:
			return new Vector2(-51.6f, 51.6f);
		case 4:
			return new Vector2(-73f, 0f);
		case 5:
			return new Vector2(-51.6f, -51.6f);
		case 6:
			return new Vector2(0f, -73f);
		case 7:
			return new Vector2(51.6f, -51.6f);
		}
		return Vector2.zero;
	}

	// Token: 0x0601B023 RID: 110627 RVA: 0x0084F5C8 File Offset: 0x0084D9C8
	public void OnDrag(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId && this.isOnDrag)
		{
			this.isOnTouch = true;
			this.isDynamicActif = true;
			float radius = this.GetRadius();
			if (!this.isNoReturnThumb)
			{
				this.thumbPosition = (eventData.position - eventData.pressPosition) / this.cachedRootCanvas.rectTransform().localScale.x;
			}
			else
			{
				this.thumbPosition = (eventData.position - this.noReturnPosition) / this.cachedRootCanvas.rectTransform().localScale.x + this.noReturnOffset;
			}
			float num = radius;
			if (this.joystickType == ETCJoystick.JoystickType.Dynamic && this._activated)
			{
				Vector2 anchoredPosition = this.cachedRectTransform.anchoredPosition;
				Vector2 vector;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), eventData.position, this.cachedRootCanvas.worldCamera, ref vector);
				float num2 = Mathf.Clamp(vector.x - anchoredPosition.x, -num, num);
				float num3 = Mathf.Clamp(vector.y - anchoredPosition.y, -num, num);
				anchoredPosition.x = vector.x - num2;
				anchoredPosition.y = vector.y - num3;
				if (anchoredPosition.x > (float)this.maxOffsetX)
				{
					anchoredPosition.x = (float)this.maxOffsetX;
				}
				if (anchoredPosition.y > (float)this.maxOffsetY)
				{
					anchoredPosition.y = (float)this.maxOffsetY;
				}
				this.cachedRectTransform.anchoredPosition = anchoredPosition;
				this.thumbPosition = vector - anchoredPosition;
			}
			else if (this.joystickType == ETCJoystick.JoystickType.Static && this._activated)
			{
				Vector2 anchoredPosition2 = this.cachedRectTransform.anchoredPosition;
				Vector2 vector2;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), eventData.position, this.cachedRootCanvas.worldCamera, ref vector2);
				float num4 = Mathf.Clamp(vector2.x - anchoredPosition2.x, -num, num);
				float num5 = Mathf.Clamp(vector2.y - anchoredPosition2.y, -num, num);
				this.thumbPosition.x = this.thumbPosition.x + num4;
				this.thumbPosition.y = this.thumbPosition.y + num5;
			}
			this.UpdateThumb();
			this.UpdateJoystick();
		}
	}

	// Token: 0x0601B024 RID: 110628 RVA: 0x0084F837 File Offset: 0x0084DC37
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.OnUp(true);
		}
	}

	// Token: 0x0601B025 RID: 110629 RVA: 0x0084F854 File Offset: 0x0084DC54
	private void OnUp(bool real = true)
	{
		if (!this.isDynamicActif && this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			return;
		}
		this.isOnDrag = false;
		this.isOnTouch = false;
		if (this.isNoReturnThumb)
		{
			this.noReturnPosition = this.thumb.position;
			this.noReturnOffset = this.thumbPosition;
		}
		if (!this.isNoReturnThumb)
		{
			this.thumbPosition = Vector2.zero;
			this.thumb.anchoredPosition = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
		}
		if (!this.axisX.isEnertia && !this.axisY.isEnertia)
		{
			this.axisX.ResetAxis();
			this.axisY.ResetAxis();
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			if (real)
			{
				this.onMoveEnd.Invoke();
			}
		}
		if (this.joystickType == ETCJoystick.JoystickType.Dynamic)
		{
			real = this.isDynamicActif;
			base.visible = true;
			this.isDynamicActif = false;
			this.ResetJoyStick();
		}
		this.pointId = -1;
		if (real)
		{
			this.onTouchUp.Invoke();
		}
	}

	// Token: 0x0601B026 RID: 110630 RVA: 0x0084F98D File Offset: 0x0084DD8D
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x0601B027 RID: 110631 RVA: 0x0084F9A8 File Offset: 0x0084DDA8
	private void UpdateJoystick()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
			if (!this.isNoReturnThumb)
			{
				this.thumb.localPosition = Vector2.zero;
			}
			this.isOnDrag = false;
			if (axis != 0f)
			{
				this.isOnDrag = true;
				this.m_ThumbXLocalPosition.x = this.GetRadius() * axis;
				this.m_ThumbXLocalPosition.y = this.thumb.localPosition.y;
				this.thumb.localPosition = this.m_ThumbXLocalPosition;
			}
			if (axis2 != 0f)
			{
				this.isOnDrag = true;
				this.m_ThumbYLocalPosition.x = this.thumb.localPosition.x;
				this.m_ThumbYLocalPosition.y = this.GetRadius() * axis2;
				this.thumb.localPosition = this.m_ThumbYLocalPosition;
			}
			this.thumbPosition = this.thumb.localPosition;
		}
		this.OldTmpAxis.x = this.axisX.axisValue;
		this.OldTmpAxis.y = this.axisY.axisValue;
		this.tmpAxis = this.thumbPosition / this.GetRadius();
		this.axisX.UpdateAxis(this.tmpAxis.x, this.isOnDrag, ETCBase.ControlType.Joystick, true);
		this.axisY.UpdateAxis(this.tmpAxis.y, this.isOnDrag, ETCBase.ControlType.Joystick, true);
		if ((this.axisX.axisValue != 0f || this.axisY.axisValue != 0f) && this.OldTmpAxis == Vector2.zero)
		{
			this.onMoveStart.Invoke();
		}
		if (this.axisX.axisValue != 0f || this.axisY.axisValue != 0f)
		{
			if (!this.isTurnAndMove)
			{
				if (this.axisX.actionOn == ETCAxis.ActionOn.Down && (this.axisX.axisState == ETCAxis.AxisState.DownLeft || this.axisX.axisState == ETCAxis.AxisState.DownRight))
				{
					this.axisX.DoDirectAction();
				}
				else if (this.axisX.actionOn == ETCAxis.ActionOn.Press)
				{
					this.axisX.DoDirectAction();
				}
				if (this.axisY.actionOn == ETCAxis.ActionOn.Down && (this.axisY.axisState == ETCAxis.AxisState.DownUp || this.axisY.axisState == ETCAxis.AxisState.DownDown))
				{
					this.axisY.DoDirectAction();
				}
				else if (this.axisY.actionOn == ETCAxis.ActionOn.Press)
				{
					this.axisY.DoDirectAction();
				}
			}
			else
			{
				this.DoTurnAndMove();
			}
			this.onMove.Invoke(new Vector2(this.axisX.axisValue, this.axisY.axisValue));
			this.onMoveSpeed.Invoke(new Vector2(this.axisX.axisSpeedValue, this.axisY.axisSpeedValue));
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.OldTmpAxis != Vector2.zero)
		{
			this.onMoveEnd.Invoke();
		}
		if (!this.isTurnAndMove)
		{
			if (this.axisX.axisValue == 0f && this.axisX.directCharacterController && !this.axisX.directCharacterController.isGrounded && this.axisX.isLockinJump)
			{
				this.axisX.DoDirectAction();
			}
			if (this.axisY.axisValue == 0f && this.axisY.directCharacterController && !this.axisY.directCharacterController.isGrounded && this.axisY.isLockinJump)
			{
				this.axisY.DoDirectAction();
			}
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.axisX.directCharacterController && !this.axisX.directCharacterController.isGrounded && this.tmLockInJump)
		{
			this.DoTurnAndMove();
		}
		float num = 1f;
		if (this.axisX.invertedAxis)
		{
			num = -1f;
		}
		if (Mathf.Abs(this.OldTmpAxis.x) < this.axisX.axisThreshold && Mathf.Abs(this.axisX.axisValue) >= this.axisX.axisThreshold)
		{
			if (this.axisX.axisValue * num > 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.DownRight;
				this.OnDownRight.Invoke();
			}
			else if (this.axisX.axisValue * num < 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.DownLeft;
				this.OnDownLeft.Invoke();
			}
			else
			{
				this.axisX.axisState = ETCAxis.AxisState.None;
			}
		}
		else if (this.axisX.axisState != ETCAxis.AxisState.None)
		{
			if (this.axisX.axisValue * num > 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.PressRight;
				this.OnPressRight.Invoke();
			}
			else if (this.axisX.axisValue * num < 0f)
			{
				this.axisX.axisState = ETCAxis.AxisState.PressLeft;
				this.OnPressLeft.Invoke();
			}
			else
			{
				this.axisX.axisState = ETCAxis.AxisState.None;
			}
		}
		num = 1f;
		if (this.axisY.invertedAxis)
		{
			num = -1f;
		}
		if (Mathf.Abs(this.OldTmpAxis.y) < this.axisY.axisThreshold && Mathf.Abs(this.axisY.axisValue) >= this.axisY.axisThreshold)
		{
			if (this.axisY.axisValue * num > 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.DownUp;
				this.OnDownUp.Invoke();
			}
			else if (this.axisY.axisValue * num < 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.DownDown;
				this.OnDownDown.Invoke();
			}
			else
			{
				this.axisY.axisState = ETCAxis.AxisState.None;
			}
		}
		else if (this.axisY.axisState != ETCAxis.AxisState.None)
		{
			if (this.axisY.axisValue * num > 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.PressUp;
				this.OnPressUp.Invoke();
			}
			else if (this.axisY.axisValue * num < 0f)
			{
				this.axisY.axisState = ETCAxis.AxisState.PressDown;
				this.OnPressDown.Invoke();
			}
			else
			{
				this.axisY.axisState = ETCAxis.AxisState.None;
			}
		}
	}

	// Token: 0x0601B028 RID: 110632 RVA: 0x00850134 File Offset: 0x0084E534
	private bool isTouchOverJoystickArea(ref Vector2 localPosition, ref Vector2 screenPosition)
	{
		bool flag = false;
		bool flag2 = false;
		screenPosition = Vector2.zero;
		int touchCount = this.GetTouchCount();
		int num = 0;
		while (num < touchCount && !flag)
		{
			if (Input.GetTouch(num).phase == null)
			{
				screenPosition = Input.GetTouch(num).position;
				flag2 = true;
			}
			screenPosition = this._ScreenToWorldPoint(screenPosition);
			if (flag2 && this.isScreenPointOverArea(screenPosition, ref localPosition))
			{
				flag = true;
			}
			num++;
		}
		return flag;
	}

	// Token: 0x0601B029 RID: 110633 RVA: 0x008501D4 File Offset: 0x0084E5D4
	private bool isScreenPointOverArea(Vector2 screenPosition, ref Vector2 localPosition)
	{
		bool result = false;
		if (this.joystickArea != ETCJoystick.JoystickArea.UserDefined)
		{
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), screenPosition, null, ref localPosition))
			{
				switch (this.joystickArea)
				{
				case ETCJoystick.JoystickArea.FullScreen:
					result = true;
					break;
				case ETCJoystick.JoystickArea.Left:
					if (localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Right:
					if (localPosition.x > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Top:
					if (localPosition.y > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.Bottom:
					if (localPosition.y < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.TopLeft:
					if (localPosition.y > 0f && localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.TopRight:
					if (localPosition.y > 0f && localPosition.x > 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.BottomLeft:
					if (localPosition.y < 0f && localPosition.x < 0f)
					{
						result = true;
					}
					break;
				case ETCJoystick.JoystickArea.BottomRight:
					if (localPosition.y < 0f && localPosition.x > 0f)
					{
						result = true;
					}
					break;
				}
			}
		}
		else if (RectTransformUtility.RectangleContainsScreenPoint(this.userArea, screenPosition, this.cachedRootCanvas.worldCamera))
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRootCanvas.rectTransform(), screenPosition, this.cachedRootCanvas.worldCamera, ref localPosition);
			result = true;
		}
		return result;
	}

	// Token: 0x0601B02A RID: 110634 RVA: 0x0085037F File Offset: 0x0084E77F
	private int GetTouchCount()
	{
		return Input.touchCount;
	}

	// Token: 0x0601B02B RID: 110635 RVA: 0x00850388 File Offset: 0x0084E788
	public float GetRadius()
	{
		float result = 0f;
		ETCJoystick.RadiusBase radiusBase = this.radiusBase;
		if (radiusBase != ETCJoystick.RadiusBase.Width)
		{
			if (radiusBase != ETCJoystick.RadiusBase.Height)
			{
				if (radiusBase == ETCJoystick.RadiusBase.UserDefined)
				{
					result = this.radiusBaseValue;
				}
			}
			else
			{
				result = this.cachedRectTransform.sizeDelta.y * 0.5f;
			}
		}
		else
		{
			result = this.cachedRectTransform.sizeDelta.x * 0.5f;
		}
		return result;
	}

	// Token: 0x0601B02C RID: 110636 RVA: 0x00850406 File Offset: 0x0084E806
	protected override void SetActivated()
	{
		base.GetComponent<CanvasGroup>().blocksRaycasts = this._activated;
		if (!this._activated)
		{
			this.OnUp(false);
		}
	}

	// Token: 0x0601B02D RID: 110637 RVA: 0x0085042C File Offset: 0x0084E82C
	protected override void SetVisible(bool visible = true)
	{
		bool enabled = this._visible;
		if (!visible)
		{
			enabled = visible;
		}
		Image component = base.GetComponent<Image>();
		if (component != null)
		{
			component.enabled = enabled;
		}
		if (this.thumb != null)
		{
			component = this.thumb.GetComponent<Image>();
			if (component != null)
			{
				component.enabled = enabled;
			}
		}
		CanvasGroup component2 = base.GetComponent<CanvasGroup>();
		if (component2 != null)
		{
			component2.blocksRaycasts = this._activated;
		}
	}

	// Token: 0x0601B02E RID: 110638 RVA: 0x008504B4 File Offset: 0x0084E8B4
	private void DoTurnAndMove()
	{
		float num = Mathf.Atan2(this.axisX.axisValue, this.axisY.axisValue) * 57.29578f;
		AnimationCurve animationCurve = this.tmMoveCurve;
		Vector2 vector;
		vector..ctor(this.axisX.axisValue, this.axisY.axisValue);
		float num2 = animationCurve.Evaluate(vector.magnitude) * this.tmSpeed;
		if (this.axisX.directTransform != null)
		{
			this.axisX.directTransform.rotation = Quaternion.Euler(new Vector3(0f, num + this.tmAdditionnalRotation, 0f));
			if (this.axisX.directCharacterController != null)
			{
				if (this.axisX.directCharacterController.isGrounded || !this.tmLockInJump)
				{
					Vector3 vector2 = this.axisX.directCharacterController.transform.TransformDirection(Vector3.forward) * num2;
					this.axisX.directCharacterController.Move(vector2 * Time.deltaTime);
					this.tmLastMove = vector2;
				}
				else
				{
					this.axisX.directCharacterController.Move(this.tmLastMove * Time.deltaTime);
				}
			}
			else
			{
				this.axisX.directTransform.Translate(Vector3.forward * num2 * Time.deltaTime, 1);
			}
		}
	}

	// Token: 0x0601B02F RID: 110639 RVA: 0x00850627 File Offset: 0x0084EA27
	public void InitCurve()
	{
		this.axisX.InitDeadCurve();
		this.axisY.InitDeadCurve();
		this.InitTurnMoveCurve();
	}

	// Token: 0x0601B030 RID: 110640 RVA: 0x00850645 File Offset: 0x0084EA45
	public void InitTurnMoveCurve()
	{
		this.tmMoveCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		this.tmMoveCurve.postWrapMode = 4;
		this.tmMoveCurve.preWrapMode = 4;
	}

	// Token: 0x04012D34 RID: 77108
	[SerializeField]
	public ETCJoystick.OnMoveStartHandler onMoveStart;

	// Token: 0x04012D35 RID: 77109
	[SerializeField]
	public ETCJoystick.OnMoveHandler onMove;

	// Token: 0x04012D36 RID: 77110
	[SerializeField]
	public ETCJoystick.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x04012D37 RID: 77111
	[SerializeField]
	public ETCJoystick.OnMoveEndHandler onMoveEnd;

	// Token: 0x04012D38 RID: 77112
	[SerializeField]
	public ETCJoystick.OnTouchStartHandler onTouchStart;

	// Token: 0x04012D39 RID: 77113
	[SerializeField]
	public ETCJoystick.OnTouchUpHandler onTouchUp;

	// Token: 0x04012D3A RID: 77114
	[SerializeField]
	public ETCJoystick.OnDownUpHandler OnDownUp;

	// Token: 0x04012D3B RID: 77115
	[SerializeField]
	public ETCJoystick.OnDownDownHandler OnDownDown;

	// Token: 0x04012D3C RID: 77116
	[SerializeField]
	public ETCJoystick.OnDownLeftHandler OnDownLeft;

	// Token: 0x04012D3D RID: 77117
	[SerializeField]
	public ETCJoystick.OnDownRightHandler OnDownRight;

	// Token: 0x04012D3E RID: 77118
	[SerializeField]
	public ETCJoystick.OnDownUpHandler OnPressUp;

	// Token: 0x04012D3F RID: 77119
	[SerializeField]
	public ETCJoystick.OnDownDownHandler OnPressDown;

	// Token: 0x04012D40 RID: 77120
	[SerializeField]
	public ETCJoystick.OnDownLeftHandler OnPressLeft;

	// Token: 0x04012D41 RID: 77121
	[SerializeField]
	public ETCJoystick.OnDownRightHandler OnPressRight;

	// Token: 0x04012D42 RID: 77122
	public ETCJoystick.JoystickType joystickType;

	// Token: 0x04012D43 RID: 77123
	public bool allowJoystickOverTouchPad;

	// Token: 0x04012D44 RID: 77124
	public ETCJoystick.RadiusBase radiusBase;

	// Token: 0x04012D45 RID: 77125
	public float radiusBaseValue;

	// Token: 0x04012D46 RID: 77126
	public ETCAxis axisX;

	// Token: 0x04012D47 RID: 77127
	public ETCAxis axisY;

	// Token: 0x04012D48 RID: 77128
	public RectTransform thumb;

	// Token: 0x04012D49 RID: 77129
	public RectTransform direction;

	// Token: 0x04012D4A RID: 77130
	public ETCJoystick.JoystickArea joystickArea;

	// Token: 0x04012D4B RID: 77131
	public RectTransform userArea;

	// Token: 0x04012D4C RID: 77132
	public GameObject dirObj;

	// Token: 0x04012D4D RID: 77133
	public bool isTurnAndMove;

	// Token: 0x04012D4E RID: 77134
	public float tmSpeed = 10f;

	// Token: 0x04012D4F RID: 77135
	public float tmAdditionnalRotation;

	// Token: 0x04012D50 RID: 77136
	public AnimationCurve tmMoveCurve;

	// Token: 0x04012D51 RID: 77137
	public bool tmLockInJump;

	// Token: 0x04012D52 RID: 77138
	private Vector3 tmLastMove;

	// Token: 0x04012D53 RID: 77139
	public int maxOffsetX = -200;

	// Token: 0x04012D54 RID: 77140
	public int maxOffsetY = -100;

	// Token: 0x04012D55 RID: 77141
	private Vector2 thumbPosition;

	// Token: 0x04012D56 RID: 77142
	private bool isDynamicActif;

	// Token: 0x04012D57 RID: 77143
	private bool needUpdateDynamic;

	// Token: 0x04012D58 RID: 77144
	private Vector2 tmpAxis;

	// Token: 0x04012D59 RID: 77145
	private Vector2 OldTmpAxis;

	// Token: 0x04012D5A RID: 77146
	private bool isOnTouch;

	// Token: 0x04012D5B RID: 77147
	[SerializeField]
	private bool isNoReturnThumb;

	// Token: 0x04012D5C RID: 77148
	private Vector2 noReturnPosition;

	// Token: 0x04012D5D RID: 77149
	private Vector2 noReturnOffset;

	// Token: 0x04012D5E RID: 77150
	private Vector2 initJoyPosition;

	// Token: 0x04012D5F RID: 77151
	[SerializeField]
	private bool isNoOffsetThumb;

	// Token: 0x04012D60 RID: 77152
	private Vector2 m_ThumbXLocalPosition = Vector2.zero;

	// Token: 0x04012D61 RID: 77153
	private Vector2 m_ThumbYLocalPosition = Vector2.zero;

	// Token: 0x02004961 RID: 18785
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x02004962 RID: 18786
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004963 RID: 18787
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004964 RID: 18788
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x02004965 RID: 18789
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x02004966 RID: 18790
	[Serializable]
	public class OnTouchUpHandler : UnityEvent
	{
	}

	// Token: 0x02004967 RID: 18791
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x02004968 RID: 18792
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x02004969 RID: 18793
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x0200496A RID: 18794
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x0200496B RID: 18795
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x0200496C RID: 18796
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x0200496D RID: 18797
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x0200496E RID: 18798
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}

	// Token: 0x0200496F RID: 18799
	public enum JoystickArea
	{
		// Token: 0x04012D63 RID: 77155
		UserDefined,
		// Token: 0x04012D64 RID: 77156
		FullScreen,
		// Token: 0x04012D65 RID: 77157
		Left,
		// Token: 0x04012D66 RID: 77158
		Right,
		// Token: 0x04012D67 RID: 77159
		Top,
		// Token: 0x04012D68 RID: 77160
		Bottom,
		// Token: 0x04012D69 RID: 77161
		TopLeft,
		// Token: 0x04012D6A RID: 77162
		TopRight,
		// Token: 0x04012D6B RID: 77163
		BottomLeft,
		// Token: 0x04012D6C RID: 77164
		BottomRight
	}

	// Token: 0x02004970 RID: 18800
	public enum JoystickType
	{
		// Token: 0x04012D6E RID: 77166
		Dynamic,
		// Token: 0x04012D6F RID: 77167
		Static
	}

	// Token: 0x02004971 RID: 18801
	public enum RadiusBase
	{
		// Token: 0x04012D71 RID: 77169
		Width,
		// Token: 0x04012D72 RID: 77170
		Height,
		// Token: 0x04012D73 RID: 77171
		UserDefined
	}
}
