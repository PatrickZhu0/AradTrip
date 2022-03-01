using System;

namespace behaviac
{
	// Token: 0x020035A7 RID: 13735
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node11 : Condition
	{
		// Token: 0x0601537D RID: 86909 RVA: 0x0066522E File Offset: 0x0066362E
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node11()
		{
			this.opl_p0 = EventType.OnBackHit;
		}

		// Token: 0x0601537E RID: 86910 RVA: 0x00665240 File Offset: 0x00663640
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED48 RID: 60744
		private EventType opl_p0;
	}
}
