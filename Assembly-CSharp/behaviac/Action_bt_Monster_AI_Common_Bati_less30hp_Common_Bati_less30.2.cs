using System;

namespace behaviac
{
	// Token: 0x0200322A RID: 12842
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node3 : Action
	{
		// Token: 0x06014CDB RID: 85211 RVA: 0x006449F7 File Offset: 0x00642DF7
		public Action_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = 3000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014CDC RID: 85212 RVA: 0x00644A2D File Offset: 0x00642E2D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E62E RID: 58926
		private BE_Target method_p0;

		// Token: 0x0400E62F RID: 58927
		private int method_p1;

		// Token: 0x0400E630 RID: 58928
		private int method_p2;

		// Token: 0x0400E631 RID: 58929
		private int method_p3;

		// Token: 0x0400E632 RID: 58930
		private int method_p4;
	}
}
