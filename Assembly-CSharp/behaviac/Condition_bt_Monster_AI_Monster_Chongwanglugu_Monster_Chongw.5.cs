using System;

namespace behaviac
{
	// Token: 0x020035F7 RID: 13815
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18 : Condition
	{
		// Token: 0x06015414 RID: 87060 RVA: 0x006683E9 File Offset: 0x006667E9
		public Condition_bt_Monster_AI_Monster_Chongwanglugu_Monster_Chongwanglugu_Action_node18()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x06015415 RID: 87061 RVA: 0x006683FC File Offset: 0x006667FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EDCE RID: 60878
		private float opl_p0;
	}
}
