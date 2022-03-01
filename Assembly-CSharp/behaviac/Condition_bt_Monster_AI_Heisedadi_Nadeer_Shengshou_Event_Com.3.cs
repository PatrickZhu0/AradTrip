using System;

namespace behaviac
{
	// Token: 0x02003548 RID: 13640
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node8 : Condition
	{
		// Token: 0x060152D1 RID: 86737 RVA: 0x00661D8E File Offset: 0x0066018E
		public Condition_bt_Monster_AI_Heisedadi_Nadeer_Shengshou_Event_Common_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521770;
		}

		// Token: 0x060152D2 RID: 86738 RVA: 0x00661DB0 File Offset: 0x006601B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC86 RID: 60550
		private BE_Target opl_p0;

		// Token: 0x0400EC87 RID: 60551
		private BE_Equal opl_p1;

		// Token: 0x0400EC88 RID: 60552
		private int opl_p2;
	}
}
