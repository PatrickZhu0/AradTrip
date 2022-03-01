using System;

namespace behaviac
{
	// Token: 0x0200358D RID: 13709
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node4 : Condition
	{
		// Token: 0x0601534B RID: 86859 RVA: 0x00664417 File Offset: 0x00662817
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_Event_node4()
		{
			this.opl_p0 = 0.02f;
		}

		// Token: 0x0601534C RID: 86860 RVA: 0x0066442C File Offset: 0x0066282C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED0D RID: 60685
		private float opl_p0;
	}
}
