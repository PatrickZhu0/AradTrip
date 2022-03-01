using System;

namespace behaviac
{
	// Token: 0x02003B7A RID: 15226
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Xianfeng_Event_node2 : Action
	{
		// Token: 0x06015EA7 RID: 89767 RVA: 0x0069F6AB File Offset: 0x0069DAAB
		public Action_bt_Monster_AI_Tuanben_Xianfeng_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 30;
			this.method_p2 = 900000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015EA8 RID: 89768 RVA: 0x0069F6E2 File Offset: 0x0069DAE2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F76C RID: 63340
		private BE_Target method_p0;

		// Token: 0x0400F76D RID: 63341
		private int method_p1;

		// Token: 0x0400F76E RID: 63342
		private int method_p2;

		// Token: 0x0400F76F RID: 63343
		private int method_p3;

		// Token: 0x0400F770 RID: 63344
		private int method_p4;
	}
}
