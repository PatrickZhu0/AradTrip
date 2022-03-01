using System;

namespace behaviac
{
	// Token: 0x02003B83 RID: 15235
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4 : Condition
	{
		// Token: 0x06015EB8 RID: 89784 RVA: 0x0069FA3B File Offset: 0x0069DE3B
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node4()
		{
			this.opl_p0 = ServerNotifyMessageId.TeamTailPass;
		}

		// Token: 0x06015EB9 RID: 89785 RVA: 0x0069FA4C File Offset: 0x0069DE4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_ServerNotify(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F77E RID: 63358
		private ServerNotifyMessageId opl_p0;
	}
}
