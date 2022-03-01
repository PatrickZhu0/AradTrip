using System;

namespace behaviac
{
	// Token: 0x0200313A RID: 12602
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node8 : Action
	{
		// Token: 0x06014B17 RID: 84759 RVA: 0x0063B4B7 File Offset: 0x006398B7
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014B18 RID: 84760 RVA: 0x0063B4EE File Offset: 0x006398EE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E48C RID: 58508
		private BE_Target method_p0;

		// Token: 0x0400E48D RID: 58509
		private int method_p1;

		// Token: 0x0400E48E RID: 58510
		private int method_p2;

		// Token: 0x0400E48F RID: 58511
		private int method_p3;

		// Token: 0x0400E490 RID: 58512
		private int method_p4;
	}
}
