using System;

namespace behaviac
{
	// Token: 0x02003F9B RID: 16283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node22 : Condition
	{
		// Token: 0x060166A0 RID: 91808 RVA: 0x006C7C75 File Offset: 0x006C6075
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node22()
		{
			this.opl_p0 = 5108;
		}

		// Token: 0x060166A1 RID: 91809 RVA: 0x006C7C88 File Offset: 0x006C6088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEF4 RID: 65268
		private int opl_p0;
	}
}
