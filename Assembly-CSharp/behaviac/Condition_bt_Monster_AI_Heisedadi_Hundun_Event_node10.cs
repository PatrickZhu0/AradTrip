using System;

namespace behaviac
{
	// Token: 0x0200345B RID: 13403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node10 : Condition
	{
		// Token: 0x06015102 RID: 86274 RVA: 0x00658793 File Offset: 0x00656B93
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node10()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521729;
		}

		// Token: 0x06015103 RID: 86275 RVA: 0x006587B4 File Offset: 0x00656BB4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9F3 RID: 59891
		private BE_Target opl_p0;

		// Token: 0x0400E9F4 RID: 59892
		private BE_Equal opl_p1;

		// Token: 0x0400E9F5 RID: 59893
		private int opl_p2;
	}
}
