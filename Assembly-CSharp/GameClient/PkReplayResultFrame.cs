using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001998 RID: 6552
	internal class PkReplayResultFrame : ClientFrame
	{
		// Token: 0x0600FF1F RID: 65311 RVA: 0x0046A178 File Offset: 0x00468578
		protected override void _bindExUI()
		{
			this.mBtnWatchAgain = this.mBind.GetCom<Button>("btnWatchAgain");
			this.mBtnWatchAgain.onClick.AddListener(new UnityAction(this._onBtnWatchAgainButtonClick));
			this.mBtnReturn = this.mBind.GetCom<Button>("btnReturn");
			this.mBtnReturn.onClick.AddListener(new UnityAction(this._onBtnReturnButtonClick));
		}

		// Token: 0x0600FF20 RID: 65312 RVA: 0x0046A1EC File Offset: 0x004685EC
		protected override void _unbindExUI()
		{
			this.mTxtWin = null;
			this.mTxtLose = null;
			this.mBtnWatchAgain.onClick.RemoveListener(new UnityAction(this._onBtnWatchAgainButtonClick));
			this.mBtnWatchAgain = null;
			this.mBtnReturn.onClick.RemoveListener(new UnityAction(this._onBtnReturnButtonClick));
			this.mBtnReturn = null;
		}

		// Token: 0x0600FF21 RID: 65313 RVA: 0x0046A24D File Offset: 0x0046864D
		private void _onBtnWatchAgainButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600FF22 RID: 65314 RVA: 0x0046A256 File Offset: 0x00468656
		private void _onBtnReturnButtonClick()
		{
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x0600FF23 RID: 65315 RVA: 0x0046A265 File Offset: 0x00468665
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PKReplayResult";
		}

		// Token: 0x0600FF24 RID: 65316 RVA: 0x0046A26C File Offset: 0x0046866C
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600FF25 RID: 65317 RVA: 0x0046A26E File Offset: 0x0046866E
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0400A0EA RID: 41194
		private Text mTxtWin;

		// Token: 0x0400A0EB RID: 41195
		private Text mTxtLose;

		// Token: 0x0400A0EC RID: 41196
		private Button mBtnWatchAgain;

		// Token: 0x0400A0ED RID: 41197
		private Button mBtnReturn;
	}
}
