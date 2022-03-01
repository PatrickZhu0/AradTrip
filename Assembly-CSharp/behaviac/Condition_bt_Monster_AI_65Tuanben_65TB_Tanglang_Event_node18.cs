using System;

namespace behaviac
{
	// Token: 0x02002CB0 RID: 11440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node18 : Condition
	{
		// Token: 0x06014255 RID: 82517 RVA: 0x0060CE83 File Offset: 0x0060B283
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node18()
		{
			this.opl_p0 = 20758;
		}

		// Token: 0x06014256 RID: 82518 RVA: 0x0060CE98 File Offset: 0x0060B298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC0E RID: 56334
		private int opl_p0;
	}
}
