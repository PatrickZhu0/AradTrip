using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001635 RID: 5685
	public class GuildMergeAskFrame : ClientFrame
	{
		// Token: 0x0600DF53 RID: 57171 RVA: 0x0038FC02 File Offset: 0x0038E002
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildMergeAskFrame";
		}

		// Token: 0x0600DF54 RID: 57172 RVA: 0x0038FC0C File Offset: 0x0038E00C
		protected override void _bindExUI()
		{
			this.mItemList = this.mBind.GetCom<ComUIListScript>("ItemList");
			this.mCloseBtn = this.mBind.GetCom<Button>("CloseBtn");
			this.mCloseBtn.SafeAddOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mClearAllBtn = this.mBind.GetCom<Button>("ClearAllBtn");
			this.mClearAllBtn.SafeAddOnClickListener(new UnityAction(this.OnClearAllAskInfoBtnClick));
		}

		// Token: 0x0600DF55 RID: 57173 RVA: 0x0038FC8C File Offset: 0x0038E08C
		protected override void _unbindExUI()
		{
			this.mItemList = null;
			this.mCloseBtn.SafeRemoveOnClickListener(new UnityAction(this.OnCloseBtnClick));
			this.mCloseBtn = null;
			this.mClearAllBtn.SafeRemoveOnClickListener(new UnityAction(this.OnClearAllAskInfoBtnClick));
			this.mClearAllBtn = null;
		}

		// Token: 0x0600DF56 RID: 57174 RVA: 0x0038FCDC File Offset: 0x0038E0DC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mItemList != null && !this.mItemList.IsInitialised())
			{
				this.mItemList.Initialize();
				ComUIListScript comUIListScript = this.mItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildReceiveMergedList, new ClientEventSystem.UIEventHandler(this.OnGuildReceiveMergedList));
			DataManager<GuildDataManager>.GetInstance().RequestGuildHaveMgergeRequest();
		}

		// Token: 0x0600DF57 RID: 57175 RVA: 0x0038FD67 File Offset: 0x0038E167
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mGuildList.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildReceiveMergedList, new ClientEventSystem.UIEventHandler(this.OnGuildReceiveMergedList));
		}

		// Token: 0x0600DF58 RID: 57176 RVA: 0x0038FD98 File Offset: 0x0038E198
		private void OnGuildReceiveMergedList(UIEvent uiEvent)
		{
			GuildEntry[] array = (GuildEntry[])uiEvent.Param1;
			if (array != null)
			{
				this.mGuildList.Clear();
				for (int i = 0; i < array.Length; i++)
				{
					this.mGuildList.Add(array[i]);
				}
			}
			this.mItemList.SetElementAmount(this.mGuildList.Count);
		}

		// Token: 0x0600DF59 RID: 57177 RVA: 0x0038FDFC File Offset: 0x0038E1FC
		private void OnItemVisiable(ComUIListElementScript item)
		{
			if (item != null && item.m_index < this.mGuildList.Count && item.m_index >= 0)
			{
				GuildMergeAskItem component = item.GetComponent<GuildMergeAskItem>();
				if (component != null)
				{
					component.SetData(this.mGuildList[item.m_index]);
				}
			}
		}

		// Token: 0x0600DF5A RID: 57178 RVA: 0x0038FE61 File Offset: 0x0038E261
		private void OnCloseBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildMergeAskFrame>(null, false);
		}

		// Token: 0x0600DF5B RID: 57179 RVA: 0x0038FE6F File Offset: 0x0038E26F
		private void OnClearAllAskInfoBtnClick()
		{
			DataManager<GuildDataManager>.GetInstance().AcceptOrRefuseOrCancelMergeRequest(3, 0UL);
		}

		// Token: 0x0400849F RID: 33951
		private ComUIListScript mItemList;

		// Token: 0x040084A0 RID: 33952
		private Button mCloseBtn;

		// Token: 0x040084A1 RID: 33953
		private Button mClearAllBtn;

		// Token: 0x040084A2 RID: 33954
		private List<GuildEntry> mGuildList = new List<GuildEntry>();
	}
}
