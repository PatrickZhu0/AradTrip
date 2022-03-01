using System;

namespace behaviac
{
	// Token: 0x020033EF RID: 13295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node3 : Condition
	{
		// Token: 0x06015031 RID: 86065 RVA: 0x00654BF4 File Offset: 0x00652FF4
		public Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node3()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521727;
		}

		// Token: 0x06015032 RID: 86066 RVA: 0x00654C18 File Offset: 0x00653018
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E91D RID: 59677
		private BE_Target opl_p0;

		// Token: 0x0400E91E RID: 59678
		private BE_Equal opl_p1;

		// Token: 0x0400E91F RID: 59679
		private int opl_p2;
	}
}
