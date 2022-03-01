using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017BF RID: 6079
	internal class ComMainMissionScript : MonoBehaviour
	{
		// Token: 0x17001CE7 RID: 7399
		// (get) Token: 0x0600EFB9 RID: 61369 RVA: 0x00408311 File Offset: 0x00406711
		public MissionManager.SingleMissionInfo Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x17001CE8 RID: 7400
		// (get) Token: 0x0600EFBA RID: 61370 RVA: 0x00408319 File Offset: 0x00406719
		public bool Acquired
		{
			get
			{
				return this.bAcquired;
			}
		}

		// Token: 0x0600EFBB RID: 61371 RVA: 0x00408324 File Offset: 0x00406724
		public static bool IsLegalMainMission(MissionManager.SingleMissionInfo value)
		{
			return value != null && value.missionItem != null && (value.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || value.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || value.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE || value.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE);
		}

		// Token: 0x0600EFBC RID: 61372 RVA: 0x00408393 File Offset: 0x00406793
		private void OnDestroy()
		{
			this.kIcon = null;
			this.kName = null;
			this.goCheckMark = null;
			this.goArrow = null;
			this.value = null;
			this.bAcquired = false;
			this.kContentProcess = null;
			this.frame = null;
		}

		// Token: 0x0600EFBD RID: 61373 RVA: 0x004083D0 File Offset: 0x004067D0
		public void OnVisible(MissionManager.SingleMissionInfo data, ClientFrame clientFrame)
		{
			this.value = data;
			this.frame = (clientFrame as MissionFrameNew);
			MissionTable missionItem = this.value.missionItem;
			base.gameObject.name = missionItem.ID.ToString();
			ETCImageLoader.LoadSprite(ref this.kIcon, Utility.GetMissionIcon(this.value.missionItem.TaskType), true);
			this.kName.text = DataManager<MissionManager>.GetInstance().GetMissionName((uint)missionItem.ID) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)this.value.status, this.value.missionItem.ID);
			this.bAcquired = (this.value.status == 5);
			this.kContentProcess = Utility.ParseMissionProcess((int)this.value.taskID, true);
		}

		// Token: 0x0600EFBE RID: 61374 RVA: 0x004084AD File Offset: 0x004068AD
		public void OnDisplayChange(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
			this.goArrow.CustomActive(bSelected);
		}

		// Token: 0x04009304 RID: 37636
		public static MissionManager.SingleMissionInfo ms_selected;

		// Token: 0x04009305 RID: 37637
		public Image kIcon;

		// Token: 0x04009306 RID: 37638
		public Text kName;

		// Token: 0x04009307 RID: 37639
		public GameObject goCheckMark;

		// Token: 0x04009308 RID: 37640
		public GameObject goArrow;

		// Token: 0x04009309 RID: 37641
		private MissionManager.SingleMissionInfo value;

		// Token: 0x0400930A RID: 37642
		private bool bAcquired;

		// Token: 0x0400930B RID: 37643
		private Utility.ContentProcess kContentProcess;

		// Token: 0x0400930C RID: 37644
		private MissionFrameNew frame;
	}
}
