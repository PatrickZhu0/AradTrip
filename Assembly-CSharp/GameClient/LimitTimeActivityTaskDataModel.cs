using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CE9 RID: 7401
	public class LimitTimeActivityTaskDataModel : ILimitTimeActivityTaskDataModel
	{
		// Token: 0x060122D8 RID: 74456 RVA: 0x0054D53C File Offset: 0x0054B93C
		public LimitTimeActivityTaskDataModel(OpActivityTmpType tmpType, OpActTaskData taskData, OpActTask task, string desc)
		{
			this.DataId = taskData.dataid;
			if (task != null)
			{
				this.State = (OpActTaskState)task.state;
				this.DoneNum = task.curNum;
				this.ParamProgressList = new List<OpActTaskParam>();
				for (int i = 0; i < task.parms.Length; i++)
				{
					this.ParamProgressList.Add(task.parms[i]);
				}
			}
			this.Desc = desc;
			this.TotalNum = taskData.completeNum;
			this.ParamNums = new List<uint>(taskData.variables.Length);
			for (int j = 0; j < taskData.variables.Length; j++)
			{
				this.ParamNums.Add(taskData.variables[j]);
			}
			this.ParamNums2 = new List<uint>(taskData.variables2.Length);
			for (int k = 0; k < taskData.variables2.Length; k++)
			{
				this.ParamNums2.Add(taskData.variables2[k]);
			}
			this.CountParamNums = new List<CounterItem>(taskData.counters.Length);
			for (int l = 0; l < taskData.counters.Length; l++)
			{
				this.CountParamNums.Add(taskData.counters[l]);
			}
			this.AwardDataList = new List<OpTaskReward>(taskData.rewards.Length);
			for (int m = 0; m < taskData.rewards.Length; m++)
			{
				this.AwardDataList.Add(taskData.rewards[m]);
			}
			IActivityDetailDesc activityDetailDesc;
			if (tmpType != OpActivityTmpType.OAT_DAY_COST_ITEM && tmpType != OpActivityTmpType.OAT_COST_ITEM)
			{
				if (tmpType != OpActivityTmpType.OAT_DAY_COMPLETE_DUNG && tmpType != OpActivityTmpType.OAT_COMPLETE_DUNG)
				{
					activityDetailDesc = new ActDetailBaseDesc();
				}
				else
				{
					activityDetailDesc = new ActDetailDungeonDesc();
				}
			}
			else
			{
				activityDetailDesc = new ActDetailItemDesc();
			}
			int count = this.ParamNums.Count;
			int[] array = new int[count + 1];
			array[0] = (int)this.TotalNum;
			for (int n = 1; n <= count; n++)
			{
				array[n] = (int)this.ParamNums[n - 1];
			}
			if (activityDetailDesc != null)
			{
				this.Desc = activityDetailDesc.FormatActivityDesc(this.Desc, array);
			}
			this.taskName = taskData.taskName;
			this.ParamProgress = new List<string>();
			for (int num = 0; num < taskData.varProgressName.Length; num++)
			{
				this.ParamProgress.Add(taskData.varProgressName[num]);
			}
			this.PlayerLevelLimit = taskData.playerLevelLimit;
			this.AccountDailySubmitLimit = (int)taskData.accountDailySubmitLimit;
			this.AccountTotalSubmitLimit = (int)taskData.accountTotalSubmitLimit;
			this.AccountWeeklySubmitLimit = (int)taskData.accountWeeklySubmitLimit;
			this.CantAccept = (int)taskData.cantAccept;
			this.EventType = (int)taskData.eventType;
			this.SubType = (int)taskData.subType;
		}

		// Token: 0x17001EA3 RID: 7843
		// (get) Token: 0x060122D9 RID: 74457 RVA: 0x0054D814 File Offset: 0x0054BC14
		// (set) Token: 0x060122DA RID: 74458 RVA: 0x0054D81C File Offset: 0x0054BC1C
		public uint DataId { get; private set; }

		// Token: 0x17001EA4 RID: 7844
		// (get) Token: 0x060122DB RID: 74459 RVA: 0x0054D825 File Offset: 0x0054BC25
		// (set) Token: 0x060122DC RID: 74460 RVA: 0x0054D82D File Offset: 0x0054BC2D
		public OpActTaskState State { get; private set; }

		// Token: 0x17001EA5 RID: 7845
		// (get) Token: 0x060122DD RID: 74461 RVA: 0x0054D836 File Offset: 0x0054BC36
		// (set) Token: 0x060122DE RID: 74462 RVA: 0x0054D83E File Offset: 0x0054BC3E
		public string Desc { get; private set; }

		// Token: 0x17001EA6 RID: 7846
		// (get) Token: 0x060122DF RID: 74463 RVA: 0x0054D847 File Offset: 0x0054BC47
		// (set) Token: 0x060122E0 RID: 74464 RVA: 0x0054D84F File Offset: 0x0054BC4F
		public uint DoneNum { get; private set; }

		// Token: 0x17001EA7 RID: 7847
		// (get) Token: 0x060122E1 RID: 74465 RVA: 0x0054D858 File Offset: 0x0054BC58
		// (set) Token: 0x060122E2 RID: 74466 RVA: 0x0054D860 File Offset: 0x0054BC60
		public uint TotalNum { get; private set; }

		// Token: 0x17001EA8 RID: 7848
		// (get) Token: 0x060122E3 RID: 74467 RVA: 0x0054D869 File Offset: 0x0054BC69
		// (set) Token: 0x060122E4 RID: 74468 RVA: 0x0054D871 File Offset: 0x0054BC71
		public List<uint> ParamNums { get; private set; }

		// Token: 0x17001EA9 RID: 7849
		// (get) Token: 0x060122E5 RID: 74469 RVA: 0x0054D87A File Offset: 0x0054BC7A
		// (set) Token: 0x060122E6 RID: 74470 RVA: 0x0054D882 File Offset: 0x0054BC82
		public List<uint> ParamNums2 { get; private set; }

		// Token: 0x17001EAA RID: 7850
		// (get) Token: 0x060122E7 RID: 74471 RVA: 0x0054D88B File Offset: 0x0054BC8B
		// (set) Token: 0x060122E8 RID: 74472 RVA: 0x0054D893 File Offset: 0x0054BC93
		public List<CounterItem> CountParamNums { get; private set; }

		// Token: 0x17001EAB RID: 7851
		// (get) Token: 0x060122E9 RID: 74473 RVA: 0x0054D89C File Offset: 0x0054BC9C
		// (set) Token: 0x060122EA RID: 74474 RVA: 0x0054D8A4 File Offset: 0x0054BCA4
		public List<OpTaskReward> AwardDataList { get; private set; }

		// Token: 0x17001EAC RID: 7852
		// (get) Token: 0x060122EB RID: 74475 RVA: 0x0054D8AD File Offset: 0x0054BCAD
		// (set) Token: 0x060122EC RID: 74476 RVA: 0x0054D8B5 File Offset: 0x0054BCB5
		public string taskName { get; private set; }

		// Token: 0x17001EAD RID: 7853
		// (get) Token: 0x060122ED RID: 74477 RVA: 0x0054D8BE File Offset: 0x0054BCBE
		// (set) Token: 0x060122EE RID: 74478 RVA: 0x0054D8C6 File Offset: 0x0054BCC6
		public List<string> ParamProgress { get; private set; }

		// Token: 0x17001EAE RID: 7854
		// (get) Token: 0x060122EF RID: 74479 RVA: 0x0054D8CF File Offset: 0x0054BCCF
		// (set) Token: 0x060122F0 RID: 74480 RVA: 0x0054D8D7 File Offset: 0x0054BCD7
		public List<OpActTaskParam> ParamProgressList { get; private set; }

		// Token: 0x17001EAF RID: 7855
		// (get) Token: 0x060122F1 RID: 74481 RVA: 0x0054D8E0 File Offset: 0x0054BCE0
		// (set) Token: 0x060122F2 RID: 74482 RVA: 0x0054D8E8 File Offset: 0x0054BCE8
		public ushort PlayerLevelLimit { get; private set; }

		// Token: 0x17001EB0 RID: 7856
		// (get) Token: 0x060122F3 RID: 74483 RVA: 0x0054D8F1 File Offset: 0x0054BCF1
		// (set) Token: 0x060122F4 RID: 74484 RVA: 0x0054D8F9 File Offset: 0x0054BCF9
		public int AccountDailySubmitLimit { get; private set; }

		// Token: 0x17001EB1 RID: 7857
		// (get) Token: 0x060122F5 RID: 74485 RVA: 0x0054D902 File Offset: 0x0054BD02
		// (set) Token: 0x060122F6 RID: 74486 RVA: 0x0054D90A File Offset: 0x0054BD0A
		public int AccountTotalSubmitLimit { get; private set; }

		// Token: 0x17001EB2 RID: 7858
		// (get) Token: 0x060122F7 RID: 74487 RVA: 0x0054D913 File Offset: 0x0054BD13
		// (set) Token: 0x060122F8 RID: 74488 RVA: 0x0054D91B File Offset: 0x0054BD1B
		public int AccountWeeklySubmitLimit { get; private set; }

		// Token: 0x17001EB3 RID: 7859
		// (get) Token: 0x060122F9 RID: 74489 RVA: 0x0054D924 File Offset: 0x0054BD24
		// (set) Token: 0x060122FA RID: 74490 RVA: 0x0054D92C File Offset: 0x0054BD2C
		public int CantAccept { get; private set; }

		// Token: 0x17001EB4 RID: 7860
		// (get) Token: 0x060122FB RID: 74491 RVA: 0x0054D935 File Offset: 0x0054BD35
		// (set) Token: 0x060122FC RID: 74492 RVA: 0x0054D93D File Offset: 0x0054BD3D
		public int EventType { get; private set; }

		// Token: 0x17001EB5 RID: 7861
		// (get) Token: 0x060122FD RID: 74493 RVA: 0x0054D946 File Offset: 0x0054BD46
		// (set) Token: 0x060122FE RID: 74494 RVA: 0x0054D94E File Offset: 0x0054BD4E
		public int SubType { get; private set; }
	}
}
