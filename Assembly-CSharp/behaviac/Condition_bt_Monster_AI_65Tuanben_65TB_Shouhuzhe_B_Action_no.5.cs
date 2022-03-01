using System;

namespace behaviac
{
	// Token: 0x02002C5F RID: 11359
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node14 : Condition
	{
		// Token: 0x060141B9 RID: 82361 RVA: 0x00609CC3 File Offset: 0x006080C3
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node14()
		{
			this.opl_p0 = 20780;
		}

		// Token: 0x060141BA RID: 82362 RVA: 0x00609CD8 File Offset: 0x006080D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB78 RID: 56184
		private int opl_p0;
	}
}
