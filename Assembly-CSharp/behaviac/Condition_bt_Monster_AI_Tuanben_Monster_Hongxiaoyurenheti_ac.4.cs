using System;

namespace behaviac
{
	// Token: 0x02003AF9 RID: 15097
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node12 : Condition
	{
		// Token: 0x06015DAE RID: 89518 RVA: 0x0069A913 File Offset: 0x00698D13
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node12()
		{
			this.opl_p0 = 21301;
		}

		// Token: 0x06015DAF RID: 89519 RVA: 0x0069A928 File Offset: 0x00698D28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A9 RID: 63145
		private int opl_p0;
	}
}
