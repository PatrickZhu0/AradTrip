using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019FC RID: 6652
	internal class FriendBackBuffBonusFrame : ClientFrame
	{
		// Token: 0x06010519 RID: 66841 RVA: 0x004940CC File Offset: 0x004924CC
		protected sealed override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("Close");
			if (null != this.mClose)
			{
				this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mBuffBonusComUIList = this.mBind.GetCom<ComUIListScript>("BuffBonus");
		}

		// Token: 0x0601051A RID: 66842 RVA: 0x00494132 File Offset: 0x00492532
		protected sealed override void _unbindExUI()
		{
			if (null != this.mClose)
			{
				this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			}
			this.mClose = null;
			this.mBuffBonusComUIList = null;
		}

		// Token: 0x0601051B RID: 66843 RVA: 0x0049416F File Offset: 0x0049256F
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<FriendBackBuffBonusFrame>(this, false);
		}

		// Token: 0x0601051C RID: 66844 RVA: 0x0049417E File Offset: 0x0049257E
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.value = (this.userData as RelationData);
			}
			this.InitFriendBackBuffBonusComUIList();
			this.InitBackBuffBonusInfo();
		}

		// Token: 0x0601051D RID: 66845 RVA: 0x004941A8 File Offset: 0x004925A8
		protected sealed override void _OnCloseFrame()
		{
			this.backBuffBonusList.Clear();
			this.value = null;
		}

		// Token: 0x0601051E RID: 66846 RVA: 0x004941BC File Offset: 0x004925BC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/FriendBackBuffBonusFrame";
		}

		// Token: 0x0601051F RID: 66847 RVA: 0x004941C4 File Offset: 0x004925C4
		private void InitFriendBackBuffBonusComUIList()
		{
			this.mBuffBonusComUIList.Initialize();
			this.mBuffBonusComUIList.onBindItem = ((GameObject go) => go.GetComponent<ComFriendBackBuffBonusInfo>());
			this.mBuffBonusComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null)
				{
					ComFriendBackBuffBonusInfo comFriendBackBuffBonusInfo = item.gameObjectBindScript as ComFriendBackBuffBonusInfo;
					if (comFriendBackBuffBonusInfo != null && item.m_index >= 0 && item.m_index < this.backBuffBonusList.Count)
					{
						comFriendBackBuffBonusInfo.OnItemVisible(this.backBuffBonusList[item.m_index]);
					}
				}
			};
		}

		// Token: 0x06010520 RID: 66848 RVA: 0x0049421C File Offset: 0x0049261C
		private void InitBackBuffBonusInfo()
		{
			this.backBuffBonusList.Clear();
			OpActivityTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<OpActivityTable>(1209, string.Empty, string.Empty);
			if (tableItem != null && tableItem.Param2.Count > 0)
			{
				for (int i = 0; i < tableItem.Param2.Count; i++)
				{
					int id = tableItem.Param2[i];
					BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(id, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						BackBuffBonusInfo backBuffBonusInfo = new BackBuffBonusInfo();
						backBuffBonusInfo.IconPath = tableItem2.Icon;
						backBuffBonusInfo.Name = tableItem2.Name;
						this.backBuffBonusList.Add(backBuffBonusInfo);
					}
				}
			}
			if (this.value != null && this.value.returnYearTitle != 0U)
			{
				BuffTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(1201092, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					BackBuffBonusInfo backBuffBonusInfo2 = new BackBuffBonusInfo();
					backBuffBonusInfo2.IconPath = tableItem3.Icon;
					backBuffBonusInfo2.Name = tableItem3.Name;
					this.backBuffBonusList.Add(backBuffBonusInfo2);
				}
			}
			if (this.backBuffBonusList.Count > 0)
			{
				this.mBuffBonusComUIList.SetElementAmount(this.backBuffBonusList.Count);
			}
		}

		// Token: 0x0400A54D RID: 42317
		private const int friendBackActivityID = 1209;

		// Token: 0x0400A54E RID: 42318
		private List<BackBuffBonusInfo> backBuffBonusList = new List<BackBuffBonusInfo>();

		// Token: 0x0400A54F RID: 42319
		private RelationData value;

		// Token: 0x0400A550 RID: 42320
		private Button mClose;

		// Token: 0x0400A551 RID: 42321
		private ComUIListScript mBuffBonusComUIList;
	}
}
