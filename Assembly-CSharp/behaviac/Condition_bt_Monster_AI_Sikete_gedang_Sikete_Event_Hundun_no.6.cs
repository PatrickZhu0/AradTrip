using System;

namespace behaviac
{
	// Token: 0x0200373C RID: 14140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node13 : Condition
	{
		// Token: 0x06015683 RID: 87683 RVA: 0x006755FA File Offset: 0x006739FA
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node13()
		{
			this.opl_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015684 RID: 87684 RVA: 0x0067560C File Offset: 0x00673A0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F053 RID: 61523
		private EventType opl_p0;
	}
}
