using System;

namespace behaviac
{
	// Token: 0x02001F78 RID: 8056
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node3 : Condition
	{
		// Token: 0x06012890 RID: 75920 RVA: 0x0056D97B File Offset: 0x0056BD7B
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node3()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012891 RID: 75921 RVA: 0x0056D9B0 File Offset: 0x0056BDB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C281 RID: 49793
		private int opl_p0;

		// Token: 0x0400C282 RID: 49794
		private int opl_p1;

		// Token: 0x0400C283 RID: 49795
		private int opl_p2;

		// Token: 0x0400C284 RID: 49796
		private int opl_p3;
	}
}
