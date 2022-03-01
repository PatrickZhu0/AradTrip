using System;

namespace behaviac
{
	// Token: 0x020031C1 RID: 12737
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node56 : Condition
	{
		// Token: 0x06014C15 RID: 85013 RVA: 0x0063FD62 File Offset: 0x0063E162
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Action_node56()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570273;
		}

		// Token: 0x06014C16 RID: 85014 RVA: 0x0063FD84 File Offset: 0x0063E184
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E570 RID: 58736
		private BE_Target opl_p0;

		// Token: 0x0400E571 RID: 58737
		private BE_Equal opl_p1;

		// Token: 0x0400E572 RID: 58738
		private int opl_p2;
	}
}
