using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200002B RID: 43
	public class ComFagureController : MonoBehaviour
	{
		// Token: 0x06000101 RID: 257 RVA: 0x0000A570 File Offset: 0x00008970
		private void Awake()
		{
			this._OnFagureChanged(null);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000A579 File Offset: 0x00008979
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this._OnFagureChanged));
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000A594 File Offset: 0x00008994
		private void _OnFagureChanged(UIEvent uiEvent)
		{
			if (null != this.goTarget)
			{
				this.goTarget.CustomActive((int)DataManager<PlayerBaseData>.GetInstance().fatigue >= this.iLow && (int)DataManager<PlayerBaseData>.GetInstance().fatigue <= this.iHigh);
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000A5EA File Offset: 0x000089EA
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FatigueChanged, new ClientEventSystem.UIEventHandler(this._OnFagureChanged));
		}

		// Token: 0x040000D9 RID: 217
		public GameObject goTarget;

		// Token: 0x040000DA RID: 218
		public int iLow;

		// Token: 0x040000DB RID: 219
		public int iHigh = 60;
	}
}
