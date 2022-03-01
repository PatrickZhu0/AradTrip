using System;

namespace behaviac
{
	// Token: 0x020033FA RID: 13306
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3 : Condition
	{
		// Token: 0x06015046 RID: 86086 RVA: 0x0065520D File Offset: 0x0065360D
		public Condition_bt_Monster_AI_Heisedadi_Emo_Destiation_node3()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521727;
		}

		// Token: 0x06015047 RID: 86087 RVA: 0x00655230 File Offset: 0x00653630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E92B RID: 59691
		private BE_Target opl_p0;

		// Token: 0x0400E92C RID: 59692
		private BE_Equal opl_p1;

		// Token: 0x0400E92D RID: 59693
		private int opl_p2;
	}
}
