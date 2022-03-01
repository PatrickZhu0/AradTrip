using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014D5 RID: 5333
	public class ChallengeModelDropControl : MonoBehaviour
	{
		// Token: 0x0600CED7 RID: 52951 RVA: 0x003306A9 File Offset: 0x0032EAA9
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CED8 RID: 52952 RVA: 0x003306B1 File Offset: 0x0032EAB1
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CED9 RID: 52953 RVA: 0x003306C0 File Offset: 0x0032EAC0
		private void BindEvents()
		{
			if (this.dropItemList != null)
			{
				this.dropItemList.Initialize();
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
		}

		// Token: 0x0600CEDA RID: 52954 RVA: 0x00330710 File Offset: 0x0032EB10
		private void UnBindEvents()
		{
			if (this.dropItemList != null)
			{
				ComUIListScript comUIListScript = this.dropItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnDropItemVisible));
			}
		}

		// Token: 0x0600CEDB RID: 52955 RVA: 0x0033074A File Offset: 0x0032EB4A
		private void ClearData()
		{
			this._dropItemIdList = null;
			this._dungeonModelTable = null;
		}

		// Token: 0x0600CEDC RID: 52956 RVA: 0x0033075C File Offset: 0x0032EB5C
		public void InitModelControl(DungeonModelTable dungeonModelTable)
		{
			this._dungeonModelTable = dungeonModelTable;
			if (this._dungeonModelTable == null)
			{
				Logger.LogErrorFormat("DungeonModelTable is null ", new object[0]);
				return;
			}
			if (this._dungeonModelTable.DropShow == null)
			{
				base.gameObject.CustomActive(false);
			}
			else
			{
				base.gameObject.CustomActive(true);
				this._dropItemIdList = this._dungeonModelTable.DropShow.ToList<int>();
				if (this.dropItemList != null)
				{
					this.dropItemList.SetElementAmount(this._dropItemIdList.Count);
				}
			}
		}

		// Token: 0x0600CEDD RID: 52957 RVA: 0x003307F8 File Offset: 0x0032EBF8
		private void OnDropItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._dropItemIdList == null)
			{
				return;
			}
			if (this.dropItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._dropItemIdList.Count)
			{
				return;
			}
			int num = this._dropItemIdList[item.m_index];
			ChallengeChapterDropItem component = item.GetComponent<ChallengeChapterDropItem>();
			if (component != null && num > 0)
			{
				component.InitItem(num, 0);
			}
		}

		// Token: 0x040078DE RID: 30942
		private DungeonModelTable _dungeonModelTable;

		// Token: 0x040078DF RID: 30943
		private List<int> _dropItemIdList;

		// Token: 0x040078E0 RID: 30944
		[SerializeField]
		private ComUIListScript dropItemList;
	}
}
