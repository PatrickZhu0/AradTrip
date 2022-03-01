using System;

namespace behaviac
{
	// Token: 0x020030FF RID: 12543
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node3 : Condition
	{
		// Token: 0x06014AAB RID: 84651 RVA: 0x0063935A File Offset: 0x0063775A
		public Condition_bt_Monster_AI_Chapter10_Gangban_Heng_Event_node3()
		{
			this.opl_p0 = 20722;
		}

		// Token: 0x06014AAC RID: 84652 RVA: 0x00639370 File Offset: 0x00637770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E420 RID: 58400
		private int opl_p0;
	}
}
