using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AB2 RID: 6834
	public class SmallPackageDownloadFrame : ClientFrame
	{
		// Token: 0x06010CB4 RID: 68788 RVA: 0x004C957C File Offset: 0x004C797C
		protected override void _bindExUI()
		{
			this.mTxtDownloadSize = this.mBind.GetCom<Text>("txtDownloadSize");
			this.mBtnDownload = this.mBind.GetCom<Button>("btnDownload");
			this.mBtnDownload.onClick.AddListener(new UnityAction(this._onBtnDownloadButtonClick));
			this.mRootIsDownloading = this.mBind.GetGameObject("rootIsDownloading");
			this.mRootDownload = this.mBind.GetGameObject("rootDownload");
			this.mSlider = this.mBind.GetCom<Slider>("slider");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mRootDownloaded = this.mBind.GetGameObject("rootDownloaded");
			this.mBtnCancelDoanload = this.mBind.GetCom<Button>("btnCancelDoanload");
			this.mBtnCancelDoanload.onClick.AddListener(new UnityAction(this._onBtnCancelDoanloadButtonClick));
		}

		// Token: 0x06010CB5 RID: 68789 RVA: 0x004C9690 File Offset: 0x004C7A90
		protected override void _unbindExUI()
		{
			this.mTxtDownloadSize = null;
			this.mBtnDownload.onClick.RemoveListener(new UnityAction(this._onBtnDownloadButtonClick));
			this.mBtnDownload = null;
			this.mRootIsDownloading = null;
			this.mRootDownload = null;
			this.mSlider = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mRootDownloaded = null;
			this.mBtnCancelDoanload.onClick.RemoveListener(new UnityAction(this._onBtnCancelDoanloadButtonClick));
			this.mBtnCancelDoanload = null;
		}

		// Token: 0x06010CB6 RID: 68790 RVA: 0x004C972C File Offset: 0x004C7B2C
		private void _onBtnDownloadButtonClick()
		{
			if (Application.internetReachability == 1)
			{
				float num = Mathf.Abs((float)(this.totalDownloadSize - this.currentDownloadSize)) / 1024f / 1024f;
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format("当前是在4G环境下，是否下载剩余的{0}M资源", num), delegate()
				{
					this._resetTimeAcc();
					SDKInterface.instance.OpenDownload();
					this.isDownloading = true;
				}, null, 0f, false);
			}
			else
			{
				this._resetTimeAcc();
				SDKInterface.instance.OpenDownload();
				this.isDownloading = true;
			}
		}

		// Token: 0x06010CB7 RID: 68791 RVA: 0x004C97A8 File Offset: 0x004C7BA8
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<SmallPackageDownloadFrame>(null, false);
		}

		// Token: 0x06010CB8 RID: 68792 RVA: 0x004C97B6 File Offset: 0x004C7BB6
		private void _onBtnCancelDoanloadButtonClick()
		{
			if (Application.internetReachability == 1)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel("确认停止下载吗", delegate()
				{
					SDKInterface.instance.CloseDownload();
					this._resetTimeAcc();
					this.isDownloading = false;
				}, null, 0f, false);
			}
		}

		// Token: 0x06010CB9 RID: 68793 RVA: 0x004C97E0 File Offset: 0x004C7BE0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmallPackage/SmallPackageDownloadFrame";
		}

		// Token: 0x06010CBA RID: 68794 RVA: 0x004C97E8 File Offset: 0x004C7BE8
		protected override void _OnOpenFrame()
		{
			this.isSmallPackage = SDKInterface.instance.IsSmallPackage();
			if (!this.isSmallPackage)
			{
				this.SetData();
				return;
			}
			this.timeAcc = 0f;
			this.count = 0;
			this.isDownloaded = SDKInterface.instance.IsResourceDownloadFinished();
			this.currentDownloadSize = SDKInterface.instance.GetResourceDownloadedSize();
			this.preDownloadSize = this.currentDownloadSize;
			this.totalDownloadSize = SDKInterface.instance.GetTotalResourceDownloadSize();
			this.SetData();
		}

		// Token: 0x06010CBB RID: 68795 RVA: 0x004C986B File Offset: 0x004C7C6B
		private void _resetTimeAcc()
		{
			this.timeAcc = this.UPDATE_INTERVAL;
		}

		// Token: 0x06010CBC RID: 68796 RVA: 0x004C987C File Offset: 0x004C7C7C
		private void SetData()
		{
			if (this.mRootDownloaded != null)
			{
				this.mRootDownloaded.CustomActive(false);
			}
			if (this.mRootIsDownloading != null)
			{
				this.mRootIsDownloading.CustomActive(false);
			}
			if (this.mRootDownload != null)
			{
				this.mRootDownload.CustomActive(false);
			}
			if (this.isDownloaded)
			{
				this.currentDownloadSize = this.totalDownloadSize;
			}
			if (this.mSlider != null)
			{
				float value = 0f;
				if (this.totalDownloadSize > 0L)
				{
					value = (float)this.currentDownloadSize / (float)this.totalDownloadSize;
				}
				this.mSlider.value = value;
			}
			if (this.mTxtDownloadSize != null)
			{
				this.mTxtDownloadSize.text = string.Format("{0}M/{1}M", this.currentDownloadSize / 1024L / 1024L, this.totalDownloadSize / 1024L / 1024L);
			}
			if (this.isSmallPackage)
			{
				if (this.isDownloaded)
				{
					if (this.mRootDownloaded != null)
					{
						this.mRootDownloaded.CustomActive(true);
					}
				}
				else if (this.isDownloading)
				{
					if (this.mRootIsDownloading != null)
					{
						this.mRootIsDownloading.CustomActive(true);
						this.mBtnCancelDoanload.CustomActive(Application.internetReachability == 1);
					}
				}
				else if (this.mRootDownload != null)
				{
					this.mRootDownload.CustomActive(true);
				}
			}
		}

		// Token: 0x06010CBD RID: 68797 RVA: 0x004C9A24 File Offset: 0x004C7E24
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06010CBE RID: 68798 RVA: 0x004C9A28 File Offset: 0x004C7E28
		protected override void _OnUpdate(float timeElapsed)
		{
			if (!this.isSmallPackage)
			{
				return;
			}
			if (this.isDownloaded)
			{
				return;
			}
			this.timeAcc += timeElapsed;
			if (this.timeAcc > this.UPDATE_INTERVAL)
			{
				this.timeAcc -= this.UPDATE_INTERVAL;
				this.isDownloaded = SDKInterface.instance.IsResourceDownloadFinished();
				this.currentDownloadSize = SDKInterface.instance.GetResourceDownloadedSize();
				if (this.preDownloadSize != this.currentDownloadSize)
				{
					this.isDownloading = true;
					this.count = 0;
				}
				else
				{
					if (this.isDownloading)
					{
						this.count++;
					}
					if (this.count >= 10)
					{
						this.isDownloading = false;
						this.count = 0;
					}
				}
				this.preDownloadSize = this.currentDownloadSize;
				this.SetData();
			}
		}

		// Token: 0x0400AC1A RID: 44058
		private Text mTxtDownloadSize;

		// Token: 0x0400AC1B RID: 44059
		private Button mBtnDownload;

		// Token: 0x0400AC1C RID: 44060
		private GameObject mRootIsDownloading;

		// Token: 0x0400AC1D RID: 44061
		private GameObject mRootDownload;

		// Token: 0x0400AC1E RID: 44062
		private Slider mSlider;

		// Token: 0x0400AC1F RID: 44063
		private Button mClose;

		// Token: 0x0400AC20 RID: 44064
		private GameObject mRootDownloaded;

		// Token: 0x0400AC21 RID: 44065
		private Button mBtnCancelDoanload;

		// Token: 0x0400AC22 RID: 44066
		private bool isDownloading;

		// Token: 0x0400AC23 RID: 44067
		private bool isDownloaded;

		// Token: 0x0400AC24 RID: 44068
		private long currentDownloadSize;

		// Token: 0x0400AC25 RID: 44069
		private long totalDownloadSize;

		// Token: 0x0400AC26 RID: 44070
		private long preDownloadSize;

		// Token: 0x0400AC27 RID: 44071
		private bool isSmallPackage;

		// Token: 0x0400AC28 RID: 44072
		private int count;

		// Token: 0x0400AC29 RID: 44073
		private float timeAcc;

		// Token: 0x0400AC2A RID: 44074
		private float UPDATE_INTERVAL = 0.5f;
	}
}
