using System;

namespace behaviac
{
	// Token: 0x0200311C RID: 12572
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node3 : Condition
	{
		// Token: 0x06014ADF RID: 84703 RVA: 0x0063A3FB File Offset: 0x006387FB
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Event_node3()
		{
			this.opl_p0 = 20719;
		}

		// Token: 0x06014AE0 RID: 84704 RVA: 0x0063A410 File Offset: 0x00638810
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E44C RID: 58444
		private int opl_p0;
	}
}
