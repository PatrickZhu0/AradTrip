using System;

namespace behaviac
{
	// Token: 0x02003C64 RID: 15460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node43 : Condition
	{
		// Token: 0x06016070 RID: 90224 RVA: 0x006A817B File Offset: 0x006A657B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node43()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06016071 RID: 90225 RVA: 0x006A8190 File Offset: 0x006A6590
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8F3 RID: 63731
		private int opl_p0;
	}
}
