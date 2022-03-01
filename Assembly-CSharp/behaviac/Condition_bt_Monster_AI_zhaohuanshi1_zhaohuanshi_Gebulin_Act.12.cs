using System;

namespace behaviac
{
	// Token: 0x02004044 RID: 16452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node22 : Condition
	{
		// Token: 0x060167E7 RID: 92135 RVA: 0x006CEE51 File Offset: 0x006CD251
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node22()
		{
			this.opl_p0 = 5108;
		}

		// Token: 0x060167E8 RID: 92136 RVA: 0x006CEE64 File Offset: 0x006CD264
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010033 RID: 65587
		private int opl_p0;
	}
}
