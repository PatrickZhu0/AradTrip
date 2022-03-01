using System;

namespace behaviac
{
	// Token: 0x02003737 RID: 14135
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node4 : Condition
	{
		// Token: 0x06015679 RID: 87673 RVA: 0x00675411 File Offset: 0x00673811
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node4()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.SKILL;
		}

		// Token: 0x0601567A RID: 87674 RVA: 0x00675430 File Offset: 0x00673830
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F048 RID: 61512
		private BE_Target opl_p0;

		// Token: 0x0400F049 RID: 61513
		private BE_Equal opl_p1;

		// Token: 0x0400F04A RID: 61514
		private BE_State opl_p2;
	}
}
