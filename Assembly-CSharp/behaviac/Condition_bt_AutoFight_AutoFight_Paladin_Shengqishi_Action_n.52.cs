using System;

namespace behaviac
{
	// Token: 0x02002857 RID: 10327
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node101 : Condition
	{
		// Token: 0x060139EC RID: 80364 RVA: 0x005DA1BE File Offset: 0x005D85BE
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node101()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060139ED RID: 80365 RVA: 0x005DA1F4 File Offset: 0x005D85F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D444 RID: 54340
		private int opl_p0;

		// Token: 0x0400D445 RID: 54341
		private int opl_p1;

		// Token: 0x0400D446 RID: 54342
		private int opl_p2;

		// Token: 0x0400D447 RID: 54343
		private int opl_p3;
	}
}
