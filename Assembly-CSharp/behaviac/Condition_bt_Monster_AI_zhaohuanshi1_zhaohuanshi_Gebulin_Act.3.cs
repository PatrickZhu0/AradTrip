using System;

namespace behaviac
{
	// Token: 0x02004038 RID: 16440
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node7 : Condition
	{
		// Token: 0x060167CF RID: 92111 RVA: 0x006CE935 File Offset: 0x006CCD35
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node7()
		{
			this.opl_p0 = 5109;
		}

		// Token: 0x060167D0 RID: 92112 RVA: 0x006CE948 File Offset: 0x006CCD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401001B RID: 65563
		private int opl_p0;
	}
}
