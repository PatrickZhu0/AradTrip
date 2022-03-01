using System;

namespace behaviac
{
	// Token: 0x02002CF1 RID: 11505
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node40 : Condition
	{
		// Token: 0x060142D2 RID: 82642 RVA: 0x0060F0BD File Offset: 0x0060D4BD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Action_node40()
		{
			this.opl_p0 = 20742;
		}

		// Token: 0x060142D3 RID: 82643 RVA: 0x0060F0D0 File Offset: 0x0060D4D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC7E RID: 56446
		private int opl_p0;
	}
}
