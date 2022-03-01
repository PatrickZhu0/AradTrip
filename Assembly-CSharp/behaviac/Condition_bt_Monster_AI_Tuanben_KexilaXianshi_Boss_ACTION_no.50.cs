using System;

namespace behaviac
{
	// Token: 0x02003A77 RID: 14967
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node71 : Condition
	{
		// Token: 0x06015CB7 RID: 89271 RVA: 0x00694C41 File Offset: 0x00693041
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node71()
		{
			this.opl_p0 = 21054;
		}

		// Token: 0x06015CB8 RID: 89272 RVA: 0x00694C54 File Offset: 0x00693054
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5F3 RID: 62963
		private int opl_p0;
	}
}
