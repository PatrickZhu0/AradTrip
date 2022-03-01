using System;

namespace behaviac
{
	// Token: 0x02004058 RID: 16472
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node47 : Condition
	{
		// Token: 0x0601680F RID: 92175 RVA: 0x006CF6D5 File Offset: 0x006CDAD5
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node47()
		{
			this.opl_p0 = 5108;
		}

		// Token: 0x06016810 RID: 92176 RVA: 0x006CF6E8 File Offset: 0x006CDAE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401005B RID: 65627
		private int opl_p0;
	}
}
