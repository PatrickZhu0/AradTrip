using System;

namespace behaviac
{
	// Token: 0x02003E02 RID: 15874
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node12 : Condition
	{
		// Token: 0x0601638E RID: 91022 RVA: 0x006B7C5E File Offset: 0x006B605E
		public Condition_bt_Monster_AI_Weishi_Tianzhiquzhuzhe_Weishi_Tianzhiquzhuzhe_Event_Hundun_node12()
		{
			this.opl_p0 = EventType.OnBeforeHit;
		}

		// Token: 0x0601638F RID: 91023 RVA: 0x006B7C70 File Offset: 0x006B6070
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBF6 RID: 64502
		private EventType opl_p0;
	}
}
