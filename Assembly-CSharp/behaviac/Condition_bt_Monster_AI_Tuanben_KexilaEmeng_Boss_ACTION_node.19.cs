using System;

namespace behaviac
{
	// Token: 0x020039EB RID: 14827
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node11 : Condition
	{
		// Token: 0x06015BA6 RID: 88998 RVA: 0x0068FB42 File Offset: 0x0068DF42
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_ACTION_node11()
		{
			this.opl_p0 = 21056;
		}

		// Token: 0x06015BA7 RID: 88999 RVA: 0x0068FB58 File Offset: 0x0068DF58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4E5 RID: 62693
		private int opl_p0;
	}
}
