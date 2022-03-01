using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E89 RID: 3721
	public class ComChapterInfoDrug : MonoBehaviour, IChapterInfoDrugs
	{
		// Token: 0x0600933C RID: 37692 RVA: 0x001B70C0 File Offset: 0x001B54C0
		private void _loadUnit(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDrug", enResourceType.UIPrefab, 0U);
				gameObject.name = string.Format("{0}", id);
				Utility.AttachTo(gameObject, base.gameObject, false);
				ComChapterInfoDrugUnit component = gameObject.GetComponent<ComChapterInfoDrugUnit>();
				component.LoadUnit(id);
				this.mCache.Add(component);
			}
		}

		// Token: 0x0600933D RID: 37693 RVA: 0x001B7138 File Offset: 0x001B5538
		private void _loadUnitSplit()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDrugSplit", true, 0U);
			Utility.AttachTo(gameObject, base.gameObject, false);
			this.mCacheSplit.Add(gameObject);
		}

		// Token: 0x0600933E RID: 37694 RVA: 0x001B7170 File Offset: 0x001B5570
		private void _unloadUnit()
		{
			for (int i = 0; i < this.mCache.Count; i++)
			{
				if (null != this.mCache[i])
				{
					this.mCache[i].UnloadUnit();
					Singleton<CGameObjectPool>.instance.RecycleGameObject(this.mCache[i].gameObject);
				}
			}
			this.mCache.Clear();
			for (int j = 0; j < this.mCacheSplit.Count; j++)
			{
				if (null != this.mCacheSplit[j])
				{
					Object.Destroy(this.mCacheSplit[j]);
					this.mCacheSplit[j] = null;
				}
			}
			this.mCacheSplit.Clear();
		}

		// Token: 0x0600933F RID: 37695 RVA: 0x001B7244 File Offset: 0x001B5644
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffAdded, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
		}

		// Token: 0x06009340 RID: 37696 RVA: 0x001B735C File Offset: 0x001B575C
		private void _unbindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemTakeSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemSellSuccess, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._onUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffAdded, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._onLevelChanged));
		}

		// Token: 0x06009341 RID: 37697 RVA: 0x001B7474 File Offset: 0x001B5874
		private void _onLevelChanged(UIEvent ui)
		{
			if (this.mCache != null)
			{
				for (int i = 0; i < this.mCache.Count; i++)
				{
					if (null != this.mCache[i])
					{
						this.mCache[i].UpdateCost();
					}
				}
			}
		}

		// Token: 0x06009342 RID: 37698 RVA: 0x001B74D0 File Offset: 0x001B58D0
		private void _onUpdateItems(UIEvent ui)
		{
			if (this.mCache != null)
			{
				for (int i = 0; i < this.mCache.Count; i++)
				{
					if (null != this.mCache[i])
					{
						this.mCache[i].UpdateCount();
					}
				}
			}
		}

		// Token: 0x06009343 RID: 37699 RVA: 0x001B752C File Offset: 0x001B592C
		private void _updateDrugs()
		{
			base.StopAllCoroutines();
			base.StartCoroutine(this._updateDrugsIters());
		}

		// Token: 0x06009344 RID: 37700 RVA: 0x001B7544 File Offset: 0x001B5944
		private IEnumerator _updateDrugsIters()
		{
			this._unloadUnit();
			yield return Yielders.EndOfFrame;
			if (this.mDrugs != null)
			{
				for (int i = 0; i < this.mDrugs.Length; i++)
				{
					this._loadUnit(this.mDrugs[i]);
					yield return Yielders.EndOfFrame;
					if (this.mWithSplit && i < this.mDrugs.Length - 1)
					{
						this._loadUnitSplit();
					}
				}
			}
			yield break;
		}

		// Token: 0x06009345 RID: 37701 RVA: 0x001B755F File Offset: 0x001B595F
		private void Awake()
		{
			this._bindEvents();
			this._updateDrugs();
		}

		// Token: 0x06009346 RID: 37702 RVA: 0x001B756D File Offset: 0x001B596D
		private void OnDestroy()
		{
			this._unloadUnit();
			this._unbindEvents();
		}

		// Token: 0x06009347 RID: 37703 RVA: 0x001B757C File Offset: 0x001B597C
		public void SetBuffDrugs(IList<int> drugs)
		{
			if (drugs != null)
			{
				this.mDrugs = new int[drugs.Count];
				for (int i = 0; i < drugs.Count; i++)
				{
					this.mDrugs[i] = drugs[i];
				}
				this._updateDrugs();
			}
		}

		// Token: 0x04004A4D RID: 19021
		public bool mWithSplit;

		// Token: 0x04004A4E RID: 19022
		public int[] mDrugs = new int[0];

		// Token: 0x04004A4F RID: 19023
		private const string kPrefabUnit = "UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDrug";

		// Token: 0x04004A50 RID: 19024
		private const string kPrefabUnitSplit = "UIFlatten/Prefabs/Chapter/Normal/ChapterInfoDrugSplit";

		// Token: 0x04004A51 RID: 19025
		private List<ComChapterInfoDrugUnit> mCache = new List<ComChapterInfoDrugUnit>();

		// Token: 0x04004A52 RID: 19026
		private List<GameObject> mCacheSplit = new List<GameObject>();
	}
}
