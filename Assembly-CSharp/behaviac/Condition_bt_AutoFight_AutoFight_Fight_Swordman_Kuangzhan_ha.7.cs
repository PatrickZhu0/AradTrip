using System;

namespace behaviac
{
	// Token: 0x0200236D RID: 9069
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node16 : Condition
	{
		// Token: 0x06013044 RID: 77892 RVA: 0x005A064A File Offset: 0x0059EA4A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013045 RID: 77893 RVA: 0x005A0680 File Offset: 0x0059EA80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA5B RID: 51803
		private int opl_p0;

		// Token: 0x0400CA5C RID: 51804
		private int opl_p1;

		// Token: 0x0400CA5D RID: 51805
		private int opl_p2;

		// Token: 0x0400CA5E RID: 51806
		private int opl_p3;
	}
}
