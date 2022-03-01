using System;

namespace behaviac
{
	// Token: 0x02001F88 RID: 8072
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node23 : Condition
	{
		// Token: 0x060128B0 RID: 75952 RVA: 0x0056E25B File Offset: 0x0056C65B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node23()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060128B1 RID: 75953 RVA: 0x0056E290 File Offset: 0x0056C690
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A1 RID: 49825
		private int opl_p0;

		// Token: 0x0400C2A2 RID: 49826
		private int opl_p1;

		// Token: 0x0400C2A3 RID: 49827
		private int opl_p2;

		// Token: 0x0400C2A4 RID: 49828
		private int opl_p3;
	}
}
