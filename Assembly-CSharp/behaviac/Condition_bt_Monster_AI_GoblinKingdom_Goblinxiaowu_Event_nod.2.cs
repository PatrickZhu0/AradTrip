using System;

namespace behaviac
{
	// Token: 0x020032DB RID: 13019
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node3 : Condition
	{
		// Token: 0x06014E25 RID: 85541 RVA: 0x0064AE0F File Offset: 0x0064920F
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521416;
		}

		// Token: 0x06014E26 RID: 85542 RVA: 0x0064AE30 File Offset: 0x00649230
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E703 RID: 59139
		private BE_Target opl_p0;

		// Token: 0x0400E704 RID: 59140
		private BE_Equal opl_p1;

		// Token: 0x0400E705 RID: 59141
		private int opl_p2;
	}
}
