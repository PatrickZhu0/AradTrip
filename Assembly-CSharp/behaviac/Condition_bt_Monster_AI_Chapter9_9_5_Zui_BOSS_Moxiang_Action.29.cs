using System;

namespace behaviac
{
	// Token: 0x020031C2 RID: 12738
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node52 : Condition
	{
		// Token: 0x06014C17 RID: 85015 RVA: 0x0063FDC3 File Offset: 0x0063E1C3
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node52()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014C18 RID: 85016 RVA: 0x0063FDD8 File Offset: 0x0063E1D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E573 RID: 58739
		private float opl_p0;
	}
}
