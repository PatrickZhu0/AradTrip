using System;

namespace behaviac
{
	// Token: 0x020032DE RID: 13022
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node27 : Condition
	{
		// Token: 0x06014E2A RID: 85546 RVA: 0x0064AEE8 File Offset: 0x006492E8
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node27()
		{
			this.opl_p0 = 0.01f;
		}

		// Token: 0x06014E2B RID: 85547 RVA: 0x0064AEFC File Offset: 0x006492FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E70B RID: 59147
		private float opl_p0;
	}
}
