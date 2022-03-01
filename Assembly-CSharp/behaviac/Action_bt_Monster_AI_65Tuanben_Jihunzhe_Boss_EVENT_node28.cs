using System;

namespace behaviac
{
	// Token: 0x02002F1C RID: 12060
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node28 : Action
	{
		// Token: 0x0601470E RID: 83726 RVA: 0x006264F7 File Offset: 0x006248F7
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601470F RID: 83727 RVA: 0x0062650D File Offset: 0x0062490D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E086 RID: 57478
		private int method_p0;
	}
}
