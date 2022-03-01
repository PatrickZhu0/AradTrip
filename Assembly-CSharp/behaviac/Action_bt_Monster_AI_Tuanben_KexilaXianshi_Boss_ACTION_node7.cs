using System;

namespace behaviac
{
	// Token: 0x02003A4C RID: 14924
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node75 : Action
	{
		// Token: 0x06015C61 RID: 89185 RVA: 0x0069394B File Offset: 0x00691D4B
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node75()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570105;
			this.method_p2 = 12000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015C62 RID: 89186 RVA: 0x00693986 File Offset: 0x00691D86
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F586 RID: 62854
		private BE_Target method_p0;

		// Token: 0x0400F587 RID: 62855
		private int method_p1;

		// Token: 0x0400F588 RID: 62856
		private int method_p2;

		// Token: 0x0400F589 RID: 62857
		private int method_p3;

		// Token: 0x0400F58A RID: 62858
		private int method_p4;
	}
}
