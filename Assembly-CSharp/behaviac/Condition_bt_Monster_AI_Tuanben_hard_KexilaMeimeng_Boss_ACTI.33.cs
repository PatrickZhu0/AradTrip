using System;

namespace behaviac
{
	// Token: 0x02003C38 RID: 15416
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node30 : Condition
	{
		// Token: 0x0601601A RID: 90138 RVA: 0x006A681B File Offset: 0x006A4C1B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node30()
		{
			this.opl_p0 = 21474;
		}

		// Token: 0x0601601B RID: 90139 RVA: 0x006A6830 File Offset: 0x006A4C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F893 RID: 63635
		private int opl_p0;
	}
}
