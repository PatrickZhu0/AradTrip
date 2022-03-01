using System;

namespace behaviac
{
	// Token: 0x02002784 RID: 10116
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node45 : Condition
	{
		// Token: 0x06013849 RID: 79945 RVA: 0x005D0C9B File Offset: 0x005CF09B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node45()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x0601384A RID: 79946 RVA: 0x005D0CD0 File Offset: 0x005CF0D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2A8 RID: 53928
		private int opl_p0;

		// Token: 0x0400D2A9 RID: 53929
		private int opl_p1;

		// Token: 0x0400D2AA RID: 53930
		private int opl_p2;

		// Token: 0x0400D2AB RID: 53931
		private int opl_p3;
	}
}
