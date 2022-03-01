using System;

namespace behaviac
{
	// Token: 0x02002CA5 RID: 11429
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node4 : Condition
	{
		// Token: 0x0601423F RID: 82495 RVA: 0x0060CAFA File Offset: 0x0060AEFA
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node4()
		{
			this.opl_p0 = 42490021;
		}

		// Token: 0x06014240 RID: 82496 RVA: 0x0060CB10 File Offset: 0x0060AF10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF5 RID: 56309
		private int opl_p0;
	}
}
