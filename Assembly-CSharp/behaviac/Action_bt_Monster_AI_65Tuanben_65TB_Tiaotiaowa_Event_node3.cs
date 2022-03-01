using System;

namespace behaviac
{
	// Token: 0x02002D09 RID: 11529
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node3 : Action
	{
		// Token: 0x06014300 RID: 82688 RVA: 0x006108D0 File Offset: 0x0060ECD0
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06014301 RID: 82689 RVA: 0x006108F4 File Offset: 0x0060ECF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DCA4 RID: 56484
		private int method_p0;

		// Token: 0x0400DCA5 RID: 56485
		private int method_p1;
	}
}
