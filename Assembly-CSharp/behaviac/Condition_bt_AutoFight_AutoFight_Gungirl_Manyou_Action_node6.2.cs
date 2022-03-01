using System;

namespace behaviac
{
	// Token: 0x020024EC RID: 9452
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node61 : Condition
	{
		// Token: 0x06013322 RID: 78626 RVA: 0x005B3001 File Offset: 0x005B1401
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node61()
		{
			this.opl_p0 = 2508;
		}

		// Token: 0x06013323 RID: 78627 RVA: 0x005B3014 File Offset: 0x005B1414
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD42 RID: 52546
		private int opl_p0;
	}
}
