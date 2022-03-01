using System;

namespace behaviac
{
	// Token: 0x02003D9D RID: 15773
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node9 : Condition
	{
		// Token: 0x060162CC RID: 90828 RVA: 0x006B4387 File Offset: 0x006B2787
		public Condition_bt_Monster_AI_Tuanben_hard_Zhaohuan_zibaoguai_Event_hard_node9()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060162CD RID: 90829 RVA: 0x006B4398 File Offset: 0x006B2798
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB1B RID: 64283
		private int opl_p0;
	}
}
