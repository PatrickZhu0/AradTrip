using System;

namespace behaviac
{
	// Token: 0x02002EA2 RID: 11938
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node32 : Condition
	{
		// Token: 0x0601461F RID: 83487 RVA: 0x00620F38 File Offset: 0x0061F338
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node32()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 2229;
		}

		// Token: 0x06014620 RID: 83488 RVA: 0x00620F5C File Offset: 0x0061F35C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_HasMechanism(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF99 RID: 57241
		private BE_Target opl_p0;

		// Token: 0x0400DF9A RID: 57242
		private BE_Equal opl_p1;

		// Token: 0x0400DF9B RID: 57243
		private int opl_p2;
	}
}
