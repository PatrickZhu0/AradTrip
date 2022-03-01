using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F76 RID: 3958
	public class ComConsumeItemGroup : MonoBehaviour
	{
		// Token: 0x06009909 RID: 39177 RVA: 0x001D6C44 File Offset: 0x001D5044
		private void Awake()
		{
			if (this.mComConsumeGroup != null)
			{
				for (int i = 0; i < this.mComConsumeGroup.Count; i++)
				{
					ComCommonConsume comCommonConsume = this.mComConsumeGroup[i];
					if (!(comCommonConsume == null))
					{
						if (!this.mOriginalConsumeIds.Contains(comCommonConsume.mItemID))
						{
							this.mOriginalConsumeIds.Add(comCommonConsume.mItemID);
						}
						this.mConsumeItemModels.Add(new ComConsumeItemModel
						{
							comConsume = comCommonConsume,
							index = i
						});
					}
				}
			}
		}

		// Token: 0x0600990A RID: 39178 RVA: 0x001D6CDD File Offset: 0x001D50DD
		private void OnDestroy()
		{
			if (this.mOriginalConsumeIds != null)
			{
				this.mOriginalConsumeIds.Clear();
			}
			if (this.mConsumeItemModels != null)
			{
				this.mConsumeItemModels.Clear();
			}
		}

		// Token: 0x0600990B RID: 39179 RVA: 0x001D6D0C File Offset: 0x001D510C
		private void _SetIndexConsumeItemActivated(int index, bool bActivated)
		{
			if (this.mConsumeItemModels != null && this.mConsumeItemModels.Count > 0)
			{
				for (int i = 0; i < this.mConsumeItemModels.Count; i++)
				{
					ComConsumeItemModel comConsumeItemModel = this.mConsumeItemModels[i];
					if (comConsumeItemModel != null && comConsumeItemModel.index == index)
					{
						comConsumeItemModel.comConsume.CustomActive(bActivated);
					}
				}
			}
		}

		// Token: 0x0600990C RID: 39180 RVA: 0x001D6D7C File Offset: 0x001D517C
		private void _SetSelectedConsumeActive(ComConsumeItemModel model, bool bActivated)
		{
			if (this.mConsumeItemModels != null && this.mConsumeItemModels.Count > 0)
			{
				for (int i = 0; i < this.mConsumeItemModels.Count; i++)
				{
					ComConsumeItemModel comConsumeItemModel = this.mConsumeItemModels[i];
					if (comConsumeItemModel != null && comConsumeItemModel == model)
					{
						comConsumeItemModel.comConsume.CustomActive(bActivated);
					}
				}
			}
		}

		// Token: 0x0600990D RID: 39181 RVA: 0x001D6DE8 File Offset: 0x001D51E8
		private bool _GetIndexConsumeItemActivated(int index)
		{
			if (this.mConsumeItemModels != null && this.mConsumeItemModels.Count > 0)
			{
				for (int i = 0; i < this.mConsumeItemModels.Count; i++)
				{
					ComConsumeItemModel comConsumeItemModel = this.mConsumeItemModels[i];
					if (comConsumeItemModel != null && comConsumeItemModel.index == index)
					{
						return comConsumeItemModel.comConsume.gameObject.activeSelf;
					}
				}
			}
			return false;
		}

		// Token: 0x0600990E RID: 39182 RVA: 0x001D6E5E File Offset: 0x001D525E
		private bool _GetSelectedConsumeItemActivated(ComConsumeItemModel model)
		{
			return model != null && model.comConsume != null && model.comConsume.gameObject.activeSelf;
		}

		// Token: 0x0600990F RID: 39183 RVA: 0x001D6E8C File Offset: 0x001D528C
		private ComConsumeItemModel _CheckConsumeItemGroupHasSameItemId(int itemId)
		{
			if (this.mConsumeItemModels == null)
			{
				return null;
			}
			for (int i = 0; i < this.mConsumeItemModels.Count; i++)
			{
				ComConsumeItemModel comConsumeItemModel = this.mConsumeItemModels[i];
				if (comConsumeItemModel != null && !(comConsumeItemModel.comConsume == null))
				{
					if (comConsumeItemModel.comConsume.mItemID == itemId)
					{
						return comConsumeItemModel;
					}
				}
			}
			return null;
		}

		// Token: 0x06009910 RID: 39184 RVA: 0x001D6EFF File Offset: 0x001D52FF
		public List<int> GetOriginalConsumeIds()
		{
			return this.mOriginalConsumeIds;
		}

		// Token: 0x06009911 RID: 39185 RVA: 0x001D6F07 File Offset: 0x001D5307
		public List<ComCommonConsume> GetConsumeGroup()
		{
			return this.mComConsumeGroup;
		}

		// Token: 0x06009912 RID: 39186 RVA: 0x001D6F0F File Offset: 0x001D530F
		public bool GetGroupEnable()
		{
			return this.bGroupEnable;
		}

		// Token: 0x06009913 RID: 39187 RVA: 0x001D6F18 File Offset: 0x001D5318
		public void SetItemActiveByItemId(int itemId, bool active)
		{
			if (!this.bGroupEnable)
			{
				return;
			}
			if (this.mConsumeItemModels == null)
			{
				return;
			}
			if (itemId <= 0)
			{
				return;
			}
			for (int i = 0; i < this.mConsumeItemModels.Count; i++)
			{
				ComConsumeItemModel comConsumeItemModel = this.mConsumeItemModels[i];
				if (comConsumeItemModel != null && !(comConsumeItemModel.comConsume == null))
				{
					if (comConsumeItemModel.comConsume.mItemID == itemId)
					{
						this._SetSelectedConsumeActive(comConsumeItemModel, active);
						break;
					}
				}
			}
		}

		// Token: 0x06009914 RID: 39188 RVA: 0x001D6FA8 File Offset: 0x001D53A8
		public void SetAllItemActive(bool active)
		{
			if (!this.bGroupEnable)
			{
				return;
			}
			if (this.mConsumeItemModels == null)
			{
				return;
			}
			for (int i = 0; i < this.mConsumeItemModels.Count; i++)
			{
				ComConsumeItemModel model = this.mConsumeItemModels[i];
				this._SetSelectedConsumeActive(model, active);
			}
		}

		// Token: 0x06009915 RID: 39189 RVA: 0x001D7000 File Offset: 0x001D5400
		public void _ResetSelectedItemIds(int[] itemIds, bool needitemShow, ComCommonConsume.eType iType = ComCommonConsume.eType.Item, ComCommonConsume.eCountType iCountType = ComCommonConsume.eCountType.Fatigue)
		{
			if (!this.bGroupEnable)
			{
				return;
			}
			if (itemIds == null || itemIds.Length == 0)
			{
				return;
			}
			if (this.mConsumeItemModels == null)
			{
				return;
			}
			if (itemIds.Length > this.mConsumeItemModels.Count)
			{
				Logger.LogError("[ComConsumeItemGroup] - ResetSelectedItemIds, out params consume itemIds length > mComConsume Items count!!!");
				return;
			}
			for (int i = 0; i < itemIds.Length; i++)
			{
				ComConsumeItemModel comConsumeItemModel = this._CheckConsumeItemGroupHasSameItemId(itemIds[i]);
				if (comConsumeItemModel != null)
				{
					comConsumeItemModel.index = i;
					this._SetSelectedConsumeActive(comConsumeItemModel, needitemShow);
				}
				else
				{
					bool flag = false;
					for (int j = 0; j < this.mConsumeItemModels.Count; j++)
					{
						ComConsumeItemModel comConsumeItemModel2 = this.mConsumeItemModels[j];
						if (comConsumeItemModel2 != null && !(comConsumeItemModel2.comConsume == null))
						{
							if (!this._GetSelectedConsumeItemActivated(comConsumeItemModel2))
							{
								if (!flag)
								{
									comConsumeItemModel2.comConsume.SetData(iType, iCountType, itemIds[i]);
									comConsumeItemModel2.index = i;
									flag = true;
									this._SetSelectedConsumeActive(comConsumeItemModel2, needitemShow);
								}
							}
						}
					}
				}
			}
			for (int k = 0; k < this.mConsumeItemModels.Count; k++)
			{
				ComConsumeItemModel comConsumeItemModel3 = this.mConsumeItemModels[k];
				if (comConsumeItemModel3 != null && !(comConsumeItemModel3.comConsume == null))
				{
					comConsumeItemModel3.comConsume.transform.SetSiblingIndex(comConsumeItemModel3.index);
				}
			}
		}

		// Token: 0x06009916 RID: 39190 RVA: 0x001D717B File Offset: 0x001D557B
		public void ResetSelectedItemIds(int[] itemIds, bool needAcc = false, bool needShow = false, ComCommonConsume.eType iType = ComCommonConsume.eType.Item, ComCommonConsume.eCountType iCountType = ComCommonConsume.eCountType.Fatigue)
		{
			if (!this.bGroupEnable)
			{
				return;
			}
			if (itemIds == null || itemIds.Length <= 0)
			{
				return;
			}
			if (!needAcc)
			{
				this.SetAllItemActive(false);
			}
			this._ResetSelectedItemIds(itemIds, needShow, iType, iCountType);
		}

		// Token: 0x06009917 RID: 39191 RVA: 0x001D71B4 File Offset: 0x001D55B4
		public void ResetOriginalItemIdsWithShow(bool needShow = true, ComCommonConsume.eType iType = ComCommonConsume.eType.Item, ComCommonConsume.eCountType iCountType = ComCommonConsume.eCountType.Fatigue)
		{
			if (!this.bGroupEnable)
			{
				return;
			}
			if (this.mOriginalConsumeIds != null && this.mOriginalConsumeIds.Count > 0)
			{
				this.SetAllItemActive(false);
				this._ResetSelectedItemIds(this.mOriginalConsumeIds.ToArray(), needShow, iType, iCountType);
			}
		}

		// Token: 0x04004ED4 RID: 20180
		[SerializeField]
		private List<ComCommonConsume> mComConsumeGroup;

		// Token: 0x04004ED5 RID: 20181
		[SerializeField]
		private bool bGroupEnable = true;

		// Token: 0x04004ED6 RID: 20182
		private List<ComConsumeItemModel> mConsumeItemModels = new List<ComConsumeItemModel>();

		// Token: 0x04004ED7 RID: 20183
		private List<int> mOriginalConsumeIds = new List<int>();
	}
}
