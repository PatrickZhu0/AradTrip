using System;

namespace behaviac
{
	// Token: 0x02003B58 RID: 15192
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node9 : Condition
	{
		// Token: 0x06015E65 RID: 89701 RVA: 0x0069DA72 File Offset: 0x0069BE72
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node9()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06015E66 RID: 89702 RVA: 0x0069DA84 File Offset: 0x0069BE84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 7;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F732 RID: 63282
		private int opl_p0;
	}
}
