using System;

namespace behaviac
{
	// Token: 0x02003461 RID: 13409
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node39 : Condition
	{
		// Token: 0x0601510E RID: 86286 RVA: 0x006589A4 File Offset: 0x00656DA4
		public Condition_bt_Monster_AI_Heisedadi_Hundun_Event_node39()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521890;
		}

		// Token: 0x0601510F RID: 86287 RVA: 0x006589C8 File Offset: 0x00656DC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA09 RID: 59913
		private BE_Target opl_p0;

		// Token: 0x0400EA0A RID: 59914
		private BE_Equal opl_p1;

		// Token: 0x0400EA0B RID: 59915
		private int opl_p2;
	}
}
