using System;

namespace behaviac
{
	// Token: 0x02002718 RID: 10008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node29 : Condition
	{
		// Token: 0x06013772 RID: 79730 RVA: 0x005CC99E File Offset: 0x005CAD9E
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhandoufashi_Action_node29()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013773 RID: 79731 RVA: 0x005CC9D4 File Offset: 0x005CADD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D1CB RID: 53707
		private int opl_p0;

		// Token: 0x0400D1CC RID: 53708
		private int opl_p1;

		// Token: 0x0400D1CD RID: 53709
		private int opl_p2;

		// Token: 0x0400D1CE RID: 53710
		private int opl_p3;
	}
}
