using System;

namespace behaviac
{
	// Token: 0x02004048 RID: 16456
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node27 : Condition
	{
		// Token: 0x060167EF RID: 92143 RVA: 0x006CF005 File Offset: 0x006CD405
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node27()
		{
			this.opl_p0 = 5112;
		}

		// Token: 0x060167F0 RID: 92144 RVA: 0x006CF018 File Offset: 0x006CD418
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401003B RID: 65595
		private int opl_p0;
	}
}
