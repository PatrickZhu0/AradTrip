using System;

namespace behaviac
{
	// Token: 0x02003AAC RID: 15020
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node11 : Condition
	{
		// Token: 0x06015D1A RID: 89370 RVA: 0x00697AE3 File Offset: 0x00695EE3
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node11()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015D1B RID: 89371 RVA: 0x00697AF4 File Offset: 0x00695EF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F63B RID: 63035
		private int opl_p0;
	}
}
