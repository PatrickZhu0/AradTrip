using System;

namespace behaviac
{
	// Token: 0x02003B12 RID: 15122
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node8 : Condition
	{
		// Token: 0x06015DDD RID: 89565 RVA: 0x0069B8CD File Offset: 0x00699CCD
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node8()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x06015DDE RID: 89566 RVA: 0x0069B8E0 File Offset: 0x00699CE0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HaveSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6CA RID: 63178
		private int opl_p0;
	}
}
