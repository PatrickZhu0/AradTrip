using System;

namespace behaviac
{
	// Token: 0x0200277F RID: 10111
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node36 : Condition
	{
		// Token: 0x0601383F RID: 79935 RVA: 0x005D0A9E File Offset: 0x005CEE9E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node36()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 1000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013840 RID: 79936 RVA: 0x005D0AD4 File Offset: 0x005CEED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D29F RID: 53919
		private int opl_p0;

		// Token: 0x0400D2A0 RID: 53920
		private int opl_p1;

		// Token: 0x0400D2A1 RID: 53921
		private int opl_p2;

		// Token: 0x0400D2A2 RID: 53922
		private int opl_p3;
	}
}
