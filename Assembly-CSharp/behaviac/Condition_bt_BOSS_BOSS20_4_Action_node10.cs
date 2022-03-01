using System;

namespace behaviac
{
	// Token: 0x020029EC RID: 10732
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node10 : Condition
	{
		// Token: 0x06013D0B RID: 81163 RVA: 0x005EE3FD File Offset: 0x005EC7FD
		public Condition_bt_BOSS_BOSS20_4_Action_node10()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x06013D0C RID: 81164 RVA: 0x005EE410 File Offset: 0x005EC810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D780 RID: 55168
		private float opl_p0;
	}
}
