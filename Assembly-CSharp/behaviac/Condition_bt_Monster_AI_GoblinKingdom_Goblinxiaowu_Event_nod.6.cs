using System;

namespace behaviac
{
	// Token: 0x020032E4 RID: 13028
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node6 : Condition
	{
		// Token: 0x06014E36 RID: 85558 RVA: 0x0064B0A3 File Offset: 0x006494A3
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node6()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 29;
		}

		// Token: 0x06014E37 RID: 85559 RVA: 0x0064B0C4 File Offset: 0x006494C4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E717 RID: 59159
		private BE_Target opl_p0;

		// Token: 0x0400E718 RID: 59160
		private BE_Equal opl_p1;

		// Token: 0x0400E719 RID: 59161
		private int opl_p2;
	}
}
