using System;

namespace behaviac
{
	// Token: 0x02002CA3 RID: 11427
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node2 : Condition
	{
		// Token: 0x0601423B RID: 82491 RVA: 0x0060CA63 File Offset: 0x0060AE63
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node2()
		{
			this.opl_p0 = 42470021;
		}

		// Token: 0x0601423C RID: 82492 RVA: 0x0060CA78 File Offset: 0x0060AE78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF3 RID: 56307
		private int opl_p0;
	}
}
