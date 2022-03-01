using System;

namespace behaviac
{
	// Token: 0x020030FE RID: 12542
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node5 : Condition
	{
		// Token: 0x06014AA9 RID: 84649 RVA: 0x0063930F File Offset: 0x0063770F
		public Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node5()
		{
			this.opl_p0 = 20722;
		}

		// Token: 0x06014AAA RID: 84650 RVA: 0x00639324 File Offset: 0x00637724
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckIsUsingSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E41F RID: 58399
		private int opl_p0;
	}
}
