using System;

namespace GameClient
{
	// Token: 0x020013CC RID: 5068
	public class ActiveGroupMainFrame : ClientFrame
	{
		// Token: 0x0600C49D RID: 50333 RVA: 0x002F36BB File Offset: 0x002F1ABB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActiveGroup/ActiveGroupMainFrame";
		}

		// Token: 0x0600C49E RID: 50334 RVA: 0x002F36C2 File Offset: 0x002F1AC2
		public static void CommandOpen(object argv)
		{
			if (argv == null)
			{
				argv = new ActiveGroupMainFrameData();
			}
			else
			{
				argv = (argv as ActiveGroupMainFrameData);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveGroupMainFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600C49F RID: 50335 RVA: 0x002F36F0 File Offset: 0x002F1AF0
		[UIEventHandle("ComWnd/Title/Close")]
		private void _OnClickCloseFrame()
		{
			this.frameMgr.CloseFrame<ActiveGroupMainFrame>(this, false);
		}

		// Token: 0x0600C4A0 RID: 50336 RVA: 0x002F3700 File Offset: 0x002F1B00
		protected override void _OnOpenFrame()
		{
			this._data = (this.userData as ActiveGroupMainFrameData);
			if (this._data == null)
			{
				this._data = new ActiveGroupMainFrameData();
			}
			this.comActiveMain = this.frame.GetComponent<ComActiveGroupMain>();
			if (null != this.comActiveMain)
			{
				this.comActiveMain.CreateMainTabs();
				this.comActiveMain.SelectTab(this._data.iTabID);
				this.comActiveMain.InitTabDropDown();
				this.comActiveMain.UpdateAchievementPoint();
				this.comActiveMain.UpdateTabProcess();
				this.comActiveMain.UpdateAwardStatus();
			}
		}

		// Token: 0x0600C4A1 RID: 50337 RVA: 0x002F37A3 File Offset: 0x002F1BA3
		protected override void _OnCloseFrame()
		{
			if (null != this.comActiveMain)
			{
				this.comActiveMain.StopInvoke();
				this.comActiveMain = null;
			}
			this._data = null;
		}

		// Token: 0x04006FF3 RID: 28659
		private ComActiveGroupMain comActiveMain;

		// Token: 0x04006FF4 RID: 28660
		private ActiveGroupMainFrameData _data;
	}
}
