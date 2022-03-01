using System;

namespace behaviac
{
	// Token: 0x02003598 RID: 13720
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node9 : Condition
	{
		// Token: 0x06015360 RID: 86880 RVA: 0x0066499E File Offset: 0x00662D9E
		public Condition_bt_Monster_AI_Longren_leihuanxiusi_Longren_leihuanxiusi_Event_leihuanxiusi_Hundun_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x06015361 RID: 86881 RVA: 0x006649BC File Offset: 0x00662DBC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED27 RID: 60711
		private BE_Target opl_p0;

		// Token: 0x0400ED28 RID: 60712
		private BE_Equal opl_p1;

		// Token: 0x0400ED29 RID: 60713
		private BE_State opl_p2;
	}
}
