using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200162C RID: 5676
	internal class GuildManorAwardGetControl : MonoBehaviour
	{
		// Token: 0x0600DEDA RID: 57050 RVA: 0x0038CC18 File Offset: 0x0038B018
		private void Start()
		{
			this.dailyAward.SafeSetOnClickListener(delegate
			{
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildGetTerrDayRewardReq();
			});
			this.OnRedPointChanged(null);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
		}

		// Token: 0x0600DEDB RID: 57051 RVA: 0x0038CC6C File Offset: 0x0038B06C
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
		}

		// Token: 0x0600DEDC RID: 57052 RVA: 0x0038CC88 File Offset: 0x0038B088
		private void OnRedPointChanged(UIEvent a_event)
		{
			ERedPoint a_eType = ERedPoint.GuildTerrDayReward;
			bool bActive = DataManager<RedPointDataManager>.GetInstance().HasRedPoint(a_eType) && DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().myGuild.nSelfManorID == this.manorID;
			this.dailyAwardRedPoint.CustomActive(bActive);
			this.dailyAward.CustomActive(bActive);
		}

		// Token: 0x04008436 RID: 33846
		[SerializeField]
		private Button dailyAward;

		// Token: 0x04008437 RID: 33847
		[SerializeField]
		private GameObject dailyAwardRedPoint;

		// Token: 0x04008438 RID: 33848
		[SerializeField]
		private int manorID;
	}
}
