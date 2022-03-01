using System;

namespace behaviac
{
	// Token: 0x02002EF7 RID: 12023
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node49 : Condition
	{
		// Token: 0x060146C6 RID: 83654 RVA: 0x00624BB6 File Offset: 0x00622FB6
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node49()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570303;
		}

		// Token: 0x060146C7 RID: 83655 RVA: 0x00624BD8 File Offset: 0x00622FD8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E039 RID: 57401
		private BE_Target opl_p0;

		// Token: 0x0400E03A RID: 57402
		private BE_Equal opl_p1;

		// Token: 0x0400E03B RID: 57403
		private int opl_p2;
	}
}
