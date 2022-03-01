using System;

namespace behaviac
{
	// Token: 0x02002C57 RID: 11351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node2 : Condition
	{
		// Token: 0x060141A9 RID: 82345 RVA: 0x00609A37 File Offset: 0x00607E37
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node2()
		{
			this.opl_p0 = 20780;
		}

		// Token: 0x060141AA RID: 82346 RVA: 0x00609A4C File Offset: 0x00607E4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB6F RID: 56175
		private int opl_p0;
	}
}
