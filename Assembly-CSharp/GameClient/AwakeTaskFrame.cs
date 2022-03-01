using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014A3 RID: 5283
	internal class AwakeTaskFrame : ClientFrame
	{
		// Token: 0x0600CCD6 RID: 52438 RVA: 0x00324DE0 File Offset: 0x003231E0
		protected override void _OnOpenFrame()
		{
			DataManager<PlayerBaseData>.GetInstance().eChangeJobState = Utility.GetChangeJobState();
			this.eState = DataManager<PlayerBaseData>.GetInstance().eChangeJobState;
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnFinishTask));
			this.InitInterface();
		}

		// Token: 0x0600CCD7 RID: 52439 RVA: 0x00324E38 File Offset: 0x00323238
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600CCD8 RID: 52440 RVA: 0x00324E40 File Offset: 0x00323240
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/AwakeTaskFrame";
		}

		// Token: 0x0600CCD9 RID: 52441 RVA: 0x00324E48 File Offset: 0x00323248
		private void ClearData()
		{
			this.TaskList.Clear();
			this.DoingTaskIndex = -1;
			this.CurSelTaskIndex = -1;
			this.eState = ChangeJobState.DoAwakeJobTask;
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnFinishTask));
		}

		// Token: 0x0600CCDA RID: 52442 RVA: 0x00324E9B File Offset: 0x0032329B
		[UIEventHandle("btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<AwakeTaskFrame>(this, false);
		}

		// Token: 0x0600CCDB RID: 52443 RVA: 0x00324EAA File Offset: 0x003232AA
		[UIEventHandle("return_back/btReturn")]
		private void OnReturn()
		{
			this.OnClose();
		}

		// Token: 0x0600CCDC RID: 52444 RVA: 0x00324EB2 File Offset: 0x003232B2
		[UIEventHandle("TaskList/task{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 4)]
		private void OnSwitchTask(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.CurSelTaskIndex = iIndex;
			this.UpdateCurTaskInfo();
		}

		// Token: 0x0600CCDD RID: 52445 RVA: 0x00324ED0 File Offset: 0x003232D0
		[UIEventHandle("btReceiveAward")]
		private void OnReceiveAward()
		{
			if (this.CurSelTaskIndex < 0 || this.CurSelTaskIndex >= this.TaskList.Count)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AwakeAwardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AwakeAwardFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AwakeAwardFrame>(FrameLayer.Middle, this.TaskList[this.CurSelTaskIndex], string.Empty);
			DataManager<MissionManager>.GetInstance().sendCmdSubmitTask((uint)this.TaskList[this.CurSelTaskIndex], TaskSubmitType.TASK_SUBMIT_UI, 0U);
		}

		// Token: 0x0600CCDE RID: 52446 RVA: 0x00324F60 File Offset: 0x00323360
		private void InitInterface()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.eState == ChangeJobState.DoChangeJobTask)
			{
				this.TaskList = Utility.GetChangeJobTaskList();
			}
			else
			{
				this.TaskList = Utility.GetAwakeTaskList();
			}
			this.taskIcon.gameObject.AddComponent<UIGray>();
			this.taskIcon.gameObject.GetComponent<UIGray>().enabled = false;
			for (int i = 0; i < 4; i++)
			{
				if (i < this.TaskList.Count)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					if (DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)this.TaskList[i], out singleMissionInfo))
					{
						this.task[i].isOn = true;
						this.DoingTaskIndex = i;
						this.CurSelTaskIndex = i;
					}
					else
					{
						this.task[i].isOn = false;
					}
					this.task[i].gameObject.SetActive(true);
				}
				else
				{
					this.task[i].isOn = false;
					this.task[i].gameObject.SetActive(false);
				}
			}
			for (int j = 0; j < 4; j++)
			{
				if (j < this.TaskList.Count)
				{
					if (j < this.DoingTaskIndex)
					{
						this.finish[j].gameObject.SetActive(true);
						this.Tasklock[j].gameObject.SetActive(false);
						this.cover[j].gameObject.SetActive(false);
					}
					else if (j == this.DoingTaskIndex)
					{
						this.finish[j].gameObject.SetActive(false);
						this.Tasklock[j].gameObject.SetActive(false);
						this.cover[j].gameObject.SetActive(false);
					}
					else
					{
						this.finish[j].gameObject.SetActive(false);
						this.Tasklock[j].gameObject.SetActive(true);
						this.cover[j].gameObject.SetActive(true);
					}
				}
				else
				{
					this.finish[j].gameObject.SetActive(false);
					this.Tasklock[j].gameObject.SetActive(false);
					this.cover[j].gameObject.SetActive(false);
				}
			}
			for (int k = 0; k < 3; k++)
			{
				if (k < this.DoingTaskIndex)
				{
					this.Lines[k].gameObject.SetActive(true);
				}
				else
				{
					this.Lines[k].gameObject.SetActive(false);
				}
			}
			if (tableItem.JobPortrayal != string.Empty && tableItem.JobPortrayal != "-")
			{
				ETCImageLoader.LoadSprite(ref this.role, tableItem.JobPortrayal, true);
			}
			if (this.eState == ChangeJobState.DoChangeJobTask)
			{
				this.jobName.gameObject.SetActive(false);
			}
			else if (tableItem.AwakeJobName != string.Empty && tableItem.AwakeJobName != "-")
			{
				ETCImageLoader.LoadSprite(ref this.jobName, tableItem.AwakeJobName, true);
			}
			this.UpdateCurTaskInfo();
		}

		// Token: 0x0600CCDF RID: 52447 RVA: 0x003252B0 File Offset: 0x003236B0
		private void UpdateCurTaskInfo()
		{
			if (this.CurSelTaskIndex < 0 || this.CurSelTaskIndex >= this.TaskList.Count)
			{
				return;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(this.TaskList[this.CurSelTaskIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.taskname.text = tableItem.TaskName;
			if (this.CurSelTaskIndex < this.DoingTaskIndex)
			{
				this.taskstate.text = "完成";
				this.taskIcon.gameObject.GetComponent<UIGray>().enabled = false;
				this.btReceiveAward.gameObject.SetActive(false);
			}
			else if (this.CurSelTaskIndex == this.DoingTaskIndex)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)this.TaskList[this.CurSelTaskIndex], out singleMissionInfo);
				if (singleMissionInfo != null && singleMissionInfo.status == 2)
				{
					this.taskIcon.gameObject.GetComponent<UIGray>().enabled = false;
					this.btReceiveAward.gameObject.SetActive(true);
					this.taskstate.text = "可提交";
				}
				else
				{
					this.taskIcon.gameObject.GetComponent<UIGray>().enabled = true;
					this.btReceiveAward.gameObject.SetActive(false);
					this.taskstate.text = "进行中";
				}
			}
			else
			{
				this.taskstate.text = "未解锁";
				this.taskIcon.gameObject.GetComponent<UIGray>().enabled = true;
				this.btReceiveAward.gameObject.SetActive(false);
			}
			this.taskDes.text = Utility.ParseMissionText(tableItem.ID, true, false, false);
		}

		// Token: 0x0600CCE0 RID: 52448 RVA: 0x0032547C File Offset: 0x0032387C
		public void OnFinishTask(uint iMissionID)
		{
			if (this.eState == ChangeJobState.DoChangeJobTask)
			{
				if (!Utility.IsChangeJobTask(iMissionID))
				{
					return;
				}
			}
			else if (!Utility.IsAwakeTask(iMissionID))
			{
				return;
			}
			if ((ulong)iMissionID != (ulong)((long)this.TaskList[this.CurSelTaskIndex]))
			{
				return;
			}
			this.OnClose();
		}

		// Token: 0x04007740 RID: 30528
		private const int MaxTaskNum = 4;

		// Token: 0x04007741 RID: 30529
		private List<int> TaskList = new List<int>();

		// Token: 0x04007742 RID: 30530
		private int DoingTaskIndex = -1;

		// Token: 0x04007743 RID: 30531
		private int CurSelTaskIndex = -1;

		// Token: 0x04007744 RID: 30532
		private ChangeJobState eState = ChangeJobState.DoAwakeJobTask;

		// Token: 0x04007745 RID: 30533
		[UIControl("titleback/Title", null, 0)]
		protected Image title;

		// Token: 0x04007746 RID: 30534
		[UIControl("role", null, 0)]
		protected Image role;

		// Token: 0x04007747 RID: 30535
		[UIControl("jobback/jobName", null, 0)]
		protected Image jobName;

		// Token: 0x04007748 RID: 30536
		[UIControl("TaskDes/taskname", null, 0)]
		protected Text taskname;

		// Token: 0x04007749 RID: 30537
		[UIControl("TaskDes/taskstate", null, 0)]
		protected Text taskstate;

		// Token: 0x0400774A RID: 30538
		[UIControl("TaskDes/taskIcon", null, 0)]
		protected Image taskIcon;

		// Token: 0x0400774B RID: 30539
		[UIControl("TaskDes/taskDes", null, 0)]
		protected Text taskDes;

		// Token: 0x0400774C RID: 30540
		[UIControl("TaskList/line{0}", typeof(Image), 1)]
		protected Image[] Lines = new Image[3];

		// Token: 0x0400774D RID: 30541
		[UIControl("TaskList/task{0}", typeof(Toggle), 1)]
		protected Toggle[] task = new Toggle[4];

		// Token: 0x0400774E RID: 30542
		[UIControl("TaskList/task{0}/finish", typeof(Image), 1)]
		protected Image[] finish = new Image[4];

		// Token: 0x0400774F RID: 30543
		[UIControl("TaskList/task{0}/cover", typeof(Image), 1)]
		protected Image[] cover = new Image[4];

		// Token: 0x04007750 RID: 30544
		[UIControl("TaskList/task{0}/lock", typeof(Image), 1)]
		protected Image[] Tasklock = new Image[4];

		// Token: 0x04007751 RID: 30545
		[UIControl("btReceiveAward", null, 0)]
		protected Button btReceiveAward;
	}
}
