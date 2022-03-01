using System;

namespace behaviac
{
	// Token: 0x020031B1 RID: 12721
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node38 : Condition
	{
		// Token: 0x06014BF5 RID: 84981 RVA: 0x0063F6D6 File Offset: 0x0063DAD6
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node38()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014BF6 RID: 84982 RVA: 0x0063F6EC File Offset: 0x0063DAEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E559 RID: 58713
		private float opl_p0;
	}
}
