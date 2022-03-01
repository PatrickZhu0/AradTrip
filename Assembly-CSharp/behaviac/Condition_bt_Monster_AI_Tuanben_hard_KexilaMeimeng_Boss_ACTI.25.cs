using System;

namespace behaviac
{
	// Token: 0x02003C2C RID: 15404
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node11 : Condition
	{
		// Token: 0x06016003 RID: 90115 RVA: 0x006A5761 File Offset: 0x006A3B61
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node11()
		{
			this.opl_p0 = 21065;
		}

		// Token: 0x06016004 RID: 90116 RVA: 0x006A5774 File Offset: 0x006A3B74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F881 RID: 63617
		private int opl_p0;
	}
}
