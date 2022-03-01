using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A4 RID: 6308
	public sealed class LimitTimeMallGiftPackActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F69F RID: 63135 RVA: 0x004295D8 File Offset: 0x004279D8
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.InitItems(model);
			this.mNote.Init(model, true, null);
			this.mNote.SetActivityTimeStr(model.Desc);
			this.UpdateTip();
		}

		// Token: 0x0600F6A0 RID: 63136 RVA: 0x0042963C File Offset: 0x00427A3C
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			GameObject gameObject = null;
			this.mModel = model;
			if (model.Id == 0U || this.mModel.DetailDatas == null)
			{
				return;
			}
			for (int i = 0; i < this.mModel.DetailDatas.Count; i++)
			{
				if (this.mItems.ContainsKey(this.mModel.DetailDatas[i].Id))
				{
					this.mItems[this.mModel.DetailDatas[i].Id].UpdateData(this.mModel.DetailDatas[i]);
				}
				else
				{
					if (gameObject == null)
					{
						gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mModel.ItemPath, true, 0U);
					}
					this._AddItem(gameObject, i, this.mModel);
				}
			}
			List<uint> list = new List<uint>(this.mItems.Keys);
			for (int j = 0; j < list.Count; j++)
			{
				bool flag = false;
				for (int k = 0; k < this.mModel.DetailDatas.Count; k++)
				{
					if (list[j] == this.mModel.DetailDatas[k].Id)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					MallGiftPackItem mallGiftPackItem = this.mItems[list[j]];
					this.mItems.Remove(list[j]);
					mallGiftPackItem.Destroy();
				}
			}
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
			this.UpdateTip();
		}

		// Token: 0x0600F6A1 RID: 63137 RVA: 0x00429802 File Offset: 0x00427C02
		private void UpdateTip()
		{
			if (this.mItems.Count <= 0)
			{
				this.mNoGoodsTip.CustomActive(true);
			}
			else
			{
				this.mNoGoodsTip.CustomActive(false);
			}
		}

		// Token: 0x0600F6A2 RID: 63138 RVA: 0x00429834 File Offset: 0x00427C34
		private void InitItems(LimitTimeGiftPackModel model)
		{
			if (model.DetailDatas == null || model.DetailDatas.Count <= 0)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(model.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject.GetComponent<MallGiftPackItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			this.mItems.Clear();
			for (int i = 0; i < model.DetailDatas.Count; i++)
			{
				this._AddItem(gameObject, i, model);
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F6A3 RID: 63139 RVA: 0x004298FC File Offset: 0x00427CFC
		private void _AddItem(GameObject go, int id, LimitTimeGiftPackModel data)
		{
			if (go == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoot, false);
			MallGiftPackItem component = gameObject.GetComponent<MallGiftPackItem>();
			if (component != null)
			{
				component.Init(id, data.DetailDatas[id], this.mOnItemClick, (int)this.mModel.Id);
				this.mItems.Add(data.DetailDatas[id].Id, component);
			}
		}

		// Token: 0x0600F6A4 RID: 63140 RVA: 0x00429988 File Offset: 0x00427D88
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
		}

		// Token: 0x0600F6A5 RID: 63141 RVA: 0x004299A6 File Offset: 0x00427DA6
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x04009788 RID: 38792
		[SerializeField]
		private Text mNoGoodsTip;

		// Token: 0x04009789 RID: 38793
		[SerializeField]
		protected RectTransform mItemRoot;

		// Token: 0x0400978A RID: 38794
		[SerializeField]
		protected ActivityNote mNote;

		// Token: 0x0400978B RID: 38795
		private readonly Dictionary<uint, MallGiftPackItem> mItems = new Dictionary<uint, MallGiftPackItem>();

		// Token: 0x0400978C RID: 38796
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400978D RID: 38797
		private LimitTimeGiftPackModel mModel;
	}
}
