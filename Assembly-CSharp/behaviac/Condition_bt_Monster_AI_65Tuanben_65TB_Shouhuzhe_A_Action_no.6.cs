using System;

namespace behaviac
{
	// Token: 0x02002C39 RID: 11321
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node20 : Condition
	{
		// Token: 0x06014170 RID: 82288 RVA: 0x0060846D File Offset: 0x0060686D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node20()
		{
			this.opl_p0 = 20777;
		}

		// Token: 0x06014171 RID: 82289 RVA: 0x00608480 File Offset: 0x00606880
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB31 RID: 56113
		private int opl_p0;
	}
}
