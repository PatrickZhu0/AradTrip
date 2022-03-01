using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02004950 RID: 18768
public class ETCDPad : ETCBase, IDragHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x0601AF9F RID: 110495 RVA: 0x0084C8DC File Offset: 0x0084ACDC
	public ETCDPad()
	{
		this.axisX = new ETCAxis("Horizontal");
		this.axisY = new ETCAxis("Vertical");
		this._visible = true;
		this._activated = true;
		this.dPadAxisCount = ETCBase.DPadAxis.Two_Axis;
		this.tmpAxis = Vector2.zero;
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
	}

	// Token: 0x0601AFA0 RID: 110496 RVA: 0x0084C98C File Offset: 0x0084AD8C
	public override void Start()
	{
		base.Start();
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.axisX.InitAxis();
		this.axisY.InitAxis();
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x0601AFA1 RID: 110497 RVA: 0x0084C9F7 File Offset: 0x0084ADF7
	protected override void UpdateControlState()
	{
		this.UpdateDPad();
	}

	// Token: 0x0601AFA2 RID: 110498 RVA: 0x0084C9FF File Offset: 0x0084ADFF
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x0601AFA3 RID: 110499 RVA: 0x0084CA18 File Offset: 0x0084AE18
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.onTouchStart.Invoke();
			this.GetTouchDirection(eventData.position, eventData.pressEventCamera);
			this.isOnTouch = true;
			this.isOnDrag = true;
			this.pointId = eventData.pointerId;
		}
	}

	// Token: 0x0601AFA4 RID: 110500 RVA: 0x0084CA72 File Offset: 0x0084AE72
	public void OnDrag(PointerEventData eventData)
	{
		if (this._activated && this.pointId == eventData.pointerId)
		{
			this.isOnTouch = true;
			this.isOnDrag = true;
			this.GetTouchDirection(eventData.position, eventData.pressEventCamera);
		}
	}

	// Token: 0x0601AFA5 RID: 110501 RVA: 0x0084CAB0 File Offset: 0x0084AEB0
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnTouch = false;
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
			if (!this.axisX.isEnertia && !this.axisY.isEnertia)
			{
				this.axisX.ResetAxis();
				this.axisY.ResetAxis();
				this.onMoveEnd.Invoke();
			}
			this.pointId = -1;
			this.onTouchUp.Invoke();
		}
	}

	// Token: 0x0601AFA6 RID: 110502 RVA: 0x0084CB60 File Offset: 0x0084AF60
	private void UpdateDPad()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
			if (axis != 0f)
			{
				this.isOnDrag = true;
				this.tmpAxis = new Vector2(1f * Mathf.Sign(axis), this.tmpAxis.y);
			}
			if (axis2 != 0f)
			{
				this.isOnDrag = true;
				this.tmpAxis = new Vector2(this.tmpAxis.x, 1f * Mathf.Sign(axis2));
			}
		}
		this.OldTmpAxis.x = this.axisX.axisValue;
		this.OldTmpAxis.y = this.axisY.axisValue;
		this.axisX.UpdateAxis(this.tmpAxis.x, this.isOnDrag, ETCBase.ControlType.DPad, true);
		this.axisY.UpdateAxis(this.tmpAxis.y, this.isOnDrag, ETCBase.ControlType.DPad, true);
		if ((this.axisX.axisValue != 0f || this.axisY.axisValue != 0f) && this.OldTmpAxis == Vector2.zero)
		{
			this.onMoveStart.Invoke();
		}
		if (this.axisX.axisValue != 0f || this.axisY.axisValue != 0f)
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
			this.onMove.Invoke(new Vector2(this.axisX.axisValue, this.axisY.axisValue));
			this.onMoveSpeed.Invoke(new Vector2(this.axisX.axisSpeedValue, this.axisY.axisSpeedValue));
		}
		else if (this.axisX.axisValue == 0f && this.axisY.axisValue == 0f && this.OldTmpAxis != Vector2.zero)
		{
			this.onMoveEnd.Invoke();
		}
		float num = 1f;
		if (this.axisX.invertedAxis)
		{
			num = -1f;
		}
		if (this.OldTmpAxis.x == 0f && Mathf.Abs(this.axisX.axisValue) > 0f)
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
		if (this.OldTmpAxis.y == 0f && Mathf.Abs(this.axisY.axisValue) > 0f)
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

	// Token: 0x0601AFA7 RID: 110503 RVA: 0x0084D0F4 File Offset: 0x0084B4F4
	protected override void SetVisible(bool forceUnvisible = false)
	{
		bool visible = this._visible;
		if (!base.visible)
		{
			visible = base.visible;
		}
		base.GetComponent<Image>().enabled = visible;
	}

	// Token: 0x0601AFA8 RID: 110504 RVA: 0x0084D128 File Offset: 0x0084B528
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnTouch = false;
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
			this.OldTmpAxis = Vector2.zero;
			this.axisX.axisState = ETCAxis.AxisState.None;
			this.axisY.axisState = ETCAxis.AxisState.None;
			if (!this.axisX.isEnertia && !this.axisY.isEnertia)
			{
				this.axisX.ResetAxis();
				this.axisY.ResetAxis();
			}
			this.pointId = -1;
		}
	}

	// Token: 0x0601AFA9 RID: 110505 RVA: 0x0084D1BC File Offset: 0x0084B5BC
	private void GetTouchDirection(Vector2 position, Camera cam)
	{
		Vector2 vector;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedRectTransform, position, cam, ref vector);
		Vector2 vector2 = this.rectTransform().sizeDelta / this.buttonSizeCoef;
		this.tmpAxis = Vector2.zero;
		if ((vector.x < -vector2.x / 2f && vector.y > -vector2.y / 2f && vector.y < vector2.y / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.x < -vector2.x / 2f))
		{
			this.tmpAxis.x = -1f;
		}
		if ((vector.x > vector2.x / 2f && vector.y > -vector2.y / 2f && vector.y < vector2.y / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.x > vector2.x / 2f))
		{
			this.tmpAxis.x = 1f;
		}
		if ((vector.y > vector2.y / 2f && vector.x > -vector2.x / 2f && vector.x < vector2.x / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.y > vector2.y / 2f))
		{
			this.tmpAxis.y = 1f;
		}
		if ((vector.y < -vector2.y / 2f && vector.x > -vector2.x / 2f && vector.x < vector2.x / 2f && this.dPadAxisCount == ETCBase.DPadAxis.Two_Axis) || (this.dPadAxisCount == ETCBase.DPadAxis.Four_Axis && vector.y < -vector2.y / 2f))
		{
			this.tmpAxis.y = -1f;
		}
	}

	// Token: 0x04012D16 RID: 77078
	[SerializeField]
	public ETCDPad.OnMoveStartHandler onMoveStart;

	// Token: 0x04012D17 RID: 77079
	[SerializeField]
	public ETCDPad.OnMoveHandler onMove;

	// Token: 0x04012D18 RID: 77080
	[SerializeField]
	public ETCDPad.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x04012D19 RID: 77081
	[SerializeField]
	public ETCDPad.OnMoveEndHandler onMoveEnd;

	// Token: 0x04012D1A RID: 77082
	[SerializeField]
	public ETCDPad.OnTouchStartHandler onTouchStart;

	// Token: 0x04012D1B RID: 77083
	[SerializeField]
	public ETCDPad.OnTouchUPHandler onTouchUp;

	// Token: 0x04012D1C RID: 77084
	[SerializeField]
	public ETCDPad.OnDownUpHandler OnDownUp;

	// Token: 0x04012D1D RID: 77085
	[SerializeField]
	public ETCDPad.OnDownDownHandler OnDownDown;

	// Token: 0x04012D1E RID: 77086
	[SerializeField]
	public ETCDPad.OnDownLeftHandler OnDownLeft;

	// Token: 0x04012D1F RID: 77087
	[SerializeField]
	public ETCDPad.OnDownRightHandler OnDownRight;

	// Token: 0x04012D20 RID: 77088
	[SerializeField]
	public ETCDPad.OnDownUpHandler OnPressUp;

	// Token: 0x04012D21 RID: 77089
	[SerializeField]
	public ETCDPad.OnDownDownHandler OnPressDown;

	// Token: 0x04012D22 RID: 77090
	[SerializeField]
	public ETCDPad.OnDownLeftHandler OnPressLeft;

	// Token: 0x04012D23 RID: 77091
	[SerializeField]
	public ETCDPad.OnDownRightHandler OnPressRight;

	// Token: 0x04012D24 RID: 77092
	public ETCAxis axisX;

	// Token: 0x04012D25 RID: 77093
	public ETCAxis axisY;

	// Token: 0x04012D26 RID: 77094
	public Sprite normalSprite;

	// Token: 0x04012D27 RID: 77095
	public Color normalColor;

	// Token: 0x04012D28 RID: 77096
	public Sprite pressedSprite;

	// Token: 0x04012D29 RID: 77097
	public Color pressedColor;

	// Token: 0x04012D2A RID: 77098
	private Vector2 tmpAxis;

	// Token: 0x04012D2B RID: 77099
	private Vector2 OldTmpAxis;

	// Token: 0x04012D2C RID: 77100
	private bool isOnTouch;

	// Token: 0x04012D2D RID: 77101
	private Image cachedImage;

	// Token: 0x04012D2E RID: 77102
	public float buttonSizeCoef = 3f;

	// Token: 0x02004951 RID: 18769
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x02004952 RID: 18770
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004953 RID: 18771
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004954 RID: 18772
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x02004955 RID: 18773
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x02004956 RID: 18774
	[Serializable]
	public class OnTouchUPHandler : UnityEvent
	{
	}

	// Token: 0x02004957 RID: 18775
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x02004958 RID: 18776
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x02004959 RID: 18777
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x0200495A RID: 18778
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x0200495B RID: 18779
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x0200495C RID: 18780
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x0200495D RID: 18781
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x0200495E RID: 18782
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}
}
