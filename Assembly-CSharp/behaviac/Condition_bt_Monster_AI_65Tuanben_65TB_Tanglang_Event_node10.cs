using System;

namespace behaviac
{
	// Token: 0x02002CAB RID: 11435
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node10 : Condition
	{
		// Token: 0x0601424B RID: 82507 RVA: 0x0060CCB7 File Offset: 0x0060B0B7
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node10()
		{
			this.opl_p0 = 20756;
		}

		// Token: 0x0601424C RID: 82508 RVA: 0x0060CCCC File Offset: 0x0060B0CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DC04 RID: 56324
		private int opl_p0;
	}
}
