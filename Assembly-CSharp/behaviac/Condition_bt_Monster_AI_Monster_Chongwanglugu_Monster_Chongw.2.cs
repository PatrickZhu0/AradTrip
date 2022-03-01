using System;

namespace behaviac
{
	// Token: 0x020035F3 RID: 13811
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13 : Condition
	{
		// Token: 0x0601540C RID: 87052 RVA: 0x0066821B File Offset: 0x0066661B
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node13()
		{
			this.opl_p0 = 0.1f;
		}

		// Token: 0x0601540D RID: 87053 RVA: 0x00668230 File Offset: 0x00666630
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDC4 RID: 60868
		private float opl_p0;
	}
}
