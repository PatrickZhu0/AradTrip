using System;

namespace behaviac
{
	// Token: 0x02003570 RID: 13680
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node2 : Action
	{
		// Token: 0x06015316 RID: 86806 RVA: 0x006632C2 File Offset: 0x006616C2
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Zhoufaqiu_An_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522094;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06015317 RID: 86807 RVA: 0x006632FD File Offset: 0x006616FD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECD0 RID: 60624
		private BE_Target method_p0;

		// Token: 0x0400ECD1 RID: 60625
		private int method_p1;

		// Token: 0x0400ECD2 RID: 60626
		private int method_p2;

		// Token: 0x0400ECD3 RID: 60627
		private int method_p3;

		// Token: 0x0400ECD4 RID: 60628
		private int method_p4;
	}
}
