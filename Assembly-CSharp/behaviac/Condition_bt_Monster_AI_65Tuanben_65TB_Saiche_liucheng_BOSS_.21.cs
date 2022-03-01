using System;

namespace behaviac
{
	// Token: 0x02002C08 RID: 11272
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node105 : Condition
	{
		// Token: 0x0601410F RID: 82191 RVA: 0x00605D71 File Offset: 0x00604171
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node105()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06014110 RID: 82192 RVA: 0x00605D80 File Offset: 0x00604180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 15000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAEB RID: 56043
		private int opl_p0;
	}
}
