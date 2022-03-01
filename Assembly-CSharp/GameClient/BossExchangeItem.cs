using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018D6 RID: 6358
	public class BossExchangeItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F838 RID: 63544 RVA: 0x00436198 File Offset: 0x00434598
		public void Init(int id, BossExchangeTaskModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick, bool isChallengScoreActivity = false)
		{
			this.mId = id;
			this.mOnItemClick = onItemClick;
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnButtonGoChallengeClick));
			DataManager<ActivityDataManager>.GetInstance().RegisterBossAccountData(new ClientEventSystem.UIEventHandler(this._OnUpdateAccounterNum));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateIntegrationChallengeScore, new ClientEventSystem.UIEventHandler(this._OnUpdateChallengeNum));
			DataManager<ActivityDataManager>.GetInstance().OnRequsetBossAccountData(data);
			this.mData = data;
			this.mIsChallengScoreActivity = isChallengScoreActivity;
			if (!this.mIsChallengScoreActivity)
			{
				this.UpdateData(data);
				this._InitItems();
			}
		}

		// Token: 0x0600F839 RID: 63545 RVA: 0x00436230 File Offset: 0x00434630
		public void UpdateData(BossExchangeTaskModel data)
		{
			this.mData = data;
			if (this.mData.AccountTotalSubmitLimit == 0)
			{
				if (this.mData.TaskCycleCount == -1)
				{
					this.mTextExchangeCount.CustomActive(false);
				}
				else
				{
					this.mTextExchangeCount.CustomActive(true);
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_boss_exchange_item_count_role"), this.mData.RemainCount));
				}
			}
			if (this.mData.AccountTotalSubmitLimit == 0)
			{
				this._UpdateButtonState(this.mData.RemainCount);
			}
			else
			{
				this.ShowHaveUseNumState();
			}
			this._UpdateItems();
		}

		// Token: 0x0600F83A RID: 63546 RVA: 0x004362E0 File Offset: 0x004346E0
		private void _UpdateItems()
		{
			if (this.mData.NeedItems == null)
			{
				return;
			}
			foreach (KeyValuePair<int, Text> keyValuePair in this.mItemTextCountsDictionary)
			{
				Text value = keyValuePair.Value;
				int key = keyValuePair.Key;
				if (this.mData.NeedItems.ContainsKey(key))
				{
					int num = this.mData.NeedItems[key];
					value.CustomActive(true);
					int num2;
					if (!this.mIsChallengScoreActivity)
					{
						num2 = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(key);
					}
					else
					{
						num2 = DataManager<PlayerBaseData>.GetInstance().ChanllengeScore;
					}
					string text = num2.ToString();
					if (num2 < num)
					{
						text = this._TrySetColor(text, Color.red);
					}
					else
					{
						text = this._TrySetColor(text, Color.green);
					}
					value.SafeSetText(text + "/" + num);
				}
			}
		}

		// Token: 0x0600F83B RID: 63547 RVA: 0x0043640C File Offset: 0x0043480C
		public void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F83C RID: 63548 RVA: 0x00436420 File Offset: 0x00434820
		public void Dispose()
		{
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mIsInit = false;
			this.mAccountNumLeft = 0;
			this.mItemTextCountsDictionary.Clear();
			this.mOnItemClick = null;
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnButtonGoChallengeClick));
			this.mButtonGoLink.SafeRemoveAllListener();
			DataManager<ActivityDataManager>.GetInstance().UnRegisterBossAccountData(new ClientEventSystem.UIEventHandler(this._OnUpdateAccounterNum));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateIntegrationChallengeScore, new ClientEventSystem.UIEventHandler(this._OnUpdateChallengeNum));
		}

		// Token: 0x0600F83D RID: 63549 RVA: 0x004364E8 File Offset: 0x004348E8
		private void _InitItems()
		{
			if (this.mData.NeedItems == null)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ItemPrefabPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("load prefab failed at path: " + this.ItemPrefabPath);
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				Logger.LogErrorFormat("can not find ComcomonBind in mBindThing at Path:" + this.ItemPrefabPath, new object[0]);
				return;
			}
			GameObject gameObject2 = component.GetGameObject("ItemRoot");
			if (gameObject2 == null)
			{
				Logger.LogErrorFormat("can not find ItemRoot in mBind at Path:" + this.ItemPrefabPath, new object[0]);
				return;
			}
			this._InitConsueItems(gameObject);
			this._InitAwardItems(gameObject);
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F83E RID: 63550 RVA: 0x004365B4 File Offset: 0x004349B4
		private void _InitConsueItems(GameObject template)
		{
			bool flag = true;
			foreach (KeyValuePair<int, int> keyValuePair in this.mData.NeedItems)
			{
				this._InitItem(template, keyValuePair.Key, keyValuePair.Value, !flag, false, true);
				flag = false;
			}
		}

		// Token: 0x0600F83F RID: 63551 RVA: 0x00436630 File Offset: 0x00434A30
		private void _UpdateButtonState(int remainCount)
		{
			bool flag = true;
			int notEnoughItemId = 0;
			if (this.mData.NeedItems != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in this.mData.NeedItems)
				{
					int num;
					if (!this.mIsChallengScoreActivity)
					{
						num = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(keyValuePair.Key);
					}
					else
					{
						num = DataManager<PlayerBaseData>.GetInstance().ChanllengeScore;
					}
					if (flag && num < keyValuePair.Value)
					{
						flag = false;
						notEnoughItemId = keyValuePair.Key;
						break;
					}
				}
			}
			if (remainCount == 0 && this.mData.TaskCycleCount != -1)
			{
				this.mButtonExchange.CustomActive(true);
				this.mButtonGoLink.CustomActive(false);
				if (this.mExchangeGray != null)
				{
					this.mExchangeGray.enabled = true;
				}
			}
			else
			{
				if (!flag)
				{
					this.mButtonExchange.CustomActive(false);
					this.mButtonGoLink.CustomActive(true);
					this.mButtonGoLink.SafeRemoveAllListener();
					this.mButtonGoLink.SafeAddOnClickListener(delegate
					{
						ItemComeLink.OnLink(notEnoughItemId, 0, true, null, false, false, false, null, string.Empty);
					});
				}
				else
				{
					this.mButtonExchange.CustomActive(true);
					this.mButtonGoLink.CustomActive(false);
				}
				if (this.mExchangeGray != null)
				{
					this.mExchangeGray.enabled = false;
				}
			}
		}

		// Token: 0x0600F840 RID: 63552 RVA: 0x004367D0 File Offset: 0x00434BD0
		private void _InitAwardItems(GameObject template)
		{
			bool flag = true;
			foreach (KeyValuePair<int, int> keyValuePair in this.mData.ExchangeItems)
			{
				this._InitItem(template, keyValuePair.Key, keyValuePair.Value, !flag, flag, false);
				flag = false;
			}
		}

		// Token: 0x0600F841 RID: 63553 RVA: 0x0043684C File Offset: 0x00434C4C
		private void _InitItem(GameObject template, int id, int count, bool isShowAdd = false, bool isShowEqual = false, bool isShowOwnCount = true)
		{
			if (template == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(template);
			gameObject.transform.SetParent(this.mItemRoot, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			GameObject gameObject2 = component.GetGameObject("ItemRoot");
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
			ComItem comItem = gameObject2.gameObject.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = ComItemManager.Create(gameObject2);
			}
			ComItem comItem2 = comItem;
			ItemData item = itemData;
			if (BossExchangeItem.<>f__mg$cache0 == null)
			{
				BossExchangeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem2.Setup(item, BossExchangeItem.<>f__mg$cache0);
			GameObject gameObject3 = component.GetGameObject("dengyu");
			GameObject gameObject4 = component.GetGameObject("jia");
			gameObject4.CustomActive(isShowAdd);
			gameObject3.CustomActive(isShowEqual);
			if (isShowOwnCount)
			{
				Text com = component.GetCom<Text>("Count");
				com.CustomActive(true);
				int num;
				if (!this.mIsChallengScoreActivity)
				{
					num = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(id);
				}
				else
				{
					num = DataManager<PlayerBaseData>.GetInstance().ChanllengeScore;
				}
				string text = num.ToString();
				if (num < count)
				{
					text = this._TrySetColor(text, Color.red);
				}
				else
				{
					text = this._TrySetColor(text, Color.green);
				}
				com.SafeSetText(text + "/" + count);
				if (!this.mItemTextCountsDictionary.ContainsKey(id))
				{
					this.mItemTextCountsDictionary.Add(id, com);
				}
			}
			else if (count > 1)
			{
				Text com2 = component.GetCom<Text>("Count");
				com2.CustomActive(true);
				com2.SafeSetText(count.ToString());
			}
		}

		// Token: 0x0600F842 RID: 63554 RVA: 0x00436A00 File Offset: 0x00434E00
		private void _OnButtonGoChallengeClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
			DataManager<ActivityDataManager>.GetInstance().OnRequsetBossAccountData(this.mData);
			if (this.mIsChallengScoreActivity)
			{
				DataManager<ActivityDataManager>.GetInstance().RequestChallengeScore();
			}
		}

		// Token: 0x0600F843 RID: 63555 RVA: 0x00436A54 File Offset: 0x00434E54
		private string _TrySetColor(string str, Color color)
		{
			if (color == Color.red)
			{
				return "<color=#FF0101FF>" + str + "</color>";
			}
			if (color == Color.green)
			{
				return "<color=#01FF01FF>" + str + "</color>";
			}
			return str;
		}

		// Token: 0x0600F844 RID: 63556 RVA: 0x00436AA4 File Offset: 0x00434EA4
		private void _OnUpdateAccounterNum(UIEvent uiEvent)
		{
			if ((ulong)((uint)uiEvent.Param1) == (ulong)((long)this.mData.Id) && (uint)uiEvent.Param2 == 4003U)
			{
				if (this.mData.AccountTotalSubmitLimit > 0)
				{
					int num = (int)uiEvent.Param3;
					int num2 = this.mData.AccountTotalSubmitLimit - num;
					if (num2 < 0)
					{
						num2 = 0;
					}
					this.mAccountNumLeft = num2;
					this.mTextExchangeCount.CustomActive(true);
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_boss_exchange_item_count_account"), num2));
					this._UpdateButtonState(num2);
				}
			}
			else
			{
				this.ShowHaveUseNumState();
			}
		}

		// Token: 0x0600F845 RID: 63557 RVA: 0x00436B5C File Offset: 0x00434F5C
		private void ShowHaveUseNumState()
		{
			int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
			int num = 0;
			if (accountTotalSubmitLimit > 0)
			{
				num = accountTotalSubmitLimit;
			}
			if (num > 0)
			{
				int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter((uint)this.mData.Id, ActivityLimitTimeFactory.EActivityCounterType.OP_ITEM_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
				int num2 = num - activityConunter;
				if (num2 < 0)
				{
					num2 = 0;
				}
				this.mAccountNumLeft = num2;
				this.mTextExchangeCount.CustomActive(true);
				this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_boss_exchange_item_count_account"), num2));
				this._UpdateButtonState(num2);
			}
		}

		// Token: 0x0600F846 RID: 63558 RVA: 0x00436BEC File Offset: 0x00434FEC
		private void _OnUpdateChallengeNum(UIEvent uiEvent)
		{
			if (this.mIsChallengScoreActivity)
			{
				this.UpdateData(this.mData);
				if (!this.mIsInit)
				{
					this._InitItems();
					this.mIsInit = true;
				}
				if (this.mData.AccountTotalSubmitLimit > 0)
				{
					this._UpdateButtonState(this.mAccountNumLeft);
				}
			}
		}

		// Token: 0x04009954 RID: 39252
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04009955 RID: 39253
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009956 RID: 39254
		[SerializeField]
		private Button mButtonExchange;

		// Token: 0x04009957 RID: 39255
		[SerializeField]
		private Button mButtonGoLink;

		// Token: 0x04009958 RID: 39256
		[SerializeField]
		private string ItemPrefabPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BossExchangeThing";

		// Token: 0x04009959 RID: 39257
		[SerializeField]
		private UIGray mExchangeGray;

		// Token: 0x0400995A RID: 39258
		private readonly List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x0400995B RID: 39259
		private BossExchangeTaskModel mData;

		// Token: 0x0400995C RID: 39260
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400995D RID: 39261
		private int mId;

		// Token: 0x0400995E RID: 39262
		private readonly Dictionary<int, Text> mItemTextCountsDictionary = new Dictionary<int, Text>();

		// Token: 0x0400995F RID: 39263
		private bool mIsChallengScoreActivity;

		// Token: 0x04009960 RID: 39264
		private int mAccountNumLeft;

		// Token: 0x04009961 RID: 39265
		[SerializeField]
		private int mChallengeScoreItemId = 800001235;

		// Token: 0x04009962 RID: 39266
		private bool mIsInit;

		// Token: 0x04009963 RID: 39267
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
