using System;

namespace behaviac
{
	// Token: 0x0200358C RID: 13708
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node3 : Condition
	{
		// Token: 0x06015349 RID: 86857 RVA: 0x006643BB File Offset: 0x006627BB
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601534A RID: 86858 RVA: 0x006643D8 File Offset: 0x006627D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED0A RID: 60682
		private BE_Target opl_p0;

		// Token: 0x0400ED0B RID: 60683
		private BE_Equal opl_p1;

		// Token: 0x0400ED0C RID: 60684
		private BE_State opl_p2;
	}
}
