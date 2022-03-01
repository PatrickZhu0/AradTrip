using System;

namespace behaviac
{
	// Token: 0x02003E13 RID: 15891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node17 : Condition
	{
		// Token: 0x060163AF RID: 91055 RVA: 0x006B865D File Offset: 0x006B6A5D
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node17()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060163B0 RID: 91056 RVA: 0x006B8670 File Offset: 0x006B6A70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC19 RID: 64537
		private float opl_p0;
	}
}
