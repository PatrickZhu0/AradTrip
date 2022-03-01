using System;

namespace behaviac
{
	// Token: 0x0200371C RID: 14108
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node8 : Condition
	{
		// Token: 0x06015645 RID: 87621 RVA: 0x006743AA File Offset: 0x006727AA
		public Condition_bt_Monster_AI_Niutou_sawuta_Niutou_sawuta_Event_Hundun_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x06015646 RID: 87622 RVA: 0x006743C8 File Offset: 0x006727C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F011 RID: 61457
		private BE_Target opl_p0;

		// Token: 0x0400F012 RID: 61458
		private BE_Equal opl_p1;

		// Token: 0x0400F013 RID: 61459
		private BE_State opl_p2;
	}
}
