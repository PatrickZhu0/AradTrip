using System;

namespace behaviac
{
	// Token: 0x0200371E RID: 14110
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node13 : Condition
	{
		// Token: 0x06015649 RID: 87625 RVA: 0x00674442 File Offset: 0x00672842
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node13()
		{
			this.opl_p0 = EventType.OnBackHit;
		}

		// Token: 0x0601564A RID: 87626 RVA: 0x00674454 File Offset: 0x00672854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F016 RID: 61462
		private EventType opl_p0;
	}
}
