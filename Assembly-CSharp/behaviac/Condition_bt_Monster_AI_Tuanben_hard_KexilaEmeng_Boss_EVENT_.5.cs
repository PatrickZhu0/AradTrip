using System;

namespace behaviac
{
	// Token: 0x02003BCC RID: 15308
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node36 : Condition
	{
		// Token: 0x06015F45 RID: 89925 RVA: 0x006A284E File Offset: 0x006A0C4E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node36()
		{
			this.opl_p0 = 8001500;
		}

		// Token: 0x06015F46 RID: 89926 RVA: 0x006A2864 File Offset: 0x006A0C64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_DungeonRecoverProcess(this.opl_p0);
			int num2 = 1000;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7D9 RID: 63449
		private int opl_p0;
	}
}
