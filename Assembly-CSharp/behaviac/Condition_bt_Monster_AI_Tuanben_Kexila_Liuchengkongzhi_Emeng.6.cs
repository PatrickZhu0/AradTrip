using System;

namespace behaviac
{
	// Token: 0x02003AAD RID: 15021
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node12 : Condition
	{
		// Token: 0x06015D1C RID: 89372 RVA: 0x00697B27 File Offset: 0x00695F27
		public Condition_bt_Monster_AI_Tuanben_Kexila_Liuchengkongzhi_Emeng_node12()
		{
			this.opl_p0 = 21406;
		}

		// Token: 0x06015D1D RID: 89373 RVA: 0x00697B3C File Offset: 0x00695F3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F63C RID: 63036
		private int opl_p0;
	}
}
