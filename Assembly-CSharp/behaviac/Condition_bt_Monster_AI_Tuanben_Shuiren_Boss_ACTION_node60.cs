using System;

namespace behaviac
{
	// Token: 0x02003B59 RID: 15193
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node60 : Condition
	{
		// Token: 0x06015E67 RID: 89703 RVA: 0x0069DAB7 File Offset: 0x0069BEB7
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node60()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015E68 RID: 89704 RVA: 0x0069DAC8 File Offset: 0x0069BEC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F733 RID: 63283
		private int opl_p0;
	}
}
