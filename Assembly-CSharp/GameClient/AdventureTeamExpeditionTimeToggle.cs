using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200141A RID: 5146
	public class AdventureTeamExpeditionTimeToggle : MonoBehaviour
	{
		// Token: 0x0600C782 RID: 51074 RVA: 0x003042DA File Offset: 0x003026DA
		private void Awake()
		{
			this.ClearData();
		}

		// Token: 0x0600C783 RID: 51075 RVA: 0x003042E2 File Offset: 0x003026E2
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600C784 RID: 51076 RVA: 0x003042EA File Offset: 0x003026EA
		public void InitItemView(byte time, bool flag, bool useOnekey = false)
		{
			this.tempTime = time;
			this.isEnable = flag;
			this.mTimeChangeToggle.onValueChanged.AddListener(new UnityAction<bool>(this._OnChangeTimeToggleClick));
			this.isSelect = false;
			this.useOnekey = useOnekey;
		}

		// Token: 0x0600C785 RID: 51077 RVA: 0x00304324 File Offset: 0x00302724
		public void UpdateItemInfo()
		{
			this.mTimeText.text = TR.Value("adventure_team_expedition_dispatch_hour", this.tempTime.ToString());
			if (this.mTimeChangeToggle.isOn)
			{
				this.mTimeText.color = Color.yellow;
				this.mUIGray.enabled = false;
			}
			else if (this.isEnable)
			{
				this.mTimeText.color = Color.white;
				this.mUIGray.enabled = false;
			}
			else
			{
				this.mTimeText.color = Color.white;
				this.mUIGray.enabled = true;
			}
			this.mTimeChangeToggle.enabled = this.isEnable;
			if (this.mTimeChangeToggle)
			{
				bool enabled = this.mTimeChangeToggle.enabled;
				this.mTimeChangeToggle.enabled = true;
				this.mTimeChangeToggle.enabled = enabled;
			}
		}

		// Token: 0x0600C786 RID: 51078 RVA: 0x00304415 File Offset: 0x00302815
		public void ChangeToggleState(bool isOn)
		{
			this.mTimeChangeToggle.isOn = isOn;
		}

		// Token: 0x0600C787 RID: 51079 RVA: 0x00304424 File Offset: 0x00302824
		private void _OnChangeTimeToggleClick(bool isOn)
		{
			if (isOn == this.isSelect)
			{
				return;
			}
			this.isSelect = isOn;
			if (isOn)
			{
				this.mTimeText.color = Color.yellow;
				DataManager<AdventureTeamDataManager>.GetInstance().SetEpxeditionTime(this.tempTime, this.useOnekey);
			}
			else
			{
				this.mTimeText.color = Color.white;
			}
		}

		// Token: 0x0600C788 RID: 51080 RVA: 0x00304486 File Offset: 0x00302886
		public void OnItemRecycle()
		{
			this.ClearData();
			this.mTimeChangeToggle.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnChangeTimeToggleClick));
			this.mTimeChangeToggle.isOn = false;
		}

		// Token: 0x0600C789 RID: 51081 RVA: 0x003044B6 File Offset: 0x003028B6
		private void ClearData()
		{
			this.tempTime = 0;
		}

		// Token: 0x0400728E RID: 29326
		[SerializeField]
		private Text mTimeText;

		// Token: 0x0400728F RID: 29327
		[SerializeField]
		private Toggle mTimeChangeToggle;

		// Token: 0x04007290 RID: 29328
		[SerializeField]
		private UIGray mUIGray;

		// Token: 0x04007291 RID: 29329
		[SerializeField]
		private byte tempTime;

		// Token: 0x04007292 RID: 29330
		private bool isEnable = true;

		// Token: 0x04007293 RID: 29331
		private bool isSelect;

		// Token: 0x04007294 RID: 29332
		private bool useOnekey;
	}
}
