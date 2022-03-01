using System;

namespace behaviac
{
	// Token: 0x02002E9F RID: 11935
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node41 : Condition
	{
		// Token: 0x06014619 RID: 83481 RVA: 0x00620E72 File Offset: 0x0061F272
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node41()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570309;
		}

		// Token: 0x0601461A RID: 83482 RVA: 0x00620E94 File Offset: 0x0061F294
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF93 RID: 57235
		private BE_Target opl_p0;

		// Token: 0x0400DF94 RID: 57236
		private BE_Equal opl_p1;

		// Token: 0x0400DF95 RID: 57237
		private int opl_p2;
	}
}
