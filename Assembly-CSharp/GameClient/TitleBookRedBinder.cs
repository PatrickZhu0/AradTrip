using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004AF5 RID: 19189
	internal class TitleBookRedBinder : MonoBehaviour
	{
		// Token: 0x0601BEA4 RID: 114340 RVA: 0x0088BEB7 File Offset: 0x0088A2B7
		private void Start()
		{
			if (this.goTarget == null)
			{
				this.goTarget = base.gameObject;
			}
			this._UpdateRedPoint();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0601BEA5 RID: 114341 RVA: 0x0088BEF4 File Offset: 0x0088A2F4
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
		}

		// Token: 0x0601BEA6 RID: 114342 RVA: 0x0088BF0E File Offset: 0x0088A30E
		private void _OnAddTittle(ulong uid)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0601BEA7 RID: 114343 RVA: 0x0088BF16 File Offset: 0x0088A316
		private void _OnRemoveTitle(ulong uid)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0601BEA8 RID: 114344 RVA: 0x0088BF1E File Offset: 0x0088A31E
		private void _OnUpdateTitle(ulong uid)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0601BEA9 RID: 114345 RVA: 0x0088BF26 File Offset: 0x0088A326
		private void _OnTittleMarkChanged(TittleComeType eTittleComeType)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0601BEAA RID: 114346 RVA: 0x0088BF2E File Offset: 0x0088A32E
		private void _OnRedPointChanged(UIEvent uiEvent)
		{
			this._UpdateRedPoint();
		}

		// Token: 0x0601BEAB RID: 114347 RVA: 0x0088BF36 File Offset: 0x0088A336
		private void _UpdateRedPoint()
		{
			this.goTarget.CustomActive(DataManager<ItemDataManager>.GetInstance().IsPackageHasNew(EPackageType.Title));
		}

		// Token: 0x0401376B RID: 79723
		public GameObject goTarget;
	}
}
