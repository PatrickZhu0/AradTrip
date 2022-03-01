using System;

namespace behaviac
{
	// Token: 0x020026EC RID: 9964
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node18 : Condition
	{
		// Token: 0x0601371B RID: 79643 RVA: 0x005C9F87 File Offset: 0x005C8387
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node18()
		{
			this.opl_p0 = 2005;
		}

		// Token: 0x0601371C RID: 79644 RVA: 0x005C9F9C File Offset: 0x005C839C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D172 RID: 53618
		private int opl_p0;
	}
}
