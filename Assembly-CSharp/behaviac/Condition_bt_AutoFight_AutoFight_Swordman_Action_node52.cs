using System;

namespace behaviac
{
	// Token: 0x02002891 RID: 10385
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node52 : Condition
	{
		// Token: 0x06013A5F RID: 80479 RVA: 0x005DD661 File Offset: 0x005DBA61
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node52()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06013A60 RID: 80480 RVA: 0x005DD680 File Offset: 0x005DBA80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4BA RID: 54458
		private BE_Target opl_p0;

		// Token: 0x0400D4BB RID: 54459
		private BE_Equal opl_p1;

		// Token: 0x0400D4BC RID: 54460
		private BE_State opl_p2;
	}
}
