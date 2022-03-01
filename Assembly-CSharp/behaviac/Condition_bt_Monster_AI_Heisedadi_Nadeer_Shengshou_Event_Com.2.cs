using System;

namespace behaviac
{
	// Token: 0x02003546 RID: 13638
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node5 : Condition
	{
		// Token: 0x060152CD RID: 86733 RVA: 0x00661CF2 File Offset: 0x006600F2
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node5()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521769;
		}

		// Token: 0x060152CE RID: 86734 RVA: 0x00661D14 File Offset: 0x00660114
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC81 RID: 60545
		private BE_Target opl_p0;

		// Token: 0x0400EC82 RID: 60546
		private BE_Equal opl_p1;

		// Token: 0x0400EC83 RID: 60547
		private int opl_p2;
	}
}
