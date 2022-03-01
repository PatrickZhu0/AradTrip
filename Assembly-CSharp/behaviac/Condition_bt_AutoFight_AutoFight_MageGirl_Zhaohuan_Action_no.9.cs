using System;

namespace behaviac
{
	// Token: 0x02002753 RID: 10067
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node57 : Condition
	{
		// Token: 0x060137E7 RID: 79847 RVA: 0x005CF74E File Offset: 0x005CDB4E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node57()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060137E8 RID: 79848 RVA: 0x005CF784 File Offset: 0x005CDB84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D243 RID: 53827
		private int opl_p0;

		// Token: 0x0400D244 RID: 53828
		private int opl_p1;

		// Token: 0x0400D245 RID: 53829
		private int opl_p2;

		// Token: 0x0400D246 RID: 53830
		private int opl_p3;
	}
}
