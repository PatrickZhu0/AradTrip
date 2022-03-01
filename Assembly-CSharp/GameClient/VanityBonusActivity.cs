using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001924 RID: 6436
	public class VanityBonusActivity : IActivity, IDisposable
	{
		// Token: 0x0600FA77 RID: 64119 RVA: 0x00449AC8 File Offset: 0x00447EC8
		public void Init(uint activityId)
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (limitTimeActivityData != null)
			{
				this.eAdditionBuffType = (EadditionBuffType)limitTimeActivityData.parm;
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null);
			}
		}

		// Token: 0x0600FA78 RID: 64120 RVA: 0x00449B08 File Offset: 0x00447F08
		public void Show(Transform root)
		{
			if (this.mDataModel.Id == 0U)
			{
				return;
			}
			if (this.mIsInit)
			{
				this.mGameObject.CustomActive(true);
			}
			else
			{
				if (this.mGameObject == null)
				{
					this.mGameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this._GetPrefabPath(), true, 0U);
				}
				if (!(this.mGameObject != null))
				{
					Logger.LogError("加载活动预制体失败，路径:" + this._GetPrefabPath());
					return;
				}
				this.mGameObject.transform.SetParent(root, false);
				this.mGameObject.CustomActive(true);
				this.mView = this.mGameObject.GetComponent<IDungeonBuffView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new UnityAction(this.GoBtnOnClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600FA79 RID: 64121 RVA: 0x00449BF5 File Offset: 0x00447FF5
		private void GoBtnOnClick()
		{
			if (this.eAdditionBuffType == EadditionBuffType.XuKong)
			{
				Utility.PathfindingYiJieMap();
			}
			else
			{
				ChallengeUtility.OnOpenChallengeMapFrame(DungeonModelTable.eType.WeekHellModel, 0, 0);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
				}
			}
		}

		// Token: 0x0600FA7A RID: 64122 RVA: 0x00449C31 File Offset: 0x00448031
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600FA7B RID: 64123 RVA: 0x00449C50 File Offset: 0x00448050
		public void Close()
		{
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Close();
			}
			this.mView = null;
			this.mGameObject = null;
		}

		// Token: 0x0600FA7C RID: 64124 RVA: 0x00449C80 File Offset: 0x00448080
		public void UpdateData()
		{
			if (this.mDataModel == null)
			{
				return;
			}
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(this.mDataModel.Id);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null);
			}
		}

		// Token: 0x0600FA7D RID: 64125 RVA: 0x00449CCA File Offset: 0x004480CA
		public void UpdateTask(int taskId)
		{
			this.mDataModel.UpdateTask(taskId);
		}

		// Token: 0x0600FA7E RID: 64126 RVA: 0x00449CD8 File Offset: 0x004480D8
		public bool IsHaveRedPoint()
		{
			return false;
		}

		// Token: 0x0600FA7F RID: 64127 RVA: 0x00449CDB File Offset: 0x004480DB
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600FA80 RID: 64128 RVA: 0x00449CE8 File Offset: 0x004480E8
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600FA81 RID: 64129 RVA: 0x00449CF5 File Offset: 0x004480F5
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600FA82 RID: 64130 RVA: 0x00449D02 File Offset: 0x00448102
		public void Dispose()
		{
			this.mGameObject = null;
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
		}

		// Token: 0x0600FA83 RID: 64131 RVA: 0x00449D30 File Offset: 0x00448130
		private string _GetPrefabPath()
		{
			string result = string.Empty;
			if (this.eAdditionBuffType == EadditionBuffType.XuKong)
			{
				result = "UIFlatten/Prefabs/OperateActivity/YiJie/Activities/VanityBonusActivity";
			}
			else if (this.eAdditionBuffType == EadditionBuffType.HunDun)
			{
				if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
				{
					result = this.mDataModel.ActivityPrefafPath;
				}
				else
				{
					result = "UIFlatten/Prefabs/OperateActivity/Chaos/Activity/ChaosAdditionActivity";
				}
			}
			return result;
		}

		// Token: 0x0600FA84 RID: 64132 RVA: 0x00449DA0 File Offset: 0x004481A0
		private string _GetItemPrefabPath()
		{
			string result = string.Empty;
			if (this.eAdditionBuffType == EadditionBuffType.XuKong)
			{
				result = "UIFlatten/Prefabs/OperateActivity/YiJie/Items/VanityBonusItemLeft";
			}
			else if (this.eAdditionBuffType == EadditionBuffType.HunDun)
			{
				result = "UIFlatten/Prefabs/OperateActivity/Chaos/Item/ChaosAdditionItemLeft";
			}
			return result;
		}

		// Token: 0x04009C7B RID: 40059
		protected GameObject mGameObject;

		// Token: 0x04009C7C RID: 40060
		protected bool mIsInit;

		// Token: 0x04009C7D RID: 40061
		protected IDungeonBuffView mView;

		// Token: 0x04009C7E RID: 40062
		protected ILimitTimeActivityModel mDataModel;

		// Token: 0x04009C7F RID: 40063
		protected EadditionBuffType eAdditionBuffType;
	}
}
