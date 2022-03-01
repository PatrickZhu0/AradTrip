using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200139B RID: 5019
	public class AmberPrivilegeItem : MonoBehaviour
	{
		// Token: 0x0600C2F2 RID: 49906 RVA: 0x002E8470 File Offset: 0x002E6870
		public void OnItemVisiable(ActiveManager.ActivityData activityData, OnAmberPrivilegeItemClick onAmberPrivilegeItemClick)
		{
			this.mActivityData = activityData;
			this.mOnAmberPrivilegeItemClick = onAmberPrivilegeItemClick;
			List<AwardItemData> activeAwards = DataManager<ActiveManager>.GetInstance().GetActiveAwards(this.mActivityData.ID);
			if (activeAwards.Count > 0)
			{
				if (activeAwards[0] == null)
				{
					return;
				}
				int id = activeAwards[0].ID;
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
				if (this.mItemRoot != null)
				{
					if (this.comItem == null)
					{
						this.comItem = ComItemManager.Create(this.mItemRoot);
					}
					ComItem comItem = this.comItem;
					ItemData item = itemData;
					if (AmberPrivilegeItem.<>f__mg$cache0 == null)
					{
						AmberPrivilegeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, AmberPrivilegeItem.<>f__mg$cache0);
				}
			}
			this.UpdateStatus(this.mActivityData);
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(delegate()
				{
					if (this.mOnAmberPrivilegeItemClick != null)
					{
						this.mOnAmberPrivilegeItemClick(this.mActivityData.ID);
					}
				});
			}
		}

		// Token: 0x0600C2F3 RID: 49907 RVA: 0x002E8578 File Offset: 0x002E6978
		private void UpdateStatus(ActiveManager.ActivityData activityData)
		{
			if (activityData == null)
			{
				return;
			}
			this.SetReceiveCondition(activityData);
			if (activityData.status == 1 || activityData.status == 0)
			{
				this.SetReceiveGray(true);
				this.SetReceiveBtn(true);
				this.SetReceivedRoot(false);
			}
			else if (activityData.status == 2)
			{
				this.SetReceiveGray(false);
				this.SetReceiveBtn(true);
				this.SetReceivedRoot(false);
			}
			else if (activityData.status == 5 || activityData.status == 4)
			{
				this.SetReceiveBtn(false);
				this.SetReceivedRoot(true);
			}
		}

		// Token: 0x0600C2F4 RID: 49908 RVA: 0x002E8610 File Offset: 0x002E6A10
		private void SetReceiveGray(bool isFlag)
		{
			if (this.mReceiveGray != null)
			{
				this.mReceiveGray.enabled = isFlag;
			}
		}

		// Token: 0x0600C2F5 RID: 49909 RVA: 0x002E862F File Offset: 0x002E6A2F
		private void SetReceiveBtn(bool isFlag)
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.gameObject.CustomActive(isFlag);
			}
		}

		// Token: 0x0600C2F6 RID: 49910 RVA: 0x002E8653 File Offset: 0x002E6A53
		private void SetReceivedRoot(bool isFlag)
		{
			if (this.mReceivedRoot != null)
			{
				this.mReceivedRoot.CustomActive(isFlag);
			}
		}

		// Token: 0x0600C2F7 RID: 49911 RVA: 0x002E8672 File Offset: 0x002E6A72
		private void SetReceiveCondition(ActiveManager.ActivityData activityData)
		{
			if (this.mReceiveCondition != null)
			{
				this.mReceiveCondition.text = activityData.activeItem.Desc;
			}
		}

		// Token: 0x0600C2F8 RID: 49912 RVA: 0x002E869B File Offset: 0x002E6A9B
		private void OnDestroy()
		{
			this.mActivityData = null;
			this.mOnAmberPrivilegeItemClick = null;
			this.comItem = null;
		}

		// Token: 0x04006E58 RID: 28248
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04006E59 RID: 28249
		[SerializeField]
		private Text mReceiveCondition;

		// Token: 0x04006E5A RID: 28250
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04006E5B RID: 28251
		[SerializeField]
		private UIGray mReceiveGray;

		// Token: 0x04006E5C RID: 28252
		[SerializeField]
		private GameObject mReceivedRoot;

		// Token: 0x04006E5D RID: 28253
		private OnAmberPrivilegeItemClick mOnAmberPrivilegeItemClick;

		// Token: 0x04006E5E RID: 28254
		private ActiveManager.ActivityData mActivityData;

		// Token: 0x04006E5F RID: 28255
		private ComItem comItem;

		// Token: 0x04006E60 RID: 28256
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
