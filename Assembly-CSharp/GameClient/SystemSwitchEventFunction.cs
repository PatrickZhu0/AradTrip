using System;

namespace GameClient
{
	// Token: 0x02000DE2 RID: 3554
	public class SystemSwitchEventFunction
	{
		// Token: 0x06008F4F RID: 36687 RVA: 0x001A883E File Offset: 0x001A6C3E
		public static void OnEventSelectRole()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<UserAgreementFrame>(null, false);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PublishContentFrame>(null, false);
			ClientSystemLoginUtility.StartLoginAfterVerify();
			ClientSystemLogin.mSwitchRole = false;
			Singleton<SystemSwitchEventManager>.GetInstance().RemoveEvent(SystemEventType.SYSTEM_EVENT_ON_SWITCH_FAILED);
		}

		// Token: 0x06008F50 RID: 36688 RVA: 0x001A8872 File Offset: 0x001A6C72
		public static void OnEventSwitchFailed()
		{
			Singleton<SystemSwitchEventManager>.GetInstance().RemoveEvent(SystemEventType.SYSETM_EVENT_SELECT_ROLE);
			ClientSystemLogin.mSwitchRole = false;
		}
	}
}
