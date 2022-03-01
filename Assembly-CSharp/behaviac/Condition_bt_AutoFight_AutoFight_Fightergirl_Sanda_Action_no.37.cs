using System;

namespace behaviac
{
	// Token: 0x02001F54 RID: 8020
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node32 : Condition
	{
		// Token: 0x0601284B RID: 75851 RVA: 0x0056B43F File Offset: 0x0056983F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_Sanda_Action_node32()
		{
			this.opl_p0 = 3008;
		}

		// Token: 0x0601284C RID: 75852 RVA: 0x0056B454 File Offset: 0x00569854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C244 RID: 49732
		private int opl_p0;
	}
}
