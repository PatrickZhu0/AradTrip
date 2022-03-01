using System;

namespace behaviac
{
	// Token: 0x02003CC1 RID: 15553
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node36 : Condition
	{
		// Token: 0x06016124 RID: 90404 RVA: 0x006AC38A File Offset: 0x006AA78A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node36()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016125 RID: 90405 RVA: 0x006AC3A0 File Offset: 0x006AA7A0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9CE RID: 63950
		private int opl_p0;
	}
}
