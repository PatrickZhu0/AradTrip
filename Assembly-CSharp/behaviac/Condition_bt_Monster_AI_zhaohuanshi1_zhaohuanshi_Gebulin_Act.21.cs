using System;

namespace behaviac
{
	// Token: 0x02004050 RID: 16464
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node37 : Condition
	{
		// Token: 0x060167FF RID: 92159 RVA: 0x006CF36D File Offset: 0x006CD76D
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node37()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x06016800 RID: 92160 RVA: 0x006CF380 File Offset: 0x006CD780
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401004B RID: 65611
		private int opl_p0;
	}
}
