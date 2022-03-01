using System;

namespace behaviac
{
	// Token: 0x02002E8F RID: 11919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node64 : Condition
	{
		// Token: 0x060145F9 RID: 83449 RVA: 0x00620A5E File Offset: 0x0061EE5E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node64()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570305;
		}

		// Token: 0x060145FA RID: 83450 RVA: 0x00620A80 File Offset: 0x0061EE80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF7C RID: 57212
		private BE_Target opl_p0;

		// Token: 0x0400DF7D RID: 57213
		private BE_Equal opl_p1;

		// Token: 0x0400DF7E RID: 57214
		private int opl_p2;
	}
}
