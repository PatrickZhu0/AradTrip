using System;

namespace behaviac
{
	// Token: 0x02003137 RID: 12599
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node3 : Condition
	{
		// Token: 0x06014B11 RID: 84753 RVA: 0x0063B39E File Offset: 0x0063979E
		public Condition_bt_Monster_AI_Chapter10_Shouhuzhe_B_Event_node3()
		{
			this.opl_p0 = 41590021;
			this.opl_p1 = 1;
		}

		// Token: 0x06014B12 RID: 84754 RVA: 0x0063B3B8 File Offset: 0x006397B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E482 RID: 58498
		private int opl_p0;

		// Token: 0x0400E483 RID: 58499
		private int opl_p1;
	}
}
