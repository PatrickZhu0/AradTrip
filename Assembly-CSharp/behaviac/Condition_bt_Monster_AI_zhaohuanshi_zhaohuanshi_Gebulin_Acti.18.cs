using System;

namespace behaviac
{
	// Token: 0x02003FA3 RID: 16291
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node32 : Condition
	{
		// Token: 0x060166B0 RID: 91824 RVA: 0x006C7FDD File Offset: 0x006C63DD
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node32()
		{
			this.opl_p0 = 5110;
		}

		// Token: 0x060166B1 RID: 91825 RVA: 0x006C7FF0 File Offset: 0x006C63F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF04 RID: 65284
		private int opl_p0;
	}
}
