using System;

namespace behaviac
{
	// Token: 0x020039E7 RID: 14823
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node35 : Condition
	{
		// Token: 0x06015B9E RID: 88990 RVA: 0x0068F95B File Offset: 0x0068DD5B
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node35()
		{
			this.opl_p0 = 21076;
		}

		// Token: 0x06015B9F RID: 88991 RVA: 0x0068F970 File Offset: 0x0068DD70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4DF RID: 62687
		private int opl_p0;
	}
}
