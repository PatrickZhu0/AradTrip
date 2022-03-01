using System;

namespace behaviac
{
	// Token: 0x02003D9C RID: 15772
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node7 : Condition
	{
		// Token: 0x060162CA RID: 90826 RVA: 0x006B4342 File Offset: 0x006B2742
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node7()
		{
			this.opl_p0 = ServerNotifyMessageId.HARDTeamTailPass;
		}

		// Token: 0x060162CB RID: 90827 RVA: 0x006B4354 File Offset: 0x006B2754
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB1A RID: 64282
		private ServerNotifyMessageId opl_p0;
	}
}
