using System;

namespace behaviac
{
	// Token: 0x020039D3 RID: 14803
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node39 : Condition
	{
		// Token: 0x06015B76 RID: 88950 RVA: 0x0068F1BE File Offset: 0x0068D5BE
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.CthyllaNightmare;
		}

		// Token: 0x06015B77 RID: 88951 RVA: 0x0068F1D0 File Offset: 0x0068D5D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4C1 RID: 62657
		private ServerNotifyMessageId opl_p0;
	}
}
