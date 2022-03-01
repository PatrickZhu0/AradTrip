using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013D1 RID: 5073
	public class ComAchievementEventListener : MonoBehaviour
	{
		// Token: 0x0600C4B4 RID: 50356 RVA: 0x002F3F91 File Offset: 0x002F2391
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementComplete, new ClientEventSystem.UIEventHandler(this._OnAchievementComplete));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAchievementOver, new ClientEventSystem.UIEventHandler(this._OnAchievementComplete));
		}

		// Token: 0x0600C4B5 RID: 50357 RVA: 0x002F3FC9 File Offset: 0x002F23C9
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementComplete, new ClientEventSystem.UIEventHandler(this._OnAchievementComplete));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAchievementOver, new ClientEventSystem.UIEventHandler(this._OnAchievementComplete));
		}

		// Token: 0x0600C4B6 RID: 50358 RVA: 0x002F4001 File Offset: 0x002F2401
		private void Start()
		{
			this._TriggerEvent();
		}

		// Token: 0x0600C4B7 RID: 50359 RVA: 0x002F400C File Offset: 0x002F240C
		private void _OnAchievementOver(UIEvent uiEvent)
		{
			int iId = (int)uiEvent.Param1;
			AchievementAwardPlayFrame.CommandOpen(new AchievementAwardPlayFrameData
			{
				iId = iId
			});
		}

		// Token: 0x0600C4B8 RID: 50360 RVA: 0x002F4038 File Offset: 0x002F2438
		private void _OnAchievementComplete(UIEvent uiEvent)
		{
			this._TriggerEvent();
		}

		// Token: 0x0600C4B9 RID: 50361 RVA: 0x002F4040 File Offset: 0x002F2440
		private void _TriggerEvent()
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AchievementEffectPlayFrame>(null) && DataManager<MissionManager>.GetInstance().HasAchievementItem())
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AchievementEffectPlayFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}
	}
}
