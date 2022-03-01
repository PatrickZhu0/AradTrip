using System;

namespace behaviac
{
	// Token: 0x020032C7 RID: 12999
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GHFB_haidaoyuren_node1 : Condition
	{
		// Token: 0x06014E00 RID: 85504 RVA: 0x00649ED1 File Offset: 0x006482D1
		public Condition_bt_Monster_AI_GHFB_haidaoyuren_node1()
		{
			this.opl_p0 = 20166;
		}

		// Token: 0x06014E01 RID: 85505 RVA: 0x00649EE4 File Offset: 0x006482E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6EA RID: 59114
		private int opl_p0;
	}
}
