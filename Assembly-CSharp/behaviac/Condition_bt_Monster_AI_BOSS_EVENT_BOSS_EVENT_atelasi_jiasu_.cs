using System;

namespace behaviac
{
	// Token: 0x020030AC RID: 12460
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_atelasi_jiasu_event_node0 : Condition
	{
		// Token: 0x06014A1B RID: 84507 RVA: 0x006367AC File Offset: 0x00634BAC
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_atelasi_jiasu_event_node0()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.2f;
		}

		// Token: 0x06014A1C RID: 84508 RVA: 0x006367D0 File Offset: 0x00634BD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E378 RID: 58232
		private HMType opl_p0;

		// Token: 0x0400E379 RID: 58233
		private BE_Operation opl_p1;

		// Token: 0x0400E37A RID: 58234
		private float opl_p2;
	}
}
