using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E7 RID: 5607
	public class CheckEnterGuildDungeon : MonoBehaviour
	{
		// Token: 0x0600DB7D RID: 56189 RVA: 0x0037508D File Offset: 0x0037348D
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB7E RID: 56190 RVA: 0x003750CC File Offset: 0x003734CC
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
		}

		// Token: 0x0600DB7F RID: 56191 RVA: 0x00375104 File Offset: 0x00373504
		private void Update()
		{
		}

		// Token: 0x0600DB80 RID: 56192 RVA: 0x00375108 File Offset: 0x00373508
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				this.goShow.CustomActive(GuildDataManager.CheckActivityLimit() && guildDungeonActivityData.nActivityState == 2U);
			}
		}

		// Token: 0x0400815A RID: 33114
		[SerializeField]
		private GameObject goShow;
	}
}
