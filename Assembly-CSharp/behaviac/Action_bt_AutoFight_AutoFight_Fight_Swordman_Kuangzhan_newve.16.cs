using System;

namespace behaviac
{
	// Token: 0x020023D1 RID: 9169
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node9 : Action
	{
		// Token: 0x06013107 RID: 78087 RVA: 0x005A6E19 File Offset: 0x005A5219
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_newveryhard_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x06013108 RID: 78088 RVA: 0x005A6E2F File Offset: 0x005A522F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB3A RID: 52026
		private EventType method_p0;
	}
}
