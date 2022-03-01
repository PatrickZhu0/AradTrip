using System;

namespace behaviac
{
	// Token: 0x02003CF7 RID: 15607
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node12 : Condition
	{
		// Token: 0x0601618D RID: 90509 RVA: 0x006AE0B7 File Offset: 0x006AC4B7
		public Condition_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node12()
		{
			this.opl_p0 = 21406;
		}

		// Token: 0x0601618E RID: 90510 RVA: 0x006AE0CC File Offset: 0x006AC4CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA27 RID: 64039
		private int opl_p0;
	}
}
