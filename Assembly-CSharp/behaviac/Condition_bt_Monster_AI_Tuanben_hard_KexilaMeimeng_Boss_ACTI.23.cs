using System;

namespace behaviac
{
	// Token: 0x02003C28 RID: 15400
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node1 : Condition
	{
		// Token: 0x06015FFB RID: 90107 RVA: 0x006A55E1 File Offset: 0x006A39E1
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node1()
		{
			this.opl_p0 = 21064;
		}

		// Token: 0x06015FFC RID: 90108 RVA: 0x006A55F4 File Offset: 0x006A39F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F87A RID: 63610
		private int opl_p0;
	}
}
