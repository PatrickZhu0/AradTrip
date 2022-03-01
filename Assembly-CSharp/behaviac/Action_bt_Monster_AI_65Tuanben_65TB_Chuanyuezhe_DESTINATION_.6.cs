using System;

namespace behaviac
{
	// Token: 0x02002B7D RID: 11133
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node15 : Action
	{
		// Token: 0x06014007 RID: 81927 RVA: 0x0060168F File Offset: 0x005FFA8F
		public Action_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_DESTINATION_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
		}

		// Token: 0x06014008 RID: 81928 RVA: 0x0060169E File Offset: 0x005FFA9E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ChangeFaceToTarget();
			return EBTStatus.BT_SUCCESS;
		}
	}
}
