using System;

namespace behaviac
{
	// Token: 0x020024DA RID: 9434
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node22 : Condition
	{
		// Token: 0x060132FE RID: 78590 RVA: 0x005B26A9 File Offset: 0x005B0AA9
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node22()
		{
			this.opl_p0 = 2517;
		}

		// Token: 0x060132FF RID: 78591 RVA: 0x005B26BC File Offset: 0x005B0ABC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD1C RID: 52508
		private int opl_p0;
	}
}
