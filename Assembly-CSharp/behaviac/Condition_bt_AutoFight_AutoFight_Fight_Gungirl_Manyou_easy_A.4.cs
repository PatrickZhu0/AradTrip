using System;

namespace behaviac
{
	// Token: 0x02001FC4 RID: 8132
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node8 : Condition
	{
		// Token: 0x06012925 RID: 76069 RVA: 0x005713CF File Offset: 0x0056F7CF
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node8()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06012926 RID: 76070 RVA: 0x00571404 File Offset: 0x0056F804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C316 RID: 49942
		private int opl_p0;

		// Token: 0x0400C317 RID: 49943
		private int opl_p1;

		// Token: 0x0400C318 RID: 49944
		private int opl_p2;

		// Token: 0x0400C319 RID: 49945
		private int opl_p3;
	}
}
