using System;

namespace behaviac
{
	// Token: 0x020033F1 RID: 13297
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node5 : Condition
	{
		// Token: 0x06015035 RID: 86069 RVA: 0x00654C81 File Offset: 0x00653081
		public Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node5()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521728;
		}

		// Token: 0x06015036 RID: 86070 RVA: 0x00654CA4 File Offset: 0x006530A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E921 RID: 59681
		private BE_Target opl_p0;

		// Token: 0x0400E922 RID: 59682
		private BE_Equal opl_p1;

		// Token: 0x0400E923 RID: 59683
		private int opl_p2;
	}
}
