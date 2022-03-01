using System;

namespace behaviac
{
	// Token: 0x02003B01 RID: 15105
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node0 : Condition
	{
		// Token: 0x06015DBD RID: 89533 RVA: 0x0069AF07 File Offset: 0x00699307
		public Condition_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node0()
		{
			this.opl_p0 = 21301;
		}

		// Token: 0x06015DBE RID: 89534 RVA: 0x0069AF1C File Offset: 0x0069931C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B6 RID: 63158
		private int opl_p0;
	}
}
