using System;

namespace behaviac
{
	// Token: 0x02003505 RID: 13573
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node45 : Condition
	{
		// Token: 0x0601524D RID: 86605 RVA: 0x0065EE5F File Offset: 0x0065D25F
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node45()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521791;
		}

		// Token: 0x0601524E RID: 86606 RVA: 0x0065EE80 File Offset: 0x0065D280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB86 RID: 60294
		private BE_Target opl_p0;

		// Token: 0x0400EB87 RID: 60295
		private BE_Equal opl_p1;

		// Token: 0x0400EB88 RID: 60296
		private int opl_p2;
	}
}
