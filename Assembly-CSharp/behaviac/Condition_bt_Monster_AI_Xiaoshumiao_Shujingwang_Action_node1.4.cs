using System;

namespace behaviac
{
	// Token: 0x02003E16 RID: 15894
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node12 : Condition
	{
		// Token: 0x060163B5 RID: 91061 RVA: 0x006B8796 File Offset: 0x006B6B96
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node12()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060163B6 RID: 91062 RVA: 0x006B87B8 File Offset: 0x006B6BB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC1D RID: 64541
		private HMType opl_p0;

		// Token: 0x0400FC1E RID: 64542
		private BE_Operation opl_p1;

		// Token: 0x0400FC1F RID: 64543
		private float opl_p2;
	}
}
