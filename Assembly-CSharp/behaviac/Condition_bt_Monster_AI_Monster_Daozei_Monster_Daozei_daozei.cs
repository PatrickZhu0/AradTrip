using System;

namespace behaviac
{
	// Token: 0x02003680 RID: 13952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node1 : Condition
	{
		// Token: 0x06015520 RID: 87328 RVA: 0x0066E5C2 File Offset: 0x0066C9C2
		public Condition_bt_Monster_AI_Monster_Daozei_Monster_Daozei_daozei_fengkuangdaofei_event_node1()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThanOrEqualTo;
			this.opl_p2 = 0.3f;
		}

		// Token: 0x06015521 RID: 87329 RVA: 0x0066E5E4 File Offset: 0x0066C9E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EED5 RID: 61141
		private HMType opl_p0;

		// Token: 0x0400EED6 RID: 61142
		private BE_Operation opl_p1;

		// Token: 0x0400EED7 RID: 61143
		private float opl_p2;
	}
}
