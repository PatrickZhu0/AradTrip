using System;

namespace behaviac
{
	// Token: 0x020032E8 RID: 13032
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node22 : Condition
	{
		// Token: 0x06014E3D RID: 85565 RVA: 0x0064B1D9 File Offset: 0x006495D9
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node22()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x06014E3E RID: 85566 RVA: 0x0064B1EC File Offset: 0x006495EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E722 RID: 59170
		private float opl_p0;
	}
}
