using System;

namespace behaviac
{
	// Token: 0x02003AB2 RID: 15026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node1 : Condition
	{
		// Token: 0x06015D26 RID: 89382 RVA: 0x00697D0B File Offset: 0x0069610B
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node1()
		{
			this.opl_p0 = 21177;
		}

		// Token: 0x06015D27 RID: 89383 RVA: 0x00697D20 File Offset: 0x00696120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F646 RID: 63046
		private int opl_p0;
	}
}
