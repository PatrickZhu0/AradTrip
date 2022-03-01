using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001974 RID: 6516
	public class PersonalSettingView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600FD30 RID: 64816 RVA: 0x0045AF78 File Offset: 0x00459378
		private void Awake()
		{
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
				this.mCloseBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<PersonalSettingFrame>(null, false);
				});
			}
		}

		// Token: 0x0600FD31 RID: 64817 RVA: 0x0045AFD3 File Offset: 0x004593D3
		public void InitView()
		{
			this.InitMainTabComUIList();
		}

		// Token: 0x0600FD32 RID: 64818 RVA: 0x0045AFDC File Offset: 0x004593DC
		private void InitMainTabComUIList()
		{
			if (this.mMainTabComUIList != null)
			{
				this.mMainTabComUIList.Initialize();
				ComUIListScript comUIListScript = this.mMainTabComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mMainTabComUIList.SetElementAmount(this.mMainTabList.Count);
		}

		// Token: 0x0600FD33 RID: 64819 RVA: 0x0045B06C File Offset: 0x0045946C
		private void UnInitMainTabComUIList()
		{
			if (this.mMainTabComUIList != null)
			{
				ComUIListScript comUIListScript = this.mMainTabComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mMainTabComUIList = null;
		}

		// Token: 0x0600FD34 RID: 64820 RVA: 0x0045B0DF File Offset: 0x004594DF
		private PersonalSettingMainTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<PersonalSettingMainTabItem>();
		}

		// Token: 0x0600FD35 RID: 64821 RVA: 0x0045B0E8 File Offset: 0x004594E8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			PersonalSettingMainTabItem personalSettingMainTabItem = item.gameObjectBindScript as PersonalSettingMainTabItem;
			if (personalSettingMainTabItem == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mMainTabList.Count)
			{
				if (PersonalSettingFrame.mDefalutTabIndex == this.mMainTabList[item.m_index].mIndex)
				{
					personalSettingMainTabItem.InitTabItem(this.mMainTabList[item.m_index], true);
				}
				else
				{
					personalSettingMainTabItem.InitTabItem(this.mMainTabList[item.m_index], false);
				}
			}
		}

		// Token: 0x0600FD36 RID: 64822 RVA: 0x0045B185 File Offset: 0x00459585
		public void Dispose()
		{
			this.UnInitMainTabComUIList();
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600FD37 RID: 64823 RVA: 0x0045B1AE File Offset: 0x004595AE
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04009F14 RID: 40724
		[SerializeField]
		private List<PersonalSettingMainTabDataModle> mMainTabList;

		// Token: 0x04009F15 RID: 40725
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x04009F16 RID: 40726
		[SerializeField]
		private ComUIListScript mMainTabComUIList;
	}
}
