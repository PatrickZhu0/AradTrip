using System;

namespace behaviac
{
	// Token: 0x02001F5A RID: 8026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node49 : Condition
	{
		// Token: 0x06012857 RID: 75863 RVA: 0x0056B69B File Offset: 0x00569A9B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012858 RID: 75864 RVA: 0x0056B6D0 File Offset: 0x00569AD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C250 RID: 49744
		private int opl_p0;

		// Token: 0x0400C251 RID: 49745
		private int opl_p1;

		// Token: 0x0400C252 RID: 49746
		private int opl_p2;

		// Token: 0x0400C253 RID: 49747
		private int opl_p3;
	}
}
