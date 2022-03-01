using System;

namespace behaviac
{
	// Token: 0x020030E7 RID: 12519
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node8 : Action
	{
		// Token: 0x06014A81 RID: 84609 RVA: 0x0063861E File Offset: 0x00636A1E
		public Action_bt_Monster_AI_Chapter10_Dashengqishi_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522996;
		}

		// Token: 0x06014A82 RID: 84610 RVA: 0x0063863F File Offset: 0x00636A3F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3F0 RID: 58352
		private BE_Target method_p0;

		// Token: 0x0400E3F1 RID: 58353
		private int method_p1;
	}
}
