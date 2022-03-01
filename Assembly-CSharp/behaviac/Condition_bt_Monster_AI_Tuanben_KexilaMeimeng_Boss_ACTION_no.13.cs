using System;

namespace behaviac
{
	// Token: 0x02003A2B RID: 14891
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node16 : Condition
	{
		// Token: 0x06015C20 RID: 89120 RVA: 0x006923B9 File Offset: 0x006907B9
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node16()
		{
			this.opl_p0 = 21067;
		}

		// Token: 0x06015C21 RID: 89121 RVA: 0x006923CC File Offset: 0x006907CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F53C RID: 62780
		private int opl_p0;
	}
}
