using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001106 RID: 4358
	public class ChijiBugReportFrame : ClientFrame
	{
		// Token: 0x0600A52D RID: 42285 RVA: 0x002214EB File Offset: 0x0021F8EB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiBugReportFrame";
		}

		// Token: 0x0600A52E RID: 42286 RVA: 0x002214F2 File Offset: 0x0021F8F2
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600A52F RID: 42287 RVA: 0x002214F4 File Offset: 0x0021F8F4
		protected override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x0600A530 RID: 42288 RVA: 0x002214FC File Offset: 0x0021F8FC
		private void _ClearData()
		{
		}

		// Token: 0x0600A531 RID: 42289 RVA: 0x00221500 File Offset: 0x0021F900
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mBtReport = this.mBind.GetCom<Button>("btReport");
			this.mBtReport.onClick.AddListener(new UnityAction(this._onBtReportButtonClick));
			this.mBtRecordReport = this.mBind.GetCom<Button>("btReportRecord");
			if (!this.mBtRecordReport.IsNull())
			{
				this.mBtRecordReport.onClick.AddListener(new UnityAction(this._onBtReportRecordButtonClick));
			}
		}

		// Token: 0x0600A532 RID: 42290 RVA: 0x002215B4 File Offset: 0x0021F9B4
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mBtReport.onClick.RemoveListener(new UnityAction(this._onBtReportButtonClick));
			this.mBtReport = null;
			if (!this.mBtRecordReport.IsNull())
			{
				this.mBtRecordReport.onClick.RemoveListener(new UnityAction(this._onBtReportRecordButtonClick));
			}
			this.mBtRecordReport = null;
		}

		// Token: 0x0600A533 RID: 42291 RVA: 0x0022163A File Offset: 0x0021FA3A
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiBugReportFrame>(this, false);
		}

		// Token: 0x0600A534 RID: 42292 RVA: 0x0022164C File Offset: 0x0021FA4C
		private void _onBtReportButtonClick()
		{
			SystemNotifyManager.BaseMsgBoxOkCancel("是否上传数据", delegate
			{
				Singleton<ExceptionManager>.GetInstance().SaveLog();
				Singleton<ClientSystemManager>.instance.OpenFrame<UploadingCompressFrame>(FrameLayer.Middle, null, string.Empty);
			}, null, "确定", "取消");
			this.frameMgr.CloseFrame<ChijiBugReportFrame>(this, false);
		}

		// Token: 0x0600A535 RID: 42293 RVA: 0x00221698 File Offset: 0x0021FA98
		private void _onBtReportRecordButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PKReporterFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04005C32 RID: 23602
		private Button mClose;

		// Token: 0x04005C33 RID: 23603
		private Button mBtReport;

		// Token: 0x04005C34 RID: 23604
		private Button mBtRecordReport;
	}
}
