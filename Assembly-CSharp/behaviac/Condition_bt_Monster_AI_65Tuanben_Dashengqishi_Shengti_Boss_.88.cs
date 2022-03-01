using System;

namespace behaviac
{
	// Token: 0x02002E66 RID: 11878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node258 : Condition
	{
		// Token: 0x060145A9 RID: 83369 RVA: 0x0061BCEA File Offset: 0x0061A0EA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node258()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060145AA RID: 83370 RVA: 0x0061BCFC File Offset: 0x0061A0FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 40000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF35 RID: 57141
		private int opl_p0;
	}
}
