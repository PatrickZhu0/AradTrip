using System;

namespace behaviac
{
	// Token: 0x02003CC8 RID: 15560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node40 : Condition
	{
		// Token: 0x06016132 RID: 90418 RVA: 0x006AC5BF File Offset: 0x006AA9BF
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node40()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016133 RID: 90419 RVA: 0x006AC5D4 File Offset: 0x006AA9D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9E3 RID: 63971
		private int opl_p0;
	}
}
