using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E8 RID: 5608
	public class CheckGuildDungeonActivityOpen : MonoBehaviour
	{
		// Token: 0x0600DB82 RID: 56194 RVA: 0x0037514F File Offset: 0x0037354F
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB83 RID: 56195 RVA: 0x0037518E File Offset: 0x0037358E
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
		}

		// Token: 0x0600DB84 RID: 56196 RVA: 0x003751C6 File Offset: 0x003735C6
		private void Update()
		{
		}

		// Token: 0x0600DB85 RID: 56197 RVA: 0x003751C8 File Offset: 0x003735C8
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				this.goShow.CustomActive(GuildDataManager.CheckActivityLimit() && guildDungeonActivityData.nActivityState != 0U);
			}
		}

		// Token: 0x0400815B RID: 33115
		[SerializeField]
		private GameObject goShow;
	}
}
