using System;

namespace behaviac
{
	// Token: 0x02003A20 RID: 14880
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node43 : Action
	{
		// Token: 0x06015C0A RID: 89098 RVA: 0x00691F16 File Offset: 0x00690316
		public Action_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node43()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570049;
			this.method_p2 = -1;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x06015C0B RID: 89099 RVA: 0x00691F4D File Offset: 0x0069034D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F51E RID: 62750
		private BE_Target method_p0;

		// Token: 0x0400F51F RID: 62751
		private int method_p1;

		// Token: 0x0400F520 RID: 62752
		private int method_p2;

		// Token: 0x0400F521 RID: 62753
		private int method_p3;

		// Token: 0x0400F522 RID: 62754
		private int method_p4;
	}
}
