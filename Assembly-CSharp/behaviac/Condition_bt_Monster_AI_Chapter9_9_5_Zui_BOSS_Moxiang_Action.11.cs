using System;

namespace behaviac
{
	// Token: 0x020031A8 RID: 12712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node17 : Condition
	{
		// Token: 0x06014BE3 RID: 84963 RVA: 0x0063F323 File Offset: 0x0063D723
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node17()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06014BE4 RID: 84964 RVA: 0x0063F338 File Offset: 0x0063D738
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E54D RID: 58701
		private float opl_p0;
	}
}
