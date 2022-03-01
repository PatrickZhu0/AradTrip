using System;

namespace behaviac
{
	// Token: 0x02003AF8 RID: 15096
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node11 : Condition
	{
		// Token: 0x06015DAC RID: 89516 RVA: 0x0069A8CD File Offset: 0x00698CCD
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_action_node11()
		{
			this.opl_p0 = 21301;
		}

		// Token: 0x06015DAD RID: 89517 RVA: 0x0069A8E0 File Offset: 0x00698CE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A8 RID: 63144
		private int opl_p0;
	}
}
