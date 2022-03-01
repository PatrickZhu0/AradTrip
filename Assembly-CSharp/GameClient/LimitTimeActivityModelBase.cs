using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CE6 RID: 7398
	public abstract class LimitTimeActivityModelBase
	{
		// Token: 0x0601229A RID: 74394 RVA: 0x0054CF58 File Offset: 0x0054B358
		protected LimitTimeActivityModelBase(OpActivityData msg, string itemPath, string logoPath = null, string noteBgPath = null, string notePrefabPath = null)
		{
			if (msg == null)
			{
				return;
			}
			this.Id = msg.dataId;
			this.Name = msg.name;
			this.RuleDesc = msg.ruleDesc;
			this.LogoDesc = msg.logoDesc.Replace("|", "\n");
			this.State = (OpActivityState)msg.state;
			this.Desc = msg.desc;
			if (!string.IsNullOrEmpty(logoPath))
			{
				this.LogoPath = logoPath;
			}
			else
			{
				this.LogoPath = msg.logoPath;
			}
			this.ItemPath = itemPath;
			this.StartTime = msg.startTime;
			this.EndTime = msg.endTime;
			this.NoteBgPath = noteBgPath;
			this.NotePrefabPath = notePrefabPath;
			this.Param = msg.parm;
			this.ParamArray = msg.parm2;
			this.ParamArray2 = msg.parm3;
			this.CountParam = msg.countParam;
			this.StrParam = msg.strParams;
			this.TaskDatas = new List<ILimitTimeActivityTaskDataModel>();
			this.ActivityPrefafPath = msg.prefabPath;
		}

		// Token: 0x17001E7D RID: 7805
		// (get) Token: 0x0601229B RID: 74395 RVA: 0x0054D06E File Offset: 0x0054B46E
		// (set) Token: 0x0601229C RID: 74396 RVA: 0x0054D076 File Offset: 0x0054B476
		public uint Id { get; private set; }

		// Token: 0x17001E7E RID: 7806
		// (get) Token: 0x0601229D RID: 74397 RVA: 0x0054D07F File Offset: 0x0054B47F
		// (set) Token: 0x0601229E RID: 74398 RVA: 0x0054D087 File Offset: 0x0054B487
		public uint StartTime { get; private set; }

		// Token: 0x17001E7F RID: 7807
		// (get) Token: 0x0601229F RID: 74399 RVA: 0x0054D090 File Offset: 0x0054B490
		// (set) Token: 0x060122A0 RID: 74400 RVA: 0x0054D098 File Offset: 0x0054B498
		public uint EndTime { get; private set; }

		// Token: 0x17001E80 RID: 7808
		// (get) Token: 0x060122A1 RID: 74401 RVA: 0x0054D0A1 File Offset: 0x0054B4A1
		// (set) Token: 0x060122A2 RID: 74402 RVA: 0x0054D0A9 File Offset: 0x0054B4A9
		public string RuleDesc { get; private set; }

		// Token: 0x17001E81 RID: 7809
		// (get) Token: 0x060122A3 RID: 74403 RVA: 0x0054D0B2 File Offset: 0x0054B4B2
		// (set) Token: 0x060122A4 RID: 74404 RVA: 0x0054D0BA File Offset: 0x0054B4BA
		public string LogoDesc { get; private set; }

		// Token: 0x17001E82 RID: 7810
		// (get) Token: 0x060122A5 RID: 74405 RVA: 0x0054D0C3 File Offset: 0x0054B4C3
		// (set) Token: 0x060122A6 RID: 74406 RVA: 0x0054D0CB File Offset: 0x0054B4CB
		public string Desc { get; private set; }

		// Token: 0x17001E83 RID: 7811
		// (get) Token: 0x060122A7 RID: 74407 RVA: 0x0054D0D4 File Offset: 0x0054B4D4
		// (set) Token: 0x060122A8 RID: 74408 RVA: 0x0054D0DC File Offset: 0x0054B4DC
		public string LogoPath { get; private set; }

		// Token: 0x17001E84 RID: 7812
		// (get) Token: 0x060122A9 RID: 74409 RVA: 0x0054D0E5 File Offset: 0x0054B4E5
		// (set) Token: 0x060122AA RID: 74410 RVA: 0x0054D0ED File Offset: 0x0054B4ED
		public string NoteBgPath { get; private set; }

		// Token: 0x17001E85 RID: 7813
		// (get) Token: 0x060122AB RID: 74411 RVA: 0x0054D0F6 File Offset: 0x0054B4F6
		// (set) Token: 0x060122AC RID: 74412 RVA: 0x0054D0FE File Offset: 0x0054B4FE
		public string NotePrefabPath { get; private set; }

		// Token: 0x17001E86 RID: 7814
		// (get) Token: 0x060122AD RID: 74413 RVA: 0x0054D107 File Offset: 0x0054B507
		// (set) Token: 0x060122AE RID: 74414 RVA: 0x0054D10F File Offset: 0x0054B50F
		public string ItemPath { get; private set; }

		// Token: 0x17001E87 RID: 7815
		// (get) Token: 0x060122AF RID: 74415 RVA: 0x0054D118 File Offset: 0x0054B518
		// (set) Token: 0x060122B0 RID: 74416 RVA: 0x0054D120 File Offset: 0x0054B520
		public OpActivityState State { get; set; }

		// Token: 0x17001E88 RID: 7816
		// (get) Token: 0x060122B1 RID: 74417 RVA: 0x0054D129 File Offset: 0x0054B529
		// (set) Token: 0x060122B2 RID: 74418 RVA: 0x0054D131 File Offset: 0x0054B531
		public string Name { get; private set; }

		// Token: 0x17001E89 RID: 7817
		// (get) Token: 0x060122B3 RID: 74419 RVA: 0x0054D13A File Offset: 0x0054B53A
		// (set) Token: 0x060122B4 RID: 74420 RVA: 0x0054D142 File Offset: 0x0054B542
		public uint Param { get; private set; }

		// Token: 0x17001E8A RID: 7818
		// (get) Token: 0x060122B5 RID: 74421 RVA: 0x0054D14B File Offset: 0x0054B54B
		// (set) Token: 0x060122B6 RID: 74422 RVA: 0x0054D153 File Offset: 0x0054B553
		public uint[] ParamArray { get; private set; }

		// Token: 0x17001E8B RID: 7819
		// (get) Token: 0x060122B7 RID: 74423 RVA: 0x0054D15C File Offset: 0x0054B55C
		// (set) Token: 0x060122B8 RID: 74424 RVA: 0x0054D164 File Offset: 0x0054B564
		public uint[] ParamArray2 { get; private set; }

		// Token: 0x17001E8C RID: 7820
		// (get) Token: 0x060122B9 RID: 74425 RVA: 0x0054D16D File Offset: 0x0054B56D
		// (set) Token: 0x060122BA RID: 74426 RVA: 0x0054D175 File Offset: 0x0054B575
		public string CountParam { get; set; }

		// Token: 0x17001E8D RID: 7821
		// (get) Token: 0x060122BB RID: 74427 RVA: 0x0054D17E File Offset: 0x0054B57E
		// (set) Token: 0x060122BC RID: 74428 RVA: 0x0054D186 File Offset: 0x0054B586
		public string[] StrParam { get; set; }

		// Token: 0x17001E8E RID: 7822
		// (get) Token: 0x060122BD RID: 74429 RVA: 0x0054D18F File Offset: 0x0054B58F
		// (set) Token: 0x060122BE RID: 74430 RVA: 0x0054D197 File Offset: 0x0054B597
		public List<ILimitTimeActivityTaskDataModel> TaskDatas { get; private set; }

		// Token: 0x17001E8F RID: 7823
		// (get) Token: 0x060122BF RID: 74431 RVA: 0x0054D1A0 File Offset: 0x0054B5A0
		// (set) Token: 0x060122C0 RID: 74432 RVA: 0x0054D1A8 File Offset: 0x0054B5A8
		public string ActivityPrefafPath { get; private set; }

		// Token: 0x060122C1 RID: 74433 RVA: 0x0054D1B4 File Offset: 0x0054B5B4
		public void SortTaskByState()
		{
			this.mIsSortByState = true;
			if (this.TaskDatas == null)
			{
				return;
			}
			List<ILimitTimeActivityTaskDataModel> list = new List<ILimitTimeActivityTaskDataModel>();
			List<ILimitTimeActivityTaskDataModel> list2 = new List<ILimitTimeActivityTaskDataModel>();
			for (int i = 0; i < this.TaskDatas.Count; i++)
			{
				if (this.TaskDatas[i].State == OpActTaskState.OATS_OVER)
				{
					list.Add(this.TaskDatas[i]);
				}
				else
				{
					list2.Add(this.TaskDatas[i]);
				}
			}
			this.TaskDatas.Clear();
			this.TaskDatas.AddRange(list2);
			this.TaskDatas.AddRange(list);
		}

		// Token: 0x060122C2 RID: 74434 RVA: 0x0054D260 File Offset: 0x0054B660
		protected virtual int _CompareTask(ILimitTimeActivityTaskDataModel task1, ILimitTimeActivityTaskDataModel task2)
		{
			if (task1.State == task2.State)
			{
				return (task1.DataId >= task2.DataId) ? 1 : -1;
			}
			if (task1.State == OpActTaskState.OATS_OVER)
			{
				return 1;
			}
			if (task1.State == OpActTaskState.OATS_FINISHED)
			{
				return -1;
			}
			return -1;
		}

		// Token: 0x0400BD37 RID: 48439
		protected bool mIsSortByState;
	}
}
