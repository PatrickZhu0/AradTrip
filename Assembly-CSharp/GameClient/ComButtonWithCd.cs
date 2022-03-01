using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E76 RID: 3702
	public class ComButtonWithCd : MonoBehaviour
	{
		// Token: 0x060092CC RID: 37580 RVA: 0x001B451C File Offset: 0x001B291C
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x060092CD RID: 37581 RVA: 0x001B4524 File Offset: 0x001B2924
		private void BindEvents()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
			}
		}

		// Token: 0x060092CE RID: 37582 RVA: 0x001B4563 File Offset: 0x001B2963
		private void OnDestroy()
		{
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x060092CF RID: 37583 RVA: 0x001B4571 File Offset: 0x001B2971
		private void UnBindEvents()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x060092D0 RID: 37584 RVA: 0x001B4594 File Offset: 0x001B2994
		public void SetButtonListener(Action onClick)
		{
			this._onButtonClickAction = onClick;
		}

		// Token: 0x060092D1 RID: 37585 RVA: 0x001B459D File Offset: 0x001B299D
		public void ResetListener()
		{
			this._onButtonClickAction = null;
			this._onReturnButtonClickAction = null;
		}

		// Token: 0x060092D2 RID: 37586 RVA: 0x001B45AD File Offset: 0x001B29AD
		public void ResetButtonListener()
		{
			this._onButtonClickAction = null;
		}

		// Token: 0x060092D3 RID: 37587 RVA: 0x001B45B6 File Offset: 0x001B29B6
		public void SetReturnButtonListener(OnReturnButtonClickAction returnButtonClickAction)
		{
			this._onReturnButtonClickAction = returnButtonClickAction;
		}

		// Token: 0x060092D4 RID: 37588 RVA: 0x001B45BF File Offset: 0x001B29BF
		public void ResetReturnButtonListener()
		{
			this._onReturnButtonClickAction = null;
		}

		// Token: 0x060092D5 RID: 37589 RVA: 0x001B45C8 File Offset: 0x001B29C8
		private void ResetData()
		{
			this._curInterval = 0f;
			this._onButtonClickAction = null;
			this._onReturnButtonClickAction = null;
		}

		// Token: 0x060092D6 RID: 37590 RVA: 0x001B45E4 File Offset: 0x001B29E4
		private void OnButtonClick()
		{
			if (this._onButtonClickAction != null)
			{
				this._onButtonClickAction();
			}
			if (this._onReturnButtonClickAction != null && !this._onReturnButtonClickAction())
			{
				return;
			}
			this.SetButtonTimeLimit(this.buttonCdTime);
		}

		// Token: 0x060092D7 RID: 37591 RVA: 0x001B4631 File Offset: 0x001B2A31
		public void SetButtonTimeLimit(float cdTime)
		{
			if (cdTime <= 0f)
			{
				return;
			}
			this.UpdateButtonState(false);
			this._curInterval = cdTime;
			base.StartCoroutine(this.StartCountDown());
		}

		// Token: 0x060092D8 RID: 37592 RVA: 0x001B465C File Offset: 0x001B2A5C
		private IEnumerator StartCountDown()
		{
			while (this._curInterval > 0f)
			{
				if (this.buttonCdInterval <= 0.1f)
				{
					this._curInterval -= 0.1f;
				}
				else
				{
					this._curInterval -= this.buttonCdInterval;
				}
				this.SetCountDownTimeLabel();
				yield return new WaitForSeconds(0.1f);
			}
			this.UpdateButtonState(true);
			this.ResetCountDownTimeLabel();
			yield break;
		}

		// Token: 0x060092D9 RID: 37593 RVA: 0x001B4677 File Offset: 0x001B2A77
		public void UpdateButtonState(bool flag)
		{
			if (this.button != null)
			{
				this.button.interactable = flag;
			}
			if (this.buttonGray != null)
			{
				this.buttonGray.enabled = !flag;
			}
		}

		// Token: 0x060092DA RID: 37594 RVA: 0x001B46B6 File Offset: 0x001B2AB6
		public void SetCountDownTimeDescription(string defaultStr = null, string countDownTimeFormat = null)
		{
			this._defaultStr = defaultStr;
			this._countDownTimeStrFormat = countDownTimeFormat;
		}

		// Token: 0x060092DB RID: 37595 RVA: 0x001B46C8 File Offset: 0x001B2AC8
		private void SetCountDownTimeLabel()
		{
			if (this.countDownTimeLabel == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._countDownTimeStrFormat))
			{
				return;
			}
			string text = string.Format(this._countDownTimeStrFormat, (int)this._curInterval + 1);
			this.countDownTimeLabel.text = text;
		}

		// Token: 0x060092DC RID: 37596 RVA: 0x001B471E File Offset: 0x001B2B1E
		private void ResetCountDownTimeLabel()
		{
			if (this.countDownTimeLabel == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._defaultStr))
			{
				return;
			}
			this.countDownTimeLabel.text = this._defaultStr;
		}

		// Token: 0x060092DD RID: 37597 RVA: 0x001B4754 File Offset: 0x001B2B54
		public void Reset()
		{
			this.StopCountDown();
			this.UpdateButtonState(true);
			this.ResetCountDownTimeLabel();
		}

		// Token: 0x060092DE RID: 37598 RVA: 0x001B4769 File Offset: 0x001B2B69
		public void StopCountDown()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x060092DF RID: 37599 RVA: 0x001B4771 File Offset: 0x001B2B71
		public float GetButtonCdTime()
		{
			return this.buttonCdTime;
		}

		// Token: 0x040049E0 RID: 18912
		private Action _onButtonClickAction;

		// Token: 0x040049E1 RID: 18913
		private OnReturnButtonClickAction _onReturnButtonClickAction;

		// Token: 0x040049E2 RID: 18914
		private float _curInterval;

		// Token: 0x040049E3 RID: 18915
		private string _defaultStr;

		// Token: 0x040049E4 RID: 18916
		private string _countDownTimeStrFormat;

		// Token: 0x040049E5 RID: 18917
		[SerializeField]
		private Button button;

		// Token: 0x040049E6 RID: 18918
		[SerializeField]
		private UIGray buttonGray;

		// Token: 0x040049E7 RID: 18919
		[SerializeField]
		private float buttonCdTime = 0.5f;

		// Token: 0x040049E8 RID: 18920
		[SerializeField]
		private float buttonCdInterval = 0.1f;

		// Token: 0x040049E9 RID: 18921
		[Space(25f)]
		[Header("CountDownTimeLabel")]
		[Space(15f)]
		[SerializeField]
		private Text countDownTimeLabel;
	}
}
