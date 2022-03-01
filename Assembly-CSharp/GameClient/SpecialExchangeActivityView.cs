using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B1 RID: 6321
	public class SpecialExchangeActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F70C RID: 63244 RVA: 0x0042CE5C File Offset: 0x0042B25C
		public void Init(BossExchangeModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mOnItemClick = onItemClick;
			this.mData = model;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			this.InitConsumeInfo();
			this.InitHelpAssistant();
			ETCImageLoader.LoadSprite(ref this.mBg, this.mData.LogoPath, true);
			this.mTime.SafeSetText(string.Format("{0}~{1}", Function.GetDateTime((int)this.mData.StartTime, false), Function.GetDateTime((int)this.mData.EndTime, false)));
			this.InitItems();
		}

		// Token: 0x0600F70D RID: 63245 RVA: 0x0042CF4C File Offset: 0x0042B34C
		private void OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item.TableID == this.mConsumItemID)
				{
					this.UpdateConsumeCount();
					break;
				}
			}
		}

		// Token: 0x0600F70E RID: 63246 RVA: 0x0042CFAA File Offset: 0x0042B3AA
		private void OnRemoveItem(ItemData item)
		{
			if (item.TableID == this.mConsumItemID)
			{
				this.UpdateConsumeCount();
			}
		}

		// Token: 0x0600F70F RID: 63247 RVA: 0x0042CFC4 File Offset: 0x0042B3C4
		private void InitConsumeInfo()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mConsumItemID, string.Empty, string.Empty);
			if (tableItem != null && this.mConsumeIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mConsumeIcon, tableItem.Icon, true);
			}
			this.UpdateConsumeCount();
		}

		// Token: 0x0600F710 RID: 63248 RVA: 0x0042D01C File Offset: 0x0042B41C
		private void UpdateConsumeCount()
		{
			int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(this.mConsumItemID);
			if (this.mConsumeCount != null)
			{
				this.mConsumeCount.text = itemCountInPackage.ToString();
			}
		}

		// Token: 0x0600F711 RID: 63249 RVA: 0x0042D064 File Offset: 0x0042B464
		private void InitHelpAssistant()
		{
			if (this.mData == null)
			{
				return;
			}
			if (this.mData.Id == 22950U)
			{
				if (this.mHelp != null)
				{
					this.mHelp.eType = HelpFrame.HelpType.HT_CHILDRENSDAYACTIVITY;
				}
			}
			else if (this.mData.Id == 22960U)
			{
				if (this.mHelp != null)
				{
					this.mHelp.eType = HelpFrame.HelpType.HT_DRAGONBOATFESTIVALACTIVITY;
				}
			}
			else if (this.mData.Id == 23060U)
			{
				this.mHelp.eType = HelpFrame.HelpType.HT_MIDAUTUMNFESTIVALACTIVITY;
			}
			else if (this.mData.Id == 23070U)
			{
				this.mHelp.eType = HelpFrame.HelpType.HT_DOUBLEELEVENGIFTCERTIFICATEACTIVITY;
			}
		}

		// Token: 0x0600F712 RID: 63250 RVA: 0x0042D13C File Offset: 0x0042B53C
		public void UpdateData(BossExchangeModel data)
		{
			GameObject gameObject = null;
			if (data.ExchangeTasks == null)
			{
				return;
			}
			int i = 0;
			foreach (BossExchangeTaskModel taskData in data.ExchangeTasks.Values)
			{
				if (this.mItems.ContainsKey(taskData.Id))
				{
					this.mItems[taskData.Id].UpdateData(taskData);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					this.AddItem(gameObject, taskData.Id, taskData, i);
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
					SpecialExchangeItem specialExchangeItem = this.mItems[list[i]];
					this.mItems.Remove(list[i]);
					specialExchangeItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600F713 RID: 63251 RVA: 0x0042D2EC File Offset: 0x0042B6EC
		private void InitItems()
		{
			if (this.mData == null)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mData.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + this.mData.ItemPath);
				return;
			}
			if (gameObject.GetComponent<SpecialExchangeItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到SpecialExchangeItem的脚本，预制体路径是:" + this.mData.ItemPath);
				return;
			}
			if (this.mItems != null)
			{
				this.mItems.Clear();
			}
			int num = 0;
			foreach (BossExchangeTaskModel taskData in this.mData.ExchangeTasks.Values)
			{
				this.AddItem(gameObject, taskData.Id, taskData, num);
				num++;
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F714 RID: 63252 RVA: 0x0042D3FC File Offset: 0x0042B7FC
		private void AddItem(GameObject go, int id, BossExchangeTaskModel taskData, int index)
		{
			if (index < 0 || index > this.mItemListRoot.Count)
			{
				return;
			}
			if (go == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemListRoot[index], false);
			SpecialExchangeItem component = gameObject.GetComponent<SpecialExchangeItem>();
			if (component != null)
			{
				component.Init(id, taskData, this.mOnItemClick);
				if (!this.mItems.ContainsKey(taskData.Id))
				{
					this.mItems.Add(taskData.Id, component);
				}
				else
				{
					Logger.LogErrorFormat("SpecialExchangeActivityView中 AddItem函数 mItems.add时，活动任务 Key重复  Key = {0}", new object[]
					{
						taskData.Id
					});
				}
			}
		}

		// Token: 0x0600F715 RID: 63253 RVA: 0x0042D4C0 File Offset: 0x0042B8C0
		public void Dispose()
		{
			if (this.mItems != null)
			{
				this.mItems.Clear();
			}
			this.mOnItemClick = null;
			this.mData = null;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		}

		// Token: 0x0600F716 RID: 63254 RVA: 0x0042D563 File Offset: 0x0042B963
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x040097E8 RID: 38888
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x040097E9 RID: 38889
		[SerializeField]
		private Text mTime;

		// Token: 0x040097EA RID: 38890
		[SerializeField]
		private Image mBg;

		// Token: 0x040097EB RID: 38891
		[SerializeField]
		private HelpAssistant mHelp;

		// Token: 0x040097EC RID: 38892
		[SerializeField]
		private List<RectTransform> mItemListRoot;

		// Token: 0x040097ED RID: 38893
		[SerializeField]
		private Image mConsumeIcon;

		// Token: 0x040097EE RID: 38894
		[SerializeField]
		private Text mConsumeCount;

		// Token: 0x040097EF RID: 38895
		[SerializeField]
		private int mConsumItemID = 800001725;

		// Token: 0x040097F0 RID: 38896
		private readonly Dictionary<int, SpecialExchangeItem> mItems = new Dictionary<int, SpecialExchangeItem>();

		// Token: 0x040097F1 RID: 38897
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040097F2 RID: 38898
		private BossExchangeModel mData;
	}
}
