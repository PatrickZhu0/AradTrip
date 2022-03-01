using System;

namespace behaviac
{
	// Token: 0x02002CC9 RID: 11465
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node24 : Condition
	{
		// Token: 0x06014286 RID: 82566 RVA: 0x0060DCDD File Offset: 0x0060C0DD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Fenshen_Action_node24()
		{
			this.opl_p0 = 20754;
		}

		// Token: 0x06014287 RID: 82567 RVA: 0x0060DCF0 File Offset: 0x0060C0F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC39 RID: 56377
		private int opl_p0;
	}
}
