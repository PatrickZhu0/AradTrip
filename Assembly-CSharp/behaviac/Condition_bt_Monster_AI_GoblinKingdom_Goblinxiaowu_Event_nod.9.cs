using System;

namespace behaviac
{
	// Token: 0x020032EA RID: 13034
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node33 : Condition
	{
		// Token: 0x06014E41 RID: 85569 RVA: 0x0064B26B File Offset: 0x0064966B
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node33()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06014E42 RID: 85570 RVA: 0x0064B280 File Offset: 0x00649680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E726 RID: 59174
		private float opl_p0;
	}
}
