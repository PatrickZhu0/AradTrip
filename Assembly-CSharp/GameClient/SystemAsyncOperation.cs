using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DDD RID: 3549
	public class SystemAsyncOperation : IASyncOperation
	{
		// Token: 0x06008F3A RID: 36666 RVA: 0x001A8366 File Offset: 0x001A6766
		public float GetProgress()
		{
			return this.Progress;
		}

		// Token: 0x06008F3B RID: 36667 RVA: 0x001A836E File Offset: 0x001A676E
		public void SetError(string ErrorMsg)
		{
			this.m_errorMsg = ErrorMsg;
			this.m_isError = true;
		}

		// Token: 0x06008F3C RID: 36668 RVA: 0x001A837E File Offset: 0x001A677E
		public void SetProgressInfo(string info)
		{
			this.m_progressInfo = info;
		}

		// Token: 0x06008F3D RID: 36669 RVA: 0x001A8387 File Offset: 0x001A6787
		public string GetProgressInfo()
		{
			return this.m_progressInfo;
		}

		// Token: 0x06008F3E RID: 36670 RVA: 0x001A838F File Offset: 0x001A678F
		public string GetErrorMessage()
		{
			return this.m_errorMsg;
		}

		// Token: 0x06008F3F RID: 36671 RVA: 0x001A8397 File Offset: 0x001A6797
		public bool IsError()
		{
			return this.m_isError;
		}

		// Token: 0x170018D9 RID: 6361
		// (get) Token: 0x06008F40 RID: 36672 RVA: 0x001A839F File Offset: 0x001A679F
		public int currentTaskIndex
		{
			get
			{
				return this.m_currentTask;
			}
		}

		// Token: 0x170018DA RID: 6362
		// (get) Token: 0x06008F41 RID: 36673 RVA: 0x001A83A8 File Offset: 0x001A67A8
		public float Progress
		{
			get
			{
				float num = 0f;
				if (this.m_taskInfos.Count <= 0)
				{
					num = 1f;
				}
				else
				{
					for (int i = 0; i < this.m_taskInfos.Count; i++)
					{
						SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[i];
						if (taskInfo.State == SystemAsyncOperation.ETaskState.Done)
						{
							num += taskInfo.Weight;
						}
						else
						{
							if (taskInfo.State != SystemAsyncOperation.ETaskState.Loading)
							{
								break;
							}
							num += taskInfo.Weight * taskInfo.Progress;
						}
					}
					num /= this.m_maxProgress;
				}
				return Mathf.Clamp(num, 0f, 1f);
			}
		}

		// Token: 0x170018DB RID: 6363
		// (get) Token: 0x06008F42 RID: 36674 RVA: 0x001A8458 File Offset: 0x001A6858
		public string Description
		{
			get
			{
				for (int i = 0; i < this.m_taskInfos.Count; i++)
				{
					SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[i];
					if (taskInfo.State == SystemAsyncOperation.ETaskState.Loading)
					{
						return taskInfo.Name;
					}
				}
				return string.Empty;
			}
		}

		// Token: 0x06008F43 RID: 36675 RVA: 0x001A84A5 File Offset: 0x001A68A5
		public void ReInit()
		{
			this.m_taskInfos.Clear();
			this.m_maxProgress = 0f;
			this.m_progressDelta = 0f;
			this.m_currentTask = 0;
			this.m_isError = false;
			this.m_errorMsg = string.Empty;
		}

		// Token: 0x06008F44 RID: 36676 RVA: 0x001A84E1 File Offset: 0x001A68E1
		public void AddTask(string name, float weight = 1f)
		{
			this.m_taskInfos.Add(new SystemAsyncOperation.TaskInfo(name, weight));
			this.m_maxProgress += weight;
		}

		// Token: 0x06008F45 RID: 36677 RVA: 0x001A8504 File Offset: 0x001A6904
		public void SetProgress(float progress)
		{
			if (this.currentTaskIndex < 0 || this.currentTaskIndex >= this.m_taskInfos.Count)
			{
				Logger.LogErrorFormat("[SystemAsyncOperation Error!!]_SetTaskProgress CurrentTask out range {0}  0-{1}!!", new object[]
				{
					this.currentTaskIndex,
					this.m_taskInfos.Count - 1
				});
			}
			progress = Mathf.Clamp(progress, 0f, 1f);
			SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[this.currentTaskIndex];
			if (taskInfo.State != SystemAsyncOperation.ETaskState.Loading)
			{
				Logger.LogErrorFormat("[SystemAsyncOperation Error!!]_SetTaskProgress Error State {0} Index {1} Name{2}!!", new object[]
				{
					taskInfo.State,
					this.currentTaskIndex,
					taskInfo.Name
				});
			}
			if (progress < taskInfo.Progress)
			{
				Logger.LogErrorFormat("[SystemAsyncOperation Error!!]_SetTaskProgress ==> progress error!! Index:{0} Name:{2} progress:{1}", new object[]
				{
					this.currentTaskIndex,
					progress,
					taskInfo.Name
				});
				return;
			}
			this.m_progressDelta += (progress - taskInfo.Progress) * taskInfo.Weight;
			taskInfo.Progress = progress;
		}

		// Token: 0x06008F46 RID: 36678 RVA: 0x001A862C File Offset: 0x001A6A2C
		public void SetTaskDesc(string description)
		{
			bool flag = false;
			for (int i = 0; i < this.m_taskInfos.Count; i++)
			{
				SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[i];
				if (taskInfo.State == SystemAsyncOperation.ETaskState.Loading)
				{
					taskInfo.Name = description;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Logger.LogError("_SetTaskDesc Error!!! No Loading Task");
			}
		}

		// Token: 0x06008F47 RID: 36679 RVA: 0x001A8690 File Offset: 0x001A6A90
		public void BeginTask(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.m_taskInfos.Count)
			{
				SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[iIndex];
				this.m_currentTask = iIndex;
				if (taskInfo.State != SystemAsyncOperation.ETaskState.NotStart)
				{
					Logger.LogErrorFormat("[SystemAsyncOperation Error!!]try begin task: Error State {0} index:{1} Name:{2}!!", new object[]
					{
						taskInfo.State,
						iIndex,
						taskInfo.Name
					});
				}
				else
				{
					taskInfo.Progress = 0f;
					taskInfo.State = SystemAsyncOperation.ETaskState.Loading;
				}
			}
			else
			{
				Logger.LogErrorFormat("[SystemAsyncOperation Error!!]try begin task: {0} OutRange 0 - {1}, !!", new object[]
				{
					iIndex,
					this.m_taskInfos.Count - 1
				});
			}
		}

		// Token: 0x06008F48 RID: 36680 RVA: 0x001A8750 File Offset: 0x001A6B50
		public void FinishTask(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.m_taskInfos.Count)
			{
				SystemAsyncOperation.TaskInfo taskInfo = this.m_taskInfos[iIndex];
				this.m_currentTask = iIndex;
				if (taskInfo.State != SystemAsyncOperation.ETaskState.Loading)
				{
					Logger.LogErrorFormat("[SystemAsyncOperation Error!!]try finish task: Error State {0} index:{1} Name:{2}!!", new object[]
					{
						taskInfo.State,
						iIndex,
						taskInfo.Name
					});
				}
				else
				{
					taskInfo.Progress = 1f;
					taskInfo.State = SystemAsyncOperation.ETaskState.Done;
				}
			}
			else
			{
				Logger.LogErrorFormat("[SystemAsyncOperation Error!!]try finish task: {0} OutRange 0 - {1}, !!", new object[]
				{
					iIndex,
					this.m_taskInfos.Count - 1
				});
			}
		}

		// Token: 0x0400470A RID: 18186
		private bool m_isError;

		// Token: 0x0400470B RID: 18187
		private string m_errorMsg;

		// Token: 0x0400470C RID: 18188
		private string m_progressInfo;

		// Token: 0x0400470D RID: 18189
		private int m_currentTask;

		// Token: 0x0400470E RID: 18190
		private List<SystemAsyncOperation.TaskInfo> m_taskInfos = new List<SystemAsyncOperation.TaskInfo>();

		// Token: 0x0400470F RID: 18191
		private float m_maxProgress;

		// Token: 0x04004710 RID: 18192
		private float m_progressDelta;

		// Token: 0x02000DDE RID: 3550
		private enum ETaskState
		{
			// Token: 0x04004712 RID: 18194
			NotStart = -1,
			// Token: 0x04004713 RID: 18195
			Loading,
			// Token: 0x04004714 RID: 18196
			Done
		}

		// Token: 0x02000DDF RID: 3551
		private class TaskInfo
		{
			// Token: 0x06008F49 RID: 36681 RVA: 0x001A880E File Offset: 0x001A6C0E
			public TaskInfo(string name, float weight)
			{
				this.Name = name;
				this.Weight = weight;
				this.Progress = 0f;
				this.State = SystemAsyncOperation.ETaskState.NotStart;
			}

			// Token: 0x04004715 RID: 18197
			public string Name;

			// Token: 0x04004716 RID: 18198
			public float Weight;

			// Token: 0x04004717 RID: 18199
			public float Progress;

			// Token: 0x04004718 RID: 18200
			public SystemAsyncOperation.ETaskState State;
		}
	}
}
