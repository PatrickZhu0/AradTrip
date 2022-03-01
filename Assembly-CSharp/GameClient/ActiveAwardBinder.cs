using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000002 RID: 2
	internal class ActiveAwardBinder : MonoBehaviour
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000458
		private void Start()
		{
			this._CheckStatus();
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002104 File Offset: 0x00000504
		private void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
			this._destoryComItem();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000021AF File Offset: 0x000005AF
		private void _destoryComItem()
		{
			if (this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021D4 File Offset: 0x000005D4
		private void _createComItem(int id, GameObject root)
		{
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(id);
			if (commonItemTableDataByID != null)
			{
				this.comItem = ComItemManager.Create(root);
				this.comItem.Setup(commonItemTableDataByID, null);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000220C File Offset: 0x0000060C
		private void _BindImage()
		{
			this.bindImg.enabled = false;
			if (this.bindImg == null)
			{
				return;
			}
			List<AwardItemData> activeAwards = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.iBindActiveID);
			if (activeAwards == null || activeAwards.Count <= 0)
			{
				return;
			}
			if (null == this.comItem)
			{
				this._createComItem(activeAwards[0].ID, this.bindImg.gameObject);
			}
			else if (this.comItem.ItemData.TableID != activeAwards[0].ID)
			{
				this._destoryComItem();
				this._createComItem(activeAwards[0].ID, this.bindImg.gameObject);
			}
			this.bindImg.enabled = false;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022E0 File Offset: 0x000006E0
		private void _CheckStatus()
		{
			bool bActive = true;
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iActiveConfigID);
			if (activeData != null)
			{
				bActive = (activeData.mainInfo.state == 0);
			}
			base.gameObject.CustomActive(bActive);
			this._BindImage();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002327 File Offset: 0x00000727
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this._CheckStatus();
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000232F File Offset: 0x0000072F
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000234D File Offset: 0x0000074D
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000236B File Offset: 0x0000076B
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.iActiveConfigID)
			{
				this._CheckStatus();
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000238C File Offset: 0x0000078C
		public void _OnClickPreView()
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(this.iBindActiveID, string.Empty, string.Empty) == null)
			{
				return;
			}
			ActiveAwardFrameData activeAwardFrameData = new ActiveAwardFrameData();
			activeAwardFrameData.title = string.Format(TR.Value("activity_award_title"), (this.iActiveConfigID - 7000) / 100);
			activeAwardFrameData.datas = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.iBindActiveID);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveAwardFrame>(FrameLayer.Middle, activeAwardFrameData, string.Empty);
		}

		// Token: 0x04000001 RID: 1
		public int iBindActiveID;

		// Token: 0x04000002 RID: 2
		public int iActiveConfigID;

		// Token: 0x04000003 RID: 3
		public Image bindImg;

		// Token: 0x04000004 RID: 4
		public ComItem comItem;
	}
}
