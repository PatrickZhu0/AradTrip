using System;

namespace behaviac
{
	// Token: 0x02002F1E RID: 12062
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node27 : Condition
	{
		// Token: 0x06014712 RID: 83730 RVA: 0x0062655C File Offset: 0x0062495C
		public Condition_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node27()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014713 RID: 83731 RVA: 0x0062656C File Offset: 0x0062496C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 45000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E089 RID: 57481
		private int opl_p0;
	}
}
