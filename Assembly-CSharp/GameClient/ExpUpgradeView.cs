using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015D9 RID: 5593
	public class ExpUpgradeView : MonoBehaviour
	{
		// Token: 0x17001C54 RID: 7252
		// (get) Token: 0x0600DB1C RID: 56092 RVA: 0x003735FC File Offset: 0x003719FC
		// (set) Token: 0x0600DB1D RID: 56093 RVA: 0x00373604 File Offset: 0x00371A04
		public UnityAction OnTimeIntervalCloseCallBack
		{
			get
			{
				return this._onTimeIntervalCloseCallBack;
			}
			set
			{
				if (value != null)
				{
					this._onTimeIntervalCloseCallBack = value;
				}
			}
		}

		// Token: 0x17001C55 RID: 7253
		// (set) Token: 0x0600DB1E RID: 56094 RVA: 0x00373614 File Offset: 0x00371A14
		public UnityAction OnButtonCloseCallBack
		{
			set
			{
				if (this.closeButton != null)
				{
					if (this._onButtonCloseCallBack != null)
					{
						this.closeButton.onClick.RemoveListener(this._onButtonCloseCallBack);
					}
					if (value != null)
					{
						this._onButtonCloseCallBack = value;
						this.closeButton.onClick.AddListener(this._onButtonCloseCallBack);
					}
				}
			}
		}

		// Token: 0x0600DB1F RID: 56095 RVA: 0x00373676 File Offset: 0x00371A76
		private void Awake()
		{
			this.titleText.text = TR.Value("exp_upgrade_title");
			this.closeTipText.text = TR.Value("exp_upgrade_close_tip");
		}

		// Token: 0x0600DB20 RID: 56096 RVA: 0x003736A4 File Offset: 0x00371AA4
		public void InitExpUpgradeData(ExpUpgradeData expUpgradeData)
		{
			this._curExpValue = expUpgradeData.CurExpValue;
			this._curTotalExpValue = expUpgradeData.MaxExpValue;
			this._addExpValue = expUpgradeData.AddExpValue;
			if (expUpgradeData.reason == PlayerIncExpReason.PIER_EXP_PILL_VALUE)
			{
				this.curExpText.text = this._curExpValue.ToString();
				this.upgradeExpText.text = this._addExpValue.ToString();
			}
			else if (expUpgradeData.reason == PlayerIncExpReason.PIER_EXP_PILL_PERCENT)
			{
				this.curExpText.text = this.GetExpValueStr(this._curExpValue, this._curTotalExpValue);
				this.upgradeExpText.text = this.GetExpValueStr(this._addExpValue, this._curTotalExpValue);
			}
			this.expSlider.maxValue = this._curTotalExpValue;
			this.expSlider.value = this._curExpValue;
			if (this.addExpFrame <= 1)
			{
				this.addExpFrame = 30;
			}
			this._addExpInterval = this._addExpValue / (float)this.addExpFrame;
			if (this.showTimeInterval < 2f)
			{
				this.showTimeInterval = 2f;
			}
		}

		// Token: 0x0600DB21 RID: 56097 RVA: 0x003737D0 File Offset: 0x00371BD0
		private void Update()
		{
			if (this.addExpFrame >= 0)
			{
				if (this.addExpFrame == 0)
				{
					this.expSlider.value = this._curExpValue + this._addExpValue;
					this.addExpFrame = -1;
				}
				else
				{
					this.expSlider.value = this.expSlider.value + this._addExpInterval;
					this.addExpFrame--;
				}
			}
			this.showTimeInterval -= Time.deltaTime;
			if (this.showTimeInterval <= 0f && this._onTimeIntervalCloseCallBack != null)
			{
				this._onTimeIntervalCloseCallBack.Invoke();
			}
		}

		// Token: 0x0600DB22 RID: 56098 RVA: 0x0037387D File Offset: 0x00371C7D
		private void OnDisable()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600DB23 RID: 56099 RVA: 0x003738A0 File Offset: 0x00371CA0
		private string GetExpValueStr(ulong value, ulong totalValue)
		{
			int num = (int)(value / totalValue * 100f);
			return string.Format("{0}%", num);
		}

		// Token: 0x04008107 RID: 33031
		[SerializeField]
		private Text titleText;

		// Token: 0x04008108 RID: 33032
		[SerializeField]
		private Text curExpText;

		// Token: 0x04008109 RID: 33033
		[SerializeField]
		private Text upgradeExpText;

		// Token: 0x0400810A RID: 33034
		[SerializeField]
		private Text closeTipText;

		// Token: 0x0400810B RID: 33035
		[SerializeField]
		private Slider expSlider;

		// Token: 0x0400810C RID: 33036
		[SerializeField]
		private float showTimeInterval;

		// Token: 0x0400810D RID: 33037
		[SerializeField]
		private int addExpFrame;

		// Token: 0x0400810E RID: 33038
		private ulong _curExpValue = 100UL;

		// Token: 0x0400810F RID: 33039
		private ulong _addExpValue = 300UL;

		// Token: 0x04008110 RID: 33040
		private ulong _curTotalExpValue = 500UL;

		// Token: 0x04008111 RID: 33041
		private float _addExpInterval;

		// Token: 0x04008112 RID: 33042
		private UnityAction _onTimeIntervalCloseCallBack;

		// Token: 0x04008113 RID: 33043
		[SerializeField]
		private Button closeButton;

		// Token: 0x04008114 RID: 33044
		private UnityAction _onButtonCloseCallBack;
	}
}
