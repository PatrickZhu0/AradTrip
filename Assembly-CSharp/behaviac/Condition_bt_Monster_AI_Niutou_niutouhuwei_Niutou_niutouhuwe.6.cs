using System;

namespace behaviac
{
	// Token: 0x02003711 RID: 14097
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node13 : Condition
	{
		// Token: 0x06015630 RID: 87600 RVA: 0x00673C4A File Offset: 0x0067204A
		public Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node13()
		{
			this.opl_p0 = EventType.OnBackHit;
		}

		// Token: 0x06015631 RID: 87601 RVA: 0x00673C5C File Offset: 0x0067205C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasReceiveEvent(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFFA RID: 61434
		private EventType opl_p0;
	}
}
