using System;

namespace behaviac
{
	// Token: 0x02003230 RID: 12848
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS04_Event_node1 : Condition
	{
		// Token: 0x06014CE5 RID: 85221 RVA: 0x00644D5A File Offset: 0x0064315A
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS04_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06014CE6 RID: 85222 RVA: 0x00644D78 File Offset: 0x00643178
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E63C RID: 58940
		private BE_Target opl_p0;

		// Token: 0x0400E63D RID: 58941
		private BE_Equal opl_p1;

		// Token: 0x0400E63E RID: 58942
		private BE_State opl_p2;
	}
}
