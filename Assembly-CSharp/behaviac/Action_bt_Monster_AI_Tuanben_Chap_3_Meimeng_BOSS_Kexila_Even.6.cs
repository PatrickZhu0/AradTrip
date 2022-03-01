using System;

namespace behaviac
{
	// Token: 0x02003951 RID: 14673
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node11 : Action
	{
		// Token: 0x06015A7C RID: 88700 RVA: 0x0068A976 File Offset: 0x00688D76
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521646;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A7D RID: 88701 RVA: 0x0068A9AD File Offset: 0x00688DAD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F410 RID: 62480
		private BE_Target method_p0;

		// Token: 0x0400F411 RID: 62481
		private int method_p1;

		// Token: 0x0400F412 RID: 62482
		private int method_p2;

		// Token: 0x0400F413 RID: 62483
		private int method_p3;

		// Token: 0x0400F414 RID: 62484
		private int method_p4;
	}
}
