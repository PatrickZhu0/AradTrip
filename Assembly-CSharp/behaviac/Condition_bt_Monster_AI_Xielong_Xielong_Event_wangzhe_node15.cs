using System;

namespace behaviac
{
	// Token: 0x02003E5A RID: 15962
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node15 : Condition
	{
		// Token: 0x06016438 RID: 91192 RVA: 0x006BB2F3 File Offset: 0x006B96F3
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_wangzhe_node15()
		{
			this.opl_p0 = 7228;
		}

		// Token: 0x06016439 RID: 91193 RVA: 0x006BB308 File Offset: 0x006B9708
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC83 RID: 64643
		private int opl_p0;
	}
}
