using System;

namespace behaviac
{
	// Token: 0x02003E47 RID: 15943
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node14 : Condition
	{
		// Token: 0x06016413 RID: 91155 RVA: 0x006BA7E6 File Offset: 0x006B8BE6
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_putong_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x06016414 RID: 91156 RVA: 0x006BA808 File Offset: 0x006B8C08
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC68 RID: 64616
		private HMType opl_p0;

		// Token: 0x0400FC69 RID: 64617
		private BE_Operation opl_p1;

		// Token: 0x0400FC6A RID: 64618
		private float opl_p2;
	}
}
