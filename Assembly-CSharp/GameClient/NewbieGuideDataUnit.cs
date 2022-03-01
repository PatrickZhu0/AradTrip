using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200105E RID: 4190
	[LoggerModel("NewbieGuide")]
	public class NewbieGuideDataUnit
	{
		// Token: 0x06009D38 RID: 40248 RVA: 0x001E8E2A File Offset: 0x001E722A
		public NewbieGuideDataUnit(int tid)
		{
			this.taskId = (NewbieGuideTable.eNewbieGuideTask)tid;
			this.savePoint = 0;
			this.finished = false;
		}

		// Token: 0x06009D39 RID: 40249 RVA: 0x001E8E68 File Offset: 0x001E7268
		public void ClearData()
		{
			this.guideType = NewbieGuideTable.eNewbieGuideType.NGT_None;
			this.taskId = NewbieGuideTable.eNewbieGuideTask.None;
			this.savePoint = 0;
			this.finished = false;
			this.AlreadySend = false;
			if (this.newbieComList != null)
			{
				this.newbieComList.Clear();
			}
			if (this.newbieConditionList != null)
			{
				this.newbieConditionList.Clear();
			}
			if (this.NeedSaveParamsList != null)
			{
				this.NeedSaveParamsList.Clear();
			}
		}

		// Token: 0x06009D3A RID: 40250 RVA: 0x001E8EDA File Offset: 0x001E72DA
		public virtual void LoadEvent()
		{
		}

		// Token: 0x06009D3B RID: 40251 RVA: 0x001E8EDC File Offset: 0x001E72DC
		public virtual void Unloadevent()
		{
		}

		// Token: 0x06009D3C RID: 40252 RVA: 0x001E8EDE File Offset: 0x001E72DE
		public void Init()
		{
			this.LoadEvent();
			this.InitContent();
			this.InitCondition();
		}

		// Token: 0x06009D3D RID: 40253 RVA: 0x001E8EF2 File Offset: 0x001E72F2
		public virtual void InitContent()
		{
		}

		// Token: 0x06009D3E RID: 40254 RVA: 0x001E8EF4 File Offset: 0x001E72F4
		public virtual void InitCondition()
		{
		}

		// Token: 0x06009D3F RID: 40255 RVA: 0x001E8EF6 File Offset: 0x001E72F6
		protected void AddContent(ComNewbieData data)
		{
			if (data != null)
			{
				this.newbieComList.Add(data);
			}
		}

		// Token: 0x06009D40 RID: 40256 RVA: 0x001E8F0A File Offset: 0x001E730A
		protected void AddCondition(NewbieConditionData condition)
		{
			if (condition != null)
			{
				this.newbieConditionList.Add(condition);
			}
		}

		// Token: 0x06009D41 RID: 40257 RVA: 0x001E8F20 File Offset: 0x001E7320
		public bool CheckAllCondition(UIEvent uiEvent)
		{
			if (this.finished)
			{
				return false;
			}
			this.NeedSaveParamsList.Clear();
			if (this.taskId == NewbieGuideTable.eNewbieGuideTask.AutoFightGuide)
			{
			}
			for (int i = 0; i < this.newbieConditionList.Count; i++)
			{
				NewbieConditionData newbieConditionData = this.newbieConditionList[i];
				if (!NewbieGuideConditionUtil.CheckCondition(this.taskId, uiEvent, newbieConditionData, newbieConditionData.condition, ref this.NeedSaveParamsList, newbieConditionData.LimitArgsList))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009D42 RID: 40258 RVA: 0x001E8FA4 File Offset: 0x001E73A4
		public void Start()
		{
			this.OnStart();
		}

		// Token: 0x06009D43 RID: 40259 RVA: 0x001E8FAC File Offset: 0x001E73AC
		public void UnitFinish()
		{
			if (!this.finished)
			{
				this.finished = true;
				this.Unloadevent();
				this.OnFinish();
			}
		}

		// Token: 0x06009D44 RID: 40260 RVA: 0x001E8FCC File Offset: 0x001E73CC
		protected virtual void OnStart()
		{
		}

		// Token: 0x06009D45 RID: 40261 RVA: 0x001E8FCE File Offset: 0x001E73CE
		protected virtual void OnFinish()
		{
		}

		// Token: 0x0400561A RID: 22042
		public NewbieGuideManager manager;

		// Token: 0x0400561B RID: 22043
		public NewbieGuideTable.eNewbieGuideType guideType;

		// Token: 0x0400561C RID: 22044
		public NewbieGuideTable.eNewbieGuideTask taskId;

		// Token: 0x0400561D RID: 22045
		public int savePoint;

		// Token: 0x0400561E RID: 22046
		public bool finished;

		// Token: 0x0400561F RID: 22047
		public bool AlreadySend;

		// Token: 0x04005620 RID: 22048
		public List<ComNewbieData> newbieComList = new List<ComNewbieData>();

		// Token: 0x04005621 RID: 22049
		public List<NewbieConditionData> newbieConditionList = new List<NewbieConditionData>();

		// Token: 0x04005622 RID: 22050
		public List<object> NeedSaveParamsList = new List<object>();
	}
}
