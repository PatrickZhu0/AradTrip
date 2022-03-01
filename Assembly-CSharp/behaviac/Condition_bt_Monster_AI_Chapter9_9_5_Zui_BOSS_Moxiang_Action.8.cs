using System;

namespace behaviac
{
	// Token: 0x020031A4 RID: 12708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node28 : Condition
	{
		// Token: 0x06014BDB RID: 84955 RVA: 0x0063F186 File Offset: 0x0063D586
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014BDC RID: 84956 RVA: 0x0063F19C File Offset: 0x0063D59C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E546 RID: 58694
		private float opl_p0;
	}
}
