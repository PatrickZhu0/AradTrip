using System;

namespace behaviac
{
	// Token: 0x020030B2 RID: 12466
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node6 : Condition
	{
		// Token: 0x06014A25 RID: 84517 RVA: 0x006369B7 File Offset: 0x00634DB7
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node6()
		{
			this.opl_p0 = 0.05f;
		}

		// Token: 0x06014A26 RID: 84518 RVA: 0x006369CC File Offset: 0x00634DCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E382 RID: 58242
		private float opl_p0;
	}
}
