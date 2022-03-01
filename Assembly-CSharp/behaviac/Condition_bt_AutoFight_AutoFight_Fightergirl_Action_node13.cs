using System;

namespace behaviac
{
	// Token: 0x02001EE1 RID: 7905
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node13 : Condition
	{
		// Token: 0x06012767 RID: 75623 RVA: 0x0056683E File Offset: 0x00564C3E
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Action_node13()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012768 RID: 75624 RVA: 0x00566874 File Offset: 0x00564C74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C15A RID: 49498
		private int opl_p0;

		// Token: 0x0400C15B RID: 49499
		private int opl_p1;

		// Token: 0x0400C15C RID: 49500
		private int opl_p2;

		// Token: 0x0400C15D RID: 49501
		private int opl_p3;
	}
}
