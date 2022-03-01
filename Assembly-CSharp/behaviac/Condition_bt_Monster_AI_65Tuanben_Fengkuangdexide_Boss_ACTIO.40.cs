using System;

namespace behaviac
{
	// Token: 0x02002EE4 RID: 12004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node5 : Condition
	{
		// Token: 0x060146A2 RID: 83618 RVA: 0x006231D1 File Offset: 0x006215D1
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node5()
		{
			this.opl_p0 = 21591;
		}

		// Token: 0x060146A3 RID: 83619 RVA: 0x006231E4 File Offset: 0x006215E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E01B RID: 57371
		private int opl_p0;
	}
}
