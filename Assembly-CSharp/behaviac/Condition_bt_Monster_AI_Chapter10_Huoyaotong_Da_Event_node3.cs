using System;

namespace behaviac
{
	// Token: 0x02003110 RID: 12560
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node3 : Condition
	{
		// Token: 0x06014ACA RID: 84682 RVA: 0x00639D0B File Offset: 0x0063810B
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Da_Event_node3()
		{
			this.opl_p0 = 20718;
		}

		// Token: 0x06014ACB RID: 84683 RVA: 0x00639D20 File Offset: 0x00638120
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E43A RID: 58426
		private int opl_p0;
	}
}
