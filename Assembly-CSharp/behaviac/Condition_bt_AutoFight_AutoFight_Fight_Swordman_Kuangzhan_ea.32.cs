using System;

namespace behaviac
{
	// Token: 0x02002330 RID: 9008
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node61 : Condition
	{
		// Token: 0x06012FD3 RID: 77779 RVA: 0x0059CEEB File Offset: 0x0059B2EB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_easy_Action_node61()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012FD4 RID: 77780 RVA: 0x0059CF20 File Offset: 0x0059B320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C9EB RID: 51691
		private int opl_p0;

		// Token: 0x0400C9EC RID: 51692
		private int opl_p1;

		// Token: 0x0400C9ED RID: 51693
		private int opl_p2;

		// Token: 0x0400C9EE RID: 51694
		private int opl_p3;
	}
}
