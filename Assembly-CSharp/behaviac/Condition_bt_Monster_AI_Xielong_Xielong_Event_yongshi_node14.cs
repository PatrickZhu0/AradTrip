using System;

namespace behaviac
{
	// Token: 0x02003E6B RID: 15979
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node14 : Condition
	{
		// Token: 0x06016459 RID: 91225 RVA: 0x006BBD3E File Offset: 0x006BA13E
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node14()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.LessThan;
			this.opl_p2 = 0.25f;
		}

		// Token: 0x0601645A RID: 91226 RVA: 0x006BBD60 File Offset: 0x006BA160
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC98 RID: 64664
		private HMType opl_p0;

		// Token: 0x0400FC99 RID: 64665
		private BE_Operation opl_p1;

		// Token: 0x0400FC9A RID: 64666
		private float opl_p2;
	}
}
