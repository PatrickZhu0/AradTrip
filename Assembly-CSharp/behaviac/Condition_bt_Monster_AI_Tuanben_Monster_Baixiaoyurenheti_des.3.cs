using System;

namespace behaviac
{
	// Token: 0x02003AEF RID: 15087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node0 : Condition
	{
		// Token: 0x06015D9B RID: 89499 RVA: 0x0069A4FB File Offset: 0x006988FB
		public Condition_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node0()
		{
			this.opl_p0 = 21302;
		}

		// Token: 0x06015D9C RID: 89500 RVA: 0x0069A510 File Offset: 0x00698910
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A1 RID: 63137
		private int opl_p0;
	}
}
