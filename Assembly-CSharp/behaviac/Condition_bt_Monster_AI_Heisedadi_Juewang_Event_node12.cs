using System;

namespace behaviac
{
	// Token: 0x0200347D RID: 13437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node12 : Condition
	{
		// Token: 0x06015143 RID: 86339 RVA: 0x0065A0FA File Offset: 0x006584FA
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node12()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015144 RID: 86340 RVA: 0x0065A11C File Offset: 0x0065851C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA45 RID: 59973
		private BE_Target opl_p0;

		// Token: 0x0400EA46 RID: 59974
		private BE_Equal opl_p1;

		// Token: 0x0400EA47 RID: 59975
		private int opl_p2;
	}
}
