using System;

namespace behaviac
{
	// Token: 0x02003E0A RID: 15882
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node7 : Condition
	{
		// Token: 0x0601639D RID: 91037 RVA: 0x006B8279 File Offset: 0x006B6679
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node7()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x0601639E RID: 91038 RVA: 0x006B828C File Offset: 0x006B668C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC05 RID: 64517
		private float opl_p0;
	}
}
