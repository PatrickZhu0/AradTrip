using System;

namespace behaviac
{
	// Token: 0x02003AA6 RID: 15014
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node39 : Condition
	{
		// Token: 0x06015D0E RID: 89358 RVA: 0x006978EF File Offset: 0x00695CEF
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node39()
		{
			this.opl_p0 = ServerNotifyMessageId.CthyllaNightmare;
		}

		// Token: 0x06015D0F RID: 89359 RVA: 0x00697900 File Offset: 0x00695D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F633 RID: 63027
		private ServerNotifyMessageId opl_p0;
	}
}
