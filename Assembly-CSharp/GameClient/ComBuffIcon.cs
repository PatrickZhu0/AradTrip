using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E71 RID: 3697
	public class ComBuffIcon : MonoBehaviour
	{
		// Token: 0x170018F9 RID: 6393
		// (get) Token: 0x060092A1 RID: 37537 RVA: 0x001B3E62 File Offset: 0x001B2262
		public BuffDisplayData BuffData
		{
			get
			{
				return this.m_buffTableData;
			}
		}

		// Token: 0x170018FA RID: 6394
		// (get) Token: 0x060092A2 RID: 37538 RVA: 0x001B3E6A File Offset: 0x001B226A
		// (set) Token: 0x060092A3 RID: 37539 RVA: 0x001B3E72 File Offset: 0x001B2272
		public BeBuff BattleBuff
		{
			get
			{
				return this.m_beBuff;
			}
			set
			{
				this.m_beBuff = value;
			}
		}

		// Token: 0x170018FB RID: 6395
		// (get) Token: 0x060092A4 RID: 37540 RVA: 0x001B3E7B File Offset: 0x001B227B
		// (set) Token: 0x060092A5 RID: 37541 RVA: 0x001B3E83 File Offset: 0x001B2283
		public bool needRecycle
		{
			get
			{
				return this.m_needRecycle;
			}
			set
			{
				this.m_needRecycle = value;
			}
		}

		// Token: 0x170018FC RID: 6396
		// (get) Token: 0x060092A6 RID: 37542 RVA: 0x001B3E8C File Offset: 0x001B228C
		// (set) Token: 0x060092A7 RID: 37543 RVA: 0x001B3E94 File Offset: 0x001B2294
		public bool overFlowFlag
		{
			get
			{
				return this.m_overFlowFlag;
			}
			set
			{
				this.m_overFlowFlag = value;
			}
		}

		// Token: 0x060092A8 RID: 37544 RVA: 0x001B3EA0 File Offset: 0x001B22A0
		public void Setup(BuffDisplayData buffData)
		{
			this.m_buffTableData = buffData;
			if (buffData != null)
			{
				base.gameObject.name = buffData.BuffTableID.ToString();
			}
			else
			{
				base.gameObject.name = "buffIcon";
			}
			this.MarkDirty();
		}

		// Token: 0x060092A9 RID: 37545 RVA: 0x001B3EF4 File Offset: 0x001B22F4
		public void SetCountFormatter(ComBuffIcon.CountFormate a_formatter)
		{
			this.m_countFormate = a_formatter;
			this.MarkDirty();
		}

		// Token: 0x060092AA RID: 37546 RVA: 0x001B3F03 File Offset: 0x001B2303
		public void SetDurationFormatter(ComBuffIcon.DurationFormate a_formatter)
		{
			this.m_durationForate = a_formatter;
			this.MarkDirty();
		}

		// Token: 0x060092AB RID: 37547 RVA: 0x001B3F12 File Offset: 0x001B2312
		public void MarkDirty()
		{
			this.m_dirty = true;
		}

		// Token: 0x060092AC RID: 37548 RVA: 0x001B3F1B File Offset: 0x001B231B
		public void MarkCountDirty()
		{
			this.m_countDirty = true;
		}

		// Token: 0x060092AD RID: 37549 RVA: 0x001B3F24 File Offset: 0x001B2324
		private void Start()
		{
			this.MarkDirty();
			this.Update();
		}

		// Token: 0x060092AE RID: 37550 RVA: 0x001B3F32 File Offset: 0x001B2332
		private void Update()
		{
			if (this.m_dirty)
			{
				this._Refresh();
				this.m_dirty = false;
			}
			if (this.m_countDirty)
			{
				this._UpdateNum();
				this.m_countDirty = false;
			}
		}

		// Token: 0x060092AF RID: 37551 RVA: 0x001B3F64 File Offset: 0x001B2364
		private void OnDestroy()
		{
			if (this.mBuffIconGroup != null)
			{
				Image component = this.mBuffIconGroup.GetComponent<Image>();
				if (component != null)
				{
					component.sprite = null;
				}
				this.mBuffIconGroup = null;
			}
			if (this.mBuffIcon != null)
			{
				this.mBuffIcon.sprite = null;
				this.mBuffIcon = null;
			}
			if (this.mMask != null)
			{
				this.mMask.sprite = null;
				this.mMask = null;
			}
			if (this.mOverFlowIcon != null && this.mOverFlowIcon.activeSelf)
			{
				this.mOverFlowIcon.SetActive(false);
			}
		}

		// Token: 0x060092B0 RID: 37552 RVA: 0x001B4020 File Offset: 0x001B2420
		public void Reset()
		{
			base.gameObject.name = "comBuffIcon";
			this.m_dirty = false;
			this.m_buffTableData = null;
			this.m_countDirty = false;
			this.m_beBuff = null;
			RectTransform component = base.gameObject.GetComponent<RectTransform>();
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.anchoredPosition = new Vector2(0f, 0f);
			component.sizeDelta = new Vector2(0f, 0f);
			component.pivot = new Vector2(0.5f, 0.5f);
			Component[] components = base.gameObject.GetComponents<Component>();
			for (int i = 0; i < components.Length; i++)
			{
				if (!(components[i] is ComBuffIcon) && !(components[i] is RectTransform) && !(components[i] is ComButtonEnbale) && !(components[i] is AssetProxy) && !(components[i] is CPooledGameObjectScript))
				{
					Object.Destroy(components[i]);
				}
			}
			this._Refresh();
		}

		// Token: 0x060092B1 RID: 37553 RVA: 0x001B413D File Offset: 0x001B253D
		protected void _Refresh()
		{
			this._UpdateBuffIconGroup();
		}

		// Token: 0x060092B2 RID: 37554 RVA: 0x001B4148 File Offset: 0x001B2548
		private void _UpdateBuffIconGroup()
		{
			if (this.m_buffTableData != null)
			{
				if (this.mBuffIconGroup != null)
				{
					this.mBuffIconGroup.SetActive(true);
				}
				this._UpdateBuffIcon();
				this._UpdatePercent();
				this._UpdateCount();
				if (this.mOverFlowIcon != null && this.mOverFlowIcon.activeSelf)
				{
					this.mOverFlowIcon.SetActive(this.m_overFlowFlag);
				}
				if (this.mBuffIcon != null)
				{
					this.mBuffIcon.gameObject.SetActive(!this.m_overFlowFlag);
				}
				if (this.mMask != null)
				{
					this.mMask.gameObject.SetActive(!this.m_overFlowFlag);
				}
			}
			else
			{
				if (this.mOverFlowIcon != null && this.mOverFlowIcon.activeSelf)
				{
					this.mOverFlowIcon.SetActive(this.m_overFlowFlag);
				}
				if (this.mMask != null)
				{
					this.mMask.gameObject.SetActive(!this.m_overFlowFlag);
				}
				if (this.mBuffIcon != null)
				{
					this.mBuffIcon.gameObject.SetActive(!this.m_overFlowFlag);
				}
			}
		}

		// Token: 0x060092B3 RID: 37555 RVA: 0x001B42A0 File Offset: 0x001B26A0
		private void _UpdateBuffIcon()
		{
			if (this.mBuffIcon != null)
			{
				this.mBuffIcon.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.mBuffIcon, this.m_buffTableData.Icon, true);
			}
		}

		// Token: 0x060092B4 RID: 37556 RVA: 0x001B42D8 File Offset: 0x001B26D8
		private void _UpdatePercent()
		{
			if (this.mMask != null && null != this.mMask.sprite)
			{
				if (this.mMask.type != 3)
				{
					this.mMask.type = 3;
					this.mMask.fillMethod = 4;
					this.mMask.fillOrigin = 2;
					this.mMask.fillClockwise = false;
				}
				this.mMask.fillAmount = Mathf.Clamp01(0f);
			}
		}

		// Token: 0x060092B5 RID: 37557 RVA: 0x001B4362 File Offset: 0x001B2762
		private void _UpdateCount()
		{
		}

		// Token: 0x060092B6 RID: 37558 RVA: 0x001B4364 File Offset: 0x001B2764
		private void _UpdateNum()
		{
			if (this.mMask != null)
			{
				this.mMask.fillAmount = Mathf.Clamp01(1f - this.m_durationForate(this));
			}
		}

		// Token: 0x060092B7 RID: 37559 RVA: 0x001B439C File Offset: 0x001B279C
		public void SetOverFlowIconActive(bool flag)
		{
			this.m_overFlowFlag = flag;
			if (this.mOverFlowIcon != null)
			{
				this.mOverFlowIcon.SetActive(flag);
			}
			if (this.mMask != null)
			{
				this.mMask.gameObject.SetActive(!flag);
			}
			if (this.mBuffIcon != null)
			{
				this.mBuffIcon.gameObject.SetActive(!flag);
			}
		}

		// Token: 0x040049D0 RID: 18896
		[SerializeField]
		private GameObject mBuffIconGroup;

		// Token: 0x040049D1 RID: 18897
		[SerializeField]
		private Image mMask;

		// Token: 0x040049D2 RID: 18898
		[SerializeField]
		private Image mBuffIcon;

		// Token: 0x040049D3 RID: 18899
		[SerializeField]
		private GameObject mOverFlowIcon;

		// Token: 0x040049D4 RID: 18900
		private bool m_dirty;

		// Token: 0x040049D5 RID: 18901
		private BuffDisplayData m_buffTableData;

		// Token: 0x040049D6 RID: 18902
		private bool m_countDirty;

		// Token: 0x040049D7 RID: 18903
		private BeBuff m_beBuff;

		// Token: 0x040049D8 RID: 18904
		private bool m_needRecycle;

		// Token: 0x040049D9 RID: 18905
		private ComBuffIcon.CountFormate m_countFormate;

		// Token: 0x040049DA RID: 18906
		private ComBuffIcon.DurationFormate m_durationForate;

		// Token: 0x040049DB RID: 18907
		private bool m_overFlowFlag;

		// Token: 0x02000E72 RID: 3698
		// (Invoke) Token: 0x060092B9 RID: 37561
		public delegate string CountFormate(ComBuffIcon buffItem);

		// Token: 0x02000E73 RID: 3699
		// (Invoke) Token: 0x060092BD RID: 37565
		public delegate float DurationFormate(ComBuffIcon buffItem);
	}
}
