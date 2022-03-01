using System;

namespace behaviac
{
	// Token: 0x0200293E RID: 10558
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node38 : Condition
	{
		// Token: 0x06013BB2 RID: 80818 RVA: 0x005E5706 File Offset: 0x005E3B06
		public Condition_bt_AutoFight_AutoFight_Swordman_Jianhun_Action_node38()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013BB3 RID: 80819 RVA: 0x005E573C File Offset: 0x005E3B3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D617 RID: 54807
		private int opl_p0;

		// Token: 0x0400D618 RID: 54808
		private int opl_p1;

		// Token: 0x0400D619 RID: 54809
		private int opl_p2;

		// Token: 0x0400D61A RID: 54810
		private int opl_p3;
	}
}
