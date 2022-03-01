using System;

namespace behaviac
{
	// Token: 0x02003A19 RID: 14873
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node46 : Condition
	{
		// Token: 0x06015BFC RID: 89084 RVA: 0x00691C73 File Offset: 0x00690073
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node46()
		{
			this.opl_p0 = 21164;
		}

		// Token: 0x06015BFD RID: 89085 RVA: 0x00691C88 File Offset: 0x00690088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F514 RID: 62740
		private int opl_p0;
	}
}
