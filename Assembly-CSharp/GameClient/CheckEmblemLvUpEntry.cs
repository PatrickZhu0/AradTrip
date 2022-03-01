using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E6 RID: 5606
	public class CheckEmblemLvUpEntry : MonoBehaviour
	{
		// Token: 0x0600DB77 RID: 56183 RVA: 0x00374F54 File Offset: 0x00373354
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateGuildEmblemLvUpEntry, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB78 RID: 56184 RVA: 0x00374FAC File Offset: 0x003733AC
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateGuildEmblemLvUpEntry, new ClientEventSystem.UIEventHandler(this._OnUpdateShow));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this._OnLevelChanged));
		}

		// Token: 0x0600DB79 RID: 56185 RVA: 0x00374FFA File Offset: 0x003733FA
		private void Update()
		{
		}

		// Token: 0x0600DB7A RID: 56186 RVA: 0x00374FFC File Offset: 0x003733FC
		private void _OnLevelChanged(int iPre, int iCur)
		{
			this._OnUpdateShow(null);
		}

		// Token: 0x0600DB7B RID: 56187 RVA: 0x00375008 File Offset: 0x00373408
		private void _OnUpdateShow(UIEvent uiEvent)
		{
			bool bActive = (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit() && DataManager<GuildDataManager>.GetInstance().myGuild != null && DataManager<GuildDataManager>.GetInstance().myGuild.nLevel >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit() && DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR) >= DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpHonourLvLimit();
			this.goShow.CustomActive(bActive);
		}

		// Token: 0x04008159 RID: 33113
		[SerializeField]
		private GameObject goShow;
	}
}
