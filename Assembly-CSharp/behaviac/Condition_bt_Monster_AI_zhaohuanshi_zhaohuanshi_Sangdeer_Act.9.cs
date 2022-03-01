using System;

namespace behaviac
{
	// Token: 0x02003FF4 RID: 16372
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node16 : Condition
	{
		// Token: 0x0601674E RID: 91982 RVA: 0x006CBAB1 File Offset: 0x006C9EB1
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Sangdeer_Action_node16()
		{
			this.opl_p0 = 5355;
		}

		// Token: 0x0601674F RID: 91983 RVA: 0x006CBAC4 File Offset: 0x006C9EC4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFA0 RID: 65440
		private int opl_p0;
	}
}
