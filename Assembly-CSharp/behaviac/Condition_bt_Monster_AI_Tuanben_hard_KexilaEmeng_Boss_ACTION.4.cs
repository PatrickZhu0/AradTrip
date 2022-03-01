using System;

namespace behaviac
{
	// Token: 0x02003B8F RID: 15247
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node46 : Condition
	{
		// Token: 0x06015ECE RID: 89806 RVA: 0x006A0101 File Offset: 0x0069E501
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node46()
		{
			this.opl_p0 = 21172;
		}

		// Token: 0x06015ECF RID: 89807 RVA: 0x006A0114 File Offset: 0x0069E514
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F788 RID: 63368
		private int opl_p0;
	}
}
