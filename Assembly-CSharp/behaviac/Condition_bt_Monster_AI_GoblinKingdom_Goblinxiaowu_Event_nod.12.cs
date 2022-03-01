using System;

namespace behaviac
{
	// Token: 0x020032F1 RID: 13041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node44 : Condition
	{
		// Token: 0x06014E4E RID: 85582 RVA: 0x0064B47D File Offset: 0x0064987D
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node44()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014E4F RID: 85583 RVA: 0x0064B490 File Offset: 0x00649890
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E738 RID: 59192
		private float opl_p0;
	}
}
