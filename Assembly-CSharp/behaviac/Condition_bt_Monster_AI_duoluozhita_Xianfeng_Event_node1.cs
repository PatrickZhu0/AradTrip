using System;

namespace behaviac
{
	// Token: 0x0200329C RID: 12956
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node1 : Condition
	{
		// Token: 0x06014DB0 RID: 85424 RVA: 0x0064849E File Offset: 0x0064689E
		public Condition_bt_Monster_AI_duoluozhita_Xianfeng_Event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.45f;
		}

		// Token: 0x06014DB1 RID: 85425 RVA: 0x006484C0 File Offset: 0x006468C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6A2 RID: 59042
		private HMType opl_p0;

		// Token: 0x0400E6A3 RID: 59043
		private BE_Operation opl_p1;

		// Token: 0x0400E6A4 RID: 59044
		private float opl_p2;
	}
}
