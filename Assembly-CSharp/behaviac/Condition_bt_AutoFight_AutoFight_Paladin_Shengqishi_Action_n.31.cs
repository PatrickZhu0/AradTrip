using System;

namespace behaviac
{
	// Token: 0x0200283B RID: 10299
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node13 : Condition
	{
		// Token: 0x060139B4 RID: 80308 RVA: 0x005D95D2 File Offset: 0x005D79D2
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node13()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139B5 RID: 80309 RVA: 0x005D9608 File Offset: 0x005D7A08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D40C RID: 54284
		private int opl_p0;

		// Token: 0x0400D40D RID: 54285
		private int opl_p1;

		// Token: 0x0400D40E RID: 54286
		private int opl_p2;

		// Token: 0x0400D40F RID: 54287
		private int opl_p3;
	}
}
