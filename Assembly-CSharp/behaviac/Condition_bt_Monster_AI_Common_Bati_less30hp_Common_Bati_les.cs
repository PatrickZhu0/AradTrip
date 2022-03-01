using System;

namespace behaviac
{
	// Token: 0x02003224 RID: 12836
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node1 : Condition
	{
		// Token: 0x06014CD0 RID: 85200 RVA: 0x0064474D File Offset: 0x00642B4D
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_bati_BOSS01_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06014CD1 RID: 85201 RVA: 0x0064476C File Offset: 0x00642B6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E621 RID: 58913
		private BE_Target opl_p0;

		// Token: 0x0400E622 RID: 58914
		private BE_Equal opl_p1;

		// Token: 0x0400E623 RID: 58915
		private BE_State opl_p2;
	}
}
