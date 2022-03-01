using System;
using GameClient;
using UnityEngine.Events;

namespace Parser
{
	// Token: 0x020045F4 RID: 17908
	internal class SceneJump
	{
		// Token: 0x060192D2 RID: 103122 RVA: 0x007F6152 File Offset: 0x007F4552
		public void OnMoveStateChanged(BeTownPlayerMain.EMoveState ePre, BeTownPlayerMain.EMoveState eCur)
		{
		}

		// Token: 0x060192D3 RID: 103123 RVA: 0x007F6154 File Offset: 0x007F4554
		public void OnMoveSuccess()
		{
			BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
			BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
			BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			if (this.onLinkOk != null)
			{
				this.onLinkOk();
				this.onLinkOk = null;
			}
		}

		// Token: 0x060192D4 RID: 103124 RVA: 0x007F61C0 File Offset: 0x007F45C0
		public void OnAutoMoveFail()
		{
			BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this.OnMoveSuccess));
			BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this.OnAutoMoveFail));
			BeTownPlayerMain.OnMoveStateChanged.RemoveListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(this.OnMoveStateChanged));
			this.onLinkOk = null;
		}

		// Token: 0x04012099 RID: 73881
		public OnLinkOk onLinkOk;
	}
}
