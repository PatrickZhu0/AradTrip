using System;

namespace behaviac
{
	// Token: 0x02002BC1 RID: 11201
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7 : Condition
	{
		// Token: 0x06014086 RID: 82054 RVA: 0x0060439F File Offset: 0x0060279F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7()
		{
			this.opl_p0 = 21635;
		}

		// Token: 0x06014087 RID: 82055 RVA: 0x006043B4 File Offset: 0x006027B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA77 RID: 55927
		private int opl_p0;
	}
}
