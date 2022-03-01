using System;

namespace behaviac
{
	// Token: 0x0200368B RID: 13963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4 : Condition
	{
		// Token: 0x06015534 RID: 87348 RVA: 0x0066EAFF File Offset: 0x0066CEFF
		public Condition_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node4()
		{
			this.opl_p0 = 5629;
		}

		// Token: 0x06015535 RID: 87349 RVA: 0x0066EB14 File Offset: 0x0066CF14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEF7 RID: 61175
		private int opl_p0;
	}
}
