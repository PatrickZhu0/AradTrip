using System;

namespace behaviac
{
	// Token: 0x0200336E RID: 13166
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node9 : Condition
	{
		// Token: 0x06014F3A RID: 85818 RVA: 0x006500ED File Offset: 0x0064E4ED
		public Condition_bt_Monster_AI_GoblinKingdom_Goblin_zibaohong_Event_node9()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014F3B RID: 85819 RVA: 0x00650100 File Offset: 0x0064E500
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E801 RID: 59393
		private float opl_p0;
	}
}
