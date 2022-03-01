using System;

namespace behaviac
{
	// Token: 0x02002C36 RID: 11318
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node14 : Condition
	{
		// Token: 0x0601416A RID: 82282 RVA: 0x00608367 File Offset: 0x00606767
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node14()
		{
			this.opl_p0 = 20778;
		}

		// Token: 0x0601416B RID: 82283 RVA: 0x0060837C File Offset: 0x0060677C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB2E RID: 56110
		private int opl_p0;
	}
}
