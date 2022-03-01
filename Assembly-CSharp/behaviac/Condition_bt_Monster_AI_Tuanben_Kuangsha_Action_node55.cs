using System;

namespace behaviac
{
	// Token: 0x02003AB9 RID: 15033
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node55 : Condition
	{
		// Token: 0x06015D31 RID: 89393 RVA: 0x006983B2 File Offset: 0x006967B2
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node55()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015D32 RID: 89394 RVA: 0x006983C4 File Offset: 0x006967C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F64E RID: 63054
		private int opl_p0;
	}
}
