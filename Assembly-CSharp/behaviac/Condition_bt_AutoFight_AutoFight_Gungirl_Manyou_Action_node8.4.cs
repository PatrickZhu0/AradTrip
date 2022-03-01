using System;

namespace behaviac
{
	// Token: 0x020024F3 RID: 9459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node81 : Condition
	{
		// Token: 0x06013330 RID: 78640 RVA: 0x005B3379 File Offset: 0x005B1779
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node81()
		{
			this.opl_p0 = 2513;
		}

		// Token: 0x06013331 RID: 78641 RVA: 0x005B338C File Offset: 0x005B178C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD51 RID: 52561
		private int opl_p0;
	}
}
