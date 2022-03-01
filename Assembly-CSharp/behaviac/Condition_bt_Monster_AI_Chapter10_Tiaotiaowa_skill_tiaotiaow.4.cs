using System;

namespace behaviac
{
	// Token: 0x020030CF RID: 12495
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node1 : Condition
	{
		// Token: 0x06014A57 RID: 84567 RVA: 0x006379CF File Offset: 0x00635DCF
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_hard_node1()
		{
			this.opl_p0 = 20644;
		}

		// Token: 0x06014A58 RID: 84568 RVA: 0x006379E4 File Offset: 0x00635DE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3BF RID: 58303
		private int opl_p0;
	}
}
