using System;

namespace behaviac
{
	// Token: 0x02001F45 RID: 8005
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node41 : Condition
	{
		// Token: 0x0601282D RID: 75821 RVA: 0x0056AD4B File Offset: 0x0056914B
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node41()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601282E RID: 75822 RVA: 0x0056AD80 File Offset: 0x00569180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C225 RID: 49701
		private int opl_p0;

		// Token: 0x0400C226 RID: 49702
		private int opl_p1;

		// Token: 0x0400C227 RID: 49703
		private int opl_p2;

		// Token: 0x0400C228 RID: 49704
		private int opl_p3;
	}
}
