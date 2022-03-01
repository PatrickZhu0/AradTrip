using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BAF RID: 7087
	internal class StrengthenContinueConfirm : ClientFrame
	{
		// Token: 0x060115A6 RID: 71078 RVA: 0x005054CC File Offset: 0x005038CC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/StrengthenContinueConfirm";
		}

		// Token: 0x060115A7 RID: 71079 RVA: 0x005054D4 File Offset: 0x005038D4
		protected override void _OnOpenFrame()
		{
			this.m_bHasSend = false;
			this.m_data = (this.userData as StrengthenConfirmData);
			this.m_kHintText = Utility.FindComponent<Text>(this.frame, "middle/Text", true);
			if (this.m_data.ItemData.EquipType == EEquipType.ET_COMMON)
			{
				this.m_kHintText.text = string.Format(TR.Value("strengthen_cs_hint"), this.m_data.ItemData.GetColorName(string.Empty, false), this.m_data.TargetStrengthenLevel);
			}
			else if (this.m_data.ItemData.EquipType == EEquipType.ET_REDMARK)
			{
				this.m_kHintText.text = string.Format(TR.Value("growth_cs_hint"), this.m_data.ItemData.GetColorName(string.Empty, false), this.m_data.TargetStrengthenLevel);
			}
		}

		// Token: 0x060115A8 RID: 71080 RVA: 0x005055C0 File Offset: 0x005039C0
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x060115A9 RID: 71081 RVA: 0x005055C2 File Offset: 0x005039C2
		[UIEventHandle("close")]
		private void OnClickCancel()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.EndContineStrengthen, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenContinueConfirm>(this, false);
		}

		// Token: 0x060115AA RID: 71082 RVA: 0x005055E4 File Offset: 0x005039E4
		[UIEventHandle("ok")]
		private void OnClickOk()
		{
			if (this.m_bHasSend)
			{
				return;
			}
			this.m_bHasSend = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BeginContineStrengthen, null, null, null, null);
			this.frameMgr.CloseFrame<StrengthenContinueConfirm>(this, false);
		}

		// Token: 0x0400B3F0 RID: 46064
		private StrengthenConfirmData m_data;

		// Token: 0x0400B3F1 RID: 46065
		private Text m_kHintText;

		// Token: 0x0400B3F2 RID: 46066
		private bool m_bHasSend;
	}
}
