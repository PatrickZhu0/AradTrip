using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F2F RID: 3887
	public class ComToggleItem : MonoBehaviour
	{
		// Token: 0x06009787 RID: 38791 RVA: 0x001D06EF File Offset: 0x001CEAEF
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleClick));
			}
		}

		// Token: 0x06009788 RID: 38792 RVA: 0x001D072E File Offset: 0x001CEB2E
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x06009789 RID: 38793 RVA: 0x001D0757 File Offset: 0x001CEB57
		protected virtual void ResetData()
		{
			this._comToggleData = null;
			this._onComToggleClick = null;
		}

		// Token: 0x0600978A RID: 38794 RVA: 0x001D0767 File Offset: 0x001CEB67
		protected virtual void OnEnable()
		{
		}

		// Token: 0x0600978B RID: 38795 RVA: 0x001D0769 File Offset: 0x001CEB69
		protected virtual void OnDisable()
		{
		}

		// Token: 0x0600978C RID: 38796 RVA: 0x001D076B File Offset: 0x001CEB6B
		public virtual void InitItem(ComControlData comToggleData, OnComToggleClick onComToggleClick = null)
		{
			this.ResetData();
			this._comToggleData = comToggleData;
			this._onComToggleClick = onComToggleClick;
			if (this._comToggleData == null)
			{
				Logger.LogErrorFormat("ComToggleItem InitItem comToggleData is null", new object[0]);
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600978D RID: 38797 RVA: 0x001D07A4 File Offset: 0x001CEBA4
		protected virtual void InitItemView()
		{
			if (this.normalName != null)
			{
				this.normalName.text = this._comToggleData.Name;
			}
			if (this.selectedName != null)
			{
				this.selectedName.text = this._comToggleData.Name;
			}
			if (this.toggle != null)
			{
				if (this._comToggleData.IsSelected)
				{
					if (this.toggle.isOn)
					{
						this.toggle.isOn = false;
					}
					this.toggle.isOn = true;
				}
				else
				{
					this.toggle.isOn = false;
				}
			}
		}

		// Token: 0x0600978E RID: 38798 RVA: 0x001D0859 File Offset: 0x001CEC59
		private void OnToggleClick(bool value)
		{
			if (this._comToggleData == null)
			{
				return;
			}
			this._comToggleData.IsSelected = value;
			if (value && this._onComToggleClick != null)
			{
				this._onComToggleClick(this._comToggleData);
			}
		}

		// Token: 0x0600978F RID: 38799 RVA: 0x001D0895 File Offset: 0x001CEC95
		public void OnEnableComToggleItem()
		{
			if (this._onComToggleClick != null && this._comToggleData.IsSelected && this._onComToggleClick != null)
			{
				this._onComToggleClick(this._comToggleData);
			}
		}

		// Token: 0x06009790 RID: 38800 RVA: 0x001D08CE File Offset: 0x001CECCE
		public void OnItemRecycle()
		{
			this._comToggleData = null;
		}

		// Token: 0x06009791 RID: 38801 RVA: 0x001D08D7 File Offset: 0x001CECD7
		public void SetToggleOn()
		{
			if (this.toggle == null)
			{
				return;
			}
			if (this.toggle.isOn)
			{
				this.toggle.isOn = false;
			}
			this.toggle.isOn = true;
		}

		// Token: 0x04004E26 RID: 20006
		protected ComControlData _comToggleData;

		// Token: 0x04004E27 RID: 20007
		private OnComToggleClick _onComToggleClick;

		// Token: 0x04004E28 RID: 20008
		[Space(10f)]
		[Header("ComToggleItem")]
		[Space(5f)]
		[SerializeField]
		private Text normalName;

		// Token: 0x04004E29 RID: 20009
		[SerializeField]
		private Text selectedName;

		// Token: 0x04004E2A RID: 20010
		[SerializeField]
		private Toggle toggle;
	}
}
