using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200192A RID: 6442
	public class VanityCustomClearanceActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600FA9F RID: 64159 RVA: 0x0044A2E4 File Offset: 0x004486E4
		public sealed override void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || this.mItems == null)
			{
				Logger.LogError("ActivityLimitTimeData data is null");
				return;
			}
			GameObject gameObject = null;
			GameObject gameObject2 = null;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(data.TaskDatas[i].DataId))
				{
					this.mItems[data.TaskDatas[i].DataId].UpdateData(data.TaskDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					if (gameObject2 == null)
					{
						gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.VanityAddUpCustomClearanceRewardItemPath, true, 0U);
					}
					if (data.TaskDatas[i].ParamNums.Count > 0 && data.TaskDatas[i].ParamNums[0] >= 1U)
					{
						base._AddItem(gameObject, i, data);
					}
					else
					{
						this._AddAddUpItem(gameObject2, i, data);
					}
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < data.TaskDatas.Count; k++)
				{
					if (list[j] == data.TaskDatas[k].DataId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					IActivityCommonItem activityCommonItem = this.mItems[list[j]];
					this.mItems.Remove(list[j]);
					activityCommonItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			if (gameObject2 != null)
			{
				Object.Destroy(gameObject2);
			}
		}

		// Token: 0x0600FAA0 RID: 64160 RVA: 0x0044A4F0 File Offset: 0x004488F0
		protected sealed override void _InitItems(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + data.ItemPath);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.VanityAddUpCustomClearanceRewardItemPath, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogError("加载预制体失败，路径:" + this.VanityAddUpCustomClearanceRewardItemPath);
				return;
			}
			if (gameObject2.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + this.VanityAddUpCustomClearanceRewardItemPath);
				return;
			}
			this.mItems.Clear();
			bool flag = false;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				if (data.TaskDatas[i].ParamNums.Count > 0 && data.TaskDatas[i].ParamNums[0] >= 1U)
				{
					flag = true;
					base._AddItem(gameObject, i, data);
				}
				else
				{
					this._AddAddUpItem(gameObject2, i, data);
				}
			}
			if (this.mmNormalItem1Go != null)
			{
				this.mmNormalItem1Go.gameObject.SetActive(flag);
				if (!flag)
				{
					this.mNormalItem2Rect.anchoredPosition = this.mNormalItem2Pos2;
					this.mNormalItem2Rect.sizeDelta = this.mNormalItem2Size2;
				}
			}
			Object.Destroy(gameObject);
			Object.Destroy(gameObject2);
		}

		// Token: 0x0600FAA1 RID: 64161 RVA: 0x0044A68C File Offset: 0x00448A8C
		private void _AddAddUpItem(GameObject go, int id, ILimitTimeActivityModel data)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mAddUpItemRoot.transform, false);
			gameObject.GetComponent<IActivityCommonItem>().Init(data.TaskDatas[id].DataId, data.Id, data.TaskDatas[id], this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[id].DataId, gameObject.GetComponent<IActivityCommonItem>());
		}

		// Token: 0x04009C92 RID: 40082
		[SerializeField]
		private string VanityAddUpCustomClearanceRewardItemPath = "UIFlatten/Prefabs/OperateActivity/YiJie/Items/VanityAddUpCustomClearanceRewardItem";

		// Token: 0x04009C93 RID: 40083
		[SerializeField]
		private GameObject mAddUpItemRoot;

		// Token: 0x04009C94 RID: 40084
		[SerializeField]
		private Vector3 mNormalItem2Pos2;

		// Token: 0x04009C95 RID: 40085
		[SerializeField]
		private Vector2 mNormalItem2Size2;

		// Token: 0x04009C96 RID: 40086
		[SerializeField]
		private GameObject mmNormalItem1Go;

		// Token: 0x04009C97 RID: 40087
		[SerializeField]
		private RectTransform mNormalItem2Rect;
	}
}
