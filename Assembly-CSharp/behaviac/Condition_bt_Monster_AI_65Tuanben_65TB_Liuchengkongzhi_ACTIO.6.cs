using System;

namespace behaviac
{
	// Token: 0x02002BC0 RID: 11200
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node8 : Condition
	{
		// Token: 0x06014084 RID: 82052 RVA: 0x00604356 File Offset: 0x00602756
		public Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node8()
		{
			this.opl_p0 = 87350031;
		}

		// Token: 0x06014085 RID: 82053 RVA: 0x0060436C File Offset: 0x0060276C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsHaveMonster(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA76 RID: 55926
		private int opl_p0;
	}
}
