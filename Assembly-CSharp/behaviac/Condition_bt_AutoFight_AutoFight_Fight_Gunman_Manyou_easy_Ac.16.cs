using System;

namespace behaviac
{
	// Token: 0x0200211F RID: 8479
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node38 : Condition
	{
		// Token: 0x06012BD1 RID: 76753 RVA: 0x0058162F File Offset: 0x0057FA2F
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node38()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012BD2 RID: 76754 RVA: 0x00581664 File Offset: 0x0057FA64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5C3 RID: 50627
		private int opl_p0;

		// Token: 0x0400C5C4 RID: 50628
		private int opl_p1;

		// Token: 0x0400C5C5 RID: 50629
		private int opl_p2;

		// Token: 0x0400C5C6 RID: 50630
		private int opl_p3;
	}
}
