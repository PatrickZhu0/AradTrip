using System;

namespace behaviac
{
	// Token: 0x02003516 RID: 13590
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node61 : Action
	{
		// Token: 0x0601526F RID: 86639 RVA: 0x0065F3C9 File Offset: 0x0065D7C9
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node61()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521773;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015270 RID: 86640 RVA: 0x0065F400 File Offset: 0x0065D800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBBE RID: 60350
		private BE_Target method_p0;

		// Token: 0x0400EBBF RID: 60351
		private int method_p1;

		// Token: 0x0400EBC0 RID: 60352
		private int method_p2;

		// Token: 0x0400EBC1 RID: 60353
		private int method_p3;

		// Token: 0x0400EBC2 RID: 60354
		private int method_p4;
	}
}
