using System;

namespace behaviac
{
	// Token: 0x02003154 RID: 12628
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node7 : Condition
	{
		// Token: 0x06014B47 RID: 84807 RVA: 0x0063C4FC File Offset: 0x0063A8FC
		public Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522053;
		}

		// Token: 0x06014B48 RID: 84808 RVA: 0x0063C520 File Offset: 0x0063A920
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4BD RID: 58557
		private BE_Target opl_p0;

		// Token: 0x0400E4BE RID: 58558
		private BE_Equal opl_p1;

		// Token: 0x0400E4BF RID: 58559
		private int opl_p2;
	}
}
