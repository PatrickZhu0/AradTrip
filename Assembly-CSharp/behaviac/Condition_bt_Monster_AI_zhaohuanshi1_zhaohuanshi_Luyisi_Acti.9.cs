using System;

namespace behaviac
{
	// Token: 0x02004080 RID: 16512
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node19 : Condition
	{
		// Token: 0x0601685D RID: 92253 RVA: 0x006D1959 File Offset: 0x006CFD59
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node19()
		{
			this.opl_p0 = 5353;
		}

		// Token: 0x0601685E RID: 92254 RVA: 0x006D196C File Offset: 0x006CFD6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100A8 RID: 65704
		private int opl_p0;
	}
}
