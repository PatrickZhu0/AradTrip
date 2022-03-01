using System;

namespace behaviac
{
	// Token: 0x020030BE RID: 12478
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event1_node1 : Condition
	{
		// Token: 0x06014A39 RID: 84537 RVA: 0x006370B4 File Offset: 0x006354B4
		public Condition_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event1_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06014A3A RID: 84538 RVA: 0x006370D8 File Offset: 0x006354D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3A0 RID: 58272
		private HMType opl_p0;

		// Token: 0x0400E3A1 RID: 58273
		private BE_Operation opl_p1;

		// Token: 0x0400E3A2 RID: 58274
		private float opl_p2;
	}
}
