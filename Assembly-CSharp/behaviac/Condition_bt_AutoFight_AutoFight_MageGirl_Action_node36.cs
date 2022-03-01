using System;

namespace behaviac
{
	// Token: 0x020026A8 RID: 9896
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node36 : Condition
	{
		// Token: 0x06013694 RID: 79508 RVA: 0x005C754A File Offset: 0x005C594A
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node36()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013695 RID: 79509 RVA: 0x005C7580 File Offset: 0x005C5980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0E7 RID: 53479
		private int opl_p0;

		// Token: 0x0400D0E8 RID: 53480
		private int opl_p1;

		// Token: 0x0400D0E9 RID: 53481
		private int opl_p2;

		// Token: 0x0400D0EA RID: 53482
		private int opl_p3;
	}
}
