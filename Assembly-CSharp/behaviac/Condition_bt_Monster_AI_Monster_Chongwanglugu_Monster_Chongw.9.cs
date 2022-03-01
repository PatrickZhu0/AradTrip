using System;

namespace behaviac
{
	// Token: 0x020035FC RID: 13820
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node44 : Condition
	{
		// Token: 0x0601541E RID: 87070 RVA: 0x006685E3 File Offset: 0x006669E3
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node44()
		{
			this.opl_p0 = 5443;
		}

		// Token: 0x0601541F RID: 87071 RVA: 0x006685F8 File Offset: 0x006669F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDD7 RID: 60887
		private int opl_p0;
	}
}
