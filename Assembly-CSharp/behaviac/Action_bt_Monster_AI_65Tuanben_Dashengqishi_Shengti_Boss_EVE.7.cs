using System;

namespace behaviac
{
	// Token: 0x02002E91 RID: 11921
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node261 : Action
	{
		// Token: 0x060145FD RID: 83453 RVA: 0x00620B0B File Offset: 0x0061EF0B
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node261()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570305;
		}

		// Token: 0x060145FE RID: 83454 RVA: 0x00620B2C File Offset: 0x0061EF2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF82 RID: 57218
		private BE_Target method_p0;

		// Token: 0x0400DF83 RID: 57219
		private int method_p1;
	}
}
