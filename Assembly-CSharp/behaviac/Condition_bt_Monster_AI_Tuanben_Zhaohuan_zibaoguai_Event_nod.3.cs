using System;

namespace behaviac
{
	// Token: 0x02003B7E RID: 15230
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node9 : Condition
	{
		// Token: 0x06015EAE RID: 89774 RVA: 0x0069F867 File Offset: 0x0069DC67
		public Condition_bt_Monster_AI_Tuanben_Zhaohuan_zibaoguai_Event_node9()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015EAF RID: 89775 RVA: 0x0069F878 File Offset: 0x0069DC78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F773 RID: 63347
		private int opl_p0;
	}
}
