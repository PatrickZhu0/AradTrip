using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	// Token: 0x02000D99 RID: 3481
	[AddComponentMenu("GeUISwitchButton")]
	[RequireComponent(typeof(RectTransform))]
	public class GeUISwitchButton : Selectable, IInitializePotentialDragHandler, ICanvasElement, IEventSystemHandler
	{
		// Token: 0x06008CF3 RID: 36083 RVA: 0x001A2DFA File Offset: 0x001A11FA
		protected GeUISwitchButton()
		{
		}

		// Token: 0x170018AC RID: 6316
		// (get) Token: 0x06008CF4 RID: 36084 RVA: 0x001A2E23 File Offset: 0x001A1223
		// (set) Token: 0x06008CF5 RID: 36085 RVA: 0x001A2E2B File Offset: 0x001A122B
		public RectTransform fillRect
		{
			get
			{
				return this.m_FillRect;
			}
			set
			{
				if (GeUISwitchButton._SetClass<RectTransform>(ref this.m_FillRect, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018AD RID: 6317
		// (get) Token: 0x06008CF6 RID: 36086 RVA: 0x001A2E4A File Offset: 0x001A124A
		// (set) Token: 0x06008CF7 RID: 36087 RVA: 0x001A2E52 File Offset: 0x001A1252
		public RectTransform handleRect
		{
			get
			{
				return this.m_HandleRect;
			}
			set
			{
				if (GeUISwitchButton._SetClass<RectTransform>(ref this.m_HandleRect, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018AE RID: 6318
		// (get) Token: 0x06008CF8 RID: 36088 RVA: 0x001A2E71 File Offset: 0x001A1271
		// (set) Token: 0x06008CF9 RID: 36089 RVA: 0x001A2E79 File Offset: 0x001A1279
		public Text handleText
		{
			get
			{
				return this.m_HandleText;
			}
			set
			{
				if (GeUISwitchButton._SetClass<Text>(ref this.m_HandleText, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018AF RID: 6319
		// (get) Token: 0x06008CFA RID: 36090 RVA: 0x001A2E98 File Offset: 0x001A1298
		// (set) Token: 0x06008CFB RID: 36091 RVA: 0x001A2EA0 File Offset: 0x001A12A0
		public Image handleImage
		{
			get
			{
				return this.m_HandleImage;
			}
			set
			{
				if (GeUISwitchButton._SetClass<Image>(ref this.m_HandleImage, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B0 RID: 6320
		// (get) Token: 0x06008CFC RID: 36092 RVA: 0x001A2EBF File Offset: 0x001A12BF
		// (set) Token: 0x06008CFD RID: 36093 RVA: 0x001A2EC7 File Offset: 0x001A12C7
		public Sprite onImage
		{
			get
			{
				return this.m_OnImage;
			}
			set
			{
				if (GeUISwitchButton._SetClass<Sprite>(ref this.m_OnImage, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B1 RID: 6321
		// (get) Token: 0x06008CFE RID: 36094 RVA: 0x001A2EE6 File Offset: 0x001A12E6
		// (set) Token: 0x06008CFF RID: 36095 RVA: 0x001A2EEE File Offset: 0x001A12EE
		public Sprite offImage
		{
			get
			{
				return this.m_OffImage;
			}
			set
			{
				if (GeUISwitchButton._SetClass<Sprite>(ref this.m_OffImage, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B2 RID: 6322
		// (get) Token: 0x06008D00 RID: 36096 RVA: 0x001A2F0D File Offset: 0x001A130D
		// (set) Token: 0x06008D01 RID: 36097 RVA: 0x001A2F15 File Offset: 0x001A1315
		public string onText
		{
			get
			{
				return this.m_OnText;
			}
			set
			{
				if (GeUISwitchButton._SetClass<string>(ref this.m_OnText, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B3 RID: 6323
		// (get) Token: 0x06008D02 RID: 36098 RVA: 0x001A2F34 File Offset: 0x001A1334
		// (set) Token: 0x06008D03 RID: 36099 RVA: 0x001A2F3C File Offset: 0x001A133C
		public string offText
		{
			get
			{
				return this.m_OffText;
			}
			set
			{
				if (GeUISwitchButton._SetClass<string>(ref this.m_OffText, value))
				{
					this.UpdateCachedReferences();
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B4 RID: 6324
		// (get) Token: 0x06008D04 RID: 36100 RVA: 0x001A2F5B File Offset: 0x001A135B
		// (set) Token: 0x06008D05 RID: 36101 RVA: 0x001A2F63 File Offset: 0x001A1363
		public GeUISwitchButton.Direction direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				if (GeUISwitchButton._SetStruct<GeUISwitchButton.Direction>(ref this.m_Direction, value))
				{
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B5 RID: 6325
		// (get) Token: 0x06008D06 RID: 36102 RVA: 0x001A2F7C File Offset: 0x001A137C
		// (set) Token: 0x06008D07 RID: 36103 RVA: 0x001A2F84 File Offset: 0x001A1384
		public bool wholeNumbers
		{
			get
			{
				return this.m_WholeNumbers;
			}
			set
			{
				if (GeUISwitchButton._SetStruct<bool>(ref this.m_WholeNumbers, value))
				{
					this._Switch(this.m_States, false);
					this.UpdateVisuals();
				}
			}
		}

		// Token: 0x170018B6 RID: 6326
		// (get) Token: 0x06008D08 RID: 36104 RVA: 0x001A2FAA File Offset: 0x001A13AA
		// (set) Token: 0x06008D09 RID: 36105 RVA: 0x001A2FB2 File Offset: 0x001A13B2
		public virtual bool states
		{
			get
			{
				return this.m_States;
			}
			set
			{
				this._Switch(value, true);
			}
		}

		// Token: 0x170018B7 RID: 6327
		// (get) Token: 0x06008D0A RID: 36106 RVA: 0x001A2FBC File Offset: 0x001A13BC
		// (set) Token: 0x06008D0B RID: 36107 RVA: 0x001A2FC4 File Offset: 0x001A13C4
		public GeUISwitchButton.SwitchEvent onValueChanged
		{
			get
			{
				return this.m_OnValueChanged;
			}
			set
			{
				this.m_OnValueChanged = value;
			}
		}

		// Token: 0x06008D0C RID: 36108 RVA: 0x001A2FCD File Offset: 0x001A13CD
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		// Token: 0x06008D0D RID: 36109 RVA: 0x001A2FCF File Offset: 0x001A13CF
		public virtual void LayoutComplete()
		{
		}

		// Token: 0x06008D0E RID: 36110 RVA: 0x001A2FD1 File Offset: 0x001A13D1
		public virtual void GraphicUpdateComplete()
		{
		}

		// Token: 0x06008D0F RID: 36111 RVA: 0x001A2FD3 File Offset: 0x001A13D3
		protected override void OnEnable()
		{
			base.OnEnable();
			this.UpdateCachedReferences();
			this._Switch(this.m_States, true);
			this.UpdateVisuals();
		}

		// Token: 0x06008D10 RID: 36112 RVA: 0x001A2FF4 File Offset: 0x001A13F4
		protected override void OnDisable()
		{
			this.m_Tracker.Clear();
			base.OnDisable();
		}

		// Token: 0x06008D11 RID: 36113 RVA: 0x001A3008 File Offset: 0x001A1408
		protected override void OnDidApplyAnimationProperties()
		{
			this.m_CurValue = this.ClampValue(this.m_CurValue);
			float num = this.m_CurValue;
			if (this.m_FillContainerRect != null)
			{
				if (this.m_FillImage != null && this.m_FillImage.type == 3)
				{
					num = this.m_FillImage.fillAmount;
				}
				else
				{
					num = ((!this.reverseValue) ? this.m_FillRect.anchorMax[(int)this.axis] : (1f - this.m_FillRect.anchorMin[(int)this.axis]));
				}
			}
			else if (this.m_ButtonContainerRect != null)
			{
				num = ((!this.reverseValue) ? this.m_HandleRect.anchorMin[(int)this.axis] : (1f - this.m_HandleRect.anchorMin[(int)this.axis]));
			}
			this.UpdateVisuals();
			if (num != this.m_CurValue)
			{
				this.onValueChanged.Invoke(this.m_States);
			}
		}

		// Token: 0x06008D12 RID: 36114 RVA: 0x001A3140 File Offset: 0x001A1540
		private void UpdateCachedReferences()
		{
			if (this.m_FillRect)
			{
				this.m_FillTransform = this.m_FillRect.transform;
				this.m_FillImage = this.m_FillRect.GetComponent<Image>();
				if (this.m_FillTransform.parent != null)
				{
					this.m_FillContainerRect = this.m_FillTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				this.m_FillContainerRect = null;
				this.m_FillImage = null;
			}
			if (this.m_HandleRect)
			{
				this.m_ButtonTransform = this.m_HandleRect.transform;
				if (this.m_ButtonTransform.parent != null)
				{
					this.m_ButtonContainerRect = this.m_ButtonTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				this.m_ButtonContainerRect = null;
			}
		}

		// Token: 0x06008D13 RID: 36115 RVA: 0x001A3218 File Offset: 0x001A1618
		private float ClampValue(float input)
		{
			return Mathf.Clamp(input, this.m_MinValue, this.m_MaxValue);
		}

		// Token: 0x06008D14 RID: 36116 RVA: 0x001A3239 File Offset: 0x001A1639
		public void Switch()
		{
			this._Switch(!this.m_States, true);
		}

		// Token: 0x06008D15 RID: 36117 RVA: 0x001A324B File Offset: 0x001A164B
		public void SetSwitch(bool isOn)
		{
			this._Switch(isOn, true);
		}

		// Token: 0x06008D16 RID: 36118 RVA: 0x001A3258 File Offset: 0x001A1658
		public void RefreshUI()
		{
			Vector3 localPosition = base.transform.localPosition;
			localPosition.z += 0.01f;
			base.transform.localPosition = localPosition;
			localPosition.z -= 0.01f;
			base.transform.localPosition = localPosition;
			this.UpdateVisuals();
		}

		// Token: 0x06008D17 RID: 36119 RVA: 0x001A32B8 File Offset: 0x001A16B8
		protected virtual void _Switch(bool input, bool sendCallback = true)
		{
			if (this.m_States == input)
			{
				return;
			}
			this.m_States = input;
			if (this.m_States)
			{
				if (null != this.m_HandleImage)
				{
					this.m_HandleImage.sprite = this.m_OnImage;
				}
				if (null != this.m_HandleText)
				{
					this.m_HandleText.text = this.m_OnText;
				}
			}
			else
			{
				if (null != this.m_HandleImage)
				{
					this.m_HandleImage.sprite = this.m_OffImage;
				}
				if (null != this.m_HandleText)
				{
					this.m_HandleText.text = this.m_OffText;
				}
			}
			float value = (!this.m_States) ? 0f : 1f;
			this._SetValue(value);
			if (sendCallback)
			{
				this.m_OnValueChanged.Invoke(input);
			}
		}

		// Token: 0x06008D18 RID: 36120 RVA: 0x001A33A7 File Offset: 0x001A17A7
		protected void _SetValue(float value)
		{
			if (value != this.m_CurValue)
			{
				this.m_CurValue = value;
			}
			this.UpdateVisuals();
		}

		// Token: 0x06008D19 RID: 36121 RVA: 0x001A33C2 File Offset: 0x001A17C2
		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (!this.IsActive())
			{
				return;
			}
			this.UpdateVisuals();
		}

		// Token: 0x170018B8 RID: 6328
		// (get) Token: 0x06008D1A RID: 36122 RVA: 0x001A33DC File Offset: 0x001A17DC
		private GeUISwitchButton.Axis axis
		{
			get
			{
				return (this.m_Direction != GeUISwitchButton.Direction.LeftToRight && this.m_Direction != GeUISwitchButton.Direction.RightToLeft) ? GeUISwitchButton.Axis.Vertical : GeUISwitchButton.Axis.Horizontal;
			}
		}

		// Token: 0x170018B9 RID: 6329
		// (get) Token: 0x06008D1B RID: 36123 RVA: 0x001A33FC File Offset: 0x001A17FC
		private bool reverseValue
		{
			get
			{
				return this.m_Direction == GeUISwitchButton.Direction.RightToLeft || this.m_Direction == GeUISwitchButton.Direction.TopToBottom;
			}
		}

		// Token: 0x06008D1C RID: 36124 RVA: 0x001A3418 File Offset: 0x001A1818
		private void UpdateVisuals()
		{
			this.m_Tracker.Clear();
			if (this.m_FillContainerRect != null)
			{
				this.m_Tracker.Add(this, this.m_FillRect, 3840);
				Vector2 zero = Vector2.zero;
				Vector2 one = Vector2.one;
				if (this.m_FillImage != null && this.m_FillImage.type == 3)
				{
					this.m_FillImage.fillAmount = this.m_CurValue;
				}
				else if (this.reverseValue)
				{
					zero[(int)this.axis] = 1f - this.m_CurValue;
				}
				else
				{
					one[(int)this.axis] = this.m_CurValue;
				}
				this.m_FillRect.anchorMin = zero;
				this.m_FillRect.anchorMax = one;
			}
			if (this.m_ButtonContainerRect != null)
			{
				this.m_Tracker.Add(this, this.m_HandleRect, 3840);
				Vector2 zero2 = Vector2.zero;
				Vector2 one2 = Vector2.one;
				int axis = (int)this.axis;
				float num = (!this.reverseValue) ? this.m_CurValue : (1f - this.m_CurValue);
				one2[(int)this.axis] = num;
				zero2[axis] = num;
				this.m_HandleRect.anchorMin = zero2;
				this.m_HandleRect.anchorMax = one2;
			}
		}

		// Token: 0x06008D1D RID: 36125 RVA: 0x001A3580 File Offset: 0x001A1980
		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			RectTransform rectTransform = this.m_ButtonContainerRect ?? this.m_FillContainerRect;
			if (rectTransform != null && rectTransform.rect.size[(int)this.axis] > 0f)
			{
				Vector2 vector;
				if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, cam, ref vector))
				{
					return;
				}
				vector -= rectTransform.rect.position;
				float num = Mathf.Clamp01((vector - this.m_Offset)[(int)this.axis] / rectTransform.rect.size[(int)this.axis]);
				this.m_CurValue = ((!this.reverseValue) ? num : (1f - num));
			}
		}

		// Token: 0x06008D1E RID: 36126 RVA: 0x001A365F File Offset: 0x001A1A5F
		private bool MayDrag(PointerEventData eventData)
		{
			return this.IsActive() && this.IsInteractable() && eventData.button == 0;
		}

		// Token: 0x06008D1F RID: 36127 RVA: 0x001A3684 File Offset: 0x001A1A84
		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!this.MayDrag(eventData))
			{
				return;
			}
			base.OnPointerDown(eventData);
			this.Switch();
			this.m_Offset = Vector2.zero;
			Vector2 offset;
			if (this.m_ButtonContainerRect != null && RectTransformUtility.RectangleContainsScreenPoint(this.m_HandleRect, eventData.position, eventData.enterEventCamera) && RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_HandleRect, eventData.position, eventData.pressEventCamera, ref offset))
			{
				this.m_Offset = offset;
			}
		}

		// Token: 0x06008D20 RID: 36128 RVA: 0x001A3708 File Offset: 0x001A1B08
		public override Selectable FindSelectableOnLeft()
		{
			if (base.navigation.mode == 3 && this.axis == GeUISwitchButton.Axis.Horizontal)
			{
				return null;
			}
			return base.FindSelectableOnLeft();
		}

		// Token: 0x06008D21 RID: 36129 RVA: 0x001A373C File Offset: 0x001A1B3C
		public override Selectable FindSelectableOnRight()
		{
			if (base.navigation.mode == 3 && this.axis == GeUISwitchButton.Axis.Horizontal)
			{
				return null;
			}
			return base.FindSelectableOnRight();
		}

		// Token: 0x06008D22 RID: 36130 RVA: 0x001A3770 File Offset: 0x001A1B70
		public override Selectable FindSelectableOnUp()
		{
			if (base.navigation.mode == 3 && this.axis == GeUISwitchButton.Axis.Vertical)
			{
				return null;
			}
			return base.FindSelectableOnUp();
		}

		// Token: 0x06008D23 RID: 36131 RVA: 0x001A37A8 File Offset: 0x001A1BA8
		public override Selectable FindSelectableOnDown()
		{
			if (base.navigation.mode == 3 && this.axis == GeUISwitchButton.Axis.Vertical)
			{
				return null;
			}
			return base.FindSelectableOnDown();
		}

		// Token: 0x06008D24 RID: 36132 RVA: 0x001A37DD File Offset: 0x001A1BDD
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		// Token: 0x06008D25 RID: 36133 RVA: 0x001A37E8 File Offset: 0x001A1BE8
		public void SetDirection(GeUISwitchButton.Direction direction, bool includeRectLayouts)
		{
			GeUISwitchButton.Axis axis = this.axis;
			bool reverseValue = this.reverseValue;
			this.direction = direction;
			if (!includeRectLayouts)
			{
				return;
			}
			if (this.axis != axis)
			{
				RectTransformUtility.FlipLayoutAxes(base.transform as RectTransform, true, true);
			}
			if (this.reverseValue != reverseValue)
			{
				RectTransformUtility.FlipLayoutOnAxis(base.transform as RectTransform, (int)this.axis, true, true);
			}
		}

		// Token: 0x06008D26 RID: 36134 RVA: 0x001A3853 File Offset: 0x001A1C53
		protected static bool _SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			if (currentValue.Equals(newValue))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06008D27 RID: 36135 RVA: 0x001A3878 File Offset: 0x001A1C78
		protected static bool _SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return false;
			}
			currentValue = newValue;
			return true;
		}

		// Token: 0x06008D28 RID: 36136 RVA: 0x001A38D1 File Offset: 0x001A1CD1
		Transform ICanvasElement.get_transform()
		{
			return base.transform;
		}

		// Token: 0x06008D29 RID: 36137 RVA: 0x001A38D9 File Offset: 0x001A1CD9
		bool ICanvasElement.IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x040045D0 RID: 17872
		[SerializeField]
		private RectTransform m_FillRect;

		// Token: 0x040045D1 RID: 17873
		[SerializeField]
		private RectTransform m_HandleRect;

		// Token: 0x040045D2 RID: 17874
		[SerializeField]
		private Text m_HandleText;

		// Token: 0x040045D3 RID: 17875
		[SerializeField]
		private Image m_HandleImage;

		// Token: 0x040045D4 RID: 17876
		[Space]
		[SerializeField]
		private Sprite m_OnImage;

		// Token: 0x040045D5 RID: 17877
		[SerializeField]
		private Sprite m_OffImage;

		// Token: 0x040045D6 RID: 17878
		[SerializeField]
		private string m_OnText;

		// Token: 0x040045D7 RID: 17879
		[SerializeField]
		private string m_OffText;

		// Token: 0x040045D8 RID: 17880
		[SerializeField]
		private GeUISwitchButton.Direction m_Direction;

		// Token: 0x040045D9 RID: 17881
		[SerializeField]
		private bool m_WholeNumbers;

		// Token: 0x040045DA RID: 17882
		[SerializeField]
		protected bool m_States;

		// Token: 0x040045DB RID: 17883
		private float m_MinValue;

		// Token: 0x040045DC RID: 17884
		private float m_MaxValue = 1f;

		// Token: 0x040045DD RID: 17885
		[SerializeField]
		private float m_CurValue;

		// Token: 0x040045DE RID: 17886
		[Space]
		[SerializeField]
		private GeUISwitchButton.SwitchEvent m_OnValueChanged = new GeUISwitchButton.SwitchEvent();

		// Token: 0x040045DF RID: 17887
		private Image m_FillImage;

		// Token: 0x040045E0 RID: 17888
		private Transform m_FillTransform;

		// Token: 0x040045E1 RID: 17889
		private RectTransform m_FillContainerRect;

		// Token: 0x040045E2 RID: 17890
		private Transform m_ButtonTransform;

		// Token: 0x040045E3 RID: 17891
		private RectTransform m_ButtonContainerRect;

		// Token: 0x040045E4 RID: 17892
		private Vector2 m_Offset = Vector2.zero;

		// Token: 0x040045E5 RID: 17893
		private DrivenRectTransformTracker m_Tracker;

		// Token: 0x02000D9A RID: 3482
		public enum Direction
		{
			// Token: 0x040045E7 RID: 17895
			LeftToRight,
			// Token: 0x040045E8 RID: 17896
			RightToLeft,
			// Token: 0x040045E9 RID: 17897
			BottomToTop,
			// Token: 0x040045EA RID: 17898
			TopToBottom
		}

		// Token: 0x02000D9B RID: 3483
		[Serializable]
		public class SwitchEvent : UnityEvent<bool>
		{
		}

		// Token: 0x02000D9C RID: 3484
		private enum Axis
		{
			// Token: 0x040045EC RID: 17900
			Horizontal,
			// Token: 0x040045ED RID: 17901
			Vertical
		}
	}
}
