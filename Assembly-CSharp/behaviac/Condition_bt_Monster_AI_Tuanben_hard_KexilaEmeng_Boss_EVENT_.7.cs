using System;

namespace behaviac
{
	// Token: 0x02003BD3 RID: 15315
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node40 : Condition
	{
		// Token: 0x06015F53 RID: 89939 RVA: 0x006A2A83 File Offset: 0x006A0E83
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node40()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015F54 RID: 89940 RVA: 0x006A2A98 File Offset: 0x006A0E98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 500;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7EE RID: 63470
		private int opl_p0;
	}
}
