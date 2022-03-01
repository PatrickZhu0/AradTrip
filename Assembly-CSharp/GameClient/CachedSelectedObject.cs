using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000DAF RID: 3503
	internal class CachedSelectedObject<T, F> : CachedObject where T : class, new() where F : class, new()
	{
		// Token: 0x170018C9 RID: 6345
		// (get) Token: 0x06008DBB RID: 36283 RVA: 0x001A5F53 File Offset: 0x001A4353
		public T Value
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170018CA RID: 6346
		// (get) Token: 0x06008DBC RID: 36284 RVA: 0x001A5F5B File Offset: 0x001A435B
		public bool isOn
		{
			get
			{
				return this.toggle != null && this.toggle.isOn;
			}
		}

		// Token: 0x06008DBD RID: 36285 RVA: 0x001A5F7F File Offset: 0x001A437F
		public static void Clear()
		{
			if (CachedSelectedObject<T, F>.Selected != null)
			{
				CachedSelectedObject<T, F>.Selected.OnDisplayChanged(false);
				CachedSelectedObject<T, F>.Selected = null;
			}
		}

		// Token: 0x06008DBE RID: 36286 RVA: 0x001A5F9C File Offset: 0x001A439C
		public void OnSelected()
		{
			if (CachedSelectedObject<T, F>.Selected != this)
			{
				if (CachedSelectedObject<T, F>.Selected != null)
				{
					CachedSelectedObject<T, F>.Selected.OnDisplayChanged(false);
				}
				CachedSelectedObject<T, F>.Selected = this;
				if (!this.toggle.isOn)
				{
					this.toggle.isOn = true;
				}
				CachedSelectedObject<T, F>.Selected.OnDisplayChanged(true);
				if (this.onSelected != null)
				{
					this.onSelected(this.Value);
				}
			}
		}

		// Token: 0x06008DBF RID: 36287 RVA: 0x001A6014 File Offset: 0x001A4414
		public override void OnCreate(object[] param)
		{
			this.goParent = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.data = (param[2] as T);
			this.onSelected = (param[3] as CachedSelectedObject<T, F>.OnSelectedDelegate);
			if (param.Length > 4)
			{
				this.bUseTemplate = (bool)param[4];
			}
			if (this.goLocal == null)
			{
				if (this.bUseTemplate)
				{
					this.goLocal = this.goPrefab;
				}
				else
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				}
				Utility.AttachTo(this.goLocal, this.goParent, false);
			}
			this.toggle = this.goLocal.GetComponent<Toggle>();
			if (this.toggle == null)
			{
				this.toggle = this.goLocal.GetComponentInChildren<Toggle>();
			}
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(delegate(bool bValue)
				{
					if (bValue && this.onSelected != null)
					{
						if (CachedSelectedObject<T, F>.Selected != this)
						{
							if (CachedSelectedObject<T, F>.Selected != null)
							{
								CachedSelectedObject<T, F>.Selected.OnDisplayChanged(false);
							}
							CachedSelectedObject<T, F>.Selected = this;
						}
						CachedSelectedObject<T, F>.Selected.OnDisplayChanged(true);
						this.onSelected(this.data);
					}
				});
			}
			this.Initialize();
			this.Enable();
			this.SetAsLastSibling();
			this.OnUpdate();
		}

		// Token: 0x06008DC0 RID: 36288 RVA: 0x001A6150 File Offset: 0x001A4550
		public override void OnDestroy()
		{
			this.UnInitialize();
			this.onSelected = null;
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle = null;
			}
			this.goLocal = null;
			this.data = (T)((object)null);
			this.goPrefab = null;
			this.goParent = null;
		}

		// Token: 0x06008DC1 RID: 36289 RVA: 0x001A61B3 File Offset: 0x001A45B3
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x06008DC2 RID: 36290 RVA: 0x001A61D2 File Offset: 0x001A45D2
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x06008DC3 RID: 36291 RVA: 0x001A61F1 File Offset: 0x001A45F1
		public override void SetAsLastSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsLastSibling();
			}
		}

		// Token: 0x06008DC4 RID: 36292 RVA: 0x001A6214 File Offset: 0x001A4614
		public void SetSiblingIndex(int iIndex)
		{
			if (null != this.goLocal)
			{
				this.goLocal.transform.SetSiblingIndex(iIndex);
			}
		}

		// Token: 0x06008DC5 RID: 36293 RVA: 0x001A6238 File Offset: 0x001A4638
		public override void OnRefresh(object[] param)
		{
			if (param != null && param.Length > 0)
			{
				this.data = (param[0] as T);
			}
			this.OnUpdate();
		}

		// Token: 0x06008DC6 RID: 36294 RVA: 0x001A6262 File Offset: 0x001A4662
		public override void OnRecycle()
		{
			if (CachedSelectedObject<T, F>.Selected == this)
			{
				CachedSelectedObject<T, F>.Clear();
			}
			this.Disable();
		}

		// Token: 0x06008DC7 RID: 36295 RVA: 0x001A627A File Offset: 0x001A467A
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x06008DC8 RID: 36296 RVA: 0x001A6283 File Offset: 0x001A4683
		public virtual void Initialize()
		{
		}

		// Token: 0x06008DC9 RID: 36297 RVA: 0x001A6285 File Offset: 0x001A4685
		public virtual void UnInitialize()
		{
		}

		// Token: 0x06008DCA RID: 36298 RVA: 0x001A6287 File Offset: 0x001A4687
		public virtual void OnUpdate()
		{
		}

		// Token: 0x06008DCB RID: 36299 RVA: 0x001A6289 File Offset: 0x001A4689
		public virtual void OnDisplayChanged(bool bShow)
		{
		}

		// Token: 0x06008DCC RID: 36300 RVA: 0x001A628B File Offset: 0x001A468B
		public virtual void OnFrameUpdate()
		{
		}

		// Token: 0x0400465B RID: 18011
		protected GameObject goLocal;

		// Token: 0x0400465C RID: 18012
		public static CachedSelectedObject<T, F> Selected;

		// Token: 0x0400465D RID: 18013
		public CachedSelectedObject<T, F>.OnSelectedDelegate onSelected;

		// Token: 0x0400465E RID: 18014
		public GameObject goPrefab;

		// Token: 0x0400465F RID: 18015
		public GameObject goParent;

		// Token: 0x04004660 RID: 18016
		protected Toggle toggle;

		// Token: 0x04004661 RID: 18017
		protected T data;

		// Token: 0x04004662 RID: 18018
		protected bool bUseTemplate;

		// Token: 0x02000DB0 RID: 3504
		// (Invoke) Token: 0x06008DD0 RID: 36304
		public delegate void OnSelectedDelegate(T data);
	}
}
