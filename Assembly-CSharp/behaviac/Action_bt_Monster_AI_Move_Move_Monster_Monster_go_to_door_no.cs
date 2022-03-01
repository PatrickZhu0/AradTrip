using System;

namespace behaviac
{
	// Token: 0x020036F5 RID: 14069
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node0 : Action
	{
		// Token: 0x060155FB RID: 87547 RVA: 0x00672EC5 File Offset: 0x006712C5
		public Action_bt_Monster_AI_Move_Move_Monster_Monster_go_to_door_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FINAL_DOOR;
		}

		// Token: 0x060155FC RID: 87548 RVA: 0x00672EDB File Offset: 0x006712DB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC5 RID: 61381
		private DestinationType method_p0;
	}
}
