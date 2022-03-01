using System;

namespace behaviac
{
	// Token: 0x020024D8 RID: 9432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node24 : Condition
	{
		// Token: 0x060132FA RID: 78586 RVA: 0x005B25E6 File Offset: 0x005B09E6
		public Condition_bt_AutoFight_AutoFight_Gungirl_Manyou_Action_node24()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x060132FB RID: 78587 RVA: 0x005B25FC File Offset: 0x005B09FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CD17 RID: 52503
		private float opl_p0;
	}
}
