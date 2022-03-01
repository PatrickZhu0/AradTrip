using System;

namespace behaviac
{
	// Token: 0x02002EEC RID: 12012
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node2 : Condition
	{
		// Token: 0x060146B2 RID: 83634 RVA: 0x00623569 File Offset: 0x00621969
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node2()
		{
			this.opl_p0 = 21590;
		}

		// Token: 0x060146B3 RID: 83635 RVA: 0x0062357C File Offset: 0x0062197C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E02F RID: 57391
		private int opl_p0;
	}
}
