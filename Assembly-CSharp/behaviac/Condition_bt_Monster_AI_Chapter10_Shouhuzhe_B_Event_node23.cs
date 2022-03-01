using System;

namespace behaviac
{
	// Token: 0x0200313D RID: 12605
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node23 : Condition
	{
		// Token: 0x06014B1D RID: 84765 RVA: 0x0063B5B6 File Offset: 0x006399B6
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node23()
		{
			this.opl_p0 = 41590021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014B1E RID: 84766 RVA: 0x0063B5D0 File Offset: 0x006399D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E496 RID: 58518
		private int opl_p0;

		// Token: 0x0400E497 RID: 58519
		private int opl_p1;
	}
}
