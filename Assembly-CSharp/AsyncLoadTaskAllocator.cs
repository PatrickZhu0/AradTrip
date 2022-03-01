using System;
using System.Collections.Generic;

// Token: 0x020000D3 RID: 211
public class AsyncLoadTaskAllocator<T, Q> : Singleton<AsyncLoadTaskAllocator<T, Q>> where T : class, IAsyncLoadWrapper<Q>, new() where Q : class
{
	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000474 RID: 1140 RVA: 0x0001EB25 File Offset: 0x0001CF25
	// (set) Token: 0x06000475 RID: 1141 RVA: 0x0001EB2D File Offset: 0x0001CF2D
	public int RunningTaskLimit
	{
		get
		{
			return this.m_RunningTaskLimit;
		}
		set
		{
			this.m_RunningTaskLimit = value;
			this.m_RunningTaskLimit = (int)IntMath.Clamp((long)this.m_RunningTaskLimit, 1L, 64L);
		}
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x06000476 RID: 1142 RVA: 0x0001EB4E File Offset: 0x0001CF4E
	public int RunningTaskCount
	{
		get
		{
			return this.m_RunningTaskCount;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x06000477 RID: 1143 RVA: 0x0001EB56 File Offset: 0x0001CF56
	public int LoadedTaskCount
	{
		get
		{
			return this.m_LoadedTaskCount;
		}
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0001EB60 File Offset: 0x0001CF60
	public bool IsResInAsyncLoading(string path)
	{
		int hashCode = path.GetHashCode();
		AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord = this._GetAssetRecordByName(hashCode);
		return asyncLoadTaskRecord != null && asyncLoadTaskRecord.m_LoadTaskCnt > 0;
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0001EB8D File Offset: 0x0001CF8D
	public bool IsResAsyncLoading()
	{
		return this.m_AsyncLoadingList.Count > 0 || this.m_RunningTaskCount > 0;
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x0001EBAC File Offset: 0x0001CFAC
	protected AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord _AllocateAsyncRecord()
	{
		if (this.m_AsyncRecordPool.Count > 0)
		{
			int index = this.m_AsyncRecordPool.Count - 1;
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord = this.m_AsyncRecordPool[index];
			this.m_AsyncRecordPool.RemoveAt(index);
			asyncLoadTaskRecord.m_LoadTaskHashCode = -1;
			asyncLoadTaskRecord.m_LoadTaskCnt = 0;
			return asyncLoadTaskRecord;
		}
		return new AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord();
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x0001EC08 File Offset: 0x0001D008
	protected AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord _GetAssetRecordByName(int hashCode)
	{
		int i = 0;
		int count = this.m_AsyncLoadingList.Count;
		while (i < count)
		{
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord = this.m_AsyncLoadingList[i];
			if (asyncLoadTaskRecord != null)
			{
				if (asyncLoadTaskRecord.m_LoadTaskHashCode == hashCode)
				{
					return asyncLoadTaskRecord;
				}
			}
			i++;
		}
		return null;
	}

	// Token: 0x0600047C RID: 1148 RVA: 0x0001EC5C File Offset: 0x0001D05C
	public AsyncLoadRequest<Q> AllocAsyncTask(string resPath, AsyncLoadData asyncLoadData, bool highPriority)
	{
		AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask asyncLoadTask = null;
		if (this.m_IdleTaskPool.Count > 0)
		{
			asyncLoadTask = this.m_IdleTaskPool[0];
			this.m_IdleTaskPool.RemoveAt(0);
		}
		if (asyncLoadTask == null)
		{
			asyncLoadTask = new AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask();
		}
		asyncLoadTask.m_RequestWrapper.Reset();
		asyncLoadTask.m_LoadRequest.Reset();
		asyncLoadTask.m_FrameCnt = 0U;
		asyncLoadTask.m_LoadRequest.m_ResPath = resPath;
		asyncLoadTask.m_RequestData = asyncLoadData;
		asyncLoadTask.m_AsyncLoadPath = resPath;
		asyncLoadTask.m_HighPriority = highPriority;
		asyncLoadTask.m_AsyncLoadHashCode = resPath.GetHashCode();
		this.m_AsyncLoadTaskQueue.Add(asyncLoadTask);
		return asyncLoadTask.m_LoadRequest;
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0001ED00 File Offset: 0x0001D100
	public AsyncLoadRequest<Q> AllocAsyncTaskWithTarget(Q resLoaded, string resPath, bool highPriority)
	{
		AsyncLoadRequest<Q> asyncLoadRequest = this.AllocAsyncTask(resPath, null, highPriority);
		asyncLoadRequest.m_ResObject = resLoaded;
		asyncLoadRequest.m_ResPath = resPath;
		asyncLoadRequest.m_IsDone = true;
		asyncLoadRequest.m_Extracted = false;
		return asyncLoadRequest;
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600047E RID: 1150 RVA: 0x0001ED34 File Offset: 0x0001D134
	public int CompleteTaskCount
	{
		get
		{
			return this.m_CompleteTaskQueue.Count;
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600047F RID: 1151 RVA: 0x0001ED41 File Offset: 0x0001D141
	public int LoadingTaskCount
	{
		get
		{
			return this.m_AsyncLoadTaskQueue.Count;
		}
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0001ED50 File Offset: 0x0001D150
	public void Update()
	{
		int i = 0;
		int num = this.m_AsyncLoadTaskQueue.Count;
		while (i < num)
		{
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask asyncLoadTask = this.m_AsyncLoadTaskQueue[i];
			if (asyncLoadTask == null || asyncLoadTask.m_LoadRequest.IsDone())
			{
				goto IL_156;
			}
			if (asyncLoadTask.m_RequestWrapper.InLoading())
			{
				if (asyncLoadTask.m_RequestWrapper.IsDone())
				{
					this._ReleaseResloadRecord(asyncLoadTask.m_AsyncLoadHashCode);
					asyncLoadTask.OnTaskFinish();
					this.m_RunningTaskCount--;
					this.m_CompleteTaskQueue.Add(asyncLoadTask);
					goto IL_156;
				}
			}
			else
			{
				if (asyncLoadTask.m_AsyncLoadPath == null)
				{
					goto IL_156;
				}
				asyncLoadTask.m_RequestWrapper.Prepare(asyncLoadTask.m_AsyncLoadPath, asyncLoadTask.m_RequestData);
				if (asyncLoadTask.m_LoadRequest.m_IsAbort)
				{
					asyncLoadTask.m_RequestWrapper.OnAbort();
					goto IL_156;
				}
				if (asyncLoadTask.m_RequestWrapper.IsReady())
				{
					if (this.m_RunningTaskCount < this.m_RunningTaskLimit || asyncLoadTask.m_HighPriority)
					{
						if (1U <= asyncLoadTask.m_FrameCnt)
						{
							this.m_RunningTaskCount++;
							this.m_LoadedTaskCount++;
							asyncLoadTask.m_RequestWrapper.DoLoad();
							this._AddResloadRecord(asyncLoadTask.m_AsyncLoadHashCode);
						}
						else
						{
							asyncLoadTask.m_FrameCnt += 1U;
						}
					}
				}
			}
			IL_16A:
			i++;
			continue;
			IL_156:
			this.m_AsyncLoadTaskQueue.RemoveAt(i);
			i--;
			num--;
			goto IL_16A;
		}
		int j = 0;
		int num2 = this.m_CompleteTaskQueue.Count;
		while (j < num2)
		{
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask asyncLoadTask2 = this.m_CompleteTaskQueue[j];
			if (asyncLoadTask2 == null)
			{
				goto IL_207;
			}
			if (asyncLoadTask2.m_LoadRequest.m_Extracted || asyncLoadTask2.m_LoadRequest.m_IsAbort)
			{
				if (asyncLoadTask2.m_LoadRequest.m_IsAbort)
				{
					asyncLoadTask2.m_RequestWrapper.OnAbort();
				}
				asyncLoadTask2.m_LoadRequest.Reset();
				asyncLoadTask2.m_RequestWrapper.Reset();
				this.m_IdleTaskPool.Add(asyncLoadTask2);
				goto IL_207;
			}
			IL_21D:
			j++;
			continue;
			IL_207:
			this.m_CompleteTaskQueue.RemoveAt(j);
			j--;
			num2--;
			goto IL_21D;
		}
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0001EF86 File Offset: 0x0001D386
	public void ClearWaitingQueue()
	{
		this.m_AsyncLoadTaskQueue.Clear();
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0001EF94 File Offset: 0x0001D394
	public void ClearFinishQueue()
	{
		int i = 0;
		int count = this.m_CompleteTaskQueue.Count;
		while (i < count)
		{
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask asyncLoadTask = this.m_CompleteTaskQueue[i];
			if (asyncLoadTask != null && asyncLoadTask.m_RequestWrapper != null)
			{
				asyncLoadTask.m_RequestWrapper.OnAbort();
				asyncLoadTask.m_LoadRequest.Reset();
				asyncLoadTask.m_RequestWrapper.Reset();
			}
			i++;
		}
		this.m_CompleteTaskQueue.Clear();
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0001F00C File Offset: 0x0001D40C
	protected void _ReleaseResloadRecord(int resCode)
	{
		AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord = this._GetAssetRecordByName(resCode);
		if (asyncLoadTaskRecord != null)
		{
			if (asyncLoadTaskRecord.m_LoadTaskCnt > 0)
			{
				asyncLoadTaskRecord.m_LoadTaskCnt--;
			}
			if (asyncLoadTaskRecord.m_LoadTaskCnt == 0)
			{
				this.m_AsyncRecordPool.Add(asyncLoadTaskRecord);
				this.m_AsyncLoadingList.Remove(asyncLoadTaskRecord);
			}
		}
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0001F06C File Offset: 0x0001D46C
	protected void _AddResloadRecord(int resCode)
	{
		AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord = this._GetAssetRecordByName(resCode);
		if (asyncLoadTaskRecord != null)
		{
			asyncLoadTaskRecord.m_LoadTaskCnt++;
		}
		else
		{
			AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord asyncLoadTaskRecord2 = this._AllocateAsyncRecord();
			asyncLoadTaskRecord2.m_LoadTaskHashCode = resCode;
			asyncLoadTaskRecord2.m_LoadTaskCnt = 1;
			this.m_AsyncLoadingList.Add(asyncLoadTaskRecord2);
		}
	}

	// Token: 0x04000409 RID: 1033
	public static readonly AsyncLoadRequest<Q> INVALID_LOAD_REQUEST = new AsyncLoadRequest<Q>();

	// Token: 0x0400040A RID: 1034
	private List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask> m_AsyncLoadTaskQueue = new List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask>();

	// Token: 0x0400040B RID: 1035
	private List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask> m_CompleteTaskQueue = new List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask>();

	// Token: 0x0400040C RID: 1036
	private List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask> m_IdleTaskPool = new List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTask>();

	// Token: 0x0400040D RID: 1037
	private List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord> m_AsyncLoadingList = new List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord>();

	// Token: 0x0400040E RID: 1038
	private List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord> m_AsyncRecordPool = new List<AsyncLoadTaskAllocator<T, Q>.AsyncLoadTaskRecord>();

	// Token: 0x0400040F RID: 1039
	private int m_RunningTaskLimit = 4;

	// Token: 0x04000410 RID: 1040
	private int m_RunningTaskCount;

	// Token: 0x04000411 RID: 1041
	private int m_LoadedTaskCount;

	// Token: 0x020000D4 RID: 212
	protected class AsyncLoadTask
	{
		// Token: 0x06000487 RID: 1159 RVA: 0x0001F0F4 File Offset: 0x0001D4F4
		public void OnTaskFinish()
		{
			this.m_LoadRequest.Encase(this.m_RequestWrapper.Extract());
			this.m_AsyncLoadPath = null;
			this.m_AsyncLoadHashCode = -1;
			this.m_RequestData = null;
			this.m_RequestWrapper.Reset();
			this.m_HighPriority = false;
			this.m_FrameCnt = 0U;
		}

		// Token: 0x04000412 RID: 1042
		public IAsyncLoadWrapper<Q> m_RequestWrapper = Activator.CreateInstance<T>();

		// Token: 0x04000413 RID: 1043
		public AsyncLoadRequest<Q> m_LoadRequest = new AsyncLoadRequest<Q>();

		// Token: 0x04000414 RID: 1044
		public AsyncLoadData m_RequestData;

		// Token: 0x04000415 RID: 1045
		public string m_AsyncLoadPath;

		// Token: 0x04000416 RID: 1046
		public int m_AsyncLoadHashCode = -1;

		// Token: 0x04000417 RID: 1047
		public uint m_FrameCnt;

		// Token: 0x04000418 RID: 1048
		public bool m_HighPriority;
	}

	// Token: 0x020000D5 RID: 213
	protected class AsyncLoadTaskRecord
	{
		// Token: 0x04000419 RID: 1049
		public int m_LoadTaskHashCode = -1;

		// Token: 0x0400041A RID: 1050
		public int m_LoadTaskCnt;
	}
}
