using System;

namespace behaviac
{
	// Token: 0x0200322C RID: 12844
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node1 : Condition
	{
		// Token: 0x06014CDE RID: 85214 RVA: 0x00644B56 File Offset: 0x00642F56
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS03_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06014CDF RID: 85215 RVA: 0x00644B74 File Offset: 0x00642F74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E633 RID: 58931
		private BE_Target opl_p0;

		// Token: 0x0400E634 RID: 58932
		private BE_Equal opl_p1;

		// Token: 0x0400E635 RID: 58933
		private BE_State opl_p2;
	}
}
