using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001862 RID: 6242
	public sealed class ReturnGiftActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4C5 RID: 62661 RVA: 0x00420DC9 File Offset: 0x0041F1C9
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4C6 RID: 62662 RVA: 0x00420DD2 File Offset: 0x0041F1D2
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4C7 RID: 62663 RVA: 0x00420DDA File Offset: 0x0041F1DA
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ReturnGiftActivity";
		}

		// Token: 0x0600F4C8 RID: 62664 RVA: 0x00420DE1 File Offset: 0x0041F1E1
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ReturnGiftActivityItem";
		}

		// Token: 0x0600F4C9 RID: 62665 RVA: 0x00420DE8 File Offset: 0x0041F1E8
		public override bool IsHaveRedPoint()
		{
			if (this.mDataModel.TaskDatas == null || this.mDataModel.State != OpActivityState.OAS_IN)
			{
				return false;
			}
			int i = 0;
			while (i < this.mDataModel.TaskDatas.Count)
			{
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				if (this.mDataModel.TaskDatas[i].DataId == 11013006U)
				{
					uint num = this.mDataModel.TaskDatas[i].ParamNums[3];
					uint num2 = this.mDataModel.TaskDatas[i].ParamNums[4];
					if (serverTime >= num && serverTime < num2)
					{
						goto IL_118;
					}
				}
				else
				{
					if (this.mDataModel.TaskDatas[i].DataId != 11017003U)
					{
						goto IL_118;
					}
					uint num = this.mDataModel.TaskDatas[i].ParamNums[2];
					uint num2 = this.mDataModel.TaskDatas[i].ParamNums[3];
					if (serverTime >= num && serverTime < num2)
					{
						goto IL_118;
					}
				}
				IL_136:
				i++;
				continue;
				IL_118:
				if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
				{
					return true;
				}
				goto IL_136;
			}
			return false;
		}

		// Token: 0x0600F4CA RID: 62666 RVA: 0x00420F48 File Offset: 0x0041F348
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if ((long)taskId == (long)((ulong)this.mDataModel.TaskDatas[i].DataId))
				{
					if (this.mDataModel.TaskDatas[i].ParamNums2.Count > 1 && this.mDataModel.TaskDatas[i].ParamNums2[1] > 0U)
					{
						SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format("是否确定花费{0}点券赎回该奖励", this.mDataModel.TaskDatas[i].ParamNums2[1]), delegate()
						{
							this.<_OnItemClick>__BaseCallProxy0(taskId, param, param2);
						}, delegate()
						{
						}, 0f, false);
					}
					else
					{
						base._OnItemClick(taskId, param, param2);
					}
				}
			}
		}
	}
}
