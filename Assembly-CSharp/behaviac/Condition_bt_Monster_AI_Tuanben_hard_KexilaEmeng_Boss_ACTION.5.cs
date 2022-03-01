using System;

namespace behaviac
{
	// Token: 0x02003B92 RID: 15250
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node39 : Condition
	{
		// Token: 0x06015ED4 RID: 89812 RVA: 0x006A021A File Offset: 0x0069E61A
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDCthyllaNightmare;
		}

		// Token: 0x06015ED5 RID: 89813 RVA: 0x006A022C File Offset: 0x0069E62C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F78B RID: 63371
		private ServerNotifyMessageId opl_p0;
	}
}
