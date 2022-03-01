using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02004972 RID: 18802
[Serializable]
public class ETCTouchPad : ETCBase, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x0601B03F RID: 110655 RVA: 0x008506F0 File Offset: 0x0084EAF0
	public ETCTouchPad()
	{
		this.axisX = new ETCAxis("Horizontal");
		this.axisX.speed = 1f;
		this.axisY = new ETCAxis("Vertical");
		this.axisY.speed = 1f;
		this._visible = true;
		this._activated = true;
		this.showPSInspector = true;
		this.showSpriteInspector = false;
		this.showBehaviourInspector = false;
		this.showEventInspector = false;
		this.tmpAxis = Vector2.zero;
		this.isOnDrag = false;
		this.isOnTouch = false;
		this.axisX.unityAxis = "Horizontal";
		this.axisY.unityAxis = "Vertical";
		this.enableKeySimulation = true;
		this.enableKeySimulation = false;
		this.isOut = false;
		this.axisX.axisState = ETCAxis.AxisState.None;
		this.useFixedUpdate = false;
		this.isDPI = false;
	}

	// Token: 0x0601B040 RID: 110656 RVA: 0x008507D5 File Offset: 0x0084EBD5
	protected override void Awake()
	{
		base.Awake();
		this.cachedVisible = this._visible;
		this.cachedImage = base.GetComponent<Image>();
	}

	// Token: 0x0601B041 RID: 110657 RVA: 0x008507F8 File Offset: 0x0084EBF8
	public override void OnEnable()
	{
		base.OnEnable();
		if (!this.cachedVisible)
		{
			this.cachedImage.color = new Color(0f, 0f, 0f, 0f);
		}
		if (this.allowSimulationStandalone && this.enableKeySimulation && !Application.isEditor)
		{
			this.SetVisible(this.visibleOnStandalone);
		}
	}

	// Token: 0x0601B042 RID: 110658 RVA: 0x00850866 File Offset: 0x0084EC66
	public override void Start()
	{
		base.Start();
		this.tmpAxis = Vector2.zero;
		this.OldTmpAxis = Vector2.zero;
		this.axisX.InitAxis();
		this.axisY.InitAxis();
	}

	// Token: 0x0601B043 RID: 110659 RVA: 0x0085089A File Offset: 0x0084EC9A
	protected override void UpdateControlState()
	{
		this.UpdateTouchPad();
	}

	// Token: 0x0601B044 RID: 110660 RVA: 0x008508A2 File Offset: 0x0084ECA2
	protected override void DoActionBeforeEndOfFrame()
	{
		this.axisX.DoGravity();
		this.axisY.DoGravity();
	}

	// Token: 0x0601B045 RID: 110661 RVA: 0x008508BC File Offset: 0x0084ECBC
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.isSwipeIn && this.axisX.axisState == ETCAxis.AxisState.None && this._activated && !this.isOnTouch)
		{
			if (eventData.pointerDrag != null && eventData.pointerDrag != base.gameObject)
			{
				this.previousDargObject = eventData.pointerDrag;
			}
			else if (eventData.pointerPress != null && eventData.pointerPress != base.gameObject)
			{
				this.previousDargObject = eventData.pointerPress;
			}
			eventData.pointerDrag = base.gameObject;
			eventData.pointerPress = base.gameObject;
			this.OnPointerDown(eventData);
		}
	}

	// Token: 0x0601B046 RID: 110662 RVA: 0x00850984 File Offset: 0x0084ED84
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.onMoveStart.Invoke();
		}
	}

	// Token: 0x0601B047 RID: 110663 RVA: 0x008509A4 File Offset: 0x0084EDA4
	public void OnDrag(PointerEventData eventData)
	{
		if (base.activated && !this.isOut && this.pointId == eventData.pointerId)
		{
			this.isOnTouch = true;
			this.isOnDrag = true;
			if (this.isDPI)
			{
				this.tmpAxis = new Vector2(eventData.delta.x / Screen.dpi * 100f, eventData.delta.y / Screen.dpi * 100f);
			}
			else
			{
				this.tmpAxis = new Vector2(eventData.delta.x, eventData.delta.y);
			}
			if (!this.axisX.enable)
			{
				this.tmpAxis.x = 0f;
			}
			if (!this.axisY.enable)
			{
				this.tmpAxis.y = 0f;
			}
		}
	}

	// Token: 0x0601B048 RID: 110664 RVA: 0x00850A9C File Offset: 0x0084EE9C
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._activated && !this.isOnTouch)
		{
			this.axisX.axisState = ETCAxis.AxisState.Down;
			this.tmpAxis = eventData.delta;
			this.isOut = false;
			this.isOnTouch = true;
			this.pointId = eventData.pointerId;
			this.onTouchStart.Invoke();
		}
	}

	// Token: 0x0601B049 RID: 110665 RVA: 0x00850AFC File Offset: 0x0084EEFC
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId)
		{
			this.isOnDrag = false;
			this.isOnTouch = false;
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
			this.onTouchUp.Invoke();
			if (this.previousDargObject)
			{
				ExecuteEvents.Execute<IPointerUpHandler>(this.previousDargObject, eventData, ExecuteEvents.pointerUpHandler);
				this.previousDargObject = null;
			}
			this.pointId = -1;
		}
	}

	// Token: 0x0601B04A RID: 110666 RVA: 0x00850BD2 File Offset: 0x0084EFD2
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.pointId == eventData.pointerId && !this.isSwipeOut)
		{
			this.isOut = true;
			this.OnPointerUp(eventData);
		}
	}

	// Token: 0x0601B04B RID: 110667 RVA: 0x00850C00 File Offset: 0x0084F000
	private void UpdateTouchPad()
	{
		if (this.enableKeySimulation && !this.isOnTouch && this._activated && this._visible)
		{
			this.isOnDrag = false;
			this.tmpAxis = Vector2.zero;
			float axis = Input.GetAxis(this.axisX.unityAxis);
			float axis2 = Input.GetAxis(this.axisY.unityAxis);
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
		this.tmpAxis = Vector2.zero;
	}

	// Token: 0x0601B04C RID: 110668 RVA: 0x00851154 File Offset: 0x0084F554
	protected override void SetVisible(bool forceUnvisible = false)
	{
		if (Application.isPlaying)
		{
			if (!this._visible)
			{
				this.cachedImage.color = new Color(0f, 0f, 0f, 0f);
			}
			else
			{
				this.cachedImage.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	// Token: 0x0601B04D RID: 110669 RVA: 0x008511C4 File Offset: 0x0084F5C4
	protected override void SetActivated()
	{
		if (!this._activated)
		{
			this.isOnDrag = false;
			this.isOnTouch = false;
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

	// Token: 0x04012D74 RID: 77172
	[SerializeField]
	public ETCTouchPad.OnMoveStartHandler onMoveStart;

	// Token: 0x04012D75 RID: 77173
	[SerializeField]
	public ETCTouchPad.OnMoveHandler onMove;

	// Token: 0x04012D76 RID: 77174
	[SerializeField]
	public ETCTouchPad.OnMoveSpeedHandler onMoveSpeed;

	// Token: 0x04012D77 RID: 77175
	[SerializeField]
	public ETCTouchPad.OnMoveEndHandler onMoveEnd;

	// Token: 0x04012D78 RID: 77176
	[SerializeField]
	public ETCTouchPad.OnTouchStartHandler onTouchStart;

	// Token: 0x04012D79 RID: 77177
	[SerializeField]
	public ETCTouchPad.OnTouchUPHandler onTouchUp;

	// Token: 0x04012D7A RID: 77178
	[SerializeField]
	public ETCTouchPad.OnDownUpHandler OnDownUp;

	// Token: 0x04012D7B RID: 77179
	[SerializeField]
	public ETCTouchPad.OnDownDownHandler OnDownDown;

	// Token: 0x04012D7C RID: 77180
	[SerializeField]
	public ETCTouchPad.OnDownLeftHandler OnDownLeft;

	// Token: 0x04012D7D RID: 77181
	[SerializeField]
	public ETCTouchPad.OnDownRightHandler OnDownRight;

	// Token: 0x04012D7E RID: 77182
	[SerializeField]
	public ETCTouchPad.OnDownUpHandler OnPressUp;

	// Token: 0x04012D7F RID: 77183
	[SerializeField]
	public ETCTouchPad.OnDownDownHandler OnPressDown;

	// Token: 0x04012D80 RID: 77184
	[SerializeField]
	public ETCTouchPad.OnDownLeftHandler OnPressLeft;

	// Token: 0x04012D81 RID: 77185
	[SerializeField]
	public ETCTouchPad.OnDownRightHandler OnPressRight;

	// Token: 0x04012D82 RID: 77186
	public ETCAxis axisX;

	// Token: 0x04012D83 RID: 77187
	public ETCAxis axisY;

	// Token: 0x04012D84 RID: 77188
	public bool isDPI;

	// Token: 0x04012D85 RID: 77189
	private Image cachedImage;

	// Token: 0x04012D86 RID: 77190
	private Vector2 tmpAxis;

	// Token: 0x04012D87 RID: 77191
	private Vector2 OldTmpAxis;

	// Token: 0x04012D88 RID: 77192
	private GameObject previousDargObject;

	// Token: 0x04012D89 RID: 77193
	private bool isOut;

	// Token: 0x04012D8A RID: 77194
	private bool isOnTouch;

	// Token: 0x04012D8B RID: 77195
	private bool cachedVisible;

	// Token: 0x02004973 RID: 18803
	[Serializable]
	public class OnMoveStartHandler : UnityEvent
	{
	}

	// Token: 0x02004974 RID: 18804
	[Serializable]
	public class OnMoveHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004975 RID: 18805
	[Serializable]
	public class OnMoveSpeedHandler : UnityEvent<Vector2>
	{
	}

	// Token: 0x02004976 RID: 18806
	[Serializable]
	public class OnMoveEndHandler : UnityEvent
	{
	}

	// Token: 0x02004977 RID: 18807
	[Serializable]
	public class OnTouchStartHandler : UnityEvent
	{
	}

	// Token: 0x02004978 RID: 18808
	[Serializable]
	public class OnTouchUPHandler : UnityEvent
	{
	}

	// Token: 0x02004979 RID: 18809
	[Serializable]
	public class OnDownUpHandler : UnityEvent
	{
	}

	// Token: 0x0200497A RID: 18810
	[Serializable]
	public class OnDownDownHandler : UnityEvent
	{
	}

	// Token: 0x0200497B RID: 18811
	[Serializable]
	public class OnDownLeftHandler : UnityEvent
	{
	}

	// Token: 0x0200497C RID: 18812
	[Serializable]
	public class OnDownRightHandler : UnityEvent
	{
	}

	// Token: 0x0200497D RID: 18813
	[Serializable]
	public class OnPressUpHandler : UnityEvent
	{
	}

	// Token: 0x0200497E RID: 18814
	[Serializable]
	public class OnPressDownHandler : UnityEvent
	{
	}

	// Token: 0x0200497F RID: 18815
	[Serializable]
	public class OnPressLeftHandler : UnityEvent
	{
	}

	// Token: 0x02004980 RID: 18816
	[Serializable]
	public class OnPressRightHandler : UnityEvent
	{
	}
}
