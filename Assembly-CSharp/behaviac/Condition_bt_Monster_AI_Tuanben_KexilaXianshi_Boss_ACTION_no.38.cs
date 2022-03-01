using System;

namespace behaviac
{
	// Token: 0x02003A68 RID: 14952
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node40 : Condition
	{
		// Token: 0x06015C99 RID: 89241 RVA: 0x006945A3 File Offset: 0x006929A3
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node40()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C9A RID: 89242 RVA: 0x006945D8 File Offset: 0x006929D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5CB RID: 62923
		private int opl_p0;

		// Token: 0x0400F5CC RID: 62924
		private int opl_p1;

		// Token: 0x0400F5CD RID: 62925
		private int opl_p2;

		// Token: 0x0400F5CE RID: 62926
		private int opl_p3;
	}
}
