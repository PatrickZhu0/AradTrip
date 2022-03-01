using System;

namespace behaviac
{
	// Token: 0x02003E0E RID: 15886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node3 : Condition
	{
		// Token: 0x060163A5 RID: 91045 RVA: 0x006B842D File Offset: 0x006B682D
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node3()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060163A6 RID: 91046 RVA: 0x006B8440 File Offset: 0x006B6840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC0D RID: 64525
		private float opl_p0;
	}
}
