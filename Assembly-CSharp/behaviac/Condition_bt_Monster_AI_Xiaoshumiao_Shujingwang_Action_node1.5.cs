using System;

namespace behaviac
{
	// Token: 0x02003E17 RID: 15895
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node13 : Condition
	{
		// Token: 0x060163B7 RID: 91063 RVA: 0x006B87F7 File Offset: 0x006B6BF7
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node13()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060163B8 RID: 91064 RVA: 0x006B880C File Offset: 0x006B6C0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC20 RID: 64544
		private float opl_p0;
	}
}
