using System;

namespace behaviac
{
	// Token: 0x020021EB RID: 8683
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node13 : Condition
	{
		// Token: 0x06012D63 RID: 77155 RVA: 0x0058B6BF File Offset: 0x00589ABF
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node13()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D64 RID: 77156 RVA: 0x0058B6F4 File Offset: 0x00589AF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C755 RID: 51029
		private int opl_p0;

		// Token: 0x0400C756 RID: 51030
		private int opl_p1;

		// Token: 0x0400C757 RID: 51031
		private int opl_p2;

		// Token: 0x0400C758 RID: 51032
		private int opl_p3;
	}
}
