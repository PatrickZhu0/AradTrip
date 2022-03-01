using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200110C RID: 4364
	public class ChijiHandInEquipmentView : MonoBehaviour
	{
		// Token: 0x0600A557 RID: 42327 RVA: 0x00221C4C File Offset: 0x0022004C
		private void Awake()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
				this.mCloseBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			if (this.mSubmitBtn != null)
			{
				this.mSubmitBtn.onClick.RemoveAllListeners();
				this.mSubmitBtn.onClick.AddListener(new UnityAction(this.OnSubmitBtnClick));
			}
			this.InitEquipItemListScripts();
		}

		// Token: 0x0600A558 RID: 42328 RVA: 0x00221CDC File Offset: 0x002200DC
		private void OnDestroy()
		{
			if (ChijiHandInEquipmentView.mHandInEquipmentList != null)
			{
				ChijiHandInEquipmentView.mHandInEquipmentList.Clear();
			}
			if (this.mAllEquipmentList != null)
			{
				this.mAllEquipmentList.Clear();
			}
			if (this.m_NpcData != null)
			{
				this.m_NpcData.guid = 0UL;
				this.m_NpcData.npcTableId = 0;
			}
			this.UnInitEquipItemListScripts();
		}

		// Token: 0x0600A559 RID: 42329 RVA: 0x00221D40 File Offset: 0x00220140
		public void InitView(ChijiNpcData NpcData)
		{
			this.m_NpcData = NpcData;
			if (ChijiHandInEquipmentView.mHandInEquipmentList == null)
			{
				ChijiHandInEquipmentView.mHandInEquipmentList = new List<ulong>();
			}
			else
			{
				ChijiHandInEquipmentView.mHandInEquipmentList.Clear();
			}
			if (this.mAllEquipmentList == null)
			{
				this.mAllEquipmentList = new List<ItemData>();
			}
			else
			{
				this.mAllEquipmentList.Clear();
			}
			this.LoadAllEquipment();
		}

		// Token: 0x0600A55A RID: 42330 RVA: 0x00221DA4 File Offset: 0x002201A4
		private void LoadAllEquipment()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					this.mAllEquipmentList.Add(item);
				}
			}
			if (this.mEquipItemListScripts != null)
			{
				this.mEquipItemListScripts.SetElementAmount(this.mAllEquipmentList.Count);
			}
		}

		// Token: 0x0600A55B RID: 42331 RVA: 0x00221E24 File Offset: 0x00220224
		private void InitEquipItemListScripts()
		{
			if (this.mEquipItemListScripts != null)
			{
				this.mEquipItemListScripts.Initialize();
				ComUIListScript comUIListScript = this.mEquipItemListScripts;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipItemListScripts;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600A55C RID: 42332 RVA: 0x00221E9C File Offset: 0x0022029C
		private void UnInitEquipItemListScripts()
		{
			if (this.mEquipItemListScripts != null)
			{
				ComUIListScript comUIListScript = this.mEquipItemListScripts;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipItemListScripts;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600A55D RID: 42333 RVA: 0x00221F08 File Offset: 0x00220308
		private ChijiHandInEquipmentItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ChijiHandInEquipmentItem>();
		}

		// Token: 0x0600A55E RID: 42334 RVA: 0x00221F10 File Offset: 0x00220310
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ChijiHandInEquipmentItem chijiHandInEquipmentItem = item.gameObjectBindScript as ChijiHandInEquipmentItem;
			if (chijiHandInEquipmentItem != null && item.m_index >= 0 && item.m_index < this.mAllEquipmentList.Count)
			{
				chijiHandInEquipmentItem.OnItemVisiable(this.mAllEquipmentList[item.m_index], new OnEquipItemClickDelegate(this.OnEquipItemClick));
			}
		}

		// Token: 0x0600A55F RID: 42335 RVA: 0x00221F7A File Offset: 0x0022037A
		private void OnEquipItemClick(ulong guid, bool isAdd)
		{
			if (isAdd)
			{
				ChijiHandInEquipmentView.mHandInEquipmentList.Add(guid);
			}
			else
			{
				ChijiHandInEquipmentView.mHandInEquipmentList.Remove(guid);
			}
			ChijiHandInEquipmentView.hasSelectNumber = ChijiHandInEquipmentView.mHandInEquipmentList.Count;
		}

		// Token: 0x0600A560 RID: 42336 RVA: 0x00221FAD File Offset: 0x002203AD
		private void OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiHandInEquipmentFrame>(null, false);
		}

		// Token: 0x0600A561 RID: 42337 RVA: 0x00221FBC File Offset: 0x002203BC
		private void OnSubmitBtnClick()
		{
			if (ChijiHandInEquipmentView.mHandInEquipmentList.Count < this.mMaxHandInNumber)
			{
				SystemNotifyManager.SysNotifyTextAnimation(string.Format("选择的装备不足{0}个，不可提交!", this.mMaxHandInNumber), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			string msgContent = string.Format("是否确定上交选中的{0}件装备?", this.mMaxHandInNumber);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, new UnityAction(this._Subitmit), null, 0f, false);
		}

		// Token: 0x0600A562 RID: 42338 RVA: 0x00222029 File Offset: 0x00220429
		private void _Subitmit()
		{
			DataManager<ChijiDataManager>.GetInstance().SendNpcTradeReq((uint)this.m_NpcData.npcTableId, this.m_NpcData.guid, ChijiHandInEquipmentView.mHandInEquipmentList);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiNpcDialogFrame>(null, false);
			this.OnCloseBtnClick();
		}

		// Token: 0x04005C47 RID: 23623
		private ChijiNpcData m_NpcData = new ChijiNpcData();

		// Token: 0x04005C48 RID: 23624
		[SerializeField]
		private ComUIListScript mEquipItemListScripts;

		// Token: 0x04005C49 RID: 23625
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x04005C4A RID: 23626
		[SerializeField]
		private Button mSubmitBtn;

		// Token: 0x04005C4B RID: 23627
		[SerializeField]
		private int mMaxHandInNumber = 5;

		// Token: 0x04005C4C RID: 23628
		public static List<ulong> mHandInEquipmentList = new List<ulong>();

		// Token: 0x04005C4D RID: 23629
		private List<ItemData> mAllEquipmentList = new List<ItemData>();

		// Token: 0x04005C4E RID: 23630
		public static int hasSelectNumber = 0;
	}
}
