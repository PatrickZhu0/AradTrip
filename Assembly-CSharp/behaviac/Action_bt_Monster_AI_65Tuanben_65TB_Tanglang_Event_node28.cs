using System;

namespace behaviac
{
	// Token: 0x02002CAA RID: 11434
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node28 : Action
	{
		// Token: 0x06014249 RID: 82505 RVA: 0x0060CC7F File Offset: 0x0060B07F
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
		}

		// Token: 0x0601424A RID: 82506 RVA: 0x0060CC9D File Offset: 0x0060B09D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC02 RID: 56322
		private BE_Target method_p0;

		// Token: 0x0400DC03 RID: 56323
		private int method_p1;
	}
}
