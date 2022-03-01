using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001593 RID: 5523
	[RequireComponent(typeof(Text))]
	public class NumberVirtualInput : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
	{
		// Token: 0x0600D826 RID: 55334 RVA: 0x0036041B File Offset: 0x0035E81B
		private void Start()
		{
			this.iInputCount = 0UL;
			this.bFocus = false;
			this.txtNumber = base.gameObject.GetComponent<Text>();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum2, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600D827 RID: 55335 RVA: 0x00360458 File Offset: 0x0035E858
		private void Update()
		{
			if (this.bFocus && !Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VirtualKeyboardFrame2>(null))
			{
				this.bFocus = false;
			}
			if (this.txtPlaceHolder != null && this.txtNumber != null)
			{
				this.txtPlaceHolder.CustomActive(string.IsNullOrEmpty(this.txtNumber.text));
			}
		}

		// Token: 0x0600D828 RID: 55336 RVA: 0x003604C4 File Offset: 0x0035E8C4
		private void OnDestroy()
		{
			this.iInputCount = 0UL;
			this.txtNumber = null;
			this.bFocus = false;
			this.txtPlaceHolder = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum2, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600D829 RID: 55337 RVA: 0x00360500 File Offset: 0x0035E900
		private void OnChangeNum(UIEvent uiEvent)
		{
			if (this.txtNumber == null)
			{
				return;
			}
			if (this.txtPlaceHolder == null)
			{
				return;
			}
			if (!this.bFocus)
			{
				return;
			}
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			ulong num = 0UL;
			ulong.TryParse(this.txtNumber.text, out num);
			if (changeNumType == ChangeNumType.BackSpace || changeNumType == ChangeNumType.Add)
			{
				this.iInputCount += 1UL;
				if (this.iInputCount == 1UL && this.clearByFirstInput)
				{
					this.txtNumber.SafeSetText(string.Empty);
				}
			}
			else if (changeNumType == ChangeNumType.EnSure)
			{
				this.iInputCount = 0UL;
			}
			if (changeNumType == ChangeNumType.BackSpace)
			{
				if (this.inputMode == NumberVirtualInput.InputMode.STRING)
				{
					if (this.txtNumber.text.Length > 0)
					{
						this.txtNumber.text = this.txtNumber.text.Remove(this.txtNumber.text.Length - 1, 1);
					}
				}
				else if (this.inputMode == NumberVirtualInput.InputMode.NUMBER)
				{
					if (this.txtNumber.text.Length > 0)
					{
						this.txtNumber.text = this.txtNumber.text.Remove(this.txtNumber.text.Length - 1, 1);
					}
					uint num2 = 0U;
					uint.TryParse(this.txtNumber.text, out num2);
					if (num2 <= this.minValue)
					{
						this.txtNumber.text = this.minValue.ToString();
					}
				}
			}
			else if (changeNumType == ChangeNumType.Add)
			{
				int num3 = (int)uiEvent.Param2;
				if (num3 < 0 || num3 > 9)
				{
					Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
					return;
				}
				if (this.inputMode == NumberVirtualInput.InputMode.STRING)
				{
					if ((long)this.txtNumber.text.Length < (long)((ulong)this.maxCount))
					{
						Text text = this.txtNumber;
						text.text += num3.ToString();
					}
				}
				else if (this.inputMode == NumberVirtualInput.InputMode.NUMBER)
				{
					Text text2 = this.txtNumber;
					text2.text += num3.ToString();
					uint num4 = 0U;
					uint.TryParse(this.txtNumber.text, out num4);
					if (num4 >= this.maxValue)
					{
						this.txtNumber.text = this.maxValue.ToString();
					}
					else
					{
						this.txtNumber.text = num4.ToString();
					}
				}
			}
			else if (changeNumType == ChangeNumType.EnSure)
			{
				this.bFocus = false;
			}
			if (this.txtPlaceHolder != null)
			{
				this.txtPlaceHolder.CustomActive(string.IsNullOrEmpty(this.txtNumber.text));
			}
			if (changeNumType == ChangeNumType.Add || changeNumType == ChangeNumType.BackSpace)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VirtualInputNumberChange, null, null, null, null);
			}
			else if (changeNumType == ChangeNumType.EnSure)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VirtualInputEnsure, null, null, null, null);
			}
		}

		// Token: 0x0600D82A RID: 55338 RVA: 0x00360834 File Offset: 0x0035EC34
		public void OnPointerClick(PointerEventData eventData)
		{
			if (this.txtNumber != null && !this.bFocus)
			{
				this.bFocus = true;
				if (this.txtPlaceHolder != null)
				{
					this.txtPlaceHolder.CustomActive(false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame2>(FrameLayer.Middle, this.offsetPos, string.Empty);
			}
		}

		// Token: 0x0600D82B RID: 55339 RVA: 0x0036089D File Offset: 0x0035EC9D
		public void OnPointerDown(PointerEventData eventData)
		{
		}

		// Token: 0x0600D82C RID: 55340 RVA: 0x0036089F File Offset: 0x0035EC9F
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		// Token: 0x0600D82D RID: 55341 RVA: 0x003608A1 File Offset: 0x0035ECA1
		public void SetInputMode(NumberVirtualInput.InputMode mode)
		{
			this.inputMode = mode;
		}

		// Token: 0x0600D82E RID: 55342 RVA: 0x003608AA File Offset: 0x0035ECAA
		public void SetNumberLimit(uint iMin, uint iMax)
		{
			this.minValue = iMin;
			this.maxValue = iMax;
		}

		// Token: 0x0600D82F RID: 55343 RVA: 0x003608BA File Offset: 0x0035ECBA
		public void SetStringLenLimit(uint iMax)
		{
			this.maxCount = iMax;
		}

		// Token: 0x04007EE1 RID: 32481
		private Text txtNumber;

		// Token: 0x04007EE2 RID: 32482
		private bool bFocus;

		// Token: 0x04007EE3 RID: 32483
		[SerializeField]
		private NumberVirtualInput.InputMode inputMode = NumberVirtualInput.InputMode.STRING;

		// Token: 0x04007EE4 RID: 32484
		[SerializeField]
		private Text txtPlaceHolder;

		// Token: 0x04007EE5 RID: 32485
		[SerializeField]
		private uint minValue;

		// Token: 0x04007EE6 RID: 32486
		[SerializeField]
		private uint maxValue = uint.MaxValue;

		// Token: 0x04007EE7 RID: 32487
		[SerializeField]
		private uint maxCount = 10U;

		// Token: 0x04007EE8 RID: 32488
		[SerializeField]
		private Vector3 offsetPos = new Vector3(300f, 60f, 0f);

		// Token: 0x04007EE9 RID: 32489
		[SerializeField]
		private bool clearByFirstInput;

		// Token: 0x04007EEA RID: 32490
		private ulong iInputCount;

		// Token: 0x02001594 RID: 5524
		public enum InputMode
		{
			// Token: 0x04007EEC RID: 32492
			NUMBER,
			// Token: 0x04007EED RID: 32493
			STRING
		}
	}
}
