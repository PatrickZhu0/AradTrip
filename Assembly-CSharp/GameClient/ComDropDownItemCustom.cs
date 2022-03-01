using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BBD RID: 7101
	public class ComDropDownItemCustom : MonoBehaviour
	{
		// Token: 0x060115F7 RID: 71159 RVA: 0x00508BDA File Offset: 0x00506FDA
		private void Start()
		{
			if (this.m_Select)
			{
				this.m_Select.onValueChanged.AddListener(new UnityAction<bool>(this._OnSelectToggleChanged));
			}
		}

		// Token: 0x060115F8 RID: 71160 RVA: 0x00508C08 File Offset: 0x00507008
		private void OnDestroy()
		{
			if (this.m_Select)
			{
				this.m_Select.onValueChanged.RemoveListener(new UnityAction<bool>(this._OnSelectToggleChanged));
				this.m_Select = null;
			}
			this.Clear();
		}

		// Token: 0x060115F9 RID: 71161 RVA: 0x00508C43 File Offset: 0x00507043
		private void _OnSelectToggleChanged(bool isOn)
		{
			if (this.onToggleClick != null)
			{
				this.onToggleClick(isOn, this.mCurrSelectIndex);
			}
		}

		// Token: 0x060115FA RID: 71162 RVA: 0x00508C64 File Offset: 0x00507064
		public void Init(int index, string desc, string bgPath = null)
		{
			if (this.bInit)
			{
				return;
			}
			this.mCurrSelectIndex = index;
			if (this.m_Desc)
			{
				this.m_Desc.text = desc;
			}
			if (this.m_Icon && !string.IsNullOrEmpty(bgPath))
			{
				ETCImageLoader.LoadSprite(ref this.m_Icon, bgPath, true);
			}
			this.bInit = true;
		}

		// Token: 0x060115FB RID: 71163 RVA: 0x00508CD0 File Offset: 0x005070D0
		public void Clear()
		{
			this.onToggleClick = null;
			this.bInit = false;
		}

		// Token: 0x060115FC RID: 71164 RVA: 0x00508CE0 File Offset: 0x005070E0
		public void SetToggleOn()
		{
			if (this.m_Select)
			{
				this.m_Select.isOn = true;
			}
		}

		// Token: 0x060115FD RID: 71165 RVA: 0x00508CFE File Offset: 0x005070FE
		public void SetToggleOff()
		{
			if (this.m_Select)
			{
				this.m_Select.isOn = false;
			}
		}

		// Token: 0x060115FE RID: 71166 RVA: 0x00508D1C File Offset: 0x0050711C
		public string GetToggleDesc()
		{
			if (this.m_Desc)
			{
				return this.m_Desc.text;
			}
			return string.Empty;
		}

		// Token: 0x060115FF RID: 71167 RVA: 0x00508D3F File Offset: 0x0050713F
		public Toggle GetToggle()
		{
			return this.m_Select;
		}

		// Token: 0x0400B44E RID: 46158
		public ComDropDownItemCustom.OnToggleClick onToggleClick;

		// Token: 0x0400B44F RID: 46159
		private int mCurrSelectIndex;

		// Token: 0x0400B450 RID: 46160
		private bool bInit;

		// Token: 0x0400B451 RID: 46161
		[SerializeField]
		private Text m_Desc;

		// Token: 0x0400B452 RID: 46162
		[SerializeField]
		private Image m_Icon;

		// Token: 0x0400B453 RID: 46163
		[SerializeField]
		private Toggle m_Select;

		// Token: 0x02001BBE RID: 7102
		// (Invoke) Token: 0x06011601 RID: 71169
		public delegate void OnToggleClick(bool isOn, int index);
	}
}
