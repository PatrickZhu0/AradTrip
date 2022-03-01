using System;

namespace behaviac
{
	// Token: 0x02001F40 RID: 8000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node29 : Condition
	{
		// Token: 0x06012823 RID: 75811 RVA: 0x0056AB23 File Offset: 0x00568F23
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node29()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012824 RID: 75812 RVA: 0x0056AB58 File Offset: 0x00568F58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C219 RID: 49689
		private int opl_p0;

		// Token: 0x0400C21A RID: 49690
		private int opl_p1;

		// Token: 0x0400C21B RID: 49691
		private int opl_p2;

		// Token: 0x0400C21C RID: 49692
		private int opl_p3;
	}
}
