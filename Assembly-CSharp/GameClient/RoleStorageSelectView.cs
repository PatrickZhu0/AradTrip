using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001704 RID: 5892
	public class RoleStorageSelectView : MonoBehaviour
	{
		// Token: 0x0600E76C RID: 59244 RVA: 0x003D049F File Offset: 0x003CE89F
		private void Awake()
		{
		}

		// Token: 0x0600E76D RID: 59245 RVA: 0x003D04A1 File Offset: 0x003CE8A1
		private void OnDestroy()
		{
		}

		// Token: 0x0600E76E RID: 59246 RVA: 0x003D04A4 File Offset: 0x003CE8A4
		public void InitRoleStorageDropDownView(OnRoleStorageSelectItemClick onRoleStorageSelectItemClick)
		{
			if (this.roleStorageSelectItemList != null && this.roleStorageSelectItemList.Count > 0)
			{
				int count = this.roleStorageSelectItemList.Count;
				for (int i = 0; i < count; i++)
				{
					RoleStorageSelectItem roleStorageSelectItem = this.roleStorageSelectItemList[i];
					if (!(roleStorageSelectItem == null))
					{
						int itemIndex = i + 1;
						roleStorageSelectItem.InitItem(itemIndex, onRoleStorageSelectItemClick);
					}
				}
			}
			this.OnUpdateRoleStorageDropDownView();
		}

		// Token: 0x0600E76F RID: 59247 RVA: 0x003D051C File Offset: 0x003CE91C
		public void OnUpdateRoleStorageDropDownView()
		{
			int roleStorageOwnerStorageNumber = DataManager<StorageDataManager>.GetInstance().GetRoleStorageOwnerStorageNumber();
			this.UpdateRoleStorageDropDownBg(roleStorageOwnerStorageNumber);
			if (this.roleStorageSelectItemList == null || this.roleStorageSelectItemList.Count <= 0)
			{
				return;
			}
			int needShowItemNumber = StorageUtility.GetNeedShowItemNumber(roleStorageOwnerStorageNumber);
			int count = this.roleStorageSelectItemList.Count;
			for (int i = 0; i < count; i++)
			{
				RoleStorageSelectItem roleStorageSelectItem = this.roleStorageSelectItemList[i];
				if (!(roleStorageSelectItem == null))
				{
					if (i < needShowItemNumber)
					{
						CommonUtility.UpdateGameObjectVisible(roleStorageSelectItem.gameObject, true);
						roleStorageSelectItem.OnUpdateItem(roleStorageOwnerStorageNumber);
					}
					else
					{
						CommonUtility.UpdateGameObjectVisible(roleStorageSelectItem.gameObject, false);
					}
				}
			}
		}

		// Token: 0x0600E770 RID: 59248 RVA: 0x003D05CC File Offset: 0x003CE9CC
		public void OnUpdateRoleStorageDropDownName(int itemIndex)
		{
			if (this.roleStorageSelectItemList != null && this.roleStorageSelectItemList.Count > 0)
			{
				for (int i = 0; i < this.roleStorageSelectItemList.Count; i++)
				{
					RoleStorageSelectItem roleStorageSelectItem = this.roleStorageSelectItemList[i];
					if (!(roleStorageSelectItem == null))
					{
						if (roleStorageSelectItem.GetItemIndex() == itemIndex)
						{
							roleStorageSelectItem.OnUpdateItemName();
						}
					}
				}
			}
		}

		// Token: 0x0600E771 RID: 59249 RVA: 0x003D0648 File Offset: 0x003CEA48
		private void UpdateRoleStorageDropDownBg(int totalNumber)
		{
			CommonUtility.UpdateGameObjectVisible(this.firstBg, false);
			CommonUtility.UpdateGameObjectVisible(this.secondBg, false);
			CommonUtility.UpdateGameObjectVisible(this.thirdBg, false);
			int needShowLineNumber = StorageUtility.GetNeedShowLineNumber(totalNumber);
			if (needShowLineNumber == 1)
			{
				CommonUtility.UpdateGameObjectVisible(this.firstBg, true);
			}
			else if (needShowLineNumber == 2)
			{
				CommonUtility.UpdateGameObjectVisible(this.secondBg, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.thirdBg, true);
			}
		}

		// Token: 0x04008C60 RID: 35936
		[Space(10f)]
		[Header("Bg")]
		[Space(10f)]
		[SerializeField]
		private GameObject firstBg;

		// Token: 0x04008C61 RID: 35937
		[SerializeField]
		private GameObject secondBg;

		// Token: 0x04008C62 RID: 35938
		[SerializeField]
		private GameObject thirdBg;

		// Token: 0x04008C63 RID: 35939
		[Space(20f)]
		[Header("SelectItem")]
		[Space(10f)]
		[SerializeField]
		private List<RoleStorageSelectItem> roleStorageSelectItemList = new List<RoleStorageSelectItem>();
	}
}
