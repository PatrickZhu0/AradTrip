using System;

namespace behaviac
{
	// Token: 0x02002D69 RID: 11625
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node8 : Condition
	{
		// Token: 0x060143B4 RID: 82868 RVA: 0x00613F63 File Offset: 0x00612363
		public Condition_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node8()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060143B5 RID: 82869 RVA: 0x00613F74 File Offset: 0x00612374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD7E RID: 56702
		private int opl_p0;
	}
}
