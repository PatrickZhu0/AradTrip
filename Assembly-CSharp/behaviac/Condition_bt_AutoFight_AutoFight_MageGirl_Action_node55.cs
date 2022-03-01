using System;

namespace behaviac
{
	// Token: 0x02002694 RID: 9876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node55 : Condition
	{
		// Token: 0x0601366C RID: 79468 RVA: 0x005C6CC6 File Offset: 0x005C50C6
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node55()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601366D RID: 79469 RVA: 0x005C6CFC File Offset: 0x005C50FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0BF RID: 53439
		private int opl_p0;

		// Token: 0x0400D0C0 RID: 53440
		private int opl_p1;

		// Token: 0x0400D0C1 RID: 53441
		private int opl_p2;

		// Token: 0x0400D0C2 RID: 53442
		private int opl_p3;
	}
}
