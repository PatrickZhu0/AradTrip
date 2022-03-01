using System;

namespace behaviac
{
	// Token: 0x02002C5A RID: 11354
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node4 : Condition
	{
		// Token: 0x060141AF RID: 82351 RVA: 0x00609B3D File Offset: 0x00607F3D
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node4()
		{
			this.opl_p0 = 20779;
		}

		// Token: 0x060141B0 RID: 82352 RVA: 0x00609B50 File Offset: 0x00607F50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB72 RID: 56178
		private int opl_p0;
	}
}
