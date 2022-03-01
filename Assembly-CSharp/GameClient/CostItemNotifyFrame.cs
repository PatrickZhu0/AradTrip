using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200159E RID: 5534
	internal class CostItemNotifyFrame : ClientFrame
	{
		// Token: 0x0600D877 RID: 55415 RVA: 0x00362A35 File Offset: 0x00360E35
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CostItemNotify/CostItemNotify";
		}

		// Token: 0x0600D878 RID: 55416 RVA: 0x00362A3C File Offset: 0x00360E3C
		protected override void _OnOpenFrame()
		{
			CostItemNotifyData costItemNotifyData = this.userData as CostItemNotifyData;
			if (costItemNotifyData != null)
			{
				this.m_labContent.text = costItemNotifyData.strContent;
				this.m_btnOk.onClick.RemoveAllListeners();
				this.m_btnOk.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<CostItemNotifyFrame>(this, false);
				});
				if (costItemNotifyData.delOnOkCallback != null)
				{
					this.m_btnOk.onClick.AddListener(costItemNotifyData.delOnOkCallback);
				}
				this.m_btnCancel.onClick.RemoveAllListeners();
				this.m_btnCancel.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<CostItemNotifyFrame>(this, false);
				});
				if (costItemNotifyData.delOnCancelCallback != null)
				{
					this.m_btnCancel.onClick.AddListener(costItemNotifyData.delOnCancelCallback);
				}
				this.m_togCanNotify.onValueChanged.RemoveAllListeners();
				this.m_togCanNotify.isOn = !DataManager<CostItemManager>.GetInstance().isNotify;
				this.m_togCanNotify.onValueChanged.AddListener(delegate(bool var)
				{
					DataManager<CostItemManager>.GetInstance().isNotify = !var;
				});
			}
		}

		// Token: 0x0600D879 RID: 55417 RVA: 0x00362B5B File Offset: 0x00360F5B
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x04007F1A RID: 32538
		[UIControl("Back/TextPanel/AlertText", null, 0)]
		private Text m_labContent;

		// Token: 0x04007F1B RID: 32539
		[UIControl("Back/Panel/btOK", null, 0)]
		private Button m_btnOk;

		// Token: 0x04007F1C RID: 32540
		[UIControl("Back/Panel/btCancel", null, 0)]
		private Button m_btnCancel;

		// Token: 0x04007F1D RID: 32541
		[UIControl("Back/CanNotify", null, 0)]
		private Toggle m_togCanNotify;
	}
}
