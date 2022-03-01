using System;

namespace behaviac
{
	// Token: 0x02003785 RID: 14213
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node72 : Condition
	{
		// Token: 0x06015711 RID: 87825 RVA: 0x006777B7 File Offset: 0x00675BB7
		public Condition_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Action_node72()
		{
			this.opl_p0 = 21196;
		}

		// Token: 0x06015712 RID: 87826 RVA: 0x006777CC File Offset: 0x00675BCC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0CB RID: 61643
		private int opl_p0;
	}
}
