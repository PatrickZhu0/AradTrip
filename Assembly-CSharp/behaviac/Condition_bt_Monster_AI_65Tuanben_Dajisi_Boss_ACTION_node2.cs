using System;

namespace behaviac
{
	// Token: 0x02002D65 RID: 11621
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node2 : Condition
	{
		// Token: 0x060143AC RID: 82860 RVA: 0x00613DE7 File Offset: 0x006121E7
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node2()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060143AD RID: 82861 RVA: 0x00613DF8 File Offset: 0x006121F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD77 RID: 56695
		private int opl_p0;
	}
}
