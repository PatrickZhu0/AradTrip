using System;

namespace behaviac
{
	// Token: 0x020032E5 RID: 13029
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node7 : Condition
	{
		// Token: 0x06014E38 RID: 85560 RVA: 0x0064B106 File Offset: 0x00649506
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521416;
		}

		// Token: 0x06014E39 RID: 85561 RVA: 0x0064B128 File Offset: 0x00649528
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E71A RID: 59162
		private BE_Target opl_p0;

		// Token: 0x0400E71B RID: 59163
		private BE_Equal opl_p1;

		// Token: 0x0400E71C RID: 59164
		private int opl_p2;
	}
}
