using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001839 RID: 6201
	public sealed class DungeonDropActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3D0 RID: 62416 RVA: 0x0041DACC File Offset: 0x0041BECC
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			int num = -1;
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if ((ulong)this.mDataModel.TaskDatas[i].DataId == (ulong)((long)taskId))
				{
					num = (int)this.mDataModel.TaskDatas[i].ParamNums[0];
				}
			}
			if (num == -1)
			{
				return;
			}
			AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string linkInfo = tableItem.LinkInfo;
			DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(linkInfo, null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
		}

		// Token: 0x0600F3D1 RID: 62417 RVA: 0x0041DB8C File Offset: 0x0041BF8C
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			this.mData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
		}

		// Token: 0x0600F3D2 RID: 62418 RVA: 0x0041DBA8 File Offset: 0x0041BFA8
		protected override string _GetPrefabPath()
		{
			if (this.mData != null)
			{
				string prefabPath = this.mData.prefabPath;
				if (!string.IsNullOrEmpty(prefabPath))
				{
					return prefabPath;
				}
			}
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CommonHaveExtraItemActivity";
		}

		// Token: 0x0600F3D3 RID: 62419 RVA: 0x0041DBDE File Offset: 0x0041BFDE
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/DungeonDropItem";
		}

		// Token: 0x040095EA RID: 38378
		private OpActivityData mData;
	}
}
