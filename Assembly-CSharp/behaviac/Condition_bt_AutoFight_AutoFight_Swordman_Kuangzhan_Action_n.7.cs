using System;

namespace behaviac
{
	// Token: 0x0200294B RID: 10571
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node38 : Condition
	{
		// Token: 0x06013BCB RID: 80843 RVA: 0x005E6DF2 File Offset: 0x005E51F2
		public Condition_bt_AutoFight_AutoFight_Swordman_Kuangzhan_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013BCC RID: 80844 RVA: 0x005E6E28 File Offset: 0x005E5228
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D630 RID: 54832
		private int opl_p0;

		// Token: 0x0400D631 RID: 54833
		private int opl_p1;

		// Token: 0x0400D632 RID: 54834
		private int opl_p2;

		// Token: 0x0400D633 RID: 54835
		private int opl_p3;
	}
}
