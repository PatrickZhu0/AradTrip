using System;

namespace behaviac
{
	// Token: 0x020024D4 RID: 9428
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node2 : Condition
	{
		// Token: 0x060132F2 RID: 78578 RVA: 0x005B2432 File Offset: 0x005B0832
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node2()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x060132F3 RID: 78579 RVA: 0x005B2448 File Offset: 0x005B0848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD0F RID: 52495
		private float opl_p0;
	}
}
