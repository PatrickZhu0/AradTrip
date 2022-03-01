using System;

namespace behaviac
{
	// Token: 0x02003600 RID: 13824
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24 : Condition
	{
		// Token: 0x06015426 RID: 87078 RVA: 0x00668797 File Offset: 0x00666B97
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node24()
		{
			this.opl_p0 = 5441;
		}

		// Token: 0x06015427 RID: 87079 RVA: 0x006687AC File Offset: 0x00666BAC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDDF RID: 60895
		private int opl_p0;
	}
}
