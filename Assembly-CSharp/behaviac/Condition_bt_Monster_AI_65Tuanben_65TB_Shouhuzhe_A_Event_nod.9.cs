using System;

namespace behaviac
{
	// Token: 0x02002C49 RID: 11337
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node17 : Condition
	{
		// Token: 0x0601418E RID: 82318 RVA: 0x00608F0B File Offset: 0x0060730B
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node17()
		{
			this.opl_p0 = 20781;
		}

		// Token: 0x0601418F RID: 82319 RVA: 0x00608F20 File Offset: 0x00607320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB56 RID: 56150
		private int opl_p0;
	}
}
