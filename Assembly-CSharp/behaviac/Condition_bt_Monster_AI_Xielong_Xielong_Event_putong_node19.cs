using System;

namespace behaviac
{
	// Token: 0x02003E3C RID: 15932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node19 : Condition
	{
		// Token: 0x060163FD RID: 91133 RVA: 0x006BA41F File Offset: 0x006B881F
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node19()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x060163FE RID: 91134 RVA: 0x006BA440 File Offset: 0x006B8840
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC59 RID: 64601
		private HMType opl_p0;

		// Token: 0x0400FC5A RID: 64602
		private BE_Operation opl_p1;

		// Token: 0x0400FC5B RID: 64603
		private float opl_p2;
	}
}
