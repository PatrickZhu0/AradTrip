using System;

namespace behaviac
{
	// Token: 0x0200360E RID: 13838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node41 : Condition
	{
		// Token: 0x06015442 RID: 87106 RVA: 0x00668DA7 File Offset: 0x006671A7
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node41()
		{
			this.opl_p0 = 5439;
		}

		// Token: 0x06015443 RID: 87107 RVA: 0x00668DBC File Offset: 0x006671BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDFE RID: 60926
		private int opl_p0;
	}
}
