using System;

namespace behaviac
{
	// Token: 0x020030CB RID: 12491
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node1 : Condition
	{
		// Token: 0x06014A50 RID: 84560 RVA: 0x0063777F File Offset: 0x00635B7F
		public Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_easy_node1()
		{
			this.opl_p0 = 20644;
		}

		// Token: 0x06014A51 RID: 84561 RVA: 0x00637794 File Offset: 0x00635B94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3B9 RID: 58297
		private int opl_p0;
	}
}
