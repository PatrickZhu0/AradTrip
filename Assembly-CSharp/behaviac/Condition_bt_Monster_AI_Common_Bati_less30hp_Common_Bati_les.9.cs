using System;

namespace behaviac
{
	// Token: 0x02003235 RID: 12853
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node4 : Condition
	{
		// Token: 0x06014CED RID: 85229 RVA: 0x00644F6D File Offset: 0x0064336D
		public Condition_bt_Monster_AI_Common_Bati_less30hp_Common_Bati_less30hp_Common_Bati_less30hp_node4()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06014CEE RID: 85230 RVA: 0x00644F90 File Offset: 0x00643390
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E645 RID: 58949
		private HMType opl_p0;

		// Token: 0x0400E646 RID: 58950
		private BE_Operation opl_p1;

		// Token: 0x0400E647 RID: 58951
		private float opl_p2;
	}
}
