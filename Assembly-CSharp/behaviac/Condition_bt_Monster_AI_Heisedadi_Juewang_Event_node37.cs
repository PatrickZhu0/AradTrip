using System;

namespace behaviac
{
	// Token: 0x02003485 RID: 13445
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node37 : Condition
	{
		// Token: 0x06015153 RID: 86355 RVA: 0x0065A383 File Offset: 0x00658783
		public Condition_bt_Monster_AI_Heisedadi_Juewang_Event_node37()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 560001;
		}

		// Token: 0x06015154 RID: 86356 RVA: 0x0065A3A4 File Offset: 0x006587A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA52 RID: 59986
		private BE_Target opl_p0;

		// Token: 0x0400EA53 RID: 59987
		private BE_Equal opl_p1;

		// Token: 0x0400EA54 RID: 59988
		private int opl_p2;
	}
}
