using System;

namespace behaviac
{
	// Token: 0x02003DA2 RID: 15778
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node4 : Condition
	{
		// Token: 0x060162D6 RID: 90838 RVA: 0x006B455B File Offset: 0x006B295B
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node4()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDTeamTailPass;
		}

		// Token: 0x060162D7 RID: 90839 RVA: 0x006B456C File Offset: 0x006B296C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB26 RID: 64294
		private ServerNotifyMessageId opl_p0;
	}
}
