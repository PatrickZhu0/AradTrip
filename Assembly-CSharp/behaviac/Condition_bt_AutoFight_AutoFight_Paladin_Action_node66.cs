using System;

namespace behaviac
{
	// Token: 0x02002793 RID: 10131
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node66 : Condition
	{
		// Token: 0x06013866 RID: 79974 RVA: 0x005D255E File Offset: 0x005D095E
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node66()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013867 RID: 79975 RVA: 0x005D2594 File Offset: 0x005D0994
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2C5 RID: 53957
		private int opl_p0;

		// Token: 0x0400D2C6 RID: 53958
		private int opl_p1;

		// Token: 0x0400D2C7 RID: 53959
		private int opl_p2;

		// Token: 0x0400D2C8 RID: 53960
		private int opl_p3;
	}
}
