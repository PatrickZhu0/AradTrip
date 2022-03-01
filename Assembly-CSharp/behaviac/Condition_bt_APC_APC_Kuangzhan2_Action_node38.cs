using System;

namespace behaviac
{
	// Token: 0x02001D86 RID: 7558
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node38 : Condition
	{
		// Token: 0x060124C7 RID: 74951 RVA: 0x00557182 File Offset: 0x00555582
		public Condition_bt_APC_APC_Kuangzhan2_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060124C8 RID: 74952 RVA: 0x005571B4 File Offset: 0x005555B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEB2 RID: 48818
		private int opl_p0;

		// Token: 0x0400BEB3 RID: 48819
		private int opl_p1;

		// Token: 0x0400BEB4 RID: 48820
		private int opl_p2;

		// Token: 0x0400BEB5 RID: 48821
		private int opl_p3;
	}
}
