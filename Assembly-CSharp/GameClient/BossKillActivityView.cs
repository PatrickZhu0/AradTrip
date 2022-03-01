using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001877 RID: 6263
	public sealed class BossKillActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F56C RID: 62828 RVA: 0x004237B4 File Offset: 0x00421BB4
		public void Init(BossKillModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick, UnityAction onGoShopClick)
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
		}

		// Token: 0x0600F56D RID: 62829 RVA: 0x00423811 File Offset: 0x00421C11
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F56E RID: 62830 RVA: 0x00423824 File Offset: 0x00421C24
		public void UpdateData(BossKillModel data)
		{
			GameObject gameObject = null;
			if (data.MonsterDatas == null)
			{
				return;
			}
			for (int i = 0; i < data.MonsterDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(data.MonsterDatas[i].Id))
				{
					this.mItems[data.MonsterDatas[i].Id].UpdateData(data.MonsterDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
					}
					this._AddItem(gameObject, i, data.MonsterDatas[i]);
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < data.MonsterDatas.Count; k++)
				{
					if (list[j] == data.MonsterDatas[k].Id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					BossKillItem bossKillItem = this.mItems[list[j]];
					this.mItems.Remove(list[j]);
					bossKillItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}

		// Token: 0x0600F56F RID: 62831 RVA: 0x004239B8 File Offset: 0x00421DB8
		private void InitItems(BossKillModel model)
		{
			if (model.MonsterDatas == null || model.MonsterDatas.Count <= 0)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(model.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject.GetComponent<BossKillItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到BossKillItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			this.mItems.Clear();
			for (int i = 0; i < model.MonsterDatas.Count; i++)
			{
				this._AddItem(gameObject, i, model.MonsterDatas[i]);
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F570 RID: 62832 RVA: 0x00423A8C File Offset: 0x00421E8C
		private void _AddItem(GameObject go, int id, BossKillMonsterModel data)
		{
			if (go == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			BossKillItem component = gameObject.GetComponent<BossKillItem>();
			if (component != null)
			{
				component.Init(id, data, this.mOnItemClick);
				this.mItems.Add(data.Id, component);
			}
		}

		// Token: 0x0600F571 RID: 62833 RVA: 0x00423AF3 File Offset: 0x00421EF3
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
			this.mButtonGoShop.SafeRemoveOnClickListener(this.mOnGoShopClick);
		}

		// Token: 0x0400968D RID: 38541
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x0400968E RID: 38542
		[SerializeField]
		private ActivityNote mNote;

		// Token: 0x0400968F RID: 38543
		[SerializeField]
		private Button mButtonGoShop;

		// Token: 0x04009690 RID: 38544
		private readonly Dictionary<uint, BossKillItem> mItems = new Dictionary<uint, BossKillItem>();

		// Token: 0x04009691 RID: 38545
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009692 RID: 38546
		private UnityAction mOnGoShopClick;
	}
}
