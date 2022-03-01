using System;

namespace behaviac
{
	// Token: 0x02002CA4 RID: 11428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node3 : Condition
	{
		// Token: 0x0601423D RID: 82493 RVA: 0x0060CAAE File Offset: 0x0060AEAE
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node3()
		{
			this.opl_p0 = 42480021;
		}

		// Token: 0x0601423E RID: 82494 RVA: 0x0060CAC4 File Offset: 0x0060AEC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF4 RID: 56308
		private int opl_p0;
	}
}
