using System;

namespace behaviac
{
	// Token: 0x0200318E RID: 12686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node47 : Condition
	{
		// Token: 0x06014BB3 RID: 84915 RVA: 0x0063DD19 File Offset: 0x0063C119
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node47()
		{
			this.opl_p0 = 21540;
		}

		// Token: 0x06014BB4 RID: 84916 RVA: 0x0063DD2C File Offset: 0x0063C12C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E522 RID: 58658
		private int opl_p0;
	}
}
