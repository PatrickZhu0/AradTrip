using System;

namespace behaviac
{
	// Token: 0x020035EE RID: 13806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node5 : Condition
	{
		// Token: 0x06015403 RID: 87043 RVA: 0x00667F1B File Offset: 0x0066631B
		public Condition_bt_Monster_AI_Monster_Bantuzu_yetuaimuli_Monster_Bantuzu_yetuaimuli_Event_yetuaimuli_node5()
		{
			this.opl_p0 = 5379;
		}

		// Token: 0x06015404 RID: 87044 RVA: 0x00667F30 File Offset: 0x00666330
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDBF RID: 60863
		private int opl_p0;
	}
}
