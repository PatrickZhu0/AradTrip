using System;

namespace behaviac
{
	// Token: 0x0200404C RID: 16460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node32 : Condition
	{
		// Token: 0x060167F7 RID: 92151 RVA: 0x006CF1B9 File Offset: 0x006CD5B9
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node32()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x060167F8 RID: 92152 RVA: 0x006CF1CC File Offset: 0x006CD5CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010043 RID: 65603
		private int opl_p0;
	}
}
