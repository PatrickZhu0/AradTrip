using System;

namespace behaviac
{
	// Token: 0x020035F8 RID: 13816
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19 : Condition
	{
		// Token: 0x06015416 RID: 87062 RVA: 0x0066842F File Offset: 0x0066682F
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node19()
		{
			this.opl_p0 = 5642;
		}

		// Token: 0x06015417 RID: 87063 RVA: 0x00668444 File Offset: 0x00666844
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDCF RID: 60879
		private int opl_p0;
	}
}
