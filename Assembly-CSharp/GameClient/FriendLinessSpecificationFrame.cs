using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019FE RID: 6654
	public class FriendLinessSpecificationFrame : ClientFrame
	{
		// Token: 0x0601054B RID: 66891 RVA: 0x00495050 File Offset: 0x00493450
		protected override void _bindExUI()
		{
			this.mText = this.mBind.GetCom<Text>("text");
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
		}

		// Token: 0x0601054C RID: 66892 RVA: 0x004950B6 File Offset: 0x004934B6
		protected override void _unbindExUI()
		{
			this.mText = null;
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
		}

		// Token: 0x0601054D RID: 66893 RVA: 0x004950F3 File Offset: 0x004934F3
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<FriendLinessSpecificationFrame>(this, false);
		}

		// Token: 0x0601054E RID: 66894 RVA: 0x00495102 File Offset: 0x00493502
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/FriendLinessSpecificationFrame";
		}

		// Token: 0x0601054F RID: 66895 RVA: 0x00495109 File Offset: 0x00493509
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
		}

		// Token: 0x06010550 RID: 66896 RVA: 0x00495111 File Offset: 0x00493511
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x0400A55A RID: 42330
		private Text mText;

		// Token: 0x0400A55B RID: 42331
		private Button mClose;
	}
}
