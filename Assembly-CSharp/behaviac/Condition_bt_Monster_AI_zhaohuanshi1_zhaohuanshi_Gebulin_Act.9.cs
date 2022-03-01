using System;

namespace behaviac
{
	// Token: 0x02004040 RID: 16448
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node17 : Condition
	{
		// Token: 0x060167DF RID: 92127 RVA: 0x006CEC9D File Offset: 0x006CD09D
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node17()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x060167E0 RID: 92128 RVA: 0x006CECB0 File Offset: 0x006CD0B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401002B RID: 65579
		private int opl_p0;
	}
}
