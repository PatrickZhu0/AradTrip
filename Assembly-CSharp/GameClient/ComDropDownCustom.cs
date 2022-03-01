using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BBA RID: 7098
	public class ComDropDownCustom : MonoBehaviour
	{
		// Token: 0x17001DA9 RID: 7593
		// (get) Token: 0x060115E2 RID: 71138 RVA: 0x00508572 File Offset: 0x00506972
		public bool BExpand
		{
			get
			{
				return this.bExpand;
			}
		}

		// Token: 0x17001DAA RID: 7594
		// (get) Token: 0x060115E3 RID: 71139 RVA: 0x0050857A File Offset: 0x0050697A
		public bool BEnabled
		{
			get
			{
				return this.bEnabled;
			}
		}

		// Token: 0x060115E4 RID: 71140 RVA: 0x00508582 File Offset: 0x00506982
		private void Start()
		{
			if (this.m_ShowBtn)
			{
				this.m_ShowBtn.onClick.AddListener(new UnityAction(this._OnSelectBtnClick));
			}
		}

		// Token: 0x060115E5 RID: 71141 RVA: 0x005085B0 File Offset: 0x005069B0
		private void OnDestroy()
		{
			if (this.m_ShowBtn)
			{
				this.m_ShowBtn.onClick.RemoveListener(new UnityAction(this._OnSelectBtnClick));
			}
			this.Clear();
		}

		// Token: 0x060115E6 RID: 71142 RVA: 0x005085E4 File Offset: 0x005069E4
		private void _OnSelectBtnClick()
		{
			if (!this.bEnabled)
			{
				if (this.onDisabledHandle != null)
				{
					this.onDisabledHandle();
				}
				return;
			}
			if (this.m_ChildRoot == null)
			{
				return;
			}
			if (this.m_ChildRoot.activeSelf)
			{
				this._SetChildExpand(false);
			}
			else
			{
				this._SetChildExpand(true);
			}
		}

		// Token: 0x060115E7 RID: 71143 RVA: 0x00508648 File Offset: 0x00506A48
		private void _SetChildExpand(bool expand)
		{
			this.bExpand = expand;
			this.m_ChildRoot.CustomActive(expand);
			this.m_ExtendDesc.CustomActive(!expand);
		}

		// Token: 0x060115E8 RID: 71144 RVA: 0x0050866C File Offset: 0x00506A6C
		private void _SetShowText(string text)
		{
			if (this.m_ShowText)
			{
				this.m_ShowText.text = text;
			}
		}

		// Token: 0x060115E9 RID: 71145 RVA: 0x0050868C File Offset: 0x00506A8C
		public void Init(List<string> showTextList)
		{
			if (this.bInited)
			{
				return;
			}
			if (showTextList == null || showTextList.Count == 0 || this.m_ChildItemTemplete == null)
			{
				return;
			}
			List<string> list = new List<string>();
			list.AddRange(showTextList);
			if (this.m_ChildItems == null)
			{
				this.m_ChildItems = new List<ComDropDownItemCustom>();
			}
			if (list.Count > this.m_ChildItems.Count)
			{
				int num = list.Count - this.m_ChildItems.Count;
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_ChildItemTemplete.gameObject);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.m_ChildRoot, false);
						gameObject.transform.SetAsLastSibling();
						ComDropDownItemCustom component = gameObject.GetComponent<ComDropDownItemCustom>();
						if (!(component == null) && !(component.GetToggle() == null))
						{
							component.GetToggle().group = this.m_ChildToggleGroup;
							component.SetToggleOff();
							this.m_ChildItems.Add(component);
						}
					}
				}
			}
			else if (list.Count < this.m_ChildItems.Count)
			{
				for (int j = list.Count; j < this.m_ChildItems.Count; j++)
				{
					if (this.m_ChildItems.Contains(this.m_ChildItems[j]))
					{
						this.m_ChildItems[j].CustomActive(false);
					}
				}
			}
			this.currIndexCount = list.Count;
			if (this.b_IndexReverse)
			{
				list.Reverse();
				for (int k = list.Count - 1; k >= 0; k--)
				{
					if (k < this.m_ChildItems.Count)
					{
						ComDropDownItemCustom child = this.m_ChildItems[k];
						if (!(child == null))
						{
							child.Init(list.Count - k, list[k], null);
							child.onToggleClick = delegate(bool isOn, int index)
							{
								if (isOn)
								{
									this._SetChildExpand(false);
									this._SetShowText(child.GetToggleDesc());
									if (this.onSelectIndex != null)
									{
										this.onSelectIndex(index);
									}
								}
							};
							child.gameObject.CustomActive(true);
						}
					}
				}
			}
			else
			{
				for (int l = 0; l < list.Count; l++)
				{
					if (l < this.m_ChildItems.Count)
					{
						ComDropDownItemCustom child = this.m_ChildItems[l];
						if (!(child == null))
						{
							child.Init(this.m_PreIndex + l, list[l], null);
							child.onToggleClick = delegate(bool isOn, int index)
							{
								if (isOn)
								{
									this._SetChildExpand(false);
									this._SetShowText(child.GetToggleDesc());
									if (this.onSelectIndex != null)
									{
										this.onSelectIndex(index);
									}
								}
							};
							child.gameObject.CustomActive(true);
						}
					}
				}
			}
			this._SetChildExpand(false);
			this.m_ChildItemTemplete.CustomActive(false);
			this.bInited = true;
		}

		// Token: 0x060115EA RID: 71146 RVA: 0x005089CC File Offset: 0x00506DCC
		public void Clear()
		{
			this.onSelectIndex = null;
			this.onDisabledHandle = null;
			this.bExpand = false;
			this.m_ChildRoot.CustomActive(false);
			if (this.m_ChildItems != null)
			{
				for (int i = 0; i < this.m_ChildItems.Count; i++)
				{
					ComDropDownItemCustom comDropDownItemCustom = this.m_ChildItems[i];
					if (!(comDropDownItemCustom == null))
					{
						comDropDownItemCustom.Clear();
					}
				}
			}
			this.bInited = false;
			this.currIndexCount = 0;
		}

		// Token: 0x060115EB RID: 71147 RVA: 0x00508A54 File Offset: 0x00506E54
		public void ResetFirstIndex()
		{
			if (this.m_ChildItems == null || this.m_ChildItems.Count == 0)
			{
				return;
			}
			if (this.b_IndexReverse)
			{
				if (this.m_ChildItems.Count >= this.currIndexCount)
				{
					this.m_ChildItems[this.currIndexCount - 1].SetToggleOn();
					this._SetShowText(this.m_ChildItems[this.currIndexCount - 1].GetToggleDesc());
				}
			}
			else
			{
				this.m_ChildItems[0].SetToggleOn();
				this._SetShowText(this.m_ChildItems[0].GetToggleDesc());
			}
		}

		// Token: 0x060115EC RID: 71148 RVA: 0x00508B01 File Offset: 0x00506F01
		public int GetFirstIndex()
		{
			return this.m_PreIndex;
		}

		// Token: 0x060115ED RID: 71149 RVA: 0x00508B09 File Offset: 0x00506F09
		public void SetEnable(bool enabled)
		{
			this.bEnabled = enabled;
		}

		// Token: 0x0400B43F RID: 46143
		public ComDropDownCustom.OnDropDownSelectIndex onSelectIndex;

		// Token: 0x0400B440 RID: 46144
		public ComDropDownCustom.OnDisabledHandle onDisabledHandle;

		// Token: 0x0400B441 RID: 46145
		private bool bExpand;

		// Token: 0x0400B442 RID: 46146
		private bool bEnabled = true;

		// Token: 0x0400B443 RID: 46147
		private List<ComDropDownItemCustom> m_ChildItems;

		// Token: 0x0400B444 RID: 46148
		private bool bInited;

		// Token: 0x0400B445 RID: 46149
		private int currIndexCount;

		// Token: 0x0400B446 RID: 46150
		[SerializeField]
		private Button m_ShowBtn;

		// Token: 0x0400B447 RID: 46151
		[SerializeField]
		private Text m_ShowText;

		// Token: 0x0400B448 RID: 46152
		[SerializeField]
		private GameObject m_ChildRoot;

		// Token: 0x0400B449 RID: 46153
		[SerializeField]
		private ComDropDownItemCustom m_ChildItemTemplete;

		// Token: 0x0400B44A RID: 46154
		[SerializeField]
		private GameObject m_ExtendDesc;

		// Token: 0x0400B44B RID: 46155
		[SerializeField]
		private ToggleGroup m_ChildToggleGroup;

		// Token: 0x0400B44C RID: 46156
		[SerializeField]
		[Header("初始index")]
		private int m_PreIndex = 1;

		// Token: 0x0400B44D RID: 46157
		[SerializeField]
		[Header("index顺序相反")]
		private bool b_IndexReverse;

		// Token: 0x02001BBB RID: 7099
		// (Invoke) Token: 0x060115EF RID: 71151
		public delegate void OnDropDownSelectIndex(int index);

		// Token: 0x02001BBC RID: 7100
		// (Invoke) Token: 0x060115F3 RID: 71155
		public delegate void OnDisabledHandle();
	}
}
