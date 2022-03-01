using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001775 RID: 6005
	public class MonthCardBuyResult : ClientFrame
	{
		// Token: 0x0600ED4A RID: 60746 RVA: 0x003F985A File Offset: 0x003F7C5A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/MonthCardBuyResult";
		}

		// Token: 0x0600ED4B RID: 60747 RVA: 0x003F9864 File Offset: 0x003F7C64
		protected override void _OnOpenFrame()
		{
			MonthCardBuyResult.bBuyMonthCard = false;
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<MonthCardBuyResult>(this, false);
				});
			}
			MonthCardBuyResultUserData monthCardBuyResultUserData = this.userData as MonthCardBuyResultUserData;
			if (monthCardBuyResultUserData != null)
			{
				if (this.txtResultInfo != null)
				{
					this.txtResultInfo.text = monthCardBuyResultUserData.strResultInfo;
				}
				if (this.btnOK != null)
				{
					this.btnOK.onClick.AddListener(monthCardBuyResultUserData.okCallBack);
				}
			}
		}

		// Token: 0x0600ED4C RID: 60748 RVA: 0x003F990F File Offset: 0x003F7D0F
		protected override void _OnCloseFrame()
		{
			MonthCardBuyResult.bBuyMonthCard = false;
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x040090CC RID: 37068
		public static bool bBuyMonthCard;

		// Token: 0x040090CD RID: 37069
		[UIControl("Text", null, 0)]
		private Text txtResultInfo;

		// Token: 0x040090CE RID: 37070
		[UIControl("OK", null, 0)]
		private Button btnOK;
	}
}
