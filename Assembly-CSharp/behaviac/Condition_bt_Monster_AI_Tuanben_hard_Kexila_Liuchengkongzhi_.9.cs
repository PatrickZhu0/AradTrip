using System;

namespace behaviac
{
	// Token: 0x02003CFC RID: 15612
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node1 : Condition
	{
		// Token: 0x06016197 RID: 90519 RVA: 0x006AE29B File Offset: 0x006AC69B
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node1()
		{
			this.opl_p0 = 21177;
		}

		// Token: 0x06016198 RID: 90520 RVA: 0x006AE2B0 File Offset: 0x006AC6B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA31 RID: 64049
		private int opl_p0;
	}
}
