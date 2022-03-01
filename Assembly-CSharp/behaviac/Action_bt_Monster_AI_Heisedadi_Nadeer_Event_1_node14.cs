using System;

namespace behaviac
{
	// Token: 0x020034F2 RID: 13554
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node14 : Action
	{
		// Token: 0x06015227 RID: 86567 RVA: 0x0065E84B File Offset: 0x0065CC4B
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521796;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015228 RID: 86568 RVA: 0x0065E882 File Offset: 0x0065CC82
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB49 RID: 60233
		private BE_Target method_p0;

		// Token: 0x0400EB4A RID: 60234
		private int method_p1;

		// Token: 0x0400EB4B RID: 60235
		private int method_p2;

		// Token: 0x0400EB4C RID: 60236
		private int method_p3;

		// Token: 0x0400EB4D RID: 60237
		private int method_p4;
	}
}
