using System;

namespace behaviac
{
	// Token: 0x02003AA7 RID: 15015
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node85 : Condition
	{
		// Token: 0x06015D10 RID: 89360 RVA: 0x00697933 File Offset: 0x00695D33
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015D11 RID: 89361 RVA: 0x00697944 File Offset: 0x00695D44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F634 RID: 63028
		private int opl_p0;
	}
}
