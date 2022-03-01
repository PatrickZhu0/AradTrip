using System;

namespace behaviac
{
	// Token: 0x02003DFD RID: 15869
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node6 : Condition
	{
		// Token: 0x06016384 RID: 91012 RVA: 0x006B7A75 File Offset: 0x006B5E75
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node6()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x06016385 RID: 91013 RVA: 0x006B7A94 File Offset: 0x006B5E94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBEB RID: 64491
		private BE_Target opl_p0;

		// Token: 0x0400FBEC RID: 64492
		private BE_Equal opl_p1;

		// Token: 0x0400FBED RID: 64493
		private BE_State opl_p2;
	}
}
