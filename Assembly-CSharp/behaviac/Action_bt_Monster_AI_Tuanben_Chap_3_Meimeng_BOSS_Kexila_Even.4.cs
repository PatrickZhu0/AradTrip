using System;

namespace behaviac
{
	// Token: 0x0200394F RID: 14671
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5 : Action
	{
		// Token: 0x06015A78 RID: 88696 RVA: 0x0068A8CA File Offset: 0x00688CCA
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521643;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015A79 RID: 88697 RVA: 0x0068A901 File Offset: 0x00688D01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F409 RID: 62473
		private BE_Target method_p0;

		// Token: 0x0400F40A RID: 62474
		private int method_p1;

		// Token: 0x0400F40B RID: 62475
		private int method_p2;

		// Token: 0x0400F40C RID: 62476
		private int method_p3;

		// Token: 0x0400F40D RID: 62477
		private int method_p4;
	}
}
