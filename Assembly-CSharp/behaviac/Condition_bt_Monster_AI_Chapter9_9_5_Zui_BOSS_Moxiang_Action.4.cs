using System;

namespace behaviac
{
	// Token: 0x0200319E RID: 12702
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node10 : Condition
	{
		// Token: 0x06014BCF RID: 84943 RVA: 0x0063EF0E File Offset: 0x0063D30E
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node10()
		{
			this.opl_p0 = 0.45f;
		}

		// Token: 0x06014BD0 RID: 84944 RVA: 0x0063EF24 File Offset: 0x0063D324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E53E RID: 58686
		private float opl_p0;
	}
}
