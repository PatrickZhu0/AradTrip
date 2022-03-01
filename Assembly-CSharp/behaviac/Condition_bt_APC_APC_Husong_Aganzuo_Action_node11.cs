using System;

namespace behaviac
{
	// Token: 0x02001D54 RID: 7508
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Husong_Aganzuo_Action_node11 : Condition
	{
		// Token: 0x06012467 RID: 74855 RVA: 0x00554DB2 File Offset: 0x005531B2
		public Condition_bt_APC_APC_Husong_Aganzuo_Action_node11()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012468 RID: 74856 RVA: 0x00554DE8 File Offset: 0x005531E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE56 RID: 48726
		private int opl_p0;

		// Token: 0x0400BE57 RID: 48727
		private int opl_p1;

		// Token: 0x0400BE58 RID: 48728
		private int opl_p2;

		// Token: 0x0400BE59 RID: 48729
		private int opl_p3;
	}
}
