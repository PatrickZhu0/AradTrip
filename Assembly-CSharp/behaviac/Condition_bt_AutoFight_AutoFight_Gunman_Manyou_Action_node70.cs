using System;

namespace behaviac
{
	// Token: 0x0200261D RID: 9757
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node70 : Condition
	{
		// Token: 0x06013580 RID: 79232 RVA: 0x005C1206 File Offset: 0x005BF606
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node70()
		{
			this.opl_p0 = 0.28f;
		}

		// Token: 0x06013581 RID: 79233 RVA: 0x005C121C File Offset: 0x005BF61C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFCA RID: 53194
		private float opl_p0;
	}
}
