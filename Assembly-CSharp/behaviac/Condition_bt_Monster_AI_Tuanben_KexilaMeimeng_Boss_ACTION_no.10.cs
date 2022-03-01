using System;

namespace behaviac
{
	// Token: 0x02003A27 RID: 14887
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node19 : Condition
	{
		// Token: 0x06015C18 RID: 89112 RVA: 0x006921E9 File Offset: 0x006905E9
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node19()
		{
			this.opl_p0 = 21068;
		}

		// Token: 0x06015C19 RID: 89113 RVA: 0x006921FC File Offset: 0x006905FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F532 RID: 62770
		private int opl_p0;
	}
}
