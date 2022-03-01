using System;

namespace behaviac
{
	// Token: 0x02003679 RID: 13945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node19 : Condition
	{
		// Token: 0x06015513 RID: 87315 RVA: 0x0066DB87 File Offset: 0x0066BF87
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_yongshi_node19()
		{
			this.opl_p0 = 5426;
		}

		// Token: 0x06015514 RID: 87316 RVA: 0x0066DB9C File Offset: 0x0066BF9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EECA RID: 61130
		private int opl_p0;
	}
}
