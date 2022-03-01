using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001615 RID: 5653
	public class GuildDungeonBufAddUpDetailFrame : ClientFrame
	{
		// Token: 0x0600DD99 RID: 56729 RVA: 0x0038314D File Offset: 0x0038154D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonBufAddUpDetail";
		}

		// Token: 0x0600DD9A RID: 56730 RVA: 0x00383154 File Offset: 0x00381554
		protected override void _OnOpenFrame()
		{
			this.buffAddUpInfos = new List<GuildDataManager.BuffAddUpInfo>();
			this.BindEvent();
			this.UpdateBufAddUpItems(0);
		}

		// Token: 0x0600DD9B RID: 56731 RVA: 0x0038316E File Offset: 0x0038156E
		protected override void _OnCloseFrame()
		{
			this.buffAddUpInfos = null;
			this.UnBindEvent();
			this.ClearData(true);
		}

		// Token: 0x0600DD9C RID: 56732 RVA: 0x00383184 File Offset: 0x00381584
		private void BindEvent()
		{
		}

		// Token: 0x0600DD9D RID: 56733 RVA: 0x00383186 File Offset: 0x00381586
		private void UnBindEvent()
		{
		}

		// Token: 0x0600DD9E RID: 56734 RVA: 0x00383188 File Offset: 0x00381588
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<GuildDungeonBufAddUpDetailFrame>(this, false);
		}

		// Token: 0x0600DD9F RID: 56735 RVA: 0x00383198 File Offset: 0x00381598
		private List<GuildDataManager.BuffAddUpInfo> GetBuffAddUpInfoList()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData == null)
			{
				return null;
			}
			return guildDungeonActivityData.buffAddUpInfos;
		}

		// Token: 0x0600DDA0 RID: 56736 RVA: 0x003831C0 File Offset: 0x003815C0
		private void UpdateBufAddUpItems(int selectPayActId)
		{
			if (this.buffAddUpInfos == null)
			{
				Logger.LogError("ItemdataList data is null");
				return;
			}
			if (this.mScrollUIList == null)
			{
				Logger.LogError("mScrollUIList obj is null");
				return;
			}
			if (!this.mScrollUIList.IsInitialised())
			{
				this.mScrollUIList.Initialize();
				this.mScrollUIList.onBindItem = delegate(GameObject go)
				{
					GuildDungeonBuffAddUpInfoItem result = null;
					if (go)
					{
						result = go.GetComponent<GuildDungeonBuffAddUpInfoItem>();
					}
					return result;
				};
			}
			this.mScrollUIList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				if (var1 == null)
				{
					return;
				}
				int index = var1.m_index;
				if (index >= 0 && index < this.buffAddUpInfos.Count)
				{
					GuildDungeonBuffAddUpInfoItem guildDungeonBuffAddUpInfoItem = var1.gameObjectBindScript as GuildDungeonBuffAddUpInfoItem;
					if (guildDungeonBuffAddUpInfoItem != null)
					{
						guildDungeonBuffAddUpInfoItem.SetUp(this.buffAddUpInfos[index]);
					}
				}
			};
			this.buffAddUpInfos = this.GetBuffAddUpInfoList();
			this.mScrollUIList.SetElementAmount(this.buffAddUpInfos.Count);
		}

		// Token: 0x0600DDA1 RID: 56737 RVA: 0x0038327B File Offset: 0x0038167B
		private void ClearData(bool isClearWithTabs = true)
		{
			if (this.mScrollUIList != null)
			{
				this.mScrollUIList.SetElementAmount(0);
			}
		}

		// Token: 0x0600DDA2 RID: 56738 RVA: 0x0038329C File Offset: 0x0038169C
		protected override void _bindExUI()
		{
			this.btnClose = this.mBind.GetCom<Button>("btnClose");
			if (null != this.btnClose)
			{
				this.btnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mScrollUIList = this.mBind.GetCom<ComUIListScript>("ScrollUIList");
		}

		// Token: 0x0600DDA3 RID: 56739 RVA: 0x00383302 File Offset: 0x00381702
		protected override void _unbindExUI()
		{
			if (null != this.btnClose)
			{
				this.btnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.btnClose = null;
			this.mScrollUIList = null;
		}

		// Token: 0x0600DDA4 RID: 56740 RVA: 0x0038333F File Offset: 0x0038173F
		private void _onBtnCloseButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x04008329 RID: 33577
		private List<GuildDataManager.BuffAddUpInfo> buffAddUpInfos;

		// Token: 0x0400832A RID: 33578
		private ComUIListScript mScrollUIList;

		// Token: 0x0400832B RID: 33579
		private Button btnClose;
	}
}
