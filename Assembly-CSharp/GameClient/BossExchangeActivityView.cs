using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001876 RID: 6262
	public sealed class BossExchangeActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F564 RID: 62820 RVA: 0x0042329C File Offset: 0x0042169C
		public void Init(BossExchangeModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick, UnityAction onGoShopClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this.mOnGoShopClick = onGoShopClick;
			this.InitItems(model);
			this.mNote.Init(model, false, null);
			this.mButtonGoShop.SafeAddOnClickListener(this.mOnGoShopClick);
			this.mData = model;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateIntegrationChallengeScore, new ClientEventSystem.UIEventHandler(this._OnUpdateChallengeNum));
			if ((ulong)model.Id == (ulong)((long)this.mChallengeScoreActivityId))
			{
				DataManager<ActivityDataManager>.GetInstance().RequestChallengeScore();
				this.mCurScoreTxt.CustomActive(true);
			}
			else
			{
				this.mCurScoreTxt.CustomActive(false);
			}
		}

		// Token: 0x0600F565 RID: 62821 RVA: 0x00423350 File Offset: 0x00421750
		private void _OnUpdateChallengeNum(UIEvent uiEvent)
		{
			if (this.mData != null && (ulong)this.mData.Id == (ulong)((long)this.mChallengeScoreActivityId))
			{
				this.mCurScoreTxt.SafeSetText(string.Format(TR.Value("IntegrationChallenge_CurScore"), DataManager<PlayerBaseData>.GetInstance().ChanllengeScore));
			}
		}

		// Token: 0x0600F566 RID: 62822 RVA: 0x004233AC File Offset: 0x004217AC
		public void UpdateData(BossExchangeModel data)
		{
			GameObject gameObject = null;
			if (data.ExchangeTasks == null)
			{
				return;
			}
			int i = 0;
			foreach (BossExchangeTaskModel data2 in data.ExchangeTasks.Values)
			{
				if (this.mItems.ContainsKey(data2.Id))
				{
					this.mItems[data2.Id].UpdateData(data2);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					this._AddItem(gameObject, i, data2, false);
				}
				i++;
			}
			List<int> list = new List<int>(this.mItems.Keys);
			for (i = 0; i < list.Count; i++)
			{
				bool flag = false;
				foreach (BossExchangeTaskModel bossExchangeTaskModel in data.ExchangeTasks.Values)
				{
					if (list[i] == bossExchangeTaskModel.Id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					BossExchangeItem bossExchangeItem = this.mItems[list[i]];
					this.mItems.Remove(list[i]);
					bossExchangeItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600F567 RID: 62823 RVA: 0x00423554 File Offset: 0x00421954
		private void InitItems(BossExchangeModel model)
		{
			if (model.ExchangeTasks == null || model.ExchangeTasks.Count <= 0)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(model.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject.GetComponent<BossExchangeItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到BossExchangeItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			this.mItems.Clear();
			int num = 0;
			foreach (BossExchangeTaskModel data in model.ExchangeTasks.Values)
			{
				this._AddItem(gameObject, data.Id, data, (ulong)model.Id == (ulong)((long)this.mChallengeScoreActivityId));
				num++;
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F568 RID: 62824 RVA: 0x00423664 File Offset: 0x00421A64
		private void _AddItem(GameObject go, int id, BossExchangeTaskModel data, bool isChallengScoreActivity = false)
		{
			if (go == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			BossExchangeItem component = gameObject.GetComponent<BossExchangeItem>();
			if (component != null)
			{
				component.Init(id, data, this.mOnItemClick, isChallengScoreActivity);
				if (data.Id <= 0)
				{
					Logger.LogErrorFormat("BossExchangeActivityView中 _AddItem函数 活动任务Id  = {0}，服务器下发数据错误 @杨文浩", new object[]
					{
						data.Id
					});
					return;
				}
				if (!this.mItems.ContainsKey(data.Id))
				{
					this.mItems.Add(data.Id, component);
				}
				else
				{
					Logger.LogErrorFormat("BossExchangeActivityView中 _AddItem函数 mItems.add时，活动任务 Key重复  Key = {0}", new object[]
					{
						data.Id
					});
				}
			}
		}

		// Token: 0x0600F569 RID: 62825 RVA: 0x00423738 File Offset: 0x00421B38
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
			this.mButtonGoShop.SafeRemoveOnClickListener(this.mOnGoShopClick);
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateIntegrationChallengeScore, new ClientEventSystem.UIEventHandler(this._OnUpdateChallengeNum));
		}

		// Token: 0x0600F56A RID: 62826 RVA: 0x0042378D File Offset: 0x00421B8D
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x04009684 RID: 38532
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009685 RID: 38533
		[SerializeField]
		private ActivityNote mNote;

		// Token: 0x04009686 RID: 38534
		[SerializeField]
		private Button mButtonGoShop;

		// Token: 0x04009687 RID: 38535
		private readonly Dictionary<int, BossExchangeItem> mItems = new Dictionary<int, BossExchangeItem>();

		// Token: 0x04009688 RID: 38536
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009689 RID: 38537
		private UnityAction mOnGoShopClick;

		// Token: 0x0400968A RID: 38538
		[SerializeField]
		private int mChallengeScoreActivityId = 22870;

		// Token: 0x0400968B RID: 38539
		[SerializeField]
		private Text mCurScoreTxt;

		// Token: 0x0400968C RID: 38540
		private BossExchangeModel mData;
	}
}
