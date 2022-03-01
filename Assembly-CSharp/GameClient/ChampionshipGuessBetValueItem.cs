using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014F7 RID: 5367
	public class ChampionshipGuessBetValueItem : MonoBehaviour
	{
		// Token: 0x0600D054 RID: 53332 RVA: 0x00336C5A File Offset: 0x0033505A
		private void Awake()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
				this.betButton.onClick.AddListener(new UnityAction(this.OnBetButtonClick));
			}
		}

		// Token: 0x0600D055 RID: 53333 RVA: 0x00336C99 File Offset: 0x00335099
		private void OnDestroy()
		{
			if (this.betButton != null)
			{
				this.betButton.onClick.RemoveAllListeners();
			}
			this.ClearData();
		}

		// Token: 0x0600D056 RID: 53334 RVA: 0x00336CC2 File Offset: 0x003350C2
		private void ClearData()
		{
			this._betNumber = 0;
			this._guessBetClickAction = null;
		}

		// Token: 0x0600D057 RID: 53335 RVA: 0x00336CD2 File Offset: 0x003350D2
		public void InitItem(int betNumber, OnChampionshipGuessBetClickAction betClickAction)
		{
			this._betNumber = betNumber;
			this._guessBetClickAction = betClickAction;
			if (this.betNumberLabel != null)
			{
				this.betNumberLabel.text = betNumber.ToString();
			}
		}

		// Token: 0x0600D058 RID: 53336 RVA: 0x00336D0B File Offset: 0x0033510B
		private void OnBetButtonClick()
		{
			if (this._guessBetClickAction == null)
			{
				return;
			}
			if (this._betNumber <= 0)
			{
				return;
			}
			this._guessBetClickAction(this._betNumber);
		}

		// Token: 0x0600D059 RID: 53337 RVA: 0x00336D37 File Offset: 0x00335137
		public void RecycleItem()
		{
			this._betNumber = 0;
			this._guessBetClickAction = null;
		}

		// Token: 0x040079EF RID: 31215
		private int _betNumber;

		// Token: 0x040079F0 RID: 31216
		private OnChampionshipGuessBetClickAction _guessBetClickAction;

		// Token: 0x040079F1 RID: 31217
		[Space(10f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private Text betNumberLabel;

		// Token: 0x040079F2 RID: 31218
		[SerializeField]
		private Button betButton;
	}
}
