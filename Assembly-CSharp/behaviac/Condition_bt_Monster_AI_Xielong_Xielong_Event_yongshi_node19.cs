using System;

namespace behaviac
{
	// Token: 0x02003E60 RID: 15968
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node19 : Condition
	{
		// Token: 0x06016443 RID: 91203 RVA: 0x006BB977 File Offset: 0x006B9D77
		public Condition_bt_Monster_AI_Xielong_Xielong_Event_yongshi_node19()
		{
			this.opl_p0 = HMType.HP_PERCENT;
			this.opl_p1 = BE_Operation.GreaterThan;
			this.opl_p2 = 0.5f;
		}

		// Token: 0x06016444 RID: 91204 RVA: 0x006BB998 File Offset: 0x006B9D98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHPMP(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FC89 RID: 64649
		private HMType opl_p0;

		// Token: 0x0400FC8A RID: 64650
		private BE_Operation opl_p1;

		// Token: 0x0400FC8B RID: 64651
		private float opl_p2;
	}
}
