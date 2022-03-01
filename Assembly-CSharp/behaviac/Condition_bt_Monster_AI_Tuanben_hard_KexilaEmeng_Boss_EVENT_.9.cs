using System;

namespace behaviac
{
	// Token: 0x02003BD8 RID: 15320
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node43 : Condition
	{
		// Token: 0x06015F5D RID: 89949 RVA: 0x006A2BF3 File Offset: 0x006A0FF3
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node43()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015F5E RID: 89950 RVA: 0x006A2C08 File Offset: 0x006A1008
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7F9 RID: 63481
		private int opl_p0;
	}
}
