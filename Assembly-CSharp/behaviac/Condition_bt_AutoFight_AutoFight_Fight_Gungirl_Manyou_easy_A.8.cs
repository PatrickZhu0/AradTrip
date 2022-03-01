using System;

namespace behaviac
{
	// Token: 0x02001FCC RID: 8140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node18 : Condition
	{
		// Token: 0x06012935 RID: 76085 RVA: 0x005717B7 File Offset: 0x0056FBB7
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node18()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012936 RID: 76086 RVA: 0x005717EC File Offset: 0x0056FBEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C326 RID: 49958
		private int opl_p0;

		// Token: 0x0400C327 RID: 49959
		private int opl_p1;

		// Token: 0x0400C328 RID: 49960
		private int opl_p2;

		// Token: 0x0400C329 RID: 49961
		private int opl_p3;
	}
}
