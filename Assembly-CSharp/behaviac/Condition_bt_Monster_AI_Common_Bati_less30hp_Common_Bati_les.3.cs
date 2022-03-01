using System;

namespace behaviac
{
	// Token: 0x02003228 RID: 12840
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node1 : Condition
	{
		// Token: 0x06014CD7 RID: 85207 RVA: 0x00644952 File Offset: 0x00642D52
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS02_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06014CD8 RID: 85208 RVA: 0x00644970 File Offset: 0x00642D70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E62A RID: 58922
		private BE_Target opl_p0;

		// Token: 0x0400E62B RID: 58923
		private BE_Equal opl_p1;

		// Token: 0x0400E62C RID: 58924
		private BE_State opl_p2;
	}
}
