using System;

namespace behaviac
{
	// Token: 0x020035FB RID: 13819
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node43 : Condition
	{
		// Token: 0x0601541C RID: 87068 RVA: 0x0066859D File Offset: 0x0066699D
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node43()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601541D RID: 87069 RVA: 0x006685B0 File Offset: 0x006669B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDD6 RID: 60886
		private float opl_p0;
	}
}
