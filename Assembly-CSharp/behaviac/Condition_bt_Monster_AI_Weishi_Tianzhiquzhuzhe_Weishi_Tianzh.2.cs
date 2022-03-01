using System;

namespace behaviac
{
	// Token: 0x02003DFC RID: 15868
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node5 : Condition
	{
		// Token: 0x06016382 RID: 91010 RVA: 0x006B79FB File Offset: 0x006B5DFB
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node5()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016383 RID: 91011 RVA: 0x006B7A30 File Offset: 0x006B5E30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBE7 RID: 64487
		private int opl_p0;

		// Token: 0x0400FBE8 RID: 64488
		private int opl_p1;

		// Token: 0x0400FBE9 RID: 64489
		private int opl_p2;

		// Token: 0x0400FBEA RID: 64490
		private int opl_p3;
	}
}
