using System;

namespace behaviac
{
	// Token: 0x02002DA0 RID: 11680
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node46 : Condition
	{
		// Token: 0x06014421 RID: 82977 RVA: 0x00615E09 File Offset: 0x00614209
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node46()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06014422 RID: 82978 RVA: 0x00615E18 File Offset: 0x00614218
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDE8 RID: 56808
		private int opl_p0;
	}
}
