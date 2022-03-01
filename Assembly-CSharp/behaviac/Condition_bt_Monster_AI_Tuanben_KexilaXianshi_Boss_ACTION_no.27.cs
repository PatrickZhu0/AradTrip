using System;

namespace behaviac
{
	// Token: 0x02003A59 RID: 14937
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node21 : Condition
	{
		// Token: 0x06015C7B RID: 89211 RVA: 0x00693ED2 File Offset: 0x006922D2
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node21()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570034;
		}

		// Token: 0x06015C7C RID: 89212 RVA: 0x00693EF4 File Offset: 0x006922F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5A6 RID: 62886
		private BE_Target opl_p0;

		// Token: 0x0400F5A7 RID: 62887
		private BE_Equal opl_p1;

		// Token: 0x0400F5A8 RID: 62888
		private int opl_p2;
	}
}
