using System;

namespace behaviac
{
	// Token: 0x02003C0A RID: 15370
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node98 : Condition
	{
		// Token: 0x06015FBF RID: 90047 RVA: 0x006A4A7B File Offset: 0x006A2E7B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node98()
		{
			this.opl_p0 = 21171;
		}

		// Token: 0x06015FC0 RID: 90048 RVA: 0x006A4A90 File Offset: 0x006A2E90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F840 RID: 63552
		private int opl_p0;
	}
}
