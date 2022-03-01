using System;

namespace behaviac
{
	// Token: 0x02003551 RID: 13649
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node1 : Condition
	{
		// Token: 0x060152E1 RID: 86753 RVA: 0x006623AE File Offset: 0x006607AE
		public Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node1()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060152E2 RID: 86754 RVA: 0x006623E4 File Offset: 0x006607E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC98 RID: 60568
		private int opl_p0;

		// Token: 0x0400EC99 RID: 60569
		private int opl_p1;

		// Token: 0x0400EC9A RID: 60570
		private int opl_p2;

		// Token: 0x0400EC9B RID: 60571
		private int opl_p3;
	}
}
