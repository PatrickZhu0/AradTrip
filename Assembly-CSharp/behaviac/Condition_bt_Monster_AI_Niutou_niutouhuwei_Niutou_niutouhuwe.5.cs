using System;

namespace behaviac
{
	// Token: 0x0200370F RID: 14095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node8 : Condition
	{
		// Token: 0x0601562C RID: 87596 RVA: 0x00673BB2 File Offset: 0x00671FB2
		public Condition_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x0601562D RID: 87597 RVA: 0x00673BD0 File Offset: 0x00671FD0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFF5 RID: 61429
		private BE_Target opl_p0;

		// Token: 0x0400EFF6 RID: 61430
		private BE_Equal opl_p1;

		// Token: 0x0400EFF7 RID: 61431
		private BE_State opl_p2;
	}
}
