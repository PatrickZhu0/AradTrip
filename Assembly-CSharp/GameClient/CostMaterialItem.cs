using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B9D RID: 7069
	public sealed class CostMaterialItem : CachedObject
	{
		// Token: 0x17001DA7 RID: 7591
		// (get) Token: 0x06011560 RID: 71008 RVA: 0x00503473 File Offset: 0x00501873
		public ItemData ItemData
		{
			get
			{
				return this.itemData;
			}
		}

		// Token: 0x06011561 RID: 71009 RVA: 0x0050347B File Offset: 0x0050187B
		public override void OnDestroy()
		{
			this.comItem.Setup(null, null);
			this.comItem = null;
			this.itemData = null;
		}

		// Token: 0x06011562 RID: 71010 RVA: 0x00503498 File Offset: 0x00501898
		public override void OnCreate(object[] param)
		{
			this.goParent = (param[0] as GameObject);
			this.goPrefab = (param[1] as GameObject);
			this.itemData = (param[2] as ItemData);
			this.frame = (param[3] as ClientFrame);
			this.bForceShow = (bool)param[4];
			this.iNeedCount = (int)param[5];
			if (this.goPrefab == null)
			{
				return;
			}
			if (this.goLocal == null)
			{
				this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
				Utility.AttachTo(this.goLocal, this.goParent, false);
				this.name = Utility.FindComponent<Text>(this.goLocal, "Name", true);
				this.comItem = this.frame.CreateComItem(this.goLocal);
				this.comItem.gameObject.transform.SetAsFirstSibling();
				this.count = Utility.FindComponent<Text>(this.goLocal, "Count", true);
				this.goAcquired = Utility.FindChild(this.goLocal, "ItemComLink");
				this.btnAcquired = Utility.FindComponent<Button>(this.goLocal, "ItemComLink", true);
				this.btnAcquired.onClick.RemoveAllListeners();
				this.btnAcquired.onClick.AddListener(delegate()
				{
					if (this.itemData != null)
					{
						ItemComeLink.OnLink(this.itemData.TableID, 0, true, null, false, false, false, null, string.Empty);
					}
				});
			}
			this.Enable();
			this.SetAsLastSibling();
			this._Update();
		}

		// Token: 0x06011563 RID: 71011 RVA: 0x00503604 File Offset: 0x00501A04
		public override void SetAsLastSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsLastSibling();
			}
		}

		// Token: 0x06011564 RID: 71012 RVA: 0x00503627 File Offset: 0x00501A27
		public override void OnRecycle()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x06011565 RID: 71013 RVA: 0x00503646 File Offset: 0x00501A46
		public override void OnDecycle(object[] param)
		{
			this.OnCreate(param);
		}

		// Token: 0x06011566 RID: 71014 RVA: 0x0050364F File Offset: 0x00501A4F
		public override void OnRefresh(object[] param)
		{
			this.itemData = (param[0] as ItemData);
			this.bForceShow = (bool)param[1];
			this.iNeedCount = (int)param[2];
			this._Update();
		}

		// Token: 0x06011567 RID: 71015 RVA: 0x00503681 File Offset: 0x00501A81
		public override void Enable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(true);
			}
		}

		// Token: 0x06011568 RID: 71016 RVA: 0x005036A0 File Offset: 0x00501AA0
		public void SetAsFirstSibling()
		{
			if (this.goLocal != null)
			{
				this.goLocal.transform.SetAsFirstSibling();
			}
		}

		// Token: 0x06011569 RID: 71017 RVA: 0x005036C3 File Offset: 0x00501AC3
		public override void Disable()
		{
			if (this.goLocal != null)
			{
				this.goLocal.CustomActive(false);
			}
		}

		// Token: 0x0601156A RID: 71018 RVA: 0x005036E2 File Offset: 0x00501AE2
		public override bool NeedFilter(object[] param)
		{
			return !this.bForceShow && this.iNeedCount <= 0;
		}

		// Token: 0x0601156B RID: 71019 RVA: 0x005036FD File Offset: 0x00501AFD
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0601156C RID: 71020 RVA: 0x00503718 File Offset: 0x00501B18
		private void _Update()
		{
			this.comItem.Setup(this.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			this.name.text = this.itemData.GetColorName(string.Empty, false);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemData.TableID, true);
			if (this.itemData.Type == ItemTable.eType.INCOME)
			{
				this.count.text = string.Format("{0}", this.iNeedCount);
			}
			else
			{
				this.count.text = string.Format("{0}/{1}", ownedItemCount, this.iNeedCount);
			}
			if (ownedItemCount < this.iNeedCount && this.iNeedCount > 0)
			{
				this.count.color = Color.red;
			}
			else
			{
				this.count.color = Color.white;
			}
			if (this.itemData != null)
			{
				this.itemData.Count = 1;
			}
			this.goLocal.name = this.itemData.TableID.ToString();
			this.goAcquired.CustomActive(ownedItemCount < this.iNeedCount && this.iNeedCount > 0);
			this.comItem.SetShowNotEnoughState(this.goAcquired.activeSelf);
		}

		// Token: 0x0400B381 RID: 45953
		private GameObject goLocal;

		// Token: 0x0400B382 RID: 45954
		private GameObject goPrefab;

		// Token: 0x0400B383 RID: 45955
		private GameObject goParent;

		// Token: 0x0400B384 RID: 45956
		private GameObject goAcquired;

		// Token: 0x0400B385 RID: 45957
		private Button btnAcquired;

		// Token: 0x0400B386 RID: 45958
		private int iNeedCount;

		// Token: 0x0400B387 RID: 45959
		private bool bForceShow;

		// Token: 0x0400B388 RID: 45960
		private ItemData itemData;

		// Token: 0x0400B389 RID: 45961
		private ClientFrame frame;

		// Token: 0x0400B38A RID: 45962
		private Text name;

		// Token: 0x0400B38B RID: 45963
		private Text count;

		// Token: 0x0400B38C RID: 45964
		private ComItem comItem;
	}
}
