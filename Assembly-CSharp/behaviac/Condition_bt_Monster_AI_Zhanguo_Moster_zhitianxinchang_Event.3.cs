using System;

namespace behaviac
{
	// Token: 0x02003F05 RID: 16133
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node4 : Condition
	{
		// Token: 0x0601657F RID: 91519 RVA: 0x006C282F File Offset: 0x006C0C2F
		public Condition_bt_Monster_AI_Zhanguo_Moster_zhitianxinchang_Event_node4()
		{
			this.opl_p0 = 7384;
		}

		// Token: 0x06016580 RID: 91520 RVA: 0x006C2844 File Offset: 0x006C0C44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD98 RID: 64920
		private int opl_p0;
	}
}
