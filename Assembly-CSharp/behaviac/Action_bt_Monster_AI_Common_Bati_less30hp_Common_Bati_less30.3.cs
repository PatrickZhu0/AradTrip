using System;

namespace behaviac
{
	// Token: 0x0200322E RID: 12846
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node3 : Action
	{
		// Token: 0x06014CE2 RID: 85218 RVA: 0x00644BFB File Offset: 0x00642FFB
		public Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = 3000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014CE3 RID: 85219 RVA: 0x00644C31 File Offset: 0x00643031
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E637 RID: 58935
		private BE_Target method_p0;

		// Token: 0x0400E638 RID: 58936
		private int method_p1;

		// Token: 0x0400E639 RID: 58937
		private int method_p2;

		// Token: 0x0400E63A RID: 58938
		private int method_p3;

		// Token: 0x0400E63B RID: 58939
		private int method_p4;
	}
}
