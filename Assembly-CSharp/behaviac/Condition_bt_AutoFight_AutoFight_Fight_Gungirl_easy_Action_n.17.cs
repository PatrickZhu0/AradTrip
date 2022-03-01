using System;

namespace behaviac
{
	// Token: 0x02001F8C RID: 8076
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node28 : Condition
	{
		// Token: 0x060128B8 RID: 75960 RVA: 0x0056E40F File Offset: 0x0056C80F
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_easy_Action_node28()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060128B9 RID: 75961 RVA: 0x0056E444 File Offset: 0x0056C844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2A9 RID: 49833
		private int opl_p0;

		// Token: 0x0400C2AA RID: 49834
		private int opl_p1;

		// Token: 0x0400C2AB RID: 49835
		private int opl_p2;

		// Token: 0x0400C2AC RID: 49836
		private int opl_p3;
	}
}
