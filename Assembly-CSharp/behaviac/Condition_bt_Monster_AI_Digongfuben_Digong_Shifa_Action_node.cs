using System;

namespace behaviac
{
	// Token: 0x0200324C RID: 12876
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4 : Condition
	{
		// Token: 0x06014D18 RID: 85272 RVA: 0x00645B22 File Offset: 0x00643F22
		public Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4()
		{
			this.opl_p0 = 21503;
		}

		// Token: 0x06014D19 RID: 85273 RVA: 0x00645B38 File Offset: 0x00643F38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E667 RID: 58983
		private int opl_p0;
	}
}
