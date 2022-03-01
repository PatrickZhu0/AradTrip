using System;

namespace behaviac
{
	// Token: 0x02003226 RID: 12838
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node3 : Action
	{
		// Token: 0x06014CD4 RID: 85204 RVA: 0x006447F3 File Offset: 0x00642BF3
		public Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = 3000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014CD5 RID: 85205 RVA: 0x00644829 File Offset: 0x00642C29
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E625 RID: 58917
		private BE_Target method_p0;

		// Token: 0x0400E626 RID: 58918
		private int method_p1;

		// Token: 0x0400E627 RID: 58919
		private int method_p2;

		// Token: 0x0400E628 RID: 58920
		private int method_p3;

		// Token: 0x0400E629 RID: 58921
		private int method_p4;
	}
}
