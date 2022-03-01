using System;

namespace behaviac
{
	// Token: 0x02003E0F RID: 15887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node4 : Condition
	{
		// Token: 0x060163A7 RID: 91047 RVA: 0x006B8473 File Offset: 0x006B6873
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node4()
		{
			this.opl_p0 = 5199;
		}

		// Token: 0x060163A8 RID: 91048 RVA: 0x006B8488 File Offset: 0x006B6888
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC0E RID: 64526
		private int opl_p0;
	}
}
