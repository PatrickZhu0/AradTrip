using System;

namespace behaviac
{
	// Token: 0x020032E2 RID: 13026
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node20 : Condition
	{
		// Token: 0x06014E32 RID: 85554 RVA: 0x0064B00F File Offset: 0x0064940F
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node20()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06014E33 RID: 85555 RVA: 0x0064B024 File Offset: 0x00649424
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E713 RID: 59155
		private float opl_p0;
	}
}
