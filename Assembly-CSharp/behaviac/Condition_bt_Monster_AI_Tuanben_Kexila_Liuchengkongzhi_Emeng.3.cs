using System;

namespace behaviac
{
	// Token: 0x02003AA8 RID: 15016
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node98 : Condition
	{
		// Token: 0x06015D12 RID: 89362 RVA: 0x00697977 File Offset: 0x00695D77
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node98()
		{
			this.opl_p0 = 21405;
		}

		// Token: 0x06015D13 RID: 89363 RVA: 0x0069798C File Offset: 0x00695D8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F635 RID: 63029
		private int opl_p0;
	}
}
