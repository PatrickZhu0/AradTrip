using System;

namespace behaviac
{
	// Token: 0x02003FA7 RID: 16295
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node37 : Condition
	{
		// Token: 0x060166B8 RID: 91832 RVA: 0x006C8191 File Offset: 0x006C6591
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node37()
		{
			this.opl_p0 = 5111;
		}

		// Token: 0x060166B9 RID: 91833 RVA: 0x006C81A4 File Offset: 0x006C65A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF0C RID: 65292
		private int opl_p0;
	}
}
