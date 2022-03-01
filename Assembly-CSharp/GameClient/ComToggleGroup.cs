using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F39 RID: 3897
	[RequireComponent(typeof(ToggleGroup))]
	public class ComToggleGroup : MonoBehaviour
	{
		// Token: 0x060097C1 RID: 38849 RVA: 0x001D1259 File Offset: 0x001CF659
		public ComToggleGroup()
		{
			this.onSelectChanged = new ComToggleGroup.ToggleGroupEvent();
		}

		// Token: 0x17001921 RID: 6433
		// (get) Token: 0x060097C2 RID: 38850 RVA: 0x001D126C File Offset: 0x001CF66C
		public ComToggle[] comToggles
		{
			get
			{
				return this.m_comToggles;
			}
		}

		// Token: 0x060097C3 RID: 38851 RVA: 0x001D1274 File Offset: 0x001CF674
		public void Initialize()
		{
			this._InitToggles();
		}

		// Token: 0x060097C4 RID: 38852 RVA: 0x001D127C File Offset: 0x001CF67C
		public void SetCurrentToggle(int a_tag)
		{
			this.m_currToggleTag = a_tag;
			this._InitToggles();
			this._InitCurrToggle();
		}

		// Token: 0x060097C5 RID: 38853 RVA: 0x001D1291 File Offset: 0x001CF691
		private void Awake()
		{
			this._InitToggles();
			this._InitCurrToggle();
		}

		// Token: 0x060097C6 RID: 38854 RVA: 0x001D12A0 File Offset: 0x001CF6A0
		private void _InitToggles()
		{
			if (this.m_comToggles == null)
			{
				this.m_comToggles = base.GetComponentsInChildren<ComToggle>();
				for (int i = 0; i < this.m_comToggles.Length; i++)
				{
					ComToggle comToggle = this.m_comToggles[i];
					comToggle.Initialize();
					if (comToggle.toggle != null)
					{
						comToggle.toggle.onValueChanged.AddListener(delegate(bool a_check)
						{
							if (!this.m_bBlockSignal)
							{
								this.onSelectChanged.Invoke(comToggle.userData, a_check);
							}
						});
					}
				}
			}
		}

		// Token: 0x060097C7 RID: 38855 RVA: 0x001D133C File Offset: 0x001CF73C
		private void _InitCurrToggle()
		{
			if (this.m_comToggles != null)
			{
				this.m_bBlockSignal = true;
				ToggleGroup component = base.GetComponent<ToggleGroup>();
				if (!component.allowSwitchOff)
				{
					component.allowSwitchOff = true;
					for (int i = 0; i < this.m_comToggles.Length; i++)
					{
						if (this.m_comToggles[i].userData == this.m_currToggleTag)
						{
							this.m_comToggles[i].toggle.isOn = false;
						}
						else
						{
							this.m_comToggles[i].toggle.isOn = true;
							this.m_comToggles[i].toggle.isOn = false;
						}
					}
					component.allowSwitchOff = false;
				}
				else
				{
					for (int j = 0; j < this.m_comToggles.Length; j++)
					{
						if (this.m_comToggles[j].userData == this.m_currToggleTag)
						{
							this.m_comToggles[j].toggle.isOn = false;
						}
						else
						{
							this.m_comToggles[j].toggle.isOn = true;
							this.m_comToggles[j].toggle.isOn = false;
						}
					}
				}
				this.m_bBlockSignal = false;
				for (int k = 0; k < this.m_comToggles.Length; k++)
				{
					if (this.m_comToggles[k].userData == this.m_currToggleTag)
					{
						this.m_comToggles[k].toggle.isOn = true;
						break;
					}
				}
			}
		}

		// Token: 0x04004E4A RID: 20042
		public ComToggleGroup.ToggleGroupEvent onSelectChanged;

		// Token: 0x04004E4B RID: 20043
		private ComToggle[] m_comToggles;

		// Token: 0x04004E4C RID: 20044
		private int m_currToggleTag;

		// Token: 0x04004E4D RID: 20045
		private bool m_bBlockSignal;

		// Token: 0x02000F3A RID: 3898
		public class ToggleGroupEvent : UnityEvent<int, bool>
		{
		}
	}
}
