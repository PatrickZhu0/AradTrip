using System;

namespace behaviac
{
	// Token: 0x0200316D RID: 12653
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node35 : Condition
	{
		// Token: 0x06014B71 RID: 84849 RVA: 0x0063D1B2 File Offset: 0x0063B5B2
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node35()
		{
			this.opl_p0 = 21545;
		}

		// Token: 0x06014B72 RID: 84850 RVA: 0x0063D1C8 File Offset: 0x0063B5C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4EA RID: 58602
		private int opl_p0;
	}
}
