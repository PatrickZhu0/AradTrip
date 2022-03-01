using System;

namespace behaviac
{
	// Token: 0x020035F6 RID: 13814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17 : Condition
	{
		// Token: 0x06015412 RID: 87058 RVA: 0x0066836F File Offset: 0x0066676F
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node17()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x06015413 RID: 87059 RVA: 0x006683A4 File Offset: 0x006667A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDCA RID: 60874
		private int opl_p0;

		// Token: 0x0400EDCB RID: 60875
		private int opl_p1;

		// Token: 0x0400EDCC RID: 60876
		private int opl_p2;

		// Token: 0x0400EDCD RID: 60877
		private int opl_p3;
	}
}
