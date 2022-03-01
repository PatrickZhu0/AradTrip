using System;

namespace behaviac
{
	// Token: 0x02003CF2 RID: 15602
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node98 : Condition
	{
		// Token: 0x06016183 RID: 90499 RVA: 0x006ADF07 File Offset: 0x006AC307
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node98()
		{
			this.opl_p0 = 21405;
		}

		// Token: 0x06016184 RID: 90500 RVA: 0x006ADF1C File Offset: 0x006AC31C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA20 RID: 64032
		private int opl_p0;
	}
}
