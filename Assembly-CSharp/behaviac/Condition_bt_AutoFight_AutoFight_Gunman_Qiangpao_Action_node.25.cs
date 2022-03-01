using System;

namespace behaviac
{
	// Token: 0x0200265F RID: 9823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node27 : Condition
	{
		// Token: 0x06013603 RID: 79363 RVA: 0x005C435A File Offset: 0x005C275A
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node27()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013604 RID: 79364 RVA: 0x005C4390 File Offset: 0x005C2790
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D053 RID: 53331
		private int opl_p0;

		// Token: 0x0400D054 RID: 53332
		private int opl_p1;

		// Token: 0x0400D055 RID: 53333
		private int opl_p2;

		// Token: 0x0400D056 RID: 53334
		private int opl_p3;
	}
}
