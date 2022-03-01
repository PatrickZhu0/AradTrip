using System;

namespace behaviac
{
	// Token: 0x0200212A RID: 8490
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node2 : Condition
	{
		// Token: 0x06012BE6 RID: 76774 RVA: 0x0058275E File Offset: 0x00580B5E
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node2()
		{
			this.opl_p0 = 0.22f;
		}

		// Token: 0x06012BE7 RID: 76775 RVA: 0x00582774 File Offset: 0x00580B74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5D9 RID: 50649
		private float opl_p0;
	}
}
