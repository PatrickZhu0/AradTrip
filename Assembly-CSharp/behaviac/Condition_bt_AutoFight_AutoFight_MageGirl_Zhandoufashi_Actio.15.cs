using System;

namespace behaviac
{
	// Token: 0x02002714 RID: 10004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node3 : Condition
	{
		// Token: 0x0601376A RID: 79722 RVA: 0x005CC7EA File Offset: 0x005CABEA
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node3()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x0601376B RID: 79723 RVA: 0x005CC820 File Offset: 0x005CAC20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1C3 RID: 53699
		private int opl_p0;

		// Token: 0x0400D1C4 RID: 53700
		private int opl_p1;

		// Token: 0x0400D1C5 RID: 53701
		private int opl_p2;

		// Token: 0x0400D1C6 RID: 53702
		private int opl_p3;
	}
}
