using System;

namespace behaviac
{
	// Token: 0x02002720 RID: 10016
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node48 : Condition
	{
		// Token: 0x06013782 RID: 79746 RVA: 0x005CCD06 File Offset: 0x005CB106
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node48()
		{
			this.opl_p0 = 4500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013783 RID: 79747 RVA: 0x005CCD3C File Offset: 0x005CB13C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1DB RID: 53723
		private int opl_p0;

		// Token: 0x0400D1DC RID: 53724
		private int opl_p1;

		// Token: 0x0400D1DD RID: 53725
		private int opl_p2;

		// Token: 0x0400D1DE RID: 53726
		private int opl_p3;
	}
}
