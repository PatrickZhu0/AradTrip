using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F2B RID: 3883
	[RequireComponent(typeof(Toggle))]
	public class ComToggle : MonoBehaviour
	{
		// Token: 0x17001920 RID: 6432
		// (get) Token: 0x06009771 RID: 38769 RVA: 0x001D02CA File Offset: 0x001CE6CA
		public Toggle toggle
		{
			get
			{
				return this.m_toggle;
			}
		}

		// Token: 0x06009772 RID: 38770 RVA: 0x001D02D2 File Offset: 0x001CE6D2
		public void Initialize()
		{
			this._InitToggle();
		}

		// Token: 0x06009773 RID: 38771 RVA: 0x001D02DA File Offset: 0x001CE6DA
		private void Awake()
		{
			this._InitToggle();
		}

		// Token: 0x06009774 RID: 38772 RVA: 0x001D02E2 File Offset: 0x001CE6E2
		private void Start()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this._UpdateCheckMask));
				this._UpdateCheckMask(this.toggle.isOn);
			}
		}

		// Token: 0x06009775 RID: 38773 RVA: 0x001D0322 File Offset: 0x001CE722
		private void _InitToggle()
		{
			if (this.m_toggle == null)
			{
				this.m_toggle = base.GetComponent<Toggle>();
			}
		}

		// Token: 0x06009776 RID: 38774 RVA: 0x001D0341 File Offset: 0x001CE741
		private void _UpdateCheckMask(bool a_check)
		{
			if (this.objSelect != null)
			{
				this.objSelect.SetActive(a_check);
			}
			if (this.objUnselect != null)
			{
				this.objUnselect.SetActive(!a_check);
			}
		}

		// Token: 0x04004E1D RID: 19997
		public GameObject objSelect;

		// Token: 0x04004E1E RID: 19998
		public GameObject objUnselect;

		// Token: 0x04004E1F RID: 19999
		public int userData = -1;

		// Token: 0x04004E20 RID: 20000
		private Toggle m_toggle;
	}
}
