using System;

namespace behaviac
{
	// Token: 0x020026DE RID: 9950
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node6 : Condition
	{
		// Token: 0x060136FF RID: 79615 RVA: 0x005C99AA File Offset: 0x005C7DAA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node6()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06013700 RID: 79616 RVA: 0x005C99E0 File Offset: 0x005C7DE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D155 RID: 53589
		private int opl_p0;

		// Token: 0x0400D156 RID: 53590
		private int opl_p1;

		// Token: 0x0400D157 RID: 53591
		private int opl_p2;

		// Token: 0x0400D158 RID: 53592
		private int opl_p3;
	}
}
