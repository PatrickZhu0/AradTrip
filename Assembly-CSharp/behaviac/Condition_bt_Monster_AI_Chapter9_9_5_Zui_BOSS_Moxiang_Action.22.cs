using System;

namespace behaviac
{
	// Token: 0x020031B8 RID: 12728
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node40 : Condition
	{
		// Token: 0x06014C03 RID: 84995 RVA: 0x0063F9AE File Offset: 0x0063DDAE
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node40()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014C04 RID: 84996 RVA: 0x0063F9C4 File Offset: 0x0063DDC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E564 RID: 58724
		private float opl_p0;
	}
}
