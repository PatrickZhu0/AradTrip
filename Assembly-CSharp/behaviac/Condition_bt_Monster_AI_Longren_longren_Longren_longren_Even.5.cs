using System;

namespace behaviac
{
	// Token: 0x020035A5 RID: 13733
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node9 : Condition
	{
		// Token: 0x06015379 RID: 86905 RVA: 0x00665196 File Offset: 0x00663596
		public Condition_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x0601537A RID: 86906 RVA: 0x006651B4 File Offset: 0x006635B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED43 RID: 60739
		private BE_Target opl_p0;

		// Token: 0x0400ED44 RID: 60740
		private BE_Equal opl_p1;

		// Token: 0x0400ED45 RID: 60741
		private BE_State opl_p2;
	}
}
