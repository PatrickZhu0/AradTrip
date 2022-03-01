using System;

namespace behaviac
{
	// Token: 0x02003582 RID: 13698
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node12 : Condition
	{
		// Token: 0x06015336 RID: 86838 RVA: 0x00663C9B File Offset: 0x0066209B
		public Condition_bt_Monster_AI_jinbiguanq_jinbiguanq_daobaogbl_DestinationSelect_node12()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06015337 RID: 86839 RVA: 0x00663CB0 File Offset: 0x006620B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECF8 RID: 60664
		private float opl_p0;
	}
}
