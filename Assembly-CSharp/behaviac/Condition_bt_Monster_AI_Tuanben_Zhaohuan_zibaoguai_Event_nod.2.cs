using System;

namespace behaviac
{
	// Token: 0x02003B7D RID: 15229
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7 : Condition
	{
		// Token: 0x06015EAC RID: 89772 RVA: 0x0069F822 File Offset: 0x0069DC22
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node7()
		{
			this.opl_p0 = ServerNotifyMessageId.TeamTailPass;
		}

		// Token: 0x06015EAD RID: 89773 RVA: 0x0069F834 File Offset: 0x0069DC34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F772 RID: 63346
		private ServerNotifyMessageId opl_p0;
	}
}
