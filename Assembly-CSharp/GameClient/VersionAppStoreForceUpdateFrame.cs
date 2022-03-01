using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200021E RID: 542
	public class VersionAppStoreForceUpdateFrame : ClientFrame
	{
		// Token: 0x06001211 RID: 4625 RVA: 0x000626BA File Offset: 0x00060ABA
		public override string GetPrefabPath()
		{
			return "Base/UI/Prefabs/AppStoreForceUpdateFrame";
		}

		// Token: 0x06001212 RID: 4626 RVA: 0x000626C1 File Offset: 0x00060AC1
		protected override void _bindExUI()
		{
			this.mUpdate = this.mBind.GetCom<Button>("update");
			this.mUpdate.onClick.AddListener(new UnityAction(this._onUpdateButtonClick));
		}

		// Token: 0x06001213 RID: 4627 RVA: 0x000626F5 File Offset: 0x00060AF5
		protected override void _unbindExUI()
		{
			this.mUpdate.onClick.RemoveListener(new UnityAction(this._onUpdateButtonClick));
			this.mUpdate = null;
		}

		// Token: 0x06001214 RID: 4628 RVA: 0x0006271A File Offset: 0x00060B1A
		private void _onUpdateButtonClick()
		{
			Application.OpenURL(this.mUrl);
		}

		// Token: 0x06001215 RID: 4629 RVA: 0x00062728 File Offset: 0x00060B28
		protected override void _OnOpenFrame()
		{
			this.mUrl = (string)this.userData;
			Logger.LogErrorFormat("[打开AppStore 强制更新界面] {0}", new object[]
			{
				this.mUrl
			});
			if (SDKInterface.instance.NeedChangeUpdateBtnPos())
			{
				this.InitButtonPos();
			}
		}

		// Token: 0x06001216 RID: 4630 RVA: 0x00062774 File Offset: 0x00060B74
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06001217 RID: 4631 RVA: 0x00062778 File Offset: 0x00060B78
		private void InitButtonPos()
		{
			if (this.mUpdate != null)
			{
				this.mUpdate.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(580f, -32f, 0f);
			}
		}

		// Token: 0x04000C08 RID: 3080
		private Button mUpdate;

		// Token: 0x04000C09 RID: 3081
		private string mUrl = string.Empty;
	}
}
