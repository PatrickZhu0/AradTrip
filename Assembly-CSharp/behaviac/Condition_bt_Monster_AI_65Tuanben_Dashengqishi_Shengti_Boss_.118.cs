using System;

namespace behaviac
{
	// Token: 0x02002E9C RID: 11932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node79 : Condition
	{
		// Token: 0x06014613 RID: 83475 RVA: 0x00620DBA File Offset: 0x0061F1BA
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node79()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 2229;
		}

		// Token: 0x06014614 RID: 83476 RVA: 0x00620DDC File Offset: 0x0061F1DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasMechanism(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF8E RID: 57230
		private BE_Target opl_p0;

		// Token: 0x0400DF8F RID: 57231
		private BE_Equal opl_p1;

		// Token: 0x0400DF90 RID: 57232
		private int opl_p2;
	}
}
