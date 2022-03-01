using System;

namespace behaviac
{
	// Token: 0x02003156 RID: 12630
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node10 : Condition
	{
		// Token: 0x06014B4B RID: 84811 RVA: 0x0063C5C2 File Offset: 0x0063A9C2
		public Condition_bt_Monster_AI_Chapter10_Yiliaobing_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522051;
		}

		// Token: 0x06014B4C RID: 84812 RVA: 0x0063C5E4 File Offset: 0x0063A9E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4C5 RID: 58565
		private BE_Target opl_p0;

		// Token: 0x0400E4C6 RID: 58566
		private BE_Equal opl_p1;

		// Token: 0x0400E4C7 RID: 58567
		private int opl_p2;
	}
}
