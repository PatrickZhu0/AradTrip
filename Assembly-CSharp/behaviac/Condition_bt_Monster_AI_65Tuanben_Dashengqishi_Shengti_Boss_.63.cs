using System;

namespace behaviac
{
	// Token: 0x02002E3C RID: 11836
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node143 : Condition
	{
		// Token: 0x06014555 RID: 83285 RVA: 0x0061AB8A File Offset: 0x00618F8A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node143()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 2229;
		}

		// Token: 0x06014556 RID: 83286 RVA: 0x0061ABAC File Offset: 0x00618FAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasMechanism(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEEB RID: 57067
		private BE_Target opl_p0;

		// Token: 0x0400DEEC RID: 57068
		private BE_Equal opl_p1;

		// Token: 0x0400DEED RID: 57069
		private int opl_p2;
	}
}
