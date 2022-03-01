using System;

namespace behaviac
{
	// Token: 0x02002CC1 RID: 11457
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6 : Condition
	{
		// Token: 0x06014276 RID: 82550 RVA: 0x0060D9DD File Offset: 0x0060BDDD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node6()
		{
			this.opl_p0 = 20752;
		}

		// Token: 0x06014277 RID: 82551 RVA: 0x0060D9F0 File Offset: 0x0060BDF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC2B RID: 56363
		private int opl_p0;
	}
}
