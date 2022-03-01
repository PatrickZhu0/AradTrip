using System;

namespace behaviac
{
	// Token: 0x02003C40 RID: 15424
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node19 : Condition
	{
		// Token: 0x0601602A RID: 90154 RVA: 0x006A6B6D File Offset: 0x006A4F6D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node19()
		{
			this.opl_p0 = 21068;
		}

		// Token: 0x0601602B RID: 90155 RVA: 0x006A6B80 File Offset: 0x006A4F80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8A3 RID: 63651
		private int opl_p0;
	}
}
