using System;

namespace behaviac
{
	// Token: 0x020031A1 RID: 12705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node24 : Condition
	{
		// Token: 0x06014BD5 RID: 84949 RVA: 0x0063F04A File Offset: 0x0063D44A
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node24()
		{
			this.opl_p0 = 0.73f;
		}

		// Token: 0x06014BD6 RID: 84950 RVA: 0x0063F060 File Offset: 0x0063D460
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E542 RID: 58690
		private float opl_p0;
	}
}
