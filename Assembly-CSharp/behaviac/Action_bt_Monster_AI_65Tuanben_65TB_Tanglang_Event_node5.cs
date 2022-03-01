using System;

namespace behaviac
{
	// Token: 0x02002CB2 RID: 11442
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node5 : Action
	{
		// Token: 0x06014259 RID: 82521 RVA: 0x0060CF76 File Offset: 0x0060B376
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521946;
		}

		// Token: 0x0601425A RID: 82522 RVA: 0x0060CF97 File Offset: 0x0060B397
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC11 RID: 56337
		private BE_Target method_p0;

		// Token: 0x0400DC12 RID: 56338
		private int method_p1;
	}
}
