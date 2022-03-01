using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001870 RID: 6256
	public class ArborDayActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F51C RID: 62748 RVA: 0x00421FC1 File Offset: 0x004203C1
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model != null)
			{
				this.mModel = model;
			}
			this.InitViewContent();
		}

		// Token: 0x0600F51D RID: 62749 RVA: 0x00421FD6 File Offset: 0x004203D6
		public void Show()
		{
			this.UpdateViewContent();
		}

		// Token: 0x0600F51E RID: 62750 RVA: 0x00421FDE File Offset: 0x004203DE
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.mModel = data;
			this.UpdateViewContent();
		}

		// Token: 0x0600F51F RID: 62751 RVA: 0x00421FF0 File Offset: 0x004203F0
		private void InitViewContent()
		{
			if (this.treeInformationController != null)
			{
				this.treeInformationController.InitTreeInformationController(this.mModel);
			}
			if (this.rewardController != null)
			{
				this.rewardController.InitRewardController(this.mModel);
			}
		}

		// Token: 0x0600F520 RID: 62752 RVA: 0x00422044 File Offset: 0x00420444
		private void UpdateViewContent()
		{
			if (this.treeInformationController != null)
			{
				this.treeInformationController.OnUpdateTreeInformationController(this.mModel);
			}
			if (this.rewardController != null)
			{
				this.rewardController.OnUpdateRewardController(this.mModel);
			}
		}

		// Token: 0x0600F521 RID: 62753 RVA: 0x00422095 File Offset: 0x00420495
		public void Close()
		{
			this.mModel = null;
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F522 RID: 62754 RVA: 0x004220A9 File Offset: 0x004204A9
		public void Dispose()
		{
		}

		// Token: 0x0600F523 RID: 62755 RVA: 0x004220AB File Offset: 0x004204AB
		public void Hide()
		{
		}

		// Token: 0x0400964F RID: 38479
		private ILimitTimeActivityModel mModel;

		// Token: 0x04009650 RID: 38480
		[Space(10f)]
		[Header("ArborDayView")]
		[Space(10f)]
		[SerializeField]
		private ArborDayTreeInformationController treeInformationController;

		// Token: 0x04009651 RID: 38481
		[SerializeField]
		private ArborDayRewardController rewardController;
	}
}
