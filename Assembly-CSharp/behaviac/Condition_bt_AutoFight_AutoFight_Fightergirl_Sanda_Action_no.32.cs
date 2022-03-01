using System;

namespace behaviac
{
	// Token: 0x02001F4D RID: 8013
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node36 : Condition
	{
		// Token: 0x0601283D RID: 75837 RVA: 0x0056B117 File Offset: 0x00569517
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node36()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601283E RID: 75838 RVA: 0x0056B14C File Offset: 0x0056954C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C235 RID: 49717
		private int opl_p0;

		// Token: 0x0400C236 RID: 49718
		private int opl_p1;

		// Token: 0x0400C237 RID: 49719
		private int opl_p2;

		// Token: 0x0400C238 RID: 49720
		private int opl_p3;
	}
}
