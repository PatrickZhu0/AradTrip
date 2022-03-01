using System;

namespace behaviac
{
	// Token: 0x02003B13 RID: 15123
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node0 : Condition
	{
		// Token: 0x06015DDF RID: 89567 RVA: 0x0069B913 File Offset: 0x00699D13
		public Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node0()
		{
			this.opl_p0 = 21300;
		}

		// Token: 0x06015DE0 RID: 89568 RVA: 0x0069B928 File Offset: 0x00699D28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6CB RID: 63179
		private int opl_p0;
	}
}
