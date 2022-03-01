using System;

namespace behaviac
{
	// Token: 0x02002837 RID: 10295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node38 : Condition
	{
		// Token: 0x060139AC RID: 80300 RVA: 0x005D941E File Offset: 0x005D781E
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node38()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060139AD RID: 80301 RVA: 0x005D9454 File Offset: 0x005D7854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D404 RID: 54276
		private int opl_p0;

		// Token: 0x0400D405 RID: 54277
		private int opl_p1;

		// Token: 0x0400D406 RID: 54278
		private int opl_p2;

		// Token: 0x0400D407 RID: 54279
		private int opl_p3;
	}
}
