using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001442 RID: 5186
	public class ShowArtifactJarDiscountFrame : ClientFrame
	{
		// Token: 0x0600C938 RID: 51512 RVA: 0x0030EE47 File Offset: 0x0030D247
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ArtifactJar/ShowArtifactJarDiscountFrame";
		}

		// Token: 0x0600C939 RID: 51513 RVA: 0x0030EE4E File Offset: 0x0030D24E
		protected override void _OnOpenFrame()
		{
			this.UpdateDiscount();
			InvokeMethod.Invoke(1f, new UnityAction(this.ShowEffect1));
			InvokeMethod.Invoke(2.5f, new UnityAction(this.ShowEffect2));
		}

		// Token: 0x0600C93A RID: 51514 RVA: 0x0030EE82 File Offset: 0x0030D282
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ShowEffect1));
			InvokeMethod.RemoveInvokeCall(new UnityAction(this.ShowEffect2));
		}

		// Token: 0x0600C93B RID: 51515 RVA: 0x0030EEA8 File Offset: 0x0030D2A8
		protected override void _bindExUI()
		{
			this.num = this.mBind.GetCom<Image>("num");
			this.btnExit = this.mBind.GetCom<Button>("btnExit");
			this.btnExit.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<ShowArtifactJarDiscountFrame>(this, false);
				this.frameMgr.OpenFrame<ArtifactFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.count = this.mBind.GetCom<Text>("count");
			this.EffUI_moguandazhe = this.mBind.GetGameObject("EffUI_moguandazhe");
			this.EffUI_moguandazhe_chixu = this.mBind.GetGameObject("EffUI_moguandazhe_chixu");
		}

		// Token: 0x0600C93C RID: 51516 RVA: 0x0030EF3A File Offset: 0x0030D33A
		protected override void _unbindExUI()
		{
			this.num = null;
			this.btnExit = null;
			this.EffUI_moguandazhe = null;
			this.EffUI_moguandazhe_chixu = null;
		}

		// Token: 0x0600C93D RID: 51517 RVA: 0x0030EF58 File Offset: 0x0030D358
		private void UpdateDiscount()
		{
			this.num.SafeSetImage(string.Format("UI/Image/Packed/p_UI_Moguanpaidui.png:UI_Moguanpaidui_Number_0{0}", ActivityJarFrame.GetArtifactJarDiscountRate()), false);
			this.count.SafeSetText(TR.Value("artifact_jar_discount_num", ActivityJarFrame.GetArtifactJarDiscountTimes()));
		}

		// Token: 0x0600C93E RID: 51518 RVA: 0x0030EFA4 File Offset: 0x0030D3A4
		private void ShowEffect1()
		{
			this.EffUI_moguandazhe.CustomActive(true);
		}

		// Token: 0x0600C93F RID: 51519 RVA: 0x0030EFB2 File Offset: 0x0030D3B2
		private void ShowEffect2()
		{
			this.EffUI_moguandazhe_chixu.CustomActive(true);
		}

		// Token: 0x0400741E RID: 29726
		private Image num;

		// Token: 0x0400741F RID: 29727
		private Button btnExit;

		// Token: 0x04007420 RID: 29728
		private Text count;

		// Token: 0x04007421 RID: 29729
		private GameObject EffUI_moguandazhe;

		// Token: 0x04007422 RID: 29730
		private GameObject EffUI_moguandazhe_chixu;

		// Token: 0x04007423 RID: 29731
		public const string numberStr = "UI/Image/Packed/p_UI_Moguanpaidui.png:UI_Moguanpaidui_Number_0{0}";
	}
}
