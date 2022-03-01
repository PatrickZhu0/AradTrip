using System;

namespace behaviac
{
	// Token: 0x020022E0 RID: 8928
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node9 : Action
	{
		// Token: 0x06012F3A RID: 77626 RVA: 0x00599BDD File Offset: 0x00597FDD
		public Action_bt_AutoFight_AutoFight_Fight_Swordman_Jianhun_newveryhard_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = EventType.OnBeforeOtherHit;
		}

		// Token: 0x06012F3B RID: 77627 RVA: 0x00599BF3 File Offset: 0x00597FF3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RegisterEvent(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C94F RID: 51535
		private EventType method_p0;
	}
}
