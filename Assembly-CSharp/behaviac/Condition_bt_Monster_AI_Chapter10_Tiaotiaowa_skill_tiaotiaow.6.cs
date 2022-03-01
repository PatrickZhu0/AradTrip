using System;

namespace behaviac
{
	// Token: 0x020030D3 RID: 12499
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node1 : Condition
	{
		// Token: 0x06014A5E RID: 84574 RVA: 0x00637C1F File Offset: 0x0063601F
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node1()
		{
			this.opl_p0 = 20644;
		}

		// Token: 0x06014A5F RID: 84575 RVA: 0x00637C34 File Offset: 0x00636034
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3C5 RID: 58309
		private int opl_p0;
	}
}
