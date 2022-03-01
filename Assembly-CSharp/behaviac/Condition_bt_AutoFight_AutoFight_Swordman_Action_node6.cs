using System;

namespace behaviac
{
	// Token: 0x0200287D RID: 10365
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Action_node6 : Condition
	{
		// Token: 0x06013A37 RID: 80439 RVA: 0x005DCCFF File Offset: 0x005DB0FF
		public Condition_bt_AutoFight_AutoFight_Swordman_Action_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013A38 RID: 80440 RVA: 0x005DCD34 File Offset: 0x005DB134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D48F RID: 54415
		private int opl_p0;

		// Token: 0x0400D490 RID: 54416
		private int opl_p1;

		// Token: 0x0400D491 RID: 54417
		private int opl_p2;

		// Token: 0x0400D492 RID: 54418
		private int opl_p3;
	}
}
