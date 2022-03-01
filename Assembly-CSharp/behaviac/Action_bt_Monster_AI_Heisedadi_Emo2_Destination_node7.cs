using System;

namespace behaviac
{
	// Token: 0x020033F8 RID: 13304
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node7 : Action
	{
		// Token: 0x06015043 RID: 86083 RVA: 0x00654E33 File Offset: 0x00653233
		public Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015044 RID: 86084 RVA: 0x00654E49 File Offset: 0x00653249
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E92A RID: 59690
		private DestinationType method_p0;
	}
}
