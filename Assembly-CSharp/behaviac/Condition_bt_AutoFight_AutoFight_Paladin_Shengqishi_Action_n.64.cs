using System;

namespace behaviac
{
	// Token: 0x02002867 RID: 10343
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node42 : Condition
	{
		// Token: 0x06013A0C RID: 80396 RVA: 0x005DA8EA File Offset: 0x005D8CEA
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node42()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 800;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013A0D RID: 80397 RVA: 0x005DA920 File Offset: 0x005D8D20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D464 RID: 54372
		private int opl_p0;

		// Token: 0x0400D465 RID: 54373
		private int opl_p1;

		// Token: 0x0400D466 RID: 54374
		private int opl_p2;

		// Token: 0x0400D467 RID: 54375
		private int opl_p3;
	}
}
