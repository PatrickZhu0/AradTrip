using System;

namespace behaviac
{
	// Token: 0x02003CFA RID: 15610
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node0 : Condition
	{
		// Token: 0x06016193 RID: 90515 RVA: 0x006AE1E1 File Offset: 0x006AC5E1
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node0()
		{
			this.opl_p0 = 80680011;
			this.opl_p1 = 3;
		}

		// Token: 0x06016194 RID: 90516 RVA: 0x006AE1FC File Offset: 0x006AC5FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_JudgeMonsterCount(this.opl_p0, this.opl_p1);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA2C RID: 64044
		private int opl_p0;

		// Token: 0x0400FA2D RID: 64045
		private int opl_p1;
	}
}
