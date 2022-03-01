using System;

namespace behaviac
{
	// Token: 0x02001DA2 RID: 7586
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node3 : Condition
	{
		// Token: 0x060124FE RID: 75006 RVA: 0x005582C6 File Offset: 0x005566C6
		public Condition_bt_APC_APC_Kuangzhan2_Action_DestinationSelect_node3()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060124FF RID: 75007 RVA: 0x005582FC File Offset: 0x005566FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEE8 RID: 48872
		private int opl_p0;

		// Token: 0x0400BEE9 RID: 48873
		private int opl_p1;

		// Token: 0x0400BEEA RID: 48874
		private int opl_p2;

		// Token: 0x0400BEEB RID: 48875
		private int opl_p3;
	}
}
