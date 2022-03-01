using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001824 RID: 6180
	public sealed class ArborDayActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F359 RID: 62297 RVA: 0x0041C6B9 File Offset: 0x0041AAB9
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			this.InitArborDayActivityInfo();
			this.BindUiEvents();
		}

		// Token: 0x0600F35A RID: 62298 RVA: 0x0041C6D0 File Offset: 0x0041AAD0
		private void InitArborDayActivityInfo()
		{
			if (this.mDataModel == null || this.mDataModel.StrParam == null || this.mDataModel.StrParam.Length != 4)
			{
				return;
			}
			this._treePlantStateStr = this.mDataModel.StrParam[2];
		}

		// Token: 0x0600F35B RID: 62299 RVA: 0x0041C71F File Offset: 0x0041AB1F
		public override void Dispose()
		{
			base.Dispose();
			this.UnBindUiEvents();
		}

		// Token: 0x0600F35C RID: 62300 RVA: 0x0041C72D File Offset: 0x0041AB2D
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ArborDayActivity";
		}

		// Token: 0x0600F35D RID: 62301 RVA: 0x0041C734 File Offset: 0x0041AB34
		public override bool IsHaveRedPoint()
		{
			if (this.mDataModel == null)
			{
				return false;
			}
			if (this.mDataModel.State != OpActivityState.OAS_IN)
			{
				return false;
			}
			if (this.mDataModel.TaskDatas != null)
			{
				for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
				{
					ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mDataModel.TaskDatas[i];
					if (limitTimeActivityTaskDataModel != null)
					{
						if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_FINISHED)
						{
							return true;
						}
					}
				}
			}
			if (!string.IsNullOrEmpty(this._treePlantStateStr))
			{
				PlantOpActSate counterValueByCounterStr = (PlantOpActSate)ArborDayUtility.GetCounterValueByCounterStr(this._treePlantStateStr);
				if (counterValueByCounterStr == PlantOpActSate.POPS_NONE || counterValueByCounterStr == PlantOpActSate.POPS_CAN_APP)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600F35E RID: 62302 RVA: 0x0041C7E9 File Offset: 0x0041ABE9
		private void BindUiEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCounterValueChanged));
		}

		// Token: 0x0600F35F RID: 62303 RVA: 0x0041C806 File Offset: 0x0041AC06
		private void UnBindUiEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCounterValueChanged));
		}

		// Token: 0x0600F360 RID: 62304 RVA: 0x0041C824 File Offset: 0x0041AC24
		private void OnCounterValueChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._treePlantStateStr))
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (!string.Equals(a, this._treePlantStateStr))
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this, null, null, null);
		}

		// Token: 0x040095D4 RID: 38356
		private string _treePlantStateStr;
	}
}
