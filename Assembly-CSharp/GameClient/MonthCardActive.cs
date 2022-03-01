using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020013A0 RID: 5024
	internal sealed class MonthCardActive : ActiveSpecialFrame
	{
		// Token: 0x0600C31F RID: 49951 RVA: 0x002E951F File Offset: 0x002E791F
		public override void OnCreate()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600C320 RID: 49952 RVA: 0x002E9547 File Offset: 0x002E7947
		public override void OnDestroy()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600C321 RID: 49953 RVA: 0x002E9570 File Offset: 0x002E7970
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			if (EActivityUpdateType != ActiveManager.ActivityUpdateType.AUT_STATUS_CHANGED)
			{
				return;
			}
			if (data != null && data.activeItem.ID == 2500 && data.status == 5)
			{
				int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(data.activeItem.ID, "rd", 0);
				if (DataManager<TimeManager>.GetInstance().GetServerTime() + 3U > DataManager<PlayerBaseData>.GetInstance().MonthCardLv || activeItemValue < 3)
				{
					SystemNotifyManager.SystemNotify(3117, new UnityAction(this._OnClickOk));
				}
			}
		}

		// Token: 0x0600C322 RID: 49954 RVA: 0x002E9600 File Offset: 0x002E7A00
		private void _OnClickOk()
		{
			VipTabType vipTabType = VipTabType.PAY;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, vipTabType, string.Empty);
		}

		// Token: 0x0600C323 RID: 49955 RVA: 0x002E9626 File Offset: 0x002E7A26
		public override void OnUpdate()
		{
		}

		// Token: 0x04006E7D RID: 28285
		public string ms_month_day_key = "rd";
	}
}
