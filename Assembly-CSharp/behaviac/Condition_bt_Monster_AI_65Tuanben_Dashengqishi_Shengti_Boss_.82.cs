using System;

namespace behaviac
{
	// Token: 0x02002E59 RID: 11865
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node239 : Condition
	{
		// Token: 0x0601458F RID: 83343 RVA: 0x0061B896 File Offset: 0x00619C96
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node239()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570290;
		}

		// Token: 0x06014590 RID: 83344 RVA: 0x0061B8B8 File Offset: 0x00619CB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF23 RID: 57123
		private BE_Target opl_p0;

		// Token: 0x0400DF24 RID: 57124
		private BE_Equal opl_p1;

		// Token: 0x0400DF25 RID: 57125
		private int opl_p2;
	}
}
