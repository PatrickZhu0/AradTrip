using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000FAB RID: 4011
[Serializable]
internal class HGJoyStick : UIBehaviour, IBeginDragHandler, IDragHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
	// Token: 0x06009AA0 RID: 39584 RVA: 0x001DE583 File Offset: 0x001DC983
	public void Awake()
	{
		this.cachedRootCanvas = base.gameObject.GetComponentInParent<Canvas>();
		this.cachedTransform = (base.transform as RectTransform);
		this.customEventData = new CustomPointerEventData(EventSystem.current);
	}

	// Token: 0x06009AA1 RID: 39585 RVA: 0x001DE5B7 File Offset: 0x001DC9B7
	public void OnEnable()
	{
		this.onPointerEnter = false;
		this.timeAcc = 0f;
	}

	// Token: 0x06009AA2 RID: 39586 RVA: 0x001DE5CC File Offset: 0x001DC9CC
	private void Update()
	{
		if (!this.onPointerEnter)
		{
			float deltaTime = Time.deltaTime;
			this.timeAcc += deltaTime;
			if (this.timeAcc >= 0.25f)
			{
				this.onPointerEnter = true;
				if (this.onRelease != null)
				{
					this.onRelease(0, true);
				}
			}
		}
		if (this.onUpdate != null)
		{
			this.onUpdate(1);
		}
	}

	// Token: 0x06009AA3 RID: 39587 RVA: 0x001DE63E File Offset: 0x001DCA3E
	public void OnBeginDrag(PointerEventData data)
	{
	}

	// Token: 0x06009AA4 RID: 39588 RVA: 0x001DE640 File Offset: 0x001DCA40
	public void OnDrag(PointerEventData data)
	{
		this.hasDrag = true;
		Vector2 vector;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedTransform, data.position, data.pressEventCamera, ref vector);
		if (this.thumbTransform != null)
		{
			this.thumbTransform.anchoredPosition = vector;
			Vector2 vector2 = vector - Vector2.zero;
			Vector2 normalized = vector2.normalized;
			this.degree = (int)this.CalculateDegree(normalized);
			if (this.dirIndicator != null)
			{
				this.dirIndicator.localRotation = Quaternion.AngleAxis((float)this.degree, Vector3.forward);
			}
			if (vector2.magnitude > this.radius)
			{
				float magnitude = normalized.magnitude;
				float num = Mathf.Acos(normalized.x / magnitude);
				vector.y = Mathf.Sin(num) * this.radius;
				vector.x = Mathf.Cos(num) * this.radius;
				if (normalized.y < 0f)
				{
					vector.y *= -1f;
				}
				this.thumbTransform.anchoredPosition = vector;
			}
			vector2 = this.thumbTransform.anchoredPosition;
			vector2.x = Mathf.Clamp(vector2.x, -this.radius, this.radius);
			vector2.y = Mathf.Clamp(vector2.y, -this.radius, this.radius);
			int v = (int)(vector2.x / this.radius * (float)GlobalLogic.VALUE_1000);
			int v2 = (int)(vector2.y / this.radius * (float)GlobalLogic.VALUE_1000);
			if (this.onMove != null)
			{
				this.onMove(v, v2, this.degree);
			}
		}
	}

	// Token: 0x06009AA5 RID: 39589 RVA: 0x001DE7FC File Offset: 0x001DCBFC
	public void OnPointerEnter(PointerEventData data)
	{
		this.onPointerEnter = true;
		if (data.pointerPress != null)
		{
			this.customEventData.CopyFrom(data);
			this.customEventData.customData = 1;
			ExecuteEvents.Execute<IPointerUpHandler>(data.pointerPress, this.customEventData, ExecuteEvents.pointerUpHandler);
		}
		data.pointerDrag = base.gameObject;
		data.pointerPress = base.gameObject;
		this.hasDrag = false;
		if (!data.eligibleForClick && this.onRelease != null)
		{
			this.onRelease(0, true);
		}
	}

	// Token: 0x06009AA6 RID: 39590 RVA: 0x001DE892 File Offset: 0x001DCC92
	public void OnPointerDown(PointerEventData data)
	{
	}

	// Token: 0x06009AA7 RID: 39591 RVA: 0x001DE894 File Offset: 0x001DCC94
	public void OnPointerUp(PointerEventData data)
	{
		CustomPointerEventData customPointerEventData = data as CustomPointerEventData;
		if (customPointerEventData != null && customPointerEventData.customData == 1)
		{
			return;
		}
		Vector2 vector;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.cachedTransform, data.position, data.pressEventCamera, ref vector);
		if (this.thumbTransform != null)
		{
			Vector2 vector2 = vector;
			Vector2 normalized = vector2.normalized;
			this.degree = (int)this.CalculateDegree(normalized);
		}
		if (this.canRemoveJoystick)
		{
			this.thumbTransform.anchoredPosition = Vector2.zero;
		}
		if (this.onRelease != null)
		{
			this.onRelease(this.degree, this.hasDrag);
		}
	}

	// Token: 0x06009AA8 RID: 39592 RVA: 0x001DE93C File Offset: 0x001DCD3C
	public short CalculateDegree(Vector2 dir)
	{
		short num = 0;
		float x = dir.x;
		float y = dir.y;
		if (Mathf.Abs(x) > 1E-05f || Mathf.Abs(y) > 1E-05f)
		{
			this.bInMoving = true;
		}
		if (Mathf.Abs(x) > 1E-05f || Mathf.Abs(y) > 1E-05f)
		{
			float num2 = Mathf.Sqrt(x * x + y * y);
			float num3 = Mathf.Acos(x / num2);
			num = (short)(57.29578f * num3);
			if (y < --0f)
			{
				num = 360 - num;
			}
			this.bInMoving = true;
		}
		return num;
	}

	// Token: 0x04005036 RID: 20534
	public RectTransform thumbTransform;

	// Token: 0x04005037 RID: 20535
	public RectTransform dirIndicator;

	// Token: 0x04005038 RID: 20536
	protected RectTransform cachedTransform;

	// Token: 0x04005039 RID: 20537
	protected Canvas cachedRootCanvas;

	// Token: 0x0400503A RID: 20538
	private bool bInMoving;

	// Token: 0x0400503B RID: 20539
	private bool hasDrag;

	// Token: 0x0400503C RID: 20540
	public HGJoyStick.Del2 onMove;

	// Token: 0x0400503D RID: 20541
	public HGJoyStick.Del3 onRelease;

	// Token: 0x0400503E RID: 20542
	public HGJoyStick.Del onUpdate;

	// Token: 0x0400503F RID: 20543
	public float radius = 200f;

	// Token: 0x04005040 RID: 20544
	public bool onPointerEnter;

	// Token: 0x04005041 RID: 20545
	public bool canRemoveJoystick = true;

	// Token: 0x04005042 RID: 20546
	private int degree;

	// Token: 0x04005043 RID: 20547
	private float timeAcc;

	// Token: 0x04005044 RID: 20548
	private CustomPointerEventData customEventData;

	// Token: 0x02000FAC RID: 4012
	// (Invoke) Token: 0x06009AAA RID: 39594
	public delegate void Del(int degree);

	// Token: 0x02000FAD RID: 4013
	// (Invoke) Token: 0x06009AAE RID: 39598
	public delegate void Del3(int degree, bool hasDrag);

	// Token: 0x02000FAE RID: 4014
	// (Invoke) Token: 0x06009AB2 RID: 39602
	public delegate void Del2(int v1, int v2, int degree);
}
