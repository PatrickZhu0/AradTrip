using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019F9 RID: 6649
	public class ComRelationInfoList
	{
		// Token: 0x17001D44 RID: 7492
		// (get) Token: 0x06010503 RID: 66819 RVA: 0x004936BD File Offset: 0x00491ABD
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D45 RID: 7493
		// (get) Token: 0x06010504 RID: 66820 RVA: 0x004936C5 File Offset: 0x00491AC5
		public RelationData Selected
		{
			get
			{
				return ComRelationInfo.ms_selected;
			}
		}

		// Token: 0x06010505 RID: 66821 RVA: 0x004936CC File Offset: 0x00491ACC
		public List<RelationData> GetRelationDatas()
		{
			return this.relationDatas;
		}

		// Token: 0x06010506 RID: 66822 RVA: 0x004936D4 File Offset: 0x00491AD4
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, ComRelationInfoList.OnItemSelected onItemSelected, RelationTabType eRaltionTabType, RelationData currentRelationData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.onItemSelected = (ComRelationInfoList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
			this.eRelationTabType = eRaltionTabType;
			this.currentRelationData = currentRelationData;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.comUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
			ComUIListScript comUIListScript4 = this.comUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			this.mScrollRect = this.comUIListScript.GetComponent<ScrollRect>();
			this._LoadAllRelations(ref this.relationDatas);
			if (this.relationDatas.Count > 0)
			{
				this._TrySetDefaultEquipment();
			}
		}

		// Token: 0x06010507 RID: 66823 RVA: 0x00493818 File Offset: 0x00491C18
		private ComRelationInfo _OnBindItemDelegate(GameObject itemObiect)
		{
			ComRelationInfo component = itemObiect.GetComponent<ComRelationInfo>();
			if (component != null)
			{
				return component;
			}
			return null;
		}

		// Token: 0x06010508 RID: 66824 RVA: 0x0049383C File Offset: 0x00491C3C
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null)
			{
				ComRelationInfo comRelationInfo = item.gameObjectBindScript as ComRelationInfo;
				if (comRelationInfo != null)
				{
					if (this.eRelationTabType == RelationTabType.RTT_FRIEND)
					{
						if (item.m_index >= 0 && item.m_index < this.relationDatas.Count)
						{
							comRelationInfo.OnItemVisible(this.relationDatas[item.m_index], this.eRelationTabType);
						}
					}
					else if (this.eRelationTabType == RelationTabType.RTT_RECENTLY)
					{
						if (item.m_index >= 0 && item.m_index < this.relationDatas.Count)
						{
							comRelationInfo.OnItemVisible(this.relationDatas[item.m_index], this.eRelationTabType);
						}
					}
					else if (this.eRelationTabType == RelationTabType.RTT_BLACK && item.m_index >= 0 && item.m_index < this.relationDatas.Count)
					{
						comRelationInfo.OnItemVisible(this.relationDatas[item.m_index], this.eRelationTabType);
					}
				}
				if (ComRelationInfo.ms_selected == comRelationInfo.RelationData)
				{
					comRelationInfo.OnItemChangeDisplay(true);
				}
				else
				{
					comRelationInfo.OnItemChangeDisplay(false);
				}
			}
		}

		// Token: 0x06010509 RID: 66825 RVA: 0x0049397C File Offset: 0x00491D7C
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComRelationInfo comRelationInfo = item.gameObjectBindScript as ComRelationInfo;
			ComRelationInfo.ms_selected = ((!(comRelationInfo == null)) ? comRelationInfo.RelationData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComRelationInfo.ms_selected);
			}
		}

		// Token: 0x0601050A RID: 66826 RVA: 0x004939D0 File Offset: 0x00491DD0
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComRelationInfo comRelationInfo = item.gameObjectBindScript as ComRelationInfo;
			if (comRelationInfo != null)
			{
				comRelationInfo.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0601050B RID: 66827 RVA: 0x004939FC File Offset: 0x00491DFC
		public void RefreshAllRelations(RelationTabType eRelationTabType)
		{
			this.eRelationTabType = eRelationTabType;
			this._LoadAllRelations(ref this.relationDatas);
			if (this.relationDatas.Count > 0)
			{
				this._TrySetDefaultEquipment();
			}
			if (this.mScrollRect != null && this.mScrollRect.verticalNormalizedPosition <= 0.04f)
			{
				this.mScrollRect.verticalNormalizedPosition = 0f;
			}
		}

		// Token: 0x0601050C RID: 66828 RVA: 0x00493A6C File Offset: 0x00491E6C
		private void _LoadAllRelations(ref List<RelationData> kRelationDtatas)
		{
			kRelationDtatas.Clear();
			List<Vector2> list = new List<Vector2>();
			if (this.eRelationTabType == RelationTabType.RTT_RECENTLY)
			{
				List<PrivateChatPlayerData> list2 = new List<PrivateChatPlayerData>();
				List<PrivateChatPlayerData> priChatList = DataManager<RelationDataManager>.GetInstance().GetPriChatList();
				list2.AddRange(priChatList);
				list2.Sort(delegate(PrivateChatPlayerData x, PrivateChatPlayerData y)
				{
					if (x.relationData.isOnline != y.relationData.isOnline)
					{
						return (x.relationData.isOnline != 1) ? 1 : -1;
					}
					if (x.relationData.status != y.relationData.status)
					{
						return (x.relationData.status >= y.relationData.status) ? 1 : -1;
					}
					if (x.chatNum != y.chatNum)
					{
						return (y.chatNum >= x.chatNum) ? 1 : -1;
					}
					if (x.iOrder != y.iOrder)
					{
						return y.iOrder - x.iOrder;
					}
					return (x.relationData.uid >= y.relationData.uid) ? ((x.relationData.uid != y.relationData.uid) ? 1 : 0) : -1;
				});
				kRelationDtatas = new List<RelationData>();
				for (int i = 0; i < list2.Count; i++)
				{
					kRelationDtatas.Add(list2[i].relationData);
				}
			}
			else if (this.eRelationTabType == RelationTabType.RTT_FRIEND)
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
				List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
				List<RelationData> relation3 = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				kRelationDtatas = new List<RelationData>();
				kRelationDtatas.AddRange(relation2);
				kRelationDtatas.AddRange(relation3);
				kRelationDtatas.AddRange(relation);
				kRelationDtatas.Sort(new Comparison<RelationData>(this._SortMyFriend));
			}
			else if (this.eRelationTabType == RelationTabType.RTT_BLACK)
			{
				List<RelationData> relation4 = DataManager<RelationDataManager>.GetInstance().GetRelation(2);
				kRelationDtatas = new List<RelationData>();
				kRelationDtatas.AddRange(relation4);
			}
			for (int j = 0; j < kRelationDtatas.Count; j++)
			{
				list.Add(new Vector2(806f, 186f));
			}
			this.comUIListScript.SetElementAmount(kRelationDtatas.Count, list);
		}

		// Token: 0x0601050D RID: 66829 RVA: 0x00493BDC File Offset: 0x00491FDC
		private int _SortMyFriend(RelationData x, RelationData y)
		{
			if (x.isOnline != y.isOnline)
			{
				return (x.isOnline != 1) ? 1 : -1;
			}
			if (x.status != y.status)
			{
				return (x.status >= y.status) ? 1 : -1;
			}
			if (x.intimacy != y.intimacy)
			{
				return (y.intimacy >= x.intimacy) ? 1 : -1;
			}
			if (x.level != y.level)
			{
				return (int)(y.level - x.level);
			}
			if (x.seasonLv != y.seasonLv)
			{
				return (y.seasonLv >= x.seasonLv) ? 1 : -1;
			}
			return (x.uid >= y.uid) ? 1 : -1;
		}

		// Token: 0x0601050E RID: 66830 RVA: 0x00493CC4 File Offset: 0x004920C4
		private void _TrySetDefaultEquipment()
		{
			if (ComRelationInfo.ms_selected != null)
			{
				RelationData relationData = this.relationDatas.Find((RelationData x) => x.uid == ComRelationInfo.ms_selected.uid);
				if (relationData != null)
				{
					ComRelationInfo.ms_selected = relationData;
				}
				else
				{
					ComRelationInfo.ms_selected = null;
				}
			}
			int iBindIndex = -1;
			if (ComRelationInfo.ms_selected != null)
			{
				for (int i = 0; i < this.relationDatas.Count; i++)
				{
					if (this.relationDatas[i].uid == ComRelationInfo.ms_selected.uid)
					{
						iBindIndex = i;
						break;
					}
				}
			}
			else if (this.relationDatas.Count > 0 && this.currentRelationData != null)
			{
				for (int j = 0; j < this.relationDatas.Count; j++)
				{
					if (this.relationDatas[j].uid == this.currentRelationData.uid)
					{
						iBindIndex = j;
						break;
					}
				}
			}
			this._SetSelectedRelationItem(iBindIndex);
		}

		// Token: 0x0601050F RID: 66831 RVA: 0x00493DD8 File Offset: 0x004921D8
		private void _SetSelectedRelationItem(int iBindIndex)
		{
			if (iBindIndex >= 0 && iBindIndex < this.relationDatas.Count)
			{
				if (ComRelationInfo.ms_selected == this.relationDatas[iBindIndex])
				{
					return;
				}
				ComRelationInfo.ms_selected = this.relationDatas[iBindIndex];
				if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.comUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.comUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.comUIListScript.SelectElement(-1, true);
				ComRelationInfo.ms_selected = null;
			}
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComRelationInfo.ms_selected);
			}
		}

		// Token: 0x06010510 RID: 66832 RVA: 0x00493E84 File Offset: 0x00492284
		public void UnInitialize()
		{
			if (this.comUIListScript != null)
			{
				ComUIListScript comUIListScript = this.comUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.comUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.comUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.comUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
				this.comUIListScript = null;
			}
			this.eRelationTabType = RelationTabType.RTT_RECENTLY;
			this.onItemSelected = (ComRelationInfoList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.clientFrame = null;
			this.relationDatas.Clear();
			ComRelationInfo.ms_selected = null;
			this.bInitialize = false;
		}

		// Token: 0x0400A540 RID: 42304
		private bool bInitialize;

		// Token: 0x0400A541 RID: 42305
		private ClientFrame clientFrame;

		// Token: 0x0400A542 RID: 42306
		private GameObject gameObject;

		// Token: 0x0400A543 RID: 42307
		private ComUIListScript comUIListScript;

		// Token: 0x0400A544 RID: 42308
		public ComRelationInfoList.OnItemSelected onItemSelected;

		// Token: 0x0400A545 RID: 42309
		private List<RelationData> relationDatas = new List<RelationData>();

		// Token: 0x0400A546 RID: 42310
		public RelationTabType eRelationTabType;

		// Token: 0x0400A547 RID: 42311
		private RelationData currentRelationData;

		// Token: 0x0400A548 RID: 42312
		private ScrollRect mScrollRect;

		// Token: 0x020019FA RID: 6650
		// (Invoke) Token: 0x06010514 RID: 66836
		public delegate void OnItemSelected(RelationData relationData);
	}
}
